using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using Keel.DB;
using Keel.Exceptions;
using Keel.ORM;

namespace Keel
{
    /// <summary>
    /// 泛型DBHelper,用于数据库的访问
    /// </summary>
    /// <typeparam name="T">Model类型</typeparam>
    //  [System.Diagnostics.DebuggerStepThroughAttribute()]
    public sealed class DBHelper<T>
    {
        internal DBOperator<Keel.IDatabase> idb = null;
    
        /// <summary>
        /// 使用通用数据库，即 Keel.DB.Common.NowDataBase,在程序启动时需要为此赋值或者配置程序中有相应配置
        /// </summary>
        public DBHelper()
        {
            idb = new DBOperator<IDatabase>(new Keel.DB.Common());
            
        }
        /// <summary>
        /// 使用制定的数据库新建DBHelper
        /// </summary>
        /// <param name="db"></param>
        public DBHelper(Keel.IDatabase db)
        {
            idb = new DBOperator<IDatabase>(db);
        }
        /// <summary>
        /// 使用制定的dboperator创建一个 dbhelper 
        /// </summary>
        /// <param name="pdb">另一个dbhelper的dbo </param>
        public DBHelper(DBOperator<IDatabase> pdb)
        {
            idb = pdb;
        }

        /// <summary>
        /// 设置或获取当前dbhelper的dbo 
        /// </summary>
        public DBOperator<Keel.IDatabase> DBOperator
        {
            get { return idb; }
            set { idb = value; }
        }
        
        /// <summary>
        ///  开始数据库事务
        /// </summary>
        public void TransactionBegin()
        {
            idb.BeginTransaction();
        }
        /// <summary>
        ///  以指定的隔离级别启动数据库事务
        /// </summary>
        /// <param name="isolationLevel"></param>
        public void TransactionBegin(IsolationLevel isolationLevel)
        {
            idb.BeginTransaction(isolationLevel);
        }
        /// <summary>
        /// 回滚数据库事务
        /// </summary>
        public void TransactionRollback()
        {
            idb.RollbackTransaction();
        }
        /// <summary>
        /// 提交数据库事务
        /// </summary>
        public void TransactionCommit()
        {
            idb.CommitTransaction();
        }
        /// <summary>
        /// 执行并返回一个单值
        /// </summary>
        /// <param name="select_list">字段名</param>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        public object ExecuteScalar(string select_list, T filter)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return ExecuteScalar(select_list, GetFilter(filter, dbc), dbc);
        }
        /// <summary>
        /// 执行并返回一个单值
        /// </summary>
        /// <param name="select_list">字段名</param>
        /// <param name="filter">字符串形式的过滤条件</param>
        /// <returns></returns>
        public object ExecuteScalar(string select_list, string filter)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return ExecuteScalar(select_list, filter, dbc);
        }

        private object ExecuteScalar(string select_list, string filter, DbCommand dbc)
        {
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            dbc.CommandText = string.Format("SELECT  {0}  FROM {1} WHERE {2}", select_list, tablename, filter);
            idb.OpenConnection();
            object r = dbc.ExecuteScalar();
            idb.CloseConnection();

            return r;
        }


      

        /// <summary>
        /// 统计根据条件筛选到记录的总数
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="what">字段依据</param>
        /// <param name="DISTINCT">是否去掉重复项</param>
        /// <returns></returns>
        public int GetCount(string filter, string what, bool DISTINCT)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return GetCount(filter, what, DISTINCT, dbc);
        }
        public int GetCount(List<QP> filter)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return GetCount(GetFilter(filter, dbc), null, false, dbc);
        }
        /// <summary>
        /// 统计根据条件筛选到记录的总数
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="what">字段依据</param>
        /// <param name="DISTINCT">是否去掉重复项</param>
        /// <returns></returns>
        public int GetCount(List<QP> filter, string what)
        {
            return GetCount(filter, what,false );
        }
        /// <summary>
        /// 统计根据条件筛选到记录的总数
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="what">字段依据</param>
        /// <param name="DISTINCT">是否去掉重复项</param>
        /// <returns></returns>
        public int GetCount(List<QP> filter, string what, bool DISTINCT)
        {
            DbCommand dbc = idb.CreateDbCommand();
            string wherelist = GetFilter(filter, dbc);
            return GetCount(wherelist, what, DISTINCT, dbc);
        }


        private   string GetFilter(List<QP> filter, DbCommand dbc)
        {
            string wherelst = "";
            QP last = null;
            for (int i = 0; i < filter.Count; i++)
            {

                QP item = filter[i];
                wherelst += last == null ? "" : " " + ((last.After == null) ? (i >= filter.Count ? "" : " And ") : last.After) + " ";
                wherelst += Common.GetWithIdentifier(item.ColumnName) + " " + item.Operator + " " + idb.db.GetParamIdentifierChar() + "where_" + item.ColumnName;
                dbc.Parameters.Add(CreateParameter(dbc, "where_" + item.ColumnName, item.Value));
                last = item;
            }

            return wherelst;
        }
        private int GetCount(string filter, string what, bool DISTINCT, DbCommand dbc)
        {
            int rx = 0;
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            if (what == null || what.Trim() == "") what = "1";
            dbc.CommandText = string.Format("SELECT COUNT( {0} {1})  FROM {3} WHERE {2}", DISTINCT ? "DISTINCT" : "", what, filter, tablename);
            idb.OpenConnection();
            object r = dbc.ExecuteScalar();
            idb.CloseConnection();
            if (r != null && r != DBNull.Value)
            {
                if (!int.TryParse(r.ToString(), out rx))
                {
                    rx = 0;
                }
            }
            return rx;
        }
        /// <summary>
        /// 根据条件筛选并统计数量
        /// </summary>
        /// <param name="filter">字符串筛选条件</param>
        /// <param name="what">字段依据，必须是有效的字段，或*</param>
        /// <returns></returns>
        public int GetCount(string filter, string what)
        {
            return GetCount(filter, what, true);
        }
        /// <summary>
        /// 根据条件筛选并统计数量
        /// </summary>
        /// <param name="filter">字符串筛选条件</param>
        /// <returns>返回数量</returns>
        public int GetCount(string filter)
        {
            return GetCount(filter, "1", false);
        }
        /// <summary>
        ///根据实体中的非空值来筛选并统计数量
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="what">字段依照</param>
        /// <param name="DISTINCT">是否去掉重复项</param>
        /// <returns>返回数量</returns>
        public int GetCount(T filter, string what, bool DISTINCT)
        {
            DbCommand dbc = idb.CreateDbCommand();
            string f = GetFilter(filter, dbc, what);
            return GetCount(f, what, DISTINCT, dbc);
        }
        /// <summary>
        /// 根据实体中的非空值来筛选并统计数量
        /// </summary>
        /// <param name="filter">实体筛选条件</param>
        /// <param name="what">字段依据</param>
        /// <returns>返回数量</returns>
        public int GetCount(T filter, string what)
        {
            return GetCount(filter, what, true);
        }
        /// <summary>
        /// 根据实体中的非空值来筛选并统计数量
        /// </summary>
        /// <param name="filter">实体筛选条件</param>
        /// <returns>返回数量</returns>
        public int GetCount(T filter)
        {
            return GetCount(filter, "1");
        }

        #region Web控件处理
