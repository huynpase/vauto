using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Vibz.Service.History
{
    public interface IHistory
    {
        DateTime LogTime { get; set; }
        HistoryType Type { get; }
        string Message { get; set; }
        void Load(XmlNode xNode);
        XmlNode GetNode(XmlDocument doc);
    }
}
