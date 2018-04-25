using System;
using EnvDTE;
using KeelKit.Dialogs;

namespace KeelKit.Commands
{
    class SLNConfig:ICommand 
    {
 

        public    string Title
        {
            get { return "解决方案配置"; }
        }
        public string CmdParams
        {
            set { throw new NotImplementedException(); }
        }
        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {
            try
            {
                frmSlnConfig fsc = new frmSlnConfig();
                fsc.Show();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

 

        public vsCommandStatus GetCommandStatus()
        {
            vsCommandStatus cs = vsCommandStatus.vsCommandStatusUnsupported ;
            if (System.IO.File.Exists(Common.chDTE.Solution.FileName))
            {
                cs = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
            }
            return cs;
        }



        public object SettingsPage
        {
            get { return null; }
        }


        #region ICommand 成员


        public int Positon
        {
            get { return 1; }
        }

        public int IcoID
        {
            get {  return 1; }
        }

        #endregion
    }
}
 