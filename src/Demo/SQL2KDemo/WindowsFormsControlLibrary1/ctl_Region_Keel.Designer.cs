namespace WindowsFormsControlLibrary1
{
    partial class ctl_Region_Keel
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
            this.lblRegionID = new System.Windows.Forms.Label();
            this.nudRegionID = new System.Windows.Forms.NumericUpDown();
            this.lblRegionDescription = new System.Windows.Forms.Label();
            this.txtRegionDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegionID)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegionID
            // 
            this.lblRegionID.Location = new System.Drawing.Point(20, 30);
            this.lblRegionID.Name = "lblRegionID";
            this.lblRegionID.Size = new System.Drawing.Size(100, 23);
            this.lblRegionID.TabIndex = 0;
            this.lblRegionID.Text = "RegionID";
            // 
            // nudRegionID
            // 
            this.nudRegionID.Location = new System.Drawing.Point(150, 30);
            this.nudRegionID.Name = "nudRegionID";
            this.nudRegionID.Size = new System.Drawing.Size(120, 21);
            this.nudRegionID.TabIndex = 1;
            // 
            // lblRegionDescription
            // 
            this.lblRegionDescription.Location = new System.Drawing.Point(320, 30);
            this.lblRegionDescription.Name = "lblRegionDescription";
            this.lblRegionDescription.Size = new System.Drawing.Size(100, 23);
            this.lblRegionDescription.TabIndex = 2;
            this.lblRegionDescription.Text = "RegionDescription";
            // 
            // txtRegionDescription
            // 
            this.txtRegionDescription.Location = new System.Drawing.Point(450, 30);
            this.txtRegionDescription.Name = "txtRegionDescription";
            this.txtRegionDescription.Size = new System.Drawing.Size(100, 21);
            this.txtRegionDescription.TabIndex = 2;
            // 
            // ctl_Region_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRegionID);
            this.Controls.Add(this.nudRegionID);
            this.Controls.Add(this.lblRegionDescription);
            this.Controls.Add(this.txtRegionDescription);
            this.Name = "ctl_Region_Keel";
            this.Size = new System.Drawing.Size(600, 101);
            ((System.ComponentModel.ISupportInitialize)(this.nudRegionID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblRegionID;
        public System.Windows.Forms.NumericUpDown nudRegionID;
        public System.Windows.Forms.Label lblRegionDescription;
        public System.Windows.Forms.TextBox txtRegionDescription;
    }
}
