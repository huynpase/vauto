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
using Vibz.Contract.Data;

namespace Vibz.IO
{
    public abstract class IOBase
    {
        private string _path;
        public string FilePath
        {
            get { return _path; }
            set { _path = value; }
        }
        public abstract void Init(Dictionary<string, object> param);
        public abstract void Write(object text);
        public abstract IData Read();
        public abstract void Append(object text);
    }
}
