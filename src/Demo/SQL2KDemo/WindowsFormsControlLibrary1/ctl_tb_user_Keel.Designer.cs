namespace WindowsFormsControlLibrary1
{
    partial class ctl_tb_user_Keel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblusername = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.lblpassword = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblphonetype = new System.Windows.Forms.Label();
            this.txtphonetype = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblusername
            // 
            this.lblusername.Location = new System.Drawing.Point(20, 30);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(100, 23);
            this.lblusername.TabIndex = 0;
            this.lblusername.Text = "这是用户表";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(150, 30);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(100, 21);
            this.txtusername.TabIndex = 1;
            // 
            // lblpassword
            // 
            this.lblpassword.Location = new System.Drawing.Point(320, 30);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(100, 23);
            this.lblpassword.TabIndex = 2;
            this.lblpassword.Text = "password";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(450, 30);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(100, 21);
            this.txtpassword.TabIndex = 2;
            // 
            // lblphonetype
            // 
            this.lblphonetype.Location = new System.Drawing.Point(20, 60);
            this.lblphonetype.Name = "lblphonetype";
            this.lblphonetype.Size = new System.Drawing.Size(100, 23);
            this.lblphonetype.TabIndex = 3;
            this.lblphonetype.Text = "phonetype";
            // 
            // txtphonetype
            // 
            this.txtphonetype.Location = new System.Drawing.Point(150, 60);
            this.txtphonetype.Name = "txtphonetype";
            this.txtphonetype.Size = new System.Drawing.Size(100, 21);
            this.txtphonetype.TabIndex = 3;
            // 
            // lblemail
            // 
            this.lblemail.Location = new System.Drawing.Point(320, 60);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(100, 23);
            this.lblemail.TabIndex = 4;
            this.lblemail.Text = "email";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(450, 60);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(100, 21);
            this.txtemail.TabIndex = 4;
            // 
            // ctl_tb_user_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.lblphonetype);
            this.Controls.Add(this.txtphonetype);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.txtemail);
            this.Name = "ctl_tb_user_Keel";
            this.Size = new System.Drawing.Size(600, 131);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblusername;
        public System.Windows.Forms.TextBox txtusername;
        public System.Windows.Forms.Label lblpassword;
        public System.Windows.Forms.TextBox txtpassword;
        public System.Windows.Forms.Label lblphonetype;
        public System.Windows.Forms.TextBox txtphonetype;
        public System.Windows.Forms.Label lblemail;
        public System.Windows.Forms.TextBox txtemail;
    }
}
