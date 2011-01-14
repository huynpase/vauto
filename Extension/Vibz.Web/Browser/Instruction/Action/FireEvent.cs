using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 
using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Fires javascript even on the given locator.",
        Version = WebInstructionBase.Vesrion)]
    public class FireEvent : ActionBase
    {
        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
        public string Locator;
        [XmlAttribute("eventname")]
        public string EventName;
        public FireEvent()
            : base()
        {
                    
        }
        public FireEvent(string locator, string eventName)
            : base()
        {
            Locator = locator;
            EventName = eventName;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.FireEvent(Locator, vList.Evaluate(EventName));
        }
    }
}
