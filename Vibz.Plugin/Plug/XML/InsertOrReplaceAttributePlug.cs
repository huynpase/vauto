using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vibz.Plugin.Plug.XML
{
    internal class InsertOrReplaceAttributePlug : XmlPlugBase
    {
        string _attributeValue;
        string _attributeName;
        public InsertOrReplaceAttributePlug(string filePath, string xPath, string attributeName, string attributeValue)
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
            
            if (node.Attributes[_attributeName] != null)
            {
                node.Attributes[_attributeName].Value = _attributeValue;
            }
            else
            {
                XmlAttribute attr = TryLoadXml().CreateAttribute(_attributeName);
                attr.Value = _attributeValue;
                node.AppendChild((XmlNode)node.Attributes.Append(attr));
            }

            Commit();
            return true;
        }
    }
}
