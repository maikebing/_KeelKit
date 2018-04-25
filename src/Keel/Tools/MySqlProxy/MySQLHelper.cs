using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Data;



namespace Keel.Tools.MySqlProxy
{
    /// <summary>
    /// MySQL代理器异常
    /// </summary>
    public class MySqlProxyException : Exception
    {
        /// <summary>
        /// 初始化一个代理错误
        /// </summary>
        /// <param name="errcode">错误代码</param>
        /// <param name="message">错误消息</param>
        public MySqlProxyException(int errcode, string message)
            : base(message)
        {
            ErrorCode = errcode;
        }
        public int ErrorCode { get; set; }
    }

    public enum MySqlDbType
    {
        INT,
        VARCHAR,
        TEXT,
        DATE,
        NUMERIC,
        TINYINT,
        SMALLINT,
        MEDIUMINT,
        BIGINT,
        DECIMAL,
        FLOAT,
        DOUBLE,
        REAL,
        BIT,
        BOOL,
        SERIAL,
        DATETIME,
        TIMESTAMP,
        TIME,
        YEAR,
        STRING,
        CHAR,
        TINYTEXT,
        MEDIUMTEXT,
        LONGTEXT,
        BINARY,
        VARBINARY,
        TINYBLOB,
        MEDIUMBLOB,
        BLOB,
        LONGBLOB,
        ENUM,
        SET,
        SPATIAL,
        GEOMETRY,
        POINT,
        LINESTRING,
        POLYGON,
        MULTIPOINT,
        MULTILINESTRING,
        MULTIPOLYGON,
        GEOMETRYCOLLECTION

    }
    public enum MySqlDbType1
    {
        Binary = 600,
        Bit = 0x10,
        Blob = 0xfc,
        Byte = 1,
        Date = 10,
        Datetime = 12,
        Decimal = 0,
        Double = 5,
        Enum = 0xf7,
        Float = 4,
        Geometry = 0xff,
        Int16 = 2,
        Int24 = 9,
        Int32 = 3,
        Int64 = 8,
        LongBlob = 0xfb,
        LongText = 0x2ef,
        MediumBlob = 250,
        MediumText = 750,
        Newdate = 14,
        NewDecimal = 0xf6,
        Set = 0xf8,
        String = 0xfe,
        Text = 0x2f0,
        Time = 11,
        Timestamp = 7,
        TinyBlob = 0xf9,
        TinyText = 0x2ed,
        UByte = 0x1f5,
        UInt16 = 0x1f6,
        UInt24 = 0x1fd,
        UInt32 = 0x1f7,
        UInt64 = 0x1fc,
        VarBinary = 0x259,
        VarChar = 0xfd,
        VarString = 15,
        Year = 13,
        MediumInt = 999
    }
    public class MySQLHelper
    {
        static DateTime dt1970 = new DateTime(1970, 1, 1);
        /// <summary>
        /// 返回当前系统时间的时间戳，一般用于php,此时间戳为自1970年1月1日开始至今的秒数总和 。
        /// </summary>
        /// <returns></returns>
        public static double TimeStamp()
        {
            return DateTime.Now.Subtract(dt1970).TotalSeconds;
        }

