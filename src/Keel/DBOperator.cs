using System;
using System.Data;
using System.Data.Common;
namespace Keel
{
    internal sealed class KitVar
    {
       public static string AppConnectString =null  ;
       public static DbProviderFactory AppProviderFactory = null;
    }
    /// <summary>
    /// 存储过程执行方法
    /// </summary>
    public enum SPExcMethod
    {
        /// <summary>
        /// 返回单值,支持任何基本类型.
        /// </summary>
        ExecuteScalar,
        /// <summary>
        /// 支持 DataTable和 DataSet
        /// </summary>
        Fill,
        /// <summary>
        /// 支持Model内的任意类型
        /// </summary>
        Model,
        /// <summary>
        /// 方法支持int类型
        /// </summary>
        List,
        /// <summary>
        /// 仅仅支持 int .
        /// </summary>
        ExecuteNonQuery
    }
 /// <summary>
 /// 数据库操作器
 /// </summary>
 /// <typeparam name="T">指定是何种数据库</typeparam>
   //[System.Diagnostics.DebuggerStepThroughAttribute()]
    public sealed  class DBOperator<T>
    {

       internal   IDatabase db = null;
        DbProviderFactory dbf = null;
        DbConnection cnt = null;
        Keel.DB.Common _common = null;
        /// <summary>
        /// 实例化一个数据库，该数据库自动从配置文件中读取
        /// </summary>
        public DBOperator()
        {
            if (_common == null)
            {
                _common = new Keel.DB.Common();
            }
            db =Keel.DB.Common.NowDataBase ;
            dbf = db.GetProviderFactory();
            cnt = dbf.CreateConnection();
            cnt.ConnectionString = db.ConnectString;
        }
        /// <summary>
        /// 实例化一个指定类型的数据库访问操作器
        /// </summary>
        /// <param name="t"></param>
        public DBOperator(T t)
        {
            db = ((IDatabase)t );
            dbf = db.GetProviderFactory();
            cnt =  dbf.CreateConnection();
            cnt.ConnectionString = db.ConnectString;
        }
        
        /// <summary>
        /// 创建一个DBCommand
        /// </summary>
        /// <returns></returns>
        public DbCommand CreateDbCommand()
        {
            DbCommand _DbCommand =cnt.CreateCommand();
            _DbCommand.Transaction = _Transaction;
            return _DbCommand;
        }

