using System;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using System.Collections.Generic;
using KeelKit.Core;
namespace KeelKit.Controls
{
    public partial class BuildConnectString : UserControl
    {
        public BuildConnectString()
        {
            InitializeComponent();
        }
   

       static   DataProvider _mysqlDataProvider;
        public  static    DataProvider MySQLDataProvider
        {
            get
            {
                if (_mysqlDataProvider == null)
                {
                    Dictionary<string, string> dataSourceDescriptions = new Dictionary<string, string>();
                    dataSourceDescriptions.Add("MySqlProvider", "MySqlDataProvider for KeelKit");
                    Dictionary<string, Type> connectionUIControlTypes = new Dictionary<string, Type>();
                    Dictionary<string, Type> typesp = new Dictionary<string, Type>();
                    typesp.Add (string.Empty , typeof(MySql.Data.VisualStudio.MySqlConnectionProperties));
                    connectionUIControlTypes.Add(string.Empty, typeof(MySqlDataConnectionUI));
                    _mysqlDataProvider = new DataProvider("MySql.Data.MySqlClient", "MySqlDataProvider for KeelKit", "KeelMySqlDataProvider", "KeelKit 用来支持MySql代码生成的器的数据提供器", typeof(MySql.Data.MySqlClient.MySqlConnection), dataSourceDescriptions, connectionUIControlTypes, typesp);
                }
                return _mysqlDataProvider;

            }
        }


        static  DataSource _MySQLDataSource = null;
        public static  DataSource MySQLDataSource
        {
            get
            {
                if (_MySQLDataSource == null)
                {
                    _MySQLDataSource = new DataSource("MySql", "MySql");
                    _MySQLDataSource.Providers.Add(MySQLDataProvider);
                     
                }
                return _MySQLDataSource;
            }
        }
        DataConnectionDialog dcd ;
        private void btnBuild_Click(object sender, EventArgs e)
        {         
            try
            {
                  // Properties



                dcd = new DataConnectionDialog();
                //添加数据源
                AddDS(DataSource.AccessDataSource);
             //  AddDS(DataSource.OdbcDataSource);
                AddDS(DataSource.OracleDataSource);
                AddDS(DataSource.SqlDataSource);
                AddDS(DataSource.SqlFileDataSource);
                AddDS(MySQLDataSource);
               // DataSource.AddStandardDataSources (  dcd );
              
                if (csDataSource != null)
                {
                    //指定默认选择数据源 用来还原 链接字符串到DataConnectionDialog中
                    dcd.SelectedDataSource = this.csDataSource ;
                    dcd.SelectedDataProvider = dcd.SelectedDataSource.DefaultProvider;//貌似必须赋值来自dcd.SelectedDataSource的提供器 ，当然，你可以可以取this.csDataSource.DefaultProvider,确保父子关系就可以了。否则链接字符串赋值时会出错
                }
                dcd.ConnectionString = this.txtCntStr.Text;//给链接字符串赋值
            
            }
            catch (Exception)
            {

            }
            DialogResult dr = DialogResult.Cancel  ;
            try
            {  
              dr=  DataConnectionDialog.Show(dcd);
            }
            catch (Exception)
            {

            }
            if (dr == DialogResult.OK)
            {
                //保存值
                this.txtCntStr.Text = dcd.ConnectionString;
                csDataSource = dcd.SelectedDataSource;
                csDataProvider  = dcd.SelectedDataProvider;
 
            }
        }

        private void AddDS(DataSource ds)
        {
            if (csDataSource != null && ds.DisplayName == csDataSource.DisplayName)
            {
                foreach (var item in ds.Providers )
                {
                    if (item.Name == csDataProvider.Name)
                    {
                        DataProvider dp = item;
                        ds.Providers.Clear();
                        ds.Providers.Add(dp);
                        csDataProvider = dp;
                        csDataSource = ds;
                        break;
                    }
                }
            }
            dcd.DataSources.Add(ds);
        }
        public string ConnectionString
        {
            get { return this.txtCntStr.Text; }
            set { this.txtCntStr.Text = value; }
        }
        public DataSource  csDataSource { get; set; }
        public DataProvider csDataProvider { get; set; }
    }
}
