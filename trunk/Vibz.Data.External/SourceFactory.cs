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
