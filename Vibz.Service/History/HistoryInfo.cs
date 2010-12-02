using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vibz.Service.History
{
    public class HistoryInfo : HistoryBase
    {
        public override HistoryType Type { get { return HistoryType.Info; } }
        public HistoryInfo() { }
        public HistoryInfo(string info)
        {
            Message = info;
            LogTime = DateTime.Now;
        }
        public override XmlNode GetNode(XmlDocument doc)
        {
            XmlNode xNode = base.GetNode(doc);
            XmlCDataSection cdata = doc.CreateCDataSection(Message);
            xNode.AppendChild(cdata);
            return xNode;
        }
    }
}
