using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Web.Browser.Collection
{
    public class ImageList : List<Image>
    {
        public ImageList() : base() { }
        public ImageList(int capacity) : base(capacity) { }

        internal void Add(string name, string link, System.Drawing.Image img)
        {
            this.Add(new Image(name, link, img));
        }
    }
}
