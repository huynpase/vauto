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
using Vibz.Contract.Data;
namespace Vibz.Interpreter.Data
{
    public class DataProcessor : IDataProcessor
    {
        Dictionary<Variable, IData> _typeCache;

        static DataProcessor _instance;
        static object _padLock = new object();
        private DataProcessor()
        {
            _typeCache = new Dictionary<Variable, IData>();
        }
        public static void Reset()
        {
            _instance = null;
            Configuration.DataManager.Reset();
        }
        public static DataProcessor Instance
        {
            get {
                if (_instance == null)
                {
                    lock (_padLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataProcessor();
                        }
                    }
                }
                return _instance;
            }
        }
        public string Evaluate(Variable var, params object[] args)
        {
            return GetData(var).Evaluate(args);
        }
        public string Evaluate(Variable var, string property)
        {
            return GetData(var).Evaluate(property);        
        }
        public string Evaluate(Variable var, string method, params object[] args)
        {
            return GetData(var).Evaluate(method, args);        
        }
        public void Export(Variable source, Variable destination, DataExportMode mode)
        {
            Configuration.DataManager.Export(source, destination, mode);
        }
        IData GetData(Variable var)
        {
            IData data = null;
            if (_typeCache.ContainsKey(var))
                data = _typeCache[var];
            else
            {
                data = Configuration.DataManager.GetData(var);
                if (data == null)
                    throw new Exception("No handler for data " + var.Source + "|" + var.Type + "|" + var.Name + ".");
                _typeCache.Add(var, data);
            }
            return data;
        }
    }
}