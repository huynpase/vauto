using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Attribute
{
    public class FunctionAttribute
    {
        public string Name = "";
        public string Detail = "";
        public string[] Options = null;
        public bool IsRequired = true;
        public FunctionAttribute(string name, string detail)
        {
            Name = name;
            Detail = detail;
        }
        public FunctionAttribute(string name, string detail, string[] options)
        {
            Name = name;
            Detail = detail;
            Options = options;
        }
        public FunctionAttribute(string name, string detail, string[] options, bool isRequired)
        {
            Name = name;
            Detail = detail;
            Options = options;
            IsRequired = isRequired;
        }
    }
}
