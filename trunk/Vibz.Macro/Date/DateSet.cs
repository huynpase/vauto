using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Helper;
namespace Vibz.Macro.String
{
    [TypeInfo(Details = "Formats the date to given format.",
        Version = "2.0")]
    public class DateSet : IMacroFunction
    {
        public string Evaluate(object paramObj)
        {
            object[] param = (object[])paramObj;
            if (param.Length != 4)
                throw new Exception("Invalid parameter count for macro function 'DateSet'.");
            string date = param[3].ToString();
            DateTime dt = DateTime.Parse(date);
            int amt = 0;
            if (Vibz.Helper.Math.IsNumber(param[2]))
                amt = Convert.ToInt32(param[2]);
            else
                throw new Exception("Invalid argument '" + param[1] + "' for macro function 'DateSet'.");
            string datePart = param[1].ToString();
            string format = param[0].ToString();
            switch (datePart)
            {
                case "month":
                    return dt.AddMonths(amt).ToString(format);
                case "year":
                    return dt.AddYears(amt).ToString(format);
                case "hour":
                    return dt.AddHours(amt).ToString(format);
                case "minute":
                    return dt.AddMinutes(amt).ToString(format);
                case "second":
                    return dt.AddSeconds(amt).ToString(format);
                case "millisecond":
                    return dt.AddMilliseconds(amt).ToString(format);
                case "day":
                default:
                    return dt.AddDays(amt).ToString(format);

            }
        }
    }
}
