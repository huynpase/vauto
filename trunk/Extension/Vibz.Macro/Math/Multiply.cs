using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;
using Vibz.Helper;
namespace Vibz.Macro.String
{
    [TypeInfo(Author="Vibzworld", Details = "Returns result obtained by multiplying all the given numbers.",
        Version = "2.0")]
    public class Multiply : IMacroFunction
    {
        public string Evaluate(object param)
        {
            double retValue = 1;
            if (((object[])param).Length < 2)
                throw new Exception("Invalid parameter count for macro function 'Multiply'.");
            foreach (object obj in (object[])param)
            {
                if (Vibz.Helper.Math.IsNumber(obj))
                    retValue = retValue * Convert.ToDouble(obj);
                else
                    throw new Exception("Encountered '" + obj.ToString() + "' when expecting a number.");
            }
            return retValue.ToString();
        }
    }
}
