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
using Vibz.Contract.Common;
using Vibz.Contract;
using System.IO;
namespace Vibz.IO.TextFile.Instruction
{
    public abstract class IOInstructionBase : InstructionBase, IError
    {

        protected delegate void delOpern(object content);
        [XmlIgnore()]
        protected delOpern operation;
        string _filePath = "c://file.txt";
        [XmlAttribute("filepath")]
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        string _content = "CONTENT";
        [XmlAttribute("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        protected IOBase IOfile;
        public virtual void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            IOBase iofile = IOFactory.GetIOFile(FilePath);
            operation(vList.Evaluate(Content));
        }
    }
}
