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
using Vibz.Contract;
using Vibz.Contract.Data;
using Vibz.Contract.Data.Source;
namespace Vibz.Interpreter.Configuration
{
    public class DataManager
    {
        public const string NodeName = "data";
        public static void Reset()
        {
            _dataTemplate = null;
        }
        public static List<IData> _dataTemplate;
        public static List<IData> Templates
        {
            get
            {
                if (_dataTemplate == null)
                {
                    _dataTemplate = new List<IData>();
                    Vibz.Interpreter.Plugin.PluginAssembly dataTypes = new Vibz.Interpreter.Plugin.PluginAssembly("Data Handlers");
                    Vibz.Contract.Log.LogElement progress = new Vibz.Contract.Log.LogElement("Loading Data Handlers.");
                    XmlNodeList xnl = Plugin.PluginManager.Document.SelectNodes("//" + Register.NodeName + "/" + DataManager.NodeName + "/" + Register.Include.NodeName);
                    foreach (XmlNode xn in xnl)
                    {
                        if (xn.Attributes == null)
                            continue;
                        string name = (xn.Attributes[Register.Include.Name] == null ? "" : xn.Attributes[Register.Include.Name].Value);
                        string path = (xn.Attributes[Register.Include.Path] == null ? "" : xn.Attributes[Register.Include.Path].Value);
                        if (path != "")
                        {
                            progress.Add("Loading data handler types from " + path);
                            dataTypes.Append(ConfigManager.LoadTypes(path, 
                                new Type[] { typeof(Vibz.Contract.Data.IData) }
                                ));
                        }
                    }
                    foreach (FunctionType type in dataTypes.Values)
                    {
                        _dataTemplate.Add((IData)Activator.CreateInstance(type.Type));
                    }
                }
                return _dataTemplate;
            }
            set { _dataTemplate = value; }
        }
        public static void Export(Var source, Var destination, DataExportMode mode)
        {
            if (destination == null)
                throw new Exception("Destination is invalid.");
            IData data = GetData(source);
            if (data == null)
                return;
            if (destination.Type.ToLower() != data.Type.ToLower())
                throw new Exception("Source and destination data must be of same type for exporting.");
            foreach (IData temp in Templates)
            {
                if (temp.Source.ToLower() == destination.Source.ToLower()
                    && temp.Type.ToLower() == destination.Type.ToLower())
                {
                    try
                    {
                        switch (destination.Type.ToLower())
                        {
                            case "array":
                                ((ExternalData<TextArray>)temp).Export(destination.ParamList, (TextArray)data, mode);
                                break;
                            case "datatable":
                                ((ExternalData<DataTable>)temp).Export(destination.ParamList, (DataTable)data, mode);
                                break;
                            case "keyvalueset":
                                ((ExternalData<KeyValueSet>)temp).Export(destination.ParamList, (KeyValueSet)data, mode);
                                break;
                            case "scalar":
                            default:
                                ((ExternalData<Text>)temp).Export(destination.ParamList, (Text)data, mode);
                                break;
                        }
                    }
                    catch (Exception exc)
                    {
                        throw new Exception("Data " + destination.Source + "|" + destination.Type + "|" + destination.Name + " could not be exported. " + exc.Message);
                    }
                }
            }
        }
        public static IData GetData(Var var)
        {
            if (var.Source.ToLower() == SourceType.Internal.ToString().ToLower())
            {
                if (var.Data != null)
                    return var.Data;
                else if (var.InnerText != null)
                    return new Vibz.Contract.Data.Text(var.InnerText);
                else
                    throw new Exception("Data Error.");
            }
            // Process External data
            foreach (IData temp in Templates)
            {
                if (temp.Type.ToLower() == var.Type.ToLower())
                {
                    try
                    {
                        switch (var.Type.ToLower())
                        {
                            case "array":
                                ((ExternalData<TextArray>)temp).Load(var.ParamList);
                                return ((ExternalData<TextArray>)temp).Value;
                            case "datatable":
                                ((ExternalData<DataTable>)temp).Load(var.ParamList);
                                return ((ExternalData<DataTable>)temp).Value;
                            case "keyvalueset":
                                ((ExternalData<KeyValueSet>)temp).Load(var.ParamList);
                                return ((ExternalData<KeyValueSet>)temp).Value;
                            case "scalar":
                            default:
                                ((ExternalData<Text>)temp).Load(var.ParamList);
                                return ((ExternalData<Text>)temp).Value;
                        }
                    }
                    catch (Exception exc)
                    {
                        throw new Exception("Data " + var.Source + "|" + var.Type + "|" + var.Name + " could not be loaded. " + exc.Message);
                    }
                }
            }
            return null;
        }
    }
}
