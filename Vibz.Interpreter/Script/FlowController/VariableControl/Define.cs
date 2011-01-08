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
    [TypeInfo(Author = ScriptInfo.Author,
       Details = "Initialize a variable of given type.",
      Version = ScriptInfo.Version,
       HasIndeviduality = true)]
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
