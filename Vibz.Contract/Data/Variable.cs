using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;

namespace Vibz.Contract.Data
{
    public class Variable : ICompile
    {
        public const string nNodeName = "var";
        public const string nName = "name";
        public const string nSource = "source";
        public const string nType = "type";
        public const string nValue = "value";

        [XmlAttribute(Variable.nName)]
        public string Name;
        string _source = null;
        [XmlAttribute(Variable.nSource)]
        public string Source
        {
            get { if (_source == null && Data != null) _source = Data.Source; return _source; }
            set { _source = value; }
        }
        string _type = null;
        [XmlAttribute(Variable.nType)]
        public string Type
        {
            get { if (_type == null && Data != null) _type = Data.Type; return _type; }
            set { _type = value; }
        }

        [XmlIgnore()]
        public string InnerText = "";
        [XmlElement(Variable.nValue)]
        public XmlCDataSection InnerTextNode
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                return doc.CreateCDataSection(InnerText);
            }
            set
            {
                InnerText = value.Value;
            }
        }

        [XmlIgnore()]
        public IData Data = null;
        [XmlIgnore()]
        public string _filePath;
        [XmlElement(Parameter.nNodeName)]
        public ParameterSet ParamList = new ParameterSet();
        // This constructor should not be used.
        public Variable() { }
        public Variable(string name, IData data) 
        {
            Name = name;
            Data = data;
        }
        public Variable(string fileName) { _filePath = fileName; }
        public Variable(string fileName, string name, IData data, string innerText)
            : this(fileName, name, data.Source, data.Type, data)
        {
            InnerText = innerText;
        }
        public Variable(string fileName, string name, string source, string type, IData data)
        {
            Name = name;
            Data = data;
            Source = source;
            Type = type;
            _filePath = fileName;
        }
        public Variable(string fileName, XmlNode node)
        {
            LoadTypeInstance(node);
            _filePath = fileName;
        }
        void LoadTypeInstance(XmlNode node)
        {
            if (node.Attributes[Variable.nName] == null)
                throw new Exception("Data variables must define its name.");
            Name = node.Attributes[Variable.nName].Value;

            if (node.Attributes[Variable.nSource] != null)
                Source = node.Attributes[Variable.nSource].Value;

            if (node.Attributes[Variable.nType] != null)
                Type = node.Attributes[Variable.nType].Value;

            XmlNodeList xnl = node.SelectNodes(Parameter.nNodeName);
            if (xnl != null && xnl.Count != 0)
            {
                foreach (XmlNode xn in xnl)
                {
                    if (xn.Attributes[Parameter.nName] == null)
                        throw new Exception("Parameter must define its name.");
                    string pname = xn.Attributes[Parameter.nName].Value;
                    ParamList.Add(new Parameter(pname, xn.InnerText));
                }
            }
            else
                InnerText = node.InnerText;
        }
        public Variable Clone
        {
            get
            {
                return new Variable(_filePath, Name, Type, Source, Data);
            }
        }
        public string GetCompiledText()
        {
            string innerXml = "";
            foreach (Parameter param in ParamList)
            {
                innerXml += param.GetCompiledText();
            }

            string retValue = "<" + nNodeName + " " + nName + "='" + Name + "' " +
                nSource + "='" + Source + "' " + nType + "='" + Type + "'>";
            if (innerXml.Trim() == "")
            {
                if (InnerText != null || InnerText != "")
                    retValue += "<" + Variable.nValue + "><![CDATA[" + InnerText + "]]></" + Variable.nValue + ">";
            }
            else
                retValue += innerXml;
            retValue += "</" + nNodeName + ">";
            return retValue;
        }
    }
}
