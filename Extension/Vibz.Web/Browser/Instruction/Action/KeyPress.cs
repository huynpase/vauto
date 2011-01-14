using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 
using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Performs key press event on the control associated to given locator.",
        Version = WebInstructionBase.Vesrion)]
    public class KeyPress : ActionBase
    {
        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
        public string Locator;
        [XmlAttribute("char")]
        public string Char;
        public KeyPress()
            : base()
        {
                    
        }
        public KeyPress(string locator, string chr)
            : base()
        {
            Locator = locator;
            Char = chr;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.KeyPress(Locator, Convert.ToChar(vList.Evaluate(Char)));
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Key '" + Char + "' pressed on '" + Locator + "'.");
            }
        }
    }
}
