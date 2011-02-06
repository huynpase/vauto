using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract.Attribute
{
    public class CoreInfo : List<FunctionTypeInfo>
    {
        public CoreInfo()
        {
            this.Add(new FunctionTypeInfo(typeof(Vibz.Contract.Data.Var), typeof(IAction), null));
        
        }
    }
}
