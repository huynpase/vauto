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
using Vibz.Contract.Data.Source;

namespace Vibz.Contract.Data
{
    public abstract class ExternalData<T> : IData
    {
        public abstract T Value { get; }
        public abstract string Source { get; }
        public abstract void Load(ParameterSet param);
        public abstract void Export(ParameterSet param, T data, DataExportMode mode);
        public object GetValue() { return Value; }
        public string Type 
        {
            get { return ((IData)Value).Type; }
        }
        public string Evaluate(params object[] args)
        {
            return ((IData)Value).Evaluate(args);
        }
        public string Evaluate(string property)
        {
            return ((IData)Value).Evaluate(property);        
        }
        public virtual string Evaluate(string method, params object[] args)
        {
            return ((IData)Value).Evaluate(method, args);
        }
    }
}
