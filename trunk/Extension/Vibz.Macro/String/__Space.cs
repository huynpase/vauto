using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
namespace Vibz.Macro.Date
{
    [TypeInfo(Details = "Adds a space.",
        Version = "2.0")]
    public class __Space : IMacroVariable
    {
        public string Value
        {
            get
            {
                return " ";
            }
        }
    }
}
