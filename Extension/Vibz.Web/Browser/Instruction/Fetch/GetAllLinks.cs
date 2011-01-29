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
    [TypeInfo(Author=WebInstructionBase.Author, Details = "Returns array of all the attributes of the control node associated with given locator.",
        Version = WebInstructionBase.Vesrion)]
    public class GetAllLinks : FetchBase
    {

        public GetAllLinks()
            : base()
        {
                    
        }
        public GetAllLinks(string assignto)
            : base()
        {
            Output = assignto;
            
        }
        public override IData Fetch()
        {
            Collection.URLList urls = Browser.Document.RedirectLinks;
            string[] list = new string[urls.Count];
            int i = 0;
            foreach (Url url in urls)
            {
                list.SetValue(url.Link, i++);
            }
            return new Vibz.Contract.Data.TextArray(list);
        }
    }
}
