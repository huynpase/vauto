using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vibz.Plugin.Plug.XML
{
    internal class InsertOrReplaceElementPlug : XmlPlugBase
    {
        string _content;
        public InsertOrReplaceElementPlug(string filePath, string xPath, string content)
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
                    {
                        Message = "File used by another process. ";
                        return false;
                    }

                    XmlNode node = TrySelectNode();
                    if (node == null)
                    {
                        string pXpath = _xPath.Substring(0, _xPath.LastIndexOf('/'));
                        if (TrySelectNode(pXpath) == null)
                            throw new Exception("Node to be inserted or replaced must have a parent node.");
                    }
                    else
                    {
                        if (node.ParentNode == null)
                            throw new Exception("Node to be inserted or replaced must have a parent node.");
                    }

                    if (!ValidateContent(_content))
                    {
                        Message = "Content validation failed. ";
                        return false;
                    }
                }
                catch (Exception exc)
                {
                    Message = "Error at InsertOrReplaceElementPlug. CanExecute: " + exc.Message;
                    return false;
                }
                return true;
            }
        }
        public override bool Execute()
        {
            try
            {
                if (!CanExecute)
                    return false;

                XmlNode node = TrySelectNode();
                if (node == null)
                {
                    string pXpath = _xPath.Substring(0, _xPath.LastIndexOf('/'));
                    XmlNode pnode = TrySelectNode(pXpath);
                    if (pnode == null)
                        throw new Exception("Invalid xpath '" + _xPath + "'.");
                    pnode.InnerXml += _content;
                }
                else
                {
                    XmlNode parentNode = node.ParentNode;
                    parentNode.RemoveChild(node);
                    parentNode.InnerXml += _content;
                }

                Commit();
                return true;
            }
            catch (Exception exc)
            {
                throw new Exception("Error at InsertOrReplaceElementPlug. Execute: " + exc.Message);
            }
        }
    }
}
