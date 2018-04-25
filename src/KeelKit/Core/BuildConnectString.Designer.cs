namespace KeelKit.Controls
{
    partial class BuildConnectString
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
            this.txtCntStr = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCntStr
            // 
            this.txtCntStr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCntStr.Location = new System.Drawing.Point(0, 5);
            this.txtCntStr.Name = "txtCntStr";
            this.txtCntStr.Size = new System.Drawing.Size(396, 21);
            this.txtCntStr.TabIndex = 0;
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Location = new System.Drawing.Point(405, 5);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(59, 21);
            this.btnBuild.TabIndex = 1;
            this.btnBuild.Text = "...";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // BuildConnectString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.txtCntStr);
            this.Name = "BuildConnectString";
            this.Size = new System.Drawing.Size(465, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCntStr;
        private System.Windows.Forms.Button btnBuild;
    }
}
