using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualStudio.CommandBars;

namespace KeelKit
{
    public class Common
    {
       
        public static DTE2 chDTE;
        public static AddIn chAddIN;
        public static OutputWindowPane chOutWin;
        public static CommandBarControl chMenu;
        private static string _commands = null;
        public static Win7Taskbar Win7Taskbar;
        public static List<ICommand> asmCommands = new List<ICommand>();

        public const string PjtKind_SolutionFolder = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";

        public const string PjtKind_VisualBasic = "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}";

        public const string PjtKind_VisualCSharp = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";

        public const string PjtKind_VisualCPP = "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}";

        public const string PjtKind_VisualJSharp = "{E6FDF86B-F3D1-11D4-8576-0002A516ECE8}";

        public const string PjtKind_WebProject = "{E24C65DC-7377-472b-9ABA-BC803B73C61A}";
        public const string PjtKind_WebApplication = "{610D4614-D0D5-11D2-8599-006097C68E81}";
        public static string GetCommands()
        {
            if (_commands == null)
            {
                Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                Type[] ts = asm.GetTypes();
                foreach (Type var in ts)
                {
                    if (var.FullName.StartsWith("KeelKit.Commands"))
                    {
                        _commands += "," + var.Name;
                    }
                }

            }
            return _commands;
        }
        /// <summary> 
        /// 获取当前语言版本的菜单标题字符串. 
        /// </summary> 
        /// <param name="resKey">标准字符串名称.</param> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        public static string GetDTEMenuName(string resKey)
        {
            // 功能:该代码实现从资源文件中读取DTE的菜单标题 
            //完成日期:2006-01-13 
            System.Resources.ResourceManager ResMg = new System.Resources.ResourceManager("KeelKit.CommandBar", System.Reflection.Assembly.GetExecutingAssembly());
            System.Globalization.CultureInfo CultureInfo = new System.Globalization.CultureInfo(chDTE.LocaleID);
            string chMenuName = ResMg.GetString(string.Concat(CultureInfo.TwoLetterISOLanguageName + (CultureInfo.TwoLetterISOLanguageName == "zh" ? "-" + CultureInfo.ThreeLetterWindowsLanguageName.ToString() : "").ToString(), resKey));
            //根据CommandBar.resx的资源分析,该资源中仅仅包含了中文的多类别,既简体和繁体两种,对这两种 
            //语言而言, 需要指定 CultureInfo.ThreeLetterWindowsLanguageName是'CHS'还是'CHT',然后与zh 
            //之间需要 '-'隔开故.判断如果为'zh'则追加加字符串CultureInfo.ThreeLetterWindowsLanguageName 
            //然后与Concat 的第二个参数连接出一字符串给GetString() 
            //该方法仅仅用于该语言资源包.且,该资源包完全能够胜任开发任何一种语言的外接程序 
            return chMenuName;
        }


        /// <summary> 
        /// 添加命令
        /// </summary> 
        /// <param name="Owner">拥有该命令和项的菜单或工具条</param> 
        /// <param name="Name">命令名称.</param> 
        /// <param name="Caption">要添加的项目标题.该标题还用于删除该按钮/项</param> 
        /// <remarks>注意:该函数建议采用于菜单的添加操作</remarks> 