#if CF
        /// <summary>
        /// 从一个Web表单中提取出实体
        /// </summary>
        /// <param name="ctl">Web控件</param>
        /// <returns>返回实体</returns>
        public T Distill(System.Web.UI.Control  ctl)
        {

            T md = System.Activator.CreateInstance<T>();
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                object value = null;
                Type t = Keel.MetaType.GetMetaTypeFromDbType((DbType)Enum.Parse(typeof(DbType), dfa.DBType)).ClassType;
                switch (Type.GetTypeCode(t))
                {
                    case TypeCode.Boolean:
                        System.Web.UI.WebControls.CheckBox cb = ctl.FindControl("keelctl_chk_" + item.Name) as System.Web.UI.WebControls.CheckBox;
                       if (cb!=null ) value = cb.Checked;
                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.DateTime:
                        System.Web.UI.WebControls.TextBox dte = ctl.FindControl("keelctl_dte_" + item.Name) as System.Web.UI.WebControls.TextBox;
                        if (dte != null)
                        {
                            DateTime dt = new DateTime();
                            if (DateTime.TryParse(dte.Text ,out dt ))value =  dt  ;
                        }
                        break;
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Char:
                    case TypeCode.String:
                        System.Web.UI.WebControls.TextBox txt = ctl.FindControl("keelctl_txt_" + item.Name) as System.Web.UI.WebControls.TextBox;
                        if (txt != null) value = txt.Text;   
                        break;
                    case TypeCode.Decimal:
                    case TypeCode.Byte:
                    case TypeCode.Double:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.SByte:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        System.Web.UI.WebControls.TextBox txtInt = ctl.FindControl("keelctl_dec_" + item.Name) as System.Web.UI.WebControls.TextBox;
                        decimal dec=0;
                        if (txtInt != null)
                        {

                            if (!decimal.TryParse(txtInt.Text, out dec))
                            {
                                dec = 0;
                            }
                        }
                        value = System.Convert.ChangeType(dec, t);
                        break;
                    case TypeCode.Object:
                    default:
                        System.Web.UI.WebControls.TextBox ukw = ctl.FindControl("keelctl_ukw_" + item.Name) as System.Web.UI.WebControls.TextBox;
                        if (ukw != null) value  = ukw.Text; 
                        break;
                }
                item.SetValue(md, value, null);
            }
            return md;
        }

        /// <summary>
        /// 将指定值填充到一个Web控件中
        /// </summary>
        /// <param name="ctl">被填充控件</param>
        /// <param name="SetValue">Model</param>
        /// <returns>总是返回真,如果不出错误则直接返回真</returns>
        /// 
        public bool Fill(System.Web.UI.Control ctl, T SetValue)
        {
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                object objset = item.GetValue(SetValue, null);
                Type t = Keel.MetaType.GetMetaTypeFromDbType((DbType)Enum.Parse(typeof(DbType), dfa.DBType)).ClassType;
                switch (Type.GetTypeCode(t))
                {
                    case TypeCode.Boolean:
                        System.Web.UI.WebControls.CheckBox cb = ctl.FindControl("keelctl_chk_" + item.Name) as System.Web.UI.WebControls.CheckBox;
                        if (cb != null && objset!=null   )
                        {
                            cb.Checked =System.Convert.ToBoolean(objset);
                        }
                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.DateTime:
                        System.Web.UI.WebControls.TextBox dte = ctl.FindControl("keelctl_dte_" + item.Name) as System.Web.UI.WebControls.TextBox;
                        if (dte != null)
                        {
                            dte.Text =objset.ToString () ;
                        }
                        break;
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Char:
                    case TypeCode.String:
                        System.Web.UI.WebControls.TextBox txt = ctl.FindControl("keelctl_txt_" + item.Name) as System.Web.UI.WebControls.TextBox;
                        if (txt != null) txt.Text = (string)objset;
                        break;
                    case TypeCode.Decimal:
                    case TypeCode.Byte:
                    case TypeCode.Double:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.SByte:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        System.Web.UI.WebControls.TextBox txtInt = ctl.FindControl("keelctl_dec_" + item.Name) as System.Web.UI.WebControls.TextBox;
                        txtInt.Text = objset.ToString();
                        break;
                    case TypeCode.Object:
                    default:
                        System.Web.UI.WebControls.TextBox ukw = ctl.FindControl("keelctl_ukw_" + item.Name) as System.Web.UI.WebControls.TextBox;
                        if (ukw != null) ukw.Text =objset.ToString () ;
                        break;
                }
            }
            return true;

        }
