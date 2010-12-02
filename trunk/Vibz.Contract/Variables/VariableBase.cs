using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vibz.Contract.Variables
{
    public abstract class VariableBase
    {
        [XmlAttribute("Name")]
        public string Name = "";
        public abstract object GetValue();
        public static VariableBase CreateVariable(string name, object value)
        {
            switch (value.GetType().ToString())
            {
                case "System.String":
                    return new Vibz.Contract.Variables.String(name, (System.String)value);
                case "System.Data.DataTable":
                    return new Vibz.Contract.Variables.DataTable(name, (System.Data.DataTable)value);
                case "System.Int32":
                    return new Vibz.Contract.Variables.Integer(name, (System.Int32)value);
                default:
                    return null;
            }
        }
    }
}
