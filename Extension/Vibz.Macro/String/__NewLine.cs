using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
namespace Vibz.Macro.Date
{
    [TypeInfo(Details = "Adds a new line character.",
        Version = "2.0")]
    public class __NewLine : IMacroVariable
    {
        public string Value
        {
            get
            {
                return "\r\n";
            }
        }
    }
}
