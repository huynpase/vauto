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

namespace Vibz.Web.Browser
{
    public class Url
    {
        public string Text = "";
        public string Link = "";
        public Url(string text, string link)
        {
            Text = text;
            Link = link;
        }
        public static Uri AbsolutifyUrl(Uri baseUri, string url)
        {
            return new Uri(baseUri, url);
        }
    }
}
