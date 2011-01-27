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

namespace Vibz.Contract
{
    public class InstructionValueMap : Dictionary<string, string>
    {
        static InstructionValueMap _instance = null;
        static object _padlock = new object();
        InstructionValueMap()
        { }
        public static InstructionValueMap Instance
        {
            get {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new InstructionValueMap();
                        }    
                    }
                }
                return _instance;
            }
        }
    }
}
