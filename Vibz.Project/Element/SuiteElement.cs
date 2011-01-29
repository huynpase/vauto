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
using System.Xml.Serialization;
using Vibz.Contract;
namespace Vibz.Solution.Element
{
    public abstract class SuiteElement : ElementBase, ICompile
    {
        public SuiteElement() { }
        public SuiteElement(Project ownerProject)
            : base(ownerProject)
        { }
        List<string> _includes;
        [XmlIgnore()]
        public List<string> Includes
        {
            get
            {
                if (_includes == null)
                    _includes = new List<string>();
                return _includes;
            }
        }
        internal string _fullname;
        [XmlAttribute(Element.ElementBase.nReference)]
        public override string FullName
        {
            get
            {
                if (_fullname == null)
                {
                    if (_path == null || _path == "")
                        return "<No Name>";
                    FileInfo fi = new FileInfo(_path);
                    _fullname = fi.FullName.Substring(0, fi.FullName.LastIndexOf('.'));
                    _fullname = _fullname.Replace("\\", "/");
                    _fullname = _fullname.Replace(this.OwnerProject.FullName, "");
                }
                return _fullname;
            }
            set { _fullname = value; }
        }

        public virtual void UnLoad() { }
    }
}
