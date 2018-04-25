using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Keel;
namespace KeelKit.Generators
{
    public class WinFormBaseGengerator
    {
        ProjectItem pi = null;
        IDesignerHost host = null;
        IContainer ic = null;
        List<SQLTableInfo> stl;
        Project pjt = null;
        public WinFormBaseGengerator(Project pjt1, string ctlname, List<SQLTableInfo> stltmp)
        {
            pjt = pjt1;
            stl = stltmp;
            Common.ShowInfo("正在准备控件" + ctlname);
            Solution2 slu = (Solution2)Common.chDTE.Solution;
            string itmname = ctlname + Kit.GetProjectLaneExt(Kit.GetProjectLangType(pjt));
            if (itmname == null) throw new Exception("错误002 不支持此项目类型");
            string pit = "";
            if (Kit.GetProjectLangType(pjt) == KeelKit.Core.cfLangType.CPP)
            {

            }
            else
            {
                pit = slu.GetProjectItemTemplate("UserControl.zip", Kit.GetProjectLangStr(Kit.GetProjectLangType(pjt)));
            }
            //string aaa = slu.get_TemplatePath(Kit.GetProjectLangStr(Kit.GetProjectLangType(pjt)));
            if (pit == null) throw new Exception("错误003 未能得到对应项目模板,请确认此语言项目是否正确安装!");
            pi = Kit.GetProjectItemByName(pjt, itmname);
            if (pi != null) pi.Delete();
            try
            {
                DeleteFile(itmname);
                pi = pjt.ProjectItems.AddFromTemplate(pit, itmname);
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
            Window itemDesigner = pi.Open(Constants.vsViewKindDesigner);
            this.SaveForm();
            itemDesigner.Activate();
            host = itemDesigner.Object as IDesignerHost;
            if (host != null)
            {
                ic = host.Container;
            }
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
        public IComponent AddControl(Type t, string name)
        {
            IComponent icc = host.CreateComponent(t, name);
            PropertyDescriptor parent = TypeDescriptor.GetProperties(icc)["Parent"];
            parent.SetValue(icc, host.RootComponent);
            PropertyDescriptor mod = TypeDescriptor.GetProperties(icc)["Modifiers"];
            mod.SetValue(icc, System.CodeDom.MemberAttributes.Public);
            return icc;
        }
        public bool GenForm()
        {
            return GenForm(stl);
        }
        public bool GenForm(List<SQLTableInfo> stlx)
        {
            int dis = 30;
            bool lr = false;
            int sum = 0;
            int maxwinwidth = 0;
            int maxwinheight = 0;
            if (pi == null || host == null || ic == null || stlx == null) return false;
            foreach (var item in stlx)
            {
                try
                {
                    GenControl(dis, ref lr, ref sum, ref maxwinwidth, ref maxwinheight, item);
                }
                catch (Exception ex)
                {

                    Common.ShowInfo(string.Format("生成控件{0}时发生异常:{1}", item, ex.Message));
                }
            }
            if (maxwinwidth > 0)
            {
                PropertyDescriptor parent = TypeDescriptor.GetProperties(host.RootComponent)["Width"];
                parent.SetValue(host.RootComponent, maxwinwidth + dis + 20);
            }
            if (maxwinheight > 0)
            {
                PropertyDescriptor parent = TypeDescriptor.GetProperties(host.RootComponent)["Height"];
                parent.SetValue(host.RootComponent, maxwinheight + dis + 20);
            }
            return true;
        }
        public delegate void DCreateControl(WinFormBaseGengerator wf, int dis, ref bool lr, ref int sum, ref int maxwinwidth, ref int maxwinheight, SQLTableInfo item);
        private DCreateControl CreateControl;
        private void GenControl(int dis, ref bool lr, ref int sum, ref int maxwinwidth, ref int maxwinheight, SQLTableInfo item)
        {
            if (CreateControl != null)
            {
                CreateControl(this, dis, ref lr, ref sum, ref maxwinwidth, ref maxwinheight, item);
            }
            else
            {
                GenDefControl(dis, ref lr, ref sum, ref maxwinwidth, ref maxwinheight, item);
            }
        }
        public void GenDefControl(int dis, ref bool lr, ref int sum, ref int maxwinwidth, ref int maxwinheight, SQLTableInfo item)
        {
            sum++;
            IComponent iclbl = this.AddControl(typeof(Label), "lbl" + BaseGengerator.ClearBadChars(item.t_fieldname));
            (iclbl as Label).Text = ((item.t_fielddesc != null && item.t_fielddesc as string != "") ? item.t_fielddesc : item.t_fieldname) as string;
            IComponent ictxt;
            Type t = Keel.DB.Common.NowDataBase.PasteType(item.t_fieldtype);
            if (t.Equals(typeof(string)))
                ictxt = this.AddControl(typeof(TextBox), "txt" + BaseGengerator.ClearBadChars(item.t_fieldname));

            else if (t.Equals(typeof(DateTime)))
                ictxt = this.AddControl(typeof(DateTimePicker), "dtp" + BaseGengerator.ClearBadChars(item.t_fieldname));

            else if (t.Equals(typeof(decimal)) || t.Equals(typeof(Int32)) || t.Equals(typeof(float)) || t.Equals(typeof(double))
                || t.Equals(typeof(byte)) || t.Equals(typeof(int)) || t.Equals(typeof(Int16)) || t.Equals(typeof(Int64))
                )
                ictxt = this.AddControl(typeof(NumericUpDown), "nud" + item.t_fieldname);
            else
                ictxt = this.AddControl(typeof(TextBox), "txt_unsupport_type_" + item.t_fieldname);

            int y;
            int xxx = Math.DivRem(sum, 2, out y) + y;
            // (ictxt as Control).Tag = item.t_fieldname;
            (ictxt as Control).TabIndex = (int)item.t_fieldindex;
            switch (lr)
            {
                default:
                case true:
                    (iclbl as Label).Location = new Point(20 + 300, dis * xxx);
                    (ictxt as Control).Location = new Point(20 + 300 + (iclbl as Label).Width + dis, dis * xxx);
                    int fw = (ictxt as Control).Left + (ictxt as Control).Width;
                    int fh = (ictxt as Control).Top + (ictxt as Control).Height;
                    maxwinwidth = maxwinwidth > fw ? maxwinwidth : fw;
                    maxwinheight = maxwinheight > fh ? maxwinheight : fh;
                    lr = false;
                    break;
                case false:
                    (iclbl as Label).Location = new Point(20, dis * xxx);
                    (ictxt as Control).Location = new Point(20 + (iclbl as Label).Width + dis, dis * xxx);
                    lr = true;
                    break;
            }

        }

        /// <summary>
        /// 设置对象的文本
        /// </summary>
        /// <param name="item"></param>
        /// <param name="ic"></param>

        public bool SaveForm()
        {
            if (pi == null) return true;
            bool ok = true;
            try
            {
                for (short i = 1; i <= pi.FileCount; i++)
                {
                    pi.Save(pi.get_FileNames(i));
                }
            }
            catch (Exception)
            {
                ok = false;
            }
            return ok;

        }
        private static string tablenamenow = null;
        private static bool FindByTableName(SQLTableInfo di)
        {

            return di.t_tablename.ToLower() == tablenamenow.ToLower().Trim();
        }
        public static void GeneratedCode()
        {
            GeneratedCode(null);
        }

        public static void GeneratedCode(DCreateControl dc)
        {
            GeneratedCode(dc, null, null);
        }
        public static void GeneratedCode(DCreateControl dc, string fieldlist, string tablename)
        {
            Common.ShowInfo("正在检查数据库是否可用!");
            if (Kit.CheckDataBase())
            {
                Common.ShowInfo("正在从数据库中读取表信息...");
                EnvDTE.Project pjt = Kit.GetProjectComponent();
                List<SQLTableInfo> dbix = ModelGengerator.GetSqlTableInfoList();
                SQLTableInfo[] dbix_111 = dbix.ToArray();
                if (fieldlist != null && fieldlist != "" && tablename != null && tablename != "")
                {

                    var xf = from f in dbix_111 where f.t_tablename.ToLower() == tablename.ToLower() && fieldlist.Contains(f.t_fieldname + ";") select f;
                    dbix = xf.ToList();
                }

                string[] lsttab = ((tablename != null) ? tablename + ";" : (Kit.SlnKeel.DataTableForms + Kit.SlnKeel.DataViewForms)).Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in lsttab)
                {
                    CreateControlByTable(dc, pjt, dbix, item, item + (fieldlist != null ? "_diy_" + fieldlist.Replace(";", "") : ""));
                }
                Common.chExc("SaveAll", "");
                Common.ShowInfo(string.Format("全部控件生成完毕!"));
            }
        }

        private static void CreateControlByTable(DCreateControl dc, EnvDTE.Project pjt, List<SQLTableInfo> dbix, string item, string ctlname)
        {
            tablenamenow = item;
            Common.ShowInfo(string.Format("正在生成{0}的控件,请稍候...", tablenamenow));
            Predicate<SQLTableInfo> pdbi = new Predicate<SQLTableInfo>(FindByTableName);
            List<SQLTableInfo> lstdb = dbix.FindAll(pdbi);
            WinFormBaseGengerator mg;
            try
            {
                mg = new WinFormBaseGengerator(pjt, "ctl_" + ctlname + "_Keel", lstdb);
                mg.CreateControl = dc;
                bool genok = mg.GenForm();
                if (genok)
                {
                    Common.ShowInfo(string.Format("{0}成功生成,正在保存...", tablenamenow));
                }
                else
                {
                    Common.ShowInfo(string.Format("抱歉!{0}的控件生成失败!", tablenamenow));

                }
                if (mg.SaveForm())
                {
                    Common.ShowInfo(string.Format("恭喜!{0}的控件保存完毕!", tablenamenow));
                }
                else
                {
                    Common.ShowInfo(string.Format("抱歉!{0}的控件保存失败!", tablenamenow));
                }
            }
            catch (Exception ex)
            {

                Common.ShowInfo(string.Format("抱歉!{0}的控件生成失败!由于发生了异常:{1}", tablenamenow, ex.Message));
            }
        }

    }
}
