using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Studio.Document.XDoc
{
    public class StringHelper
    {
        public static string GetLineIndentation(string lineText)
        {
            if (lineText == null || lineText == "")
                return "";
            return lineText.Replace(lineText.TrimStart(new char[] { ' ', '\r', '\t', '\n' }), "");
        }
    }
}
