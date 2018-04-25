using System;
using System.Text;
using EnvDTE;
using KeelKit.Serialization;

namespace KeelKit.AutoVersion
{
    public class AsmVerControl
    {
        public static void CheckAndChangeAsmVer()
        {
           AutoVersionSetting avs = Kit.SlnKeel.AutoVersion;
           if (avs != null)
           {
               if (avs.Enable == false) return;
               switch (avs.Kind)
               {

                   case VersionKind.KVT:
                       KTV(ref avs);
                       break;
                   case VersionKind.Default:
                   default:
                       AutoChangeAsmVer(ref avs);
                       break;
               }
               Kit.SlnKeel.AutoVersion = avs;
           }
        }

        private static void KTV(ref AutoVersionSetting avs)
        {
            Common.ShowInfo("正在搜集解决方案KVT模板信息....");
            string[] files = System.IO.Directory.GetFiles(Kit.GetSlnPath(), "*.kvt", avs.searchOption);
            if (files.Length > 0)
            {
                Project pjt = Kit.GetProjectByName(avs.ProjectBase);
                string ext = Kit.GetProjectLaneExt(Kit.GetProjectLangType(pjt));
                foreach (var filename in files)
                {
                    Common.ShowInfo("正在处理文件" + filename);
                    try
                    {
                        avs = WriteKVT(avs, pjt, ext, filename);
                    }
                    catch (Exception ex)
                    {
                        Common.ShowInfo(string.Format ("处理文件{0}时遇到异常{1}", filename,ex.Message ));
                    }
                }
            }
            Common.ShowInfo("KVT任务完成.");
        }

        private static AutoVersionSetting WriteKVT(AutoVersionSetting avs, Project pjt, string ext, string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                BuildAsmVerString(ref avs, pjt);
                string context = System.IO.File.ReadAllText(filename, Encoding.UTF8);
                context = context.Replace("-INSERTMAJOR-", avs.major);
                context = context.Replace("-INSERTMINOR-", avs.minor);
                context = context.Replace("-INSERTBUILD-", avs.build);
                context = context.Replace("-INSERTREVISION-", avs.revision);
                System.IO.FileInfo fi = new System.IO.FileInfo(filename);
                string exfilename = fi.DirectoryName + "\\" + fi.Name.Remove(fi.Name.Length - fi.Extension.Length) + ext;
                bool w = true;
                if (System.IO.File.Exists(exfilename) && context == System.IO.File.ReadAllText(exfilename, Encoding.UTF8))
                {
                    w = false;
                }
                if (w)
                {
                    System.IO.File.WriteAllText(exfilename, context, Encoding.UTF8);
                }
            }
            return avs;
        }

        private static void AutoChangeAsmVer(ref AutoVersionSetting avs)
        {
            Common.ShowInfo("正在执行版本号自动控制....");
            string futurever = avs.OneVersion ? BuildAsmVerString(ref avs, null) : "";
            EnvDTE.BuildDependencies bd = Common.chDTE.Solution.SolutionBuild.BuildDependencies;
            for (int i = 1; i <= bd.Count; i++)
            {
                EnvDTE.BuildDependency bb = bd.Item(i);
                string AssemblyVersion = bb.Project.Properties.Item("AssemblyVersion").Value as string;
                if (avs.OneVersion == false) futurever = BuildAsmVerString(ref avs, bb.Project);//重新针对此文件生成asm,主要针对svn 
                if (AssemblyVersion != futurever)
                {

                    try
                    {
                        bb.Project.Properties.Item("AssemblyVersion").Value = futurever;
                        if (avs.RndBuildRev == false) bb.Project.Properties.Item("AssemblyFileVersion").Value = futurever;
                    }
                    catch (Exception ex)
                    {
                        Common.ShowInfo(string.Format ("处理项目{0}的版本时遇到问题{1}",bb.Project.Name ,ex.Message ));
                    }
                }
            }
            Common.ShowInfo("版本号自动控制任务已完成");
        }

