using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Vibz.Contract.Variables
{
    public class String : VariableBase
    {
        private string _value = "";
        [XmlAttribute("value")]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public String() {
            Value = "";  
        }
        public String(string name, string value)
        {
            Name = name;
            Value = value;  
        }
        public override object GetValue()
        {
            return _value;
        }
    }
}
