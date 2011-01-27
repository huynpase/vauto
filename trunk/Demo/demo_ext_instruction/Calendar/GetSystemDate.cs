/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization; // Add this namespace
using Vibz.Contract; // Add this namespace
using Vibz.Contract.Attribute;

namespace demo_ext_instruction.Calendar
{
    // Add Type info attribute for user reference
    // Version can be maintained to distinguish macro releases
    // The class inherit Instruction base and implements IFetch as GetSystemDate 
    //   is going to fetch some data (i.e. No action no assert).
    [TypeInfo(Author="Vibzworld", Details = "Fetches the system date.",
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
        [AttributeInfo("Variable where the instruction output will be stored.")]
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
