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
