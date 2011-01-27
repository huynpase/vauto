/*
*	Copyright © 2011, The Vibzworld Team
*	All rights reserved.
*	http://code.google.com/p/vauto/
*	
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions
*	are met:
*	
*	- Redistributions of source code must retain the above copyright
*	notice, this list of conditions and the following disclaimer.
*	
*	- Neither the name of the Vibzworld Team, nor the names of its
*	contributors may be used to endorse or promote products
*	derived from this software without specific prior written
*	permission.
*/
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
        public Type FunctionType;
        public Type InterfaceType;
        Dictionary<string, FunctionType> _mapList;
        public string TypeName
        {
            get { return FunctionType.Name; }
        }
        public string InterfaceName
        {
            get { return InterfaceType.Name; }
        }
        public string Type
        {
            get {
                string type = "";
                switch (InterfaceName.ToLower())
                {
                    case "iaction":
                        type = "Action";
                        break;
                    case "iassert":
                        type = "Assert";
                        break;
                    case "ifetch":
                        type = "Fetch";
                        break;
                    case "imacrovariable":
                        type = "Macro Variable";
                        break;
                    case "imacrofunction":
                        type = "Macro Function";
                        break;
                }
                return type;
            }
        }
        public TypeInfo Information
        {
            get
            {
                TypeInfo retValue = new TypeInfo();
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(FunctionType);
                foreach (System.Attribute attr in attrs)
                {
                    if (attr is TypeInfo)
                    {
                        TypeInfo ti = (TypeInfo)attr;
                        retValue = new TypeInfo(ti.Author, ti.Details, ti.Version, ti.HasIndeviduality);
                        break;
                    }
                }
                return retValue;
            }
        }
        public bool IsContainer
        {
            get {
                System.Reflection.MemberInfo[] mInfos = FunctionType.GetMembers();
                foreach (System.Reflection.MemberInfo mInfo in mInfos)
                {
                    object[] attribs = mInfo.GetCustomAttributes(typeof(XmlAnyElementAttribute), true);
                    if (attribs.Length > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public List<FunctionAttribute> Attributes
        {
            get {
                List<FunctionAttribute> retValue = new List<FunctionAttribute>();
                
                System.Reflection.MemberInfo[] mInfos = FunctionType.GetMembers();
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

                        Type mType = typeof(string);
                        switch (mInfo.MemberType)
                        {
                            case System.Reflection.MemberTypes.Property:
                                mType = ((System.Reflection.PropertyInfo)mInfo).PropertyType;
                                break;
                            case System.Reflection.MemberTypes.Field:
                                mType = ((System.Reflection.FieldInfo)mInfo).FieldType;
                                break;
                        }
                        if (mType == null)
                            continue;
                        if (mType.IsEnum)
                        {
                            options = Enum.GetNames(mType);
                        }
                        else if (mType == typeof(Boolean))
                        {
                            options = new string[] { "true", "false" };
                        }
                        attribs = mInfo.GetCustomAttributes(typeof(AttributeInfo), true);
                        if (attribs.Length > 0)
                        {
                            detail = ((AttributeInfo)attribs[0]).Details;
                            if (((AttributeInfo)attribs[0]).Options != null && ((AttributeInfo)attribs[0]).Options.Length > 0)
                                options = ((AttributeInfo)attribs[0]).Options;
                            isRequired = ((AttributeInfo)attribs[0]).IsRequired;
                        }
                        retValue.Add(new FunctionAttribute(name, detail, options, isRequired));
                    }
                }
                return retValue;
            }
        }
        public List<FunctionTypeInfo> ChildNodes
        {
            get
            {
                List<FunctionTypeInfo> retValue = new List<FunctionTypeInfo>();

                System.Reflection.MemberInfo[] mInfos = FunctionType.GetMembers();
                foreach (System.Reflection.MemberInfo mInfo in mInfos)
                {
                    string name = "";
                    string detail = "";
                    bool isRequired = true;

                    object[] attribs = mInfo.GetCustomAttributes(typeof(XmlAnyElementAttribute), true);
                    if (attribs.Length > 0)
                    {
                        name = ((XmlAnyElementAttribute)attribs[0]).Name;
                        if (name == "")
                            continue;
                        attribs = mInfo.GetCustomAttributes(typeof(NodeInfo), true);
                        if (attribs.Length > 0)
                        {
                            detail = ((NodeInfo)attribs[0]).Details;
                            isRequired = ((NodeInfo)attribs[0]).IsRequired;
                        }
                        FunctionType ft = Serializer.GetFunctionType(_mapList, name);
                        retValue.Add(new FunctionTypeInfo(ft.Type, ft.Interface, _mapList));
                    }
                }
                return retValue;
            }
        }
        public FunctionTypeInfo(Type type, Type iFace, Dictionary<string, FunctionType> mapList)
        {
            FunctionType = type;
            InterfaceType = iFace;
            _mapList = mapList;
        }
    }
}
