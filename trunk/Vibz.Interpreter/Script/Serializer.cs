using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Threading;
using System.IO;
using Vibz.Contract;
namespace Vibz.Interpreter.Script
{
    public class Serializer
    {
        internal static IInstruction ConvertXmlElementToInstruction(XmlElement ele)
        {
            Type type = null;
            string elementName = ele.Name.ToLower();
            if (Configuration.InstructionManager.Handlers.ContainsKey(elementName))
                type = Configuration.InstructionManager.Handlers[elementName].Type;
            else
            {
                foreach (string funckey in Configuration.InstructionManager.Handlers.Keys)
                {
                    string keyName = funckey.Substring(funckey.LastIndexOf('.') + 1);
                    if (keyName == elementName.ToLower())
                    {
                        type = Configuration.InstructionManager.Handlers[funckey].Type;
                        break;
                    }
                }
            }
            if (type == null)
                throw new Exception("Instruction '" + elementName + "' is undefined. Are you missing some assembly reference.");

            XmlElement newEle = ele.OwnerDocument.CreateElement(type.Name);
            foreach(XmlAttribute attr in ele.Attributes)
            {
                newEle.Attributes.Append((XmlAttribute)attr.Clone());
            }
            newEle.InnerXml = ele.InnerXml;
            return DeSerialize(newEle, type);
        }
        public static IInstruction DeSerialize(XmlElement xInstruction, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            TextReader tReader = new StringReader(xInstruction.OuterXml);
            
            return (IInstruction)serializer.Deserialize(tReader);
        }
    }
}
