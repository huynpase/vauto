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
    internal class ReplaceElementPlug : XmlPlugBase
    {
        string _content;
        public ReplaceElementPlug(string filePath, string xPath, string content)
            : base(filePath, xPath)
        {
            _content = content;
        }
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
                        throw new Exception("Node to be replaced must exists. If not sure of existance use InsertOrReplaceElement command.");
                    if (node.ParentNode == null)
                        throw new Exception("Node to be replaced must has a parent node.");

                    if (!ValidateContent(_content))
                        return false;
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

            XmlNode parentNode = node.ParentNode;
            parentNode.RemoveChild(node);
            parentNode.InnerXml += _content;

            Commit();
            return true;
        }
    }
}
