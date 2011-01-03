using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract.Attribute;


namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author="Vibzworld", Details = "Performs mouse hovering event on the control associated to given locator.",
        Version = "2.0")]
    public class MouseOver : ActionBase
    {
        [XmlAttribute("locator")][AttributeInfo(WebInstructionBase.LocatorInfo)]
        public string Locator;
        public MouseOver()
            : base()
        {
                    
        }
        public MouseOver(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.MouseOver(Locator);
        }
    }
}
