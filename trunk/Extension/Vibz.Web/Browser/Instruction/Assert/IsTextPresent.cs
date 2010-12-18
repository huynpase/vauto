using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Assert
{
    [TypeInfo(Author="Vibzworld", Details = "Checks if the given text is present or not.",
        Version = "2.0")]
    public class IsTextPresent : AssertBase
    {

        [XmlAttribute("text")]
        public string Text;
        public IsTextPresent()
            : base()
        {

        }
        public IsTextPresent(string text)
            : base()
        {
            Text = text;
            
        }
        public override bool Assert(Vibz.Contract.Data.DataHandler vList)
        {
            return Browser.Document.IsTextPresent(vList.Evaluate(Text));
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Text '" + Text + "' is " + (Result ? "present" : "not present") + ".");
            }
        }
    }
}
