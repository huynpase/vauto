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

namespace Vibz.Web.Browser.Collection
{
    public class StyleList : Dictionary<string, string>
    {
        public StyleList(string styleText)
        {
            string[] styles = styleText.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string style in styles)
            {
                string[] styleKV = style.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (styleKV.Length < 2)
                    continue;
                this.Add(styleKV[0].Trim().ToLower(), styleKV[1].Trim());
            }
        }
        public string Get(string key)
        {
            return (this.ContainsKey(key.ToLower()) ? this[key.ToLower()] : null);
        }
    }
}
