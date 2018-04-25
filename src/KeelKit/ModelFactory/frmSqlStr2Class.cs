using System;
using System.Windows.Forms;

namespace KeelKit.Dialogs
{
    public partial class frmSqlStr2Class : Form
    {
        public frmSqlStr2Class()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSQL.Text != null && txtViewName.Text != null && txtSQL.Text.Trim() != "" && txtViewName.Text.Trim() != "")
                {
                    bool ok = Commands.SQL2Class.BuildClassBySql(txtSQL.Text, txtViewName.Text);
                    if (ok)
                    {
                        this.Close();
                    }
                }
                else
                {
                    Common.ShowInfo("请填写完整的SQL语句和K视图名称");
                }
            }
            catch (Exception ex)
            {
                Common.ShowInfo(ex.Message);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSqlStr2Class_Load(object sender, EventArgs e)
        {
            this.txtSQL.SetHighlighting("SQL");
        }

       
    }
}
