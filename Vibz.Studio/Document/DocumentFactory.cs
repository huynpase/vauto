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
using System.IO;
using Vibz.Solution.Element;
namespace Vibz.Studio.Document
{
    public class DocumentFactory
    {
        public static DocumentType GetDocumentType(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            switch (fi.Extension.ToLower())
            {
                case "." + Vibz.FileType.XML:
                case "." + Vibz.FileType.TestSuite:
                case "." + Vibz.FileType.ApplicationGlobal:
                case "." + Vibz.FileType.Configuration:
                    return DocumentType.XML;
                case "." + Vibz.FileType.TestCase:
                    return DocumentType.TestCase;
                case "." + Vibz.FileType.Identifier:
                    return DocumentType.Identifier;
                case "." + Vibz.FileType.Project:
                    return DocumentType.Project;
                default:
                    throw new Exception("This file type is not supported.");
            }
        }
        public static DocumentType GetDocumentType(IElement element)
        {
            switch (element.Type)
            {
                case ElementType.ApplicationGlobal:
                    return DocumentType.XML;
                case ElementType.Case:
                case ElementType.Function:
                    return DocumentType.TestCase;
                case ElementType.Identifier:
                    return DocumentType.Identifier;
                case ElementType.Suite:
                    return DocumentType.TestSuite;
                case ElementType.Project:
                    return DocumentType.Project;
                default:
                    return DocumentType.None;
            }
        }
        public static string GetDocumentInitialContent(Document.DocumentType type)
        {
            switch (type)
            {
                case DocumentType.XML:
                    return "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
                case DocumentType.TestSuite:
                    return "<suite xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"></suite>";
                default:
                    return "";
            }
        }
    }
}
