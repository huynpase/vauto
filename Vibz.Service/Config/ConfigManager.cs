using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Vibz;
using Vibz.Service.Schedule;
using Vibz.Service.Schedule.Event;
namespace Vibz.Service.Config
{
    public class ConfigManager
    {
        const string DefaultPath = @"Config\VibzSchedule.config";
        string _schedulePath;
        List<ISchedule> _scheduleList;
        static ConfigManager _config;
        static object _lock = new object();
        private ConfigManager()
        {
            LoadSchedule();
        }
        public List<ISchedule> ScheduleList
        {
            get {
                if (_scheduleList == null)
                {
                    _scheduleList = new List<ISchedule>();
                }
                return _scheduleList;
            }
        }
        public static ConfigManager Configuration
        {
            get
            {
                if (_config == null)
                {
                    lock (_lock)
                    {
                        if (_config == null)
                        {
                            _config = new ConfigManager();
                        }
                    }
                }
                return _config;
            }
        }
        int _maxThreadCount = 1;
        double _tickInterval = 300000;
        public int MaxThreadCount
        {
            get { return _maxThreadCount; }
        }
        
        public double TickInterval
        {
            get { return _tickInterval; }
        }
        public void UpdateScheduleService(double tickInterval, int threadCount, LogLevel level)
        {
            lock (_lock)
            {
                XmlNode xNode = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/@" + ScheduleBase.ScheduleDocument.MaxThreadCount);
                xNode.Value = threadCount.ToString();

                xNode = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/@" + ScheduleBase.ScheduleDocument.TickInterval);
                xNode.Value = tickInterval.ToString();

                xNode = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/@" + ScheduleBase.ScheduleDocument.LogLevel);
                xNode.Value = level.ToString();

                _tickInterval = tickInterval;
                _maxThreadCount = threadCount;
                HistoryManager.History.LogLevel = level;

                XML.GetDocument(_schedulePath).Save();
            }
        }
        public void DeleteElement(IElementNode ele)
        {
            XmlNode nodeToDelete = null;
            XmlNode rootNode = null;
            if (ele.GetType().GetInterface(typeof(ISchedule).FullName) != null)
            {
                nodeToDelete = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/" + ScheduleBase.ScheduleDocument.Schedule.NodeName + "[@" + ScheduleBase.ScheduleDocument.Schedule.Name + "='" + ele.Name + "']");
                rootNode = XML.GetDocument(_schedulePath).DocumentElement;
            }
            else if (ele.GetType().GetInterface(typeof(IEvent).FullName) != null)
            {
                nodeToDelete = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/" + ScheduleBase.ScheduleDocument.Schedule.NodeName + "[@" + ScheduleBase.ScheduleDocument.Schedule.Name + "='" + ((IEvent)ele).ScheduleName + "']/" + EventBase.Event.NodeName + "[@" + EventBase.Event.Name + "='" + ((IEvent)ele).Name + "']");
                rootNode = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/" + ScheduleBase.ScheduleDocument.Schedule.NodeName + "[@" + ScheduleBase.ScheduleDocument.Schedule.Name + "='" + ((IEvent)ele).ScheduleName + "']");
                if (nodeToDelete.ParentNode.ChildNodes.Count == 1)
                {
                    nodeToDelete = rootNode;
                    rootNode = XML.GetDocument(_schedulePath).DocumentElement;
                }
            }
            rootNode.RemoveChild(nodeToDelete);
            XML.GetDocument(_schedulePath).Save();
        }
        public void UpdateElement(IElementNode newEle)
        {
            if (newEle.GetType().GetInterface(typeof(ISchedule).FullName) != null)
            {
                UpdateSchedule((ISchedule)newEle);
            }
            else if (newEle.GetType().GetInterface(typeof(IEvent).FullName) != null)
            {
                UpdateEvent((IEvent)newEle);
            }
        }
        public void UpdateSchedule(ISchedule newSchedule)
        {
            lock (_lock)
            {
                XmlNode newNode = newSchedule.GetNode(XML.GetDocument(_schedulePath));
                XmlNode nodeToReplace = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/" + ScheduleBase.ScheduleDocument.Schedule.NodeName + "[@" + ScheduleBase.ScheduleDocument.Schedule.Name + "='" + newSchedule.Name + "']");
                
                XmlElement rootNode = XML.GetDocument(_schedulePath).DocumentElement;
                if (nodeToReplace == null)
                {
                    if (newNode.ChildNodes.Count != 0)
                        rootNode.AppendChild(newNode);
                }
                else
                {
                    if (newNode.ChildNodes.Count != 0)
                    {
                        rootNode.ReplaceChild(newNode, nodeToReplace);
                    }
                    else
                    {
                        rootNode.RemoveChild(nodeToReplace);
                    }
                }
                XML.GetDocument(_schedulePath).Save();
                LoadSchedule();
            }
        }
        
