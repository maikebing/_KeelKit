using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using Microsoft.VisualStudio.Data;
using System.Data.Common;
using MySql.Data.VisualStudio;

namespace KeelKit.Core
{
    public partial class MySqlDataConnectionUI : DataConnectionUIControl

    {
        public MySqlDataConnectionUI()
        {
            InitializeComponent();


        }
        private bool AttemptToCreateDatabase()
        {
            bool flag;
            MySqlConnectionProperties connectionProperties = (MySqlConnectionProperties)(base.ConnectionProperties);
            DbConnectionStringBuilder connectionStringBuilder = connectionProperties.ConnectionStringBuilder;
            string str = (string)connectionStringBuilder["Database"];
            connectionStringBuilder["Database"] = "";
            try
            {
                using (MySqlConnectionSupport support = new MySqlConnectionSupport())
                {
                    support.Initialize(null);
                    support.ConnectionString = connectionStringBuilder.ConnectionString;
                    support.Open(false);
                    support.ExecuteWithoutResults("CREATE DATABASE `" + this.dbList.Text + "`", 1, null, 0);
                }
                flag = true;
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("There was an error attempting to create the database '{0}'", this.dbList.Text));
                flag = false;
            }
            finally
            {
                connectionStringBuilder["Database"] = str;
            }
            return flag;
          
        }

        private bool DatabaseExists()
        {
            
            DbConnectionStringBuilder builder = ((base.ConnectionProperties as MySqlConnectionProperties ).ConnectionStringBuilder);
            try
            {
                using (MySqlConnectionSupport support = new MySqlConnectionSupport())
                {
                    support.Initialize(null);
                    support.ConnectionString=(builder.ConnectionString);
                    support.Open(false);
                }
                return true;
            }
            catch (DbException exception)
            {
                if (!exception.Message.ToLowerInvariant().StartsWith("unknown database", StringComparison.OrdinalIgnoreCase))
                {
                    throw;
                }
                return false;
            }
        }

        private void dbList_DropDown(object sender, EventArgs e)
        {
            if (!this.dbListPopulated)
            {
                DbConnectionStringBuilder builder = ((base.ConnectionProperties) as MySqlConnectionProperties).ConnectionStringBuilder;
                try
                {
                    using (MySqlConnectionSupport support = new MySqlConnectionSupport())
                    {
                        support.Initialize(null);
                        support.ConnectionString=builder.ConnectionString;
                        support.Open(false);
                        this.dbList.Items.Clear();
                        using (DataReader reader = support.Execute("SHOW DATABASES", 1, null, 0))
                        {
                            while (reader.Read())
                            {
                                string str = reader.GetItem(0).ToString().ToLowerInvariant();
                                if (!(str == "information_schema") && !(str == "mysql"))
                                {
                                    this.dbList.Items.Add(reader.GetItem(0));
                                }
                            }
                            this.dbListPopulated = true;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to retrieve the list of databases");
                }
            }
        }


        // Fields
        private IDataConnectionProperties _connectionProperties;
        private bool _loading;
        public override void LoadProperties()
        {
            if (base.ConnectionProperties == null)
            {
                throw new Exception("An error occurred that is normally caused by not having Connector/Net properly installed.");
            }
            Button acceptButton = base.ParentForm.AcceptButton as Button;
            acceptButton.Click += new EventHandler(this.okButton_Click);
            DbConnectionStringBuilder builder = ((base.ConnectionProperties) as MySqlConnectionProperties).ConnectionStringBuilder;
            this.loadingInProcess = true;
            try
            {
                this.serverNameTextBox.Text = (string)builder["Server"];
                this.userNameTextBox.Text = (string)builder["User Id"];
                this.passwordTextBox.Text = (string)builder["Password"];
                this.dbList.Text = (string)builder["Database"];
                this.savePasswordCheckBox.Checked = (bool)builder["Persist Security Info"];
            }
            finally
            {
                this.loadingInProcess = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!this.DatabaseExists())
            {
                DialogResult result = MessageBox.Show(string.Format("The database '{0}' does not exist or you do not have permission to see it.\n\nWould you like to create it?", this.dbList.Text).Replace(@"\n", @"\n"), null, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                base.ParentForm.DialogResult = DialogResult.None;
                if (result == DialogResult.Yes)
                {
                    if (!this.AttemptToCreateDatabase())
                    {
                        MessageBox.Show(string.Format("There was an error attempting to create the database '{0}'", this.dbList.Text));
                    }
                    else
                    {
                        base.ParentForm.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void SavePasswordChanged(object sender, EventArgs e)
        {
            if (!this.loadingInProcess)
            {
                base.ConnectionProperties[this.savePasswordCheckBox.Tag as string]= this.savePasswordCheckBox.Checked;
            }
        }

        private void SetProperty(object sender, EventArgs e)
        {
            if (!this.loadingInProcess)
            {
                Control control = sender as Control;
                if (control.Tag.Equals("Server") || control.Tag.Equals("User id"))
                {
                    this.dbListPopulated = false;
                }
                if ((control != null) && (control.Tag is string))
                {
                    base.ConnectionProperties[control.Tag as string]= control.Text;
                }
            }
            this.dbList.Enabled = (this.serverNameTextBox.Text.Trim().Length > 0) && (this.userNameTextBox.Text.Trim().Length > 0);
        }

        private void TrimControlText(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.Text = control.Text.Trim();
        }
    }

}


