using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Data
{
    public class Text : IData
    {
        public string Value = "";
        public Text()
            : this("")
        { }
        public Text(string text)
        { Value = text; }
        
        public string Type
        { get { return DataType.Scalar.ToString(); } }

        public virtual string Source
        { get { return Vibz.Contract.Data.Source.SourceType.Internal.ToString(); } }

        public virtual string Evaluate(params object[] args)
        {
            return Value;
        }
        public virtual string Evaluate(string property)
        {
            switch (property.ToLower())
            {
                case "length":
                    return this.Value.Length.ToString();
                default:
                    throw new Exception("Invalid property '" + property + "' for array data type.");
            }
        }
        public virtual string Evaluate(string method, params object[] args)
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