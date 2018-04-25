namespace KeelKit.FormFactory
{
    partial class frmDIY
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
            this.chkTableList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstFieldList = new System.Windows.Forms.CheckedListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtclass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkCheckall = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkTableList
            // 
            this.chkTableList.FormattingEnabled = true;
            this.chkTableList.Location = new System.Drawing.Point(26, 34);
            this.chkTableList.Name = "chkTableList";
            this.chkTableList.Size = new System.Drawing.Size(374, 20);
            this.chkTableList.TabIndex = 0;
            this.chkTableList.SelectedIndexChanged += new System.EventHandler(this.chkTableList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择要使用的表";
            // 
            // lstFieldList
            // 
            this.lstFieldList.CheckOnClick = true;
            this.lstFieldList.FormattingEnabled = true;
            this.lstFieldList.Location = new System.Drawing.Point(26, 82);
            this.lstFieldList.Name = "lstFieldList";
            this.lstFieldList.Size = new System.Drawing.Size(374, 244);
            this.lstFieldList.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(121, 354);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(127, 39);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtclass
            // 
            this.txtclass.Location = new System.Drawing.Point(78, 58);
            this.txtclass.Name = "txtclass";
            this.txtclass.Size = new System.Drawing.Size(322, 21);
            this.txtclass.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "类命";
            // 
            // checkCheckall
            // 
            this.checkCheckall.AutoSize = true;
            this.checkCheckall.Location = new System.Drawing.Point(322, 332);
            this.checkCheckall.Name = "checkCheckall";
            this.checkCheckall.Size = new System.Drawing.Size(78, 16);
            this.checkCheckall.TabIndex = 7;
            this.checkCheckall.Text = "全选/反选";
            this.checkCheckall.UseVisualStyleBackColor = true;
            this.checkCheckall.CheckedChanged += new System.EventHandler(this.checkCheckall_CheckedChanged);
            // 
            // frmDIY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 405);
            this.Controls.Add(this.checkCheckall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtclass);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lstFieldList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTableList);
            this.Name = "frmDIY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义生成控件";
            this.Load += new System.EventHandler(this.frmDIY_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chkTableList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox lstFieldList;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtclass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkCheckall;
    }
}