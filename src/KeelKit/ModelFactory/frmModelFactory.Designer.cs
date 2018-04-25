namespace KeelKit.Dialogs
{
    partial class frmModelFactory
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenCode = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnGenCodeForC = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkViewList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBuildDBHelper = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkTableList
            // 
            this.chkTableList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTableList.CheckOnClick = true;
            this.chkTableList.FormattingEnabled = true;
            this.chkTableList.Location = new System.Drawing.Point(15, 42);
            this.chkTableList.Name = "chkTableList";
            this.chkTableList.Size = new System.Drawing.Size(282, 324);
            this.chkTableList.TabIndex = 0;
            this.chkTableList.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.chkTableList_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择您欲生成Model的表";
            // 
            // btnGenCode
            // 
            this.btnGenCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenCode.Location = new System.Drawing.Point(332, 345);
            this.btnGenCode.Name = "btnGenCode";
            this.btnGenCode.Size = new System.Drawing.Size(106, 34);
            this.btnGenCode.TabIndex = 2;
            this.btnGenCode.Text = "生成代码(&C)";
            this.btnGenCode.UseVisualStyleBackColor = true;
            this.btnGenCode.Click += new System.EventHandler(this.btnGenCode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(457, 345);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 34);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(457, 263);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 33);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "刷新数据库信息(F5)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnGenCodeForC
            // 
            this.btnGenCodeForC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenCodeForC.Location = new System.Drawing.Point(332, 263);
            this.btnGenCodeForC.Name = "btnGenCodeForC";
            this.btnGenCodeForC.Size = new System.Drawing.Size(106, 33);
            this.btnGenCodeForC.TabIndex = 8;
            this.btnGenCodeForC.Text = "生成C语言Model";
            this.btnGenCodeForC.UseVisualStyleBackColor = true;
            this.btnGenCodeForC.Click += new System.EventHandler(this.btnGenCodeForC_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(15, 375);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(78, 16);
            this.chkSelectAll.TabIndex = 9;
            this.chkSelectAll.Text = "全选/反选";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkViewList
            // 
            this.chkViewList.CheckOnClick = true;
            this.chkViewList.FormattingEnabled = true;
            this.chkViewList.Location = new System.Drawing.Point(325, 42);
            this.chkViewList.Name = "chkViewList";
            this.chkViewList.Size = new System.Drawing.Size(255, 196);
            this.chkViewList.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "请选择您欲生成Model的视图";
            // 
            // chkBuildDBHelper
            // 
            this.chkBuildDBHelper.AutoSize = true;
            this.chkBuildDBHelper.Location = new System.Drawing.Point(341, 323);
            this.chkBuildDBHelper.Name = "chkBuildDBHelper";
            this.chkBuildDBHelper.Size = new System.Drawing.Size(108, 16);
            this.chkBuildDBHelper.TabIndex = 12;
            this.chkBuildDBHelper.Text = "生成DBHelper类";
            this.chkBuildDBHelper.UseVisualStyleBackColor = true;
            // 
            // frmModelFactory
            // 
            this.AcceptButton = this.btnGenCode;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(605, 403);
            this.Controls.Add(this.chkBuildDBHelper);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkViewList);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnGenCodeForC);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTableList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmModelFactory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model生成器";
            this.Load += new System.EventHandler(this.frmModelFactory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkTableList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGenCodeForC;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.CheckedListBox chkViewList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBuildDBHelper;

    }
}