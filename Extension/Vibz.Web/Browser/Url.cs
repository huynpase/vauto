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
