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
using System.Xml;

namespace Vibz.Solution.Element
{
    public class CaseFile : ElementBase
    {
        internal const string nSection = "section";
        internal const string nInclude = "include";
        public const string Extension = Vibz.FileType.TestCase;
        internal CaseFile(FileInfo fInfo, Project ownerProject)
            : base(ownerProject)
        {
            _name = fInfo.Name;
            _path = fInfo.FullName;
        }

        public override ElementType Type { get { return ElementType.Case; } }

        List<IElement> _functions;
        public List<IElement> Functions
        {
            get {
                if (_functions == null)
                    _functions = new List<IElement>();
                return _functions;
            }
            set { _functions = value; }
        }

        public override string FullName
        {
            get
            {
                if (_name == null || _name == "")
                    _name = "<No Name>";
                return _name;
            }
            set { throw new Exception("Full name can not be set for this file."); }
        }
        public override void Load()
        {
            if (!File.Exists(_path))
                throw new Exception("Invalid " + this.GetType().Name + " path.");
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(_path);
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid " + this.GetType().Name + " content. " + exc.Message);
            }
            XmlNodeList xnl = doc.SelectNodes("//function/@name");
            if (xnl == null)
                return;
            Functions.Clear();
            foreach (XmlNode xn in xnl)
            {
                if (xn.NodeType == XmlNodeType.Comment)
                    continue;
                Functions.Add(this.OwnerProject.CreateFunction(new FileInfo(_path), xn.Value));
            }
        }
    }
}
