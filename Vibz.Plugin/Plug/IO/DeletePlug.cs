using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Vibz.Plugin.Plug.IO
{
    internal class DeletePlug : IOPlugBase
    {
        public DeletePlug(string path, PlugType type)
            : base(path, type)
        { }
        public DeletePlug(string path, string type):base(path, type)
        { }
        public override bool ExecutionNeeded
        {
            get
            {
                switch (_type)
                {
                    case PlugType.File:
                        if (File.Exists(_filePath))
                            return true;
                        break;
                    case PlugType.Folder:
                        if (Directory.Exists(_filePath))
                            return true;
                        break;
                }
                return false;
            }
        }
        public override bool Execute()
        {
            if (!ExecutionNeeded || !CanExecute)
                return false;
            switch (_type)
            {
                case PlugType.File:
                    File.Delete(_filePath);
                    break;
                case PlugType.Folder:
                    Directory.Delete(_filePath, true);
                    break;
            }
            return true;
        }
    }
}
