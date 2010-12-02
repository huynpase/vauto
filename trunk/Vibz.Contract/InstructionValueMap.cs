using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract
{
    public class InstructionValueMap : Dictionary<string, string>
    {
        static InstructionValueMap _instance = null;
        static object _padlock = new object();
        InstructionValueMap()
        { }
        public static InstructionValueMap Instance
        {
            get {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new InstructionValueMap();
                        }    
                    }
                }
                return _instance;
            }
        }
    }
}
