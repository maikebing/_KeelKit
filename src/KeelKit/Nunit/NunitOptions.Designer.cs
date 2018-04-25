namespace KeelKit.Nunit
{
    partial class NunitOptions
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
            this.cbxNunitProject = new KeelKit.Controls.cbxProjects();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNunit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbxNunitProject
            // 
            this.cbxNunitProject.Location = new System.Drawing.Point(112, 29);
            this.cbxNunitProject.Name = "cbxNunitProject";
            this.cbxNunitProject.ProjectName = "";
            this.cbxNunitProject.Size = new System.Drawing.Size(269, 20);
            this.cbxNunitProject.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "单元测试项目:";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(15, 4);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(78, 16);
            this.chkEnable.TabIndex = 2;
            this.chkEnable.Text = "启用Nunit";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(344, 94);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPath.TabIndex = 4;
            this.btnSelectPath.Text = "浏览";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "安装路径";
            // 
            // txtNunit
            // 
            this.txtNunit.Location = new System.Drawing.Point(112, 94);
            this.txtNunit.Name = "txtNunit";
            this.txtNunit.Size = new System.Drawing.Size(214, 21);
            this.txtNunit.TabIndex = 6;
            // 
            // NunitOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNunit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxNunitProject);
            this.Name = "NunitOptions";
            this.Size = new System.Drawing.Size(428, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KeelKit.Controls.cbxProjects cbxNunitProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNunit;
    }
}
