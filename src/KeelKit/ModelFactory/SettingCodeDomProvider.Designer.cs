namespace KeelKit.ModelFactory
{
    partial class SettingCodeDomProvider
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstAsms = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbxIronPython = new KeelKit.Controls.cbxCodeDomeProvider();
            this.cbxFSharp = new KeelKit.Controls.cbxCodeDomeProvider();
            this.cbxCPP = new KeelKit.Controls.cbxCodeDomeProvider();
            this.cbxCSharp = new KeelKit.Controls.cbxCodeDomeProvider();
            this.cbxVBDotNet = new KeelKit.Controls.cbxCodeDomeProvider();
            this.txtAddtext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visual Basic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Visual C#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Visual C++";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Microsoft F#";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "IronPython";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(446, 131);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(139, 34);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "刷新CodeDomProvider";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(446, 81);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(139, 34);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "恢复默认";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(527, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "在这里设置对应语言的CodeDomProvider，错误的设置将导致错误后果，除非你知道自己在做什么！";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(431, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "如果列表内未显示你需要的，则说明当前IDE域内未加载相应程序集，请手动添加";
            // 
            // lstAsms
            // 
            this.lstAsms.FormattingEnabled = true;
            this.lstAsms.ItemHeight = 12;
            this.lstAsms.Location = new System.Drawing.Point(29, 210);
            this.lstAsms.Name = "lstAsms";
            this.lstAsms.Size = new System.Drawing.Size(410, 76);
            this.lstAsms.TabIndex = 19;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(445, 191);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 34);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(446, 241);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 34);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbxIronPython
            // 
            this.cbxIronPython.Location = new System.Drawing.Point(141, 125);
            this.cbxIronPython.Name = "cbxIronPython";
            this.cbxIronPython.ProviderInfo = null;
            this.cbxIronPython.Size = new System.Drawing.Size(299, 20);
            this.cbxIronPython.TabIndex = 16;
            this.cbxIronPython.SelectedProject += new System.EventHandler(this.cbxCodeDomeProvider_SelectedCodeDomProvider);
            // 
            // cbxFSharp
            // 
            this.cbxFSharp.Location = new System.Drawing.Point(141, 99);
            this.cbxFSharp.Name = "cbxFSharp";
            this.cbxFSharp.ProviderInfo = null;
            this.cbxFSharp.Size = new System.Drawing.Size(299, 20);
            this.cbxFSharp.TabIndex = 15;
            this.cbxFSharp.SelectedProject += new System.EventHandler(this.cbxCodeDomeProvider_SelectedCodeDomProvider);
            // 
            // cbxCPP
            // 
            this.cbxCPP.Location = new System.Drawing.Point(141, 73);
            this.cbxCPP.Name = "cbxCPP";
            this.cbxCPP.ProviderInfo = null;
            this.cbxCPP.Size = new System.Drawing.Size(299, 20);
            this.cbxCPP.TabIndex = 14;
            this.cbxCPP.SelectedProject += new System.EventHandler(this.cbxCodeDomeProvider_SelectedCodeDomProvider);
            // 
            // cbxCSharp
            // 
            this.cbxCSharp.Location = new System.Drawing.Point(141, 47);
            this.cbxCSharp.Name = "cbxCSharp";
            this.cbxCSharp.ProviderInfo = null;
            this.cbxCSharp.Size = new System.Drawing.Size(299, 20);
            this.cbxCSharp.TabIndex = 13;
            this.cbxCSharp.SelectedProject += new System.EventHandler(this.cbxCodeDomeProvider_SelectedCodeDomProvider);
            // 
            // cbxVBDotNet
            // 
            this.cbxVBDotNet.Location = new System.Drawing.Point(140, 21);
            this.cbxVBDotNet.Name = "cbxVBDotNet";
            this.cbxVBDotNet.ProviderInfo = null;
            this.cbxVBDotNet.Size = new System.Drawing.Size(299, 20);
            this.cbxVBDotNet.TabIndex = 12;
            this.cbxVBDotNet.SelectedProject += new System.EventHandler(this.cbxCodeDomeProvider_SelectedCodeDomProvider);
            // 
            // txtAddtext
            // 
            this.txtAddtext.Location = new System.Drawing.Point(29, 183);
            this.txtAddtext.Name = "txtAddtext";
            this.txtAddtext.Size = new System.Drawing.Size(410, 21);
            this.txtAddtext.TabIndex = 22;
            // 
            // SettingCodeDomProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAddtext);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstAsms);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxIronPython);
            this.Controls.Add(this.cbxFSharp);
            this.Controls.Add(this.cbxCPP);
            this.Controls.Add(this.cbxCSharp);
            this.Controls.Add(this.cbxVBDotNet);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingCodeDomProvider";
            this.Size = new System.Drawing.Size(635, 290);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReset;
        private KeelKit.Controls.cbxCodeDomeProvider cbxVBDotNet;
        private KeelKit.Controls.cbxCodeDomeProvider cbxCSharp;
        private KeelKit.Controls.cbxCodeDomeProvider cbxCPP;
        private KeelKit.Controls.cbxCodeDomeProvider cbxFSharp;
        private KeelKit.Controls.cbxCodeDomeProvider cbxIronPython;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstAsms;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtAddtext;

    }
}
