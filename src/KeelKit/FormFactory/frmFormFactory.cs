using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeelKit.Serialization;

namespace KeelKit.Dialogs
{
    public partial class frmFormFactory : Form
    {
        public frmFormFactory()
        {
            InitializeComponent();
        }

        private void btnGenCode_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSelectTables();
                EnvDTE.Project pjt = Kit.GetProjectComponent();
                if (pjt == null)
                {
                    Common.ShowInfo("未指定组件项目！");

                }
                else
                {
                    for (int i = 1; i < pjt.Properties.Count; i++)
                    {
                        System.Diagnostics.Debug.WriteLine(pjt.Properties.Item(i).Name);
                        //System.Diagnostics.Debug.WriteLine(  pjt.Properties.Item(i).Value);
                    }//

                    if (pjt.Kind == Common.PjtKind_WebProject || Generators.WebFormBaseGengerator.IsWebApplication(pjt))
                    {
                        Generators.WebFormBaseGengerator.GeneratedCode();
                    }
                    else
                    {
#if ENABLEDevExpress 
                        Generators.WinFormBaseGengerator.GeneratedCode(chkDevExpress.Checked ?    new WinFormBaseGengerator.DCreateControl(frmDIY.DevXC):null  );
#else
                        Generators.WinFormBaseGengerator.GeneratedCode();
#endif
                    }
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
            foreach (var item in chkViewList.CheckedItems)
            {
                tabsview += item.ToString() + ";";
            }
            KeelExt ke = Kit.SlnKeel;
            ke.DataViewForms = tabsview;
            ke.DataTableForms = tabs;
            ke.FormForInherit = chkForInherit.Checked;
            Kit.SlnKeel = ke;
        }

        private void frmModelFactory_Load(object sender, EventArgs e)
        {
            try
            {
                this.Visible = true;
                Application.DoEvents();
                ReloadTableNameList();
                chkForInherit.Checked = Kit.SlnKeel.FormForInherit;
                // this.propertyGrid1.SelectedObject = new KeelKit.Property.pFormModel(); 

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
        private string dttmp_view = null;
        public void ReloadTableNameList()
        {
            dttmp = Kit.SlnKeel.DataTableForms;
            chkTableList.Items.Clear();
            List<KeelKit.Generators.SQLTableName> stb = Generators.ModelGengerator.GetSQLTableNameList();
            stb.ForEach(new Action<KeelKit.Generators.SQLTableName>(AddItem));
            this.chkTableList.Refresh();

            dttmp_view = Kit.SlnKeel.DataViewForms;
            this.chkViewList.Items.Clear();
            List<KeelKit.Generators.SQLTableName> stb1 = Generators.ModelGengerator.GetSQLViewNameList();
            stb1.ForEach(new Action<KeelKit.Generators.SQLTableName>(AddItemForView));
            this.chkViewList.Refresh();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            //propertyGrid1.SelectedObject = System.Reflection.Assembly.GetExecutingAssembly();
        }
    }
}
