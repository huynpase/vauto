using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
namespace Vibz.Macro.String
{
    [TypeInfo(Details = "Concats all the strings.",
        Version = "2.0")]
    public class Concat : IMacroFunction
    {
        public string Evaluate(object param)
        {
            string retValue = "";
            foreach (object obj in (object[])param)
                retValue = obj.ToString() + retValue;
            return retValue;
        }
    }
}
