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
using Vibz.Contract.Macro;
namespace Vibz.Contract.Data
{
    public class ParameterSet : List<Parameter>
    {
        static MacroParser _mParser = null;
        public ParameterSet()
        { }
        public ParameterSet(MacroParser mParser)
        {
            _mParser = mParser;
        }
        public static void SetParser(MacroParser mParser)
        {
            _mParser = mParser;
        }
        public new void Add(Parameter param)
        {
            base.Add(param);
        }
        public bool Contains(string paramKey)
        {
            foreach (Parameter param in this)
            {
                if (param.Name.ToLower() == paramKey.ToLower())
                    return true;
            }
            return false;
        }
        public Parameter GetParameter(string paramKey)
        {
            foreach (Parameter param in this)
            {
                if (param.Name.ToLower() == paramKey.ToLower())
                {
                    if (_mParser != null)
                        param.Value = _mParser.Parse(param.Value);
                    return param;
                }
            }
            return null;
        }
    }
}
