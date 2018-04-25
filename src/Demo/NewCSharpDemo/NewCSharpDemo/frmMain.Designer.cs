namespace NewCSharpDemo
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ctl_tb_codfiles_Keel1 = new NewCSharpDemo.Controls.ctl_tb_codfiles_Keel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctl_tb_codfiles_Keel1
            // 
            this.ctl_tb_codfiles_Keel1.Location = new System.Drawing.Point(102, 29);
            this.ctl_tb_codfiles_Keel1.Name = "ctl_tb_codfiles_Keel1";
            this.ctl_tb_codfiles_Keel1.Size = new System.Drawing.Size(600, 101);
            this.ctl_tb_codfiles_Keel1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(120, 183);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(111, 35);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(299, 183);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(111, 35);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "插入";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(491, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "更新";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(608, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 35);
            this.button4.TabIndex = 4;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(86, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(635, 157);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 419);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.ctl_tb_codfiles_Keel1);
            this.Name = "frmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NewCSharpDemo.Controls.ctl_tb_codfiles_Keel ctl_tb_codfiles_Keel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
 

    }
}

