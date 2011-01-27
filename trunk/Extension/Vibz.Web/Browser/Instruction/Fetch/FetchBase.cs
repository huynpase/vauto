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
using Vibz.Contract.Attribute;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    public abstract class FetchBase : WebInstructionBase, IFetch
    {
        public FetchBase()
        {
            Type = InstructionType.Fetch;
        }
        private string _output = "assignto";
        [XmlAttribute("assignto")][AttributeInfo(WebInstructionBase.AssignToInfo)]
        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
        public abstract IData Fetch();
        public virtual IData Fetch(Vibz.Contract.Data.DataHandler varList)
        {
            try
            {
                vList = varList;
                return Fetch();
            }
            catch (Exception exc)
            {
                throw GetBrowserException(exc);
            }
        }
        
    }
}
