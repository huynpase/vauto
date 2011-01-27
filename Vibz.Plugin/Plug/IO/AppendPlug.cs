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

namespace Vibz.Plugin.Plug.IO
{
    internal class AppendPlug : IOPlugBase
    {
        string _content;
        public AppendPlug(string path, string content)
            : base(path, PlugType.File)
        {
            _content = content;
        }
        public override bool Execute()
        {
            if (!ExecutionNeeded || !CanExecute)
                return false;
            File.AppendAllText(_filePath, _content);
            return true;
        }
    }
}
