using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Assert
{
    [TypeInfo(Author="Vibzworld", Details = "Checks if the control associated with given locator is checked or not.",
        Version = "2.0")]
    public class IsChecked : AssertBase
    {

        [XmlAttribute("locator")]
        public string Locator;
        public IsChecked()
            : base()
        {
                   
        }
        public IsChecked(string locator)
            : base()
        {
            Locator = locator;
            
        }
        public override bool Assert(Vibz.Contract.Data.DataHandler vList)
        {
            Result = Browser.Document.IsChecked(Locator);
            return Result;
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("CheckBox '" + Locator + "' is " + (Result ? "checked" : "not checked") + ".");
            }
        }
    }
}
