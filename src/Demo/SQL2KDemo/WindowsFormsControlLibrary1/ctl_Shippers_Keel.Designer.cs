namespace WindowsFormsControlLibrary1
{
    partial class ctl_Shippers_Keel
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
            this.lblShipperID = new System.Windows.Forms.Label();
            this.nudShipperID = new System.Windows.Forms.NumericUpDown();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudShipperID)).BeginInit();
            this.SuspendLayout();
            // 
            // lblShipperID
            // 
            this.lblShipperID.Location = new System.Drawing.Point(20, 30);
            this.lblShipperID.Name = "lblShipperID";
            this.lblShipperID.Size = new System.Drawing.Size(100, 23);
            this.lblShipperID.TabIndex = 0;
            this.lblShipperID.Text = "ShipperID";
            // 
            // nudShipperID
            // 
            this.nudShipperID.Location = new System.Drawing.Point(150, 30);
            this.nudShipperID.Name = "nudShipperID";
            this.nudShipperID.Size = new System.Drawing.Size(120, 21);
            this.nudShipperID.TabIndex = 1;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Location = new System.Drawing.Point(320, 30);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(100, 23);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "CompanyName";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(450, 30);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(100, 21);
            this.txtCompanyName.TabIndex = 2;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(20, 60);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(150, 60);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 21);
            this.txtPhone.TabIndex = 3;
            // 
            // ctl_Shippers_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblShipperID);
            this.Controls.Add(this.nudShipperID);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Name = "ctl_Shippers_Keel";
            this.Size = new System.Drawing.Size(600, 101);
            ((System.ComponentModel.ISupportInitialize)(this.nudShipperID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblShipperID;
        public System.Windows.Forms.NumericUpDown nudShipperID;
        public System.Windows.Forms.Label lblCompanyName;
        public System.Windows.Forms.TextBox txtCompanyName;
        public System.Windows.Forms.Label lblPhone;
        public System.Windows.Forms.TextBox txtPhone;
    }
}
