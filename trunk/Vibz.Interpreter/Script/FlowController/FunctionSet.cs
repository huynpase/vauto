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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vibz.Interpreter.Script.FlowController
{
    public class FunctionSet
    {
        ArrayList _function = new ArrayList();
        [XmlElement("function")]
        public Function[] Functions
        {
            get
            {
                Function[] retValue = new Function[_function.Count];
                _function.CopyTo(retValue);
                return retValue;
            }
            set 
            {
                foreach (Function c in value)
                {
                    c.DataSet.DataProcessor = Vibz.Interpreter.Data.DataProcessor.Instance;
                    _function.Add(c);
                }
            }
        }
        public void AddFunction(Function function)
        {
            _function.Add(function);
        }
        public Function GetFunction(string name)
        {
            if (Functions == null)
                return null;
            foreach (Function function in Functions)
            {
                if (function.Name.ToLower() == name.ToLower())
                    return function;
            }
            return null;
        }
    }
}
