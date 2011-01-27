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
using System.Xml;
using Vibz.Contract;
using Vibz.Contract.Macro;

namespace Vibz.Interpreter.Configuration
{
    public class MacroManager : IMacroManager
    {
        public const string NodeName = "macro";
        Vibz.Interpreter.Plugin.PluginAssembly _macroList;
        static object padlock = new object();
        static MacroManager _instance = null;
        MacroManager()
        { }
        public static MacroManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MacroManager();
                        }
                    }
                }
                return _instance;
            }
        }
        public Vibz.Interpreter.Plugin.PluginAssembly Handlers
        {
            get
            {
                if (_macroList == null)
                {
                    _macroList = new Vibz.Interpreter.Plugin.PluginAssembly("Macro Set");
                    Vibz.Contract.Log.LogElement progress = new Vibz.Contract.Log.LogElement("Loading Macros.");
                    XmlNodeList xnl = Plugin.PluginManager.Document.SelectNodes("//" + Register.NodeName + "/" + MacroManager.NodeName + "/" + Register.Include.NodeName);
                    foreach (XmlNode xn in xnl)
                    {
                        if (xn.Attributes == null)
                            continue;
                        string name = (xn.Attributes[Register.Include.Name] == null ? "" : xn.Attributes[Register.Include.Name].Value);
                        string path = (xn.Attributes[Register.Include.Path] == null ? "" : xn.Attributes[Register.Include.Path].Value);
                        if (path != "")
                        {
                            progress.Add("Loading macro types from " + path);
                            _macroList.Append(ConfigManager.LoadTypes(path, new Type[] { typeof(Vibz.Contract.IMacroFunction), typeof(Vibz.Contract.IMacroVariable) }));
                        }
                    }
                }
                return _macroList;
            }
            set { _macroList = value; }
        }

        public FunctionType GetFunction(string macro)
        {
            return GetFunction(macro, null);
        }
        public FunctionType GetFunction(string macro, Type type)
        {
            FunctionType ftype = null;
            if (Handlers.ContainsKey(macro.ToLower()))
            {
                ftype = Handlers[macro.ToLower()];
                if (type != null && ftype.Interface != type)
                    ftype = null;
            }
            else
            {
                foreach (string funckey in Handlers.Keys)
                {
                    string keyName = funckey.Substring(funckey.LastIndexOf('.') + 1);
                    if (keyName == macro.ToLower())
                    {
                        ftype = Handlers[funckey];
                        if (type != null && ftype.Interface != type)
                            continue;
                        break;
                    }
                }
            }
            return ftype;
        }
    }
}
