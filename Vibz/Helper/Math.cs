using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Helper
{
    public class Math
    {
        public static bool IsNumber(object obj)
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
        public static int TryGetInteger(object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception exc)
            {
                throw new Exception("Encountered '" + obj.ToString() + "' when expecting an integer value.");
            }
        }
        public static int TryGetInteger(object obj, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception exc)
            {
                return defaultValue;
            }
        }
    }
}
