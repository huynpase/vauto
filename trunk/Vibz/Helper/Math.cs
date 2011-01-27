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
    public class Math
    {
        public static bool IsNumber(object obj)
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
        public static int TryGetInteger(object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception exc)
            {
                throw new Exception("Encountered '" + obj.ToString() + "' when expecting an integer value.");
            }
        }
        public static int TryGetInteger(object obj, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception exc)
            {
                return defaultValue;
            }
        }
    }
}
