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
using Vibz.Solution.Element;
using System.IO;
using System.Xml;
namespace Vibz.Solution
{
    public class Loader
    {
        public static Project Load(string projectPath)
        {
            if (!File.Exists(projectPath))
                throw new Exception("Invalid Project path.");
            FileInfo diMain = new FileInfo(projectPath);
            Project prj = new Project(diMain);
            prj.Load();
            return prj;
        }
    }
}
