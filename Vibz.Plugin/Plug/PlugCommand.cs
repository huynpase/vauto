using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vibz.Plugin.Plug
{
    class PlugCommand
    {
        XmlNode _xNode;
        Dictionary<string, string> _commandArguments;
        public PlugCommand(XmlNode node)
        {
            _xNode = node;
            _commandArguments = new Dictionary<string, string>();
            foreach (XmlAttribute attr in _xNode.Attributes)
            {
                _commandArguments.Add(attr.Name.ToLower(), attr.Value);
            }
            if (_xNode.InnerText.Trim() != "")
            {
                if (_commandArguments.ContainsKey("content"))
                    _commandArguments["content"] = _xNode.InnerText;
                else
                    _commandArguments.Add("content", _xNode.InnerText);
            }
        }
        public string GetArgument(string name)
        {
            if(_commandArguments.ContainsKey(name.ToLower()))
                return _commandArguments[name.ToLower()];
            return null;
        }
        public string GetArgument(params string[] names)
        {
            foreach (string name in names)
            {
                if (_commandArguments.ContainsKey(name.ToLower()))
                    return _commandArguments[name.ToLower()];
            }
            return null;
        }
    }
}
