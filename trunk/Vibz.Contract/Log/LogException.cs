using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Log
{
    public enum LogDirection { TopDown, BottomUp}
    public class LogException
    {
        public static string GetFullException(Exception exc)
        {
            return GetFullException(exc, LogDirection.TopDown);
        }
        public static string GetFullException(Exception exc, LogDirection dir)
        {
            switch (dir)
            { 
                case LogDirection.BottomUp:
                    return ((exc.InnerException != null) ? GetFullException(exc.InnerException, dir) + "\r\n\t" : "") + exc.Message;
                default:
                case LogDirection.TopDown:
                    return exc.Message + ((exc.InnerException != null) ? "\r\n\t" + GetFullException(exc.InnerException, dir) : "");
            }
        }
    }
}
