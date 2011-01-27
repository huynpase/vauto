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
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Checks existance of the control associated with given locator.",
        Version = WebInstructionBase.Vesrion)]
    public class IsExists : AssertBase
    {

        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
        public string Locator;
        public IsExists()
            : base()
        {
                   
        }
        public IsExists(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override bool Assert()
        {
            bool result = Browser.Document.IsExists(Locator);
            SetInfo("Control '" + Locator + "' " + (result ? "exists" : "does not exists") + ".");
            return result;
        }
    }
}
