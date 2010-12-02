using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using Vibz.Contract.Log;
using Vibz.Plugin.Plug;
using Vibz.Zip;

namespace Vibz.Plugin
{
    public enum ProcessType { Validate, Execute }
    public abstract class Processor
    {
        Dictionary<string, string> _processorParam = null;
        DirectoryInfo _sourceDir;
        public Processor(string sourcePath)
            : this(sourcePath, null)
        {
            
        }
        public Processor(string sourcePath, Dictionary<string, string> processorParam)
        {
            _processorParam = processorParam;

            string tempFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName + "/_tempPlugin";
            ZipHelper zh = new ZipHelper();
            if (Directory.Exists(tempFolder))
                Directory.Delete(tempFolder, true);
            _sourceDir = Directory.CreateDirectory(tempFolder);
            if (!zh.ExtractFilesFromZip(sourcePath, _sourceDir.FullName, ""))
            {
                LogQueue.Instance.Enqueue(new LogQueueElement("Invalid Plugin type.", LogSeverity.Info));
                return;
            }

            if (_processorParam == null)
                _processorParam = new Dictionary<string, string>();

            _processorParam.Add("RootPath", PlugManager.GetConfig().RootFolder);
        }
        protected bool Execute(ProcessType type)
        {
            bool retValue = true;
            FileInfo[] plugs = _sourceDir.GetFiles("*.plg", SearchOption.AllDirectories);
            foreach (FileInfo plug in plugs)
            {
                StreamReader sr = new StreamReader(plug.FullName);
                try
                {
                    LogQueue.Instance.Enqueue(new LogQueueElement(GetVerb(type) + " plugger '" + plug.FullName + "'.", LogSeverity.Info));
                    XmlDocument doc = new XmlDocument();
                    doc.Load(sr);
                    LogQueue.Instance.Enqueue(new LogQueueElement("Plugger loaded successfully.", LogSeverity.Info));
                    XmlNode xnPlugin = doc.SelectSingleNode("plugin");
                    if (xnPlugin == null)
                    {
                        LogQueue.Instance.Enqueue(new LogQueueElement("Invalid plugger content. Expected 'plugin' to be the root node.", LogSeverity.Error));
                        if (type == ProcessType.Validate)
                            retValue = false;
                        continue;
                    }
                    
                    if (xnPlugin.Attributes["type"] != null)
                    {
                        if (_processorParam.ContainsKey("PluginType"))
                            _processorParam["PluginType"] = xnPlugin.Attributes["type"].Value;
                        else
                            _processorParam.Add("PluginType", xnPlugin.Attributes["type"].Value);
                    }
                    PlugFactory pFactory = new PlugFactory(_sourceDir.FullName, _processorParam);

                    XmlNode xNodeInit = xnPlugin.SelectSingleNode("init");
                    if (xNodeInit != null)
                    {
                        pFactory.Init(xNodeInit);
                    }
                    XmlNode xNodeOps = xnPlugin.SelectSingleNode("operation");
                    if (xNodeOps == null)
                    {
                        LogQueue.Instance.Enqueue(new LogQueueElement("Plugger operation is empty.", LogSeverity.Error));
                        if (type == ProcessType.Validate)
                            retValue = false;
                        continue;
                    }

                    XmlNodeList xnl = xNodeOps.ChildNodes;
                    if (xnl.Count == 0)
                    {
                        LogQueue.Instance.Enqueue(new LogQueueElement("Plugger operation content is empty.", LogSeverity.Error));
                        if (type == ProcessType.Validate)
                            retValue = false;
                        continue;
                    }
                    try
                    {
                        foreach (XmlNode xNode in xnl)
                        {
                            LogQueue.Instance.Enqueue(new LogQueueElement(GetVerb(type) + " plug '" + xNode.Name + "'.", LogSeverity.Info));
                            IPlug plg = pFactory.GetPlugHandler(xNode);
                            if (plg == null)
                                throw new Exception("Invalid plug command. " + xNode.OuterXml);
                            LogQueue.Instance.Enqueue(new LogQueueElement("Plug handler for '" + xNode.Name + "' found.", LogSeverity.Info));
                            try
                            {
                                switch (type)
                                {
                                    case ProcessType.Validate:
                                        if (!plg.VerificationNeeded)
                                        {
                                            LogQueue.Instance.Enqueue(new LogQueueElement("Verification skipped.", LogSeverity.Info));
                                            break;
                                        }
                                        if (!plg.CanExecute)
                                        {
                                            LogQueue.Instance.Enqueue(new LogQueueElement(plg.Message, LogSeverity.Error));
                                            LogQueue.Instance.Enqueue(new LogQueueElement("Error while executing plugin '" + xNode.OuterXml + "'", LogSeverity.Error));
                                            retValue = false;
                                        }
                                        else
                                            LogQueue.Instance.Enqueue(new LogQueueElement("Validation passed.", LogSeverity.Info));
                                        break;
                                    case ProcessType.Execute:
                                        if (!plg.TryExecute())
                                        {
                                            LogQueue.Instance.Enqueue(new LogQueueElement(plg.Message, LogSeverity.Error));
                                            LogQueue.Instance.Enqueue(new LogQueueElement("Error while executing plugin '" + xNode.OuterXml + "'", LogSeverity.Error));
                                            return false;
                                        }
                                        else
                                            LogQueue.Instance.Enqueue(new LogQueueElement("Execution passed.", LogSeverity.Info));
                                        break;
                                }
                            }
                            finally
                            {
                                plg.Dispose();
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        LogQueue.Instance.Enqueue(new LogQueueElement("Invalid plugin. " + LogException.GetFullException(exc), LogSeverity.Error));
                        if (type == ProcessType.Validate)
                            retValue = false;
                    }
                }
                catch (Exception exc)
                {
                    LogQueue.Instance.Enqueue(new LogQueueElement("Invalid Plugin. Plugger content invalid." + LogException.GetFullException(exc), LogSeverity.Error));
                    if (type == ProcessType.Validate)
                        retValue = false;
                    continue;
                }
                finally
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
            return retValue;
        }
        protected void Cleanup()
        {
            try
            {
                if (Directory.Exists(_sourceDir.FullName))
                    Directory.Delete(_sourceDir.FullName, true);
            }
            catch (Exception exc)
            {
                LogQueue.Instance.Enqueue(new LogQueueElement("Deleting temporary files failed. " + exc.Message, LogSeverity.Error));
            }
        }
        static string GetVerb(ProcessType type)
        {
            switch (type)
            {
                case ProcessType.Execute:
                    return "Executing";
                case ProcessType.Validate:
                    return "Validating";
            }
            return type.ToString() + "ing";
        }
    }
}
