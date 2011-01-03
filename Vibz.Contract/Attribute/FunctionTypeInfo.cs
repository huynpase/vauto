using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Vibz.Contract;

namespace Vibz.Contract.Attribute
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
                string name = "";
                string detail = "";
                string[] options = null;
                bool isRequired = true;

                object[] attribs = mInfo.GetCustomAttributes(typeof(XmlAttributeAttribute), true);
                if (attribs.Length > 0)
                {
                    name = ((XmlAttributeAttribute)attribs[0]).AttributeName;

                    attribs = mInfo.GetCustomAttributes(typeof(AttributeInfo), true);
                    if (attribs.Length > 0)
                    {
                        detail = ((AttributeInfo)attribs[0]).Details;
                        options = ((AttributeInfo)attribs[0]).Options;
                        isRequired = ((AttributeInfo)attribs[0]).IsRequired;
                    }
                    Attributes.Add(new FunctionAttribute(name, detail, options, isRequired));
                }
            }
        }
    }
}
