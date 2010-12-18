using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;

namespace Vibz.Interpreter.Plugin
{
    public class FunctionTypeInfo
    {
        public string TypeName;
        public string InterfaceName;
        public string Type;
        public TypeInfo Information;
        public List<FunctionAttribute> Attributes = new List<FunctionAttribute>();
        public FunctionTypeInfo(Type type, Type iFace)
        {
            TypeName = type.Name;
            InterfaceName = iFace.Name;
            switch (InterfaceName.ToLower())
            {
                case "iaction":
                    Type = "Action";
                    break;
                case "iassert":
                    Type = "Assert";
                    break;
                case "ifetch":
                    Type = "Fetch";
                    break;
                case "imacrovariable":
                    Type = "Macro Variable";
                    break;
                case "imacrofunction":
                    Type = "Macro Function";
                    break;
            }
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
            System.Reflection.MemberInfo[] mInfos = type.GetMembers();
            foreach (System.Reflection.MemberInfo mInfo in mInfos)
            {
                object[] attribs = mInfo.GetCustomAttributes(typeof(XmlAttributeAttribute), true);
                foreach (object attrib in attribs)
                {
                    Attributes.Add(new FunctionAttribute(((XmlAttributeAttribute)attrib).AttributeName));
                }
            }
        }
    }
}
