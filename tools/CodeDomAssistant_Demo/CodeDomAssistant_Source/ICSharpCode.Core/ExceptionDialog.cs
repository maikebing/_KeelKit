namespace ICSharpCode.Core
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ExceptionDialog : Form
    {
        private Button btnClose;
        private Container components;
        private RichTextBox details;
        private Label label1;
        private System.Exception m_exException;
        private string m_message;
        private RichTextBox messagebox;
        private LinkLabel showDetails;

        public ExceptionDialog()
        {
            this.m_message = string.Empty;
            this.InitializeComponent();
        }

        public ExceptionDialog(System.Exception exException, string message)
        {
            this.m_message = string.Empty;
            this.InitializeComponent();
            this.m_exException = exException;
            this.m_message = message;
            this.ViewExceptionInWindow();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void HideDetails()
        {
            this.showDetails.Text = "Show Details";
            this.details.Visible = false;
            base.Height = this.showDetails.Bottom + 0x39;
            this.Refresh();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.showDetails = new System.Windows.Forms.LinkLabel();
            this.messagebox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // details
            // 
            this.details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.details.Location = new System.Drawing.Point(10, 118);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(631, 382);
            this.details.TabIndex = 5;
            this.details.Text = "";
            this.details.WordWrap = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(296, 518);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // showDetails
            // 
            this.showDetails.AutoSize = true;
            this.showDetails.Location = new System.Drawing.Point(12, 87);
            this.showDetails.Name = "showDetails";
            this.showDetails.Size = new System.Drawing.Size(77, 12);
            this.showDetails.TabIndex = 6;
            this.showDetails.TabStop = true;
            this.showDetails.Text = "Hide Details";
            this.showDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.showDetails_LinkClicked);
            // 
            // messagebox
            // 
            this.messagebox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.messagebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messagebox.Location = new System.Drawing.Point(15, 11);
            this.messagebox.Name = "messagebox";
            this.messagebox.ReadOnly = true;
            this.messagebox.Size = new System.Drawing.Size(632, 73);
            this.messagebox.TabIndex = 7;
            this.messagebox.Text = "";
            // 
            // ExceptionDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(661, 550);
            this.Controls.Add(this.details);
            this.Controls.Add(this.messagebox);
            this.Controls.Add(this.showDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ShowDetails()
        {
            this.showDetails.Text = "Hide Details";
            this.details.Visible = true;
            base.Height = this.showDetails.Bottom + 300;
            this.Refresh();
        }

        private void showDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ToggleDetails();
        }

        public static void ShowException(IWin32Window owner, System.Exception ex, string message)
        {
            new ExceptionDialog(ex, message).ShowDialog(owner);
        }

        private void ToggleDetails()
        {
            if (!this.details.Visible)
            {
                this.ShowDetails();
            }
            else
            {
                this.HideDetails();
            }
        }

        public void ViewExceptionInWindow()
        {
            string message = this.m_message;
            if ((message == null) || (message.Length == 0))
            {
                if (this.m_exException == null)
                {
                    message = "No exception loaded into window: can't visualize exception";
                }
                else
                {
                    message = this.m_exException.Message;
                }
            }
            this.messagebox.Text = message;
            System.Exception exException = this.m_exException;
            while (exException != null)
            {
                this.details.SelectionColor = Color.Red;
                this.details.SelectedText = exException.Message;
                this.details.SelectedText = Environment.NewLine;
                this.details.SelectionColor = Color.Blue;
                this.details.SelectedText = exException.StackTrace.Replace(Environment.NewLine, "\t" + Environment.NewLine);
                exException = exException.InnerException;
                if (exException != null)
                {
                    this.details.SelectedText = Environment.NewLine;
                }
            }
            this.HideDetails();
        }

        public System.Exception Exception
        {
            set
            {
                this.m_exException = value;
            }
        }
    }
}

