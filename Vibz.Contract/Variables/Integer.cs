using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Vibz.Contract.Variables
{
    public class Integer : VariableBase
    {
        private int _value = 0;
        [XmlAttribute("value")]
        public int Value
        {
            get { return _value;  }
            set { _value = value; }
        }
        public Integer() {
            Value = 0;  
        }
        public Integer(string name, int value)
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
