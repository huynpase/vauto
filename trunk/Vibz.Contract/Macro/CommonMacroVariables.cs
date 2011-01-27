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

namespace Vibz.Contract.Macro
{
    public class CommonMacroVariables : Dictionary<string, string>
    {
        static CommonMacroVariables _instance;
        CommonMacroVariables()
        { }
        public static void Set(string macro, string value)
        {
            if (_instance == null)
                _instance = new CommonMacroVariables();
            if (_instance.ContainsKey(macro))
                _instance[macro] = value;
            else
                _instance.Add(macro, value);
        }
        public static bool Contains(string macro)
        {
            if (_instance == null)
                _instance = new CommonMacroVariables();
            if (_instance.ContainsKey(macro))
                return true;
            else
                return false;
        }
        public static string Get(string macro)
        {
            if (_instance == null)
                _instance = new CommonMacroVariables();
            if (_instance.ContainsKey(macro))
                return _instance[macro];
            else
                throw new Exception(macro + " is undefined.");                
        }
    }
}
