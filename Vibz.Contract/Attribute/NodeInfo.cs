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
