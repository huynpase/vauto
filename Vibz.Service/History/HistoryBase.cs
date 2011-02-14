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
using System.Xml;

namespace Vibz.Service.History
{
    public abstract class HistoryBase : IHistory
    {
        public class HistoryDocument
        {
            public const string RootNode = "servicehistory";
            public class Log
            {
                public const string NodeName = "log";
                public const string Type = "type";
                public const string Time = "time";
                public const string ThreadId = "tid";
            }
        }
        DateTime _logTime;
        public virtual DateTime LogTime { get { return _logTime; } set { _logTime = value; } }

        public virtual HistoryType Type { get { return HistoryType.Info; } }

        int _threadId;
        public int ThreadId { get { return _threadId; } }

        string _message;
        public virtual string Message { get { return _message; } set { _message = value; } }
        public HistoryBase()
        {
            _threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        }
        public virtual void Load(XmlNode xNode)
        {
            if (xNode == null)
                return;

            _message = xNode.InnerText;

            if (xNode.Attributes[HistoryDocument.Log.Time] == null)
            {
                _logTime = DateTime.MinValue;
            }
            else
            {
                DateTime.TryParse(xNode.Attributes[HistoryDocument.Log.Time].Value, out _logTime);
            }
            if (xNode.Attributes[HistoryDocument.Log.ThreadId] == null)
            {
                _threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            }
            else
            {
                int.TryParse(xNode.Attributes[HistoryDocument.Log.ThreadId].Value, out _threadId);
            }

        }
        public virtual XmlNode GetNode(XmlDocument doc)
        {
            XmlNode node = doc.CreateElement(HistoryDocument.Log.NodeName);

            XmlAttribute attr = doc.CreateAttribute(HistoryDocument.Log.Time);
            attr.Value = LogTime.ToString();
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(HistoryDocument.Log.Type);
            attr.Value = Type.ToString();
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(HistoryDocument.Log.ThreadId);
            attr.Value = ThreadId.ToString();
            node.Attributes.Append(attr);

            return node;
        }
    }
}
