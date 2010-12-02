using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Plugin.Plug
{
    internal enum PlugType { File, Folder, XmlElement, XmlAttribute, Register }
    internal enum NegateSeverity { NonFatal, Fatal }
    internal interface IPlug : IDisposable
    {
        string Message { get; }
        PlugType Type { get; }
        NegateSeverity Severity { get; }
        bool VerificationNeeded { get; set; }
        bool ExecutionNeeded { get; }
        bool CanExecute { get;}
        bool Execute();
        bool TryExecute();
        void Dispose(bool disposing);
    }
}
