using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;

namespace demo_ext_macro
{
    [TypeInfo(Details = "Returns the current logged in user name.",
        Version = "2.0")]
    public class UserName : IMacroVariable
    {
        public string Value
        {
            get
            {
                return Environment.UserName;
            }
        }
    }
}
