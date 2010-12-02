using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Details = "Selects option in drop down control associated to given locator.",
        Version = "2.0")]
    public class SelectOption : ActionBase
    {
        [XmlAttribute("locator")]
        public string Locator;
        [XmlAttribute("optiontext")]
        public string OptionText;
        public SelectOption()
            : base()
        {
                    
        }
        public SelectOption(string locator, string optionText)
            : base()
        {
            Locator = locator;
            OptionText = optionText;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.SelectOption(Locator, vList.Evaluate(OptionText));
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Selected '" + OptionText + "' in dropdown '" + Locator + "'.");
            }
        }
    }
}
