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
