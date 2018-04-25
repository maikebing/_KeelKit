
using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.Common;

using MySql.Data.MySqlClient;
namespace Keel.DB
{



    /// <summary>
    /// MySQL数据库访问器
    /// </summary>
    public class MYSQL
    {
        /// <summary>
        /// 实例化一个Mysql数据库访问器
        /// </summary>
        /// <param name="connectstring">链接字符串</param>
        public MYSQL(string connectstring)
        {
            ConnectString = connectstring;
        }
        /// <summary>
        ///  参数前导符号例如:mysql 是 ? mssql 是 @
        /// </summary>
        /// <returns></returns>
        public string GetParamIdentifierChar()
        {
            return "?";
        }
        #region IDatabase 成员
        /// <summary>
        /// 获取结束字符
        /// </summary>
        /// <returns></returns>
        public string GetIdentifierEndChar()
        {
            return "`";

        }
        /// <summary>
        /// 获取开始字符
        /// </summary>
        /// <returns></returns>
        public string GetIdentifierStartChar()
        {
            return "`";

        }
        /// <summary>
        /// 获取工厂接口
        /// </summary>
        /// <returns></returns>
        public DbProviderFactory GetProviderFactory()
        {
            return MySqlClientFactory.Instance;
        }
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string ConnectString { get; set; }
        /// <summary>
        /// 粘贴一个类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public Type PasteType(string dbtypestring)
        {
            Type t = typeof(object); ;
            MySqlDbType mySqlDbType = GetMySqlDbTypeByString(dbtypestring);
            DbType _dbType = MySQL2DBType(mySqlDbType);
            switch (_dbType)
            {
                case DbType.AnsiString:
                    t = typeof(string);
                    break;
                case DbType.AnsiStringFixedLength:
                    t = typeof(string);
                    break;
                case DbType.Binary:
                    t = typeof(byte[]);
                    break;
                case DbType.Boolean:
                    t = typeof(bool);
                    break;
                case DbType.Byte:
                    t = typeof(byte);
                    break;
                case DbType.Currency:
                    t = typeof(double);
                    break;
                case DbType.Date:
                    t = typeof(DateTime);
                    break;
                case DbType.DateTime:
                    t = typeof(DateTime);
                    break;
                case DbType.DateTime2:
                    t = typeof(DateTime);
                    break;
                case DbType.DateTimeOffset:
                    t = typeof(DateTimeOffset);
                    break;
                case DbType.Decimal:
                    t = typeof(decimal);
                    break;
                case DbType.Double:
                    t = typeof(double);
                    break;
                case DbType.Guid:
                    t = typeof(Guid);
                    break;
                case DbType.Int16:
                    t = typeof(Int16);
                    break;
                case DbType.Int32:
                    t = typeof(Int32);
                    break;
                case DbType.Int64:
                    t = typeof(Int64);
                    break;
                case DbType.Object:
                    t = typeof(object);
                    break;
                case DbType.SByte:
                    t = typeof(sbyte);
                    break;
                case DbType.Single:
                    t = typeof(Single);
                    break;
                case DbType.String:
                    t = typeof(string);
                    break;
                case DbType.StringFixedLength:
                    t = typeof(string);
                    break;
                case DbType.Time:
                    t = typeof(DateTime);
                    break;
                case DbType.UInt16:
                    t = typeof(UInt16);
                    break;
                case DbType.UInt32:
                    t = typeof(UInt32);
                    break;
                case DbType.UInt64:
                    t = typeof(UInt64);
                    break;
                case DbType.VarNumeric:
                    t = typeof(decimal);
                    break;
                case DbType.Xml:
                    t = typeof(string);
                    break;
                default:
                    t = typeof(object);
                    break;
            }
            return t;
        }
        /// <summary>
        /// 粘贴数据库类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public System.Data.DbType PasteDBType(string dbtypestring)
        {
            MySqlDbType mySqlDbType = GetMySqlDbTypeByString(dbtypestring);
            DbType _dbType = MySQL2DBType(mySqlDbType);
            return _dbType;
        }
        /// <summary>
        /// mysql 类型转换为 常规数据库类型
        /// </summary>
        /// <param name="mySqlDbType"></param>
        /// <returns></returns>
        private static DbType MySQL2DBType(MySqlDbType mySqlDbType)
        {

            DbType _dbType = DbType.Object;
            switch (mySqlDbType)
            {
                case MySqlDbType.Decimal:
                    _dbType = DbType.Decimal;
                    break;

                case MySqlDbType.Byte:
                    _dbType = DbType.SByte;
                    break;

                case MySqlDbType.Int16:
                    _dbType = DbType.Int16;
                    break;

                case MySqlDbType.Int32:
                case MySqlDbType.Int24:
                    _dbType = DbType.Int32;
                    break;

                case MySqlDbType.Float:
                    _dbType = DbType.Single;
                    break;

                case MySqlDbType.Double:
                    _dbType = DbType.Double;
                    break;

                case (MySqlDbType.Float | MySqlDbType.Int16):
                case MySqlDbType.VarString:
                case ((MySqlDbType)0x1f8):
                case ((MySqlDbType)0x1f9):
                case ((MySqlDbType)0x1fa):
                case ((MySqlDbType)0x1fb):
                    break;

                case MySqlDbType.Timestamp:
                case MySqlDbType.Datetime:
                    _dbType = DbType.DateTime;
                    break;

                case MySqlDbType.Int64:
                    _dbType = DbType.Int64;
                    break;

                case MySqlDbType.Date:
                case MySqlDbType.Year:
                case MySqlDbType.Newdate:
                    _dbType = DbType.Date;
                    break;

                case MySqlDbType.Time:
                    _dbType = DbType.Time;
                    break;
                case MySqlDbType.Bit:
                    _dbType = DbType.UInt64;
                    break;

                case MySqlDbType.Enum:
                case MySqlDbType.Set:
                case MySqlDbType.VarChar:
                    _dbType = DbType.String;
                    break;

                case MySqlDbType.TinyBlob:
                case MySqlDbType.MediumBlob:
                case MySqlDbType.LongBlob:
                case MySqlDbType.Blob:
                    _dbType = DbType.Object;
                    break;

                case MySqlDbType.String:
                    _dbType = DbType.StringFixedLength;
                    break;

                case MySqlDbType.UByte:
                    _dbType = DbType.Byte;
                    break;

                case MySqlDbType.UInt16:
                    _dbType = DbType.UInt16;
                    break;

                case MySqlDbType.UInt32:
                case MySqlDbType.UInt24:
                    _dbType = DbType.UInt32;
                    break;

                case MySqlDbType.UInt64:
                    _dbType = DbType.UInt64;
                    break;

                default:
                    break;
            }
            return _dbType;
        }

