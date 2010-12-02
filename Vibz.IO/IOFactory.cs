using System;
using System.Collections.Generic;
using System.Text;
using Vibz.IO.TextFile;

namespace Vibz.IO
{
    public class IOFactory
    {
        public static IOBase GetIOFile(string filename)
        {
            return new TextFile.TextFile(filename);
        }
    }
}
