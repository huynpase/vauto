using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Helper
{
    public class Time
    {
        public static string ConvertToReadableTime(double milliseconds)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(milliseconds);
            if (ts.ToString().LastIndexOf('.') > 0)
                return ts.ToString().Substring(0, ts.ToString().LastIndexOf('.'));
            else
                return ts.ToString();
        }
        public static string TimeStamp
        {
            get {
                return Vibz.Helper.IO.FilterFolderChar(DateTime.Now.ToString());
            }
        }
    }
}
