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
    internal class DeleteAttributePlug : XmlPlugBase
    {
        string _attributeName;
        public DeleteAttributePlug(string filePath, string xPath, string attributeName)
            : base(filePath, xPath)
        {
            _attributeName = attributeName;
        }
        public override PlugType Type { get { return PlugType.XmlAttribute; } }
        public override bool ExecutionNeeded
        {
            get
            {
                XmlNode node = TrySelectNode();
                if (node != null && node.Attributes[_attributeName] != null)
                    return true;
                return false;
            }
        }
        public override bool CanExecute
        {
            get
            {
                try
                {
                    if (IsPlugUsedbyAnotherProcess)
                        return false;

                    if (!ExecutionNeeded)
                        return true;
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
            if (!CanExecute || !ExecutionNeeded)
                return false;

            XmlNode node = TrySelectNode();
            node.RemoveChild((XmlNode)node.Attributes[_attributeName]);

            Commit();
            return true;
        }
    }
}
