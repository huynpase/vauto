/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
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
