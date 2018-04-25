using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;
using EnvDTE;
using KeelKit.Core;
using KeelKit.Core.Serialization;
using KeelKit.Serialization;
 ///resetaddin KeelKit.Connect /ranu /rootsuffix Exp
 
namespace KeelKit
{

  
    public   class Kit:KeelKit.Core.Kit
    {
       static  LangCodeProvider _LangCodeProvider = null;
        public static LangCodeProvider GetDefaultCodeProviderRouter()
        {
            if (_LangCodeProvider == null)
            {
                     _LangCodeProvider = XMLRW<LangCodeProvider>.Read(Properties.Resources.CodeProviderRouter);
                
            }
            return _LangCodeProvider;
        }
        public static LangCodeProvider GetCodeProviderRouter()
        {
            LangCodeProvider result = null;
            if (Kit.SlnKeel != null && Kit.SlnKeel.CodeProviderRouter != null 
                && Kit.SlnKeel.CodeProviderRouter.CSharp !=null
                && Kit.SlnKeel.CodeProviderRouter.VBDotNet  != null
                && Kit.SlnKeel.CodeProviderRouter.FSharp  != null
                && Kit.SlnKeel.CodeProviderRouter.CPP  != null
                && Kit.SlnKeel.CodeProviderRouter.IronPython  != null
                )
            {
                result = Kit.SlnKeel.CodeProviderRouter;
            }
            else
            {
                result = GetDefaultCodeProviderRouter();
            }
            return _LangCodeProvider;
        }
        /// <summary>
        /// 设置或者取得当前解决方案的Keel配置信息
        /// </summary>
        public static KeelExt SlnKeel
        {
            get
            {
                return ReadKeel( GetKeelFileName() );
            }
            set
            {
                WriteKeel(value, GetKeelFileName());
            }
        }
 
       
        
        public static bool CheckDataBase()
        {
            bool i = false;
            try
            {
                Keel.DB.Common.NowDataBase = Keel.DB.Common.GetIDatabaseByNamespace(Kit.SlnKeel.ProviderName, Kit.SlnKeel.ConnectString);
                i = true;
            }
            catch (Exception)
            {
                throw new Keel.Exceptions.DataBaseNotConfigException();
            }
            return i;
        }
       
