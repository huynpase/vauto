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
        {
            this.Details = "Not Available.";
            Options = new string[] { };
        }
        public AttributeInfo(string details)
        {
            this.Details = details;
            Options = new string[] { };
        }
        public AttributeInfo(string details, string[] options)
        {
            this.Details = details;
            Options = options;
        }
        public AttributeInfo(string details, Type enumType)
        {
            this.Details = details;
            Options = Enum.GetNames(enumType);
        }
        public AttributeInfo(string details, Type enumType, bool isRequired)
        {
            this.Details = details;
            if (enumType != null)
                Options = Enum.GetNames(enumType);
            IsRequired = isRequired;
        }
    }
}
