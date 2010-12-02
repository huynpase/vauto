using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;

namespace Vibz.Interpreter.Plugin
{
    
    public class PluginAssembly : Dictionary<string, FunctionType>
    {
        public PluginSettings Settings = new PluginSettings();
        public string Name = "";
        public PluginAssembly(string name)
        {
            Name = name;
        }
        public PluginAssembly(string name, PluginSettings settings)
        {
            Name = name;
            Settings = settings;
        }
        public void Append(Dictionary<string, FunctionType> list)
        {
            foreach (string key in list.Keys)
            {
                this.Add(key, list[key]);
            }
        }
    }
}
