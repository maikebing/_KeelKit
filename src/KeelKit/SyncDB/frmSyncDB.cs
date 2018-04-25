using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Keel;
using KeelKit.Generators;

namespace KeelKit.SyncDB
{
    public partial class frmSyncDB : Form
    {
        public frmSyncDB()
        {
            InitializeComponent();
        }

        private void btnReadDBInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper<SQLTableInfo> dbi = new DBHelper<SQLTableInfo>(new Keel.DB.SQLServer(buildConnectString1.ConnectionString));
                sQLTableInfoBindingSource.DataSource = dbi.GetDataViewForObjectList();
                DBHelper<SQLTableInfo> db2 = new DBHelper<SQLTableInfo>(new Keel.DB.SQLServer(buildConnectString2.ConnectionString));
                sQLTableInfoBindingSource1.DataSource = db2.GetDataViewForObjectList();
                label3.Text = sQLTableInfoBindingSource.Count.ToString();
                label4.Text = sQLTableInfoBindingSource1.Count.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCmp_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "正在准备数据...";
            Application.DoEvents();
            List<SQLTableInfo> lstst1 = sQLTableInfoBindingSource.List as List<SQLTableInfo>;
            List<SQLTableInfo> lstst2 = sQLTableInfoBindingSource1.List as List<SQLTableInfo>;

            DBHelper<SQLTableName> dbt1 = new DBHelper<SQLTableName>(new Keel.DB.SQLServer(buildConnectString1.ConnectionString));
            List<SQLTableName> lsttab1 = dbt1.GetDataViewForObjectList(null);
            DBHelper<SQLTableName> dbt2 = new DBHelper<SQLTableName>(new Keel.DB.SQLServer(buildConnectString2.ConnectionString));
            List<SQLTableName> lsttab2 = dbt2.GetDataViewForObjectList(null);
            Keel.DBOperator<Keel.DB.SQLServer> kdb = new DBOperator<Keel.DB.SQLServer>(new Keel.DB.SQLServer(buildConnectString2.ConnectionString));
            foreach (var item in lsttab1)
            {
                lblInfo.Text = "准备对比"+item.name ;
                Application.DoEvents();
                var t1 = from n in lstst1 where n.t_tablename == item.name select n;
                List<SQLTableInfo> sl1 = t1.ToList();

                var havetable = from ht in lsttab2 where item.name == ht.name select ht;
                if (havetable.Count() == 0)
                {
                    lblInfo.Text = "准备建表" + item.name;
                    Application.DoEvents();
                    string ctsql = " create table  {0}( {1})";
                    string fsql = "";
                    string fk = @"ALTER TABLE  {0} ADD CONSTRAINT
	PK_{0} PRIMARY KEY CLUSTERED 
	(
	 {1}
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
";
                    foreach (var itemht in sl1)
                    {
                        if (itemht.t_identity != "")
                        {
                            fsql += (fsql != "" ? "," : "") + string.Format("{0}  {1} NOT NULL IDENTITY (1, 1)", itemht.t_fieldname, itemht.t_fieldtype);
                            fk = string.Format(fk, item.name, itemht.t_fieldname);
                        }
                        else
                        {
                            fsql += (fsql != "" ? "," : "") + string.Format("{0}  {1}{2}  {3}", itemht.t_fieldname, itemht.t_fieldtype, GetTypeSql(itemht), itemht.t_fieldcannull != "" ? "NULL" : "");
                        }
                    }
                    ctsql = string.Format(ctsql, item.name, fsql);//创建表的结构

                    int i = kdb.ExecuteNonQuery(ctsql);//创建表
                    int i2 = kdb.ExecuteNonQuery(fk);//主键；


                }
                else //如果表存在
                {
                    lblInfo.Text = "修改表" + item.name;
                    Application.DoEvents();
                    var t2 = from n in lstst2 where n.t_tablename == item.name select n;
                    List<SQLTableInfo> sl2 = t2.ToList();

                    foreach (var itemf in sl1)
                    {
                        var ft = from x in sl2 where x.t_fieldname == itemf.t_fieldname select x;
                        int ix = ft.Count();
                        if (ix == 0)
                        {
                            string sql2 = string.Format("ALTER TABLE  {0} ADD   {1}  {2}{3}  {4}", itemf.t_tablename, itemf.t_fieldname, itemf.t_fieldtype, GetTypeSql(itemf), itemf.t_fieldcannull != "" ? "NULL" : "");
                            kdb.ExecuteNonQuery(sql2);//执行此语句
                        }
                        else
                        {

                        }

                    }

                }
            }
            lblInfo.Text = "完成";
        }
        /// <summary>
        /// 值判断和返回括号里的东西
        /// </summary>
        /// <param name="itemf"></param>
        /// <returns></returns>
        private static string GetTypeSql(SQLTableInfo itemf)
        {
            string sql = "";
            string lkh = "decimal,numeric,";
            string kh = "binary,char,datetime2,datetimeoffset,nchar,nvarchar,time,varbinary,varchar,";
            string max = "nvarchar,varbinary,varchar,";
            if (lkh.Contains((itemf.t_fieldtype + ",")))
            {
                sql = string.Format("({0},{1})",  itemf.t_fieldlenght, itemf.t_fieldscale);
            }
            else if (kh.Contains(itemf.t_fieldtype + ","))
            {
                sql = string.Format("({0})", itemf.t_fieldlenght);
            }
            else if (max.Contains(itemf.t_fieldtype + ","))
            {
                sql = string.Format("(MAX)");
            }

            else
            {
               sql = "";
            }
            return sql;
        }

        private void btndb_Click(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "正在准备数据...";
            Application.DoEvents();
            List<SQLTableInfo> lstst1 = sQLTableInfoBindingSource.List as List<SQLTableInfo>;
            List<SQLTableInfo> lstst2 = sQLTableInfoBindingSource1.List as List<SQLTableInfo>;

            DBHelper<SQLTableName> dbt1 = new DBHelper<SQLTableName>(new Keel.DB.SQLServer(buildConnectString1.ConnectionString));
            List<SQLTableName> lsttab1 = dbt1.GetDataViewForObjectList(null);
            DBHelper<SQLTableName> dbt2 = new DBHelper<SQLTableName>(new Keel.DB.SQLServer(buildConnectString2.ConnectionString));
            List<SQLTableName> lsttab2 = dbt2.GetDataViewForObjectList(null);
            Keel.DBOperator<Keel.DB.SQLServer> kdb = new DBOperator<Keel.DB.SQLServer>(new Keel.DB.SQLServer(buildConnectString2.ConnectionString));
            foreach (var item in lsttab2)
            {
                var s = from n in lsttab1 where n.name == item.name select n;
                SQLTableName stn = s.SingleOrDefault();
                if (stn == null)
                {
                    //表不存在
                }
                else
                {
                    var fd = from f in lstst2 where f.t_tablename == item.name select f;
                    foreach (var fdx in fd.ToArray () )
                    {
                        var fxddd = from fx1 in lstst1 where fx1.t_fieldname == fdx.t_fieldname select fx1;
                        SQLTableInfo sti = fxddd.SingleOrDefault();
                        if (sti == null)//如果不存在
                        {

                        }
                        else
                        {//如果存在这个字段， 就对比一下

                        }
                    }


                }
               
            }
            lblInfo.Text = "完成";
        }
 
    }
}
