using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EnvDTE;
using EnvDTE80;
using Keel;
using KeelKit.Core;

namespace KeelKit.Generators
{
    public class WebFormBaseGengerator
    {

        ProjectItem pi = null;

        List<SQLTableInfo> stl;
        Project pjt = null;
        AscxDom ctlDom = null;
        protected CodeCompileUnit ccu = new CodeCompileUnit();
        protected System.CodeDom.CodeNamespace cns = null;
        protected CodeTypeDeclaration ctd = null;
        public WebFormBaseGengerator(Project pjt1, string ctlname, List<SQLTableInfo> stltmp)
        {
            pjt = pjt1;
            stl = stltmp;
            Common.ShowInfo("正在准备控件" + ctlname);
            Solution2 slu = (Solution2)Common.chDTE.Solution;
            string itmname = ctlname + ".ascx";// Kit.GetProjectLaneExt(Kit.GetProjectLangType(pjt));
            if (itmname == null) throw new Exception("错误002 不支持此项目类型");

            pi = Kit.GetProjectItemByName(pjt, itmname);
            if (pi != null) pi.Delete();
            VsWebSite.VSWebSite ws = pjt.Object as VsWebSite.VSWebSite;
            try
            {
                DeleteFile(itmname);
                if (ws != null)
                {
                    pi = ws.AddFromTemplate("", "WebUserControl.vstemplate", Kit.GetProjectLangStr2(Kit.GetProjectLangType(pjt)), itmname, true, "", "");
                }
                else
                {
                    if (IsWebApplication())
                    {
                        //WAProjectExtender wpe = pjt.get_Extender("WebApplication") as WAProjectExtender;
                        string pit = slu.GetProjectItemTemplate("WebUserControl.zip", Kit.GetProjectLangStr(Kit.GetProjectLangType(pjt)) + "\\Web");
                        if (pit == null) throw new Exception("错误003 未能得到对应项目模板,请确认此语言项目是否正确安装!");
                        pi = pjt.ProjectItems.AddFromTemplate(pit, itmname);
                    }
                }
                // pi = pjt.ProjectItems.AddFromTemplate(pit, itmname+".cs");
                //pi = pjt.ProjectItems.AddFromTemplate(pit, itmname);

            }
            catch (Exception)
            {
                pi = null;
            }
            if (pi == null)
            {
                pi = Kit.GetProjectItemByName(pjt, itmname);
            }
            if (pi == null)
            {
                return;
            }
            XmlSerializer xs = new XmlSerializer(typeof(AscxDom));
            XmlReader xr = XmlReader.Create(new MemoryStream(Properties.Resources.WebUserControl));
            if (xs.CanDeserialize(xr))
            {
                ctlDom = xs.Deserialize(xr) as AscxDom;
            }
            if (IsWebApplication())
            {
                cns = new System.CodeDom.CodeNamespace(Kit.GetRootNamespace(pjt));
                cns.Comments.Add(new CodeCommentStatement("生成日期:" + DateTime.Now.ToString("yyyyMMddHHmmss")));
                cns.Comments.Add(new CodeCommentStatement("KeelKit版本:" +System.Reflection.Assembly.GetExecutingAssembly().GetName ().Version.ToString()   ));
                ccu.Namespaces.Add(cns);
                ctd = new CodeTypeDeclaration(ctlname);
                ctd.IsPartial = true;
                ctd.IsClass = true;
                cns.Types.Add(ctd);
            }

        }

        private bool IsWebApplication()
        {
            return IsWebApplication(pjt);
        }
        public static  bool IsWebApplication(Project pjt)
        {
            if (pjt != null)
            {
                return (pjt.ExtenderNames as object[]).Length > 0 && (pjt.ExtenderNames as object[])[0].ToString() == "WebApplication";
            }
            else
            {
                return false;
            }
        }

        public static void CreateDom()
        {
            AscxDom ctlDom = new AscxDom();
            ctlDom.Header = "<table style=\"width:100%;\">";
            ctlDom.Mapping_Boolean = "<tr><td colspan=\"2\"><asp:CheckBox ID=\"_name_\" runat=\"server\" Checked=\"_defaultvalue_\" Text=\"_desc_\"  style=\"width:100%;\"/></td></tr>";
            ctlDom.Mapping_DateTime = "<tr><td align=\"right\">_desc_</td><td><asp:TextBox ID=\"_name_\" runat=\"server\" MaxLength=\"_lenght_\">_defaultvalue_</asp:TextBox></td></tr>";
            ctlDom.Mapping_Decimal = ctlDom.Mapping_DateTime;
            ctlDom.Mapping_String = ctlDom.Mapping_DateTime;
            ctlDom.Mapping_Unknow = ctlDom.Mapping_DateTime;
            ctlDom.Footer = "</table>";
            XmlSerializer xs = new XmlSerializer(typeof(AscxDom));
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, ctlDom);
            System.IO.File.WriteAllBytes("c:\\WebUserControl.KeelTemplate", ms.ToArray());

        }

        public void DeleteFile(string itmname)
        {
            string ff = new System.IO.FileInfo(pjt.FileName).Directory.FullName;
            if (System.IO.File.Exists(ff + "\\" + itmname))
            {
                if (System.IO.File.GetAttributes(ff + "\\" + itmname) == System.IO.FileAttributes.Normal)
                    System.IO.File.SetAttributes(ff + "\\" + itmname, System.IO.FileAttributes.Normal);
                System.IO.File.Delete(ff + "\\" + itmname);
            }

            if (System.IO.File.Exists(ff + "\\" + itmname.Replace(".", ".Designer.")))
            {
                if (System.IO.File.GetAttributes(ff + "\\" + itmname.Replace(".", ".Designer.")) == System.IO.FileAttributes.Normal)
                    System.IO.File.SetAttributes(ff + "\\" + itmname.Replace(".", ".Designer."), System.IO.FileAttributes.Normal);
                System.IO.File.Delete(ff + "\\" + itmname.Replace(".", ".Designer."));
            }

        }

