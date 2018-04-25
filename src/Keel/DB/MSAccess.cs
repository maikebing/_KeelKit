using System;
using System.Collections.Generic;
using System.Text;
using Keel.ORM;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
namespace Keel.DB
{
    /// <summary>
    /// MSAccess数据库
    /// </summary>
    public sealed class MSAccess : IDatabase
    {
        /// <summary>
        /// 根据连接字符串实例化一个Access数据库
        /// </summary>
        /// <param name="connectstring"></param>
        public MSAccess(string connectstring)
        {
            ConnectString = connectstring;
        }
        /// <summary>
        /// 获得数据库提供器
        /// </summary>
        /// <returns></returns>
        public DbProviderFactory GetProviderFactory()
        {
            return System.Data.OleDb.OleDbFactory.Instance;
        }
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string ConnectString { get; set; }
        /// <summary>
        /// 数据库类型转换为系统类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public Type PasteType(string dbtypestring)
        {
            Type t = null;
            OleDbType sd = GetOleDbTypeByString(dbtypestring);
            t = NativeDBType.FromDataType(sd).dataType;
            return t;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public static OleDbType GetOleDbTypeByString(string dbtypestring)
        {
            OleDbType sd = (OleDbType)Enum.Parse(typeof(OleDbType), dbtypestring, true);
            return sd;
        }
        public static DbType PasteOleDbType(string dbtypestring)
        {
            DbType t;
            OleDbType sd = GetOleDbTypeByString(dbtypestring);
            t = NativeDBType.FromDataType(sd).enumDbType;
            return t;
        }
        /// <summary>
        /// 将字符串形式的数据库类型转换为枚举类型的数据库类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public DbType PasteDBType(string dbtypestring)
        {
            DbType t;
            OleDbType sd = GetOleDbTypeByString(dbtypestring);
            t = NativeDBType.FromDataType(sd).enumDbType;
            return t;
        }
        /// <summary>
        /// 系统类型转换为数据库类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public DbType PasteType(Type t)
        {
            return NativeDBType.FromSystemType(t).enumDbType;
            // return MetaType.GetMetaTypeFromType(t).DbType;
        }

        #region IDatabase 成员

        /// <summary>
        /// 结束字符
        /// </summary>
        /// <returns></returns>
        public string GetIdentifierEndChar()
        {
            return "]";
        }
        /// <summary>
        /// 起始字符
        /// </summary>
        /// <returns></returns>
        public string GetIdentifierStartChar()
        {
            return "[";
        }

        #endregion

        #region IDatabase 成员

        /// <summary>
        ///  参数前导符号例如:mysql 是 ? mssql 是 @
        /// </summary>
        /// <returns></returns>
        public string GetParamIdentifierChar()
        {
            return "@";
        }

        #endregion
    }
}
