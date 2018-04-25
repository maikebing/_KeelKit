namespace KeelKit.Dialogs
{
    partial class frmSlnConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpCommon = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxCmpntPjt = new KeelKit.Controls.cbxProjects();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxUiPjt = new KeelKit.Controls.cbxProjects();
            this.cbxModelPjt = new KeelKit.Controls.cbxProjects();
            this.cbxDALPjt = new KeelKit.Controls.cbxProjects();
            this.bcsCs = new KeelKit.Controls.BuildConnectString();
            this.tpModel = new System.Windows.Forms.TabPage();
            this.chkXMLRW = new System.Windows.Forms.CheckBox();
            this.rbGrove = new System.Windows.Forms.RadioButton();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkModelForUI = new System.Windows.Forms.CheckBox();
            this.chkAddMore = new System.Windows.Forms.CheckBox();
            this.chkGenMore = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbDotNetAndC = new System.Windows.Forms.RadioButton();
            this.rbDotNetAndDotNet = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.tpUI = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.autoversetting = new KeelKit.AutoVersion.av_ctlSetting();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.settingCodeDomProvider1 = new KeelKit.ModelFactory.SettingCodeDomProvider();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nunitOptions1 = new KeelKit.Nunit.NunitOptions();
            this.lstDllUsing = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tpCommon.SuspendLayout();
            this.tpModel.SuspendLayout();
            this.tpUI.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "您的解决方案中第一次使用KeelKit,请在这里配置相关选项";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "DAL项目";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Model项目";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "链接字符串";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(407, 356);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 30);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(514, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpCommon);
            this.tabMain.Controls.Add(this.tpModel);
            this.tabMain.Controls.Add(this.tpUI);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(605, 338);
            this.tabMain.TabIndex = 12;
            // 
            // tpCommon
            // 
            this.tpCommon.Controls.Add(this.label13);
            this.tpCommon.Controls.Add(this.cbxCmpntPjt);
            this.tpCommon.Controls.Add(this.label14);
            this.tpCommon.Controls.Add(this.label8);
            this.tpCommon.Controls.Add(this.label7);
            this.tpCommon.Controls.Add(this.label6);
            this.tpCommon.Controls.Add(this.label5);
            this.tpCommon.Controls.Add(this.cbxUiPjt);
            this.tpCommon.Controls.Add(this.label1);
            this.tpCommon.Controls.Add(this.cbxModelPjt);
            this.tpCommon.Controls.Add(this.label2);
            this.tpCommon.Controls.Add(this.cbxDALPjt);
            this.tpCommon.Controls.Add(this.label3);
            this.tpCommon.Controls.Add(this.bcsCs);
            this.tpCommon.Controls.Add(this.label4);
            this.tpCommon.Location = new System.Drawing.Point(4, 22);
            this.tpCommon.Name = "tpCommon";
            this.tpCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommon.Size = new System.Drawing.Size(597, 312);
            this.tpCommon.TabIndex = 0;
            this.tpCommon.Text = "常规";
            this.tpCommon.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(400, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 30);
            this.label13.TabIndex = 19;
            this.label13.Text = "所有的组件将在这里出现";
            // 
            // cbxCmpntPjt
            // 
            this.cbxCmpntPjt.Location = new System.Drawing.Point(100, 135);
            this.cbxCmpntPjt.Name = "cbxCmpntPjt";
            this.cbxCmpntPjt.ProjectName = "";
            this.cbxCmpntPjt.Size = new System.Drawing.Size(269, 20);
            this.cbxCmpntPjt.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "Component项目";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(391, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "在该项目中添加数据窗体";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(400, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 30);
            this.label7.TabIndex = 15;
            this.label7.Text = "将所有Model添加至该项目,并使用该项目的命名空间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "将为该项目添加相关引用和代码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "UI项目";
            // 
            // cbxUiPjt
            // 
            this.cbxUiPjt.Location = new System.Drawing.Point(100, 180);
            this.cbxUiPjt.Name = "cbxUiPjt";
            this.cbxUiPjt.ProjectName = "";
            this.cbxUiPjt.Size = new System.Drawing.Size(269, 20);
            this.cbxUiPjt.TabIndex = 12;
            // 
            // cbxModelPjt
            // 
            this.cbxModelPjt.Location = new System.Drawing.Point(100, 91);
            this.cbxModelPjt.Name = "cbxModelPjt";
            this.cbxModelPjt.ProjectName = "";
            this.cbxModelPjt.Size = new System.Drawing.Size(269, 20);
            this.cbxModelPjt.TabIndex = 11;
            // 
            // cbxDALPjt
            // 
            this.cbxDALPjt.Location = new System.Drawing.Point(100, 54);
            this.cbxDALPjt.Name = "cbxDALPjt";
            this.cbxDALPjt.ProjectName = "";
            this.cbxDALPjt.Size = new System.Drawing.Size(269, 20);
            this.cbxDALPjt.TabIndex = 10;
            // 
            // bcsCs
            // 
            this.bcsCs.BackColor = System.Drawing.Color.Transparent;
            this.bcsCs.ConnectionString = "";
            this.bcsCs.csDataProvider = null;
            this.bcsCs.csDataSource = null;
            this.bcsCs.Location = new System.Drawing.Point(100, 226);
            this.bcsCs.Name = "bcsCs";
            this.bcsCs.Size = new System.Drawing.Size(479, 30);
            this.bcsCs.TabIndex = 9;
            // 
            // tpModel
            // 
            this.tpModel.Controls.Add(this.chkXMLRW);
            this.tpModel.Controls.Add(this.rbGrove);
            this.tpModel.Controls.Add(this.btnSelectPath);
            this.tpModel.Controls.Add(this.txtPath);
            this.tpModel.Controls.Add(this.label11);
            this.tpModel.Controls.Add(this.chkModelForUI);
            this.tpModel.Controls.Add(this.chkAddMore);
            this.tpModel.Controls.Add(this.chkGenMore);
            this.tpModel.Controls.Add(this.label9);
            this.tpModel.Controls.Add(this.rbDotNetAndC);
            this.tpModel.Controls.Add(this.rbDotNetAndDotNet);
            this.tpModel.Controls.Add(this.label10);
            this.tpModel.Location = new System.Drawing.Point(4, 22);
            this.tpModel.Name = "tpModel";
            this.tpModel.Padding = new System.Windows.Forms.Padding(3);
            this.tpModel.Size = new System.Drawing.Size(597, 312);
            this.tpModel.TabIndex = 1;
            this.tpModel.Text = "Model选项";
            this.tpModel.UseVisualStyleBackColor = true;
            // 
            // chkXMLRW
            // 
            this.chkXMLRW.AutoSize = true;
            this.chkXMLRW.Location = new System.Drawing.Point(282, 63);
            this.chkXMLRW.Name = "chkXMLRW";
            this.chkXMLRW.Size = new System.Drawing.Size(162, 16);
            this.chkXMLRW.TabIndex = 19;
            this.chkXMLRW.Text = "支持XML序列化和反序列化";
            this.chkXMLRW.UseVisualStyleBackColor = true;
            // 
            // rbGrove
            // 
            this.rbGrove.AutoSize = true;
            this.rbGrove.Location = new System.Drawing.Point(30, 135);
            this.rbGrove.Name = "rbGrove";
            this.rbGrove.Size = new System.Drawing.Size(257, 16);
            this.rbGrove.TabIndex = 18;
            this.rbGrove.TabStop = true;
            this.rbGrove.Text = "生成Grove的Model(使用了字符串内存映射 )";
            this.rbGrove.UseVisualStyleBackColor = true;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(435, 260);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPath.TabIndex = 17;
            this.btnSelectPath.Text = "浏览";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(40, 260);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(374, 21);
            this.txtPath.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(38, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "不要使用任何看起来不限制大小的类型";
            // 
            // chkModelForUI
            // 
            this.chkModelForUI.AutoSize = true;
            this.chkModelForUI.Checked = true;
            this.chkModelForUI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModelForUI.Location = new System.Drawing.Point(239, 205);
            this.chkModelForUI.Name = "chkModelForUI";
            this.chkModelForUI.Size = new System.Drawing.Size(234, 16);
            this.chkModelForUI.TabIndex = 14;
            this.chkModelForUI.Text = "生成复杂Model，以便用于生成和处理UI";
            this.chkModelForUI.UseVisualStyleBackColor = true;
            // 
            // chkAddMore
            // 
            this.chkAddMore.AutoSize = true;
            this.chkAddMore.Checked = true;
            this.chkAddMore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddMore.Location = new System.Drawing.Point(40, 205);
            this.chkAddMore.Name = "chkAddMore";
            this.chkAddMore.Size = new System.Drawing.Size(180, 16);
            this.chkAddMore.TabIndex = 13;
            this.chkAddMore.Text = "针对高级程序员添加更多支持";
            this.chkAddMore.UseVisualStyleBackColor = true;
            // 
            // chkGenMore
            // 
            this.chkGenMore.AutoSize = true;
            this.chkGenMore.Location = new System.Drawing.Point(40, 238);
            this.chkGenMore.Name = "chkGenMore";
            this.chkGenMore.Size = new System.Drawing.Size(312, 16);
            this.chkGenMore.TabIndex = 12;
            this.chkGenMore.Text = "生成针对.Net的Model的同时生成针对其它语言的Model";
            this.chkGenMore.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 11;
            // 
            // rbDotNetAndC
            // 
            this.rbDotNetAndC.AutoSize = true;
            this.rbDotNetAndC.Location = new System.Drawing.Point(30, 96);
            this.rbDotNetAndC.Name = "rbDotNetAndC";
            this.rbDotNetAndC.Size = new System.Drawing.Size(407, 16);
            this.rbDotNetAndC.TabIndex = 9;
            this.rbDotNetAndC.Text = ".Net 和 C(用于.Net应用和C语言(GCC)应用的交互,使用字符串内存隐射)";
            this.rbDotNetAndC.UseVisualStyleBackColor = true;
            // 
            // rbDotNetAndDotNet
            // 
            this.rbDotNetAndDotNet.AutoSize = true;
            this.rbDotNetAndDotNet.Checked = true;
            this.rbDotNetAndDotNet.Location = new System.Drawing.Point(30, 63);
            this.rbDotNetAndDotNet.Name = "rbDotNetAndDotNet";
            this.rbDotNetAndDotNet.Size = new System.Drawing.Size(245, 16);
            this.rbDotNetAndDotNet.TabIndex = 8;
            this.rbDotNetAndDotNet.TabStop = true;
            this.rbDotNetAndDotNet.Text = ".Net环境(用于纯.Net应用间的数据交换) ";
            this.rbDotNetAndDotNet.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "您的Model针对何种模式";
            // 
            // tpUI
            // 
            this.tpUI.Controls.Add(this.btnDelete);
            this.tpUI.Controls.Add(this.btnAdd);
            this.tpUI.Controls.Add(this.lstDllUsing);
            this.tpUI.Location = new System.Drawing.Point(4, 22);
            this.tpUI.Name = "tpUI";
            this.tpUI.Padding = new System.Windows.Forms.Padding(3);
            this.tpUI.Size = new System.Drawing.Size(597, 312);
            this.tpUI.TabIndex = 2;
            this.tpUI.Text = "UI和组件";
            this.tpUI.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.autoversetting);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 312);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "项目高级配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // autoversetting
            // 
            this.autoversetting.BackColor = System.Drawing.Color.Transparent;
            this.autoversetting.Location = new System.Drawing.Point(6, 6);
            this.autoversetting.Name = "autoversetting";
            this.autoversetting.Setting = null;
            this.autoversetting.Size = new System.Drawing.Size(373, 294);
            this.autoversetting.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.settingCodeDomProvider1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 312);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "设置CodeDomProvider";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // settingCodeDomProvider1
            // 
            this.settingCodeDomProvider1.Location = new System.Drawing.Point(3, 6);
            this.settingCodeDomProvider1.Name = "settingCodeDomProvider1";
            this.settingCodeDomProvider1.Size = new System.Drawing.Size(598, 301);
            this.settingCodeDomProvider1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.nunitOptions1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 312);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "单元测试";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nunitOptions1
            // 
            this.nunitOptions1.Location = new System.Drawing.Point(66, 21);
            this.nunitOptions1.Name = "nunitOptions1";
            this.nunitOptions1.Size = new System.Drawing.Size(428, 247);
            this.nunitOptions1.TabIndex = 0;
            // 
            // lstDllUsing
            // 
            this.lstDllUsing.FormattingEnabled = true;
            this.lstDllUsing.ItemHeight = 12;
            this.lstDllUsing.Location = new System.Drawing.Point(6, 220);
            this.lstDllUsing.Name = "lstDllUsing";
            this.lstDllUsing.Size = new System.Drawing.Size(488, 76);
            this.lstDllUsing.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(500, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 37);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加引用..";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(500, 263);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 33);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmSlnConfig
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(629, 398);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSlnConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置结局方案";
            this.Load += new System.EventHandler(this.frmSlnConfig_Load);
            this.tabMain.ResumeLayout(false);
            this.tpCommon.ResumeLayout(false);
            this.tpCommon.PerformLayout();
            this.tpModel.ResumeLayout(false);
            this.tpModel.PerformLayout();
            this.tpUI.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private KeelKit.Controls.BuildConnectString bcsCs;
        private KeelKit.Controls.cbxProjects cbxDALPjt;
        private KeelKit.Controls.cbxProjects cbxModelPjt;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpCommon;
        private System.Windows.Forms.TabPage tpModel;
        private System.Windows.Forms.Label label5;
        private KeelKit.Controls.cbxProjects cbxUiPjt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkAddMore;
        private System.Windows.Forms.CheckBox chkGenMore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbDotNetAndC;
        private System.Windows.Forms.RadioButton rbDotNetAndDotNet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tpUI;
        private System.Windows.Forms.CheckBox chkModelForUI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label13;
        private KeelKit.Controls.cbxProjects cbxCmpntPjt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage1;
        private KeelKit.AutoVersion.av_ctlSetting autoversetting;
        private System.Windows.Forms.RadioButton rbGrove;
        private System.Windows.Forms.TabPage tabPage2;
        private KeelKit.ModelFactory.SettingCodeDomProvider settingCodeDomProvider1;
        private System.Windows.Forms.TabPage tabPage3;
        private KeelKit.Nunit.NunitOptions nunitOptions1;
        private System.Windows.Forms.CheckBox chkXMLRW;
        private System.Windows.Forms.ListBox lstDllUsing;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;

    }
}