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

namespace Vibz.Plugin.Plug.XML
{
    internal class InsertAttributePlug : XmlPlugBase
    {
        string _attributeValue;
        string _attributeName;
        public InsertAttributePlug(string filePath, string xPath, string attributeName, string attributeValue)
            : base(filePath, xPath)
        {
            _attributeName = attributeName;
            _attributeValue = attributeValue;
        }
        public override PlugType Type { get { return PlugType.XmlAttribute; } }
        public override bool CanExecute
        {
            get
            {
                try
                {
                    if (IsPlugUsedbyAnotherProcess)
                        return false;

                    XmlNode node = TrySelectNode();
                    if (node == null)
                        throw new Exception("Node '" + _xPath + "' not found while inserting attribute.");

                    if (node.Attributes[_attributeName] != null)
                        throw new Exception("Another attribute with same name already exists. Please use InsertOrReplaceAttribute function when you are not sure of attribute existance");
                }
                catch (Exception exc)
                {
                    Message = exc.Message;
                    return false;
                }
                return true;
            }
        }
        public override bool Execute()
        {
            if (!CanExecute)
                return false;

            XmlNode node = TrySelectNode();
            XmlAttribute attr = TryLoadXml().CreateAttribute(_attributeName);
            attr.Value = _attributeValue;
            node.AppendChild((XmlNode)node.Attributes.Append(attr));

            Commit();
            return true;
        }
    }
}
