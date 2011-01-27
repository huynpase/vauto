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
    [System.AttributeUsage(System.AttributeTargets.Class |
          System.AttributeTargets.Struct)
    ]
    public class TypeInfo : System.Attribute
    {
        public string Author;
        public string Details;
        public string Version;
        public bool HasIndeviduality;
        public TypeInfo()
        {
            this.Author = "Unknown";
            this.Details = "Information not available.";
            Version = "1.0";
            HasIndeviduality = true;
        }
        public TypeInfo(string details)
        {
            this.Author = "Unknown";
            this.Details = details;
            Version = "1.0";
            HasIndeviduality = true;
        }
        public TypeInfo(string author, string details)
        {
            this.Author = author;
            this.Details = details;
            Version = "1.0";
            HasIndeviduality = true;
        }
        public TypeInfo(string author, string details, string version)
        {
            this.Author = author;
            this.Details = details;
            this.Version = version;
            HasIndeviduality = true;
        }
        public TypeInfo(string author, string details, string version, bool hasIndeviduality)
        {
            this.Author = author;
            this.Details = details;
            this.Version = version;
            HasIndeviduality = hasIndeviduality;
        }
    }

}
