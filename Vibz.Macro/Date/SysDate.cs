using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;

namespace Vibz.Macro.Date
{
    [TypeInfo(Details = "Returns system date.",
        Version = "2.0")]
    public class SysDate : IMacroVariable
    {
        public string Value
        {
            get
            {
                return DateTime.Now.ToString();
            }
        }
    }
}
