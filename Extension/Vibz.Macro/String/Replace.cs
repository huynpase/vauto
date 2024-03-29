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
using Vibz.Contract;
using Vibz.Contract.Attribute;
using Vibz.Helper;
namespace Vibz.Macro.String
{
    [TypeInfo(Author="Vibzworld", Details = "Replaces string within the given string with a new string.",
        Version = "2.0")]
    public class Replace : IMacroFunction
    {
        public string Evaluate(object paramObj)
        {
            string strFullText = "";
            object[] param = (object[])paramObj;
            if (param.Length != 3)
                throw new Exception("Invalid parameter count for macro function 'Replace'.");
            string strRepWith = param[0].ToString();
            string strRepText = param[1].ToString();
            strFullText = param[2].ToString();
            return strFullText.Replace(strRepText, strRepWith);
        }
    }
}
