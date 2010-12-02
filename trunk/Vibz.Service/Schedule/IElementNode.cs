using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace Vibz.Service.Schedule
{
    public interface IElementNode
    {
        string Name { get; set; }
        XmlNode GetNode(XmlDocument doc);
        Dictionary<string, string> GetParameters();
        void SetParameters(Dictionary<string, string> param);
        Dictionary<string, string> MapParameters(Dictionary<string, string> param);
    }
}
