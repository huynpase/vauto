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
    public class TextArray : IData
    {
        public string[] Value = new string[0];

        public TextArray()
            : this(new string[] { })
        { }
        public TextArray(string[] value)
        { Value = value; }

        public string Type
        { get { return DataType.Array.ToString(); } }

        public virtual string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Internal.ToString(); } }
       
        public object GetValue() { return Value; }

        public virtual string Evaluate(params object[] args)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");
            
            if (args.Length < 1)
                throw new Exception("Data in array must be accessed through a numeric index.");
            
            if (args.Length > 1)
                throw new Exception("More than one index provided. Array data should be accessed with one index only.");
            
            int index = -1;
            try
            {
                index = Convert.ToInt32(args.GetValue(0));
            }
            catch (Exception exc)
            {
                throw new Exception("Data in array must be accessed through a numeric index.");            
            }

            if (index >= Value.Length)
                throw new Exception("Array index out of range.");
            
            return Value.GetValue(index).ToString();
        }
        public virtual string Evaluate(string property)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");
            
            switch (property.ToLower())
            { 
                case "length":
                    return this.Value.Length.ToString();
                default:
                    throw new Exception("Invalid property '"+property+"' for array data type.");
            }
        }
        public virtual string Evaluate(string method, params object[] args)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");

            switch (method.ToLower())
            {
                default:
                    throw new Exception("Invalid method '" + method + "' for array data type.");
            }
        }
        bool ValidateValue
        {
            get
            {
                if (this.Value == null)
                    return false;
            
                return true;
            }
        }
        public override string ToString()
        {
            return String.Join(",", Value);
        } 
    }
}
