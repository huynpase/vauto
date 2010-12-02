using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Contract
{
    public class FunctionType
    {
        public Type Type;
        public Type Interface;
        public FunctionType(Type type, Type iFace)
        {
            Type = type;
            Interface = iFace;
        }
    }
}
