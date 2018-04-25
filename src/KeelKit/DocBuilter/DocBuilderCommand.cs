using System;

namespace KeelKit.Commands
{
  public   class DocBuilder:ICommand 
    {
        #region ICommand 成员

        public string Title
        {
            get {return  "生成数据库文档"; }
        }
        public string CmdParams
        {
            set { throw new NotImplementedException(); }
        }

        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {
            try
            {
                KeelKit.DocBuilter.frmBuilder fb = new KeelKit.DocBuilter.frmBuilder();
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
            return Kit.GetCommandStatusForModel();
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


        public object SettingsPage
        {
            get { return null; }
        }

        #endregion
    }
}
