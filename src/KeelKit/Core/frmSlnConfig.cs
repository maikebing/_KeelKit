using System;
using System.Windows.Forms;
using KeelKit.Serialization;
using KeelKit.Controls;

namespace KeelKit.Dialogs
{
    public partial class frmSlnConfig : Form
    {
        public frmSlnConfig()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                KeelExt ke = Kit.SlnKeel;
                if (ke == null)
                {
                    ke = new KeelExt();
                }
              

                #region DAL相关
                ke.DALProjectName = cbxDALPjt.ProjectName;
                //Kit.GetProjectDAL().ProjectItems
                #endregion

                #region Model 相关
                ReadModeInfo(ref ke);
                #endregion


                #region UI相关
                ReadUIInfo(ref ke);
                #endregion

               ke.ComponentProjectName = cbxCmpntPjt.ProjectName;
                ke.AutoVersion = autoversetting.Setting;

                #region 数据连接
                ke.ConnectString = bcsCs.ConnectionString;
                #endregion 

                #region 代码提供器路由信息
                ke.CodeProviderRouter = settingCodeDomProvider1.GetInfo(); ;
                #endregion 

                #region  NUnit设置
                ke.Nunit = nunitOptions1.GetNunit();
                #endregion 


                AppDBInfo(ref   ke);

                Kit.SlnKeel = ke;
                Kit.UpdateConnectionString();
                DialogResult = DialogResult.OK;

