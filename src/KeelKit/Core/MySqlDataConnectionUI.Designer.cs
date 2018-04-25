using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Data.ConnectionUI;
 
using System;
using System.Drawing;
using MySql.Data.VisualStudio;
namespace KeelKit.Core
{
    partial class MySqlDataConnectionUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Initialize(IDataConnectionProperties connectionProperties)
        {
            if (connectionProperties == null)
            {
                throw new ArgumentNullException("connectionProperties");
            }
            if (!(connectionProperties is  MySqlConnectionProperties ) && !(connectionProperties is OleDBOracleConnectionProperties))
            {
                throw new ArgumentException( "MysqlConnectionUIControl_InvalidConnectionProperties");
            }
            if (connectionProperties is OdbcConnectionProperties)
            {
                this.savePasswordCheckBox.Enabled = false;
            }
            this._connectionProperties = connectionProperties;
        }

        #region 组件设计器生成的代码
        ComponentResourceManager manager;
        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.loginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.savePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.dbList = new System.Windows.Forms.ComboBox();
            this.loginTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTableLayoutPanel
            // 
            this.loginTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.loginTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.loginTableLayoutPanel.Controls.Add(this.passwordLabel, 0, 2);
            this.loginTableLayoutPanel.Controls.Add(this.serverNameTextBox, 1, 0);
            this.loginTableLayoutPanel.Controls.Add(this.savePasswordCheckBox, 1, 3);
            this.loginTableLayoutPanel.Controls.Add(this.databaseNameLabel, 0, 4);
            this.loginTableLayoutPanel.Controls.Add(this.userNameLabel, 0, 1);
            this.loginTableLayoutPanel.Controls.Add(this.serverNameLabel, 0, 0);
            this.loginTableLayoutPanel.Controls.Add(this.userNameTextBox, 1, 1);
            this.loginTableLayoutPanel.Controls.Add(this.dbList, 1, 4);
            this.loginTableLayoutPanel.Controls.Add(this.passwordTextBox, 1, 2);
            this.loginTableLayoutPanel.Location = new System.Drawing.Point(15, 0);
            this.loginTableLayoutPanel.Name = "loginTableLayoutPanel";
            this.loginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.loginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.loginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.loginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.loginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.loginTableLayoutPanel.Size = new System.Drawing.Size(340, 155);
            this.loginTableLayoutPanel.TabIndex = 0;
            // 
            // passwordLabel
            // 
            this.passwordLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.passwordLabel.Location = new System.Drawing.Point(3, 66);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(100, 23);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "&Password:";
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.Location = new System.Drawing.Point(112, 3);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(218, 21);
            this.serverNameTextBox.TabIndex = 1;
            this.serverNameTextBox.Tag = "Server";
            this.serverNameTextBox.TextChanged += new System.EventHandler(this.SetProperty);
            this.serverNameTextBox.Leave += new System.EventHandler(this.TrimControlText);
            // 
            // savePasswordCheckBox
            // 
            this.savePasswordCheckBox.Location = new System.Drawing.Point(112, 96);
            this.savePasswordCheckBox.Name = "savePasswordCheckBox";
            this.savePasswordCheckBox.Size = new System.Drawing.Size(186, 23);
            this.savePasswordCheckBox.TabIndex = 2;
            this.savePasswordCheckBox.Tag = "Persist Security Info";
            this.savePasswordCheckBox.Text = "&Save my password";
            this.savePasswordCheckBox.CheckedChanged += new System.EventHandler(this.SavePasswordChanged);
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.databaseNameLabel.Location = new System.Drawing.Point(3, 122);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(100, 23);
            this.databaseNameLabel.TabIndex = 3;
            this.databaseNameLabel.Text = "&Database name:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.userNameLabel.Location = new System.Drawing.Point(3, 34);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(100, 23);
            this.userNameLabel.TabIndex = 4;
            this.userNameLabel.Text = "&User name:";
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.serverNameLabel.Location = new System.Drawing.Point(3, 0);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(100, 23);
            this.serverNameLabel.TabIndex = 5;
            this.serverNameLabel.Text = "S&erver name:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(112, 37);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(225, 21);
            this.userNameTextBox.TabIndex = 6;
            this.userNameTextBox.Tag = "User id";
            this.userNameTextBox.TextChanged += new System.EventHandler(this.SetProperty);
            this.userNameTextBox.Leave += new System.EventHandler(this.TrimControlText);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(112, 69);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(225, 21);
            this.passwordTextBox.TabIndex = 7;
            this.passwordTextBox.Tag = "Password";
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.SetProperty);
            // 
            // dbList
            // 
            this.dbList.FormattingEnabled = true;
            this.dbList.Location = new System.Drawing.Point(112, 125);
            this.dbList.Name = "dbList";
            this.dbList.Size = new System.Drawing.Size(218, 20);
            this.dbList.TabIndex = 8;
            this.dbList.Tag = "Database";
            this.dbList.DropDown += new System.EventHandler(this.dbList_DropDown);
            this.dbList.TextChanged += new System.EventHandler(this.SetProperty);
            // 
            // MySqlDataConnectionUI
            // 
            this.Controls.Add(this.loginTableLayoutPanel);
            this.Name = "MySqlDataConnectionUI";
            this.Size = new System.Drawing.Size(366, 172);
            this.loginTableLayoutPanel.ResumeLayout(false);
            this.loginTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        // Fields
    
        private Label databaseNameLabel;
        private ComboBox dbList;
        private bool dbListPopulated;
        private bool loadingInProcess;
        private TableLayoutPanel loginTableLayoutPanel;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private CheckBox savePasswordCheckBox;
        private Label serverNameLabel;
        private TextBox serverNameTextBox;
        private Label userNameLabel;
        private TextBox userNameTextBox;

       
        #endregion
    }
}
