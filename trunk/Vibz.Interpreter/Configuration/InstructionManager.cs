using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Vibz.Contract;

namespace Vibz.Interpreter.Configuration
{
    public class InstructionManager
    {
        public const string NodeName = "instruction";
        static FileParser _fParser;
        static Vibz.Interpreter.Plugin.PluginAssembly _instList;
        public static Vibz.Interpreter.Plugin.PluginAssembly Handlers
        {
            get
            {
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
            AddType(typeof(Vibz.Interpreter.Script.FlowController.Condition), typeof(IAssert));
            AddType(typeof(Vibz.Interpreter.Script.FlowController.Case), typeof(IAction));
            AddType(typeof(Vibz.Interpreter.Script.FlowController.Body), typeof(IAction));
            AddType(typeof(Vibz.Interpreter.Script.FlowController.If), typeof(IAction));
            AddType(typeof(Vibz.Interpreter.Script.FlowController.Else), typeof(IAction));

            AddType(typeof(Vibz.Interpreter.Script.FlowController.LoopControl.DoWhile), typeof(IAction));
            AddType(typeof(Vibz.Interpreter.Script.FlowController.LoopControl.While), typeof(IAction));
            AddType(typeof(Vibz.Interpreter.Script.FlowController.LoopControl.For), typeof(IAction));

            AddType(typeof(Vibz.Interpreter.Script.FlowController.VariableControl.Define), typeof(IAction));
            AddType(typeof(Vibz.Interpreter.Script.FlowController.VariableControl.Set), typeof(IAction));
            AddType(typeof(Vibz.Interpreter.Script.FlowController.VariableControl.Invoke), typeof(IFetch));

        }
        static void AddType(Type type, Type iFace)
        {
            if (!Handlers.ContainsKey(type.FullName.ToLower()))
                Handlers.Add(type.FullName.ToLower(), new FunctionType(type, iFace));
        }
    }
}
