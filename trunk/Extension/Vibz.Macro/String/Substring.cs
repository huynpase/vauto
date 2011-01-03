using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;
using Vibz.Contract.Attribute;
using Vibz.Helper;
namespace Vibz.Macro.String
{
    [TypeInfo(Author="Vibzworld", Details = "Returns part of the string.",
        Version = "2.0")]
    public class Substring : IMacroFunction
    {
        public string Evaluate(object paramObj)
        {
            object[] param = (object[])paramObj;
            int startIndex = 0;
            int length = -1;
            string strFullText = "";
            switch (param.Length)
            {
                case 2:
                    strFullText = param[1].ToString();
                    startIndex = Vibz.Helper.Math.IsNumber(param[0]) ? Convert.ToInt32(param[0]) : 0;
                    break;
                case 3:
                    strFullText = param[2].ToString();
                    startIndex = Vibz.Helper.Math.IsNumber(param[1]) ? Convert.ToInt32(param[1]) : 0;
                    length = Vibz.Helper.Math.IsNumber(param[0]) ? Convert.ToInt32(param[0]) : -1;
                    break;
            }
            if (length != -1)
                return strFullText.Substring(startIndex, length);
            else
                return strFullText.Substring(startIndex);
        }
    }
}