        /// <summary>
        /// 执行一个sql语句，并返回一个值 ，如果返回了多个值，则会使用第一行第一列数据。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            object obj = null;
            string result = Execute(sql);
            XmlParser xp = new XmlParser(result);
            DataTable dt = xp.GetDataTable();
            if (dt.Columns.Count > 0 && dt.Rows.Count > 0)
            {
                obj = dt.Rows[0][0];
            }
            return obj;
        }
        /// <summary>
        /// 执行一个sql语句，并返回影响行数。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            string result = Execute(sql);
            XmlParser xp = new XmlParser(result);
            int i = 0;
            int.TryParse(xp.readInnerText("a_r"), out i);
            return i;
        }
        /// <summary>
        /// 执行SQL语句并返回一个ID，一般用于插入数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteAndGetID(string sql)
        {
            string result = Execute(sql);
            XmlParser xp = new XmlParser(result);
            int i = 0;
            int.TryParse(xp.readInnerText("i_i"), out i);
            return i;
        }
        /// <summary>
        /// 执行sql语句，并返回一个DataTable 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql)
        {
            string context = Execute(sql);
            XmlParser xp = new XmlParser(context);
            System.Data.DataTable dt = xp.GetDataTable();
            return dt;
        }
        /// <summary>
        /// 初始化一个Mysql代理的基本信息
        /// </summary>
        /// <param name="sSQLyogTunnel">安装目录下的SQLyogTunnel.php的url，必须将此文件传送到您的服务器上，使用前确保你的服务器能访问数据库。</param>
        /// <param name="DBHost">数据库IP地址</param>
        /// <param name="DBUser">用户名</param>
        /// <param name="DBPassword">密码</param>
        /// <param name="DBName">数据名称</param>
        public static void InitMySQLProxy(string sSQLyogTunnel, string DBHost, string DBUser, string DBPassword, string DBName)
        {
            PHPInput.init(DBHost, DBUser, DBPassword, DBName);
            SQLyogTunnel = sSQLyogTunnel;

        }
        /// <summary>
        /// 初始化一个Mysql代理的基本信息
        /// </summary>
        /// <param name="sSQLyogTunnel">安装目录下的SQLyogTunnel.php的url，必须将此文件传送到您的服务器上，使用前确保你的服务器能访问数据库。</param>
        /// <param name="DBHost">数据库IP地址</param>
        /// <param name="DBUser">用户名</param>
        /// <param name="DBPassword">密码</param>
        /// <param name="DBName">数据名称</param>
        /// <param name="port">端口</param>
        /// <param name="charset">字符集</param>
        public static void InitMySQLProxy(string sSQLyogTunnel, string DBHost, string DBUser, string DBPassword, string DBName, int port, string charset)
        {
            PHPInput.init(DBHost, DBUser, DBPassword, DBName);
            PHPInput.charset = charset;
            PHPInput.port = port.ToString();
            PHPInput.isinit = true;
            SQLyogTunnel = sSQLyogTunnel;

        }
        public static string SQLyogTunnel { get; set; }
        /// <summary>
        /// 执行MySQL语句
        /// </summary>
        /// <param name="sql">要执行的语句</param>
        /// <returns>返回一个xml文件</returns>
        private  static string Execute(string sql)
        {
            if (!PHPInput.isinit)
            {
                throw new MySqlProxyException(-1, "未初始化MySQLProxy代理");
            }
            string phpinput = PHPInput.getxml(sql);
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] buffer = wc.UploadData(SQLyogTunnel, System.Text.Encoding.UTF8.GetBytes(phpinput));
            string result = System.Text.Encoding.UTF8.GetString(buffer);
            Exception ex = new XmlParser(result).GetException();
            if (ex != null)
            {
                throw ex;
            }
            return result;
        }


        /// <summary>
        /// 根据mysql类型获取一个系统类型
        /// </summary>
        /// <param name="mysql_dbtype"></param>
        /// <returns></returns>
        public static Type GetTypeByByMySqlType(MySqlDbType mysql_dbtype)
        {
            DbType dt;
            Type type;
            GetTypeDBType(mysql_dbtype, out  dt, out type);
            return type;
        }
        /// <summary>
        /// 根据MySql类型获得一个系统的DBType
        /// </summary>
        /// <param name="mysql_dbtype"></param>
        /// <param name="type"></param>
        public static DbType GetDBTypeByMySqlType(MySqlDbType mysql_dbtype  )
        {
            Type dt;
            DbType type;
            GetTypeDBType(mysql_dbtype, out  type, out dt);
            return type;
        }
        /// <summary>
        /// 根据Mysql类型获得系统类型和数据库类型
        /// </summary>
        /// <param name="mysql_dbtype"></param>
        /// <param name="thisdbType"></param>
        /// <param name="systype"></param>
        public static void GetTypeDBType(MySqlDbType mysql_dbtype, out DbType thisdbType, out Type systype)
        {
            thisdbType = DbType.Object;
            systype = typeof(object);
            switch (mysql_dbtype)
            {
                case MySqlDbType.NUMERIC:
                case MySqlDbType.DECIMAL:
                    thisdbType = DbType.Decimal;
                    systype = typeof(decimal);
                    return;

                //case MySqlDbType. :
                //    thisdbType = DbType.SByte;
                //    systype = typeof(sbyte );
                //    return;

                case MySqlDbType.SMALLINT:
                    thisdbType = DbType.Int16;
                    systype = typeof(Int16);
                    return;

                case MySqlDbType.INT:
                case MySqlDbType.TINYINT:
                    thisdbType = DbType.Int32;
                    systype = typeof(Int32);
                    return;

                case MySqlDbType.FLOAT:
                    thisdbType = DbType.Single;
                    systype = typeof(float);
                    return;

                case MySqlDbType.DOUBLE:
                    thisdbType = DbType.Double;
                    systype = typeof(double);
                    return;

                case ((MySqlDbType)0x1f8):
                case ((MySqlDbType)0x1f9):
                case ((MySqlDbType)0x1fa):
                case ((MySqlDbType)0x1fb):
                    break;

                case MySqlDbType.TIMESTAMP:
                case MySqlDbType.DATETIME:
                    thisdbType = DbType.DateTime;
                    systype = typeof(DateTime);
                    return;

                case MySqlDbType.BIGINT:
                    thisdbType = DbType.Int64;
                    systype = typeof(Int64);
                    return;

                case MySqlDbType.DATE:
                case MySqlDbType.YEAR:
                    // case MySqlDbType.dat:
                    thisdbType = DbType.Date;
                    systype = typeof(DateTime);
                    return;

                case MySqlDbType.TIME:
                    thisdbType = DbType.Time;
                    systype = typeof(DateTime);
                    return;

                case MySqlDbType.BIT:
                    thisdbType = DbType.UInt64;
                    systype = typeof(UInt64);
                    return;

                case MySqlDbType.ENUM:
                case MySqlDbType.SET:
                case MySqlDbType.VARCHAR:
                    thisdbType = DbType.String;
                    systype = typeof(string);
                    return;

                case MySqlDbType.TINYBLOB:
                case MySqlDbType.MEDIUMBLOB:
                case MySqlDbType.LONGBLOB:
                case MySqlDbType.BLOB:

                    thisdbType = DbType.Object;
                    systype = typeof(object);
                    return;
                case MySqlDbType.BINARY:
                    thisdbType = DbType.Binary;
                    systype = typeof(byte[]);
                    return;
                case MySqlDbType.MULTILINESTRING:
                case MySqlDbType.STRING:
                case MySqlDbType.TEXT:
                    thisdbType = DbType.StringFixedLength;
                    systype = typeof(string);
                    break;

                case MySqlDbType.CHAR:
                    thisdbType = DbType.String;
                    systype = typeof(string);
                    return;



                case MySqlDbType.MEDIUMINT:

                    thisdbType = DbType.UInt32;
                    systype = typeof(UInt32);
                    return;



                default:

                    return;
            }
        }


    }
}
