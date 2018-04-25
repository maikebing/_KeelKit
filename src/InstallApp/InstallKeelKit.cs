using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;


namespace InstallApp
{
    [RunInstaller(true)]
    public partial class InstallKeelKit : Installer
    {
        public InstallKeelKit()
        {
            InitializeComponent();
        }
        protected override void OnBeforeInstall(IDictionary savedState)
        {
             
            base.OnBeforeInstall(savedState);
        }
        public override void Install(IDictionary stateSaver)
        {
            Program.InstallKeelKit();
            base.Install(stateSaver);
        }
        public override void Uninstall(IDictionary savedState)
        {
            Program.UninstallKeelKit();
            base.Uninstall(savedState);
        }
        public override void Rollback(IDictionary savedState)
        {
            Program.UninstallKeelKit();
            base.Rollback(savedState);
        }
    }
}
