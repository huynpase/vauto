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
                case "." + Vibz.FileType.TestCase:
                case "." + Vibz.FileType.Identifier:
                case "." + Vibz.FileType.TestSuite:
                case "." + Vibz.FileType.ApplicationGlobal:
                case "." + Vibz.FileType.Configuration:
                    return DocumentType.XML;
                    break;
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
                case ElementType.Case:
                case ElementType.Function:
                case ElementType.Identifier:
                    return DocumentType.XML;
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
