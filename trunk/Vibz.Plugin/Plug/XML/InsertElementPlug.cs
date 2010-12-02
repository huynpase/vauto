using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vibz.Plugin.Plug.XML
{
    internal class InsertElementPlug : XmlPlugBase
    {
        string _content;
        public InsertElementPlug(string filePath, string xParentPath, string content)
            : base(filePath, xParentPath)
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
                    
                    if (TrySelectNode() == null)
                        throw new Exception("No parent node found at xpath: '" + _xPath + "'. Insertion of a node needs a valid parent node.");

                    if(!ValidateContent(_content))
                        return false;
                }
                catch (Exception exc)
                {
                    Message += exc.Message;
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
            node.InnerXml += _content;
            
            Commit();
            return true;
        }
    }
}
