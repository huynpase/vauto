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
    public class NodeInfo : System.Attribute
    {
        public bool IsRequired = true;
        public string Details;
        public NodeInfo()
        {
            this.Details = "Information not available.";
        }
        public NodeInfo(string details)
        {
            this.Details = details;
        }
        public NodeInfo(string details, bool isRequired)
        {
            this.Details = details;
            IsRequired = isRequired;
        }
    }
}
