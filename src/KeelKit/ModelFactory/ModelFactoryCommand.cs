using System;


namespace KeelKit.Commands
{
    public class ModelFactory : ICommand
    {
        #region ICommand 成员

        public string Title
        {
            get { return "模型生成器"; }
        }
        public string CmdParams
        {
            set { throw new NotImplementedException(); }
        }
        public object SettingsPage
        {
            get { return null; }
        }

        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {
            try
            {
                Dialogs.frmModelFactory fmf = new KeelKit.Dialogs.frmModelFactory();
                fmf.Show();
                return null;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public void Show()
        {

        }
        #endregion

        #region ICommand 成员


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
    }
}
