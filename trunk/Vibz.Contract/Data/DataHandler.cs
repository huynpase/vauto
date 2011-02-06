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
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;
namespace Vibz.Contract.Data
{
    public class DataHandler
    {
        public DataHandler() { }
        [XmlElement(Var.nNodeName)]
        public DataCollection DataList = new DataCollection();
        IDataProcessor _dataProcessor = null;
        [XmlIgnore()]
        public IDataProcessor DataProcessor
        {
            get { return _dataProcessor; }
            set { _dataProcessor = value; }
        }
        public DataHandler(IDataProcessor handler)
        {
            _dataProcessor = handler;
        }
        public IData GetData(string name)
        {
            if (!name.StartsWith("@"))
                return new Text(Evaluate(name));
            string nameData = name.Substring(1);
            if (this.DataList.ContainsData(nameData))
                return this.DataList.Get(nameData).Data;
            else
                return new Text(Evaluate(name));
        }
        public string Evaluate(string name)
        {
            try
            {
                if (name.StartsWith("@")) // Variable
                {
                    string nameData = name.Substring(1);
                    string[] key_index = nameData.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    if (key_index == null || key_index.Length == 0)
                        throw new Exception("Invalid data '" + name + "'");

                    if (!this.DataList.ContainsData(key_index.GetValue(0).ToString()))
                    {
                        string[] key_prop = key_index.GetValue(0).ToString().Split(new char[] { '.' }, 2, StringSplitOptions.RemoveEmptyEntries);
                        if (key_prop == null || key_prop.Length == 0)
                            throw new Exception("Invalid data '" + name + "'");

                        string key = key_prop.GetValue(0).ToString();

                        if (!this.DataList.ContainsData(key))
                            return name;
                        else if (key_prop.Length == 1)
                            return DataProcessor.Evaluate(this.DataList.Get(key), new object[0]);

                        if (this.DataList.Get(key).Data != null && this.DataList.Get(key).Data.GetValue() == null)
                            throw new Exception(name + " can not be evaluated as '" + key + "' is null.");

                        string propOrMethod = key_prop.GetValue(1).ToString();

                        if (!propOrMethod.Contains("("))
                        {
                            // Is a Property
                            return DataProcessor.Evaluate(this.DataList.Get(key), propOrMethod);
                        }
                        else
                        {
                            // Is a method
                            string[] key_method = nameData.Split(new char[] { '.' }, 2, StringSplitOptions.RemoveEmptyEntries);
                            string methodArg = key_method.GetValue(1).ToString();
                            if (!methodArg.Trim().EndsWith(")"))
                                return name;
                            string method = methodArg.Substring(0, methodArg.IndexOf('('));
                            string argString = methodArg.Substring(methodArg.IndexOf('(') + 1, methodArg.LastIndexOf(')') - methodArg.IndexOf('(') - 1);
                            string[] argset = argString.Split(new string[] { "," }, StringSplitOptions.None);
                            string[] newArgs = new string[argset.Length];
                            for (int i = 0; i < argset.Length; i++)
                            {
                                newArgs.SetValue(Evaluate(argset.GetValue(i).ToString().Trim()), i);
                            }
                            try
                            {
                                return DataProcessor.Evaluate(this.DataList.Get(key), method, newArgs);
                            }
                            catch (Exception exc)
                            {
                                throw new Exception("Method execution failed. " + exc.Message);
                            }
                        }

                    }

                    nameData = key_index.GetValue(0).ToString();
                    object[] args = new object[key_index.Length - 1];
                    for (int i = 1; i < key_index.Length; i++)
                    {
                        object param = null;
                        try
                        {
                            param = key_index.GetValue(i);
                            if (param.ToString().Length > 0 && this.DataList.ContainsData(param.ToString().Remove(0, 1)))
                                param = this.DataList.Get(param.ToString().Remove(0, 1)).Data.Evaluate(new object[] { null });
                        }
                        catch (Exception exc)
                        {
                            throw new Exception("Encountered '" + key_index.GetValue(i).ToString() + "' when expecting a number.");
                        }
                        args.SetValue(param, i - 1);
                    }
                    return DataProcessor.Evaluate(this.DataList.Get(nameData), args);
                }
                else if (name.StartsWith("#")) // Evaluate Expression
                {
                    string key = name.Substring(1);
                    if (key.Trim() != "")
                    {
                        string[] elements = key.Split(new char[] { '>', '<', '=', '+', '-', '*', '/', '%' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string element in elements)
                        {
                            key = key.Replace(element, Evaluate(element.Trim()));
                        }
                        return EvaluateExpression(key).ToString();
                    }
                }
                return name;
            }
            catch (Exception exc)
            {
                throw new Exception("Error occured while evaluation of '" + name + "'. " + exc.Message);
            }
        }
        double EvaluateExpression(string expression)
        {
            return (double)new System.Xml.XPath.XPathDocument
            (new System.IO.StringReader("<r/>")).CreateNavigator().Evaluate
            (string.Format("number({0})", new
            System.Text.RegularExpressions.Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
            .Replace("/", " div ").Replace("%", " mod ")));
        }
        
        public static DataHandler Load(XmlNode node, string path, IDataProcessor handler)
        {
            DataHandler dh = new DataHandler(handler);
            if (node == null)
                return dh;
            XmlNodeList xnlVars = node.SelectNodes(Var.nNodeName);
            if (xnlVars != null)
            {
                foreach (XmlNode xnv in xnlVars)
                {
                    if (xnv.NodeType == XmlNodeType.Comment)
                        continue;

                    Var dm = new Var(path, xnv);

                    dh.DataList.Update(dm);
                }
            }
            return dh;
        }
        public static IData DefineData(string datatype)
        {
            switch (datatype.ToLower())
            { 
                case "array":
                    return new TextArray();
                case "datatable":
                    return new DataTable();
                case "keyvalueset":
                    return new KeyValueSet();
                case "scalar":
                    return new Text();
                default:
                    throw new Exception("Datatype '" + datatype + "' is not supported.");
            }
        }
    }
}
