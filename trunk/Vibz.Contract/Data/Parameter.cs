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
