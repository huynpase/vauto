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
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Drags the element on source locator and drops it on destination locator.",
        Version = WebInstructionBase.Vesrion)]
    public class DragAndDrop : ActionBase
    {
        [XmlAttribute("sourcelocator")]
        public string SourceLocator;
        [XmlAttribute("destinationlocator")]
        public string DestinationLocator;
        public DragAndDrop()
            : base()
        {
                    
        }
        public DragAndDrop(string sourceLocator, string destinationLocator)
            : base()
        {
            SourceLocator = sourceLocator;
            DestinationLocator = destinationLocator;
            
        }
        public override void Execute()
        {
            Browser.Document.DragAndDrop(SourceLocator, DestinationLocator);
            SetInfo("Dragged control '" + SourceLocator + "' over '" + DestinationLocator + "'.");
        }
    }
}