                AppRefInfo();             
                this.Close();
            }
            catch (Exception ex)
            {

                Common.ShowInfo(ex.Message);
            }

        }

        private void ReadUIInfo(ref KeelExt ke)
        {
            //ke.UIAddForm = chkUIAddForm.Checked;
            //ke.UIQueryForm = chkQueryForm.Checked;
            //ke.UIPrinterForm = chkPrinter.Checked;
            //ke.UIModifyForm = chkModifyForm.Checked;
            ke.UIProjectName = cbxUiPjt.ProjectName;
        }

        private void ReadModeInfo(ref KeelExt ke)
        {
            ke.ModelProjectName = cbxModelPjt.ProjectName;
            ke.ModelGenerateMore = chkGenMore.Checked;
            ke.ModelAddMore = chkAddMore.Checked;
            ke.ModelForUI = chkModelForUI.Checked;
            ke.ModelCanSerialization = chkXMLRW.Checked;
            if (rbDotNetAndDotNet.Checked)
            {
                ke.ModelProjectKind = KeelExt.ModelKind.DotNetAndDotNet;
            }
            else if (rbDotNetAndC.Checked)
            {
                ke.ModelProjectKind = KeelExt.ModelKind.DotNetAndC;
            }
            else if (rbGrove.Checked)
            {
                ke.ModelProjectKind = KeelExt.ModelKind.Grove;
            }
            else
            {
                ke.ModelProjectKind = KeelExt.ModelKind.DotNetAndDotNet;
            }


            ke.ModelForCPath = txtPath.Text;
        }

        private void AppDBInfo(ref  KeelExt ke)
        {

            #region 应用数据连接
            try
            {
                if (bcsCs.csDataSource != null)
                {
                    ke.DataSourceName = bcsCs.csDataSource.Name;
                }
                if (bcsCs.csDataProvider != null)
                {
                    ke.ProviderName = bcsCs.csDataProvider.Name;
                }
             
            }
            catch (Exception)
            {


            }
            #endregion
        }

        private static void AppRefInfo()
        {
            #region 应用项目关系
            Kit.AddKeelRefToProject(Kit.GetProjectModel());
            Kit.AddKeelRefToProject(Kit.GetProjectDAL());
            Kit.AddKeelRefToProject(Kit.GetProjectByName(Kit.SlnKeel.UIProjectName));
            Kit.AddProjectRefToProject(Kit.GetProjectModel(), Kit.GetProjectDAL());
            Kit.AddProjectRefToProject(Kit.GetProjectModel(), Kit.GetProjectByName(Kit.SlnKeel.UIProjectName));
            Kit.AddProjectRefToProject(Kit.GetProjectDAL(), Kit.GetProjectByName(Kit.SlnKeel.UIProjectName));
            #endregion
        }

        private void frmSlnConfig_Load(object sender, EventArgs e)
        {
            tabMain.TabPages.Remove(tpUI);
            if (Kit.SlnKeel == null) return;
            this.Visible = true;
            tabMain.SelectTab(tpCommon);
            try
            {
                #region 数据连接
                LoadDBInfo();
                #endregion

                #region DAL相关
                cbxDALPjt.ProjectName = Kit.SlnKeel.DALProjectName;
                #endregion

                #region UI相关
                LoadUIInfo();
                #endregion

                cbxCmpntPjt.ProjectName = Kit.SlnKeel.ComponentProjectName;

                #region Model 相关
                LoadModelInfo();
                #endregion

                autoversetting.Setting = Kit.SlnKeel.AutoVersion;

                settingCodeDomProvider1.SetInfo(  Kit.SlnKeel.CodeProviderRouter);

                nunitOptions1.SetNunit(Kit.SlnKeel.Nunit);

            }
            catch (Exception ex)
            {
                Common.ShowInfo(ex.Message);
            }


        }

        private void LoadModelInfo()
        {
            chkModelForUI.Checked = Kit.SlnKeel.ModelForUI;
            cbxModelPjt.ProjectName = Kit.SlnKeel.ModelProjectName;
            chkGenMore.Checked = Kit.SlnKeel.ModelGenerateMore;
            chkAddMore.Checked = Kit.SlnKeel.ModelAddMore;
            chkXMLRW.Checked = Kit.SlnKeel.ModelCanSerialization;
            switch (Kit.SlnKeel.ModelProjectKind)
            {
                default:
                case KeelExt.ModelKind.DotNetAndDotNet:
                    rbDotNetAndDotNet.Checked = true;
                    rbDotNetAndC.Checked = false;
                    rbGrove.Checked = false;
                    break;
                case KeelExt.ModelKind.DotNetAndC:
                    rbDotNetAndDotNet.Checked = false;
                    rbDotNetAndC.Checked = true;
                    rbGrove.Checked = false;
                    break;
                case KeelExt.ModelKind.Grove:
                    rbDotNetAndDotNet.Checked = false;
                    rbDotNetAndC.Checked = false;
                    rbGrove.Checked = true;
                    break;
            }
            txtPath.Text = Kit.SlnKeel.ModelForCPath;
        }

        private void LoadUIInfo()
        {
            cbxUiPjt.ProjectName = Kit.SlnKeel.UIProjectName;
            //chkUIAddForm.Checked = Kit.SlnKeel.UIAddForm;
            //chkQueryForm.Checked = Kit.SlnKeel.UIQueryForm;
            //chkPrinter.Checked = Kit.SlnKeel.UIPrinterForm;
            //chkModifyForm.Checked = Kit.SlnKeel.UIModifyForm;
        }

        private void LoadDBInfo()
        {
            bcsCs.ConnectionString = Kit.SlnKeel.ConnectString;
            if (Kit.SlnKeel.ProviderName == "MySql.Data.MySqlClient")
            {
                bcsCs.csDataProvider = BuildConnectString.MySQLDataProvider;
                bcsCs.csDataSource = BuildConnectString.MySQLDataSource;
            }
            else
            {

                bcsCs.csDataProvider = Kit.GetDataProviderByName(Kit.SlnKeel.ProviderName);
                bcsCs.csDataSource = Kit.GetDataSourceByName(Kit.SlnKeel.DataSourceName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择存放目录:";
            fbd.SelectedPath = txtPath.Text;
            DialogResult dr = fbd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
         //   this.
        }

    

    }
}
