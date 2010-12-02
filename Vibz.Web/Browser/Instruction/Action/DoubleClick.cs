using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Details = "Double clicks on the given locator.",
        Version = "2.0")]
    public class DoubleClick : ActionBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        public DoubleClick()
            : base()
        {
                    
        }
        public DoubleClick(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.DoubleClick(Locator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Double Clicked on '" + Locator + "'.");
            }
        }
    }
}
