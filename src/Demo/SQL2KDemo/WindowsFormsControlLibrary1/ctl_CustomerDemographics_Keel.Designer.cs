namespace WindowsFormsControlLibrary1
{
    partial class ctl_CustomerDemographics_Keel
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
            this.lblCustomerTypeID = new System.Windows.Forms.Label();
            this.txtCustomerTypeID = new System.Windows.Forms.TextBox();
            this.lblCustomerDesc = new System.Windows.Forms.Label();
            this.txtCustomerDesc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCustomerTypeID
            // 
            this.lblCustomerTypeID.Location = new System.Drawing.Point(20, 30);
            this.lblCustomerTypeID.Name = "lblCustomerTypeID";
            this.lblCustomerTypeID.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerTypeID.TabIndex = 0;
            this.lblCustomerTypeID.Text = "CustomerTypeID";
            // 
            // txtCustomerTypeID
            // 
            this.txtCustomerTypeID.Location = new System.Drawing.Point(150, 30);
            this.txtCustomerTypeID.Name = "txtCustomerTypeID";
            this.txtCustomerTypeID.Size = new System.Drawing.Size(100, 21);
            this.txtCustomerTypeID.TabIndex = 1;
            // 
            // lblCustomerDesc
            // 
            this.lblCustomerDesc.Location = new System.Drawing.Point(320, 30);
            this.lblCustomerDesc.Name = "lblCustomerDesc";
            this.lblCustomerDesc.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerDesc.TabIndex = 2;
            this.lblCustomerDesc.Text = "CustomerDesc";
            // 
            // txtCustomerDesc
            // 
            this.txtCustomerDesc.Location = new System.Drawing.Point(450, 30);
            this.txtCustomerDesc.Name = "txtCustomerDesc";
            this.txtCustomerDesc.Size = new System.Drawing.Size(100, 21);
            this.txtCustomerDesc.TabIndex = 2;
            // 
            // ctl_CustomerDemographics_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCustomerTypeID);
            this.Controls.Add(this.txtCustomerTypeID);
            this.Controls.Add(this.lblCustomerDesc);
            this.Controls.Add(this.txtCustomerDesc);
            this.Name = "ctl_CustomerDemographics_Keel";
            this.Size = new System.Drawing.Size(600, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblCustomerTypeID;
        public System.Windows.Forms.TextBox txtCustomerTypeID;
        public System.Windows.Forms.Label lblCustomerDesc;
        public System.Windows.Forms.TextBox txtCustomerDesc;
    }
}
