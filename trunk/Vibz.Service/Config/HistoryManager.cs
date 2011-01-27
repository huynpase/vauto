/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
using System;
using System.Collections.Generic;
using System.Text;
using Vibz;
using Vibz.Service.Schedule;
using Vibz.Service.Schedule.Event;
using Vibz.Service.History;
using System.IO;
using System.Xml;
namespace Vibz.Service.Config
{
    public class HistoryManager
    {

        const string DefaultPath = @"Config\ServiceHistory.log";
        string _historyPath;
        List<IHistory> _historyList;
        static HistoryManager _history;
        static object _lock = new object();
        private HistoryManager()
        {
            LoadHistory();
        }
        public static HistoryManager History
        {
            get
            {
                if (_history == null)
                {
                    lock (_lock)
                    {
                        if (_history == null)
                        {
                            _history = new HistoryManager();
                        }
                    }
                }
                return _history;
            }
        }
        public List<IHistory> HistoryList
        {
            get
            {
                if (_historyList == null)
                {
                    _historyList = new List<IHistory>();
                }
                return _historyList;
            }
        }
        LogLevel _logLevel = LogLevel.Debug;
        // Todo: to be changed to Release
        public LogLevel LogLevel
        {
            get { return _logLevel; }
            set { _logLevel = value; }
        }
        public void ClearHistory()
        {
            lock (_lock)
            {
                while (XML.GetDocument(_historyPath).DocumentElement.ChildNodes.Count > 0)
                {
                    XmlNode xNode = XML.GetDocument(_historyPath).DocumentElement.ChildNodes[0];
                    XML.GetDocument(_historyPath).DocumentElement.RemoveChild(xNode);
                }
                XML.GetDocument(_historyPath).Save();
                _historyList = new List<IHistory>();
            }
        }
        public void Reload()
        {
            _historyList = new List<IHistory>();
            XML.GetDocument(_historyPath, NewDocumentText, true);
            LoadHistory();
        }
        void LoadHistory()
        {
            try
            {
                _historyPath = System.Configuration.ConfigurationManager.AppSettings["ServiceHistory"];
                if (_historyPath == null || _historyPath == "")
                {
                    _historyPath = DefaultPath;
                }

                Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                _historyPath = new FileInfo(_historyPath).FullName;

                XML.GetDocument(_historyPath, NewDocumentText);

                // Log(LogLevel.Debug, "Service history loaded.");

                foreach (XmlNode xNode in XML.GetDocument(_historyPath).DocumentElement.ChildNodes)
                {
                    HistoryList.Add(GetHistoryElement(xNode));            
                }
            }
            catch (Exception exc)
            {

            }
        }
        string NewDocumentText
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                XmlNode xNode = (XmlNode)doc.CreateElement(HistoryBase.HistoryDocument.RootNode);
                doc.AppendChild(xNode);
                return doc.DocumentElement.OuterXml;
            }
        }
        IHistory GetHistoryElement(XmlNode node)
        {
            if (node.Name.ToLower() != HistoryBase.HistoryDocument.Log.NodeName)
                return null;
            
            if (node.Attributes[HistoryBase.HistoryDocument.Log.Type] == null)
                throw new Exception("Invalid history log file. " + HistoryBase.HistoryDocument.Log.Type + " is missing.");

            IHistory history = GetHistoryElement(node.Attributes[HistoryBase.HistoryDocument.Log.Type].Value);
            DateTime date = DateTime.MinValue;
            if (node.Attributes[HistoryBase.HistoryDocument.Log.Time] != null)
            {
                DateTime.TryParse(node.Attributes[HistoryBase.HistoryDocument.Log.Time].Value, out date);
            }
            history.LogTime = date;
            history.Load(node);
            return history;
        }
        IHistory GetHistoryElement(string type)
        {
            switch (type.ToLower())
            {
                case "error":
                    return new HistoryException();
                case "event":
                    return new HistoryEvent();
                default:
                case "info":
                    return new HistoryInfo();
            }    
        }
        public void Log(Exception e)
        {
            HistoryException history = new HistoryException(e);
            lock (_lock)
            {
                XML.GetDocument(_historyPath).DocumentElement.AppendChild(history.GetNode(XML.GetDocument(_historyPath)));
                XML.GetDocument(_historyPath).Save();
            }
        }
        public void Log(string message)
        {
            Log(LogLevel.Release, message);
        }
        public void Log(LogLevel level, string message)
        {
            if (level == LogLevel.Release || (LogLevel == LogLevel.Debug))
            {
                HistoryInfo history = new HistoryInfo(message);
                lock (_lock)
                {
                    XML.GetDocument(_historyPath).DocumentElement.AppendChild(history.GetNode(XML.GetDocument(_historyPath)));
                    XML.GetDocument(_historyPath).Save();
                }
            }
        }
        public void Log(IEvent evt)
        {
            HistoryEvent history = new HistoryEvent(evt);
            lock (_lock)
            {
                XML.GetDocument(_historyPath).DocumentElement.AppendChild(history.GetNode(XML.GetDocument(_historyPath)));
                XML.GetDocument(_historyPath).Save();
            }
        }
    }
}
