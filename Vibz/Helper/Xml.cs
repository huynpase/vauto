using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vibz.Helper
{
    public class Xml
    {
        public static Dictionary<string, string> GetParameters(XmlNode node)
        {
            Dictionary<string, string> retValue = new Dictionary<string, string>();
            XmlNodeList xnl = node.SelectNodes("param");
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes["name"] == null)
                    throw new Exception("Name attribute is mandatory for a parameter node. " + xn.OuterXml);
                retValue.Add(xn.Attributes["name"].Value, (xn.Attributes["value"] == null ? "" : xn.Attributes["value"].Value));
            }
            return retValue;
        }
        public static string Encode(string text)
        {
            return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
        public static string Decode(string text)
        {
            return text.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">");
        }
    }
}
