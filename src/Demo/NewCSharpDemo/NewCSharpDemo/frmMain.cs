using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Keel;


namespace NewCSharpDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = new DBHelper<tb_codfiles>().SelectEntitys();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DBHelper<tb_codfiles> dbt = new DBHelper<tb_codfiles>();
            int i = dbt.Insert(dbt.Distill(this.ctl_tb_codfiles_Keel1));
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = new DBHelper<tb_codfiles>().Update (new DBHelper<tb_codfiles>().Distill(this.ctl_tb_codfiles_Keel1));
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if  (dataGridView1.SelectedRows.Count >0)
            {
            tb_codfiles t = new tb_codfiles();
            t.filemd5 = dataGridView1.SelectedRows[0].Cells["filemd5"].Value.ToString();
            t.filepath = dataGridView1.SelectedRows[0].Cells["filepath"].Value.ToString();
            new DBHelper<tb_codfiles>().Fill(this.ctl_tb_codfiles_Keel1,t );
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                tb_codfiles t = new tb_codfiles();
                t.filemd5 ="asdfjasd"
                t.filemd5 = dataGridView1.SelectedRows[0].Cells["filemd5"].Value.ToString();
                t.filepath = dataGridView1.SelectedRows[0].Cells["filepath"].Value.ToString();
              int i =  new DBHelper<tb_codfiles>().Delete (t);
            }
        }
 

   

 
 

      
    }
}
