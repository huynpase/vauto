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
