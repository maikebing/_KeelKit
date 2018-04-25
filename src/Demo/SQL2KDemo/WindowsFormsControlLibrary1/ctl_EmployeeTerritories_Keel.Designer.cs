namespace WindowsFormsControlLibrary1
{
    partial class ctl_EmployeeTerritories_Keel
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
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.nudEmployeeID = new System.Windows.Forms.NumericUpDown();
            this.lblTerritoryID = new System.Windows.Forms.Label();
            this.txtTerritoryID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployeeID)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Location = new System.Drawing.Point(20, 30);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(100, 23);
            this.lblEmployeeID.TabIndex = 0;
            this.lblEmployeeID.Text = "EmployeeID";
            // 
            // nudEmployeeID
            // 
            this.nudEmployeeID.Location = new System.Drawing.Point(150, 30);
            this.nudEmployeeID.Name = "nudEmployeeID";
            this.nudEmployeeID.Size = new System.Drawing.Size(120, 21);
            this.nudEmployeeID.TabIndex = 1;
            // 
            // lblTerritoryID
            // 
            this.lblTerritoryID.Location = new System.Drawing.Point(320, 30);
            this.lblTerritoryID.Name = "lblTerritoryID";
            this.lblTerritoryID.Size = new System.Drawing.Size(100, 23);
            this.lblTerritoryID.TabIndex = 2;
            this.lblTerritoryID.Text = "TerritoryID";
            // 
            // txtTerritoryID
            // 
            this.txtTerritoryID.Location = new System.Drawing.Point(450, 30);
            this.txtTerritoryID.Name = "txtTerritoryID";
            this.txtTerritoryID.Size = new System.Drawing.Size(100, 21);
            this.txtTerritoryID.TabIndex = 2;
            // 
            // ctl_EmployeeTerritories_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.nudEmployeeID);
            this.Controls.Add(this.lblTerritoryID);
            this.Controls.Add(this.txtTerritoryID);
            this.Name = "ctl_EmployeeTerritories_Keel";
            this.Size = new System.Drawing.Size(600, 101);
            ((System.ComponentModel.ISupportInitialize)(this.nudEmployeeID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblEmployeeID;
        public System.Windows.Forms.NumericUpDown nudEmployeeID;
        public System.Windows.Forms.Label lblTerritoryID;
        public System.Windows.Forms.TextBox txtTerritoryID;
    }
}
