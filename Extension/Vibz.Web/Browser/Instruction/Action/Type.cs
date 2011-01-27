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
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Types the given text on the control associated to given locator.",
        Version = WebInstructionBase.Vesrion)]
    
    public class Type : ActionBase
    {
        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
        public string Locator;
        [XmlAttribute("value")]
        [AttributeInfo("Value to be inserted.")]
        public string Value;
        public Type()
            : base()
        {
                    
        }
        public Type(string locator, string value)
            : base()
        {
            Locator = locator;
            Value = value;
        }
        public override void Execute()
        {
            Browser.Document.Type(Locator, vList.Evaluate(Value));
            SetInfo("Typed '" + Value + "' on '" + Locator + "'.");
        }
    }
}
