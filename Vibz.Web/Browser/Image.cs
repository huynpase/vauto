using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Vibz.Web.Browser
{
    public class Image
    {
        public string FileName = "";
        public string Link = "";
        public System.Drawing.Image ImageObject;
        public Image(string name, string link, System.Drawing.Image img)
        {
            FileName = name;
            Link = link;
            ImageObject = img;
        }
    }
}
