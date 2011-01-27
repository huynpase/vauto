/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
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
    public class TemplateProcessor : Processor
    {
        public TemplateProcessor(string zipLocation, Dictionary<string, string> templateParam) : base(zipLocation, templateParam) { }
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
