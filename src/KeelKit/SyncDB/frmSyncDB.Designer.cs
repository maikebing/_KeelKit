namespace KeelKit.SyncDB
{
    partial class frmSyncDB
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ttablenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttabledescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldindexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tidentityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttablekeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldbitcountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldlenghtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldscaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldcannullDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfielddefaultvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfielddescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldiscomputedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sQLTableInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buildConnectString1 = new KeelKit.Controls.BuildConnectString();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ttablenameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttabledescDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldindexDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldnameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tidentityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttablekeyDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldtypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldbitcountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldlenghtDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldscaleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldcannullDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfielddefaultvalueDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfielddescDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfieldiscomputedDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sQLTableInfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buildConnectString2 = new KeelKit.Controls.BuildConnectString();
            this.btnReadDBInfo = new System.Windows.Forms.Button();
            this.btnCmp = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLTableInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLTableInfoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请选择源数据库";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请选择目标数据库";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.buildConnectString1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.buildConnectString2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(634, 332);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ttablenameDataGridViewTextBoxColumn,
            this.ttabledescDataGridViewTextBoxColumn,
            this.tfieldindexDataGridViewTextBoxColumn,
            this.tfieldnameDataGridViewTextBoxColumn,
            this.tidentityDataGridViewTextBoxColumn,
            this.ttablekeyDataGridViewTextBoxColumn,
            this.tfieldtypeDataGridViewTextBoxColumn,
            this.tfieldbitcountDataGridViewTextBoxColumn,
            this.tfieldlenghtDataGridViewTextBoxColumn,
            this.tfieldscaleDataGridViewTextBoxColumn,
            this.tfieldcannullDataGridViewTextBoxColumn,
            this.tfielddefaultvalueDataGridViewTextBoxColumn,
            this.tfielddescDataGridViewTextBoxColumn,
            this.tfieldiscomputedDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sQLTableInfoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(309, 289);
            this.dataGridView1.TabIndex = 0;
            // 
            // ttablenameDataGridViewTextBoxColumn
            // 
            this.ttablenameDataGridViewTextBoxColumn.DataPropertyName = "t_tablename";
            this.ttablenameDataGridViewTextBoxColumn.HeaderText = "t_tablename";
            this.ttablenameDataGridViewTextBoxColumn.Name = "ttablenameDataGridViewTextBoxColumn";
            this.ttablenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ttabledescDataGridViewTextBoxColumn
            // 
            this.ttabledescDataGridViewTextBoxColumn.DataPropertyName = "t_tabledesc";
            this.ttabledescDataGridViewTextBoxColumn.HeaderText = "t_tabledesc";
            this.ttabledescDataGridViewTextBoxColumn.Name = "ttabledescDataGridViewTextBoxColumn";
            this.ttabledescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfieldindexDataGridViewTextBoxColumn
            // 
            this.tfieldindexDataGridViewTextBoxColumn.DataPropertyName = "t_fieldindex";
            this.tfieldindexDataGridViewTextBoxColumn.HeaderText = "t_fieldindex";
            this.tfieldindexDataGridViewTextBoxColumn.Name = "tfieldindexDataGridViewTextBoxColumn";
            this.tfieldindexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfieldnameDataGridViewTextBoxColumn
            // 
            this.tfieldnameDataGridViewTextBoxColumn.DataPropertyName = "t_fieldname";
            this.tfieldnameDataGridViewTextBoxColumn.HeaderText = "t_fieldname";
            this.tfieldnameDataGridViewTextBoxColumn.Name = "tfieldnameDataGridViewTextBoxColumn";
            this.tfieldnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tidentityDataGridViewTextBoxColumn
            // 
            this.tidentityDataGridViewTextBoxColumn.DataPropertyName = "t_identity";
            this.tidentityDataGridViewTextBoxColumn.HeaderText = "t_identity";
            this.tidentityDataGridViewTextBoxColumn.Name = "tidentityDataGridViewTextBoxColumn";
            this.tidentityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ttablekeyDataGridViewTextBoxColumn
            // 
            this.ttablekeyDataGridViewTextBoxColumn.DataPropertyName = "t_tablekey";
            this.ttablekeyDataGridViewTextBoxColumn.HeaderText = "t_tablekey";
            this.ttablekeyDataGridViewTextBoxColumn.Name = "ttablekeyDataGridViewTextBoxColumn";
            this.ttablekeyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfieldtypeDataGridViewTextBoxColumn
            // 
            this.tfieldtypeDataGridViewTextBoxColumn.DataPropertyName = "t_fieldtype";
            this.tfieldtypeDataGridViewTextBoxColumn.HeaderText = "t_fieldtype";
            this.tfieldtypeDataGridViewTextBoxColumn.Name = "tfieldtypeDataGridViewTextBoxColumn";
            this.tfieldtypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfieldbitcountDataGridViewTextBoxColumn
            // 
            this.tfieldbitcountDataGridViewTextBoxColumn.DataPropertyName = "t_fieldbitcount";
            this.tfieldbitcountDataGridViewTextBoxColumn.HeaderText = "t_fieldbitcount";
            this.tfieldbitcountDataGridViewTextBoxColumn.Name = "tfieldbitcountDataGridViewTextBoxColumn";
            this.tfieldbitcountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfieldlenghtDataGridViewTextBoxColumn
            // 
            this.tfieldlenghtDataGridViewTextBoxColumn.DataPropertyName = "t_fieldlenght";
            this.tfieldlenghtDataGridViewTextBoxColumn.HeaderText = "t_fieldlenght";
            this.tfieldlenghtDataGridViewTextBoxColumn.Name = "tfieldlenghtDataGridViewTextBoxColumn";
            this.tfieldlenghtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfieldscaleDataGridViewTextBoxColumn
            // 
            this.tfieldscaleDataGridViewTextBoxColumn.DataPropertyName = "t_fieldscale";
            this.tfieldscaleDataGridViewTextBoxColumn.HeaderText = "t_fieldscale";
            this.tfieldscaleDataGridViewTextBoxColumn.Name = "tfieldscaleDataGridViewTextBoxColumn";
            this.tfieldscaleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfieldcannullDataGridViewTextBoxColumn
            // 
            this.tfieldcannullDataGridViewTextBoxColumn.DataPropertyName = "t_fieldcannull";
            this.tfieldcannullDataGridViewTextBoxColumn.HeaderText = "t_fieldcannull";
            this.tfieldcannullDataGridViewTextBoxColumn.Name = "tfieldcannullDataGridViewTextBoxColumn";
            this.tfieldcannullDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfielddefaultvalueDataGridViewTextBoxColumn
            // 
            this.tfielddefaultvalueDataGridViewTextBoxColumn.DataPropertyName = "t_fielddefaultvalue";
            this.tfielddefaultvalueDataGridViewTextBoxColumn.HeaderText = "t_fielddefaultvalue";
            this.tfielddefaultvalueDataGridViewTextBoxColumn.Name = "tfielddefaultvalueDataGridViewTextBoxColumn";
            this.tfielddefaultvalueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfielddescDataGridViewTextBoxColumn
            // 
            this.tfielddescDataGridViewTextBoxColumn.DataPropertyName = "t_fielddesc";
            this.tfielddescDataGridViewTextBoxColumn.HeaderText = "t_fielddesc";
            this.tfielddescDataGridViewTextBoxColumn.Name = "tfielddescDataGridViewTextBoxColumn";
            this.tfielddescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tfieldiscomputedDataGridViewTextBoxColumn
            // 
            this.tfieldiscomputedDataGridViewTextBoxColumn.DataPropertyName = "t_fieldiscomputed";
            this.tfieldiscomputedDataGridViewTextBoxColumn.HeaderText = "t_fieldiscomputed";
            this.tfieldiscomputedDataGridViewTextBoxColumn.Name = "tfieldiscomputedDataGridViewTextBoxColumn";
            this.tfieldiscomputedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sQLTableInfoBindingSource
            // 
            this.sQLTableInfoBindingSource.DataSource = typeof(KeelKit.Generators.SQLTableInfo);
            // 
            // buildConnectString1
            // 
            this.buildConnectString1.BackColor = System.Drawing.Color.Transparent;
            this.buildConnectString1.ConnectionString = global::KeelKit.Properties.Settings.Default.srccnt;
            this.buildConnectString1.csDataProvider = null;
            this.buildConnectString1.csDataSource = null;
            this.buildConnectString1.DataBindings.Add(new System.Windows.Forms.Binding("ConnectionString", global::KeelKit.Properties.Settings.Default, "srccnt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buildConnectString1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buildConnectString1.Location = new System.Drawing.Point(0, 12);
            this.buildConnectString1.Name = "buildConnectString1";
            this.buildConnectString1.Size = new System.Drawing.Size(309, 31);
            this.buildConnectString1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ttablenameDataGridViewTextBoxColumn1,
            this.ttabledescDataGridViewTextBoxColumn1,
            this.tfieldindexDataGridViewTextBoxColumn1,
            this.tfieldnameDataGridViewTextBoxColumn1,
            this.tidentityDataGridViewTextBoxColumn1,
            this.ttablekeyDataGridViewTextBoxColumn1,
            this.tfieldtypeDataGridViewTextBoxColumn1,
            this.tfieldbitcountDataGridViewTextBoxColumn1,
            this.tfieldlenghtDataGridViewTextBoxColumn1,
            this.tfieldscaleDataGridViewTextBoxColumn1,
            this.tfieldcannullDataGridViewTextBoxColumn1,
            this.tfielddefaultvalueDataGridViewTextBoxColumn1,
            this.tfielddescDataGridViewTextBoxColumn1,
            this.tfieldiscomputedDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.sQLTableInfoBindingSource1;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 43);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(321, 289);
            this.dataGridView2.TabIndex = 0;
            // 
            // ttablenameDataGridViewTextBoxColumn1
            // 
            this.ttablenameDataGridViewTextBoxColumn1.DataPropertyName = "t_tablename";
            this.ttablenameDataGridViewTextBoxColumn1.HeaderText = "t_tablename";
            this.ttablenameDataGridViewTextBoxColumn1.Name = "ttablenameDataGridViewTextBoxColumn1";
            this.ttablenameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ttabledescDataGridViewTextBoxColumn1
            // 
            this.ttabledescDataGridViewTextBoxColumn1.DataPropertyName = "t_tabledesc";
            this.ttabledescDataGridViewTextBoxColumn1.HeaderText = "t_tabledesc";
            this.ttabledescDataGridViewTextBoxColumn1.Name = "ttabledescDataGridViewTextBoxColumn1";
            this.ttabledescDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfieldindexDataGridViewTextBoxColumn1
            // 
            this.tfieldindexDataGridViewTextBoxColumn1.DataPropertyName = "t_fieldindex";
            this.tfieldindexDataGridViewTextBoxColumn1.HeaderText = "t_fieldindex";
            this.tfieldindexDataGridViewTextBoxColumn1.Name = "tfieldindexDataGridViewTextBoxColumn1";
            this.tfieldindexDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfieldnameDataGridViewTextBoxColumn1
            // 
            this.tfieldnameDataGridViewTextBoxColumn1.DataPropertyName = "t_fieldname";
            this.tfieldnameDataGridViewTextBoxColumn1.HeaderText = "t_fieldname";
            this.tfieldnameDataGridViewTextBoxColumn1.Name = "tfieldnameDataGridViewTextBoxColumn1";
            this.tfieldnameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tidentityDataGridViewTextBoxColumn1
            // 
            this.tidentityDataGridViewTextBoxColumn1.DataPropertyName = "t_identity";
            this.tidentityDataGridViewTextBoxColumn1.HeaderText = "t_identity";
            this.tidentityDataGridViewTextBoxColumn1.Name = "tidentityDataGridViewTextBoxColumn1";
            this.tidentityDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ttablekeyDataGridViewTextBoxColumn1
            // 
            this.ttablekeyDataGridViewTextBoxColumn1.DataPropertyName = "t_tablekey";
            this.ttablekeyDataGridViewTextBoxColumn1.HeaderText = "t_tablekey";
            this.ttablekeyDataGridViewTextBoxColumn1.Name = "ttablekeyDataGridViewTextBoxColumn1";
            this.ttablekeyDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfieldtypeDataGridViewTextBoxColumn1
            // 
            this.tfieldtypeDataGridViewTextBoxColumn1.DataPropertyName = "t_fieldtype";
            this.tfieldtypeDataGridViewTextBoxColumn1.HeaderText = "t_fieldtype";
            this.tfieldtypeDataGridViewTextBoxColumn1.Name = "tfieldtypeDataGridViewTextBoxColumn1";
            this.tfieldtypeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfieldbitcountDataGridViewTextBoxColumn1
            // 
            this.tfieldbitcountDataGridViewTextBoxColumn1.DataPropertyName = "t_fieldbitcount";
            this.tfieldbitcountDataGridViewTextBoxColumn1.HeaderText = "t_fieldbitcount";
            this.tfieldbitcountDataGridViewTextBoxColumn1.Name = "tfieldbitcountDataGridViewTextBoxColumn1";
            this.tfieldbitcountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfieldlenghtDataGridViewTextBoxColumn1
            // 
            this.tfieldlenghtDataGridViewTextBoxColumn1.DataPropertyName = "t_fieldlenght";
            this.tfieldlenghtDataGridViewTextBoxColumn1.HeaderText = "t_fieldlenght";
            this.tfieldlenghtDataGridViewTextBoxColumn1.Name = "tfieldlenghtDataGridViewTextBoxColumn1";
            this.tfieldlenghtDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfieldscaleDataGridViewTextBoxColumn1
            // 
            this.tfieldscaleDataGridViewTextBoxColumn1.DataPropertyName = "t_fieldscale";
            this.tfieldscaleDataGridViewTextBoxColumn1.HeaderText = "t_fieldscale";
            this.tfieldscaleDataGridViewTextBoxColumn1.Name = "tfieldscaleDataGridViewTextBoxColumn1";
            this.tfieldscaleDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfieldcannullDataGridViewTextBoxColumn1
            // 
            this.tfieldcannullDataGridViewTextBoxColumn1.DataPropertyName = "t_fieldcannull";
            this.tfieldcannullDataGridViewTextBoxColumn1.HeaderText = "t_fieldcannull";
            this.tfieldcannullDataGridViewTextBoxColumn1.Name = "tfieldcannullDataGridViewTextBoxColumn1";
            this.tfieldcannullDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfielddefaultvalueDataGridViewTextBoxColumn1
            // 
            this.tfielddefaultvalueDataGridViewTextBoxColumn1.DataPropertyName = "t_fielddefaultvalue";
            this.tfielddefaultvalueDataGridViewTextBoxColumn1.HeaderText = "t_fielddefaultvalue";
            this.tfielddefaultvalueDataGridViewTextBoxColumn1.Name = "tfielddefaultvalueDataGridViewTextBoxColumn1";
            this.tfielddefaultvalueDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfielddescDataGridViewTextBoxColumn1
            // 
            this.tfielddescDataGridViewTextBoxColumn1.DataPropertyName = "t_fielddesc";
            this.tfielddescDataGridViewTextBoxColumn1.HeaderText = "t_fielddesc";
            this.tfielddescDataGridViewTextBoxColumn1.Name = "tfielddescDataGridViewTextBoxColumn1";
            this.tfielddescDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tfieldiscomputedDataGridViewTextBoxColumn1
            // 
            this.tfieldiscomputedDataGridViewTextBoxColumn1.DataPropertyName = "t_fieldiscomputed";
            this.tfieldiscomputedDataGridViewTextBoxColumn1.HeaderText = "t_fieldiscomputed";
            this.tfieldiscomputedDataGridViewTextBoxColumn1.Name = "tfieldiscomputedDataGridViewTextBoxColumn1";
            this.tfieldiscomputedDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // sQLTableInfoBindingSource1
            // 
            this.sQLTableInfoBindingSource1.DataSource = typeof(KeelKit.Generators.SQLTableInfo);
            // 
            // buildConnectString2
            // 
            this.buildConnectString2.BackColor = System.Drawing.Color.Transparent;
            this.buildConnectString2.ConnectionString = global::KeelKit.Properties.Settings.Default.descnt;
            this.buildConnectString2.csDataProvider = null;
            this.buildConnectString2.csDataSource = null;
            this.buildConnectString2.DataBindings.Add(new System.Windows.Forms.Binding("ConnectionString", global::KeelKit.Properties.Settings.Default, "descnt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buildConnectString2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buildConnectString2.Location = new System.Drawing.Point(0, 12);
            this.buildConnectString2.Name = "buildConnectString2";
            this.buildConnectString2.Size = new System.Drawing.Size(321, 31);
            this.buildConnectString2.TabIndex = 1;
            // 
            // btnReadDBInfo
            // 
            this.btnReadDBInfo.Location = new System.Drawing.Point(14, 12);
            this.btnReadDBInfo.Name = "btnReadDBInfo";
            this.btnReadDBInfo.Size = new System.Drawing.Size(87, 34);
            this.btnReadDBInfo.TabIndex = 5;
            this.btnReadDBInfo.Text = "获取数据结构";
            this.btnReadDBInfo.UseVisualStyleBackColor = true;
            this.btnReadDBInfo.Click += new System.EventHandler(this.btnReadDBInfo_Click);
            // 
            // btnCmp
            // 
            this.btnCmp.Location = new System.Drawing.Point(129, 12);
            this.btnCmp.Name = "btnCmp";
            this.btnCmp.Size = new System.Drawing.Size(114, 33);
            this.btnCmp.TabIndex = 6;
            this.btnCmp.Text = "同步数据结构";
            this.btnCmp.UseVisualStyleBackColor = true;
            this.btnCmp.Click += new System.EventHandler(this.btnCmp_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(376, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(29, 12);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "就绪";
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(266, 13);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(104, 33);
            this.btnClean.TabIndex = 8;
            this.btnClean.Text = "清理多余字段";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // frmSyncDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 396);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnCmp);
            this.Controls.Add(this.btnReadDBInfo);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmSyncDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库同步工具";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLTableInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLTableInfoBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.BuildConnectString buildConnectString1;
        private Controls.BuildConnectString buildConnectString2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnReadDBInfo;
        private System.Windows.Forms.Button btnCmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttablenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttabledescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldindexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tidentityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttablekeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldbitcountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldlenghtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldscaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldcannullDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfielddefaultvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfielddescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldiscomputedDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sQLTableInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttablenameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttabledescDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldindexDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldnameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tidentityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttablekeyDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldtypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldbitcountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldlenghtDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldscaleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldcannullDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfielddefaultvalueDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfielddescDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfieldiscomputedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource sQLTableInfoBindingSource1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClean;
    }
}