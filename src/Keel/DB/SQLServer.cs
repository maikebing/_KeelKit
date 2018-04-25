using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Keel.ORM;
using System.Data;
using System.Data.SqlClient;

namespace Keel.DB
{
    /// <summary>
    /// SQLServer数据库操作器
    /// </summary>
    public sealed class SQLServer : IDatabase 

    {
        /// <summary>
        /// 根据连接字符串新建一个SQLServer实例
        /// </summary>
        /// <param name="connectstring"></param>
        public SQLServer(string connectstring)
        {
            ConnectString = connectstring;
        }
        /// <summary>
        /// 取得一个提供器 
        /// </summary>
        /// <returns></returns>
        public DbProviderFactory GetProviderFactory()
        {
            return System.Data.SqlClient.SqlClientFactory.Instance;  
        }
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string ConnectString { get; set; }
        /// <summary>
        /// 字符串形式的数据库类型转换为系统类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public Type PasteType(string dbtypestring)
        {
            Type t = null;
            SqlDbType sd = SqlDbType.Variant;
            if (Enum.TryParse<SqlDbType>(dbtypestring,true , out sd))
            {
                sd = GetSQLDBTypeByString(dbtypestring);
                t = MetaType.GetMetaTypeFromSqlDbType(sd, false).ClassType;
            }
            else
            {
                System.Data.OleDb.OleDbType xxx = (System.Data.OleDb.OleDbType)Enum.Parse(typeof(System.Data.OleDb.OleDbType), dbtypestring, true);
                t = new DB.MSAccess("").PasteType(dbtypestring);
            }
             
         
            return t;
        }
        /// <summary>
        /// 根据数据库类型取得SQLServer类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public  static SqlDbType GetSQLDBTypeByString(string dbtypestring)
        {
            SqlDbType sd = SqlDbType.Variant;
            if (Enum.TryParse<SqlDbType>(dbtypestring,true , out sd))
            {
                sd = (SqlDbType)Enum.Parse(typeof(SqlDbType), dbtypestring, true);
            }
 
            return sd;
        }
        /// <summary>
        /// 根据字符串形式的数据库类型转换为数据库类型的枚举形式
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public DbType  PasteDBType(string dbtypestring)
        {
            DbType t;
            SqlDbType sd= SqlDbType.Variant ;
            if (Enum.TryParse<SqlDbType>(dbtypestring,true , out sd))
            {

                sd = GetSQLDBTypeByString(dbtypestring);
                t = MetaType.GetMetaTypeFromSqlDbType(sd, false).DbType;
            }
            else
            {
                System.Data.OleDb.OleDbType xxx = (System.Data.OleDb.OleDbType)Enum.Parse(typeof(System.Data.OleDb.OleDbType), dbtypestring, true);
                t = new DB.MSAccess("").PasteDBType(dbtypestring);
               
            }
      
            return t;
        }
        /// <summary>
        /// 系统类型转换为数据库类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public DbType PasteType(Type t)
        {
            return MetaType.GetMetaTypeFromType(t).DbType;
        }
        /// <summary>
        ///  参数前导符号例如:mysql 是 ? mssql 是 @
        /// </summary>
        /// <returns></returns>

        public string GetParamIdentifierChar()
        {
            return "@";
        }


        #region IDatabase 成员

        /// <summary>
        /// 结束符
        /// </summary>
        /// <returns></returns>
        public string GetIdentifierEndChar()
        {
            return "]";

        }
        /// <summary>
        /// 起始符
        /// </summary>
        /// <returns></returns>
        public string GetIdentifierStartChar()
        {
            return "[";

        }

        #endregion
 
    }
}
