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
using Vibz.Contract.Data;
using Vibz.Contract.Common;
using System.IO;
namespace Vibz.Contract
{
    public abstract class InstructionBase : IError, IInstruction
    {
        public const string OnErrorInfo = "This setting determines how the execution should proceed when error occurs in the current statement.";
        InstructionType _type = InstructionType.Action;
        private string _onError;
        [XmlAttribute("onerror")][Attribute.AttributeInfo(InstructionBase.OnErrorInfo, typeof(StepToFollow), false)]
        public string OnError
        {
            get
            {
                if (_onError == null)
                    _onError = StepToFollow.Break.ToString();
                return _onError.ToLower();
            }
            set
            {
                if (value.ToLower() == StepToFollow.Break.ToString().ToLower()
                    || value.ToLower() == StepToFollow.Continue.ToString().ToLower())
                    _onError = value.ToLower();
                else
                    throw new Exception("Encountered invalid option '" + value + "' for ontimeout. Available options are 'continue or break'.");
            }
        }

        InstructionValueMap _valueMap = null;
        [XmlIgnore()]
        public InstructionValueMap ValueMap
        {
            get
            {
                if (_valueMap == null)
                    _valueMap = InstructionValueMap.Instance;
                return _valueMap;
            }
        }
        
        [XmlIgnore()]
        public InstructionType Type { get { return _type; } set { _type = value; } }
        public virtual Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement(this.GetType().Name + " end.");
            }
        }
        public XmlElement Serialize()
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(memoryStream, Encoding.UTF8);
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(writer, this);
            memoryStream = (MemoryStream)writer.BaseStream;
            string xmlString = UTF8ByteArrayToString(memoryStream.ToArray());
            writer.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            return doc.DocumentElement;
        }
        private static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }
    }
}
