using System;
using System.Collections.Generic;
using System.Text;

namespace Vibz.Plugin.Plug
{
    internal abstract class PlugBase : IPlug
    {
        protected string _filePath;
        protected bool _disposed;
        protected bool _verificationNeeded;
        public PlugBase(string filePath)
        {
            _filePath = filePath;
        }
        string _message = "Log not available.";
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public abstract PlugType Type { get; }
        public abstract NegateSeverity Severity { get; }
        public bool VerificationNeeded 
        {
            get 
            {
                return _verificationNeeded;
            }
            set { _verificationNeeded = value; }
        }
        public abstract bool ExecutionNeeded { get; }
        public abstract bool CanExecute { get;}
        public abstract bool Execute();
        public bool TryExecute()
        {
            try
            {
                return Execute();
            }
            catch (Exception exc)
            {
                Message = exc.Message;
                return false;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // ToDo
                    // Clean resources if used 
                }
                _disposed = true;
            }
        }
    }
}
