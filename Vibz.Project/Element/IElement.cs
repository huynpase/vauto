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

namespace Vibz.Solution.Element
{
    public enum ElementType { Project, Suite, Case, Identifier, Space, Function, ApplicationGlobal }
    public interface IElement
    {
        bool HasError { get; }
        string Error { get; }
        string Path { get; }
        string FullName { get; set; }
        string Name { get; set; }
        ElementType Type { get; }
        IElement Clone { get; }
        void Load();
        void Save();
        string GetCompiledText();
        void SaveAs(string path);
        Project OwnerProject { get; }
    }
}
