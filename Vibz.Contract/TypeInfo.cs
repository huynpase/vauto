using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract
{
    [System.AttributeUsage(System.AttributeTargets.Class |
          System.AttributeTargets.Struct)
    ]
    public class TypeInfo : System.Attribute
    {
        public string Author;
        public string Details;
        public string Version;

        public TypeInfo()
        {
            this.Author = "Unknown";
            this.Details = "Not Available.";
            Version = "1.0";
        }
        public TypeInfo(string details)
        {
            this.Author = "Unknown";
            this.Details = details;
            Version = "1.0";
        }
        public TypeInfo(string author, string details)
        {
            this.Author = author;
            this.Details = details;
            Version = "1.0";
        }
        public TypeInfo(string author, string details, string version)
        {
            this.Author = author;
            this.Details = details;
            this.Version = version;
        }
    }

}
