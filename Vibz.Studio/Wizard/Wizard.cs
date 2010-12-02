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
