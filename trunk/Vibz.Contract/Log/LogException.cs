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

namespace Vibz.Contract.Log
{
    public enum LogDirection { TopDown, BottomUp}
    public class LogException
    {
        public static string GetFullException(Exception exc)
        {
            return GetFullException(exc, LogDirection.TopDown);
        }
        public static string GetFullException(Exception exc, LogDirection dir)
        {
            switch (dir)
            { 
                case LogDirection.BottomUp:
                    return ((exc.InnerException != null) ? GetFullException(exc.InnerException, dir) + "\r\n\t" : "") + exc.Message;
                default:
                case LogDirection.TopDown:
                    return exc.Message + ((exc.InnerException != null) ? "\r\n\t" + GetFullException(exc.InnerException, dir) : "");
            }
        }
    }
}
