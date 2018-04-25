using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
namespace Keel
{
    /// <summary>
    /// 数据库接口
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// 提供器工厂
        /// </summary>
        /// <returns></returns>
        DbProviderFactory GetProviderFactory();
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnectString { get; set; }
        /// <summary>
        /// 字符串形式的数据库类型转换为系统类型
        /// </summary>
        /// <param name="dbtypestring">数据库字符串形式的类型</param>
        /// <returns></returns>
        Type PasteType(string dbtypestring);
        /// <summary>
        /// 字符串形式的类型转换为数据库类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        DbType PasteDBType(string dbtypestring);
        /// <summary>
        /// 系统类型转换为数据库类型
        /// </summary>
        /// <param name="t">系统类型</param>
        /// <returns></returns>
        DbType PasteType(Type t);
        /// <summary>
        /// 获取结束字符
        /// </summary>
        /// <returns></returns>
        string GetIdentifierEndChar();
        /// <summary>
        /// 获取开始字符
        /// </summary>
        /// <returns></returns>
        string GetIdentifierStartChar();
        /// <summary>
        /// 参数前导符号例如:mysql 是 ? mssql 是 @
        /// </summary>
        /// <returns></returns>
        string GetParamIdentifierChar();
 
       

    }
}
