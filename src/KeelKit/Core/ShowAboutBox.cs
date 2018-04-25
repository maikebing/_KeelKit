using System;

namespace KeelKit.Commands
{
  public   class ShowAboutBox:ICommand 
    {
        #region ICommand 成员

        public string Title
        {
            get {return  "关于KeelKit"; }
        }
        public string CmdParams
        {
            set { throw new NotImplementedException(); }
        }
        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {
  
            Dialogs.frmAboutBox about = new KeelKit.Dialogs.frmAboutBox();
            about.ShowDialog ();
            return null;
        }

        public EnvDTE.vsCommandStatus GetCommandStatus()
        {
            return EnvDTE.vsCommandStatus.vsCommandStatusSupported | EnvDTE.vsCommandStatus.vsCommandStatusEnabled;
        }
        public int Positon
        {
            get { return 999; }
        }

        public int IcoID
        {
            get { return 1; }
        }


        public object SettingsPage
        {
            get { return null; }
        }

        #endregion
    }
}
