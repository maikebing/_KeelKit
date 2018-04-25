using System;
using System.Data.Common;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using EnvDTE;
using KeelKit.Serialization;
using Microsoft.Data.ConnectionUI;
using VSLangProj;
using System.Collections.Generic;

namespace KeelKit.Core
 
{
    public enum cfLangType
    {
        CSharp, VBDotNet, IronPython, FSharp,CPP
    }
 

    public    class Kit
    {

        public static string GetKeelFileName(EnvDTE80.DTE2 dte)
        {
            if (dte == null) return null;
            if (dte.Solution.FileName == null || dte.Solution.FileName == "" || dte.Solution.FileName.Length == 0)
                return null;
            FileInfo fi = new FileInfo(dte.Solution.FileName);
            if (fi.Exists == false) return null;
            string ex = fi.FullName.Remove(fi.FullName.Length - 3) + "keel";
            return ex;
        }
        public static string GetSlnPath(EnvDTE80.DTE2 dte)
        {
            if (dte == null) return null;
            if (dte.Solution.FileName == null || dte.Solution.FileName == "" || dte.Solution.FileName.Length == 0)
                return null;
            FileInfo fi = new FileInfo(dte.Solution.FileName);
            return fi.DirectoryName; ;
        }
        private static string _slnname = null;
        private static KeelExt kex = null ;
        public static void WriteKeel(KeelExt value, string filename)
        {
            lock (KeelExtLock)
            {
                kex = value;
                XmlSerializer xs = new XmlSerializer(typeof(KeelExt));
                MemoryStream ms = new MemoryStream();
                xs.Serialize(ms, kex);
                System.IO.File.WriteAllBytes(filename, ms.ToArray());
            }
        }
        private  static string KeelExtLock = "KeelExtLock";
        public  static KeelExt ReadKeel(string file )
        {
            lock (KeelExtLock)
            {
                if (file != _slnname || kex != null)
                {

                    if (File.Exists(file))
                    {
                        try
                        {
                            XmlSerializer xs = new XmlSerializer(typeof(KeelExt));
                            XmlReader xr = XmlReader.Create(new MemoryStream(File.ReadAllBytes(file)));
                            if (xs.CanDeserialize(xr))
                            {
                                kex = xs.Deserialize(xr) as KeelExt;
                            }
                        }
                        catch (Exception)
                        {
                            kex = new KeelExt();
                        }
                    }
                    else
                    {
                        kex = new KeelExt();
                    }
                }
                else
                {
                    _slnname = file;

                }
              }
            return kex;
        }

        public static DataSource GetDataSourceByName(string name)
        {
            DataSource ds = null;
            switch (name)
            {
                case "MicrosoftAccess":
                    ds = DataSource.AccessDataSource;
                    break;
                case "OdbcDsn":
                    ds = DataSource.OdbcDataSource;
                    break;
                case "Oracle":
                    ds = DataSource.OracleDataSource;
                    break;
                default:
                case "MicrosoftSqlServer":
                    ds = DataSource.SqlDataSource;
                    break;
                case "MicrosoftSqlServerFile":
                    ds = DataSource.SqlFileDataSource;
                    break;

            }
            return ds;

        }

        public static DataProvider GetDataProviderByName(string name)
        {
            DataProvider dp = null;
            switch (name)
            {
              
                case "System.Data.SqlClient":
                    dp = DataProvider.SqlDataProvider;
                    break;
                case "System.Data.OracleClient":
                    dp = DataProvider.OracleDataProvider;
                    break;
                     default:
                case "System.Data.OleDb":
                    dp = DataProvider.OleDBDataProvider;
                    break;
                case "System.Data.Odbc":
                    dp = DataProvider.OdbcDataProvider;
                    break;

            }
            return dp;

        }
    
        public static DbProviderFactory GetProviderFactoryByName(string name)
        {
            DbProviderFactory dp = null;
            switch (name)
            {
                default:
                case "System.Data.SqlClient":
                    dp = System.Data.SqlClient.SqlClientFactory.Instance;
                    break;
                case "System.Data.OracleClient": 
                    dp = System.Data.OracleClient.OracleClientFactory.Instance;
                    break;
                case "System.Data.OleDb":
                    dp = System.Data.OleDb.OleDbFactory.Instance;
                    break;
                case "System.Data.Odbc":
                    dp = System.Data.Odbc.OdbcFactory.Instance;
                    break;

            }
            return dp;

        }
        
     

