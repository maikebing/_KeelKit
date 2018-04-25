namespace CodeDomAssistant
{
    using ICSharpCode.Core;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormCodeDomProviderAssemblies : Form
    {
        private Hashtable assemblies = new Hashtable();
        private DataGridView assemblyDataGridView;
        private Button buttonCancel;
        private Button buttonOk;
        private Container components;
        private Label labelProgress;
        private Progress progress = new Progress();
        private System.Type subclass = typeof(object);
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAssembly;
        private ToolStripButton toolStripButtonRefresh;

        public FormCodeDomProviderAssemblies()
        {
            this.InitializeComponent();
            this.progress.NotifyProgress += new NotifyProgessHandler(this.progress_NotifyProgress);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (((DataView) this.assemblyDataGridView.DataSource).Table.DataSet.HasChanges())
                {
                    DynProvider.SaveAssemblyInfo(((DataView) this.assemblyDataGridView.DataSource).Table.DataSet);
                }
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormCodeDomProviderAssemblies));
            this.toolStrip1 = new ToolStrip();
            this.toolStripButtonAssembly = new ToolStripButton();
            this.toolStripButtonRefresh = new ToolStripButton();
            this.assemblyDataGridView = new DataGridView();
            this.buttonOk = new Button();
            this.buttonCancel = new Button();
            this.labelProgress = new Label();
            this.toolStrip1.SuspendLayout();
            ((ISupportInitialize) this.assemblyDataGridView).BeginInit();
            base.SuspendLayout();
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripButtonAssembly, this.toolStripButtonRefresh });
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(790, 0x19);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStripButtonAssembly.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAssembly.ImageTransparentColor = Color.Magenta;
            this.toolStripButtonAssembly.Name = "toolStripButtonAssembly";
            this.toolStripButtonAssembly.Size = new Size(0x3b, 0x16);
            this.toolStripButtonAssembly.Text = "Browse";
            this.toolStripButtonAssembly.ToolTipText = "Browse For CodeDomProvider Assembly";
            this.toolStripButtonAssembly.Click += new EventHandler(this.toolStripButtonAssembly_Click);
            this.toolStripButtonRefresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRefresh.Image = (Image) manager.GetObject("toolStripButtonRefresh.Image");
            this.toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new Size(0x3e, 0x16);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.ToolTipText = "Refresh CodeDomProvider List";
            this.toolStripButtonRefresh.Click += new EventHandler(this.toolStripButtonRefresh_Click);
            this.assemblyDataGridView.AllowUserToAddRows = false;
            this.assemblyDataGridView.AllowUserToDeleteRows = false;
            this.assemblyDataGridView.AllowUserToOrderColumns = true;
            this.assemblyDataGridView.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.assemblyDataGridView.BackgroundColor = SystemColors.Window;
            this.assemblyDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.assemblyDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assemblyDataGridView.Location = new Point(0, 0x19);
            this.assemblyDataGridView.Name = "assemblyDataGridView";
            this.assemblyDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.assemblyDataGridView.RowTemplate.Height = 0x18;
            this.assemblyDataGridView.Size = new Size(790, 0x1b2);
            this.assemblyDataGridView.TabIndex = 2;
            this.buttonOk.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOk.Location = new Point(0x20c, 0x1d9);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new Size(110, 0x24);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.Location = new Point(0x290, 0x1d9);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(110, 0x24);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.labelProgress.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new Point(9, 0x1d5);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new Size(0, 0x11);
            this.labelProgress.TabIndex = 5;
            this.AutoScaleBaseSize = new Size(6, 15);
            base.ClientSize = new Size(790, 0x20c);
            base.Controls.Add(this.labelProgress);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOk);
            base.Controls.Add(this.assemblyDataGridView);
            base.Controls.Add(this.toolStrip1);
            base.Name = "FormCodeDomProviderAssemblies";
            base.ShowInTaskbar = false;
            this.Text = "CodeDomProvider Assemblies";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((ISupportInitialize) this.assemblyDataGridView).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void LoadAssemblies(bool refreshcache)
        {
            DataSet assemblyInfo = DynProvider.GetAssemblyInfo();
            DynProvider.MergeGAC(assemblyInfo, refreshcache, this.progress);
            if (refreshcache)
            {
                foreach (DataRow row in assemblyInfo.Tables[0].Select("IsGAC = 0"))
                {
                    DynProvider.MergeLocal(assemblyInfo, row["Path"].ToString(), this.progress);
                }
            }
            this.progress.Message = string.Empty;
            this.progress.Notify();
            DataView view = new DataView(assemblyInfo.Tables[0]);
            view.RowFilter = "HasProvider = 1";
            this.assemblyDataGridView.AutoGenerateColumns = false;
            this.assemblyDataGridView.DataSource = view;
            DataGridViewCheckBoxColumn dataGridViewColumn = new DataGridViewCheckBoxColumn();
            dataGridViewColumn.DataPropertyName = "Load";
            dataGridViewColumn.HeaderText = "Load";
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.DataPropertyName = "Name";
            column2.HeaderText = "Name";
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column2.ReadOnly = false;
            this.assemblyDataGridView.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            this.assemblyDataGridView.Columns.Clear();
            this.assemblyDataGridView.Columns.Add(dataGridViewColumn);
            this.assemblyDataGridView.Columns.Add(column2);
            this.assemblyDataGridView.AllowUserToResizeRows = false;
        }

        private void progress_NotifyProgress(Progress progress)
        {
            this.labelProgress.Text = progress.Message;
            this.labelProgress.Update();
        }

        private void toolStripButtonAssembly_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog dialog = new OpenFileDialog();
                dialog.DefaultExt = ".dll";
                dialog.Title = "Open CodeDomProvider DLL";
                dialog.SupportMultiDottedExtensions = true;
                dialog.Filter = "CodeDomProvider DLL (*.dll)|*.dll|All files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string str in dialog.FileNames)
                    {
                        DynProvider.MergeLocal(((DataView) this.assemblyDataGridView.DataSource).Table.DataSet, str, null);
                    }
                }
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadAssemblies(true);
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
        }
    }
}

