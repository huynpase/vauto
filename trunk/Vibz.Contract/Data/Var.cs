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
using System.Xml.Serialization;
using Vibz.Contract;

namespace Vibz.Contract.Data
{
    public class Var : InstructionBase, IAction, ICompile
    {
        public const string nNodeName = "var";
        public const string nName = "name";
        public const string nSource = "source";
        public const string nType = "type";
        public const string nValue = "value";

        [XmlAttribute(Var.nName)]
        public string Name;
        string _source = null;
        [XmlAttribute(Var.nSource)]
        public string Source
        {
            get {
                if (_source == null)
                {
                    if (Data != null)
                        _source = Data.Source;
                    else
                        _source = Vibz.Contract.Data.Source.SourceType.Internal.ToString().ToLower();
                }

                return _source; 
            }
            set { _source = value; }
        }
        string _type = null;
        [XmlAttribute(Var.nType)]
        public string Type
        {
            get { 
                if (_type == null) 
                {
                    if (Data != null)
                        _type = Data.Type;
                    else
                        _type = Vibz.Contract.Data.DataType.Scalar.ToString().ToLower();
                }
                return _type; 
            }
            set { _type = value; }
        }

        [XmlIgnore()]
        public string InnerText = "";
        [XmlElement(Var.nValue)]
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
        public Var() { }
        public Var(string name, IData data) 
        {
            Name = name;
            Data = data;
        }
        public Var(string fileName) { _filePath = fileName; }
        public Var(string fileName, string name, IData data, string innerText)
            : this(fileName, name, data.Source, data.Type, data)
        {
            InnerText = innerText;
        }
        public Var(string fileName, string name, string source, string type, IData data)
        {
            Name = name;
            Data = data;
            Source = source;
            Type = type;
            _filePath = fileName;
        }
        public Var(string fileName, XmlNode node)
        {
            LoadTypeInstance(node);
            _filePath = fileName;
        }
        void LoadTypeInstance(XmlNode node)
        {
            if (node.Attributes[Var.nName] == null)
                throw new Exception("Data variables must define its name.");
            Name = node.Attributes[Var.nName].Value;

            if (node.Attributes[Var.nSource] != null)
                Source = node.Attributes[Var.nSource].Value;

            if (node.Attributes[Var.nType] != null)
                Type = node.Attributes[Var.nType].Value;

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
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            vList.DataList.Update(Name, vList.DataProcessor.LoadData(this));
        }
        public Var Clone
        {
            get
            {
                return new Var(_filePath, Name, Type, Source, Data);
            }
        }
        public override string ToString()
        {
            if ((this.Source==null || this.Type==null) || this.Source.ToLower() == Vibz.Contract.Data.Source.SourceType.Internal.ToString().ToLower()
                            && this.Type.ToLower() == Vibz.Contract.Data.DataType.Scalar.ToString().ToLower())
            {
                return (this.InnerText == null ? "" : this.InnerText);
            }
            else
            {
                return "[" + this.Source + ":" + this.Type + "]";
            }
        }
        public bool IsInternal
        {
            get {
                return (this.Source == null || this.Source.ToLower() == Vibz.Contract.Data.Source.SourceType.Internal.ToString().ToLower());
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
                    retValue += "<" + Var.nValue + "><![CDATA[" + InnerText + "]]></" + Var.nValue + ">";
            }
            else
                retValue += innerXml;
            retValue += "</" + nNodeName + ">";
            return retValue;
        }
    }
}
