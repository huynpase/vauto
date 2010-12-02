using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action.Synchronize
{
    [TypeInfo(Details = "Refreshes the focussed browser.",
        Version = "2.0")]
    public class Refresh : SynchronizeBase
    {
        public Refresh()
            : base()
        {
                    
        }
        public Refresh(int maxWait)
            : base()
        {
            MaxWait = maxWait;
            
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.Refresh(MaxWait);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Browser refreshed.");
            }
        }
    }
}