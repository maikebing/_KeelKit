namespace WindowsFormsControlLibrary1
{
    partial class ctl_tb_codfiles_Keel
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
            this.lblfilemd5 = new System.Windows.Forms.Label();
            this.txtfilemd5 = new System.Windows.Forms.TextBox();
            this.lblfilepath = new System.Windows.Forms.Label();
            this.txtfilepath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblfilemd5
            // 
            this.lblfilemd5.Location = new System.Drawing.Point(20, 30);
            this.lblfilemd5.Name = "lblfilemd5";
            this.lblfilemd5.Size = new System.Drawing.Size(100, 23);
            this.lblfilemd5.TabIndex = 0;
            this.lblfilemd5.Text = "Cod文件";
            // 
            // txtfilemd5
            // 
            this.txtfilemd5.Location = new System.Drawing.Point(150, 30);
            this.txtfilemd5.Name = "txtfilemd5";
            this.txtfilemd5.Size = new System.Drawing.Size(100, 21);
            this.txtfilemd5.TabIndex = 1;
            // 
            // lblfilepath
            // 
            this.lblfilepath.Location = new System.Drawing.Point(320, 30);
            this.lblfilepath.Name = "lblfilepath";
            this.lblfilepath.Size = new System.Drawing.Size(100, 23);
            this.lblfilepath.TabIndex = 2;
            this.lblfilepath.Text = "filepath";
            // 
            // txtfilepath
            // 
            this.txtfilepath.Location = new System.Drawing.Point(450, 30);
            this.txtfilepath.Name = "txtfilepath";
            this.txtfilepath.Size = new System.Drawing.Size(100, 21);
            this.txtfilepath.TabIndex = 4;
            // 
            // ctl_tb_codfiles_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblfilemd5);
            this.Controls.Add(this.txtfilemd5);
            this.Controls.Add(this.lblfilepath);
            this.Controls.Add(this.txtfilepath);
            this.Name = "ctl_tb_codfiles_Keel";
            this.Size = new System.Drawing.Size(600, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblfilemd5;
        public System.Windows.Forms.TextBox txtfilemd5;
        public System.Windows.Forms.Label lblfilepath;
        public System.Windows.Forms.TextBox txtfilepath;
    }
}
