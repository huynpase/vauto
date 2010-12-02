using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Data.Source;

namespace Vibz.Data.External
{
    public class SourceFactory
    {
        public static ISource GetSourceInstance(SourceType type, Dictionary<string, string> paramList)
        {
            return GetSourceInstance(type.ToString().ToLower(), paramList);
        }
        public static ISource GetSourceInstance(string type, Dictionary<string, string> paramList)
        {
            switch (type.ToLower())
            { 
                case "text":
                    if (!paramList.ContainsKey("path"))
                        throw new Exception("Parameter 'path' is not provided.");
                    return new Text.ScalarText(paramList["path"]);
                case "database":
                    throw new Exception("Not implemented.");
                case "excel":
                    throw new Exception("Not implemented.");
                case "xml":
                    throw new Exception("Not implemented.");
                default:
                    throw new Exception("Unknown source type '" + type + "'.");
            }
        }
    }
}
