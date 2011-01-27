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
using System.IO;
using System.Configuration;
using System.Reflection;
using Vibz.Contract.Log;

namespace Vibz.Plugin.Plug
{
    internal class PlugFactory
    {
        const string Destination = "destinationpath";
        Dictionary<string, string> _factoryParam;
        string _sourcePath;
        public PlugFactory(string sourcePath, Dictionary<string, string> factoryParam)
        {
            _factoryParam = new Dictionary<string, string>();
            foreach (string key in factoryParam.Keys)
            {
                _factoryParam.Add(key.ToLower(), factoryParam[key]);
            }
            _sourcePath = sourcePath;
        }
        string DestinationPath
        {
            get {
                if (_factoryParam == null || _factoryParam[PlugFactory.Destination.ToLower()] == null)
                    throw new Exception(PlugFactory.Destination.ToLower() + " not specified.");
                else
                    return _factoryParam[PlugFactory.Destination.ToLower()];
            }
        }
        public void Init(XmlNode xNode)
        {
            foreach (XmlNode xVar in xNode.ChildNodes)
            {
                if (xVar.Attributes["value"] == null)
                    throw new Exception("Expected 'value' node. Source: Plugin > Init.");
                if (_factoryParam.ContainsKey(xVar.Name.ToLower()))
                    _factoryParam[xVar.Name.ToLower()] = ParseValue(xVar.Attributes["value"].Value);
                else
                    _factoryParam.Add(xVar.Name.ToLower(), ParseValue(xVar.Attributes["value"].Value));
            }
        }
        string ParseValue(string value)
        {
            string newValue = value;
            while (newValue.Contains("${"))
            {
                int st_index = newValue.IndexOf("${");
                int end_index = newValue.IndexOf("}", st_index);
                if (end_index == -1)
                    throw new Exception("Invalid value string. Source: Plugin > Init.");
                string rep = newValue.Substring(st_index, end_index - st_index + 1);
                string param = rep.Substring(2, rep.Length - 3);
                if (_factoryParam.ContainsKey(param.ToLower()))
                    newValue = newValue.Replace(rep, _factoryParam[param.ToLower()]);
                else
                    throw new Exception(rep + " not defined.");
            }
            return newValue;
        }
        public IPlug GetPlugHandler(XmlNode commandNode)
        {
            IPlug plug = null;
            try
            {
                PlugCommand command = new PlugCommand(commandNode);
                switch (commandNode.Name.ToLower())
                {
                    case "iodelete":
                        plug = new IO.DeletePlug(GetFullPath(command), 
                            ParseValue(command.GetArgument("type")));
                        break;
                    case "ioappend":
                        plug = new IO.AppendPlug(GetFullPath(command),
                            ParseValue(command.GetArgument("content")));
                        break;
                    case "ioaddorreplace":
                        plug = new IO.AddOrReplacePlug(_sourcePath + "/" + ParseValue(command.GetArgument("source")),
                            GetFullPath(command), ParseValue(command.GetArgument("type")));
                        break;
                    case "xmldeleteattribute":
                        plug = new XML.DeleteAttributePlug(GetFullPath(command),
                            ParseValue(command.GetArgument("xpath")),
                            ParseValue(command.GetArgument("attributename")));
                        break;
                    case "xmlinsertattribute":
                        plug = new XML.InsertAttributePlug(GetFullPath(command),
                            ParseValue(command.GetArgument("xpath")),
                            ParseValue(command.GetArgument("attributename")),
                            ParseValue(command.GetArgument("attributevalue")));
                        break;
                    case "xmlinsertorreplaceattribute":
                        plug = new XML.InsertOrReplaceAttributePlug(GetFullPath(command),
                            ParseValue(command.GetArgument("xpath")),
                            ParseValue(command.GetArgument("attributename")),
                            ParseValue(command.GetArgument("attributevalue")));
                        break;
                    case "xmldeleteelement":
                        plug = new XML.DeleteElementPlug(GetFullPath(command),
                            ParseValue(command.GetArgument("xpath")));
                        break;
                    case "xmlinsertelement":
                        plug = new XML.InsertElementPlug(GetFullPath(command),
                            ParseValue(command.GetArgument("xpath")),
                            ParseValue(command.GetArgument("content")));
                        break;
                    case "xmlinsertorreplaceelement":
                        plug = new XML.InsertOrReplaceElementPlug(GetFullPath(command),
                            ParseValue(command.GetArgument("xpath")),
                            ParseValue(command.GetArgument("content")));
                        break;
                    case "xmlreplaceelement":
                        plug = new XML.ReplaceElementPlug(GetFullPath(command),
                            ParseValue(command.GetArgument("xpath")),
                            ParseValue(command.GetArgument("content")));
                        break;
                    case "register":
                        int index = (DestinationPath.LastIndexOfAny(new char[] { '/', '\\' }) == -1 ? 0 : DestinationPath.LastIndexOfAny(new char[] { '/', '\\' }) + 1);
                        string plugBase = DestinationPath.Substring(index);
                        plug = new Register(Vibz.Reflection.Runtime.GetAbsolutePath(PlugManager.GetConfig().RegFile), PlugManager.GetConfig().NodePath + "/" + plugBase,
                            ParseValue(command.GetArgument("name")),
                            ParseValue(command.GetArgument("assembly")),
                            ParseValue(command.GetArgument("config")),
                            plugBase);
                        break;
                    default:
                        plug = null;
                        break;
                }
                bool verify = true;
                Boolean.TryParse(command.GetArgument("verify"), out verify);
                plug.VerificationNeeded = verify;
            }
            catch (Exception exc)
            {
                LogQueue.Instance.Enqueue(new LogQueueElement("Error while finding plugin handler. " + exc.Message, LogSeverity.Error));
                plug = null;
            }
            return plug;
        }
        string GetFullPath(PlugCommand command)
        {
            return Vibz.Reflection.Runtime.GetAbsolutePath(DestinationPath + "/" + ParseValue(command.GetArgument("path", "destination")));
        }
    }
}
