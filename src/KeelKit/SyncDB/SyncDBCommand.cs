using System;
using KeelKit.SyncDB;

namespace KeelKit.Commands
{
    public  class SyncDBCommand:ICommand 
    {
        public string Title
        {
            get {  return "数据库同步"; }
        }

        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {
            frmSyncDB fsdb = new frmSyncDB();
            fsdb.ShowDialog();
            return null;
        }

        public EnvDTE.vsCommandStatus GetCommandStatus()
        {
            return   EnvDTE.vsCommandStatus.vsCommandStatusSupported | EnvDTE.vsCommandStatus.vsCommandStatusEnabled;
        }

        public int Positon
        {
            get { return 1; }
        }

        public int IcoID
        {
            get { return 1; }
        }
    }
}
