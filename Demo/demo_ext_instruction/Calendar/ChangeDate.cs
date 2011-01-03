using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using System.Xml.Serialization; // Add this namespace
using Vibz.Contract; // Add this namespace
using Vibz.Contract.Attribute;

namespace demo_ext_instruction.Calendar
{
    // Add Type info attribute for user reference
    // Version can be maintained to distinguish macro releases
    // The class inherit Instruction base and implements IAction as ChangeDate 
    //   is going to do some action (i.e. No fetch no check).
    [TypeInfo(Author="Vibzworld", Details = "Changes the system date.",
        Version = "2.0")]
    public class ChangeDate : InstructionBase, IAction
    {
        const string minYear = "2000";
        const string minDate = "1";
        const string minMonth = "1";

        [XmlAttribute("date")]
        public string Date = minDate;
        [XmlAttribute("month")]
        public string Month = minMonth;
        [XmlAttribute("year")]
        public string Year = minYear;
        [XmlAttribute("datestring")]
        public string DateString = minDate + "/" + minMonth + "/" + minYear;
        public ChangeDate()
            : this(minDate, minMonth, minYear)
        { }
        public ChangeDate(string date, string month, string year)
        {
            Date = date;
            Month = month;
            Year = year;
            Type = InstructionType.Action;
        }
        public ChangeDate(string dateString)
        {
            DateString = dateString;
            Type = InstructionType.Action;
        }

        [DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
        public extern static void Win32GetSystemTime(ref SystemTime sysTime);

        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SystemTime sysTime);

        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            SystemTime updatedTime = new SystemTime();
            if (Year == minYear && Month == minMonth && Date == minDate)
            {
                if (DateString == minDate + "/" + minMonth + "/" + minYear)
                    throw new Exception("Invalid arguments for changedate.");
                DateTime dt = DateTime.MinValue;
                DateString = vList.Evaluate(DateString);
                if (!DateTime.TryParse(DateString, out dt) || dt == DateTime.MinValue)
                    throw new Exception("Invalid date format '" + DateString + "'");
                updatedTime.Year = (ushort)dt.Year;
                updatedTime.Month = (ushort)dt.Month;
                updatedTime.Day = (ushort)dt.Day;
            }
            else
            {
                updatedTime.Year = Convert.ToUInt16(Year);
                updatedTime.Month = Convert.ToUInt16(Month);
                updatedTime.Day = Convert.ToUInt16(Date);
            }
            SystemTime currTime = new SystemTime();
            Win32GetSystemTime(ref currTime);

            updatedTime.Hour = (ushort)currTime.Hour;
            updatedTime.Minute = (ushort)currTime.Minute;
            updatedTime.Second = (ushort)currTime.Second;

            Win32SetSystemTime(ref updatedTime);
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Changed the system date to '" + DateTime.Today.ToShortDateString() + "'.");
            }
        }
    }
    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Millisecond;
    }
}
