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

namespace Vibz.Studio.Wizard
{
    public class WizardParams : Dictionary<string, object>
    { }
    public class Wizard : System.Windows.Forms.UserControl
    {
        protected WizardParams _parameters;
        public virtual void Init(WizardParams parameters)
        {
            _parameters = parameters;
            return;
        }
        public virtual bool CanNavigate(ref List<string> errors)
        {
            errors = new List<string>();
            return true;
        }
        public virtual WizardParams Parameters
        {
            get { return _parameters; }
        }

        public virtual string Title
        {
            get { return "Configuration Wizard"; }
        }
    }
    
}
