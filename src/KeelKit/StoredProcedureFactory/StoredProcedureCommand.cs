using System;

namespace KeelKit.Commands
{
   public  class StoredProcedureFactory:ICommand 
    {
        #region ICommand 成员

        public string Title
        {
            get { return "存储过程生成器"; }
        }

        public object SettingsPage
        {
            get { return null; }
        }

        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {
            try
            {
                KeelKit.StoredProcedureFactory.frmSPFactory fb = new KeelKit.StoredProcedureFactory.frmSPFactory();
                fb.Show();
                return null;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public EnvDTE.vsCommandStatus GetCommandStatus()
        {
            return Kit.GetCommandStatusForDAL();
        }

        public int Positon
        {
            get { return 2; }
        }

        public int IcoID
        {
            get { return 1; }
        }

        #endregion

        #region ICommand 成员


        public string CmdParams
        {
            set { throw new NotImplementedException(); }
        }

        #endregion
    }
}
