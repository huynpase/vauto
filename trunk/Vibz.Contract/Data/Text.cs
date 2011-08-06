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
    public class Text : BaseData
    {
        public string Value = "";
        public Text()
            : this("")
        { }
        public Text(string text)
        { Value = text; }
        
        public override string Type
        { get { return DataType.Scalar.ToString(); } }

        public override object GetValue() { return Value; }

        public override string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Internal.ToString(); } }

        public override string Evaluate(params object[] args)
        {
            return Value;
        }
        public override string Evaluate(string property)
        {
            switch (property.ToLower())
            {
                case "length":
                    return this.Value.Length.ToString();
                default:
                    Parameter param = this.Parameters.GetParameter(property.ToLower());
                    if (param == null)
                        throw new Exception("Invalid property '" + property + "' for " + Type + " data type.");
                    return param.Value;
            }
        }
        public override string Evaluate(string method, params object[] args)
        {
            string[] data = new string[args.Length];
            args.CopyTo(data, 0);
            switch (method.ToLower())
            {
                case "indexof":
                    if (data.Length == 1)
                        return Value.IndexOf((string)data[0]).ToString();
                    if (data.Length == 2)
                        return Value.IndexOf((string)data[0], Convert.ToInt32(data[1])).ToString();
                    throw new Exception("Invalid arguments for " + method);
                case "lastindexof":
                    if (data.Length == 1)
                        return Value.LastIndexOf((string)data[0]).ToString();
                    if (data.Length == 2)
                        return Value.LastIndexOf((string)data[0], Convert.ToInt32(data[1])).ToString();
                    throw new Exception("Invalid arguments for " + method);
                case "indexofany":
                    char[] dataC = new char[data.Length];
                    data.CopyTo(dataC, 0);
                    return Value.IndexOfAny(dataC).ToString();
                case "startswith":
                    if (data.Length >= 1)
                        return Value.StartsWith((string)data[0]).ToString();
                    return "false";
                case "endswith":
                    if (data.Length >= 1)
                        return Value.EndsWith((string)data[0]).ToString();
                    return "false";
                case "lastindexofany":
                    dataC = new char[data.Length];
                    data.CopyTo(dataC, 0);
                    return Value.LastIndexOfAny(dataC).ToString();
                case "substring":
                    int startIndex = 0;
                    int length = -1;
                    switch (data.Length)
                    {
                        case 1:
                            startIndex = Vibz.Helper.Math.IsNumber(data[0]) ? Convert.ToInt32(data[0]) : 0;
                            break;
                        case 2:
                            startIndex = Vibz.Helper.Math.IsNumber(data[0]) ? Convert.ToInt32(data[0]) : 0;
                            length = Vibz.Helper.Math.IsNumber(data[1]) ? Convert.ToInt32(data[1]) : -1;
                            break;
                    }
                    if (length != -1)
                        return Value.Substring(startIndex, length);
                    else
                        return Value.Substring(startIndex);
                default:
                    throw new Exception("Invalid method '" + method + "' for text data type.");
            }
        }
        public override string ToString()
        {
            return Value;
        } 
    }
}
