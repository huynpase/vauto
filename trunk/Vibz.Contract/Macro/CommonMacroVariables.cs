using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Macro
{
    public class CommonMacroVariables : Dictionary<string, string>
    {
        static CommonMacroVariables _instance;
        CommonMacroVariables()
        { }
        public static void Set(string macro, string value)
        {
            if (_instance == null)
                _instance = new CommonMacroVariables();
            if (_instance.ContainsKey(macro))
                _instance[macro] = value;
            else
                _instance.Add(macro, value);
        }
        public static bool Contains(string macro)
        {
            if (_instance == null)
                _instance = new CommonMacroVariables();
            if (_instance.ContainsKey(macro))
                return true;
            else
                return false;
        }
        public static string Get(string macro)
        {
            if (_instance == null)
                _instance = new CommonMacroVariables();
            if (_instance.ContainsKey(macro))
                return _instance[macro];
            else
                throw new Exception(macro + " is undefined.");                
        }
    }
}
