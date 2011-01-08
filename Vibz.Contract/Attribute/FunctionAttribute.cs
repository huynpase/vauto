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
