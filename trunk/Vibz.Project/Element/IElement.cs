using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Solution.Element
{
    public enum ElementType { Project, Suite, Case, Identifier, Space, Function, ApplicationGlobal }
    public interface IElement
    {
        string Path { get; }
        string FullName { get; }
        string Name { get; }
        ElementType Type { get; }
        IElement Clone { get; }
        void Load();
        void Save();
        string GetCompiledText();
        void SaveAs(string path);
        Project OwnerProject { get; }
    }
}
