using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Vibz.Contract.Variables;
namespace Vibz.Contract.Data
{
    [Serializable()]
    public class VariableList1
    {
        //private List<VariableBase> _variables;
        //[
        //XmlElement(Type = typeof(Vibz.Contract.Variables.DataTable)),
        //XmlElement(Type = typeof(Vibz.Contract.Variables.String)),
        //XmlElement(Type = typeof(Vibz.Contract.Variables.Integer))
        //]
        public List<VariableBase> Variables
        {
            get
            {
                if (_variables == null)
                    _variables = new List<VariableBase>();
                return _variables;
            }
            set
            {
                _variables = value;
            }
        }
        public void Add(VariableBase variable)
        {
            Variables.Add(variable);
        }
        public VariableBase TryGetVariable(string name)
        {
            foreach (VariableBase vBase in this.Variables)
            {
                if (vBase.Name == name)
                    return vBase;
            }
            return null;
        }
    }
}
