using System;
using System.Reflection;
using EnvDTE;
using EnvDTE80;
using Extensibility;
 

namespace KeelKit
{
    /// <summary>用于实现外接程序的对象。</summary>
    /// <seealso class='IDTExtensibility2' />
    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
 
        ext_ConnectMode cmWhen;
        /// <summary>实现外接程序对象的构造函数。请将您的初始化代码置于此方法内。</summary>
        public Connect()
        {
         
            //KeelKit.Generators.WebFormBaseGengerator.CreateDom();
        }

        /// <summary>实现 IDTExtensibility2 接口的 OnConnection 方法。接收正在加载外接程序的通知。</summary>
        /// <param term='application'>宿主应用程序的根对象。</param>
        /// <param term='connectMode'>描述外接程序的加载方式。</param>
        /// <param term='addInInst'>表示此外接程序的对象。</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            try
            {
                if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
                {
                    if (Common.Win7Taskbar == null) Common.Win7Taskbar = new Win7Taskbar();
                    if (Common.Win7Taskbar != null)
                    {
                        Common.Win7Taskbar.InitThis(application, connectMode, addInInst, ref custom);
                    }
                }
            }
            catch (Exception)
            {


            }
            Common.chDTE = (DTE2)application;
            Common.chAddIN = (AddIn)addInInst;
            if (connectMode != ext_ConnectMode.ext_cm_UISetup)
            {
                try
                {
                    LoadMe();
                }
                catch (Exception ex)
                {

                    Common.ShowInfo("加载KeelKit时遇到问题:" + ex.Message + System.Environment.NewLine + ex.StackTrace);
                }
            }
            else
            {
                cmWhen = connectMode;
            }
        }
        private static bool isLoad = false;
        public  static void LoadMe()
        {
            LoadMe(false);
        }
        public  static void LoadMe(bool ispack)
        {
            if (isLoad)
            {
                return;
            }
            try
            {
                Common.chOutWin = Common.chDTE.ToolWindows.OutputWindow.OutputWindowPanes.Item("KeelKit");
            }
            catch (Exception)
            {
                Common.chOutWin = Common.chDTE.ToolWindows.OutputWindow.OutputWindowPanes.Add("KeelKit");
            }
            Common.ShowInfo("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@", true);
            Common.ShowInfo("@@@           KeelKit 2012                     @@@", true);
            Common.ShowInfo("@@@      http://www.mysticboy.cn               @@@", true);
            Common.ShowInfo("@@@          100860505@qq.com                  @@@", true);
            Common.ShowInfo("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@", true);
            Common.ShowInfo("", true);

            if (ispack == false)
            {
                Common.chMenu = Common.GetMenuBar("KeelKit");
            }
            else
            {
                Commands2 Cmds = (Commands2)Common.chDTE .Commands;
                Microsoft.VisualStudio.CommandBars.CommandBars CmdBars = (Microsoft.VisualStudio.CommandBars.CommandBars)Common.chDTE.CommandBars;
                Microsoft.VisualStudio.CommandBars.CommandBarControl mnu = CmdBars["MenuBar"].Controls["KeelKit"];
                Common.chMenu = mnu;
            
            }
            Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            Type[] ts = asm.GetTypes();
            foreach (Type var in ts)
            {
                if (var.FullName.StartsWith("KeelKit.Commands"))
                {

                    ICommand i = (ICommand)Assembly.GetExecutingAssembly().CreateInstance(var.FullName);
                    Common.asmCommands.Add(i);
                    i = null;
                }
            }
            Common.asmCommands.Sort(new Comparison<ICommand>(ComparisonCmd));
            foreach (var item in Common.asmCommands)
            {
                Exception ex = Common.AddCommand(Common.chMenu, item.GetType().Name, item.Title, item.IcoID);
                if (ex != null)
                {
                    Common.ShowInfo("加载菜单时出现异常:" + ex.Message);
                }
            }
            Common.AddOpenFloderFoVS();
            Common.AddCopyToHtmlForVS();
            HandEvents.HandAllEvents();
            isLoad = true;
            Common.ShowInfo("就绪");
        }
      

        /// <summary>
        /// 排序，按照 postion 的倒序排
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int ComparisonCmd(ICommand x, ICommand y)
        {
            return y.Positon - x.Positon;
        }

        /// <summary>实现 IDTExtensibility2 接口的 OnDisconnection 方法。接收正在卸载外接程序的通知。</summary>
        /// <param term='disconnectMode'>描述外接程序的卸载方式。</param>
        /// <param term='custom'>特定于宿主应用程序的参数数组。</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
            {
                Common.Win7Taskbar.UnloadThis(disconnectMode, ref custom);
            }
            if (disconnectMode == ext_DisconnectMode.ext_dm_HostShutdown || disconnectMode == ext_DisconnectMode.ext_dm_UserClosed)
            {
                try
                {
                    UnLoadMe();
                }
                catch (Exception ex)
                {
                    Common.ShowInfo("卸载KeelKit时遇到问题:" + ex.Message + System.Environment.NewLine + ex.StackTrace);

                }
            }
        }

        private static void UnLoadMe()
        {
            if (isLoad == false)
            {
                return;
            }
            isLoad = false;
            HandEvents.RemoveHandAllEvents();
            foreach (var item in Common.asmCommands)
            {
                Exception ex = Common.DeleteCommand(Common.chMenu, item.GetType().Name, item.Title);
            }

            try
            {
                Common.chMenu.Delete(null);
            }
            catch (Exception)
            {


            }
            try
            {
                Common.DelOpenFloderForVS();
            }
            catch (Exception)
            {


            }


            try
            {
                Common.chAddIN.Remove();

            }
            catch (Exception)
            {


            }


        }

        /// <summary>实现 IDTExtensibility2 接口的 OnAddInsUpdate 方法。当外接程序集合已发生更改时接收通知。</summary>
        /// <param term='custom'>特定于宿主应用程序的参数数组。</param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom)
        {
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
            {
                Common.Win7Taskbar.OnAddInsUpdate(ref custom);
            }
            //    UnLoadMe();
            //    LoadMe();
        }

        /// <summary>实现 IDTExtensibility2 接口的 OnStartupComplete 方法。接收宿主应用程序已完成加载的通知。</summary>
        /// <param term='custom'>特定于宿主应用程序的参数数组。</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {
         
        }

        /// <summary>实现 IDTExtensibility2 接口的 OnBeginShutdown 方法。接收正在卸载宿主应用程序的通知。</summary>
        /// <param term='custom'>特定于宿主应用程序的参数数组。</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
            {
                Common.Win7Taskbar.OnBeginShutdown(ref custom);
            }
        }

        /// <summary>实现 IDTCommandTarget 接口的 QueryStatus 方法。此方法在更新该命令的可用性时调用</summary>
        /// <param term='commandName'>要确定其状态的命令的名称。</param>
        /// <param term='neededText'>该命令所需的文本。</param>
        /// <param term='status'>该命令在用户界面中的状态。</param>
        /// <param term='commandText'>neededText 参数所要求的文本。</param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
           
            if (Common.GetCommands().Contains(commandName.Replace("KeelKit.Connect.", "")))
            {

                try
                {
                    ICommand i = FindCommand(commandName.Replace("KeelKit.Connect.", ""));
                    if (i != null)
                    {
                        status = i.GetCommandStatus();
                    }
                }
                catch (Exception ex)
                {

                    Common.ShowInfo(ex.Message);
                }
               
            }
            else
            {
                status = vsCommandStatus.vsCommandStatusUnsupported;
            }

        }
        private string _cmdname = null;
        public bool FindByName(ICommand md)
        {
            bool i = md.GetType().Name == _cmdname;
            return i;
        }
        public ICommand FindCommand(string commandName)
        {
            _cmdname = commandName;
            return Common.asmCommands.Find(new Predicate<ICommand>(FindByName));
        }

        /// <summary>实现 IDTCommandTarget 接口的 Exec 方法。此方法在调用该命令时调用。</summary>
        /// <param term='commandName'>要执行的命令的名称。</param>
        /// <param term='executeOption'>描述该命令应如何运行。</param>
        /// <param term='varIn'>从调用方传递到命令处理程序的参数。</param>
        /// <param term='varOut'>从命令处理程序传递到调用方的参数。</param>
        /// <param term='handled'>通知调用方此命令是否已被处理。</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            handled = false;
            if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            {
                try
                {
                    ICommand i = FindCommand(commandName.Replace("KeelKit.Connect.", ""));
                    if (i != null)
                    {
                        i.DoCommand(Common.chDTE);
                        handled = true;
                    }
                }
                catch (Exception ex)
                {

                    Common.ShowInfo(ex.Message);
                }
                return;
            }
        }

    }
}