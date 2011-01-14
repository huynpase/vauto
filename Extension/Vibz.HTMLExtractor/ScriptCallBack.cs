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
