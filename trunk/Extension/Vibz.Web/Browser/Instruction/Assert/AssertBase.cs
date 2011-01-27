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
using Vibz.Contract;
using Vibz.Contract.Attribute;

namespace Vibz.Web.Browser.Instruction.Assert
{
    public abstract class AssertBase : WebInstructionBase, IAssert
    {
        public AssertBase()
        {
            Type = InstructionType.Assert;
        }
        public abstract bool Assert();
        public virtual bool Assert(Vibz.Contract.Data.DataHandler varList)
        {
            try
            {
                vList = varList;
                bool result = Assert();
                if (GetInfo() == null)
                    SetInfo("Assertion '" + this.GetType().Name + "' returned '" + (result ? "true" : "false") + "'.");
                return result;
            }
            catch (Exception exc)
            {
                throw GetBrowserException(exc);
            }
        }
    }
}
