using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Details="Performs click event on the given locator.", 
        Version="2.0")]
    public class Click : ActionBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        public Click()
            : base()
        {
                    
        }
        public Click(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.Click(Locator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Clicked on '" + Locator + "'.");
            }
        }
    }
}
