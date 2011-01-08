using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Vibz.Solution.Element;
namespace Vibz.Studio.Document
{
    public enum DocumentType { None, TestSuite, TestCase, Identifier, XML, Project }
    public interface IDocument
    {
        void Close();
        void Save();
        void SaveAs();
        void Focus();
        bool IsModified { get; }
        string Path { get; }
        bool DoClose { get; }
        DocumentType Type { get; }
        string DocumentName { get; }
        void Add(IElement element);
        void Render();
    }
}