        DbTransaction _Transaction = null;
        /// <summary>
        /// 开始数据库事务
        /// </summary>
        /// <returns></returns>
        public void   BeginTransaction()
        {
            OpenConnection();
            _Transaction=cnt.BeginTransaction() ;
     
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public  void  RollbackTransaction()
        {
            _Transaction.Rollback();
            CloseConnection(true);
        }
        /// <summary>
        /// 提交数据库事务
        /// </summary>
        public void CommitTransaction()
        {
            _Transaction.Commit();
            CloseConnection(true);

        }
        /// <summary>
        /// 以指定的隔离级别启动数据库事务
        /// </summary>
        /// <param name="isolationLevel"></param>
 
        public void  BeginTransaction(IsolationLevel isolationLevel)
        {
            OpenConnection();
             _Transaction = cnt.BeginTransaction(isolationLevel);
        }
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void OpenConnection()
        {
            CloseConnection();
            if (cnt != null && cnt.State != ConnectionState.Open) cnt.Open();
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConnection()
        {
            CloseConnection(false);
        }
        /// <summary>
        /// 关闭数据库连接，并指定是否是事务连接
        /// </summary>
        /// <param name="isTransaction">是否有事务</param>
        public void CloseConnection(bool isTransaction)
        {
            if (cnt != null)
            {
                if (isTransaction)
                {
                    cnt.Close();
                    _Transaction = null;
                }
                else
                {
                    if (_Transaction == null) cnt.Close();
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，仅仅返回影响行数。
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="returnid">返回 ID</param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand cmd,bool returnid)
        {
            int i = 0;

            try
            {
                OpenConnection();
                i = cmd.ExecuteNonQuery();
                if (i == 1 && returnid)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT @@IDENTITY";
                    int.TryParse( cmd.ExecuteScalar().ToString (),out i );
                }
            }
            catch (Exception  )
            {
                throw  ;
            }
            finally
            {
                CloseConnection();
            }
            return i;
        }
        /// <summary>
        /// 执行SQL语句，仅仅返回影响行数。
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(  DbCommand cmd)
        {
            int i = 0;

            try
            {
                OpenConnection();
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception    )
            {
                throw  ;
            }
            finally
            {
                CloseConnection();
            }
            return i;
        }
 

        /// <summary>
        /// 执行SQL语句，并返回影响行数
        /// </summary>
        /// <param name="sql">您要执行的SQL语句</param>
        /// <returns>影响行数</returns>
        public int ExecuteNonQuery(string sql)
        {
            int i = 0;
             
            try
            {
                OpenConnection();
                DbCommand dbc = cnt.CreateCommand();
                dbc.CommandText = sql;

                i = dbc.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return i;
        }
        /// <summary>
        /// 执行一个sql语句，并返回第一行的第一列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回值</returns>
        public object  ExecuteScalar(string sql)
        {
            object  i = null ;

            try
            {
                OpenConnection();
                DbCommand dbc = cnt.CreateCommand();
                dbc.CommandText = sql;
                i = dbc.ExecuteScalar ();
                
            }
            catch (Exception  )
            {
                
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return i;
        }
        /// <summary>
        /// 执行一个sql语句并返回一个DataReader 读取完成后需要自行关闭链接
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DbDataReader   GetDataReader(string sql)
        {
            DbDataReader dr = null;
            OpenConnection();
            DbCommand dbc = cnt.CreateCommand();
            dbc.CommandText = sql;
            dr = dbc.ExecuteReader();
            return dr ;
        }
        /// <summary>
        ///  执行一个Command并返回一个DataReader 读取完成后需要自行关闭链接
        /// </summary>
        /// <param name="dbc"></param>
        /// <returns></returns>
        public DbDataReader GetDataReader(DbCommand dbc)
        {
            DbDataReader dr = null;
            OpenConnection();
            dr = dbc.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// 关闭链接
        /// </summary>
        public void Close()
        {
            CloseConnection();
        }
        /// <summary>
        /// 执行sql并将结果填充至DataTable 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable  ExecuteFillDataTable(string sql)
        {
            DataTable  dt  = null;
            try
            {
                OpenConnection();
                DbCommand dbc = cnt.CreateCommand();
                dbc.CommandText = sql;
                DbDataAdapter da = dbf.CreateDataAdapter();
                da.SelectCommand = dbc;
                dt = new DataTable();
                da.Fill(dt );
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
        /// <summary>
        /// 执行sql并将结果填充至DataTable 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int FillData(string sql, DataTable dt)
        {
            return ExecuteFillDataTable(sql, dt, true);
        }
          /// <summary>
        /// 执行sql并将结果填充至DataTable 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteFillDataTable(string sql, DataTable dt)
        {
            return ExecuteFillDataTable(sql, dt, true);
        }
        /// <summary>
        /// 执行sql并将结果填充至DataTable 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int  FillData (string sql, DataTable dt, bool clearData)
        {
            return ExecuteFillDataTable(sql, dt, clearData);
        }
        /// <summary>
        /// 执行sql并将结果填充至DataTable 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public  int  ExecuteFillDataTable(string sql,DataTable dt,bool clearData)
        {
            int result = 0;
            try
            {
                OpenConnection();
                DbCommand dbc = cnt.CreateCommand();
                dbc.CommandText = sql;
                DbDataAdapter da = dbf.CreateDataAdapter();
                da.SelectCommand = dbc;
                if (clearData) dt.Clear();
                result = da.Fill(dt);
            }
            finally
            {
                CloseConnection();
            }
            return result ;
        }
        /// <summary>
        /// 返回一个数据适配器
        /// </summary>
        /// <returns></returns>
        public DbDataAdapter CreateDataAdapter()
        {
           return    dbf.CreateDataAdapter();
        }
        /// <summary>
        /// 执行sql填充数据到 DataSet,并指定是否清理旧数据
        /// </summary>
        public int FillData(string sql, DataSet ds)
        {
            return ExecuteFillDataSet(sql, ds, true);
        }
        /// <summary>
        /// 执行sql填充数据到 DataSet,并指定是否清理旧数据
        /// </summary>
        public int ExecuteFillDataSet(string sql, DataSet ds)
        {
            return ExecuteFillDataSet(sql, ds, true);
        }
        /// <summary>
        /// 执行sql填充数据到 DataSet,并指定是否清理旧数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ds"></param>
        /// <param name="clearData"></param>
        /// <returns></returns>
        public int FillData(string sql, DataSet ds, bool clearData)
        {
            return ExecuteFillDataSet(sql, ds, clearData);
        }
        /// <summary>
        ///  执行sql并将结果填充至DataSet 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteFillDataSet(string sql, DataSet ds,bool clearData)
        {
            int result = 0;
            try
            {
                OpenConnection();
                DbCommand dbc = cnt.CreateCommand();
                dbc.CommandText = sql;
                DbDataAdapter da = dbf.CreateDataAdapter();
                da.SelectCommand = dbc;
                if (clearData) ds.Clear();
                result = da.Fill(ds);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        /// <summary>
        ///  执行sql并将结果填充至DataSet 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet ExecuteFillDataSet(string sql)
        {
            DataSet  ds = null ;
            try
            {
                OpenConnection();
                DbCommand dbc = cnt.CreateCommand();
                dbc.CommandText = sql;
                DbDataAdapter da = dbf.CreateDataAdapter();
                da.SelectCommand  = dbc;
                ds = new DataSet();
                da.Fill(ds);
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
    }
}
