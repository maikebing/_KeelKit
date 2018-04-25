using System;
using EnvDTE;
using VSLangProj;


namespace KeelKit.Commands
{
    public class NunitCommand : ICommand
    {
        #region ICommand 成员

        public string Title
        {
            get { return "运行单元测试"; }
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

                if (Kit.SlnKeel.Nunit.Enable)
                {
                    Common.ShowInfo("正在为启动单元测试项目准备信息....");
                    Project pjt = Kit.GetProjectByName(Kit.SlnKeel.Nunit.NunitProject);
                    if (pjt != null)
                    {
                        AddProjectRefsToNunitProject(pjt);
                        AddNunitRef(pjt);
                        Common.ShowInfo("开始调试...");
                        Configuration cfg = pjt.ConfigurationManager.ActiveConfiguration;
                        //for (int i = 1; i < cfg.Properties.Count ; i++)
                        //{
                        //    System.Diagnostics.Debug.WriteLine(cfg.Properties.Item(i).Name);
                        //}

                        string nunitprogram =    System.IO.Path.Combine(Kit.SlnKeel.Nunit.NUnitRoot, "nunit.exe")  ;
                        if (System.IO.File.Exists(nunitprogram ))
                        {
                            cfg.Properties.Item("StartProgram").Value =   nunitprogram  ;
                        cfg.Properties.Item("StartArguments").Value = "\"" + pjt.FullName + "\"";
                        cfg.Properties.Item("StartWorkingDirectory").Value =   System.IO.Path.Combine(new System.IO.FileInfo(pjt.FullName).DirectoryName, cfg.Properties.Item("OutputPath").Value.ToString()) ;
                        cfg.Properties.Item("StartAction").Value = 1;
                        try
                        {
                              Common.chDTE.Solution.SolutionBuild.StartupProjects =new object[]{pjt.UniqueName };
                        }
                        catch (Exception)
                        {
                            
                            
                        }
                         
                        Common.chDTE.Solution.SolutionBuild.Debug();
                        }
                    }
                    else
                    {
                        Common.ShowInfo("未指定NUnit项目");
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                
                return ex;
            }
        }

        private    void  AddProjectRefsToNunitProject(Project pjt)
        {
            for (int i = 1; i <= Common.chDTE.Solution.Projects.Count; i++)
            {
                Project pjtx = Common.chDTE.Solution.Projects.Item(i);

                Kit.AddProjectRefToProject(pjtx, pjt);
            }
        }

        private static void AddNunitRef(Project pjt)
        {
            string npaht = System.IO.Path.Combine(Kit.SlnKeel.Nunit.NUnitRoot, "nunit.framework.dll");
            if (System.IO.File.Exists(npaht))
            {
                VSProject p2 = Kit.ProjectToVSProject(pjt);
                if (p2 != null)
                {
                    if (p2.References.Find("NUnit.Framework") == null)
                    {
                        try
                        {

                            Reference r = p2.References.Add(npaht);

                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        public void Show()
        {

        }
        #endregion

        #region ICommand 成员


        public EnvDTE.vsCommandStatus GetCommandStatus()
        {
            bool ok =Kit.SlnKeel != null && Kit.SlnKeel.Nunit != null && Kit.SlnKeel.Nunit.Enable;
            return ok ? (EnvDTE.vsCommandStatus.vsCommandStatusSupported | EnvDTE.vsCommandStatus.vsCommandStatusEnabled) : EnvDTE.vsCommandStatus.vsCommandStatusUnsupported;
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
