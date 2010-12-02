using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;

namespace Vibz.Contract.Data
{
    public class Parameter : ICompile
    {
        public const string nNodeName = "param";
        public const string nName = "name";

        [XmlAttribute(Parameter.nName)]
        public string Name = "";
        [XmlText()]
        public string Value = "";

        public Parameter() { }
        public Parameter(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string GetCompiledText()
        {
            string retValue = "<" + nNodeName + " " + nName + "='" + Name + "'>";
            retValue += "<![CDATA[" + Value + "]]>";
            retValue += "</" + nNodeName + ">";
            return retValue;
        }
    }
}