        public void UpdateEvent(IEvent evt)
        {
            lock (_lock)
            {
                XmlNode newNode = evt.GetNode(XML.GetDocument(_schedulePath));
                XmlNode nodeToReplace = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/" + ScheduleBase.ScheduleDocument.Schedule.NodeName + "[@" + ScheduleBase.ScheduleDocument.Schedule.Name + "='" + evt.ScheduleName + "']/" + EventBase.Event.NodeName + "[@" + EventBase.Event.Name + "='" + evt.Name + "']");
                XmlNode rootNode = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/" + ScheduleBase.ScheduleDocument.Schedule.NodeName + "[@" + ScheduleBase.ScheduleDocument.Schedule.Name + "='" + evt.ScheduleName + "']");
                if (rootNode == null)
                    return;
                if (nodeToReplace == null)
                {
                    rootNode.AppendChild(newNode);
                }
                else
                {
                    rootNode.ReplaceChild(newNode, nodeToReplace);
                }
                XML.GetDocument(_schedulePath).Save();
                LoadSchedule();
            }
        }
        void LoadSchedule()
        {
            try
            {
                _schedulePath = System.Configuration.ConfigurationManager.AppSettings["ServiceSchedule"];
                if (_schedulePath == null || _schedulePath == "")
                {
                    _schedulePath = DefaultPath;
                }

                Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                _schedulePath = new FileInfo(_schedulePath).FullName;
                // HistoryManager.History.Log(LogLevel.Debug, "Schedule path: " + _schedulePath);
                XML.GetDocument(_schedulePath, NewDocumentText);

                XmlNode xNode = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/@" + ScheduleBase.ScheduleDocument.MaxThreadCount);
                _maxThreadCount = Vibz.Helper.Math.TryGetInteger(xNode.Value, 1);
                // HistoryManager.History.Log(LogLevel.Debug, "Maximum thread count: " + _maxThreadCount.ToString());

                xNode = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/@" + ScheduleBase.ScheduleDocument.TickInterval);
                _tickInterval = Vibz.Helper.Math.TryGetInteger(xNode.Value, 300000);
                // HistoryManager.History.Log(LogLevel.Debug, "Tick Interval: " + _tickInterval.ToString());

                xNode = XML.GetDocument(_schedulePath).SelectSingleNode(ScheduleBase.ScheduleDocument.RootNode + "/@" + ScheduleBase.ScheduleDocument.LogLevel);
                if (xNode != null)
                {
                    HistoryManager.History.LogLevel = GetLogLevel(xNode.Value);
                    // HistoryManager.History.Log(LogLevel.Debug, "Log level: " + HistoryManager.History.LogLevel.ToString());
                }
                if (XML.GetDocument(_schedulePath).ChildNodes == null || XML.GetDocument(_schedulePath).DocumentElement.ChildNodes.Count == 0)
                    return;
                // HistoryManager.History.Log(LogLevel.Debug, "Task Count: " + _doc.DocumentElement.ChildNodes.Count.ToString());
                _scheduleList = new List<ISchedule>();
                foreach (XmlNode xn in XML.GetDocument(_schedulePath).DocumentElement.ChildNodes)
                {
                    ISchedule schedule = GetScheduleElement(xn);
                    if (schedule != null)
                    {
                        HistoryManager.History.Log(LogLevel.Debug, "Schedule '" + schedule.Name + "' loaded: ");
                        ScheduleList.Add(schedule);
                    }
                    else
                        HistoryManager.History.Log(LogLevel.Debug, "Invalid schedule type [" + xn.InnerXml + "].");
                }
            }
            catch (Exception exc)
            {
                HistoryManager.History.Log("Error while loading schedules. " + exc.Message);
                throw new Exception("Error while loading schedules. " + exc.Message);
            }
        }
        public LogLevel GetLogLevel(string logLevel)
        {
            switch (logLevel.ToLower())
            { 
                case "debug":
                    return LogLevel.Debug;
                default:
                case "release":
                    return LogLevel.Release;
            }

        }
        string NewDocumentText
        {
            get
            {
                lock (_lock)
                {
                    XmlDocument doc = new XmlDocument();

                    XmlNode xNode = (XmlNode)doc.CreateElement(ScheduleBase.ScheduleDocument.RootNode);
                    doc.AppendChild(xNode);

                    XmlAttribute attr = doc.CreateAttribute(ScheduleBase.ScheduleDocument.MaxThreadCount);
                    attr.Value = "1";
                    xNode.Attributes.Append(attr);

                    attr = doc.CreateAttribute(ScheduleBase.ScheduleDocument.TickInterval);
                    attr.Value = "300000";
                    xNode.Attributes.Append(attr);

                    attr = doc.CreateAttribute(ScheduleBase.ScheduleDocument.LogLevel);
                    attr.Value = LogLevel.Release.ToString();
                    xNode.Attributes.Append(attr);

                    return doc.DocumentElement.OuterXml;
                }
            }
        }
        ISchedule GetScheduleElement(XmlNode node)
        {
            if (node.Name.ToLower() != ScheduleBase.ScheduleDocument.Schedule.NodeName)
                return null;

            if (node.Attributes[ScheduleBase.ScheduleDocument.Schedule.Type] == null)
                throw new Exception("Invalid schedule config. " + ScheduleBase.ScheduleDocument.Schedule.Type + " is missing.");

            ISchedule schedule = ElementFactory.GetScheduleElement(node.Attributes[ScheduleBase.ScheduleDocument.Schedule.Type].Value);
            HistoryManager.History.Log(LogLevel.Debug, "Loading schedule type [" + node.Attributes[ScheduleBase.ScheduleDocument.Schedule.Type].Value + "].");
            schedule.Load(node);
            return schedule;
        }
    }
}
