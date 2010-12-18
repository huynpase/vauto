using System;
using System.Collections.Generic;
using System.Text;
using Vibz.Contract; 

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
