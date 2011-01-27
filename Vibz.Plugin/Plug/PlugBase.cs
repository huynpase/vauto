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