        public static string GetKeelKitPath()
        {
            return  typeof(KeelExt).Assembly.Location ;
        }
        public static string GetProjectConfigNamespec(cfLangType lt)
        {
            string i = "";
            switch (lt)
            {
                case cfLangType.CSharp:
                    i = ".Properties.Settings";
                    break;
                case cfLangType.VBDotNet:
                    i = ".My.MySettings";
                    break;
                case cfLangType.IronPython:
                    i = ".Properties.Settings";
                    break;
                case cfLangType.FSharp:
                    i = ".Properties.Settings";
                    break;
                default:
                    i = ".Properties.Settings";
                    break;
            }
            return i;
        }
        /// <summary>
        /// 根据项目全名的扩展名语言类型
        /// </summary>
        /// <param name="pjt">项目名称</param>
        /// <returns>返回项目类型</returns>
        public static cfLangType GetProjectLangType(EnvDTE.Project pjt)
        {
            cfLangType cl = cfLangType.CSharp;
            string ext = (new FileInfo(pjt.FullName)).Extension.ToLower();         
            switch (ext)
            {
                case "":
                    string s = null;
                    try
                    {
                        s = pjt.Properties.Item("CurrentWebsiteLanguage").Value.ToString();
                    }
                    catch (Exception) { }
                    switch (s)
                    {
                        case "Visual C#":
                            cl = cfLangType.CSharp;
                            break;
                        case "Visual Basic":
                            cl = cfLangType.VBDotNet;
                            break;
                        default:
                            break;
                    }
                    break;
                case ".vcproj":
                    cl = cfLangType.CPP;
                    break;
                case ".vbproj":
                    cl = cfLangType.VBDotNet;
                    break;
                case ".pyproj":
                    cl = cfLangType.IronPython;
                    break;
                case ".fsproj":
                    cl = cfLangType.FSharp;
                    break;
                case ".csproj":

                default:
                    cl = cfLangType.CSharp;
                    break;
            }
            return cl;
        }
        public static string GetProjectLaneExt(cfLangType lt)
        {
            string i = "";
            switch (lt)
            {
                case cfLangType.CSharp:
                    i = ".cs";
                    break;
                case cfLangType.VBDotNet:
                    i = ".vb";
                    break;
                case cfLangType.IronPython:
                    i = ".py";
                    break;
                case cfLangType.FSharp:
                    i = ".fs";
                    break;
                case cfLangType.CPP :
                    i = ".cpp;.h;.c";
                    break;
                default:
                    i = ".cs";
                    break;
            }
            return i;
        }
        public static string GetProjectLangStr(cfLangType lt)
        {
            string i = "";
            switch (lt)
            {
                case cfLangType.CSharp:
                    i = "CSharp";
                    break;
                case cfLangType.VBDotNet:
                    i = "VisualBasic";
                    break;
                case cfLangType.IronPython:
                    i = "IronPython";
                    break;
                case cfLangType.FSharp:
                    i = "FSharp";
                    break;
                default:
                    i = "CSharp";
                    break;
            }
            return i;
        }
        public static string GetRootNamespace(EnvDTE.Project pjt)
        {
            string ns = (string)pjt.Properties.Item("RootNamespace").Value;
            switch (Kit.GetProjectLangType(pjt))
            {
                case cfLangType.CSharp:
                    break;
                case cfLangType.VBDotNet:
                    break;
                case cfLangType.IronPython:
                    ns = ns.Replace('.', '_');
                    //Common.ShowInfo("命名空间已重命名(IronPython本身只支持根命名空间)!");
                    break;
                case cfLangType.FSharp:
                    break;
                default:
                    break;
            }
            return ns;
        }
        public static string GetProjectLangStr2(cfLangType lt)
        {
            string i = "";
            switch (lt)
            {
                case cfLangType.CSharp:
                    i = "C#";
                    break;
                case cfLangType.VBDotNet:
                    i = "VBNET";
                    break;
                case cfLangType.IronPython:
                    i = "Python";
                    break;
                case cfLangType.FSharp:
                    i = "F#";
                    break;
                default:
                    i = null;
                    break;
            }
            return i;
        }
        /// <summary>
        /// 根据项目中的文件名称获得项目项
        /// </summary>
        /// <param name="pjt">项目</param>
        /// <param name="name">项目项</param>
        /// <returns></returns>
        public static ProjectItem GetProjectItemByName(Project pjt, string name)
        {
            ProjectItem pi = null;
            for (int i = 1; i <= pjt.ProjectItems.Count; i++)
            {
                if (pjt.ProjectItems.Item(i).Name == name)
                {
                    pi = pjt.ProjectItems.Item(i);
                    break;
                }
            }
            return pi;
        }
        

