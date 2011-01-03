using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;

namespace Vibz.Macro.String
{
    [TypeInfo(Author="Vibzworld", Details = "Returns result obtained by adding all the given numbers.",
        Version = "2.0")]
    public class Sum : IMacroFunction
    {
        public string Evaluate(object param)
        {
            double retValue = 0;
            if (((object[])param).Length < 2)
                throw new Exception("Invalid parameter count for macro function 'Sum'.");
            foreach (object obj in (object[])param)
            {
                if (Vibz.Helper.Math.IsNumber(obj))
                    retValue += Convert.ToDouble(obj);
                else
                    throw new Exception("Encountered '" + obj.ToString() + "' when expecting a number.");
            }
            return retValue.ToString();
        }
    }
}
