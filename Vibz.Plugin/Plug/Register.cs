using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Vibz.Plugin.Plug
{
    internal class Register : PlugBase
    {
        string _name;
        string _nodePath;
        string _assemblyPath;
        string _configPath;
        string _pluginType;
        protected PlugType _type;
        public override PlugType Type { get { return PlugType.Register; } }
        public override NegateSeverity Severity { get { return NegateSeverity.Fatal; } }
        public Register(string regPath, string nodePath, string name, string assemblyPath, string configPath, string type)
            : base(regPath)
        {
            _nodePath = nodePath;
            _name = name;
            _assemblyPath = assemblyPath;
            _configPath = configPath;
            _pluginType = type;
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
                if (IsPlugUsedbyAnotherProcess)
                    return false;
                return true;
            } 
        }
        bool IsPlugUsedbyAnotherProcess
        {
            get
            {
                bool isBeingUsed = false;
                FileStream fs = null;
                try
                {
                    if (!File.Exists(_filePath))
                        isBeingUsed = false;
                    fs = File.Open(_filePath, FileMode.Open, FileAccess.Read, FileShare.None);
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
        }

        public override bool Execute()
        {
            if (!ExecutionNeeded || !CanExecute)
                return false;
            XML.InsertOrReplaceElementPlug ins = new Vibz.Plugin.Plug.XML.InsertOrReplaceElementPlug(_filePath,
                _nodePath + "/include[@name='" + _name + "']", "<include name=\"" + _name + "\" path=\"" + PlugManager.GetConfig().RootFolder + "\\" + _pluginType + "\\" + _assemblyPath + "\"  config=\"" + PlugManager.GetConfig().RootFolder + "\\" + _pluginType + "\\" + _configPath + "\" />");

            if (!ins.Execute())
            {
                Message = ins.Message;
                return false;
            }
            return true;
        }
    }
}
