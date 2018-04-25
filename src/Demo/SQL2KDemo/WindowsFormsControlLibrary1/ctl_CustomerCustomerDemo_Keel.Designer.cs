namespace WindowsFormsControlLibrary1
{
    partial class ctl_CustomerCustomerDemo_Keel
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
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomerTypeID = new System.Windows.Forms.Label();
            this.txtCustomerTypeID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.Location = new System.Drawing.Point(20, 30);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "CustomerID";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(150, 30);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 21);
            this.txtCustomerID.TabIndex = 1;
            // 
            // lblCustomerTypeID
            // 
            this.lblCustomerTypeID.Location = new System.Drawing.Point(320, 30);
            this.lblCustomerTypeID.Name = "lblCustomerTypeID";
            this.lblCustomerTypeID.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerTypeID.TabIndex = 2;
            this.lblCustomerTypeID.Text = "CustomerTypeID";
            // 
            // txtCustomerTypeID
            // 
            this.txtCustomerTypeID.Location = new System.Drawing.Point(450, 30);
            this.txtCustomerTypeID.Name = "txtCustomerTypeID";
            this.txtCustomerTypeID.Size = new System.Drawing.Size(100, 21);
            this.txtCustomerTypeID.TabIndex = 2;
            // 
            // ctl_CustomerCustomerDemo_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.lblCustomerTypeID);
            this.Controls.Add(this.txtCustomerTypeID);
            this.Name = "ctl_CustomerCustomerDemo_Keel";
            this.Size = new System.Drawing.Size(600, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblCustomerID;
        public System.Windows.Forms.TextBox txtCustomerID;
        public System.Windows.Forms.Label lblCustomerTypeID;
        public System.Windows.Forms.TextBox txtCustomerTypeID;
    }
}
