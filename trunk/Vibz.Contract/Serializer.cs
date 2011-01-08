using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Threading;
using System.IO;
namespace Vibz.Contract
{
    public class Serializer
    {
        public static IInstruction ConvertXmlElementToInstruction(Dictionary<string, FunctionType> mapList, XmlElement ele)
        {
            Type type = GetFunctionType(mapList, ele.Name.ToLower()).Type;
            XmlElement newEle = ele.OwnerDocument.CreateElement(type.Name);
            foreach(XmlAttribute attr in ele.Attributes)
            {
                newEle.Attributes.Append((XmlAttribute)attr.Clone());
            }
            newEle.InnerXml = ele.InnerXml;
            return DeSerialize(newEle, type);
        }
        public static FunctionType GetFunctionType(Dictionary<string, FunctionType> mapList, string elementName)
        {
            FunctionType type = null;
            if (mapList.ContainsKey(elementName))
                type = mapList[elementName];
            else
            {
                foreach (string funckey in mapList.Keys)
                {
                    string keyName = funckey.Substring(funckey.LastIndexOf('.') + 1);
                    if (keyName == elementName.ToLower())
                    {
                        type = mapList[funckey];
                        break;
                    }
                }
            }
            if (type == null)
                throw new Exception("Instruction '" + elementName + "' is undefined. Are you missing some assembly reference.");

            return type;
        }
        public static IInstruction DeSerialize(XmlElement xInstruction, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            TextReader tReader = new StringReader(xInstruction.OuterXml);
            
            return (IInstruction)serializer.Deserialize(tReader);
        }
    }
}
