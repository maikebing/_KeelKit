using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InstallApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            WriteLog(Environment.CommandLine);

            try
            {
                string ag = "installkeelkit";
                if (args.Length >= 1)
                {
                    args[0].Replace("/", "");
                }
                DoCommands(ag);
                WriteLog(args[0]);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);

            }
        }

        private static void DoCommands(string arg)
        {
            WriteLog("参数:" + arg);
            switch (arg)
            {
                case "installkeelkit":
                default:
                    WriteLog("安装:" + arg);
                    InstallKeelKit();
                    break;
                case "uninstallkeelkit":
                    WriteLog("卸载:" + arg);
                    UninstallKeelKit();
                    break;
            }
        }

        public static void UninstallKeelKit()
        {
            string vs2005;
            string vs2008;
            string vs2010;
            CheckPath(out vs2005, out vs2008, out vs2010);

            if (System.IO.Directory.Exists(vs2005))
            {
                System.IO.File.Delete(vs2005 + "KeelKit.AddIn");
            }
            if (System.IO.Directory.Exists(vs2008))
            {
                System.IO.File.Delete(vs2008 + "KeelKit.AddIn");
            }
            if (System.IO.Directory.Exists(vs2010))
            {
                System.IO.File.Delete(vs2010 + "KeelKit.AddIn");
            }
        }

        public static void InstallKeelKit()
        {
            string str, vs2005, vs2008, vs2010;
            InitKeelKit(out str, out vs2005, out vs2008, out vs2010);
            if (System.IO.Directory.Exists(vs2005))
            {

                System.IO.File.WriteAllText(vs2005 + "Addins\\KeelKit.AddIn", str, System.Text.Encoding.Unicode);
            }
            if (System.IO.Directory.Exists(vs2008))
            {
                System.IO.File.WriteAllText(vs2008 + "Addins\\KeelKit.AddIn", str, System.Text.Encoding.Unicode);

            }
            if (System.IO.Directory.Exists(vs2010))
            {
                System.IO.File.WriteAllText(vs2010 + "Addins\\KeelKit.AddIn", str, System.Text.Encoding.Unicode);

            }
        }

        private static void InitKeelKit(out string str, out string vs2005, out string vs2008, out string vs2010)
        {
            string s = new System.IO.FileInfo(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath).DirectoryName;
            WriteLog("取得当前路径:" + s);
            str = System.IO.File.ReadAllText(s + "\\KeelKit.AddIn", System.Text.Encoding.Unicode);
            str = str.Replace("KeelKit.dll", s + "\\KeelKit.dll");
            WriteLog("正在准备插件目录");
            CheckPath(out vs2005, out vs2008, out vs2010);
            if (System.IO.Directory.Exists (vs2005 ))
            {
            WriteLog("正在创建vs2005的目录");
            System.IO.Directory.CreateDirectory(vs2005+"Addins");

            }
            if (System.IO.Directory.Exists(vs2008))
            {
                WriteLog("正在创建vs2008的目录");
                System.IO.Directory.CreateDirectory(vs2008 + "Addins");

            }
            if (System.IO.Directory.Exists(vs2010))
            {
                WriteLog("正在创建vs2010的目录");
                System.IO.Directory.CreateDirectory(vs2010 + "Addins");
            }

        }

        private static void CheckPath(out string vs2005, out string vs2008, out string vs2010)
        {
            vs2005 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2005\\";
            WriteLog(vs2005);
            vs2008 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2008\\";
            WriteLog(vs2008);
            vs2010 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2010\\";
            WriteLog(vs2010);
        }

        private static void WriteLog(string s)
        {
            System.IO.File.AppendAllText("c:\\keelkit.log", s + Environment.NewLine);
        }
    }
}
