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
using System.IO;
using Vibz.Contract.Data;
using Vibz.Contract.Attribute;
namespace Vibz.Solution.Element.PreCompile
{
    [TypeInfo(Author = "Vibzworld", Details = "Calls another function.",
       Version = "2.0")]
    public class Call : ExpandableInstruction
    {
        internal const string nName = "name";
        internal const string nCall = "call";
        public class Data
        {
            internal const string nName = "name";
            internal const string nData = "data";
        }
        Function OwnerFunction;
        internal Call(Function ownerFunction)
        {
            OwnerFunction = ownerFunction;
        }
        string _name;
        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public override void ExpandInto(XmlNode xnInst, DataHandler idList, ref XmlNode xnTemp)
        {
            try
            {
                XmlNodeList xnlCall = ParseCall(xnInst, idList);
                while (xnlCall.Count > 0)
                {
                    XmlNode xnCallInst = xnlCall.Item(0);
                    xnTemp.AppendChild(xnCallInst);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(Vibz.Contract.Log.LogException.GetFullException(exc));
            }
        }
        XmlNodeList ParseCall(XmlNode xnCall, DataHandler idList)
        {
            string function = (xnCall.Attributes[Call.nName] == null ? "" : xnCall.Attributes[Call.nName].Value);
            try
            {
                string funcName = function.Substring(function.LastIndexOf("/") + 1);
                FileInfo fi = Reference.ResolveFunction(OwnerFunction, function);
                Function fnc = OwnerFunction.OwnerProject.CreateFunction(fi, funcName);
                fnc.DataSet = DataHandler.Load(xnCall.SelectSingleNode(Call.Data.nData), OwnerFunction.Path, Vibz.Interpreter.Data.DataProcessor.Instance);

                string fncText = fnc.GetCompiledText();
                XmlNode node = (XmlNode)xnCall.OwnerDocument.CreateElement(Call.nCall);
                node.InnerXml = fncText;
                return node.SelectSingleNode("//" + Function.nBody).ChildNodes;
            }
            catch (Exception exc)
            {
                throw new Exception("--at function call " + function, exc);
            }
        }
        public static FunctionTypeInfo Info
        {
            get {
                return new FunctionTypeInfo(typeof(Call), typeof(Vibz.Contract.IAction), new Dictionary<string, Vibz.Contract.FunctionType>());
            }
        }
    }
}
