using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Vibz.Plugin.Plug.XML
{
    internal class DeleteElementPlug : XmlPlugBase
    {
        public DeleteElementPlug(string filePath, string xPath)
            : base(filePath, xPath)
        { }
        public override bool ExecutionNeeded
        {
            get
            {
                if (TrySelectNode() != null)
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

                    XmlNode node = TrySelectNode();
                    if (node.ParentNode == null)
                        throw new Exception("Node to be deleted must has a parent node.");
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
            XmlNode parentNode = node.ParentNode;
            parentNode.RemoveChild(node);
            Commit();
            return true;
        }
    }
}
