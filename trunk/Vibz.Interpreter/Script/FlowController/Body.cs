using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using Vibz.Contract;
using Vibz.Contract.Common;
using Vibz.Contract.Log;
using Vibz.Contract.Data;
using Vibz.Contract.Macro;
using Vibz.Contract.Attribute;
namespace Vibz.Interpreter.Script.FlowController
{
    [TypeInfo(Author = ScriptInfo.Author,
     Details = "Body is a container instruction that hold one or more instructions in it.",
      Version = ScriptInfo.Version,
       HasIndeviduality = false)]
    public class Body : InstructionBase
    {
        bool _resetInstruction = false;
        const string FlowContinues = " Script will continue to flow as mentioned.";
        [XmlIgnore()]
        Vibz.Contract.Log.LogElement _progress;

        public Body()
        {
        }

        [XmlAnyElement()]
        public XmlElement[] XInstructions;
        IList<IInstruction> _instructions;
        [XmlIgnore()]
        public IList<IInstruction> Instructions
        {
            get
            {
                if (_instructions == null || _resetInstruction)
                {
                    _resetInstruction = false;
                    Vibz.Contract.Log.LogElement progress = new Vibz.Contract.Log.LogElement("Loading Instructions.");
                    _instructions = new List<IInstruction>();
                    if (XInstructions != null)
                    {
                        foreach (XmlElement ele in XInstructions)
                        {
                            LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Loading Instructions : " + ele.Name, Vibz.Contract.Log.LogSeverity.Trace));
                            _instructions.Add((IInstruction)Serializer.ConvertXmlElementToInstruction(Configuration.InstructionManager.Handlers, ele));
                        }
                    }
                }
                return _instructions;
            }
            set
            {
                _instructions = value;
            }
        }

        public void Execute(DataHandler vList)
        {
            _progress = new Vibz.Contract.Log.LogElement("Body start.");
            _resetInstruction = true;
            foreach (InstructionBase inst in Instructions)
            {
                try
                {
                    MacroParser macro = new MacroParser(Configuration.MacroManager.Instance, vList);
                    macro.Parse(inst);
                    string additionalInfo = "";
                    switch (inst.Type)
                    {
                        case InstructionType.Action:
                            ((IAction)inst).Execute(vList);
                            break;
                        case InstructionType.Fetch:
                            Vibz.Contract.Data.IData obj = ((IFetch)inst).Fetch(vList);
                            if (((IFetch)inst).Output.Trim() != "")
                            {
                                vList.DataList.Update(new Variable(((IFetch)inst).Output, obj));
                                additionalInfo = obj.ToString();
                            }
                            break;
                        case InstructionType.Assert:
                        case InstructionType.Condition:
                            bool asrt = ((IAssert)inst).Assert(vList);
                            break;
                    }
                    _progress.Add(inst.InfoEnd + (additionalInfo == "" ? "" : "[Data: " + additionalInfo + "]"));
                }
                catch (Exception exc)
                {
                    string message = "Error occured while processing instruction '" + inst.GetType().Name + "'. " + Vibz.Contract.Log.LogException.GetFullException(exc);

                    if (inst.OnError == StepToFollow.Break.ToString().ToLower())
                        throw new Exception(message);
                    _progress.Add(message + FlowContinues, Vibz.Contract.Log.LogSeverity.Warn);
                }
            }
        }

        public override Vibz.Contract.Log.LogElement InfoEnd 
        { 
            get 
            {
                return _progress; 
            } 
        }
    }
}
