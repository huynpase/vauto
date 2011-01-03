using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Studio.Document.XDoc
{
    public enum XMode
    {
        None,
        PageBegin,
        NodeBeginOpen,
        NodeNameBegin,
        AttributeName,
        AttributeEqual,
        AttributeValueStart,
        AttributeValue,
        AttributeValueEnd,
        AttributeSeperation,
        NodeBeginClose,
        NodeEndLeafSlash,
        NodeEndLeafClose,
        NodeEndBranchOpen,
        NodeEndBranchSlash,
        NodeEndBranchClose,
        NodeNameEnd,
        InnerText,
        CDATA,
        InnerTextSibling,
        PageEnd
    }
}
