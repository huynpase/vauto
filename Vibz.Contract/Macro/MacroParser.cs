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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Vibz.Contract.Log;
using Vibz.Contract;
using Vibz.Contract.Data;
using System.Xml.Serialization;
namespace Vibz.Contract.Macro
{
    public class MacroParser
    {
        DataHandler _vList;
        IMacroManager _macroManager;
        public MacroParser(IMacroManager mgr, DataHandler handler)
        {
            _macroManager = mgr;
            _vList = handler;
        }
        Log.LogElement _progress = null;
        Log.LogElement Progress
        {
            get 
            { 
                if (_progress == null) 
                    _progress = new LogElement(""); 
                return _progress; 
            }
        }
        public Vibz.Contract.Log.LogElement Parse(InstructionBase inst)
        {
            MemberInfo[] mis = inst.GetType().FindMembers(MemberTypes.Field | MemberTypes.Property,
                BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, null, null);

            string par = "parse(";
            foreach (MemberInfo mi in mis)
            {
                if (mi.GetCustomAttributes(true).Length == 0)
                    continue;
                string value;
                switch (mi.MemberType)
                {
                    case MemberTypes.Property:
                        if (((PropertyInfo)mi).CanWrite)
                        {
                            object pValue = ((PropertyInfo)mi).GetValue(inst, null);
                            if (pValue == null)
                                break;
                            value = pValue.ToString();
                            if (value.StartsWith(par) && value.EndsWith(")"))
                            {
                                string parseText = value.Substring(par.Length, value.LastIndexOf(')') - par.Length);
                                ((PropertyInfo)mi).SetValue(inst, Evaluate(parseText), null);
                            }
                        }
                        break;
                    case MemberTypes.Field:
                        object fValue = ((FieldInfo)mi).GetValue(inst);
                        if (fValue == null)
                            break;
                            //throw new Exception("Expected " + mi.Name + " not found.");
                        value = fValue.ToString();
                        if (value.StartsWith(par) && value.EndsWith(")"))
                        {
                            string parseText = value.Substring(par.Length, value.LastIndexOf(')') - par.Length);
                            ((FieldInfo)mi).SetValue(inst, Evaluate(parseText));
                        }
                        break;
                }
            }
            return Progress;
        }
        public string Parse(string macroText)
        {
            string par = "parse(";
            if (macroText.StartsWith(par) && macroText.EndsWith(")"))
            {
                string parseText = macroText.Substring(par.Length, macroText.LastIndexOf(')') - par.Length);
                return Evaluate(parseText);
            }
            return _vList.Evaluate(macroText);
        }
        string Evaluate(string macroString)
        {
            
            try
            {
                Progress.Add("Evaluating macro '" + macroString + "'.");
                string cmd = macroString;
                int startIndex = 0;
                int currentIndex = 0;
                Stack<string> items = new Stack<string>();

                if (!macroString.Contains("("))
                    return Evaluate(macroString, null);
                while (currentIndex < cmd.Length)
                {
                    switch (cmd[currentIndex])
                    {
                        case '(':
                            string val = cmd.Substring(startIndex, currentIndex - startIndex).Trim();
                            if (val != "")
                            {
                                if (!IsAFunction(val))
                                    throw new Exception("Macro function '" + val + "' is not defined.");
                                items.Push(val);
                            }
                            startIndex = currentIndex + 1;
                            break;
                        case ',':
                            val = cmd.Substring(startIndex, currentIndex - startIndex).Trim();
                            if (val != "")
                                items.Push(Evaluate(val, null));
                            startIndex = currentIndex + 1;
                            break;
                        case '\\':
                            int nextIndex = currentIndex + 1;
                            switch (cmd[nextIndex])
                            {
                                case ',':
                                case ')':
                                case '(':
                                case '\\':
                                case ' ':
                                    cmd = cmd.Remove(currentIndex, 1);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case ')':
                            ArrayList param = new ArrayList();
                            val = cmd.Substring(startIndex, currentIndex - startIndex).Trim();
                            if (val != "")
                                items.Push(Evaluate(val, null));
                            while (true)
                            {
                                string item = _vList.Evaluate(items.Pop());
                                if (IsAFunction(item))
                                {
                                    object paramObj = new object[param.Count];
                                    if (param.Count == 1)
                                        paramObj = param[0].ToString();
                                    else
                                        param.CopyTo((object[])paramObj);
                                    items.Push(Evaluate(item, paramObj));
                                    break;
                                }
                                else
                                    param.Add(item);
                            }
                            startIndex = currentIndex + 1;
                            break;
                    }
                    currentIndex++;
                }
                string retValue = items.Pop();
                if (items.Count != 0)
                    throw new Exception("Invalid macro: " + macroString);
                Progress.Add("Macro evaluated to : " + retValue);
                return retValue;
            }
            catch (Exception exc)
            {
                throw new Exception("Macro evaluation failed : " + exc.Message);
            }
        }
        string Evaluate(string macro, object param)
        {
            if (macro.StartsWith("\"") && macro.EndsWith("\""))
                return macro.Substring(1, macro.Length - 2);
            FunctionType ftype = _macroManager.GetFunction(macro);
            if (ftype == null)
            {
                if (CommonMacroVariables.Contains(macro))
                    return CommonMacroVariables.Get(macro);
                else
                    return macro;
            }
            // throw new Exception("Macro element '" + macro + "' is undefined. Please verify your macro drivers.");
            object fObj = System.Activator.CreateInstance(ftype.Type);
            switch (ftype.Interface.Name.ToLower())
            {
                case "imacrofunction":
                    return ((IMacroFunction)fObj).Evaluate(param);
                case "imacrovariable":
                    return ((IMacroVariable)fObj).Value;
                default:
                    throw new Exception("Macro element '" + macro + "' is undefined. Please verify your macro drivers.");
            }
        }
        
        bool IsAFunction(string text)
        {
            FunctionType ftype = _macroManager.GetFunction(text, typeof(IMacroFunction));
            return (ftype == null ? false : true);
        }
        bool IsAVariable(string text)
        {
            FunctionType ftype = _macroManager.GetFunction(text, typeof(IMacroVariable));
            return (ftype == null ? false : true);
        }
    }
}
