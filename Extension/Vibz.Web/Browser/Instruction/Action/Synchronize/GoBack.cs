using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Navigates the browser to last navigated url.",
        Version = WebInstructionBase.Vesrion)]
    public class GoBack : SynchronizeBase
    {
        public GoBack()
            : base()
        {
                    
        }
        public GoBack(int maxWait)
            : base()
        {
            MaxWait = maxWait;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.GoBack(MaxWait);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Navigated browser to previous page.");
            }
        }
    }
}
