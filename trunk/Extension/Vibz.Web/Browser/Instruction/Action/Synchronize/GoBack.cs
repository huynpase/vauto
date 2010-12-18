using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Author="Vibzworld", Details = "Navigates the browser to last navigated url.",
        Version = "2.0")]
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
