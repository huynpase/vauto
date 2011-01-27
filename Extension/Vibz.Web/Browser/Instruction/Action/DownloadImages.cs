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

namespace Vibz.Web.Browser.Instruction.Action
{
    [TypeInfo(Author=WebInstructionBase.Author, Details="Downloads all images from current page.", 
        Version = WebInstructionBase.Vesrion)]
    public class DownloadImages : ActionBase
    {
        [XmlAttribute("folderpath")]
        public string FolderPath;
        [XmlAttribute("linkedimages")][AttributeInfo("If true, downloads images provided in links as well.",false)]
        public bool LinkedImages;
        public DownloadImages()
            : base()
        {
                    
        }
        public DownloadImages(string folderPath)
            : this(folderPath, false)
        { }
        public DownloadImages(string folderPath, bool linkedImages)
            : base()
        {
            FolderPath = folderPath;
            LinkedImages = linkedImages; 
        }
        public override void Execute()
        {
            SetInfo("Downloaded '" + Browser.DownloadAllImages(Vibz.Contract.Macro.CommonMacroVariables.Get("__currentpath"), vList.Evaluate(FolderPath), LinkedImages) + "' images from current page into '" + FolderPath + "'.");
        }
    }
}
