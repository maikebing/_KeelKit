namespace WindowsFormsControlLibrary1
{
    partial class ctl_Categories_Keel
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
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.nudCategoryID = new System.Windows.Forms.NumericUpDown();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPicture = new System.Windows.Forms.Label();
            this.txt_unsupport_type_Picture = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCategoryID)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.Location = new System.Drawing.Point(20, 30);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(100, 23);
            this.lblCategoryID.TabIndex = 0;
            this.lblCategoryID.Text = "CategoryID";
            // 
            // nudCategoryID
            // 
            this.nudCategoryID.Location = new System.Drawing.Point(150, 30);
            this.nudCategoryID.Name = "nudCategoryID";
            this.nudCategoryID.Size = new System.Drawing.Size(120, 21);
            this.nudCategoryID.TabIndex = 1;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Location = new System.Drawing.Point(320, 30);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(100, 23);
            this.lblCategoryName.TabIndex = 2;
            this.lblCategoryName.Text = "CategoryName";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(450, 30);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(100, 21);
            this.txtCategoryName.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(20, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 60);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 21);
            this.txtDescription.TabIndex = 3;
            // 
            // lblPicture
            // 
            this.lblPicture.Location = new System.Drawing.Point(320, 60);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(100, 23);
            this.lblPicture.TabIndex = 4;
            this.lblPicture.Text = "Picture";
            // 
            // txt_unsupport_type_Picture
            // 
            this.txt_unsupport_type_Picture.Location = new System.Drawing.Point(450, 60);
            this.txt_unsupport_type_Picture.Name = "txt_unsupport_type_Picture";
            this.txt_unsupport_type_Picture.Size = new System.Drawing.Size(100, 21);
            this.txt_unsupport_type_Picture.TabIndex = 4;
            // 
            // ctl_Categories_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCategoryID);
            this.Controls.Add(this.nudCategoryID);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.txt_unsupport_type_Picture);
            this.Name = "ctl_Categories_Keel";
            this.Size = new System.Drawing.Size(600, 131);
            ((System.ComponentModel.ISupportInitialize)(this.nudCategoryID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblCategoryID;
        public System.Windows.Forms.NumericUpDown nudCategoryID;
        public System.Windows.Forms.Label lblCategoryName;
        public System.Windows.Forms.TextBox txtCategoryName;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label lblPicture;
        public System.Windows.Forms.TextBox txt_unsupport_type_Picture;
    }
}
