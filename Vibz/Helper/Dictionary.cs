using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Helper
{
    public class Dictionary
    {
        public static Dictionary<string, string> Map(Dictionary<string, string> source, Dictionary<string, string> destination)
        {
            if (source == null || source.Count == 0)
                return destination;

            foreach (string key in source.Keys)
            {
                if (destination.ContainsKey(key))
                    destination[key] = source[key];
            }
            return destination;
        }
    }
}