        private static string BuildAsmVerString( ref AutoVersionSetting avs, EnvDTE.Project pjt)
        {
 
            if (avs.OneVersion == false)
            {
                string a  =   pjt.Properties.Item("AssemblyVersion").Value.ToString ();
                string[] sx = a.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (sx.Length >= 1 && (avs.major == null || avs.major.Trim ()=="")) avs.major = sx[0];
                if (sx.Length >= 2 && (avs.minor == null || avs.minor.Trim() == "")) avs.minor = sx[1];
                if (sx.Length >= 3) avs.build  = sx[2];
                if (sx.Length >= 4) avs.revision  = sx[3];
            }
            if (avs.RndBuildRev == false)
            {
                switch (avs.buildVerType)
                {

                    case VersionType.Counter:
                        int rev = 0;
                        int.TryParse(avs.build, out  rev);
                        rev++;
                        avs.build = rev.ToString();
                        break;
                    case VersionType.SCV:
                        break;
                    case VersionType.NoControl:
                        break;
                    default:
                        break;
                }
                switch (avs.revisionVerType)
                {

                    case  VersionType.Counter:
                        int rev = 0;
                        int.TryParse(avs.revision, out  rev);
                        rev++;
                        avs.revision = rev.ToString();
                        break;
                    case  VersionType.SCV:
                        if (pjt != null && avs.OneVersion == false && pjt.FileName != null && System.IO.File.Exists(pjt.FileName))
                        {
                            avs.revision = GetSCV(new System.IO.FileInfo(pjt.FileName).DirectoryName);
                        }
                        else if (avs.OneVersion && Common.chDTE.Solution.FileName != null && System.IO.File.Exists(Common.chDTE.Solution.FileName))
                        {
                            avs.revision = GetSCV(new System.IO.FileInfo(Common.chDTE.Solution.FileName).DirectoryName);
                        }

                        break;
                    case  VersionType.NoControl:
                        break;
                    default:
                        break;
                }

                if (avs.build == null || avs.build.Trim() == "") avs.build = "0";
                if (avs.revision == null || avs.revision.Trim() == "") avs.build = "*";//build 和 revision 只能是一个 *,而不是 *.*
            }
            else//vs.RndBuildRev==true //随机build和rev的版本
            {
                avs.build = "*";
            }
            if (avs.major == null || avs.major.Trim() == "") avs.major = "0";
            if (avs.minor == null || avs.minor.Trim() == "") avs.minor = "0";
            string futurever = avs.build.Contains("*") ? string.Format("{0}.{1}.{2}", avs.major, avs.minor, avs.build) : string.Format("{0}.{1}.{2}.{3}", avs.major, avs.minor, avs.build, avs.revision);

            return futurever;
        }
        public static string GetSCV(string path)
        {


            string result = "0";
            string filename = "KeelKit.SCV.SVN.dll";

            string tmp = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\" + Properties.Settings.Default.SCVAsm;
              string tmp1 = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\" + filename ;
            if (Properties.Settings.Default.SCVAsm != null && System.IO.File.Exists(tmp))
            {
                filename = tmp ;
            }
            else if (Properties.Settings.Default.SCVAsm != null && System.IO.File.Exists(tmp1))
            {
                filename = tmp1;
            }
            object av=null ;
       
            try
            {
                
                Type t = System.Reflection.Assembly.LoadFile(filename).GetType("KeelKit.SCV.AutoVersion", false);
                if (t != null)
                {
                    av = t.InvokeMember("GetVersion", System.Reflection.BindingFlags.InvokeMethod, null, t, new object[] { path });
                }
            }
            catch (Exception)
            {
                
             av=null ;    
            } 
            if (av != null)
            {
                int i = 0;
                int.TryParse(av as string, out i);
                result = i.ToString();
            }
            else
            {
                result = GetSvnSCV(path);
            }
            return result;

        }

        private static string GetSvnSCV(string path)
        {
            string result = "0";
            string filename = path + "\\.svn\\entries";
            if (System.IO.File.Exists(filename) == false)
            {
                filename = path + "\\_svn\\entries";
            }
            if (System.IO.File.Exists(filename))
            {
                string txt = System.IO.File.ReadAllText(filename);
                string[] ary = txt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int v = 0;
                int.TryParse(ary[2], out v);
                result = v.ToString().Trim();
            }
            return result;
        }
    }
}
