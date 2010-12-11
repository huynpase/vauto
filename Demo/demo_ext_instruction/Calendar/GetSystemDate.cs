using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization; // Add this namespace
using Vibz.Contract; // Add this namespace

namespace demo_ext_instruction.Calendar
{
    // Add Type info attribute for user reference
    // Version can be maintained to distinguish macro releases
    // The class inherit Instruction base and implements IFetch as GetSystemDate 
    //   is going to fetch some data (i.e. No action no assert).
    [TypeInfo(Details = "Fetches the system date.",
        Version = "2.0")]
    public class GetSystemDate : InstructionBase, IFetch
    {
        DateTime _fetchedDate;
        public GetSystemDate()
        {
            Type = InstructionType.Fetch;
        }
        private string _output = "assignto";
        [XmlAttribute("assignto")]
        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
        public Vibz.Contract.Data.IData Fetch(Vibz.Contract.Data.DataHandler vList)
        {
            _fetchedDate = DateTime.Now;
            return new Vibz.Contract.Data.Text(_fetchedDate.ToShortDateString());
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Fetched system date: '" + _fetchedDate.ToShortDateString() + "'.");
            }
        }
    }
}
