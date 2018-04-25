using System;
using KeelKit.Core;
using KeelKit.FormFactory;

namespace KeelKit.Commands
{
    public class FormFactory2 : ICommand
    {
        #region ICommand 成员

        public string Title
        {
            get { return "自定义表单生成器"; }
        }
        public string CmdParams
        {
            set { throw new NotImplementedException(); }
        }

        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {

            try
            {
                frmDIY fff = new frmDIY();
                fff.Show();
                return null;
            }
            catch (Exception ex)
            {
                return ex;

            }

        }




        public EnvDTE.vsCommandStatus GetCommandStatus()
        {
            EnvDTE.vsCommandStatus cs = Kit.GetCommandStatusForModel();
            EnvDTE.Project pjt = Kit.GetProjectComponent();
            if (pjt != null)
            {
                switch (Kit.GetProjectLangType(pjt))
                {
                    case cfLangType.CSharp:
                    case cfLangType.VBDotNet:

                        //
                        break;
                    default:
                    case cfLangType.CPP:
                    case cfLangType.IronPython:
                    case cfLangType.FSharp:
                        cs = EnvDTE.vsCommandStatus.vsCommandStatusInvisible;
                        break;
                }
            }
            else
            {
                cs = EnvDTE.vsCommandStatus.vsCommandStatusInvisible;
            }
            return cs;

        }
        public int Positon
        {
            get { return 2; }
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
    public class FormFactory : ICommand
    {
        #region ICommand 成员

        public string Title
        {
            get { return "表单生成器"; }
        }
        public string CmdParams
        {
            set { throw new NotImplementedException(); }
        }

        public Exception DoCommand(EnvDTE80.DTE2 dte)
        {

            try
            {
                Dialogs.frmFormFactory fff = new KeelKit.Dialogs.frmFormFactory();
                fff.Show();
                return null;
            }
            catch (Exception ex)
            {
                return ex;

            }

        }




        public EnvDTE.vsCommandStatus GetCommandStatus()
        {
            EnvDTE.vsCommandStatus cs=   Kit.GetCommandStatusForModel();
            EnvDTE.Project pjt = Kit.GetProjectComponent();
            if (pjt != null)
            {
                switch (Kit.GetProjectLangType(pjt))
                {
                    case cfLangType.CSharp:
                    case cfLangType.VBDotNet:
                  
                        //
                        break;
                    default:
                    case cfLangType.CPP:
                    case cfLangType.IronPython:
                    case cfLangType.FSharp:
                        cs = EnvDTE.vsCommandStatus.vsCommandStatusInvisible;
                        break;
                }
            }
            else
            {
                cs = EnvDTE.vsCommandStatus.vsCommandStatusInvisible;
            }
            return cs;

        }
        public int Positon
        {
            get { return 2; }
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
