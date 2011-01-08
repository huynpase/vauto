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
