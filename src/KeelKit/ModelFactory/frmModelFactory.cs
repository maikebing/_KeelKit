using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeelKit.Serialization;

namespace KeelKit.Dialogs
{
    public partial class frmModelFactory : Form
    {
        public frmModelFactory()
        {
            InitializeComponent();
        }

        private void btnGenCode_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSelectTables();
                switch (Kit.SlnKeel.ModelProjectKind)
                {
                    case KeelExt.ModelKind.Grove:
                        KeelKit.ModelFactory.GroveGenerator.GeneratedCode();
                        break;
                    case KeelExt.ModelKind.DotNetAndDotNet:
                    case KeelExt.ModelKind.DotNetAndC:
                        Generators.ModelGengerator.GeneratedCode(Kit.SlnKeel.ModelProjectKind);
                        break;
                }
                 
                this.Close();
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
            }
        }

        private void SaveSelectTables()
        {
            string tabs = "";
            foreach (var item in chkTableList.CheckedItems)
            {
                tabs += item.ToString() + ";";
            }
            string tabsview = "";
            foreach (var item in  chkViewList.CheckedItems)
            {
                tabsview += item.ToString() + ";";
            }
            KeelExt ke = Kit.SlnKeel;

            ke.DataViews = tabsview;

            ke.DataTables = tabs;
            Kit.SlnKeel = ke;
        }

        private void frmModelFactory_Load(object sender, EventArgs e)
        {
            try
            {
                this.Visible = true;
                Application.DoEvents();
                ReloadTableNameList();
                if (Kit.SlnKeel.ModelGenerateMore && System.IO.Directory.Exists(Kit.SlnKeel.ModelForCPath))
                {
                    this.btnGenCodeForC.Enabled = true;
                }
                else
                {
                    this.btnGenCodeForC.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
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
            dttmp = Kit.SlnKeel.DataTables;
            chkTableList.Items.Clear();

            List<KeelKit.Generators.SQLTableName> stb = Generators.ModelGengerator.GetSQLTableNameList();
            stb.ForEach(new Action<KeelKit.Generators.SQLTableName>(AddItem));
            this.chkTableList.Refresh();
            dttmp_view = Kit.SlnKeel.DataViews ;
            this.chkViewList.Items.Clear();
            List<KeelKit.Generators.SQLTableName> stb1 = Generators.ModelGengerator.GetSQLViewNameList();
            stb1.ForEach(new Action<KeelKit.Generators.SQLTableName>(AddItemForView));
            this.chkViewList.Refresh();
        }

        private string dttmp_view = null;
        public void AddItemForView(KeelKit.Generators.SQLTableName stn)
        {
            int i = this.chkViewList.Items.Add(stn.name);
            if (dttmp_view == null) return;
            if (dttmp_view.Contains(stn.name))
            {
                chkViewList.SetItemChecked(i, true);
            }
        }
        
     
        private void chkTableList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    ReloadTableNameList();
                }
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSelectTables();
                ReloadTableNameList();
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSelectTables();
                this.Close();
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
            }
        }

        private void btnGenCodeForC_Click(object sender, EventArgs e)
        {
            try
            {
                Generators.CGenerator cg = new KeelKit.Generators.CGenerator(Kit.SlnKeel.ModelForCPath);
                cg.GeneratedCode();
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
            }
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
    }
}
