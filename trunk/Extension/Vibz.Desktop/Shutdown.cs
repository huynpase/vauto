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
using System.Management;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Vibz.Contract;
using Vibz.Contract.Attribute;

namespace Vibz.Desktop
{
    [TypeInfo(Author="Vibzworld", Details = "Toggles current state of window. Minimizes all windows to show desktop if any open or restores minimized windows to original state.",
        Version = "2.0")]
    public class Shutdown : InstructionBase, IAction
    {
        bool _force;
        [XmlAttribute("force")]
        public bool Force
        {
            get { return _force; }
            set { _force = value; }
        }
        public Shutdown()
        {
            Type = InstructionType.Action;
        }
        public void Execute(Vibz.Contract.Data.DataHandler vList)
        {
            // Shell32.ShellClass objShel = new Shell32.ShellClass();
            // ((Shell32.IShellDispatch4)objShel).ShutdownWindows();
            ShutDownComputer();
        }
        void ShutDownComputer()
        {
            /*
             * Flags:
                * 0 = Log off the network.
                * 1 = Shut down the system.
                * 2 = Perform a full reboot of the system.
                * 4 = Force any applications to quit instead of prompting the user to close them.
                * 8 = Shut down the system and, if possible, turn the computer off.
            */
            ManagementBaseObject outParameters = null;
            ManagementClass sysOS = new ManagementClass("Win32_OperatingSystem");
            sysOS.Get();
            sysOS.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject inParameters = sysOS.GetMethodParameters("Win32Shutdown");
            inParameters["Flags"] = (Force ? "4" : "1");
            inParameters["Reserved"] = "0";
            foreach (ManagementObject manObj in sysOS.GetInstances())
            {
                outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
            }
        }


        public override Vibz.Contract.Log.LogElement InfoEnd
        {
            get
            {
                return new Vibz.Contract.Log.LogElement((Force ? "Force" : "Soft") + " shutdown of the system.");
            }
        }
    }
}
