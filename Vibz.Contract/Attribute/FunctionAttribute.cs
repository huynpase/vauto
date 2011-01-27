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

namespace Vibz.Contract.Attribute
{
    public class FunctionAttribute
    {
        public string Name = "";
        public AttributeInfo Information = new AttributeInfo();
        public FunctionAttribute(string name, string detail)
            : this(name, detail, true)
        { }
        public FunctionAttribute(string name, string detail, bool isRequired)
            : this(name, detail, null, isRequired)
        { }
        internal FunctionAttribute(string name, string detail, string[] options, bool isRequired)
        {
            Name = name;
            Information.Details = detail;
            Information.IsRequired = isRequired;
            Information.Options = options;
        }
    }
}