        public static EnvDTE.vsCommandStatus GetCommandStatusForModel()
        {
            EnvDTE.vsCommandStatus cs = EnvDTE.vsCommandStatus.vsCommandStatusUnsupported;
            for (int i = 1; i <= Common.chDTE.Solution.Projects.Count; i++)
            {
                if (Kit.SlnKeel !=null && Common.chDTE.Solution.Projects.Item(i).Name == Kit.SlnKeel.ModelProjectName)
                {
                    cs = EnvDTE.vsCommandStatus.vsCommandStatusSupported | EnvDTE.vsCommandStatus.vsCommandStatusEnabled  ;
                    break;
                }
            }
            return cs;
        }
        public static EnvDTE.vsCommandStatus GetCommandStatusForDAL()
        {
            EnvDTE.vsCommandStatus cs = EnvDTE.vsCommandStatus.vsCommandStatusUnsupported;
            for (int i = 1; i <= Common.chDTE.Solution.Projects.Count; i++)
            {
                if (Common.chDTE.Solution.Projects.Item(i).Name == Kit.SlnKeel.DALProjectName )
                {
                    cs = EnvDTE.vsCommandStatus.vsCommandStatusSupported | EnvDTE.vsCommandStatus.vsCommandStatusEnabled;
                    break;
                }
            }
            return cs;
        }
        public static EnvDTE.Project GetProjectModel()
        {
            return GetProjectByName(Kit.SlnKeel.ModelProjectName);
        }
        public static EnvDTE.Project GetProjectDAL()
        {
            return GetProjectByName(Kit.SlnKeel.DALProjectName );
        }
        public static EnvDTE.Project GetProjectComponent()
        {
            return GetProjectByName(Kit.SlnKeel.ComponentProjectName );
        }
        public static EnvDTE.Project GetProjectUI()
        {
            return GetProjectByName(Kit.SlnKeel.UIProjectName);
        }
        /// <summary>
        /// 取得Keel配置文件的文件名
        /// </summary>
        /// <returns></returns>
        public static string GetKeelFileName()
        {
            return GetKeelFileName(Common.chDTE);
        }
        public static string GetSlnPath()
        {
            return GetSlnPath(Common.chDTE);
        }
        public static EnvDTE.Project GetProjectByName(string name)
        {
            EnvDTE.Project pj = null;
            for (int i = 1; i <= Common.chDTE.Solution.Projects.Count; i++)
            {
                if (Common.chDTE.Solution.Projects.Item(i).Name == name)
                {
                    pj = Common.chDTE.Solution.Projects.Item(i);
                    break;
                }
            }
            return pj;
        }
        public static bool UpdateConnectionString( )
        {
            Project pjt = Kit.GetProjectByName(Kit.SlnKeel.UIProjectName);
            if (pjt == null)
            {
                Common.ShowInfo("您尚未设置UI主界面项目， 因此无法自动配置连接字符串到你的app.config 或者web.config中!");
                return true;
            }
            ProjectItem PI = null;
            for (int i = 1; i <= pjt.ProjectItems.Count ; i++)
            {
                ProjectItem pix = pjt.ProjectItems.Item(i);
                if (pix.Name.ToLower().Contains("app.config") || pix.Name.ToLower().Contains("web.config"))
                {
                    PI = pix;
                    break;
                }
            }
            if (PI == null)
            {
                Common.ShowInfo(string.Format("您设置的主UI项目{0}中未找到app.config 或者web.config,因此无法自动设置链接字符串配置", pjt.Name));
            }
            else
            {
                bool needUpdate = true;

                ConfigXmlDocument cxd = new System.Configuration.ConfigXmlDocument();

                cxd.Load(PI.get_FileNames(1));
                XmlNode xnx = cxd.SelectSingleNode("descendant::configuration/connectionStrings");
                string csss = GetProjectConfigNamespec(GetProjectLangType(GetProjectUI()));
      
                 string name ="";
                 if (pjt.Kind == "{E24C65DC-7377-472b-9ABA-BC803B73C61A}")
                 {


                     name = "Keel"+csss + ".ConnectionString";
                 }
                 else
                 {
                     name = ((string)pjt.Properties.Item("RootNamespace").Value) + csss + ".ConnectionString";
                 }
                if (xnx != null)
                {
                    
                    for (int i = 0; i < xnx.ChildNodes.Count; i++)
                    {
                        if (xnx.ChildNodes[i].Attributes["name"].Value.Contains(name))
                        {
                            if (xnx.ChildNodes[i].Attributes["providerName"].Value != Kit.SlnKeel.ProviderName) xnx.ChildNodes[i].Attributes["providerName"].Value = Kit.SlnKeel.ProviderName;
                            if (xnx.ChildNodes[i].Attributes["connectionString"].Value != Kit.SlnKeel.ConnectString) xnx.ChildNodes[i].Attributes["connectionString"].Value = Kit.SlnKeel.ConnectString;
                            cxd.Save(PI.get_FileNames(1));
                            needUpdate = false;
                            break;
                        }
                    }
                }
                if (needUpdate)
                {

                    XmlNode xn = cxd.CreateNode("element", "add", "");
                    XmlAttribute xzproviderName = cxd.CreateAttribute("providerName");
                    xzproviderName.Value = Kit.SlnKeel.ProviderName;
                    XmlAttribute xaconnectionString = cxd.CreateAttribute("connectionString");
                    xaconnectionString.Value = Kit.SlnKeel.ConnectString;
                    XmlAttribute xaname = cxd.CreateAttribute("name");
                    xaname.Value = name;
                    xn.Attributes.Append(xaname);
                    xn.Attributes.Append(xaconnectionString);
                    xn.Attributes.Append(xzproviderName);
                    if (xnx == null)
                    {
                        XmlNode xnx1 = cxd.SelectSingleNode("descendant::configuration");
                        xnx = cxd.CreateElement("connectionStrings");
                        xnx1.AppendChild(xnx);
                    }
                    xnx.AppendChild(xn);
                    // cxd.SelectSingleNode("descendant::configuration/connectionStrings").InnerXml = xnx.InnerXml;
                    cxd.Save(PI.get_FileNames(1));
                    //;// = cxd.SelectSingleNode("descendant::configuration/connectionStrings/add[@name='" + appnamespace + ".Properties.Settings.ConnectionString']");
                    //if (xnl.Attributes["providerName"] != null && xnl.Attributes["connectionString"] != null)
                    //{

                    //}
                }
                Common.ShowInfo(string.Format("您设置的主UI项目{0}中到app.config 或者web.config,已经设置了链接字符串{1}", pjt.Name,name ));
            }
            return true;
        }

        public  static  string SearchFile(string filename)
        {
            string result = null;
            List<string> ls = new List<string>();
            ls.Add("");

            try
            {
                ls.AddRange(KeelKit.Properties.Settings.Default.Path.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                ls.Add( new FileInfo(  typeof(KeelExt).Assembly.Location).DirectoryName );
                ls.Add(Kit.GetSlnPath());

            } catch (Exception){}
            foreach (var item in ls)
            {
                if (item != null && item.Trim() != "")
                {

                    FileInfo fi = new FileInfo(Path.Combine( item , filename));
                    if (fi.Exists)
                    {
                        result = fi.FullName;
                        break;
                    }


                }
                else
                {
                    FileInfo fi = new FileInfo(filename);
                    if (fi.Exists)
                    {
                        result = fi.FullName;
                        break;
                    }
                }

            }
            return result;
           
           
         
        }
    }
}
