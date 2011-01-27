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
    public class Time
    {
        public static string ConvertToReadableTime(double milliseconds)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(milliseconds);
            if (ts.ToString().LastIndexOf('.') > 0)
                return ts.ToString().Substring(0, ts.ToString().LastIndexOf('.'));
            else
                return ts.ToString();
        }
        public static string TimeStamp
        {
            get {
                return Vibz.Helper.IO.FilterFolderChar(DateTime.Now.ToString());
            }
        }
    }
}
