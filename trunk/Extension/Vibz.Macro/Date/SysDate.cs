using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;

namespace Vibz.Macro.Date
{
    [TypeInfo(Author="Vibzworld", Details = "Returns system date.",
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
