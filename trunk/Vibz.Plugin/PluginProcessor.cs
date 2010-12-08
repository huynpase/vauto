using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using Vibz.Contract.Log;
using Vibz.Plugin.Plug;
using Vibz.Zip;
namespace Vibz.Plugin
{
    public class PluginProcessor : Processor
    {
        public PluginProcessor(string zipLocation) : base(zipLocation) { }
        public bool Execute()
        {
            if (Execute(ProcessType.Validate) && Execute(ProcessType.Execute))
            {
                Cleanup();
                LogQueue.Instance.Enqueue(new LogQueueElement("Plugin installed successfully.", LogSeverity.Trace));
            }
            else
            {
                LogQueue.Instance.Enqueue(new LogQueueElement("Plugin installation failed. ", LogSeverity.Error));
                return false;
            }
            return true;
        }
    }
}
