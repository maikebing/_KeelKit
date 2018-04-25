using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeelKit.Serialization;

namespace KeelKit.DocBuilter
{
    public partial class frmBuilder : Form
    {
        public frmBuilder()
        {
            InitializeComponent();
        }

        private void frmBuilder_Load(object sender, EventArgs e)
        {
            try
            {
                this.Visible = true;
                Application.DoEvents();
                ReloadTableNameList();
            }
            catch(Exception eee)
            {
                Common.ShowInfo(eee.Message);
            }
        }
        private string dttmp = null;
        public void AddItem(KeelKit.Generators.SQLTableName stn)
        {
            int i = this.chkTableList.Items.Add(stn.name);
            if (dttmp == null) return;
            if (dttmp.Contains(stn.name))
            {
                chkTableList.SetItemChecked(i, true);
            }
        }
        public void ReloadTableNameList()
        {
            dttmp = Kit.SlnKeel.DBDoc_DataTables;
            chkTableList.Items.Clear();
            List<KeelKit.Generators.SQLTableName> stb = Generators.ModelGengerator.GetSQLTableNameList();
            stb.ForEach(new Action<KeelKit.Generators.SQLTableName>(AddItem));
            this.chkTableList.Refresh();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < chkTableList.Items.Count; i++)
                {
                    chkTableList.SetItemChecked(i, chkSelectAll.Checked);
                }
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
            } 
        }

       

        private void btnOK_Click(object sender, EventArgs e)
        {
            KeelExt ke = Kit.SlnKeel;
            ke.DBDoc_Header = this.txtDocHeader.Text;
            SaveSelectTables();
            ke= Kit.SlnKeel ;
            Kit.SlnKeel = ke;
           string filename = DBDocBuilder.BuilingDoc();
           this.Close();
           DialogResult = DialogResult.OK;
        }
        private void SaveSelectTables()
        {
            string tabs = "";
            foreach (var item in chkTableList.CheckedItems)
            {
                tabs += item.ToString() + ";";
            }
            KeelExt ke = Kit.SlnKeel;

            ke.DBDoc_DataTables  = tabs;
            Kit.SlnKeel = ke;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

       

    }
}
