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

namespace Vibz.Helper
{
    public class Dictionary
    {
        public static Dictionary<string, string> Map(Dictionary<string, string> source, Dictionary<string, string> destination)
        {
            if (source == null || source.Count == 0)
                return destination;

            foreach (string key in source.Keys)
            {
                if (destination.ContainsKey(key))
                    destination[key] = source[key];
            }
            return destination;
        }
    }
}
