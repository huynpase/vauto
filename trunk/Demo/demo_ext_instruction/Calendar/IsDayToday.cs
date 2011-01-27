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
    // The class inherit Instruction base and implements IAssert as IsDayToday 
    //   is going to check some condition (i.e. No action no fetch).
    [TypeInfo(Author="Vibzworld", Details = "Changes the system date.",
        Version = "2.0")]
    public class IsDayToday : InstructionBase, IAssert
    {
        bool _assertValue = false;
        [XmlAttribute("day")]
        public string Day;
        public IsDayToday()
            : this(null)
        { }
        public IsDayToday(string day)
        {
            Day = day;
            Type = InstructionType.Assert;
        }
        public bool Assert(Vibz.Contract.Data.DataHandler vList)
        {
            DayOfWeek chkDay = DayOfWeek.Sunday;
            switch (Day.ToLower())
            {
                case "mon":
                case "monday":
                    chkDay = DayOfWeek.Monday;
                    break;
                case "tue":
                case "tuesday":
                    chkDay = DayOfWeek.Tuesday;
                    break;
                case "wed":
                case "wednesday":
                    chkDay = DayOfWeek.Wednesday;
                    break;
                case "thu":
                case "thursday":
                    chkDay = DayOfWeek.Thursday;
                    break;
                case "fri":
                case "friday":
                    chkDay = DayOfWeek.Friday;
                    break;
                case "sat":
                case "saturday":
                    chkDay = DayOfWeek.Saturday;
                    break;
                case "sun":
                case "sunday":
                    chkDay = DayOfWeek.Sunday;
                    break;
                default:
                    throw new Exception("'" + Day + "' is not a valid week day");
            }
            _assertValue = (DateTime.Today.DayOfWeek == chkDay);
            return _assertValue;
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Today being " + DateTime.Today.DayOfWeek.ToString().ToLower() + " the assertion 'IsDayToday' " + (_assertValue ? "passed" : "failed") + ".");
            }
        }
    }
}
