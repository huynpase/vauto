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

namespace demo_ext_macro
{
    [TypeInfo(Details = "Formats the date to given format.",
        Version = "2.0")]
    public class SQRT : IMacroFunction
    {
        public string Evaluate(object paramObj)
        {
            double number = 0;
            if (IsNumber(paramObj))
                number = Convert.ToDouble(paramObj);
            else
                throw new Exception("Invalid argument '" + paramObj + "' for macro function 'SQRT'. Integer expected.");

            return Math.Sqrt(number).ToString();
        }
        bool IsNumber(object obj)
        {
            try
            {
                Convert.ToInt32(obj);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
