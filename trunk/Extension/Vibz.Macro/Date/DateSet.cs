/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;
using Vibz.Helper;
namespace Vibz.Macro.String
{
    [TypeInfo(Author="Vibzworld", Details = "Formats the date to given format.",
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
