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
using System.IO;
using Vibz.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Contract.Attribute;
using Vibz.Contract.Data;
namespace Vibz.IO.TextFile.Instruction.Action
{
    [TypeInfo(Author="Vibzworld", Details = "Retrieves the latest file modified in the given directory.",
        Version = "2.0")]
    public class GetLatestFileInDirectory : InstructionBase, IFetch
    {
        private string _output = "assignto";
        [XmlAttribute("assignto")]
        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
        string _directory;
        [XmlAttribute("directory")]
        [AttributeInfo("Directory where your want to make the search.", true)]
        public string Directory
        {
            get { return _directory; }
            set { _directory = value; }
        }
        string _pattern;
        [XmlAttribute("pattern")]
        [AttributeInfo("Give some letters in file name, if you want to search from specific file pattern. Leave this empty to search across all files.",false)]
        public string Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }
        public GetLatestFileInDirectory() {
            Type = InstructionType.Fetch;
        }
        public GetLatestFileInDirectory(string directory)
        {
            _directory = directory;
            Type = InstructionType.Action;
        }
        string _fileName = "";
        public IData Fetch(Vibz.Contract.Data.DataHandler varList)
        {
            if (!System.IO.Directory.Exists(this.Directory))
                throw new Exception("Invalid directory path '" + this.Directory + "'.");
            _fileName = Vibz.Helper.IO.GetLastUpdatedFileInDirectory(new DirectoryInfo(Directory), Pattern).FullName;
            return new Text(_fileName);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Latest file '" + _fileName + "' fetched from directory '" + Directory + "'.");
            }
        }
    }
}
