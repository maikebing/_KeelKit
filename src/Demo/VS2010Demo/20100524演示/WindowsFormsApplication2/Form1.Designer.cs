namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.ctl_images_Keel1 = new WindowsFormsApplication2.ctl_images_Keel();
            this.SuspendLayout();
            // 
            // ctl_images_Keel1
            // 
            this.ctl_images_Keel1.Location = new System.Drawing.Point(23, 62);
            this.ctl_images_Keel1.Name = "ctl_images_Keel1";
            this.ctl_images_Keel1.Size = new System.Drawing.Size(620, 161);
            this.ctl_images_Keel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 269);
            this.Controls.Add(this.ctl_images_Keel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ctl_images_Keel ctl_images_Keel1;
    }
}