        public bool GenWebForm()
        {
            if (pi == null || stl == null) return false;
            foreach (var item in stl)
            {
                try
                {
                    string _name_ = ctlDom.AddMapping(item);
                    if (IsWebApplication())
                    {
                        Type t = Keel.DB.Common.NowDataBase.PasteType(item.t_fieldtype);
                        Type mapt = GetMapingType(t);
                        CodeMemberField cvds = new CodeMemberField(mapt, _name_);
                        cvds.Attributes = MemberAttributes.Assembly | MemberAttributes.FamilyAndAssembly | MemberAttributes.Family  ;
                        cvds.Comments.Add(new CodeCommentStatement("<summary>", true));
                        cvds.Comments.Add(new CodeCommentStatement(string.Format("{0} 控件。", _name_), true));
                        cvds.Comments.Add(new CodeCommentStatement("</summary>", true));
                        cvds.Comments.Add(new CodeCommentStatement("<remarks>", true));
                        cvds.Comments.Add(new CodeCommentStatement("自动生成的字段。", true));
                        cvds.Comments.Add(new CodeCommentStatement("若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。", true));
                        cvds.Comments.Add(new CodeCommentStatement("</remarks>", true));
                        
                        ctd.Members.Add(cvds);
                    }
                }
                catch (Exception ex)
                {

                    Common.ShowInfo(string.Format("生成控件{0}时发生异常:{1}", item, ex.Message));
                }
            }
            string context = ctlDom.GenerateCodeFromAscxDom();
            System.IO.File.AppendAllText(pi.get_FileNames(1), context, Encoding.UTF8);
            if (IsWebApplication())
            {
                Save(pi.get_FileNames(1), Kit.GetProjectLangType(pjt), new BaseGengerator.DGetFileNames(GetFileNames));
            }
            return true;
        }
        string GetFileNames(string path, string  FileExtension)
        {
            return path + ".Designer." + FileExtension;
        }

        public string Save(string path, cfLangType clt, KeelKit.Generators.BaseGengerator.DGetFileNames getfilename)
        {
            string result = null;
            CodeDomProvider provider = BaseGengerator.GetProvider(clt);
            if (provider != null)
            {
                string filename = getfilename(path, provider.FileExtension);
                IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(filename, false, Encoding.UTF8), "    ");
                provider.GenerateCodeFromCompileUnit(ccu, tw, new CodeGeneratorOptions());
                tw.Close();
                result = filename;
            }
            return  result ;
        }
        private static Type GetMapingType(Type t)
        {
            Type mapt = null;
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Boolean:
                    mapt = typeof(System.Web.UI.WebControls.CheckBox);

                    break;
                case TypeCode.DBNull:
                    break;
                case TypeCode.DateTime:
                    mapt = typeof(System.Web.UI.WebControls.TextBox);
                    break;
                case TypeCode.Empty:
                    break;
                case TypeCode.Char:
                case TypeCode.String:
                    mapt = typeof(System.Web.UI.WebControls.TextBox);
                    break;
                case TypeCode.Decimal:
                case TypeCode.Byte:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    mapt = typeof(System.Web.UI.WebControls.TextBox);
                    break;
                case TypeCode.Object:
                default:
                    mapt = typeof(System.Web.UI.WebControls.TextBox);
                    break;
            }
            return mapt;
        }



        private static string tablenamenow = null;
        private static bool FindByTableName(SQLTableInfo di)
        {

            return di.t_tablename == tablenamenow.Trim();
        }
        public static void GeneratedCode()
        {
            Common.ShowInfo("正在检查数据库是否可用!");
            if (Kit.CheckDataBase())
            {
                Common.ShowInfo("正在从数据库中读取表信息...");
                EnvDTE.Project pjt = Kit.GetProjectComponent();
                DBHelper<SQLTableInfo> dbi = new DBHelper<SQLTableInfo>();
                List<SQLTableInfo> dbix = dbi.GetDataViewForObjectList();
                string[] lsttab = Kit.SlnKeel.DataTableForms.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in lsttab)
                {
                    tablenamenow = item;
                    Common.ShowInfo(string.Format("正在生成{0}的控件,请稍候...", tablenamenow));
                    Predicate<SQLTableInfo> pdbi = new Predicate<SQLTableInfo>(FindByTableName);
                    List<SQLTableInfo> lstdb = dbix.FindAll(pdbi);
                    WebFormBaseGengerator mg;
                    try
                    {
                        mg = new WebFormBaseGengerator(pjt, "ctl_" + item + "_Keel", lstdb);
                        bool genok = mg.GenWebForm();
                        if (genok)
                        {
                            Common.ShowInfo(string.Format("{0}成功生成,正在保存...", tablenamenow));
                        }
                        else
                        {
                            Common.ShowInfo(string.Format("抱歉!{0}的控件生成失败!", tablenamenow));
                            continue;
                        }


                    }
                    catch (Exception ex)
                    {

                        Common.ShowInfo(string.Format("抱歉!{0}的控件生成失败!由于发生了异常:{1}", tablenamenow, ex.Message));
                    }



                }
                Common.chExc("SaveAll", "");
                Common.ShowInfo(string.Format("全部控件生成完毕!"));
            }
        }

    }
}
