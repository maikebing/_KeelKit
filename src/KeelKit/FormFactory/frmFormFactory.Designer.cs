namespace KeelKit.Dialogs
{
    partial class frmFormFactory
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
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkForInherit = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkViewList = new System.Windows.Forms.CheckedListBox();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
     
            // 
            // chkTableList
            // 
            this.chkTableList.FormattingEnabled = true;
            this.chkTableList.Location = new System.Drawing.Point(12, 33);
            this.chkTableList.Name = "chkTableList";
            this.chkTableList.Size = new System.Drawing.Size(369, 180);
            this.chkTableList.TabIndex = 0;
            this.chkTableList.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.chkTableList_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择您欲生成Model的表";
            // 
            // btnGenCode
            // 
            this.btnGenCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenCode.Location = new System.Drawing.Point(433, 287);
            this.btnGenCode.Name = "btnGenCode";
            this.btnGenCode.Size = new System.Drawing.Size(123, 34);
            this.btnGenCode.TabIndex = 2;
            this.btnGenCode.Text = "生成控件(&C)";
            this.btnGenCode.UseVisualStyleBackColor = true;
            this.btnGenCode.Click += new System.EventHandler(this.btnGenCode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(433, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(426, 181);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 33);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "刷新数据库信息(F5)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(14, 219);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(78, 16);
            this.chkSelectAll.TabIndex = 9;
            this.chkSelectAll.Text = "全选/反选";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkForInherit
            // 
            this.chkForInherit.AutoSize = true;
            this.chkForInherit.Location = new System.Drawing.Point(436, 327);
            this.chkForInherit.Name = "chkForInherit";
            this.chkForInherit.Size = new System.Drawing.Size(120, 16);
            this.chkForInherit.TabIndex = 10;
            this.chkForInherit.Text = "我要需要继承控件";
            this.chkForInherit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "请选择您欲生成Model的视图";
            // 
            // chkViewList
            // 
            this.chkViewList.CheckOnClick = true;
            this.chkViewList.FormattingEnabled = true;
            this.chkViewList.Location = new System.Drawing.Point(12, 265);
            this.chkViewList.Name = "chkViewList";
            this.chkViewList.Size = new System.Drawing.Size(373, 164);
            this.chkViewList.TabIndex = 12;
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Location = new System.Drawing.Point(14, 435);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(78, 16);
            this.chkView.TabIndex = 14;
            this.chkView.Text = "全选/反选";
            this.chkView.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(424, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.Text = "默认";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "选择生成模板";
            // 
            // chkDevExpress
            // 
           
            // 
            this.AcceptButton = this.btnGenCode;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(579, 458);
    
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.chkTableList);
            this.Controls.Add(this.chkView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkForInherit);
            this.Controls.Add(this.chkViewList);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmFormFactory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表单生成器";
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
        private System.Windows.Forms.CheckBox chkSelectAll;
        public System.Windows.Forms.CheckBox chkForInherit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkViewList;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        #if ENABLEDevExpress 
                  private DevExpress.XtraEditors.CheckEdit chkDevExpress;
#else
 
#endif 
      

    }
}