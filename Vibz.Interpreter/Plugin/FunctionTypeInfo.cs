using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract;

namespace Vibz.Interpreter.Plugin
{
    public class FunctionTypeInfo
    {
        public string TypeName;
        public string InterfaceName;
        public TypeInfo Information;
        public FunctionTypeInfo(Type type, Type iFace)
        {
            TypeName = type.Name;
            InterfaceName = iFace.Name;
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);
            foreach (System.Attribute attr in attrs)
            {
                if (attr is TypeInfo)
                {
                    TypeInfo ti = (TypeInfo)attr;
                    Information = new TypeInfo(ti.Author, ti.Details, ti.Version);
                    break;
                }
            }
        }
    }
}
