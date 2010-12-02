using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Interpreter.Plugin
{
    public class PluginSettings : Dictionary<string, object>
    {
        public string ConfigPath;
        public PluginSettings Clone
        { 
            get
            {
                PluginSettings pSet = new PluginSettings();
                pSet.ConfigPath = this.ConfigPath;
                foreach (string key in this.Keys)
                {
                    pSet.Add(key, this[key]);
                }
                return pSet;
            }
        }
    }
}
