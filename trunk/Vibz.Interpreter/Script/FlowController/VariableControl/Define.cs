using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Contract.Data;

namespace Vibz.Interpreter.Script.FlowController.VariableControl
{
    [TypeInfo(Details = "Initialize a variable of given type.",
        Version = "2.0")]
    public class Define : InstructionBase, IAction
    {
        [XmlAttribute("var")]
        public string Variable;
        [XmlAttribute("type")]
        public string DataType;
        public Define()
        {
            Type = InstructionType.Action;
        }
        public Define(string var, string type)
            : base()
        {
            DataType = type;
            Variable = var;
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Vibz.Contract.Data.IData obj = Vibz.Contract.Data.DataHandler.DefineData(DataType);
            vList.DataList.Update(new Variable(Variable, obj));
        }
    }
}
