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
using Vibz.Contract.Attribute;

namespace Vibz.Interpreter.Configuration
{
    public class InstructionManager
    {
        public const string NodeName = "instruction";
        static FileParser _fParser;
        static Vibz.Interpreter.Plugin.PluginAssembly _instList;
        public static void Reset()
        {
            _instList = null;
        }
        public static Vibz.Interpreter.Plugin.PluginAssembly Handlers
        {
            get
            {
                if (_fParser == null)
                    return null;
                if (_instList == null)
                {
                    _instList = new Vibz.Interpreter.Plugin.PluginAssembly("Instruction Set");
                    Vibz.Contract.Log.LogElement progress = new Vibz.Contract.Log.LogElement("Initializing framework environment.");
                    XmlNodeList xnl = Plugin.PluginManager.Document.SelectNodes("//" + Register.NodeName + "/" + InstructionManager.NodeName + "/" + Register.Include.NodeName);
                    foreach (XmlNode xn in xnl)
                    {
                        if (xn.Attributes == null)
                            continue;
                        string name = (xn.Attributes[Register.Include.Name] == null ? "" : xn.Attributes[Register.Include.Name].Value);
                        if (_fParser.IncludedAssemblies != null && !_fParser.IncludedAssemblies.Contains(name.ToLower()))
                            continue;
                        string path = (xn.Attributes[Register.Include.Path] == null ? "" : xn.Attributes[Register.Include.Path].Value);
                        if (path != "")
                        {
                            progress.Add("Loading instruction types from " + path);
                            _instList.Append(ConfigManager.LoadTypes(path, new Type[] { typeof(Vibz.Contract.IAssert), typeof(Vibz.Contract.IAction), typeof(Vibz.Contract.IFetch) }));
                        }
                    }
                }
                return _instList;
            }
            set { _instList = value; }
        }
        internal static void LoadInternalClasses(FileParser fParser)
        {
            _fParser = fParser;
            foreach (FunctionTypeInfo fType in InternalInstructions)
            {
                AddType(fType.FunctionType, fType.InterfaceType);
            }
        }
        static List<FunctionTypeInfo> _internalInstructions = null;
        public static List<FunctionTypeInfo> InternalInstructions
        {
            get {
                if (_internalInstructions == null)
                {
                    //
                    // Sequence does matter. 
                    // Put the lowest leaf instruction prior to a branch / trunk instruction.
                    //
                    _internalInstructions = new Vibz.Contract.Attribute.CoreInfo();
                    
                    //_internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Contract.Data.Variable), typeof(IAction)));

                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.Body), typeof(IAction)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.Condition), typeof(IAssert)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.Else), typeof(IAction)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.Case), typeof(IAction)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.If), typeof(IAction)));

                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.LoopControl.DoWhile), typeof(IAction)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.LoopControl.While), typeof(IAction)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.LoopControl.For), typeof(IAction)));

                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.VariableControl.Define), typeof(IAction)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.VariableControl.Set), typeof(IAction)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.VariableControl.Invoke), typeof(IFetch)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.VariableControl.Evaluate), typeof(IFetch)));
                    _internalInstructions.Add(CreateFunctionInfo(typeof(Vibz.Interpreter.Script.FlowController.VariableControl.AssertBool), typeof(IAssert)));
                    _preLoadHandler = null;
                }
                return _internalInstructions;
            }
        }
        static Dictionary<string, FunctionType> _preLoadHandler = null;
        static FunctionTypeInfo CreateFunctionInfo(Type type, Type iFace)
        {
            if (_preLoadHandler == null)
                _preLoadHandler = new Dictionary<string, FunctionType>();
            
            _preLoadHandler.Add(type.FullName.ToLower(), new FunctionType(type, iFace));

            return new FunctionTypeInfo(type, iFace, _preLoadHandler);
        }
        static void AddType(Type type, Type iFace)
        {
            if (!Handlers.ContainsKey(type.FullName.ToLower()))
                Handlers.Add(type.FullName.ToLower(), new FunctionType(type, iFace));
        }
    }
}
