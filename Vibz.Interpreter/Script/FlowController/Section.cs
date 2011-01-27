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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Vibz.Interpreter.Script.FlowController
{
    [Serializable()]
    [XmlRoot("section")]
    public class Section : FunctionSet
    {
        [XmlAttribute("version")]
        public string Version;

        ArrayList _includeList = new ArrayList();
        [XmlElement("include")]
        public Include[] IncludeList
        {
            get {
                Include[] retValue = new Include[_includeList.Count];
                _includeList.CopyTo(retValue);
                return retValue;
            }
            set {
                foreach (Include c in value)
                {
                    _includeList.Add(c);
                }
            }
        }
        FunctionSet _global;
        [XmlElement("global")]
        public FunctionSet Global
        {
            get { return _global; }
            set { _global = value; }
        }

        XmlNode _config;
        [XmlElement("app")]
        public XmlNode ConfigSection
        {
            get { return _config; }
            set { _config = value; }
        }

        string _basepath;
        [XmlElement("basepath")]
        public string BasePath
        {
            get { return _basepath; }
            set { _basepath = value; }
        }

        string _reportpath;
        [XmlElement("reportpath")]
        public string ReportPath
        {
            get { return _reportpath; }
            set { _reportpath = value; }
        }
    }
}
