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
      Details = "Invokes the data method. ",
      Version = ScriptInfo.Version,
       HasIndeviduality = true)]
    public class Invoke : InstructionBase, IFetch
    {
        [XmlAttribute("method")]
        public string Method = "";
        private string _output = "assignto";
        [XmlAttribute("assignto")]
        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
        public Invoke()
        {
            Type = InstructionType.Fetch;
        }
        public Invoke(string method, string assignto)
            : base()
        {
            Method = method;
            Output = assignto;
            Type = InstructionType.Fetch;
        }
        public IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            return new Vibz.Contract.Data.Text(vList.Evaluate(Method));
        }
    }
}
