namespace KeelKit.DocBuilter
{
    partial class frmBuilder
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
            this.chkTableList = new System.Windows.Forms.CheckedListBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDocHeader = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkTableList
            // 
            this.chkTableList.CheckOnClick = true;
            this.chkTableList.FormattingEnabled = true;
            this.chkTableList.Location = new System.Drawing.Point(17, 37);
            this.chkTableList.Name = "chkTableList";
            this.chkTableList.Size = new System.Drawing.Size(211, 292);
            this.chkTableList.TabIndex = 1;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(17, 331);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(78, 16);
            this.chkSelectAll.TabIndex = 10;
            this.chkSelectAll.Text = "全选/反选";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "请选择您欲生成文档的表";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(259, 228);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(131, 33);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "刷新数据库信息(F5)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(416, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 34);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDocHeader
            // 
            this.txtDocHeader.Location = new System.Drawing.Point(261, 61);
            this.txtDocHeader.Name = "txtDocHeader";
            this.txtDocHeader.Size = new System.Drawing.Size(278, 21);
            this.txtDocHeader.TabIndex = 20;
            this.txtDocHeader.Text = "本文挡由KeelKit生成";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "页眉内容";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(259, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(131, 34);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "生成";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(259, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 104);
            this.label2.TabIndex = 24;
            this.label2.Text = "程序将自动生成Word97-Word2003的Doc格式,无论您安装的是何种版本的Office\r\n生成过程会在VS的状态栏和输出窗口中显示!";
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Location = new System.Drawing.Point(428, 244);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(84, 16);
            this.chkOpen.TabIndex = 25;
            this.chkOpen.Text = "生成后打开";
            this.chkOpen.UseVisualStyleBackColor = true;
            // 
            // frmBuilder
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(597, 377);
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtDocHeader);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkTableList);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库文档生成器";
            this.Load += new System.EventHandler(this.frmBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkTableList;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDocHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkOpen;
    }
}