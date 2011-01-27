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
