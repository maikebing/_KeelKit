namespace KeelKit.Dialogs
{
    partial class frmSqlStr2Class
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtViewName = new System.Windows.Forms.TextBox();
            this.txtSQL = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(256, 306);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "生成(&B)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(402, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "视图名称:";
            // 
            // txtViewName
            // 
            this.txtViewName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViewName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KeelKit.Properties.Settings.Default, "frmSqlStr2Class_ViewName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtViewName.Location = new System.Drawing.Point(77, 26);
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.Size = new System.Drawing.Size(423, 21);
            this.txtViewName.TabIndex = 3;
            // 
            // txtSQL
            // 
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.AutoScroll = true;
            this.txtSQL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSQL.ConvertTabsToSpaces = true;
            this.txtSQL.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KeelKit.Properties.Settings.Default, "frmSqlStr2Class_SQL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSQL.IsIconBarVisible = true;
            this.txtSQL.IsReadOnly = false;
            this.txtSQL.Location = new System.Drawing.Point(14, 53);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(486, 246);
            this.txtSQL.TabIndex = 5;
            // 
            // frmSqlStr2Class
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(523, 345);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtViewName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSQL);
            this.Name = "frmSqlStr2Class";
            this.Text = "SQL语句类型化器";
            this.Load += new System.EventHandler(this.frmSqlStr2Class_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtViewName;
        private System.Windows.Forms.Label label1;
        private ICSharpCode.TextEditor.TextEditorControl txtSQL;
    }
}