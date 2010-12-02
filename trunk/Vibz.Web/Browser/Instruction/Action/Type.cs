using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;


namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Details = "Types the given text on the control associated to given locator.",
        Version = "2.0")]
    
    public class Type : ActionBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        [XmlAttribute("value")]
        public string Value;
        public Type()
            : base()
        {
                    
        }
        public Type(string locator, string value)
            : base()
        {
            Locator = locator;
            Value = value;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.Type(Locator, vList.Evaluate(Value));
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Typed '" + Value + "' on '" + Locator + "'.");
            }
        }
    }
}
