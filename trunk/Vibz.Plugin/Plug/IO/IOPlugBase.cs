using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Vibz.Plugin.Plug.IO
{
    internal abstract class IOPlugBase : PlugBase
    {
        protected PlugType _type;
        public override PlugType Type { get { return _type; } }
        public override NegateSeverity Severity { get { return NegateSeverity.NonFatal; } }
        public IOPlugBase(string path, PlugType type)
            : base(path)
        {
            switch (type)
            {
                case PlugType.File:
                case PlugType.Folder:
                    _type = type;
                    break;
                default:
                    throw new Exception(type.ToString() + " plug type not supported for this operation.");
            }
        }
        public IOPlugBase(string path, string type)
            : base(path)
        {
            switch (type.ToString())
            { 
                case "file":
                    _type = PlugType.File;
                    break;
                case "folder":
                    _type = PlugType.Folder;
                    break;
                default:
                    throw new Exception(type + " plug type not supported for this operation.");
            }
        }
        public override bool ExecutionNeeded
        {
            get
            {
                return true;
            }
        }
        public override bool CanExecute
        { 
            get {
                if (IsPlugUsedbyAnotherProcess(_filePath, _type))
                    return false;
                return true;
            } 
        }
        bool IsPlugUsedbyAnotherProcess(string path, PlugType type)
        {
            bool isBeingUsed = false;
            FileStream fs = null;
            try
            {
                switch (type)
                {
                    case PlugType.File:
                        if (!File.Exists(path))
                        {
                            isBeingUsed = false;
                            break;
                        }
                        fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None);
                        break;
                    case PlugType.Folder:
                        if (!Directory.Exists(path))
                        {
                            isBeingUsed = false;
                            break;
                        }
                        string[] files = Directory.GetFiles(path);
                        foreach (string fls in files)
                        {
                            if (IsPlugUsedbyAnotherProcess(fls, PlugType.File))
                            {
                                isBeingUsed = true;
                                break;
                            }
                        }
                        if (isBeingUsed)
                            break;
                        string[] dirs = Directory.GetDirectories(path);
                        foreach (string dir in dirs)
                        {
                            if (IsPlugUsedbyAnotherProcess(dir, PlugType.Folder))
                            {
                                isBeingUsed = true;
                                break;
                            }
                        }
                        break;
                }

            }
            catch (System.IO.IOException exp)
            {
                Message = exp.Message;
                isBeingUsed = true;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return isBeingUsed;
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // ToDo
                    // Clean resources if used 
                }
                _disposed = true;
            }
        }
    }
}
