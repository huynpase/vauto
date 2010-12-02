using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Vibz.Plugin.Plug.IO
{
    internal class AppendPlug : IOPlugBase
    {
        string _content;
        public AppendPlug(string path, string content)
            : base(path, PlugType.File)
        {
            _content = content;
        }
        public override bool Execute()
        {
            if (!ExecutionNeeded || !CanExecute)
                return false;
            File.AppendAllText(_filePath, _content);
            return true;
        }
    }
}
