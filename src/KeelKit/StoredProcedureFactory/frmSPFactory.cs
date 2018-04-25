using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeelKit.Serialization;

namespace KeelKit.StoredProcedureFactory
{
    public partial class frmSPFactory : Form
    {
        public frmSPFactory()
        {
            InitializeComponent();
        }


        private void btnRef_Click(object sender, EventArgs e)
        {
            try
            {
                ReloadTableNameList();
            }
            catch (Exception ex)
            {
                Common.ShowInfo("加载存储过程列表时出错::" + ex.Message);
            }
        }

        private void frmSPFactory_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            Application.DoEvents();
            try
            {
                ReloadTableNameList();
            }
            catch (Exception ex)
            {
                Common.ShowInfo("加载存储过程列表时出错::" + ex.Message);
            }
        }
        private string dttmp = null;
        public void AddItem(KeelKit.Generators.SQLTableName stn)
        {
            int i = this.chkSPList.Items.Add(stn.name);
            if (dttmp == null) return;
            if (dttmp.Contains(stn.name))
            {
                chkSPList.SetItemChecked(i, true);
            }
        }

        public void ReloadTableNameList()
        {
            dttmp = Kit.SlnKeel.DataSP;
            chkSPList.Items.Clear();
            List<KeelKit.Generators.SQLTableName> stb = Generators.SPGengerator.GetSPNameList();
            stb.ForEach(new Action<KeelKit.Generators.SQLTableName>(AddItem));
            this.chkSPList.Refresh();



            this.pty.SelectedObjects = Kit.SlnKeel.StoredProcedureSettings.ToArray ();

        }
        private void SaveSelectTables()
        {
            string tabs = "";
         
            foreach (var item in chkSPList.CheckedItems)
            {
                tabs += item.ToString() + ";";
            }

            KeelExt ke = Kit.SlnKeel;
            if (lstSp != null)
            {
                ke.StoredProcedureSettings =lstSp;
            }
            ke.DataSP = tabs;
            Kit.SlnKeel = ke;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    SaveSelectTables();
                }
                catch (Exception ex)
                {
                       Common.ShowInfo("未能正确保存配置 "+ex.Message+ ex.Source );
                 
                }
            KeelKit.Generators.SPGengerator.GeneratedCode(Kit.GetProjectDAL(), "SP");
            this.DialogResult = DialogResult.OK;
            this.Close();
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message+ ex.Source );
            }
        }

        private void chkSelect_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < chkSPList.Items.Count; i++)
                {
                    chkSPList.SetItemChecked(i, chkSelect.Checked);
                }
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        string name;
        bool find( StoredProcedure v)
        {
            if (name == null || v == null) return false;
            return name == v.Name;
        }
        List<StoredProcedure> lstSp = null;
        private void chkSPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSp == null)
            {
                lstSp = new List<StoredProcedure>();
                if (Kit.SlnKeel.StoredProcedureSettings != null)
                {
                    lstSp.AddRange(Kit.SlnKeel.StoredProcedureSettings);
                }
            }
            name = this.chkSPList.Text;
            StoredProcedure sp = lstSp.FindLast(new Predicate<StoredProcedure>(find));
            if (sp == null)
            {
                sp = new StoredProcedure();
                sp.Name = name;
                lstSp.Add(sp);
            }
            pty.SelectedObject = sp;
        }

        private void pty_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {

        }

        private void pty_SelectedObjectsChanged(object sender, EventArgs e)
        {

        }

      


    }
}
