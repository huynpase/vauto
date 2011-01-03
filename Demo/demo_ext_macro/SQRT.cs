using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;

namespace demo_ext_macro
{
    [TypeInfo(Details = "Formats the date to given format.",
        Version = "2.0")]
    public class SQRT : IMacroFunction
    {
        public string Evaluate(object paramObj)
        {
            double number = 0;
            if (IsNumber(paramObj))
                number = Convert.ToDouble(paramObj);
            else
                throw new Exception("Invalid argument '" + paramObj + "' for macro function 'SQRT'. Integer expected.");

            return Math.Sqrt(number).ToString();
        }
        bool IsNumber(object obj)
        {
            try
            {
                Convert.ToInt32(obj);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
