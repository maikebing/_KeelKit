﻿namespace WindowsFormsApplication2
{
    partial class ctl_music_Keel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblid = new System.Windows.Forms.Label();
            this.nudid = new System.Windows.Forms.NumericUpDown();
            this.lbltitle = new System.Windows.Forms.Label();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.lblurl = new System.Windows.Forms.Label();
            this.txturl = new System.Windows.Forms.TextBox();
            this.lblclick = new System.Windows.Forms.Label();
            this.nudclick = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudclick)).BeginInit();
            this.SuspendLayout();
            // 
            // lblid
            // 
            this.lblid.Location = new System.Drawing.Point(20, 30);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(100, 23);
            this.lblid.TabIndex = 0;
            this.lblid.Text = "id";
            // 
            // nudid
            // 
            this.nudid.Location = new System.Drawing.Point(150, 30);
            this.nudid.Name = "nudid";
            this.nudid.Size = new System.Drawing.Size(120, 21);
            this.nudid.TabIndex = 1;
            // 
            // lbltitle
            // 
            this.lbltitle.Location = new System.Drawing.Point(320, 30);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(100, 23);
            this.lbltitle.TabIndex = 2;
            this.lbltitle.Text = "title";
            // 
            // txttitle
            // 
            this.txttitle.Location = new System.Drawing.Point(450, 30);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(100, 21);
            this.txttitle.TabIndex = 2;
            // 
            // lblurl
            // 
            this.lblurl.Location = new System.Drawing.Point(20, 60);
            this.lblurl.Name = "lblurl";
            this.lblurl.Size = new System.Drawing.Size(100, 23);
            this.lblurl.TabIndex = 3;
            this.lblurl.Text = "url";
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(150, 60);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(100, 21);
            this.txturl.TabIndex = 3;
            // 
            // lblclick
            // 
            this.lblclick.Location = new System.Drawing.Point(320, 60);
            this.lblclick.Name = "lblclick";
            this.lblclick.Size = new System.Drawing.Size(100, 23);
            this.lblclick.TabIndex = 4;
            this.lblclick.Text = "click";
            // 
            // nudclick
            // 
            this.nudclick.Location = new System.Drawing.Point(450, 60);
            this.nudclick.Name = "nudclick";
            this.nudclick.Size = new System.Drawing.Size(120, 21);
            this.nudclick.TabIndex = 4;
            // 
            // ctl_music_Keel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.nudid);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.lblurl);
            this.Controls.Add(this.txturl);
            this.Controls.Add(this.lblclick);
            this.Controls.Add(this.nudclick);
            this.Name = "ctl_music_Keel";
            this.Size = new System.Drawing.Size(620, 131);
            ((System.ComponentModel.ISupportInitialize)(this.nudid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudclick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblid;
        public System.Windows.Forms.NumericUpDown nudid;
        public System.Windows.Forms.Label lbltitle;
        public System.Windows.Forms.TextBox txttitle;
        public System.Windows.Forms.Label lblurl;
        public System.Windows.Forms.TextBox txturl;
        public System.Windows.Forms.Label lblclick;
        public System.Windows.Forms.NumericUpDown nudclick;
    }
}
