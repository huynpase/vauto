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

namespace Vibz.Web.Browser.Instruction.Assert
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Checks if the given text is present or not.",
        Version = WebInstructionBase.Vesrion)]
    public class IsTextPresent : AssertBase
    {

        [XmlAttribute("text")]
        public string Text;
        public IsTextPresent()
            : base()
        {

        }
        public IsTextPresent(string text)
            : base()
        {
            Text = text;
            
        }
        public override bool Assert()
        {
            bool result = Browser.Document.IsTextPresent(vList.Evaluate(Text));
            SetInfo("Text '" + Text + "' is " + (result ? "present" : "not present") + ".");
            return result;
        }
    }
}
