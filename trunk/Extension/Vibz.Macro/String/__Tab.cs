using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
namespace Vibz.Macro.Date
{
    [TypeInfo(Details = "Adds a tab character.",
        Version = "2.0")]
    public class __Tab : IMacroVariable
    {
        public string Value
        {
            get
            {
                return "\t";
            }
        }
    }
}
