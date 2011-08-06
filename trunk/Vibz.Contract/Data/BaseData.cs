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

namespace Vibz.Contract.Data
{
    public class BaseData : IData
    {
        ParameterSet _parameters;
        public object Value = "";
        public BaseData()
            : this(null)
        { }
        public BaseData(object val)
        { Value = val; }
        
        public virtual string Type
        { get { return DataType.None.ToString(); } }

        public virtual object GetValue() { return Value; }

        public virtual string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Internal.ToString(); } }
        public ParameterSet Parameters
        {
            get {
                if (_parameters == null)
                    _parameters = new ParameterSet();
                return _parameters; }
            set { _parameters = value; }
        }
        public virtual string Evaluate(params object[] args)
        {
            return Value.ToString();
        }
        public virtual string Evaluate(string property)
        {
            switch (property.ToLower())
            {
                default:
                    throw new Exception("Invalid property '" + property + "' for " + Type + " data type.");
            }
        }
        public virtual string Evaluate(string method, params object[] args)
        {
            string[] data = new string[args.Length];
            args.CopyTo(data, 0);
            switch (method.ToLower())
            {
                default:
                    throw new Exception("Invalid method '" + method + "' for " + Type + " data type.");
            }
        }
        public override string ToString()
        {
            return Value.ToString();
        } 
    }
}
