namespace WindowsFormsControlLibrary1
{
    partial class ctl_Territories_Keel
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
            this.lblTerritoryID = new System.Windows.Forms.Label();
            this.txtTerritoryID = new System.Windows.Forms.TextBox();
            this.lblTerritoryDescription = new System.Windows.Forms.Label();
            this.txtTerritoryDescription = new System.Windows.Forms.TextBox();
            this.lblRegionID = new System.Windows.Forms.Label();
            this.nudRegionID = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegionID)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTerritoryID
            // 
            this.lblTerritoryID.Location = new System.Drawing.Point(20, 30);
            this.lblTerritoryID.Name = "lblTerritoryID";
            this.lblTerritoryID.Size = new System.Drawing.Size(100, 23);
            this.lblTerritoryID.TabIndex = 0;
            this.lblTerritoryID.Text = "TerritoryID";
            // 
            // txtTerritoryID
            // 
            this.txtTerritoryID.Location = new System.Drawing.Point(150, 30);
            this.txtTerritoryID.Name = "txtTerritoryID";
            this.txtTerritoryID.Size = new System.Drawing.Size(100, 21);
            this.txtTerritoryID.TabIndex = 1;
            // 
            // lblTerritoryDescription
            // 
            this.lblTerritoryDescription.Location = new System.Drawing.Point(320, 30);
            this.lblTerritoryDescription.Name = "lblTerritoryDescription";
            this.lblTerritoryDescription.Size = new System.Drawing.Size(100, 23);
            this.lblTerritoryDescription.TabIndex = 2;
            this.lblTerritoryDescription.Text = "TerritoryDescription";
            // 
            // txtTerritoryDescription
            // 
            this.txtTerritoryDescription.Location = new System.Drawing.Point(450, 30);
            this.txtTerritoryDescription.Name = "txtTerritoryDescription";
            this.txtTerritoryDescription.Size = new System.Drawing.Size(100, 21);
            this.txtTerritoryDescription.TabIndex = 2;
            // 
            // lblRegionID
            // 
            this.lblRegionID.Location = new System.Drawing.Point(20, 60);
            this.lblRegionID.Name = "lblRegionID";
            this.lblRegionID.Size = new System.Drawing.Size(100, 23);
            this.lblRegionID.TabIndex = 3;
            this.lblRegionID.Text = "RegionID";
            // 
            // nudRegionID
            // 
            this.nudRegionID.Location = new System.Drawing.Point(150, 60);
            this.nudRegionID.Name = "nudRegionID";
            this.nudRegionID.Size = new System.Drawing.Size(120, 21);
            this.nudRegionID.TabIndex = 3;
            // 
            // ctl_Territories_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTerritoryID);
            this.Controls.Add(this.txtTerritoryID);
            this.Controls.Add(this.lblTerritoryDescription);
            this.Controls.Add(this.txtTerritoryDescription);
            this.Controls.Add(this.lblRegionID);
            this.Controls.Add(this.nudRegionID);
            this.Name = "ctl_Territories_Keel";
            this.Size = new System.Drawing.Size(600, 101);
            ((System.ComponentModel.ISupportInitialize)(this.nudRegionID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTerritoryID;
        public System.Windows.Forms.TextBox txtTerritoryID;
        public System.Windows.Forms.Label lblTerritoryDescription;
        public System.Windows.Forms.TextBox txtTerritoryDescription;
        public System.Windows.Forms.Label lblRegionID;
        public System.Windows.Forms.NumericUpDown nudRegionID;
    }
}
