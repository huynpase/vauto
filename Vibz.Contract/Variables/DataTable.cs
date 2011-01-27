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
