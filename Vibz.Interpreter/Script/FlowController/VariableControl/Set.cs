using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Contract.Data;
using Vibz.Contract.Attribute;
namespace Vibz.Interpreter.Script.FlowController.VariableControl
{
    [TypeInfo(Details = "Stores the data into given variable.",
        Version = "2.0")]
    public class Set : InstructionBase, IAction
    {
        [XmlAttribute("var")]
        public string Variable;
        [XmlAttribute("value")]
        public string Value;
        public Set()
        {
            Type = InstructionType.Action;
        }
        public Set(string value, string var)
            : base()
        {
            Value = value;
            Variable = var;
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Vibz.Contract.Data.IData obj = new Vibz.Contract.Data.Text(vList.Evaluate(Value));
            vList.DataList.Update(new Variable(Variable, obj));
            Vibz.Contract.Log.LogQueue.Instance.Enqueue(new Vibz.Contract.Log.LogQueueElement("Value " + obj.ToString() + " assigned to " + Variable, Vibz.Contract.Log.LogSeverity.Trace));
        }
    }
}
