namespace KeelKit.StoredProcedureFactory
{
    partial class frmSPFactory
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
            this.chkSPList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRef = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pty = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // chkSPList
            // 
            this.chkSPList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSPList.FormattingEnabled = true;
            this.chkSPList.Location = new System.Drawing.Point(14, 37);
            this.chkSPList.Name = "chkSPList";
            this.chkSPList.Size = new System.Drawing.Size(336, 260);
            this.chkSPList.TabIndex = 0;
            this.chkSPList.SelectedIndexChanged += new System.EventHandler(this.chkSPList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "存储过程列表";
            // 
            // btnRef
            // 
            this.btnRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRef.Location = new System.Drawing.Point(215, 303);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(135, 45);
            this.btnRef.TabIndex = 2;
            this.btnRef.Text = "刷新存储过程信息(&R)";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Location = new System.Drawing.Point(407, 305);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(110, 41);
            this.btnBuild.TabIndex = 3;
            this.btnBuild.Text = "生成(&B)";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(532, 305);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 41);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkSelect
            // 
            this.chkSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(14, 318);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(78, 16);
            this.chkSelect.TabIndex = 5;
            this.chkSelect.Text = "全选/反选";
            this.chkSelect.UseVisualStyleBackColor = true;
            this.chkSelect.Click += new System.EventHandler(this.chkSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "目前不支持MSSQL2000";
            // 
            // pty
            // 
            this.pty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pty.Location = new System.Drawing.Point(356, 45);
            this.pty.Name = "pty";
            this.pty.Size = new System.Drawing.Size(278, 254);
            this.pty.TabIndex = 7;
            this.pty.SelectedObjectsChanged += new System.EventHandler(this.pty_SelectedObjectsChanged);
            this.pty.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pty_PropertyValueChanged);
            // 
            // frmSPFactory
            // 
            this.AcceptButton = this.btnBuild;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(655, 353);
            this.Controls.Add(this.pty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.btnRef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSPList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSPFactory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "存储过程生成器";
            this.Load += new System.EventHandler(this.frmSPFactory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkSPList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PropertyGrid pty;

    }
}