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
namespace Vibz.Configuration
{
    public class ConfigManager
    {
        Dictionary<string, string> _settings;
        XmlDocument xDoc;
        static Dictionary<string, ConfigManager> _instanceList = null;
        static object _padLock = new object();
        ConfigManager(string fileName)
        {
            _settings = new Dictionary<string, string>();
            xDoc = new XmlDocument();
            if (!File.Exists(fileName))
                throw new Exception("Browser configuration file not found.");
            try
            {
                xDoc.Load(fileName);
                XmlNodeList xnl = xDoc.SelectNodes("//configuration/settings/add");
                foreach (XmlNode xn in xnl)
                {
                    if (xn.Attributes == null)
                        continue;
                    string key = (xn.Attributes["key"] == null ? "" : xn.Attributes["key"].Value);
                    string value = (xn.Attributes["value"] == null ? "" : xn.Attributes["value"].Value);
                    if (key != "" && value != "")
                        _settings.Add(key, value);
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Invalid configuration file. '" + fileName + "'. " + exc.Message);
            }
        }
        public static ConfigManager LoadConfig(string fileName)
        {
            if (fileName == "" || !File.Exists(fileName))
                return null;
            if (_instanceList == null)
                _instanceList = new Dictionary<string, ConfigManager>();
            if (!_instanceList.ContainsKey(fileName))
            {
                lock (_padLock)
                {
                    _instanceList.Add(fileName, new ConfigManager(fileName));
                }
            }
            return _instanceList[fileName];
        }
        public Dictionary<string, string> Settings
        {
            get
            {
                return _settings;
            }
        }
    }
}