#endif
        #endregion
        #region  Win控件处理部分




        /// <summary>
        /// 从一个Windows控件中提取出来Model
        /// </summary>
        /// <param name="ctl">控件</param>
        /// <returns></returns>
        public T Distill(System.Windows.Forms.Control ctl)
        {
            T md = System.Activator.CreateInstance<T>();
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                object value = null;
                Type t = Keel.MetaType.GetMetaTypeFromDbType((DbType)Enum.Parse(typeof(DbType), dfa.DBType)).ClassType;
                if (t.Equals(typeof(string)))
                {
                    if (ctl.Controls.ContainsKey("txt" + dfa.ColumnName))
                    {
                        value = ((ctl.Controls["txt" + dfa.ColumnName]) as System.Windows.Forms.TextBox).Text;

                    }
                }
                else if (t.Equals(typeof(DateTime)))
                {
                    if (ctl.Controls.ContainsKey("dtp" + dfa.ColumnName))
                    {
                        value = (ctl.Controls["dtp" + dfa.ColumnName] as System.Windows.Forms.DateTimePicker).Value;
                    }
                }

                else if (t.Equals(typeof(decimal)) || t.Equals(typeof(Int32)) || t.Equals(typeof(float)) || t.Equals(typeof(double))
                    || t.Equals(typeof(byte)) || t.Equals(typeof(int)) || t.Equals(typeof(Int16)) || t.Equals(typeof(Int64))
                    )
                {
                    if (ctl.Controls.ContainsKey("nud" + dfa.ColumnName))
                    {
                        value = System.Convert.ChangeType((ctl.Controls["nud" + dfa.ColumnName] as System.Windows.Forms.NumericUpDown).Value, t);
                    }
                }
                else
                {
                    if (ctl.Controls.ContainsKey("txt_unsupport_type_" + dfa.ColumnName))
                    {
                        value = ((ctl.Controls["txt_unsupport_type_" + dfa.ColumnName]) as System.Windows.Forms.TextBox).Text;
                    }
                }
                item.SetValue(md, value, null);
            }
            return md;
        }
        /// <summary>
        /// 将指定值填充到一个Windows控件中
        /// </summary>
        /// <param name="ctl">被填充控件</param>
        /// <param name="SetValue">Model</param>
        /// <returns>总是返回真,如果不出错误则直接返回真</returns>
        public bool Fill(System.Windows.Forms.Control ctl, T SetValue)
        {
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                object objset = item.GetValue(SetValue, null);

                Type t = Keel.MetaType.GetMetaTypeFromDbType((DbType)Enum.Parse(typeof(DbType), dfa.DBType)).ClassType;
                if (t.Equals(typeof(string)))
                {
                    if (ctl.Controls.ContainsKey("txt" + dfa.ColumnName))
                    {
                        ((ctl.Controls["txt" + dfa.ColumnName]) as System.Windows.Forms.TextBox).Text = objset as string;

                    }
                }
                else if (t.Equals(typeof(DateTime)))
                {
                    if (ctl.Controls.ContainsKey("dtp" + dfa.ColumnName))
                    {
                        if (objset == null || objset == DBNull.Value)
                        {
                            objset = new DateTime();
                        }
                        (ctl.Controls["dtp" + dfa.ColumnName] as System.Windows.Forms.DateTimePicker).Value = (DateTime)objset;
                    }
                }

                else if (t.Equals(typeof(decimal)) || t.Equals(typeof(Int32)) || t.Equals(typeof(float)) || t.Equals(typeof(double))
                    || t.Equals(typeof(byte)) || t.Equals(typeof(int)) || t.Equals(typeof(Int16)) || t.Equals(typeof(Int64))
                    )
                {
                    if (ctl.Controls.ContainsKey("nud" + dfa.ColumnName))
                    {
                        decimal ddd;
                        if (decimal.TryParse(objset.ToString(), out ddd))
                        {
                            (ctl.Controls["nud" + dfa.ColumnName] as System.Windows.Forms.NumericUpDown).Value = ddd;
                        }
                    }
                }
                else
                {
                    if (ctl.Controls.ContainsKey("txt_unsupport_type_" + dfa.ColumnName))
                    {
                        ((ctl.Controls["txt_unsupport_type_" + dfa.ColumnName]) as System.Windows.Forms.TextBox).Text = objset as string;
                    }
                }
            }
            return true;

        }
        #endregion



        #region 视图处理部分  目前没有加异常处理，如碰到非视图时的异常

        /// <summary>
        /// 查询出制定视图的所有值，SQL语句在生成此视图时已赋值
        /// </summary>
        /// <returns></returns>
        public List<T> GetDataViewForObjectList()
        {
            return GetDataViewForObjectList(null);
        }
        /// <summary>
        /// 查询出制定视图的所有值，SQL语句在生成此视图时已赋值
        /// </summary>
        /// <returns></returns>
        public List<T> GetDataViewForObjectList(string choose_viewname)
        {
            List<T> lt = new List<T>();
            string viewname = null;
            if (choose_viewname == null)
            {
                viewname = typeof(T).Name;
            }
            else
            {
                viewname = choose_viewname;
            }
            //= ((Keel.ORM.DataViewAttribute)((typeof(T)).GetCustomAttributes(typeof(Keel.ORM.DataViewAttribute), true)[0])).ViewName;
            // null ;//= //;Encoding.Default.GetString(Convert.FromBase64String(((Keel.ORM.DataViewAttribute)((typeof(T)).GetCustomAttributes(typeof(Keel.ORM.DataViewAttribute), true)[0])).SQLString));
            string sql = ReadDataViewSQL(viewname);
            DbDataReader dr = idb.GetDataReader(sql);
            while ((dr.Read()))
            {

                T t = Activator.CreateInstance<T>();
                foreach (var item in typeof(T).GetProperties())
                {
                    DataFieldAttribute dfa = GetDataFieldAttrib(item);
                    string colname = dfa.ColumnName;

                    if (dr[colname] != DBNull.Value)
                    {
                        object ox = dr[colname];
                        if (ox.GetType() != item.PropertyType)
                        {
                            ox = System.Convert.ChangeType(ox, item.PropertyType);
                        }
                        item.SetValue(t, ox, null);
                    }
                }
                lt.Add(t);

            }
            dr.Close();
            idb.CloseConnection();
            return lt;
        }

        private string ReadDataViewSQL(string select_viewname)
        {
            string sql = null;
            if (select_viewname != null)
            {
                object[] sqls1 = ((typeof(T)).GetCustomAttributes(typeof(Keel.ORM.DataViewAttribute), true));
                if (sqls1.Length > 0)
                {
                    foreach (var item in sqls1)
                    {
                        Keel.ORM.DataViewAttribute dvs = item as Keel.ORM.DataViewAttribute;
                        if (dvs.ViewName == select_viewname)
                        {
                            sql = Encoding.Default.GetString(Convert.FromBase64String(dvs.SQLString));
                            break;
                        }
                    }
                }
            }

            if (typeof(T).Name == select_viewname)
            {
                object[] sqls = ((typeof(T)).GetCustomAttributes(typeof(Keel.ORM.DataViewSQLAttribute), true));
                if (sqls.Length > 0)
                {
                    foreach (var item in sqls)
                    {
                        Keel.ORM.DataViewSQLAttribute dvs = item as Keel.ORM.DataViewSQLAttribute;
                        object o = null;
                        try
                        {
                            o = idb.ExecuteScalar(Encoding.Default.GetString(Convert.FromBase64String(dvs.Condition)));
                        }
                        catch (Exception)
                        {
                            o = null;
                        }
                        if (o != null && o != DBNull.Value)
                        {
                            if (o.ToString() == Encoding.Default.GetString(Convert.FromBase64String(dvs.Value)))
                            {
                                sql = Encoding.Default.GetString(Convert.FromBase64String(dvs.SQLString));
                                break;
                            }
                        }
                    }
                }
            }
            return sql;
        }
        /// <summary>
        /// 将视图数据返回至DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataViewForDataTable()
        {
            return GetDataViewForDataTable(null);
        }

        /// <summary>
        /// 根据指定的名称来将视图数据返回至DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataViewForDataTable(string choose_viewname)
        {

            string tablename = null;
            if (choose_viewname == null)
            {
                tablename = typeof(T).Name;
            }
            else
            {
                tablename = choose_viewname;
            }
            //= ((Keel.ORM.DataViewAttribute)((typeof(T)).GetCustomAttributes(typeof(Keel.ORM.DataViewAttribute), true)[0])).ViewName;
            // null ;//= //;Encoding.Default.GetString(Convert.FromBase64String(((Keel.ORM.DataViewAttribute)((typeof(T)).GetCustomAttributes(typeof(Keel.ORM.DataViewAttribute), true)[0])).SQLString));
            // string sql = ReadDataViewSQL(viewname);
            // string tablename = ((Keel.ORM.DataViewAttribute)((typeof(T)).GetCustomAttributes(typeof(Keel.ORM.DataViewAttribute), true)[0])).ViewName ;
            //string sql = Encoding.Default.GetString(Convert.FromBase64String( ((Keel.ORM.DataViewAttribute)((typeof(T)).GetCustomAttributes(typeof(Keel.ORM.DataViewAttribute), true)[0])).SQLString)) ;
            string sql = ReadDataViewSQL(tablename);
            DataTable dt = idb.ExecuteFillDataTable(sql);
            dt.TableName = tablename;
            return dt;

        }

        #endregion

        #region select 部分
        /// <summary>
        /// 根据filter得到一个实体，该方法调用了SelectEntitys,取了第一个实体.
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>返回一个实体，如果没有查询到则返回null</returns>
        public T SelectEntity(string filter)
        {
            List<T> tt = SelectEntitys(filter, 1);
            if (tt.Count > 0)
            {
                return tt[0];
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// 根据filter得到一个实体，该方法调用了SelectEntitys,取了第一个实体.
        /// </summary>
        /// <param name="filter">泛型条件</param>
        /// <returns>返回一个实体，如果没有查询到则返回null</returns>
        public T SelectEntity(T filter)
        {
            return SelectEntity(filter, null);
        }
        /// <summary>
        /// 根据qp列表获得一个数据
        /// </summary>
        /// <param name="qp">qp查询参数</param>
        /// <returns></returns>
        public T SelectEntity(List<QP> qp)
        {
            List<T> tt = SelectEntitys(qp, 1);
            if (tt.Count > 0)
            {
                return tt[0];
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// 根据filter得到一个实体，该方法调用了SelectEntitys,取了第一个实体.
        /// </summary>
        /// <param name="filter">泛型条件</param>
        /// <param name="fields">指定作为查询条件的字段列表</param>
        /// <returns>返回一个实体，如果没有查询到则返回null</returns>
        public T SelectEntity(T filter, string fields)
        {
            //TODO:需要检查一下fileds的作用
            List<T> tt = SelectEntitys(filter, fields, 1);
            if (tt.Count > 0)
            {
                return tt[0];
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// 获得所有的实体
        /// </summary>
        /// <returns>实体列表</returns>
        public List<T> SelectEntitys()
        {
            return SelectEntitys("");
        }
        /// <summary>
        /// 根据filter得到实体表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>实体列表</returns>
        public List<T> SelectEntitys(string filter)
        {
            return SelectEntitys(filter, 0);
        }
        /// <summary>
        /// 根据filter得到实体表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>实体列表</returns>
        /// <param name="top">只取前面指定的行数</param>

        public List<T> SelectEntitys(string filter, int top)
        {
            return SelectEntitys(filter, top, null);
        }


        /// <summary>
        /// 根据filter得到实体表
        /// </summary>
        /// <param name="filter">条件</param>
        /// <returns>实体列表</returns>
        /// <param name="top">只取前面指定的行数</param>
        ///<param name="orderby">排序字段</param>
        public List<T> SelectEntitys(string filter, int top, string orderby)
        {

            DbDataReader dr = null;
            List<T> lt = new List<T>();
            DbCommand dbc = GetSelectCommand(filter, top, orderby);
            dr = idb.GetDataReader(dbc);
            while ((dr.Read()))
            {
                T t = Activator.CreateInstance<T>();
                foreach (var item in typeof(T).GetProperties())
                {
                    DataFieldAttribute dfa = GetDataFieldAttrib(item);
                    if (dfa != null)
                    {
                        string colname = dfa.ColumnName;
                        if (dr[colname] != DBNull.Value)
                        {
                            item.SetValue(t, dr[colname], null);
                        }
                    }
                }
                lt.Add(t);
            }
            dr.Close();
            idb.Close();
            return lt;
        }
        /// <summary>
        /// 查询并填充至DataSet中
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="top"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public DataSet FillDataSet(string filter, int top, string orderby)
        {

            DataSet ds = new DataSet("KeelDBHelper"); ;
            List<T> lt = new List<T>();
            DbCommand dbc = GetSelectCommand(filter, top, orderby);
            ds = idb.ExecuteFillDataSet(dbc.CommandText);
            return ds;
        }

        public DataSet GetDataset(string strsql)
        {
            DataSet ds = new DataSet(); ;
            return idb.ExecuteFillDataSet(strsql);
        }

        public DataTable GetDataTable(string strsql)
        {
            DataTable ds = new DataTable(); ;
            return idb.ExecuteFillDataTable(strsql);
        }


        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public DataSet FillDataSet(string filter, string orderby)
        {
            return FillDataSet(filter, 0, orderby);
        }
        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <returns></returns>
        public DataSet FillDataSet()
        {
            return FillDataSet(null, null);
        }
        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public DataSet FillDataSet(string filter)
        {
            return FillDataSet(filter, null);
        }

        private DbCommand GetSelectCommand(string filter, int top, string orderby)
        {

            DbCommand dbc = CreateSelectCommand(top);
            if (filter != null && filter.Trim() != "")
            {
                dbc.CommandText += " WHERE " + filter;
            }
            if (orderby != null && orderby.Trim() != "")
            {
                dbc.CommandText += " ORDER BY " + orderby;
            }
            return dbc;
        }
        /// <summary>
        /// 使用一个Model的非空值来查询数据
        /// </summary>
        /// <returns>返回查询结果</returns>
        /// <exception cref="NotAKeelModelException">不是一个Model</exception>
        /// <param name="filter">作为查询条件的Model</param>
        public List<T> SelectEntitys(T filter)
        {
            return SelectEntitys(filter, null, 0);

        }
        /// <summary>
        /// 返回查询结果
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="top">提取最多多少行</param>
        /// <returns></returns>
        public List<T> SelectEntitys(T filter, int top)
        {
            return SelectEntitys(filter, null, top);
        }


        /// <summary>
        /// 使用一个Model的非空值来查询数据
        /// </summary>
        /// <returns>返回查询结果</returns>
        /// <exception cref="NotAKeelModelException">不是一个Model</exception>
        /// <param name="filter">作为查询条件的Model</param>
        /// <param name="fields">指定作为查询条件的字段列表</param>
        public List<T> SelectEntitys(T filter, string fields)
        {
            return SelectEntitys(filter, fields, 0);
        }
        /// <summary>
        /// 使用一个Model的非空值来查询数据
        /// </summary>
        /// <returns>返回查询结果</returns>
        /// <exception cref="NotAKeelModelException">不是一个Model</exception>
        /// <param name="filter">作为查询条件的Model</param>
        /// <param name="fields">指定作为查询条件的字段列表</param>
        /// <param name="Top">指定只取前面的多少行</param>
        public List<D> SelectEntitys<D>(string filter, string groupby, string choose)
        {
            return SelectEntitys<D>(filter, groupby, choose, 0);
        }
        /// <summary>
        /// 使用一个Model的非空值来查询数据
        /// </summary>
        /// <returns>返回查询结果</returns>
        /// <exception cref="NotAKeelModelException">不是一个Model</exception>
        /// <param name="filter">作为查询条件的Model</param>
        /// <param name="fields">指定作为查询条件的字段列表</param>
        /// <param name="Top">指定只取前面的多少行</param>
        public List<D> SelectEntitys<D>(string filter, string groupby, string choose, int Top)
        {
            DbDataReader dr = null;
            List<D> lt = new List<D>();
            DbCommand dbc = CreateSelectCommand();
            string wherelst = (filter != null && filter.Trim() != "") ? (" WHERE " + filter) : "";

            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;


            if (idb.db.GetType().Name.Contains("MYSQL"))
            {
                if (Top > 0)
                {
                    dbc.CommandText += string.Format("   LIMIT 0 , {0} ", Top);
                }
            }

            string sql = string.Format("SELECT {0} FROM {3} {1}  GROUP BY {2}", choose, wherelst, groupby, idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar());

            dr = idb.GetDataReader(dbc);
            while ((dr.Read()))
            {
                D t = Activator.CreateInstance<D>();
                foreach (var item in typeof(D).GetProperties())
                {
                    DataFieldAttribute dfa = GetDataFieldAttrib(item);
                    if (dfa != null)
                    {
                        string colname = dfa.ColumnName;
                        if (dr.GetSchemaTable().Select("ColumnName='" + colname.Trim('[', ']') + "'").Length > 0 && dr[colname] != DBNull.Value)
                        {
                            item.SetValue(t, dr[colname], null);
                        }
                    }
                }
                lt.Add(t);
            }
            dr.Close();
            idb.Close();
            return lt;
        }
        /// <summary>
        /// 使用一个Model的非空值来查询数据
        /// </summary>
        /// <returns>返回查询结果</returns>
        /// <exception cref="NotAKeelModelException">不是一个Model</exception>
        /// <param name="filter">作为查询条件的Model</param>
        /// <param name="fields">指定作为查询条件的字段列表</param>
        /// <param name="Top">指定只取前面的多少行</param>
        public List<T> SelectEntitys(T filter, string fields, int Top)
        {
            DbDataReader dr = null;
            List<T> lt = new List<T>();
            DbCommand dbc = CreateSelectCommand(Top);
            string wherelst = GetFilter(filter, dbc, fields);
            if (wherelst != null && wherelst.Trim() != "")
            {
                dbc.CommandText += " WHERE " + wherelst;

                if (idb.db.GetType().Name.Contains("MYSQL"))
                {
                    dbc.CommandText += string.Format("   LIMIT 0 , {0} ", Top);
                }

            }
            dr = idb.GetDataReader(dbc);
            while ((dr.Read()))
            {
                T t = Activator.CreateInstance<T>();
                foreach (var item in typeof(T).GetProperties())
                {
                    DataFieldAttribute dfa = GetDataFieldAttrib(item);
                    if (dfa != null)
                    {
                        string colname = dfa.ColumnName;
                        if (dr[colname] != DBNull.Value)
                        {
                            item.SetValue(t, dr[colname], null);
                        }
                    }
                }
                lt.Add(t);
            }
            dr.Close();
            idb.Close();
            return lt;
        }
        public List<T> SelectEntitys(string    filter ,int index, int count )
        {
            DbDataReader dr = null;
            List<T> lt = new List<T>();
            string wherelst = filter;
            DbCommand dbc = CreateSelectCommand(0, true, wherelst, index, count);
            dr = idb.GetDataReader(dbc);
            while ((dr.Read()))
            {
                T t = Activator.CreateInstance<T>();
                foreach (var item in typeof(T).GetProperties())
                {
                    DataFieldAttribute dfa = GetDataFieldAttrib(item);
                    if (dfa != null)
                    {
                        string colname = dfa.ColumnName;
                        if (dr[colname] != DBNull.Value)
                        {
                            item.SetValue(t, dr[colname], null);
                        }
                    }
                }
                lt.Add(t);
            }
            dr.Close();
            idb.Close();
            return lt;
        }
        /// <summary>
        /// 根据qp提供的筛选器选取数据
        /// </summary>
        /// <param name="qpfilter">qf条件列表</param>

        /// <param name="Top">选取多少行</param>
        /// <returns></returns>
        public List<T> SelectEntitys(List<QP> qpfilter)
        {
            return SelectEntitys(qpfilter, 0);
        }
        /// <summary>
        /// 根据qp提供的筛选器选取数据
        /// </summary>
        /// <param name="qpfilter">qf条件列表</param>
        /// <returns></returns>
        public List<T> SelectEntitys(string sql, string where)
        {
            DbCommand dbc = CreateSelectCommand(0);
            dbc.CommandText = sql;

            return SelectEntitys(0, dbc, where);
        }
        /// <summary>
        /// 根据qp提供的筛选器选取数据
        /// </summary>
        /// <param name="qpfilter">qf条件列表</param>
        /// <returns></returns>
        public List<T> SelectEntitys(List<QP> qpfilter, int Top)
        {
            DbCommand dbc = CreateSelectCommand(Top);
            string filter = GetFilter(qpfilter, dbc);
            return SelectEntitys(Top, dbc, filter);
        }
        /// <summary>
        /// 使用指定的查询字符串用指定的值作为变量进行查询
        /// </summary>
        /// <param name="filterstr"></param>
        /// <param name="filter"></param>
        /// <param name="fields"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public List<T> SelectEntitys(string filterstr, T filter, string fields, int Top)
        {
            DbCommand dbc = CreateSelectCommand(Top);
            string wherelst = GetFilter(filter, dbc, fields);
            wherelst = filterstr;
            return SelectEntitys(Top, dbc, wherelst);
        }

        private List<T> SelectEntitys(int Top, DbCommand dbc, string wherelst)
        {
            List<T> lt = new List<T>();
            DbDataReader dr = null;

            if (wherelst != null && wherelst.Trim() != "")
            {
                dbc.CommandText += " WHERE " + wherelst;

                if (idb.db.GetType().Name.Contains("MYSQL"))
                {
                    dbc.CommandText += string.Format("   LIMIT 0 , {0} ", Top);
                }

            }
            dr = idb.GetDataReader(dbc);
            while ((dr.Read()))
            {
                T t = Activator.CreateInstance<T>();
                foreach (var item in typeof(T).GetProperties())
                {
                    DataFieldAttribute dfa = GetDataFieldAttrib(item);
                    if (dfa != null)
                    {
                        string colname = dfa.ColumnName;
                        if (dr[colname] != DBNull.Value)
                        {
                            item.SetValue(t, dr[colname], null);
                        }
                    }
                }
                lt.Add(t);
            }
            dr.Close();
            idb.Close();
            return lt;
        }

        private   string GetFilter(T filter, DbCommand dbc)
        {
            return GetFilter(filter, dbc, null);
        }
        private   string GetFilter(T filter, DbCommand dbc, string field)
        {
            string wherelst = "";
            foreach (var itemt in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(itemt);
                if (dfa == null) continue;
                object objwhere = itemt.GetValue(filter, null);

                if (objwhere != null)
                {
                    if (field == null || field.ToLower().Contains(Common.GetWithIdentifier(dfa.ColumnName.ToLower())))
                    {
                        wherelst += (wherelst != "" ? " AND " : "") + Common.GetWithIdentifier(dfa.ColumnName) + " = " + idb.db.GetParamIdentifierChar() + "where_" + dfa.ColumnName;
                        dbc.Parameters.Add(CreateParameter(dbc, itemt, dfa, "where_" + dfa.ColumnName, objwhere));
                    }
                }
            }
            return wherelst;
        }

        private DbCommand CreateSelectCommand()
        {
            return CreateSelectCommand(0);
        }
        private DbCommand CreateSelectCommand(int Top)
        {
            return CreateSelectCommand(0, false,null ,0,0);
        }
        private DbCommand CreateSelectCommand(int Top,bool xpager,string xpsql,int xindex, int xcount)
        {
            string sql=null ;
            if (Top > 0)
            {

                if (Keel.DB.Common.NowDataBase.GetType().Name.Contains("MYSQL"))
                {
                    sql += string.Format("TOP {0} ", Top);
                }

            }
            if (typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true).Length == 0)
                throw new NotAKeelModelException();

            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            string collist = null;
            DbCommand dbc = idb.CreateDbCommand();
            string firstcol=null ;
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                string colname = dfa.ColumnName;
  if (firstcol == null) firstcol = colname;
                collist += (collist != null ? "," : "") + idb.db.GetIdentifierStartChar() + colname + idb.db.GetIdentifierEndChar();
            }
            if (xpager)
            {
                sql = string.Format(
@"SELECT {0}  FROM 
     (SELECT    row_number() over ( ORDER BY {1} ) as keelid,{0} FROM {2}  {3} )
  AS  KeelTemp 
WHERE KeelTemp.keelid >={4} AND KeelTemp.keelid <{4}+{5}
"
                    , collist, firstcol
                     ,  Common.NowDataBase.GetIdentifierStartChar() + tablename + Common.NowDataBase.GetIdentifierEndChar()
                     , xpsql==null ?"":"WHERE "+ xpsql , xindex, xcount);
            }
            else
            {
                sql ="SELECT "+ collist + "  FROM " + Common.NowDataBase.GetIdentifierStartChar() + tablename + Common.NowDataBase.GetIdentifierEndChar();
            }
            dbc.CommandText = sql;
            return dbc;
        }
        #endregion

        #region insert 部分
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="t"></param>
        /// <returns>如果ID是自动生成的则返回ID,否则返回影响行数</returns>
        public int Insert(T t)
        {
            bool isauto;
            DbCommand dbc = CreateInsertCommand(t, out isauto);
            int i = idb.ExecuteNonQuery(dbc,isauto);
            return i;

        }

        /// <summary>
        /// 插入一个实体，并从数据库中获取服务器处理后的值，通常用于部分列自动生成或自动计算。
        /// </summary>
        /// <param name="t">欲插入列</param>
        /// <returns>如果主键是自动生成列则返回主键值，否则返回影响行数。</returns>
        public int Insert(ref T t)
        {
            bool isauto;
            string filter;
            DbParameter dbp;
            DbCommand dbc = CreateInsertCommand(t, out isauto, out filter, out dbp);
            int i = idb.ExecuteNonQuery(dbc, isauto);
            SelectForRef(t, isauto, ref filter, dbp, ref dbc, i);
            return i;

        }

        private void SelectForRef(T t, bool isauto, ref string filter, DbParameter dbp, ref DbCommand dbc, int i)
        {
            dbc = CreateSelectCommand();
            if (isauto)
            {
                filter = string.Format(filter, i);
            }
            else
            {
                dbc.Parameters.Add(dbp);
            }
            dbc.CommandText += " WHERE " + filter;
            DbDataReader dr = idb.GetDataReader(dbc);
            if (dr.Read())
            {
                foreach (var item in typeof(T).GetProperties())
                {
                    DataFieldAttribute dfa = GetDataFieldAttrib(item);
                    if (dfa != null)
                    {
                        string colname = dfa.ColumnName;
                        if (dr[colname] != DBNull.Value)
                        {
                            item.SetValue(t, dr[colname], null);
                        }
                    }
                }
            }
            dr.Close();
            idb.Close();
        }

        private DbCommand CreateInsertCommand(T t, out bool isautoidentitiy)
        {
            string filter;
            DbParameter dbp;
            return CreateInsertCommand(t, out isautoidentitiy, out filter, out dbp);

        }
        private DbCommand CreateInsertCommand(T t, out bool isautoidentitiy, out string filter, out DbParameter dbparm)
        {
            isautoidentitiy = false;
            dbparm = null;
            filter = null;
            string sql = "INSERT INTO ";
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            sql += idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar();
            string collist = null;
            string param = null;
            DbCommand dbc = idb.CreateDbCommand();
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                string colname = dfa.ColumnName;
                if (dfa.IsKey)
                {
                    if (dfa.IsAutoIdentitiy)
                    {
                        filter = colname + " ={0}";
                        isautoidentitiy = true;
                    }
                    else
                    {
                        filter = colname + " =" + idb.db.GetParamIdentifierChar() + colname;
                        dbparm = CreateParameter(dbc, item, dfa, colname, item.GetValue(t, null));
                    }
                }
                if (dfa.IsAutoIdentitiy || dfa.IsComputed) continue;
                object v = item.GetValue(t, null);
                if (v != null)
                {
                    dbc.Parameters.Add(CreateParameter(dbc, item, dfa, colname, item.GetValue(t, null)));
                    collist += (collist != null ? "," : "") + idb.db.GetIdentifierStartChar() + colname + idb.db.GetIdentifierEndChar();
                    param += (param != null ? "," : "") + idb.db.GetParamIdentifierChar() + colname;
                }
            }
            sql += "  (" + collist + ")      VALUES (" + param + " );";
            dbc.CommandText = sql;
            return dbc;
        }


        #endregion

        #region update 部分

        /// <summary>
        /// 将WhereValue的非空值属性作为条件更新表中符合SetValue非空值属性的字段
        /// </summary>
        /// <param name="SetValue">所有符合where的记录将使用此对象中的非空属性中的值更新</param>
        /// <returns>返回受影响行数</returns>
        /// <param name="filter">更新时条件</param>
        public int Update(string filter, T SetValue)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return Update(filter, SetValue, dbc);
        }
        /// <summary>
        /// 根据qp来更新符合条件的数据
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="SetValue"></param>
        /// <returns></returns>
        public int Update(List<QP> filter, T SetValue)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return Update(GetFilter(filter, dbc), SetValue, dbc);
        }


        private int Update(string filter, T SetValue, DbCommand dbc)
        {
            string sql = "UPDATE ";
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            sql += idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar();

            string setlst = null;

            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                object objset = item.GetValue(SetValue, null);
                if (objset != null && !dfa.IsKey && !dfa.IsAutoIdentitiy && !dfa.IsComputed)
                {
                    setlst += (setlst != null ? "," : "") + idb.db.GetIdentifierStartChar() + dfa.ColumnName + idb.db.GetIdentifierEndChar() + " = " + idb.db.GetParamIdentifierChar() + "set_" + dfa.ColumnName;
                    dbc.Parameters.Add(CreateParameter(dbc, item, dfa, "set_" + dfa.ColumnName, objset));
                }
            }
            sql += " SET " + setlst;
            if (filter != null && filter.Trim() != "")
            {
                sql += " WHERE  " + filter;
            }
            dbc.CommandText = sql;
            int i = idb.ExecuteNonQuery(dbc);
            return i;
        }
        /// <summary>
        /// 根据指定的字符串筛选器 根据指定的setvalue 更新数据
        /// </summary>
        /// <param name="filter">筛选器</param>
        /// <param name="setvalue">设置值得字符串</param>
        /// <returns>返回影响的行数</returns>
        public int Update(string filter, string setvalue)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return Update(filter, setvalue, dbc);
        }
        /// <summary>
        /// 根据指定的qp条件更新数据
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="setvalue"></param>
        /// <returns></returns>
        public int Update(List<QP> filter, string setvalue)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return Update(GetFilter(filter, dbc), setvalue, dbc);
        }
        private int Update(string filter, string setvalue, DbCommand dbc)
        {
            string sql = "UPDATE ";
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            sql += idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar();
            string setlst = setvalue;
            sql += " SET " + setlst;
            if (filter != null && filter.Trim() != "")
            {
                sql += " WHERE  " + filter;
            }
            dbc.CommandText = sql;
            int i = idb.ExecuteNonQuery(dbc);
            return i;
        }
        public  int Update<K>(string filter,string filed, K   value )
        {
            DbCommand dbc = idb.CreateDbCommand();
            string sql = "UPDATE ";
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            sql += idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar();
        
            sql += string.Format (" SET [{0}]={1}value_{0} ",filed,idb.db.GetParamIdentifierChar())  ;
            if (filter != null && filter.Trim() != "")
            {
                sql += " WHERE  " + filter;
            }
            dbc.Parameters.Add(
                CreateParameter(
                dbc
                , string.Format("value_{0}", filed)
                , value));

            dbc.CommandText = sql;
            int i = idb.ExecuteNonQuery(dbc);
            return i;
        }
        /// <summary>
        /// 将WhereValue的非空值属性作为条件更新表中符合SetValue非空值属性的字段
        /// </summary>
        /// <param name="WhereValue">该对象中的非空对象将作为where条件</param>
        /// <param name="SetValue">所有符合where的记录将使用此对象中的非空属性中的值更新</param>
        /// <returns>返回受影响行数</returns>
        public int Update(T WhereValue, T SetValue)
        {

            string sql = "UPDATE ";
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            sql += idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar();
            string wherelst = null;
            string setlst = null;
            DbCommand dbc = idb.CreateDbCommand();
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                object objwhere = item.GetValue(WhereValue, null);
                object objset = item.GetValue(SetValue, null);
                if (objwhere != null)
                {
                    wherelst += (wherelst != null ? " AND " : "") + idb.db.GetIdentifierStartChar() + dfa.ColumnName + idb.db.GetIdentifierEndChar() + " = " + idb.db.GetParamIdentifierChar() + "where_" + dfa.ColumnName;
                    dbc.Parameters.Add(CreateParameter(dbc, item, dfa, "where_" + dfa.ColumnName, objwhere));
                }
                if (objset != null && !dfa.IsKey && !dfa.IsAutoIdentitiy && !dfa.IsComputed)
                {
                    setlst += (setlst != null ? "," : "") + Common.GetWithIdentifier(dfa.ColumnName) + " = " + idb.db.GetParamIdentifierChar() + "set_" + dfa.ColumnName;
                    dbc.Parameters.Add(CreateParameter(dbc, item, dfa, "set_" + dfa.ColumnName, objset));
                }

            }
            sql += " SET " + setlst + " WHERE  " + wherelst;
            dbc.CommandText = sql;
            int i = idb.ExecuteNonQuery(dbc);
            return i;
        }
        /// <summary>
        /// 根据指定的值t更新数据库，如果t中没有主键将更新表中所有记录的t的非空字段
        /// </summary>
        /// <param name="t">要更新的内容</param>
        /// <returns></returns>
        /// <remarks>如果没有主键将更新表中所有t中非空字段</remarks>
        public int Update(T t)
        {
            int i = 0;
            bool isauto;
            string filter;
            DbParameter dbp;
            DbCommand dbc = CreateUpdateCommand(t, out isauto, out filter, out dbp);
            if (!isauto && dbp != null)
            {
                dbc.Parameters.Add(dbp);
            }
            if (filter != null && filter.Trim() != "")
            {
                dbc.CommandText += " WHERE  " + filter;
            }
            i = idb.ExecuteNonQuery(dbc);
            return i;
        }
        /// <summary>
        /// 更新一个实体，常用于部分列为自动计算
        /// 根据指定的值t更新数据库，如果t中没有主键将更新表中所有记录的t的非空字段
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <remarks>如果没有主键将更新表中所有t中非空字段</remarks>
        public int Update(ref T t)
        {
            int i = 0;
            bool isauto;
            string filter;
            DbParameter dbp;
            DbCommand dbc = CreateUpdateCommand(t, out isauto, out filter, out dbp);
            if (!isauto && dbp != null)
            {
                dbc.Parameters.Add(dbp);
            }
            if (filter != null && filter.Trim() != "")
            {
                dbc.CommandText += " WHERE  " + filter;
            }
            i = idb.ExecuteNonQuery(dbc);
            SelectForRef(t, isauto, ref filter, dbp, ref dbc, i);
            return i;
        }




        private DbCommand
            CreateUpdateCommand(T t, out bool isautoidentitiy, out string filter, out DbParameter dbparm)
        {
            isautoidentitiy = false;
            dbparm = null;
            filter = null;
            string sql = "UPDATE ";
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            sql += idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar();
            string collist = null;
            DbCommand dbc = idb.CreateDbCommand();
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;

                string colname = dfa.ColumnName;
                if (dfa.IsKey)
                {
                    if (dfa.IsKey && dfa.IsAutoIdentitiy)
                    {
                        filter = colname + " =" + item.GetValue(t, null).ToString();//取得子送生成ID的值。 
                        isautoidentitiy = true;
                    }
                    else
                    {
                        filter = colname + " =" + idb.db.GetParamIdentifierChar() + colname;
                        dbparm = CreateParameter(dbc, item, dfa, colname, item.GetValue(t, null));
                    }
                }
                if (dfa.IsAutoIdentitiy || dfa.IsComputed || dfa.IsKey) continue;
                object v = item.GetValue(t, null);
                if (v != null)
                {
                    if (item.PropertyType == typeof(DateTime))
                    {
                        ///如果是日期， 且年小宇1970年，则不处理
                        DateTime vvv = (DateTime)v;
                        if (vvv.Year < 1970) continue;
                    }

                    DbParameter dp = CreateParameter(dbc, item, dfa, colname, v);
                    dbc.Parameters.Add(dp);
                    collist += (collist != null ? "," : "") + idb.db.GetIdentifierStartChar() + colname + idb.db.GetIdentifierEndChar() + " = " + idb.db.GetParamIdentifierChar() + colname;

                }

            }
            if (filter == null || filter.Trim() == "") throw new KeyNotFoundException();
            sql += " SET " + collist;
            dbc.CommandText = sql;
            return dbc;
        }

        private   DbParameter CreateParameter(DbCommand dbc, System.Reflection.PropertyInfo item, DataFieldAttribute dfa, string colname, object v)
        {
            DbParameter dp = dbc.CreateParameter();
            dp.ParameterName = idb.db.GetParamIdentifierChar() + colname;
            if (dfa.DBType == null)
            {
                dp.DbType = Common.NowDataBase.PasteType(item.PropertyType);
            }
            else
            {
                dp.DbType = Common.GetDBTypeByString(dfa.DBType);
            }
            dp.Value = v;
            return dp;
        }

        private   DbParameter CreateParameter(DbCommand dbc, string colname, object v)
        {
            DbParameter dp = dbc.CreateParameter();
            dp.ParameterName = idb.db.GetParamIdentifierChar() + colname;

            dp.Value = v;
            return dp;
        }
        


        #endregion


        #region delete 部分
        /// <summary>
        /// 删除符合filter的所有记录
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>返回影响行数</returns>
        public int Delete(string filter)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return Delete(filter, dbc);
        }
        /// <summary>
        /// 根据qp列表来查询并删除数据
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public int Delete(List<QP> filter)
        {
            DbCommand dbc = idb.CreateDbCommand();
            return Delete(GetFilter(filter, dbc), dbc);
        }

        private int Delete(string filter, DbCommand dbc)
        {
            string sql = "DELETE FROM  ";
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            sql += idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar();

            if (filter != null && filter.Trim() != "")
            {
                sql += " WHERE  " + filter;
            }
            dbc.CommandText = sql;
            int i = idb.ExecuteNonQuery(dbc);
            return i;
        }
        /// <summary>
        /// 将t作为where条件，删除所有符合条件的内容。
        /// </summary>
        /// <param name="t">实体，用于where条件，空属性(值为null)将忽略</param>
        /// <returns>返回受影响的行数</returns>
        public int Delete(T t)
        {
            int i = 0;
            string sql = "DELETE FROM  ";
            string tablename = ((Keel.ORM.DataTableAttribute)typeof(T).GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true)[0]).TableName;
            sql += idb.db.GetIdentifierStartChar() + tablename + idb.db.GetIdentifierEndChar();
            string wherelst = null;
            DbCommand dbc = idb.CreateDbCommand();
            foreach (var item in typeof(T).GetProperties())
            {
                DataFieldAttribute dfa = GetDataFieldAttrib(item);
                if (dfa == null) continue;
                object objwhere = item.GetValue(t, null);

                if (dfa.IsKey)
                {
                    wherelst += (wherelst != null ? " AND " : "") + idb.db.GetIdentifierStartChar() + dfa.ColumnName + idb.db.GetIdentifierEndChar() + " = " + idb.db.GetParamIdentifierChar() + "where_" + dfa.ColumnName;
                    DbParameter wdp = CreateParameter(dbc, item, dfa, "where_" + dfa.ColumnName, objwhere);
                    dbc.Parameters.Add(wdp);
                }
            }
            sql += " WHERE  " + wherelst;
            if (wherelst == null || wherelst.Trim() == "") throw new KeyNotFoundException();
            dbc.CommandText = sql;
            i = idb.ExecuteNonQuery(dbc);
            return i;
        }

        internal static DataFieldAttribute GetDataFieldAttrib(System.Reflection.PropertyInfo item)
        {
            object[] objs = item.GetCustomAttributes(typeof(Keel.ORM.DataFieldAttribute), true);
            DataFieldAttribute dfa = null;
            if (objs != null && objs.Length > 0)
            {
                dfa = item.GetCustomAttributes(typeof(Keel.ORM.DataFieldAttribute), true)[0] as DataFieldAttribute;
            }
            return dfa;
        }
        #endregion

        #region id计算使用方法和对象序列化
        /// <summary>
        /// 将一个对象转换为实体隐射后的base64编码，其后带有md5验证
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string ToBase64Str(T obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            string md = GetMD5(ms.ToArray());
            string str = Convert.ToBase64String(ms.ToArray()) + " " + md + System.Environment.NewLine;
            return str;
        }
        /// <summary>
        /// 将使用ToBase64Str得到的字符串转换为对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public T FromBase64Str(string str)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.AssemblyFormat = FormatterAssemblyStyle.Simple;

            string[] tmpary = str.Split(" ".ToCharArray());
            byte[] binary = Convert.FromBase64String(tmpary[0]);
            MemoryStream ms = new MemoryStream(binary);
            T obj = (T)bf.Deserialize(ms);
            string md = GetMD5(binary);
            if (md == tmpary[1].Trim())
            {
                ms.Dispose();
                return obj;
            }
            else
            {
                ms.Dispose();
                return default(T);
            }
        }
        /// <summary>
        /// 提供一个guid的快捷方式
        /// </summary>
        /// <returns></returns>
        public Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }
        /// <summary>
        /// 使用类型名称和guid的Md5作为ID.
        /// </summary>
        /// <returns>返回值为32位</returns>
        public string GetID()
        {
            string id = typeof(T).Name + Guid.NewGuid().ToString();
            return GetMD5(id);
        }
        /// <summary>
        /// 使用类型名称和guid的Md5作为ID.
        /// </summary>
        public string GetID(int lenght)
        {
            return GetID().Substring(0, lenght);
        }
        /// <summary>
        /// 使用类型名称和guid的Md5作为ID.
        /// </summary>
        public string GetID(int start, int lenght)
        {
            return GetID().Substring(start, lenght);
        }
        /// <summary>
        /// 如果你确认某个字段或和当前数据相关的某字符串在该表中永远不重复，那么你可以使用他和表名的md5作为ID
        /// </summary>
        /// <param name="defaultstring"></param>
        /// <returns></returns>
        public string GetID(string defaultstring)
        {
            string id = typeof(T).Name + defaultstring;
            return GetMD5(id);
        }
        /// <summary>
        /// 如果你确认某个字段或和当前数据相关的某字符串在该表中永远不重复，那么你可以使用他和表名的md5作为ID
        /// </summary>
        public string GetID(string defaultstring, int lenght)
        {
            return GetID(defaultstring).Substring(0, lenght);
        }
        /// <summary>
        /// 如果你确认某个字段或和当前数据相关的某字符串在该表中永远不重复，那么你可以使用他和表名的md5作为ID
        /// </summary>
        /// <param name="defaultstring"></param>
        /// <param name="start"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        public string GetID(string defaultstring, int start, int lenght)
        {
            return GetID(defaultstring).Substring(start, lenght);
        }
        /// <summary>
        /// 返回制定字符串的32位md5值
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string GetMD5(string txt)
        {
            return GetMD5(System.Text.Encoding.Default.GetBytes(txt));
        }
        /// <summary>
        /// 获得指定的二进制数组的32位md5值
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        public string GetMD5(byte[] binary)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(binary));
            t2 = t2.Replace("-", "");
            md5.Dispose();
            return t2;
        }


        ///// <summary>
        ///// 将一个结构转换为字符串
        ///// </summary>
        ///// <param name="t"></param>
        ///// <returns>返回一个字符串</returns>
        //public   string StructToString(T t)
        //{
        //    int rawsize = Marshal.SizeOf(t );//得到内存大小
        //    IntPtr buffer = Marshal.AllocHGlobal(rawsize);//分配内存
        //    Marshal.StructureToPtr(t , buffer, true);//转换结构
        //    byte[] rawdatas = new byte[rawsize];
        //    Marshal.Copy(buffer, rawdatas, 0, rawsize);//拷贝内存
        //    Marshal.FreeHGlobal(buffer); //释放内存
        //    return Encoding.Default.GetString(rawdatas);
        //}
        ///// <summary>
        ///// 将一个字符串装转换为结构
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns>返回一个结构</returns>
        //public T  StringToStruct(string s)
        //{
        //    Type anytype = typeof(T );
        //    T t = default(T);
        //    byte[] rawdatas = Encoding.Default .GetBytes(s);
        //    int rawsize = Marshal.SizeOf(anytype);
        //    if (rawsize > rawdatas.Length)
        //        t  =(T)Activator.CreateInstance(typeof (T ));
        //    IntPtr buffer = Marshal.AllocHGlobal(rawsize);
        //    Marshal.Copy(rawdatas, 0, buffer, rawsize);
        //    object retobj = Marshal.PtrToStructure(buffer, anytype);
        //    Marshal.FreeHGlobal(buffer);
        //    t  = (T )retobj;
        //    return t;
        //}
        #endregion



        public int ExecSQL(string STR)
        {
            DbCommand dbc = idb.CreateDbCommand();
            dbc.CommandText = STR;
            idb.OpenConnection();
            int r = dbc.ExecuteNonQuery();
            idb.CloseConnection();
            return r;
        }
    }
} 
