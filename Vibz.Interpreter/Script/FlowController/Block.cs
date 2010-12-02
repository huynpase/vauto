using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Helper;
using Vibz.Interpreter.Script.Common;
using Vibz.Interpreter.Script.Variables;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
namespace Vibz.Interpreter.Script.FlowController
{
    public class Block : InstructionBase, IInstruction
    {
        const string FlowContinues = " Script will continue to flow as mentioned.";

        public Block()
        {
            Progress = ProgressLog.GetInstance();
        }

        [XmlAnyElement()]
        public XmlElement[] XInstructions;
        IList<IInstruction> _instructions;
        [XmlIgnore()]
        public IList<IInstruction> Instructions
        {
            get
            {
                if (_instructions == null)
                {
                    _instructions = new List<IInstruction>();
                    if (XInstructions != null)
                    {
                        foreach (XmlElement ele in XInstructions)
                        {
                            _instructions.Add((IInstruction)Operation.ConvertXmlElementToInstruction(ele));
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
        
        [XmlIgnore()]
        public ProgressLog Progress;
        
        public void Execute(VariableList vList)
        {
            foreach (InstructionBase inst in Instructions)
            {
                try
                {
                    string log = "";
                    // To be commented before release
                    Progress.Enqueue(new ProgressElement("[" + inst.Type.ToString() + "] " + inst.InfoBegin));
                    switch (inst.Type)
                    {
                        case InstructionType.Action:
                            ((IAction)inst).Execute(vList);
                            log = inst.InfoEnd;
                            break;
                        case InstructionType.Fetch:
                            object obj = ((IFetch)inst).Fetch(vList);
                            vList.Add(VariableBase.CreateVariable(((IFetch)inst).Output, obj));
                            log = inst.InfoEnd;
                            break;
                        case InstructionType.Assert:
                        case InstructionType.Condition:
                            bool asrt = ((IAssert)inst).Assert(vList);
                            log = (asrt ? ((IAssert)inst).InfoOnAssertPass : ((IAssert)inst).InfoOnAssertFail);
                            break;
                    }
                    Progress.Enqueue(new ProgressElement("[" + inst.Type.ToString() + "] " + log));
                }
                catch (Exception exc)
                {
                    string exceptionMessage = "Error occured while processing instruction '" + inst.GetType().Name + "'." + exc.Message;

                    if (inst.OnError == Script.Common.StepToFollow.Break.ToString().ToLower())
                        throw new Exception(exceptionMessage);
                    Progress.Enqueue(new ProgressElement(exceptionMessage + FlowContinues, ProgressElementType.Warn));
                }
            }
        }
    }
}
