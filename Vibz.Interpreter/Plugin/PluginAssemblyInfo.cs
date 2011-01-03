using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;
namespace Vibz.Interpreter.Plugin
{

    public class PluginAssemblyInfo : Dictionary<string, FunctionTypeInfo>
    {
        public PluginSettings Settings = new PluginSettings();
        public string Name = "";
        public PluginAssemblyInfo(string name)
        {
            Name = name;
        }
        public PluginAssemblyInfo(string name, PluginSettings settings)
        {
            Name = name;
            Settings = settings;
        }
        public void Append(Dictionary<string, FunctionTypeInfo> list)
        {
            foreach (string key in list.Keys)
            {
                this.Add(key, list[key]);
            }
        }
    }
}
