using System;
using KeelKit.Dialogs;
using KeelKit.Generators;
namespace KeelKit.Commands
{
   public  class SQL2Class:ICommand 
    {
        #region ICommand 成员

        public string Title
        {
            get { return "SQL语句类型化器"; }
        }

        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {
            try
            {
                frmSqlStr2Class frm = new frmSqlStr2Class();
                frm.Show();
                return null ;
            }
            catch (Exception ex)
            {
                return ex;

            }
          
        }
        public static  bool  BuildClassBySql(string sql,string classname)
        {
            return ViewGenerator.GeneratedCode(sql, Kit.GetProjectModel(),classname  );
           
        }
        public EnvDTE.vsCommandStatus GetCommandStatus()
        {
            return Kit.GetCommandStatusForModel();
        }
        public int Positon
        {
            get { return 3; }
        }

        public int IcoID
        {
            get { return 1; }
        }
        #endregion
        public string CmdParams
        {
            set { throw new NotImplementedException(); }
        }

        public object SettingsPage
        {
            get { return null; }
        }

    }
}
