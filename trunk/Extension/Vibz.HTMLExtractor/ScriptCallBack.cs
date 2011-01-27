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

namespace Vibz.HTMLExtractor
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class ScriptCallback
    {
        WBrowser owner;

        public ScriptCallback(WBrowser owner)
        {
            this.owner = owner;
        }

        // callback function to get the content
        // of page in the WebBrowser control
        public void getHtmlResult(int count)
        {
            // unequal means the content is not stable
            if (owner.NavigationCounter != count) return; 
        }
    }

}
