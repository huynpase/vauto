using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
namespace Vibz.Contract.Variables
{
    public class DataTable : VariableBase
    {
        private System.Data.DataTable _value;
        //[XmlAttribute("value")]
        [XmlIgnore()]
        public System.Data.DataTable Value
        {
            get
            {
                if (_value == null)
                    _value = new System.Data.DataTable();
                return _value;
            }
            set { _value = value; }
        }
        public DataTable() {
            Value = new System.Data.DataTable();  
        }
        public DataTable(string name, System.Data.DataTable value)
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