        /// <summary>
        /// 普通pjt 装欢为 vspjt
        /// </summary>
        /// <param name="pjt"></param>
        /// <returns></returns>
        public static VSProject ProjectToVSProject(Project pjt)
        {
            VSProject p2 = null;
            if ((pjt.Kind == PrjKind.prjKindVBProject) |
               (pjt.Kind == PrjKind.prjKindCSharpProject) |
                (pjt.Kind == "{f2a71f9b-5d33-465a-a702-920d77279786}")) //F#
            {
                p2 = ((VSProject)(pjt.Object));
            }
            else if (pjt.Kind == "{57b76cf8-f148-40c5-be9b-5c5efb1aca14}")//IronPython
            {
               // p2 = ((VSProject)(pjt.Object));//new OAVSProject((Microsoft.VisualStudio.Package.ProjectNode)pjt.Object) as VSProject;
                //用于避免语言版本问题且减少引用。 
                System.Reflection.Assembly asm = pjt.Object.GetType().Assembly;
                System.Reflection.Assembly asmIronPythonProjectBase=null ;
                foreach (var item in asm.GetReferencedAssemblies ())
                {
                    if (item.Name == "IronPythonProjectBase")
                    {
                        asmIronPythonProjectBase = System.Reflection.Assembly.Load(item.FullName);
                        break;
                    }
                }
                try
                {
                    object o =  asmIronPythonProjectBase.CreateInstance("Microsoft.VisualStudio.Package.Automation.OAVSProject",true , System.Reflection.BindingFlags.CreateInstance , null ,new object[]{pjt.Object} ,null ,new object []{});
                    p2 = o as VSProject;
                
                }
                catch (Exception  )
                {
              
       
                }
            }

  
            return p2;
        }
        public static bool AddProjectRefToProject(Project pjt1, Project pjt2)
        {
            bool ok = false;
            if (pjt1 == null || pjt2 == null) return true;
            VSProject p2;
            p2 = ProjectToVSProject(pjt2);
            if (p2 != null)
            {
                if (p2.References.Find(pjt2.Name) == null)
                {
                    try
                    {
                        string s = new Uri(typeof(Keel.DB.Common).Assembly.CodeBase).LocalPath;
                        Reference r = p2.References.AddProject(pjt1);
                        ok = true;
                    }
                    catch (Exception)
                    {


                    }
                }
            }
            else if (pjt1.Kind == "{E24C65DC-7377-472b-9ABA-BC803B73C61A}")
            {
                VsWebSite.VSWebSite vsws = pjt1.Object as VsWebSite.VSWebSite;
                vsws.References.AddFromProject(pjt2);

            }
            return ok;
        }
        public static bool AddKeelRefToProject(Project pjt)
        {
            bool ok = false;
            VSProject p2;
            if (pjt == null) return true;
            string s = new Uri(typeof(Keel.DB.Common).Assembly.CodeBase).LocalPath;
            p2 = ProjectToVSProject(pjt);
            if (p2 != null)
            {
                if (p2.References.Find(typeof(Keel.IDatabase).Namespace) == null)
                {
                    try
                    {

                        Reference r = p2.References.Add(s);
                        ok = true;
                    }
                    catch (Exception)
                    {


                    }

                }

            }
            else if (pjt.Kind == "{E24C65DC-7377-472b-9ABA-BC803B73C61A}")
            {
                VsWebSite.VSWebSite vsws = pjt.Object as VsWebSite.VSWebSite;
                vsws.References.AddFromFile(s);

            }

            return ok;

        }
 
           
      
    }
}
