using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KeelKit.Generators;
#if ENABLEDevExpress 
using DevExpress.XtraEditors;
#endif
using Keel;

namespace KeelKit.FormFactory
{
    public partial class frmDIY : Form
    {
        public frmDIY()
        {
            InitializeComponent();
        }

        private void frmDIY_Load(object sender, EventArgs e)
        {
            ReloadTableNameList();
        }
        private string dttmp = null;
        public void AddItem(KeelKit.Generators.SQLTableName stn)
        {
            int i = this.chkTableList.Items.Add(stn.name);
            if (dttmp == null) return;
            if (dttmp.Contains(stn.name))
            {
                // chkTableList.SetItemChecked(i, true);
            }
        }
        SQLTableInfo[] dbix_111 = null;
        public void ReloadTableNameList()
        {
            dttmp = Kit.SlnKeel.DataTableForms;
            chkTableList.Items.Clear();
            List<KeelKit.Generators.SQLTableName> stb = Generators.ModelGengerator.GetSQLTableNameList();
            stb.ForEach(new Action<KeelKit.Generators.SQLTableName>(AddItem));
            this.chkTableList.Refresh();

            dbix_111 = Generators.ModelGengerator.GetSqlTableInfoList().ToArray();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string fieldlist = "";
            for (int i = 0; i < lstFieldList.Items.Count; i++)
            {
                if (lstFieldList.GetItemChecked(i))
                {
                    fieldlist += lstFieldList.Items[i].ToString() + ";";
                }
            }
            string tablename = chkTableList.Items[chkTableList.SelectedIndex].ToString();
            WinFormBaseGengerator.GeneratedCode(new WinFormBaseGengerator.DCreateControl(DevXC), fieldlist, tablename);

        }
        public static void DevXC(WinFormBaseGengerator wf, int dis, ref bool lr, ref int sum, ref int maxwinwidth, ref int maxwinheight, SQLTableInfo item)
        {
            sum++;
            IComponent iclbl = wf.AddControl(typeof(
#if ENABLEDevExpress 
                LabelControl
#else
Label
#endif
), "lbl" + BaseGengerator.ClearBadChars(item.t_fieldname));
            (iclbl as
#if ENABLEDevExpress 
                LabelControl
#else
 Label
#endif
).Text = ((item.t_fielddesc != null && item.t_fielddesc as string != "") ? item.t_fielddesc : item.t_fieldname) as string;
            IComponent ictxt;
            Type t = Keel.DB.Common.NowDataBase.PasteType(item.t_fieldtype);
            if (t.Equals(typeof(string)))
                ictxt = wf.AddControl(typeof(
#if ENABLEDevExpress 
                TextEdit
#else
TextBox
#endif
), "txt" + BaseGengerator.ClearBadChars(item.t_fieldname));

            else if (t.Equals(typeof(DateTime)))
                ictxt = wf.AddControl(typeof(
#if ENABLEDevExpress 
                DateEdit
#else
DateTimePicker
#endif
), "dtp" + BaseGengerator.ClearBadChars(item.t_fieldname));

            else if (t.Equals(typeof(decimal)) || t.Equals(typeof(Int32)) || t.Equals(typeof(float)) || t.Equals(typeof(double))
                || t.Equals(typeof(byte)) || t.Equals(typeof(int)) || t.Equals(typeof(Int16)) || t.Equals(typeof(Int64))
                )
                ictxt = wf.AddControl(typeof(
#if ENABLEDevExpress 
                SpinEdit
#else
NumericUpDown
#endif
), "nud" + BaseGengerator.ClearBadChars(item.t_fieldname));
            else
                ictxt = wf.AddControl(typeof(
#if ENABLEDevExpress 
                TextEdit
#else
TextBox
#endif
), "txt_unsupport_type_" + BaseGengerator.ClearBadChars(item.t_fieldname));

            int y;
            int xxx = Math.DivRem(sum, 2, out y) + y;
            // (ictxt as Control).Tag = item.t_fieldname;
            (ictxt as Control).TabIndex = (int)item.t_fieldindex;
            switch (lr)
            {
                default:
                case true:
                    (iclbl as
#if ENABLEDevExpress 
                LabelControl
#else
 Label
#endif
).Location = new Point(20 + 300, dis * xxx);
                    (ictxt as Control).Location = new Point(20 + 300 + (iclbl as
#if ENABLEDevExpress 
                LabelControl
#else
 Label
#endif
).Width + dis, dis * xxx);
                    int fw = (ictxt as Control).Left + (ictxt as Control).Width;
                    int fh = (ictxt as Control).Top + (ictxt as Control).Height;
                    maxwinwidth = maxwinwidth > fw ? maxwinwidth : fw;
                    maxwinheight = maxwinheight > fh ? maxwinheight : fh;
                    lr = false;
                    break;
                case false:
                    (iclbl as
#if ENABLEDevExpress 
                LabelControl
#else
 Label
#endif
).Location = new Point(20, dis * xxx);
                    (ictxt as Control).Location = new Point(20 + (iclbl as
#if ENABLEDevExpress 
                LabelControl
#else
 Label
#endif
).Width + dis, dis * xxx);
                    lr = true;
                    break;
            }

        }

        private void chkTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstFieldList.Items.Clear();
            if (chkTableList.SelectedIndex < 0) return;
            string tablename = chkTableList.Items[chkTableList.SelectedIndex].ToString();



            if (dbix_111 != null)
            {
                var f = from x in dbix_111 where x.t_tablename.ToLower() == tablename.ToLower() select x;
                foreach (var item in f.ToArray())
                {
                    lstFieldList.Items.Add(item.t_fieldname);

                    lstFieldList.SetItemChecked(lstFieldList.Items.Count - 1, true);
                }
            }

        }

        private void checkCheckall_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lstFieldList.Items.Count; i++)
            {
                lstFieldList.SetItemChecked(i, checkCheckall.Checked);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
