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
