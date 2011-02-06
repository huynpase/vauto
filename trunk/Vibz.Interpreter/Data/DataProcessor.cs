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
        Dictionary<string, IData> _typeCache;

        static DataProcessor _instance;
        static object _padLock = new object();
        private DataProcessor()
        {
            _typeCache = new Dictionary<string, IData>();
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
        public string Evaluate(Var var, params object[] args)
        {
            return GetData(var).Evaluate(args);
        }
        public string Evaluate(Var var, string property)
        {
            return GetData(var).Evaluate(property);        
        }
        public IData LoadData(Var var)
        {
            IData data = Vibz.Interpreter.Configuration.DataManager.GetData(var);
            if (data == null)
                throw new Exception("No handler for data " + var.Source + "|" + var.Type + "|" + var.Name + ".");
            if (_typeCache.ContainsKey(var.Name))
                _typeCache[var.Name] = data;
            else
                _typeCache.Add(var.Name, data);
            return data;
        }
        public string Evaluate(Var var, string method, params object[] args)
        {
            return GetData(var).Evaluate(method, args);        
        }
        public void Export(Var source, Var destination, DataExportMode mode)
        {
            Configuration.DataManager.Export(source, destination, mode);
        }
        IData GetData(Var var)
        {
            /// TODO:
            /// It would be good to cache the data after loading
            /// it for first time to avoid reloading the same external 
            /// source data.
            /// Data may get changed, or same data may get assigned to 
            /// different data source. These thing should be considered 
            /// before caching it.
            return LoadData(var);

            //IData data = null;
            //if (var.Data != null)
            //{
            //    data = var.Data;
            //    if (_typeCache.ContainsKey(var.Name))
            //        _typeCache[var.Name] = data;
            //    else
            //        _typeCache.Add(var.Name, data);
            //}
            //else if (_typeCache.ContainsKey(var.Name))
            //{
            //    if (_typeCache[var.Name] != null)
            //        data = _typeCache[var.Name];
            //    else
            //    {
            //        data = Configuration.DataManager.GetData(var);
            //        if (data == null)
            //            throw new Exception("No handler for data " + var.Source + "|" + var.Type + "|" + var.Name + ".");
            //        _typeCache[var.Name] = data;
            //    }
            //}
            //else
            //{
            //    data = Configuration.DataManager.GetData(var);
            //    if (data == null)
            //        throw new Exception("No handler for data " + var.Source + "|" + var.Type + "|" + var.Name + ".");
            //    _typeCache.Add(var.Name, data);
            //}
            //return data;
        }
    }
}
