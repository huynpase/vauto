using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Web.Browser.Collection
{
    public class URLList : List<Url>
    {
        public URLList() : base() { }
        public URLList(int capacity) : base(capacity) { }

        internal void Add(string text, string link)
        {
            this.Add(new Url(text, link));
        }
    }
}
