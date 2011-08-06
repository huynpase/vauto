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
    public class KeyValueSet : BaseData
    {
        protected Dictionary<string, string> Value = new Dictionary<string, string>();
        public KeyValueSet()
            : this(new Dictionary<string, string>())
        { }
        public KeyValueSet(Dictionary<string, string> value)
        { Value = value; }

        public override string Type
        { get { return DataType.KeyValueSet.ToString(); } }

        public override string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Internal.ToString(); } }
        public override object GetValue() { return Value; }

        public override string Evaluate(params object[] args)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");

            if (args.Length < 1)
                throw new Exception("Data in array must be accessed through a key text.");

            if (args.Length > 1)
                throw new Exception("More than one key provided. Array data should be accessed with one key only.");

            string key = "";
            try
            {
                key = Convert.ToString(args.GetValue(0));
            }
            catch (Exception exc)
            {
                throw new Exception("Data in array must be accessed through a key text.");
            }

            if (!Value.ContainsKey(key))
                throw new Exception("Key text '" + key + "' not found in the Key set.");
            
            return Value[key];
        }
        public override string Evaluate(string property)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");

            switch (property.ToLower())
            {
                case "length":
                    return this.Value.Count.ToString();
                default:
                    Parameter param = this.Parameters.GetParameter(property.ToLower());
                    if (param == null)
                        throw new Exception("Invalid property '" + property + "' for " + Type + " data type.");
                    return param.Value;
            }
        }
        public override string Evaluate(string method, params object[] args)
        {
            if (!ValidateValue)
                throw new Exception("Data is not initialized.");

            switch (method.ToLower())
            {
                case "add":
                    if (args.Length != 2)
                        throw new Exception("Invalid number of arguments for 'keyvalueset.add'.");
                    Add(args[0].ToString(), args[1].ToString());
                    return "";
                    break;
                default:
                    throw new Exception("Invalid method '" + method + "' for keyvalueset data type.");
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
        #region Dictionary Members
        public bool Contains(string key)
        {
            return Value.ContainsKey(key);
        }
        public void Add(string key, string value)
        {
            Value.Add(key, value);
        }
        public Dictionary<string, string>.KeyCollection Keys
        {
            get { return Value.Keys; }
        }
        public Dictionary<string, string>.ValueCollection Values
        {
            get { return Value.Values; }
        }
        public string this[string key]
        {
            get { return Value[key]; }
            set { Value[key] = value; }
        }
        public override string ToString()
        {
            return "KeyValueSet- Items: " + Value.Count.ToString();
        }
        #endregion
    }
}
