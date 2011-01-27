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
    [System.AttributeUsage(System.AttributeTargets.Field |
          System.AttributeTargets.Property)
    ]
    public class AttributeInfo : System.Attribute
    {
        public bool IsRequired = true;
        public string Details;
        public string[] Options;
        public AttributeInfo()
            : this("Information not available.")
        { }
        public AttributeInfo(string details)
            : this(details, new string[] { })
        { }
        public AttributeInfo(string details, string[] options)
            : this(details, options, true)
        { }
        public AttributeInfo(string details, Type enumType)
            : this(details, enumType, true)
        { }
        public AttributeInfo(string details, bool isRequired)
            : this(details, new string[] { }, isRequired)
        { }
        public AttributeInfo(string details, Type enumType, bool isRequired)
        {
            if (details == null)
                Details = "";
            else
                Details = details;

            if (enumType != null)
                Options = Enum.GetNames(enumType);
            else
                Options = new string[] { };

            if (isRequired == null)
                IsRequired = true;
            else
                IsRequired = isRequired;
        }
        public AttributeInfo(string details, string[] options, bool isRequired)
        {
            if (details == null)
                Details = "";
            else
                Details = details;
            
            if (options == null)
                Options = new string[] { };
            else
                Options = options;

            if (isRequired == null)
                IsRequired = true;
            else
                IsRequired = isRequired;
        }
    }
}
