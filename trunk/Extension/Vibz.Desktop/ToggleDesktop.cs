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

namespace Vibz.Desktop
{
    [TypeInfo(Author="Vibzworld", Details = "Toggles current state of window. Minimizes all windows to show desktop if any open or restores minimized windows to original state.",
        Version = "2.0")]
    public class ToggleDesktop : InstructionBase, IAction
    {
        public ToggleDesktop()
        {
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            Shell32.ShellClass objShel = new Shell32.ShellClass();
            ((Shell32.IShellDispatch4)objShel).ToggleDesktop();
        }
        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement("Toggled current state of window.");
            }
        }
    }
}
