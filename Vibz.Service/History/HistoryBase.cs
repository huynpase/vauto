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
            }
        }
        DateTime _logTime;
        public virtual DateTime LogTime { get { return _logTime; } set { _logTime = value; } }

        public virtual HistoryType Type { get { return HistoryType.Info; } }

        string _message;
        public virtual string Message { get { return _message; } set { _message = value; } }

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

            return node;
        }
    }
}
