using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    public abstract class FetchBase : WebInstructionBase, IFetch
    {
        public FetchBase()
        {
            Type = InstructionType.Fetch;
        }
        private string _output = "assignto";
        [XmlAttribute("assignto")]
        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
        public virtual IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            throw new Exception("Fetch is not a valid function for this command.");
        }
        
    }
}
