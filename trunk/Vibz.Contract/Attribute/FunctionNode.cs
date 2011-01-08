using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Attribute
{
    public class FunctionNode
    {
        public string Name = "";
        public NodeInfo Information = null;
        public FunctionNode(string name, string detail)
            : this(name, detail, true)
        { }
        public FunctionNode(string name, string detail, bool isRequired)
        {
            Name = name;
            Information = new NodeInfo();
            Information.Details = detail;
            Information.IsRequired = isRequired;
        }
    }
}
