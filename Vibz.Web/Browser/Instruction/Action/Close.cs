using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
 using Vibz.Contract;

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Details = "Closes the focussed window.",
        Version = "2.0")]
    public class Close : ActionBase
    {
        public Close()
            : base()
        {
                    
        }
        public override void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Browser.Document.Close();
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Active window closed.");
            }
        }
    }
}
