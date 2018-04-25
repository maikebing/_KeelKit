namespace KeelKit.AutoVersion
{
    partial class av_ctlSetting
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
            this.components = new System.ComponentModel.Container();
            this.chkAutoVer = new System.Windows.Forms.CheckBox();
            this.gbVer = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbkvt = new System.Windows.Forms.GroupBox();
            this.rballdir = new System.Windows.Forms.RadioButton();
            this.rbtopdir = new System.Windows.Forms.RadioButton();
            this.rbTpl = new System.Windows.Forms.RadioButton();
            this.rbauto = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxPjtsVer = new KeelKit.Controls.cbxProjects();
            this.chkVerRnd = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbrev_nocontrol = new System.Windows.Forms.RadioButton();
            this.chkAllInOne = new System.Windows.Forms.CheckBox();
            this.rbsvnrev = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtminor = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtmajor = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbbuild_nocontrol = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.rbbuild_Count = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbVer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbkvt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAutoVer
            // 
            this.chkAutoVer.AutoSize = true;
            this.chkAutoVer.Location = new System.Drawing.Point(23, 6);
            this.chkAutoVer.Name = "chkAutoVer";
            this.chkAutoVer.Size = new System.Drawing.Size(108, 16);
            this.chkAutoVer.TabIndex = 3;
            this.chkAutoVer.Text = "启用自动版本号";
            this.chkAutoVer.UseVisualStyleBackColor = true;
            this.chkAutoVer.CheckedChanged += new System.EventHandler(this.chkAutoVer_CheckedChanged);
            // 
            // gbVer
            // 
            this.gbVer.Controls.Add(this.panel3);
            this.gbVer.Controls.Add(this.label1);
            this.gbVer.Controls.Add(this.cbxPjtsVer);
            this.gbVer.Controls.Add(this.chkVerRnd);
            this.gbVer.Controls.Add(this.panel2);
            this.gbVer.Controls.Add(this.label18);
            this.gbVer.Controls.Add(this.txtminor);
            this.gbVer.Controls.Add(this.label17);
            this.gbVer.Controls.Add(this.txtmajor);
            this.gbVer.Controls.Add(this.panel1);
            this.gbVer.Location = new System.Drawing.Point(12, 11);
            this.gbVer.Name = "gbVer";
            this.gbVer.Size = new System.Drawing.Size(354, 280);
            this.gbVer.TabIndex = 4;
            this.gbVer.TabStop = false;
            this.gbVer.Text = " ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbkvt);
            this.panel3.Controls.Add(this.rbTpl);
            this.panel3.Controls.Add(this.rbauto);
            this.panel3.Location = new System.Drawing.Point(17, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 82);
            this.panel3.TabIndex = 12;
            // 
            // gbkvt
            // 
            this.gbkvt.Controls.Add(this.rballdir);
            this.gbkvt.Controls.Add(this.rbtopdir);
            this.gbkvt.Location = new System.Drawing.Point(144, 9);
            this.gbkvt.Name = "gbkvt";
            this.gbkvt.Size = new System.Drawing.Size(161, 70);
            this.gbkvt.TabIndex = 3;
            this.gbkvt.TabStop = false;
            this.gbkvt.Text = "模板搜索";
            // 
            // rballdir
            // 
            this.rballdir.AutoSize = true;
            this.rballdir.Location = new System.Drawing.Point(14, 48);
            this.rballdir.Name = "rballdir";
            this.rballdir.Size = new System.Drawing.Size(119, 16);
            this.rballdir.TabIndex = 1;
            this.rballdir.TabStop = true;
            this.rballdir.Text = "全部目录及子目录";
            this.rballdir.UseVisualStyleBackColor = true;
            // 
            // rbtopdir
            // 
            this.rbtopdir.AutoSize = true;
            this.rbtopdir.Location = new System.Drawing.Point(13, 20);
            this.rbtopdir.Name = "rbtopdir";
            this.rbtopdir.Size = new System.Drawing.Size(131, 16);
            this.rbtopdir.TabIndex = 0;
            this.rbtopdir.TabStop = true;
            this.rbtopdir.Text = "仅搜索解决方案目录";
            this.rbtopdir.UseVisualStyleBackColor = true;
            // 
            // rbTpl
            // 
            this.rbTpl.Location = new System.Drawing.Point(3, 29);
            this.rbTpl.Name = "rbTpl";
            this.rbTpl.Size = new System.Drawing.Size(119, 44);
            this.rbTpl.TabIndex = 1;
            this.rbTpl.TabStop = true;
            this.rbTpl.Text = "使用了模版的版本号控制";
            this.rbTpl.UseVisualStyleBackColor = true;
            this.rbTpl.CheckedChanged += new System.EventHandler(this.rbTpl_CheckedChanged);
            // 
            // rbauto
            // 
            this.rbauto.AutoSize = true;
            this.rbauto.Location = new System.Drawing.Point(3, 9);
            this.rbauto.Name = "rbauto";
            this.rbauto.Size = new System.Drawing.Size(119, 16);
            this.rbauto.TabIndex = 0;
            this.rbauto.TabStop = true;
            this.rbauto.Text = "自动处理的版本号";
            this.rbauto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "基准项目";
            // 
            // cbxPjtsVer
            // 
            this.cbxPjtsVer.Location = new System.Drawing.Point(68, 45);
            this.cbxPjtsVer.Name = "cbxPjtsVer";
            this.cbxPjtsVer.ProjectName = "";
            this.cbxPjtsVer.Size = new System.Drawing.Size(273, 20);
            this.cbxPjtsVer.TabIndex = 10;
            this.cbxPjtsVer.SelectedProject += new System.EventHandler(this.cbxPjtsVer_SelectedProject);
            // 
            // chkVerRnd
            // 
            this.chkVerRnd.AutoSize = true;
            this.chkVerRnd.Location = new System.Drawing.Point(11, 159);
            this.chkVerRnd.Name = "chkVerRnd";
            this.chkVerRnd.Size = new System.Drawing.Size(216, 16);
            this.chkVerRnd.TabIndex = 9;
            this.chkVerRnd.Text = "编译器控制内部版本号和修订版本号";
            this.chkVerRnd.UseVisualStyleBackColor = true;
            this.chkVerRnd.CheckedChanged += new System.EventHandler(this.chkVerRnd_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbrev_nocontrol);
            this.panel2.Controls.Add(this.chkAllInOne);
            this.panel2.Controls.Add(this.rbsvnrev);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Location = new System.Drawing.Point(139, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 81);
            this.panel2.TabIndex = 7;
            // 
            // rbrev_nocontrol
            // 
            this.rbrev_nocontrol.AutoSize = true;
            this.rbrev_nocontrol.Location = new System.Drawing.Point(7, 63);
            this.rbrev_nocontrol.Name = "rbrev_nocontrol";
            this.rbrev_nocontrol.Size = new System.Drawing.Size(59, 16);
            this.rbrev_nocontrol.TabIndex = 4;
            this.rbrev_nocontrol.TabStop = true;
            this.rbrev_nocontrol.Text = "不控制";
            this.rbrev_nocontrol.UseVisualStyleBackColor = true;
            // 
            // chkAllInOne
            // 
            this.chkAllInOne.AutoSize = true;
            this.chkAllInOne.Location = new System.Drawing.Point(22, 41);
            this.chkAllInOne.Name = "chkAllInOne";
            this.chkAllInOne.Size = new System.Drawing.Size(168, 16);
            this.chkAllInOne.TabIndex = 8;
            this.chkAllInOne.Text = "所有程序集使用相同版本号";
            this.toolTip1.SetToolTip(this.chkAllInOne, "编译器决定的版本号除外");
            this.chkAllInOne.UseVisualStyleBackColor = true;
            // 
            // rbsvnrev
            // 
            this.rbsvnrev.AutoSize = true;
            this.rbsvnrev.Location = new System.Drawing.Point(7, 23);
            this.rbsvnrev.Name = "rbsvnrev";
            this.rbsvnrev.Size = new System.Drawing.Size(77, 16);
            this.rbsvnrev.TabIndex = 3;
            this.rbsvnrev.TabStop = true;
            this.rbsvnrev.Text = "SVN版本号";
            this.rbsvnrev.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 2;
            this.label19.Text = "修订版本号";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(180, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 6;
            this.label18.Text = "次版本号";
            // 
            // txtminor
            // 
            this.txtminor.Location = new System.Drawing.Point(241, 14);
            this.txtminor.Name = "txtminor";
            this.txtminor.Size = new System.Drawing.Size(100, 21);
            this.txtminor.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "主版本号";
            // 
            // txtmajor
            // 
            this.txtmajor.Location = new System.Drawing.Point(70, 14);
            this.txtmajor.Name = "txtmajor";
            this.txtmajor.Size = new System.Drawing.Size(100, 21);
            this.txtmajor.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbbuild_nocontrol);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.rbbuild_Count);
            this.panel1.Location = new System.Drawing.Point(11, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 81);
            this.panel1.TabIndex = 2;
            // 
            // rbbuild_nocontrol
            // 
            this.rbbuild_nocontrol.AutoSize = true;
            this.rbbuild_nocontrol.Location = new System.Drawing.Point(7, 36);
            this.rbbuild_nocontrol.Name = "rbbuild_nocontrol";
            this.rbbuild_nocontrol.Size = new System.Drawing.Size(59, 16);
            this.rbbuild_nocontrol.TabIndex = 3;
            this.rbbuild_nocontrol.TabStop = true;
            this.rbbuild_nocontrol.Text = "不控制";
            this.rbbuild_nocontrol.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "内部版本号";
            // 
            // rbbuild_Count
            // 
            this.rbbuild_Count.AutoSize = true;
            this.rbbuild_Count.Location = new System.Drawing.Point(7, 15);
            this.rbbuild_Count.Name = "rbbuild_Count";
            this.rbbuild_Count.Size = new System.Drawing.Size(71, 16);
            this.rbbuild_Count.TabIndex = 0;
            this.rbbuild_Count.TabStop = true;
            this.rbbuild_Count.Text = "编译累计";
            this.rbbuild_Count.UseVisualStyleBackColor = true;
            // 
            // av_ctlSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chkAutoVer);
            this.Controls.Add(this.gbVer);
            this.Name = "av_ctlSetting";
            this.Size = new System.Drawing.Size(376, 294);
            this.gbVer.ResumeLayout(false);
            this.gbVer.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbkvt.ResumeLayout(false);
            this.gbkvt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoVer;
        private System.Windows.Forms.GroupBox gbVer;
        private System.Windows.Forms.CheckBox chkAllInOne;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbsvnrev;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtminor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtmajor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rbbuild_Count;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton rbrev_nocontrol;
        private System.Windows.Forms.RadioButton rbbuild_nocontrol;
        private System.Windows.Forms.CheckBox chkVerRnd;
        private System.Windows.Forms.Label label1;
        private KeelKit.Controls.cbxProjects cbxPjtsVer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbTpl;
        private System.Windows.Forms.RadioButton rbauto;
        private System.Windows.Forms.RadioButton rballdir;
        private System.Windows.Forms.RadioButton rbtopdir;
        private System.Windows.Forms.GroupBox gbkvt;
    }
}
