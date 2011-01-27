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
using System.Data;
using Vibz.Interpreter.Plugin;
using Vibz.Contract.Attribute;
namespace Vibz.Studio.Document.XDoc
{
    public enum ContextType { None, Instruction, AttributeName, AttributeValue }
    public enum ContextSubType { Action = 1, Assert, Fetch, Required, NonRequired }
    public class Context
    {
        public class InstructionNode
        {
            public const string Name = "name";
            public const string Description = "desc";
            public const string Type = "type";
            public const string Subtype = "subtype";
            public const string Owner = "owner";
        }
        public struct XAttribute
        {
            public string Name;
            public string Value;
            public XAttribute(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
        public XMode Mode = XMode.None;
        public ContextType Type = ContextType.None;
        public string Instruction = "";
        public string Attribute = "";
        public string Word = "";
        public List<XAttribute> LoadedAttribute = new List<XAttribute>();

        public int WordStartIndex = -1;
        void SetCurrentItem(XMode mode, string text, int wordPointer)
       {
            if (mode == XMode.NodeNameBegin)
                Instruction = text;
            Word = text;
            Mode = mode;
            WordStartIndex = wordPointer;
        }
        public void Load(string nodeText, int currentIndex)
        {
            Mode = XMode.None;
            if (nodeText.Length == 0)
                return;
            if (nodeText.Length == 1 && nodeText[0] == '<')
            {
                SetCurrentItem(XMode.NodeNameBegin, "", 0);
                return;
            }
            if (nodeText[0] != '<')
            {
                SetCurrentItem(XMode.InnerText, "", -1);
                return;
            }
            if (nodeText.Length > 0 && 0 == currentIndex)
            {
                if (nodeText[1] == '/')
                    Mode = XMode.NodeEndBranchOpen;
                else
                    Mode = XMode.NodeBeginOpen;
            }
            int index = 1;
            int wordPointer = 1;
            bool isFirst = true;
            string attribute="";
            XMode mode = XMode.NodeNameBegin;
            string curWord = "";
            while (true)
            {
                curWord = nodeText.Substring(wordPointer, index - wordPointer).Trim();
                if (index >= nodeText.Length)
                {
                    if (Mode == XMode.None)
                        SetCurrentItem(mode, "", wordPointer);
                    switch (mode)
                    {
                        case XMode.AttributeValueEnd:
                            Mode = XMode.AttributeSeperation;
                            break;
                        case XMode.NodeBeginOpen:
                            Mode = XMode.NodeNameBegin;
                            break;
                    }
                    break;
                }
                if (nodeText[index] == ' ')
                {
                    if (mode == XMode.AttributeName)
                    {
                        attribute = curWord;
                        index++;
                        continue;
                    }
                    if (mode == XMode.AttributeValue || mode == XMode.InnerText)
                    {
                        index++;
                        continue;
                    }
                    mode = XMode.AttributeSeperation;
                    if (isFirst)
                    {
                        Instruction = curWord;
                        wordPointer = index;
                        isFirst = false;
                    }
                    else if (attribute == "")
                    {
                        attribute = curWord;
                        wordPointer = index;
                    }
                }
                else if (nodeText[index] == '=')
                {
                    if (mode == XMode.AttributeValue || mode == XMode.InnerText)
                    {
                        index++;
                        continue;
                    }
                    attribute = curWord;
                    mode = XMode.AttributeEqual;
                    wordPointer = index;
                }
                else if (nodeText[index] == '"')
                {
                    if (mode == XMode.InnerText)
                    {
                        index++;
                        continue;
                    }
                    if (attribute != "" && curWord != "=")
                    {
                        LoadedAttribute.Add(new XAttribute(attribute, DeQuoteText(curWord)));
                        mode = XMode.AttributeValueEnd;
                        wordPointer = index;
                        Attribute = attribute;
                        attribute = "";
                    }
                    else
                        mode = XMode.AttributeValueStart;
                }
                else if (nodeText[index] == '/')
                {
                    if (mode == XMode.AttributeValue || mode == XMode.InnerText)
                    {
                        index++;
                        continue;
                    }
                    if (isFirst)
                        mode = XMode.NodeEndBranchSlash;
                    else
                        mode = XMode.NodeEndLeafSlash;
                    wordPointer = index;
                }
                else if (nodeText[index] == '>')
                {
                    if (mode == XMode.AttributeValue)
                    {
                        index++;
                        continue;
                    }
                    if (mode == XMode.NodeNameBegin || mode == XMode.AttributeSeperation || mode == XMode.AttributeValueEnd)
                        mode = XMode.NodeBeginClose;
                    else if (mode == XMode.NodeEndLeafSlash)
                        mode = XMode.NodeEndLeafClose;
                    else if (mode == XMode.NodeNameEnd)
                    {
                        Instruction = curWord;
                        mode = XMode.NodeEndBranchClose;
                        isFirst = false;
                    }
                }
                else if (EqualsAny(nodeText[index].ToString(), "\n", "\t", "\r"))
                {
                    switch (mode)
                    {
                        case  XMode.AttributeValueEnd:
                            mode = XMode.AttributeSeperation;
                            break;
                    }
                }
                if (index == currentIndex)
                    SetCurrentItem(mode, curWord, wordPointer);

                index++;
                switch (mode)
                { 
                    case XMode.NodeBeginOpen:
                        mode = XMode.NodeNameBegin;
                        break;
                    case XMode.AttributeValueStart:
                        mode = XMode.AttributeValue;
                        wordPointer = index;
                        break;
                    case XMode.AttributeSeperation:
                        mode = XMode.AttributeName;
                        break;
                    case XMode.NodeEndBranchSlash:
                        mode = XMode.NodeNameEnd;
                        break;
                }
            }
        }
        public bool EqualsAny(string text, params string[] values)
        {
            foreach (string value in values)
            {
                if (text == value)
                    return true;
            }
            return false;
        }
        public string DeQuoteText(string text)
        {
            if (text.StartsWith("\"") && text.EndsWith("\"")
                || text.StartsWith("'") && text.EndsWith("'"))
                return text.Trim(new char[] { '\'', '"' });
            else return text;
        }
        static DataTable _instructions = null;
        public static DataTable Instructions
        {
            get 
            {
                if (_instructions == null)
                {
                    _instructions = new DataTable();
                    _instructions.Columns.Add(new DataColumn(InstructionNode.Name));
                    _instructions.Columns.Add(new DataColumn(InstructionNode.Type));
                    _instructions.Columns.Add(new DataColumn(InstructionNode.Subtype));
                    _instructions.Columns.Add(new DataColumn(InstructionNode.Owner));
                    _instructions.Columns.Add(new DataColumn(InstructionNode.Description));
                    PluginAssemblyInfo[] list = PluginManager.GetPluginInfoList(PluginType.Instruction);
                    foreach (PluginAssemblyInfo pInfo in list)
                    {
                        foreach (string key in pInfo.Keys)
                        {
                            CreateDataRow(pInfo[key]);
                        }
                    }
                    foreach (FunctionTypeInfo fType in Vibz.Interpreter.Configuration.InstructionManager.InternalInstructions)
                    {
                        CreateDataRow(fType);
                    }
                }
                return _instructions;
            }
        }
        static void CreateDataRow(FunctionTypeInfo inst)
        {
            DataRow drInst = _instructions.NewRow();
            drInst[InstructionNode.Name] = inst.TypeName.ToLower();
            drInst[InstructionNode.Type] = (int)ContextType.Instruction;
            drInst[InstructionNode.Owner] = null;
            drInst[InstructionNode.Description] = inst.Information.Details;
            switch (inst.Type.ToLower())
            {
                case "assert":
                    drInst[InstructionNode.Subtype] = (int)ContextSubType.Assert;
                    break;
                case "fetch":
                    drInst[InstructionNode.Subtype] = (int)ContextSubType.Fetch;
                    break;
                default:
                case "action":
                    drInst[InstructionNode.Subtype] = (int)ContextSubType.Action;
                    break;
            }
            _instructions.Rows.Add(drInst);
            if (inst.Attributes == null || inst.Attributes.Count == 0)
                return;
            foreach (FunctionAttribute atr in inst.Attributes)
            {
                DataRow drAttrName = _instructions.NewRow();
                drAttrName[InstructionNode.Name] = atr.Name.ToLower();
                drAttrName[InstructionNode.Type] = (int)ContextType.AttributeName;
                drAttrName[InstructionNode.Owner] = inst.TypeName;
                drAttrName[InstructionNode.Description] = atr.Information.Details;
                drAttrName[InstructionNode.Subtype] = (atr.Information.IsRequired ? ContextSubType.Required : ContextSubType.NonRequired);
                _instructions.Rows.Add(drAttrName);
                if (atr.Information.Options == null || atr.Information.Options.Length == 0)
                    continue;
                foreach (string val in atr.Information.Options)
                {
                    DataRow drAttrVal = _instructions.NewRow();
                    drAttrVal[InstructionNode.Name] = val.ToLower();
                    drAttrVal[InstructionNode.Type] = (int)ContextType.AttributeValue;
                    drAttrVal[InstructionNode.Owner] = inst.TypeName + "|" + atr.Name;
                    drAttrVal[InstructionNode.Description] = "Supported value.";
                    drAttrVal[InstructionNode.Subtype] = null;
                    _instructions.Rows.Add(drAttrVal);
                }
            }
        }
        public bool ContainsAttribute(string name)
        {
            foreach (XAttribute attr in LoadedAttribute)
            {
                if (attr.Name.ToLower() == name.ToLower())
                    return true;
            }
            return false;
        }
    }
}