        /// <summary>
        /// 使用字符串类型的数据库类型名称来获得 mysql的数据库类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public static MySqlDbType GetMySqlDbTypeByString(string dbtypestring)
        {
            string dbtypestringx="";
            switch (dbtypestring)
            {
                case "smallint":
                case "tinyint":
                    dbtypestringx="Int16";
                    break ;
                case "int":
                    dbtypestringx="Int32";
                    break ;
                case "mediumint":
                    dbtypestringx = "Int32";
                    break;
                case "bigint":
                      dbtypestringx = "Int32";
                    break ;
                case "char":
                    dbtypestringx="VarChar";
                    break;
                default:
                    dbtypestringx=dbtypestring;
                    break;
            }
            
            MySqlDbType sd = (MySqlDbType)Enum.Parse(typeof(MySqlDbType), dbtypestringx, true);
            return sd;
        }
        /// <summary>
        /// 系统类型转化为数据库类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public DbType PasteType(Type t)
        {
            DbType __DbType = DbType.Object;
            if (t.Equals(typeof(Guid)))
            {
                __DbType = DbType.String;
            }
            else if (t.Equals(typeof(TimeSpan)))
            {
                __DbType = DbType.Time;
            }
            else if (t.Equals(typeof(bool)))
            {
                __DbType = DbType.Byte;
            }
            else
            {
                switch (Type.GetTypeCode(t))
                {
                    case TypeCode.SByte:
                        __DbType = DbType.SByte;
                        break;

                    case TypeCode.Byte:
                        __DbType = DbType.Byte;
                        break;

                    case TypeCode.Int16:
                        __DbType = DbType.Int16;
                        break;

                    case TypeCode.UInt16:
                        __DbType = DbType.UInt16;
                        break;

                    case TypeCode.Int32:
                        __DbType = DbType.Int32;
                        break;

                    case TypeCode.UInt32:
                        __DbType = DbType.UInt32;
                        break;

                    case TypeCode.Int64:
                        __DbType = DbType.Int64;
                        break;

                    case TypeCode.UInt64:
                        __DbType = DbType.UInt64;
                        break;

                    case TypeCode.Single:
                        __DbType = DbType.Single;
                        break;

                    case TypeCode.Double:
                        __DbType = DbType.Double;
                        break;

                    case TypeCode.Decimal:
                        __DbType = DbType.Decimal;
                        break;

                    case TypeCode.DateTime:
                        __DbType = DbType.DateTime;
                        break;

                    case TypeCode.String:
                        __DbType = DbType.String;
                        break;
                }

            }
            return __DbType;
        }






        private MySqlDbType DBType2MySQLDbType(DbType db_type)
        {
            MySqlDbType mySqlDbType = MySqlDbType.Blob;
            switch (db_type)
            {
                case DbType.AnsiString:
                case DbType.Guid:
                case DbType.String:
                    mySqlDbType = MySqlDbType.VarChar;
                    break;

                case DbType.Byte:
                case DbType.Boolean:
                    mySqlDbType = MySqlDbType.UByte;
                    break;

                case DbType.Currency:
                case DbType.Decimal:
                    mySqlDbType = MySqlDbType.Decimal;
                    break;

                case DbType.Date:
                    mySqlDbType = MySqlDbType.Date;
                    break;

                case DbType.DateTime:
                    mySqlDbType = MySqlDbType.DateTime;
                    break;

                case DbType.Double:
                    mySqlDbType = MySqlDbType.Double;
                    break;

                case DbType.Int16:
                    mySqlDbType = MySqlDbType.Int16;
                    break;

                case DbType.Int32:
                    mySqlDbType = MySqlDbType.Int32;
                    break;

                case DbType.Int64:
                    mySqlDbType = MySqlDbType.Int64;
                    break;

                case DbType.SByte:
                    mySqlDbType = MySqlDbType.Byte;
                    break;

                case DbType.Single:
                    mySqlDbType = MySqlDbType.Float;
                    break;

                case DbType.Time:
                    mySqlDbType = MySqlDbType.Time;
                    break;

                case DbType.UInt16:
                    mySqlDbType = MySqlDbType.UInt16;
                    break;

                case DbType.UInt32:
                    mySqlDbType = MySqlDbType.UInt32;
                    break;

                case DbType.UInt64:
                    mySqlDbType = MySqlDbType.UInt64;
                    break;

                case DbType.AnsiStringFixedLength:
                case DbType.StringFixedLength:
                    mySqlDbType = MySqlDbType.String;
                    break;
            }
            return mySqlDbType;

        }




        #endregion


    }
}

