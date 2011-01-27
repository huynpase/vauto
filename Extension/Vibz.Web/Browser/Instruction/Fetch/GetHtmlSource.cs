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
using System.Xml.Serialization;
 using Vibz.Contract.Attribute;
using Vibz.Contract.Data;

namespace Vibz.Web.Browser.Instruction.Fetch
{
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Returns html source of the document in the focussed window.",
        Version = WebInstructionBase.Vesrion)]
    public class GetHtmlSource : FetchBase
    {

        public GetHtmlSource()
            : base()
        {
                    
        }
        public GetHtmlSource(string assignto)
            : base()
        {
            Output = assignto;
            
        }
        public override IData Fetch()
        {
            Vibz.Contract.Data.Text retValue = new Vibz.Contract.Data.Text(Browser.Document.SourceCode);
            if (retValue != null)
                SetInfo("Html source is:\r\n" + retValue.Value);
            return retValue;
        }
    }
}
