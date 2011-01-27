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
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Opens the given url in a new browser.",
        Version = WebInstructionBase.Vesrion)]
    public class OpenWindow : SynchronizeBase
    {
        [XmlAttribute("url")]
        public string Url;
        public OpenWindow()
            : base()
        {
                    
        }
        public OpenWindow(string url, int maxWait)
            : base()
        {
            MaxWait = maxWait;
            Url = url;
            
        }
        public override void Execute()
        {
            Browser.Document.OpenWindow(vList.Evaluate(Url), MaxWait);
            SetInfo("Window opened. Url: " + Url + ".");
        }
    }
}
