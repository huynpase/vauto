using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;
using Vibz.Helper;
namespace Vibz.Macro.String
{
    [TypeInfo(Author="Vibzworld", Details = "Returns result obtained by substracting number 2 from number 1.",
        Version = "2.0")]
    public class Substract : IMacroFunction
    {
        public string Evaluate(object paramObj)
        {
            object[] param = (object[])paramObj;
            double retValue = 0;
            if (param.Length != 2)
                throw new Exception("Invalid parameter count for macro function 'Substract'.");
            double num1 = 0;
            if (Vibz.Helper.Math.IsNumber(param[0]))
                num1 = Convert.ToDouble(param[0]);
            else
                throw new Exception("Invalid argument '" + param[0] + "' for macro function 'Substract'.");
            double num2 = 0;
            if (Vibz.Helper.Math.IsNumber(param[1]))
                num2 = Convert.ToDouble(param[1]);
            else
                throw new Exception("Invalid argument '" + param[1] + "' for macro function 'Substract'.");
            retValue = num2 - num1;
            return retValue.ToString();
        }
    }
}
