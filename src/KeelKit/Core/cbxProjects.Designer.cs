namespace KeelKit.Controls
{
    partial class cbxProjects
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
            this.cbxBase = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxBase
            // 
            this.cbxBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBase.FormattingEnabled = true;
            this.cbxBase.Location = new System.Drawing.Point(3, 3);
            this.cbxBase.Name = "cbxBase";
            this.cbxBase.Size = new System.Drawing.Size(237, 20);
            this.cbxBase.TabIndex = 0;
            this.cbxBase.SelectionChangeCommitted += new System.EventHandler(this.cbxBase_SelectionChangeCommitted);
  
            // 
            // cbxProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxBase);
            this.Name = "cbxProjects";
            this.Size = new System.Drawing.Size(269, 31);
            this.Resize += new System.EventHandler(this.UserControl1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxBase;
    }
}
