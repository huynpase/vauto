using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vibz.Interpreter.Script;
using System.Xml;
using System.IO;
using System.Reflection;
using Vibz.Contract;
namespace Vibz.Interpreter.Plugin
{
    public enum PluginType { Instruction, Macro, Report }
    public class PluginManager
    {
        internal static readonly string RegistryPath = new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName + "/vibz.reg";
        static XmlDocument _document;
        public static XmlDocument Document
        {
            get {
                if (_document == null)
                {
                    _document = new XmlDocument();
                    if (!File.Exists(PluginManager.RegistryPath))
                        throw new Exception("PluginManager: Framework Configuration file not found.");
                    StreamReader sr = new StreamReader(PluginManager.RegistryPath);
                    try
                    {
                        _document.Load(sr);
                        FileSystemWatcher watcher =
                            new FileSystemWatcher(new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "vibz.reg");
                        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
                        watcher.EnableRaisingEvents = true;

                        watcher.Changed += new FileSystemEventHandler(watcher_Changed);
                    }
                    catch (Exception exc)
                    {
                        throw new Exception("PluginManager: Error occured during framework configuration settings. " + exc.Message);
                    }
                    finally
                    {
                        sr.Close();
                        sr.Dispose();
                    }
                }
                return _document;
            }
        }
        public static Version SupportedVersion
        {
            get
            {
                try
                {
                    XmlNode xn = PluginManager.Document.SelectSingleNode("//" + Configuration.Register.NodeName + "/@" + Configuration.Register.VersionSupport);
                    return new Version(xn.Value);
                }
                catch (Exception exc)
                {
                    throw new Exception("Invalid supported version entry.");
                }
            }
        }
        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            _document = null;
        }
        public static PluginAssembly[] GetLockSafePluginList(PluginType group)
        {
            switch (group)
            {
                case PluginType.Macro:
                    return GetLockSafePluginList(Configuration.MacroManager.NodeName, new Type[] { typeof(IMacroFunction), typeof(IMacroVariable) });
                default:
                case PluginType.Instruction:
                    return GetLockSafePluginList(Configuration.InstructionManager.NodeName, new Type[] { typeof(IAssert), typeof(IAction), typeof(IFetch) });
            }
        }
        public static PluginAssemblyInfo[] GetPluginInfoList(PluginType group)
        {
            PluginAssembly[] pAssList = GetLockSafePluginList(group);
            PluginAssemblyInfo[] retValue = new PluginAssemblyInfo[pAssList.Length];
            for (int i = 0; i < retValue.Length; i++)
            {
                PluginAssembly pAss = (PluginAssembly)pAssList.GetValue(i);
                PluginAssemblyInfo pInfo = (pAss.Settings == null ? 
                    new PluginAssemblyInfo(pAss.Name) : 
                    new PluginAssemblyInfo(pAss.Name, pAss.Settings.Clone));
                foreach (string fKey in pAss.Keys)
                {
                    FunctionTypeInfo fTypeInfo = new FunctionTypeInfo(pAss[fKey].Type, pAss[fKey].Interface);
                    pInfo.Add(fKey, fTypeInfo);
                }
                retValue.SetValue(pInfo, i);
            }
            
            return retValue;
        }
        static PluginAssembly[] GetLockSafePluginList(string nodeName, Type[] typeList)
        {
            ArrayList list = new ArrayList();
            Vibz.Contract.Log.LogElement progress = new Vibz.Contract.Log.LogElement("Initializing framework environment.");
            XmlNodeList xnl = PluginManager.Document.SelectNodes("//" + Configuration.Register.NodeName + "/" + nodeName + "/" + Configuration.Register.Include.NodeName);
            foreach (XmlNode xn in xnl)
            {

                if (xn.Attributes == null)
                    continue;
                string path = (xn.Attributes[Configuration.Register.Include.Path] == null ? "" : xn.Attributes[Configuration.Register.Include.Path].Value);
                string name = (xn.Attributes[Configuration.Register.Include.Name] == null ? path : xn.Attributes[Configuration.Register.Include.Name].Value);

                if (path != "")
                {
                    progress.Add("Loading instruction types from " + path);
                    try
                    {
                        PluginAssembly tList = Configuration.ConfigManager.LoadTypes(Vibz.Reflection.Runtime.LoadAssemblyIntoTemporaryDomain(path), typeList);
                        tList.Name = name;
                        tList.Settings = LoadSettings(xn.Attributes[Configuration.Register.Include.Config] == null ? "" : xn.Attributes[Configuration.Register.Include.Config].Value);
                        list.Add(tList);
                    }
                    catch (Exception exc)
                    {
                        progress.Add(exc.Message + "[Plugin:" + name + "]", Vibz.Contract.Log.LogSeverity.Error);
                    }
                    finally
                    {
                        //Vibz.Reflection.Runtime.UnloadTemporaryDomain();
                    }
                }
            }
            PluginAssembly[] retValue = new PluginAssembly[list.Count];
            list.CopyTo(retValue);
            return retValue;
        }
        

        static PluginSettings LoadSettings(string path)
        {
            Vibz.Configuration.ConfigManager manager = Vibz.Configuration.ConfigManager.LoadConfig(Vibz.Reflection.Runtime.GetAbsolutePath(path));
            if (manager == null)
                return null;
            PluginSettings retValue = new PluginSettings();
            foreach (string key in manager.Settings.Keys)
            {
                retValue.Add(key, manager.Settings[key]);
            }
            return retValue;
        }
        

        public static List<IReport> GetReportInfoList()
        {
            List<IReport> reports = new List<IReport>();
            XmlNodeList xnl = PluginManager.Document.SelectNodes("//" + Configuration.Register.NodeName + "/" + Configuration.ReportManager.NodeName + "/" + Configuration.Register.Include.NodeName);
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes == null)
                    continue;
                string name = (xn.Attributes[Configuration.Register.Include.Name] == null ? "" : xn.Attributes[Configuration.Register.Include.Name].Value);
                if (name == "")
                    continue;
                string reference = (xn.Attributes[Configuration.Register.Include.Reference] == null ? "" : xn.Attributes[Configuration.Register.Include.Reference].Value);
                if (reference == "")
                    throw new Exception("Report processor '" + name + "' is corrupted. Reference is missing.");
                string[] refPart = reference.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (refPart.Length != 2)
                    throw new Exception("Reference for Report processor should be specified with assembly path and the class fullname seperated by a comma.");
                string assembly = Vibz.Reflection.Runtime.GetAbsolutePath(refPart.GetValue(0).ToString());
                string clas = refPart.GetValue(1).ToString();

                Dictionary<string, string> paramApp = Vibz.Helper.Xml.GetParameters(xn);

                IReport report = (IReport)Reflection.Runtime.CreateInstanceAndInitialize(Vibz.Reflection.Runtime.LoadAssemblyIntoTemporaryDomain(assembly), clas, "Init", new object[] { paramApp });
                report.Configuration = paramApp;
                report.ReportName = name;
                reports.Add(report);
            }
            return reports;
        }
    }
}