        public static Exception AddCommand(CommandBarControl Owner, string Name, string Caption, int bmpid)
        {
            Commands2 Cmds = (Commands2)chDTE.Commands;
            CommandBars CmdBars = (CommandBars)chDTE.CommandBars;
            CommandBar mnuBarCmdBar = CmdBars["MenuBar"];
            //菜单 
            CommandBarPopup CmdPopup = (CommandBarPopup)Owner;
            try
            {
                object[] contextGUIDS = new object[] { };
                Command chCmdConfig = Cmds.AddNamedCommand2(chAddIN, Name, Caption, Caption, true  ,bmpid , ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                if (chCmdConfig != null && CmdPopup != null)
                {
                    CommandBarControl cbc = (CommandBarControl)chCmdConfig.AddControl(CmdPopup.CommandBar,1);
                 // cbc.DescriptionText = Caption;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
       public static   CommandBarEvents menuItemHandler;
       public static CommandBarEvents menuItemHandlerPI;
       static CommandBarControl menuItemPI = null;
       static CommandBarControl menuItem = null;
       public static void DelOpenFloderForVS()
       {
           CommandBars cmdBars = (CommandBars)(Common.chDTE.DTE.CommandBars);
          
           if (menuItemPI != null)
           {
               menuItemPI.Delete(null);

           }
           if (menuItem != null)
           {
               menuItem.Delete(null);
           }
           if (menuItemCTH != null)
           {
               menuItemCTH.Delete(null);
           }
           if (menuItemCTH_C != null)
           {
               menuItemCTH_C.Delete(null);
           }
           if (menuItemCopyPath != null)
           {
               menuItemCopyPath.Delete(null);
           }
           if (menuItem != null)
           {
               menuItem.Delete(null);
           }
           //if (menuItemCTH != null)
           //{
           //    menuItemCTH.Delete(null);
           //}
       }
       public void SynchronizeClassView()
       {

           CommandBars cmdBars = (CommandBars)(Common.chDTE.DTE.CommandBars);
           CommandBar vsBarProjectItem = cmdBars["Item"];
           menuItemPI = vsBarProjectItem.Controls.Add(MsoControlType.msoControlButton, 1, "", 2, true);
       }
        public static bool AddOpenFloderFoVS()
        {
            CommandBars cmdBars = (CommandBars)(Common.chDTE.DTE.CommandBars);
            CommandBar vsBarProjectItem = cmdBars["Item"];
     
              menuItemPI = vsBarProjectItem.Controls.Add(MsoControlType.msoControlButton, 1, "", 2, true);

              menuItemPI.Caption =  "在 Windows 资源管理器中打开文件夹(&X)";
           if (chDTE.Version != "10.0") menuItemPI.TooltipText = menuItemPI.Caption;
            menuItemHandlerPI = (CommandBarEvents)Common.chDTE.DTE.Events.get_CommandBarEvents(menuItemPI);
            menuItemHandlerPI.Click += new _dispCommandBarControlEvents_ClickEventHandler(menuItemHandler_Click);

            if (chDTE.Version != "8.0") return true ;
           
            CommandBar vsBarProject = cmdBars["Project"];
              menuItem = vsBarProject.Controls.Add(MsoControlType.msoControlButton, 1, "", 2, true);
             
            menuItem.Caption = "在 Windows 资源管理器中打开文件夹(&X)";
            if (chDTE.Version != "10.0") menuItem.TooltipText = menuItem.Caption;
            menuItemHandler = (CommandBarEvents)Common.chDTE.DTE.Events.get_CommandBarEvents(menuItem);
            menuItemHandler.Click += new _dispCommandBarControlEvents_ClickEventHandler(menuItemHandler_Click);
            return true;
        }
        public static CommandBarEvents menuItemHandlerCTH;
        static CommandBarControl menuItemCTH = null;
        public static CommandBarEvents menuItemHandlerCTH_C;
        static CommandBarControl menuItemCTH_C = null;
        public static CommandBarEvents menuItemHandlerCopyPath;
        static CommandBarControl menuItemCopyPath = null;
        public static bool AddCopyToHtmlForVS()
        {
            // 
            CommandBars cmdBars = (CommandBars)(Common.chDTE.DTE.CommandBars);
            CommandBar vsBarProjectItem = cmdBars["Item"];
            menuItemCopyPath = vsBarProjectItem.Controls.Add(MsoControlType.msoControlButton, 1, "", 1, true);
            menuItemCopyPath.Caption = "复制完整路径";
            if (chDTE.Version != "10.0") menuItemCopyPath.TooltipText = menuItemCopyPath.Caption;
            menuItemHandlerCopyPath = (CommandBarEvents)Common.chDTE.DTE.Events.get_CommandBarEvents(menuItemCopyPath);
            menuItemHandlerCopyPath.Click += new _dispCommandBarControlEvents_ClickEventHandler(menuItemHandlerCopyPath_Click);

 
            menuItemCTH = vsBarProjectItem.Controls.Add(MsoControlType.msoControlButton, 1, "", 1, true);
            menuItemCTH.Caption = "HTML格式保存并打开";
            if (chDTE.Version != "10.0") menuItemCTH.TooltipText = menuItemCTH.Caption;
            menuItemHandlerCTH = (CommandBarEvents)Common.chDTE.DTE.Events.get_CommandBarEvents(menuItemCTH);
            menuItemHandlerCTH.Click += new _dispCommandBarControlEvents_ClickEventHandler(menuItemHandlerCTH_Click);


            menuItemCTH_C = vsBarProjectItem.Controls.Add(MsoControlType.msoControlButton, 1, "", 1, true);
            menuItemCTH_C.Caption = "HTML格式复制";
            if (chDTE.Version != "10.0") menuItemCTH_C.TooltipText = menuItemCTH_C.Caption;
            menuItemHandlerCTH_C = (CommandBarEvents)Common.chDTE.DTE.Events.get_CommandBarEvents(menuItemCTH_C);
            menuItemHandlerCTH_C.Click += new _dispCommandBarControlEvents_ClickEventHandler(menuItemHandlerCTH_C_Click);
            return true ;
        }

        static void menuItemHandlerCopyPath_Click(object CommandBarControl, ref bool Handled, ref bool CancelDefault)
        {
            if (Common.chDTE.SelectedItems.Count > 0)
            {
                string path = null;
                if ((Common.chDTE.SelectedItems.Item(1).Project) != null)
                {
                    path = Common.chDTE.SelectedItems.Item(1).Project.FileName;
                }
                else if ((Common.chDTE.SelectedItems.Item(1).ProjectItem) != null)
                {
                    path = Common.chDTE.SelectedItems.Item(1).ProjectItem.get_FileNames(1);
                }
                else
                {
                    Common.ShowInfo("无此项");
                }
                if (path != null)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(path, TextDataFormat.Text);
                    Common.ShowInfo("复制路径完成!");
                }
            }
            else
            {
                Common.ShowInfo("未选中任何内容");
            }

        }

        static void menuItemHandlerCTH_C_Click(object CommandBarControl, ref bool Handled, ref bool CancelDefault)
        {
            Common.ShowInfo("正在准备HTML格式复制...");
            if (Common.chDTE.SelectedItems.Count > 0)
            {
                string path = "";

                if ((Common.chDTE.SelectedItems.Item(1).ProjectItem) != null)
                {
                    path = Common.chDTE.SelectedItems.Item(1).ProjectItem.get_FileNames(1);
                    string lang = Kit.GetProjectLangStr2(Kit.GetProjectLangType(Common.chDTE.SelectedItems.Item(1).ProjectItem.ContainingProject));
                    if (System.IO.File.Exists(path))
                    {
                        string html = KeelKit.Generators.CodeToHtml.CopyCodeToStringHtml(path, lang);
                        Clipboard.Clear();
                        Clipboard.SetText(html, TextDataFormat.Text);
                        Common.ShowInfo("HTML格式复制到剪切板!");
                    }
                    else
                    {
                        Common.ShowInfo("文件不存在，无法复制!");
                    }
                }
                else
                {
                    Common.ShowInfo("无此项");
                }

            }
            else
            {
                Common.ShowInfo("未选中任何内容");
            }
        }

        static void menuItemHandlerCTH_Click(object CommandBarControl, ref bool Handled, ref bool CancelDefault)
        {
            Common.ShowInfo("准备HTML格式保存");
            if (Common.chDTE.SelectedItems.Count > 0)
            {
                string path = "";

                if ((Common.chDTE.SelectedItems.Item(1).ProjectItem) != null)
                {
                    path = Common.chDTE.SelectedItems.Item(1).ProjectItem.get_FileNames(1);
                    string lang = Kit.GetProjectLangStr2(Kit.GetProjectLangType(Common.chDTE.SelectedItems.Item(1).ProjectItem.ContainingProject));
                    if (System.IO.File.Exists(path))
                    {

                        KeelKit.Generators.CodeToHtml.CopyCodeToHtml(path, lang);
                        Common.ShowInfo("复制并打开完成!");
                    }
                    else
                    {
                        Common.ShowInfo("文件不存在，无法复制!");
                    }
                }
                else
                {
                    Common.ShowInfo("无此项");
                }

            }
            else
            {
                Common.ShowInfo("未选中任何内容");
            }

        }

        static void menuItemHandler_Click(object CommandBarControl, ref bool Handled, ref bool CancelDefault)
        {

            if (Common.chDTE.SelectedItems.Count > 0)
            {
                string path = "";


                if ((Common.chDTE.SelectedItems.Item(1).Project) != null)
                {
                    path =  Common.chDTE.SelectedItems.Item(1).Project.FileName ;
                }
                if ((Common.chDTE.SelectedItems.Item(1).ProjectItem) != null)
                {
                    path =  Common.chDTE.SelectedItems.Item(1).ProjectItem.get_FileNames(1) ;
                }
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("Explorer" ,"/select, "+ path );
                p.Start();
            }

        }


        /// <summary> 
        /// 从菜单或工具条中删除指定的命令 
        /// </summary> 
        /// <param name="CmdName"></param> 
        /// <param name="SubItemName"></param> 
        /// <param name="Name"></param> 
        /// <param name="Caption"></param> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        public static Exception DeleteCommand(string CmdName, string SubItemName, string Name, string Caption)
        {
            //CmdName 工具条名称, SubItemName 工具条子项目名称,Name 要添加的项目名称, 
            //Caption 要添加的项目标题.此方法内用于删除该按钮/项 
            Exception e = null;
            Commands2 Cmds = (Commands2)chDTE.Commands;
            CommandBars CmdBars = (CommandBars)chDTE.CommandBars;
            CommandBar mnuBarCmdBar = CmdBars[CmdName];
            //菜单 
            CommandBarControl CmdCtrl = mnuBarCmdBar.Controls[SubItemName];
            CommandBarPopup CmdPopup = (CommandBarPopup)CmdCtrl;
            try
            {
                Cmds.Item("KeelKit.Commands." + Name, 0).Delete();

            }
            catch (Exception ex)
            {
                e = ex;
            }
            try
            {
                CommandBarControl chCmdConfig = CmdPopup.Controls[Caption];
                chCmdConfig.Delete(null);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            return e;
        }

        /// <summary> 
        /// 删除指定菜单或工具条中的命令. 
        /// </summary> 
        /// <param name="Owner">所有者</param> 
        /// <param name="Name">名称.</param> 
        /// <param name="Caption">标题</param> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        public static Exception DeleteCommand(CommandBarControl Owner, string Name, string Caption)
        {
            Exception e = null;
            try
            {
                //CmdName 工具条名称, SubItemName 工具条子项目名称,Name 要添加的项目名称, 
                //Caption 要添加的项目标题.此方法内用于删除该按钮/项 
               
                Commands2 Cmds = (Commands2)chDTE.Commands;
                CommandBars CmdBars = (CommandBars)chDTE.CommandBars;
                CommandBar mnuBarCmdBar = CmdBars["MenuBar"];
                //菜单 
                CommandBarControl CmdCtrl = Owner;
                CommandBarPopup CmdPopup = (CommandBarPopup)CmdCtrl;

                Cmds.Item("KeelKit.Connect." + Name, 0).Delete();

            }
            catch (Exception ex)
            {
                e = ex;
            }
            return e;
        }
        /// <summary> 
        /// 注册别名. 
        /// </summary> 
        /// <param name="cCmd">完整命令</param> 
        /// <param name="cAlias">别名</param> 
        /// <param name="bDelete">是删除还是注册.T.删除.</param> 
        /// <remarks></remarks> 
        public static void RegAlias(string cCmd, string cAlias, bool bDelete)
        {

            try
            {
                chDTE.ExecuteCommand("Tools.Alias ", cAlias + " " + (bDelete ? " /delete" : cCmd).ToString());

                ShowInfo((bDelete ? "删除" : "注册").ToString() + "别名'" + cAlias + "'成功!");
            }
            catch (Exception)
            {
                ShowInfo((bDelete ? "删除" : "注册").ToString() + "别名" + cAlias + "失败!");
            }

        }


        /// <summary> 
        /// 在输出窗口和状态条中显示文本 
        /// </summary> 
        /// <param name="Text">为要输出的文本内容</param> 
        /// <param name="cCrlf">决定是不是要换行,默认为换行</param> 
        /// <param name="bMustOut">决定该输出是不是必须输出的.</param> 
        /// <remarks>如果不是重要的信息, 用户的不显示详细信息设置将过滤该输出信息</remarks> 
        public static void ShowInfo(string Text,bool notime)
        {
            try
            {
                chOutWin.OutputString((notime ? "" : DateTime.Now.ToString("yyyyMMddHHmmss :")) + Text + System.Environment.NewLine);
                chDTE.StatusBar.Text = "KeelKit::" + Text;
            }
            catch (Exception)
            {

            }
        }
        public static void ShowInfo(string Text )
        {
            ShowInfo(Text, false );
        }
        /// <summary> 
        /// 这执行DTE中的命令. 
        /// </summary> 
        /// <param name="Cmd">命令名称.</param> 
        /// <param name="cParam">参数.</param> 
        /// <remarks>显示执行了何种命令..</remarks> 
        public static void chExcCmd(string Cmd, string cParam)
        {
            try
            {
                chDTE.ExecuteCommand(Cmd, cParam);
                ShowInfo("调用:" + Cmd + "(" + cParam + ")成功!");
            }
            catch (Exception ex)
            {
                ShowInfo("调用开发环境命令:" + Cmd + "(" + cParam + ") 时出错:" + ex.Message);
            }
        }
        /// <summary> 
        /// 内部调用DTE命令. 
        /// </summary> 
        /// <param name="cmd">命令名称.</param> 
        /// <param name="cparam">参数</param> 
        /// <remarks>内部调用.由本程序使用</remarks> 
        public static void chExc(string cmd, string cparam)
        {
            try
            {
                chDTE.ExecuteCommand(cmd, cparam);
            }
            catch (Exception)
            {

            }
        }
        /// <summary> 
        /// 如果执行了命令行,向命令行当前位置输出文本信息. 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <remarks></remarks> 
        public static void chOutRet(string Text)
        {
            try
            {
                chDTE.ToolWindows.CommandWindow.OutputString(Text + System.Environment.NewLine);
            }
            catch (Exception)
            {

            }
        }
        /// <summary> 
        /// 在命令行运行命令. 
        /// </summary> 
        /// <param name="cmd">命令</param> 
        /// <param name="Exc">是不是立刻执行.</param> 
        /// <remarks></remarks> 
        public static void chCmdExc(string cmd, bool Exc)
        {
            try
            {
                chDTE.ToolWindows.CommandWindow.SendInput(cmd, Exc);
            }
            catch (Exception)
            {

            }
        }



        /// <summary> 
        /// 获取一个工具条名称. 
        /// </summary> 
        /// <param name="Name">存在的工具条名称.</param> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        public static CommandBarControl GetMenuBar(string Name)
        {
            Commands2 Cmds = (Commands2)chDTE.Commands;
            CommandBars CmdBars = (CommandBars)chDTE.CommandBars;
            CommandBar mnu = CmdBars["MenuBar"];
            //菜单 
            try
            {
                CommandBarControl ctl = mnu.Controls.Add(10, Type.Missing, Type.Missing, 21, Type.Missing);
                //添加在工具菜单后面.工具菜单的INDEX为20 
                ctl.Caption = Name;
                ctl.Tag = Name;
                return ctl;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary> 
        /// 获取一个指定名称的菜单项或工具条项对象. 
        /// </summary> 
        /// <param name="Name">名称.</param> 
        /// <param name="AIID"> </param> 
        /// <param name="OwnerName"></param> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        public static CommandBarControl SetMenuItem(string Name, long AIID, string OwnerName)
        {
            Commands2 Cmds = (Commands2)chDTE.Commands;
            CommandBars CmdBars = (CommandBars)chDTE.CommandBars;
            CommandBar mnuBarCmdBar = CmdBars["MenuBar"];
            //菜单 
            CommandBarControl CmdCtrl = mnuBarCmdBar.Controls[GetDTEMenuName(OwnerName)];
            CommandBarPopup CmdPopup = (CommandBarPopup)CmdCtrl;
            CommandBarControl ret = default(CommandBarControl);

            // Cmds.AddCommandBar("fads", vsCommandBarType.vsCommandBarTypePopup) 

            if (AIID > 0)
            {

                ret = CmdPopup.Controls.Add(10, null, null, CmdPopup.CommandBar.FindControl(null, AIID, null, null, null).Index + 1, null);
            }
            else
            {
                ret = CmdPopup.Controls.Add(10, 1, null, null, null);
            }
            ret.Caption = Name;
            return ret;
        }
        private static object GetTabPicture(Bitmap img)
        {
     
            Color transparent = Color.FromArgb(0, 254, 0, 254);

            if (Common.chDTE .Version == "8.0")
            {
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                        if (img.GetPixel(x, y) == Color.FromArgb(192, 192, 192))
                            img.SetPixel(x, y, transparent);
            }
            else
                img.MakeTransparent(Color.FromArgb(192, 192, 192));

            stdole.IPicture ret = Support.ImageToIPicture(img) as stdole.IPicture;
            return ret;
        }
        public static void CreateToolWindow(ref Window win, ref  Control ctl, string guid, string classname, string caption)
        {
            if (win == null || win.Visible == false)
            {
                object programmableObject = null;
                string guidString = guid;//"";
                Windows2 windows2 = (Windows2)Common.chDTE.Windows;
                Assembly asm = Assembly.GetExecutingAssembly();
                win = windows2.CreateToolWindow2(Common.chAddIN, asm.Location,
                    classname,
                     caption, guidString, ref programmableObject);
                win.SetTabPicture(GetTabPicture(Properties.Resources.ToolWindowBmp));
                win.Visible = true;
                ctl = (Control)win.Object;                 
                
            }
        }
      static   EnvDTE80.Window2   frame = null; 
        public  static void SetVisible(Window win ,bool v)
        {
            try
            {
                if (chDTE.Version == "9.0")
                {
                    Windows2 windows2 = (Windows2)Common.chDTE.Windows;
                    Window w2 = Common.chDTE.Windows.Item(EnvDTE.Constants.vsWindowKindOutput).LinkedWindowFrame;
                    frame = (Window2)windows2.CreateLinkedWindowFrame(win, w2, vsLinkedWindowType.vsLinkedWindowTypeTabbed);
                    Common.chDTE.MainWindow.LinkedWindows.Add(frame);
                    frame.SetKind(EnvDTE.vsWindowType.vsWindowTypeToolWindow);
                    if (frame != null)
                    {
                        frame.Activate();
                    }
                }
                else if (chDTE.Version == "8.0")
                {
                    //frame =  (Window2)w2 ;
                }
                
            }
            catch (Exception)
            {


            }
            win.Visible = v;
            Control ctl = win.Object as Control;
            if (ctl != null)
            {
                ctl.Visible = true;
            }
           
        
        }
    }
}
