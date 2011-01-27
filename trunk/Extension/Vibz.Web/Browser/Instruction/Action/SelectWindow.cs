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

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Selects the window associated to given windowid.",
        Version = WebInstructionBase.Vesrion)]
    public class SelectWindow : ActionBase
    {
        [XmlAttribute("windowid")]
        public string WindowId;
        public SelectWindow()
            : base()
        {
                    
        }
        public SelectWindow(string windowId)
            : base()
        {
            WindowId = windowId;
            
        }
        public override void Execute()
        {
            Browser.Document.SelectWindow(WindowId);
            SetInfo("Selected window '" + WindowId + "'.");
        }
    }
}
