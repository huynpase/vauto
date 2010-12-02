using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Collections;
using System.ServiceProcess;
namespace Vibz.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        protected override void OnAfterInstall(IDictionary savedState)        
        {        
            base.OnAfterInstall(savedState);
            Microsoft.Win32.RegistryKey ckey = 
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                @"SYSTEM\CurrentControlSet\Services\" + 
                this.serviceInstaller1.ServiceName, true); 
            if (ckey != null)   
            {   
                if (ckey.GetValue("Type") != null) 
                {
                    ckey.SetValue("Type", ((int)ckey.GetValue("Type") | 256));
                }
            }
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            ServiceController controller = new ServiceController(Automate.VibzServiceName);
            try
            {
                if (controller.Status == ServiceControllerStatus.Running | controller.Status == ServiceControllerStatus.Paused)
                {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 0, 15));
                    controller.Close();
                }
            }
            catch (Exception ex)
            {
                if (!System.Diagnostics.EventLog.SourceExists(Automate.VibzEventLogSource))
                {
                    System.Diagnostics.EventLog.CreateEventSource(Automate.VibzEventLogSource, Automate.VibzEventLog);
                }

                System.Diagnostics.EventLog eLog = new System.Diagnostics.EventLog();
                eLog.Source = Automate.VibzEventLogSource;
                eLog.WriteEntry(string.Concat(@"The service could not be stopped. Please stop the service manually. Error: ", ex.Message), System.Diagnostics.EventLogEntryType.Error);
            }
            finally
            {
                base.OnBeforeUninstall(savedState);
            }
        } 
    }
}