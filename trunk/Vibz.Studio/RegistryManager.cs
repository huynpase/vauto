using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Configuration;

namespace Vibz.Studio
{
    public class RegistryElement
    {
        public string Name;
        public string Description;
        public int Days;
        public string Value;
    }
    public class RegistryManager
    {
        NameValueCollection _config;
        
        static List<RegistryElement> _resList;
        static RegistryManager _manager;
        RegistryManager()
        {
            _config = (NameValueCollection)ConfigurationSettings.GetConfig("registryKey");
        }
        static RegistryManager Manager
        {
            get {
                if (_manager == null)
                {
                    _manager = new RegistryManager();
                }
                return _manager;
            }
        }
        static RegistryElement GetRegistryElement(string name)
        {
            string regText = Manager._config[name];
            string[] regValues = regText.Split(new string[] { "[[", "]]" }, StringSplitOptions.RemoveEmptyEntries);
            RegistryElement reg = new RegistryElement();
            reg.Name = name;
            reg.Description = regValues.GetValue(0).ToString();
            reg.Days = Vibz.Helper.Math.TryGetInteger(regValues.GetValue(1));
            reg.Value = regValues.GetValue(2).ToString();
            return reg;
        }
        public static List<RegistryElement> List
        {
            get {
                if (_resList == null)
                {
                    _resList = new List<RegistryElement>();
                    foreach (string regKey in Manager._config.Keys)
                    {
                        _resList.Add(GetRegistryElement(regKey));
                    }
                    return _resList;
                }
                return _resList;
            }
        }
        public static RegistryElement GetDetailsForRegKey(string key)
        {
            foreach (RegistryElement re in List)
            {
                if (re.Value == key)
                    return re;
            }
            return null;
        }
    }
}
