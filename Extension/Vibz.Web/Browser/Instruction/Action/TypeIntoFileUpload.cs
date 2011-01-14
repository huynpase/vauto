using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 
using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Types value into file upload control associated to given locator.",
        Version = WebInstructionBase.Vesrion)]
    public class TypeIntoFileUpload : ActionBase
    {
        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
        public string Locator;
        [XmlAttribute("value")]
        public string Value;
        public TypeIntoFileUpload()
            : base()
        {
                    
        }
        public TypeIntoFileUpload(string locator, string value)
            : base()
        {
            Locator = locator;
            Value = value;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.TypeIntoFileUpload(Locator, vList.Evaluate(Value));
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Typed '" + Value + "' into file upload control '" + Locator + "'.");
            }
        }
    }
}
