using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 
using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author="Vibzworld", Details = "Focuses the control associated to given locator.",
        Version = "2.0")]
    public class Focus : ActionBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        public Focus()
            : base()
        {
                    
        }
        public Focus(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.Focus(Locator);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Focussed on '" + Locator + "'.");
            }
        }
    }
}
