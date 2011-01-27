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
