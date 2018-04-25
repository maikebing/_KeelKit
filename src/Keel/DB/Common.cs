using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Xml;
using System.Collections.Specialized;
using Keel.Exceptions;
using System.Reflection;
using Keel.Internal;

namespace Keel.DB
{
    /// <summary>
    /// 通用数据库，此数据库实为由配置文件决定的数据库
    /// </summary>
    public sealed class Common : IDatabase
    {
        /// <summary>
        /// 用默认配置实例化一个数据库
        /// </summary>
        public Common()
        {
            if (NowDataBase == null)
            {
                try
                {
                    IKeelHack ik = KeelHackHelper.GetKeelHack();
                    try
                    {
                        NowDataBase = GetIDatabaseByNamespace(ik.DBProviderName, ik.DBConnectionString);
                    }
                    catch (Exception)
                    {
                        NowDataBase = null;
                    }
                    if (NowDataBase != null && NowDataBase.ConnectString == "NULL")
                    {
                        NowDataBase.ConnectString = Encoding.Default.GetString(Convert.FromBase64String(KeelHackHelper.ReadKeelHack("DBINFO")));
                    }
                    if (NowDataBase == null)
                    {
                        NowDataBase = KeelHackHelper.ReadConnectionString();
                    }
                }
                catch (Exception)
                {
                    NowDataBase = null;
                }
            }
            if (NowDataBase == null)
            {
                throw new DataBaseConnectionStringIsException();
            }
        }

        /// <summary>
        /// 当前程序集范围内使用的数据库
        /// </summary>
        public static IDatabase NowDataBase { get; set; }
        /// <summary>
        /// 根据命名空间和链接字符串取得数据库
        /// </summary>
        /// <param name="strnamespace"></param>
        /// <param name="connectstring"></param>
        /// <returns></returns>
        public static IDatabase GetIDatabaseByNamespace(string strnamespace, string connectstring)
        {
            IDatabase db = null;
            switch (strnamespace)
            {
                case "System.Data.SqlClient":
                    db = new SQLServer(connectstring);
                    break;
                //case "System.Data.OracleClient":
                //    dp = System.Data.OracleClient.OracleClientFactory.Instance;
                //    break;
                case "System.Data.OleDb":
                    db = new MSAccess(connectstring);
                    break;
                //case "System.Data.Odbc":
                //    dp = System.Data.Odbc.OdbcFactory.Instance;
                //break;
                default:

                    db = GetIDB(strnamespace, connectstring);
                    break;

            }
            return db;

        }
        static Dictionary<string, Remote> dicRemote = new Dictionary<string, Remote>();
        static IDatabase GetIDB(string dbname, string connectstring)
        {

            Remote rem = null;
            if (!dicRemote.TryGetValue(dbname + connectstring, out rem))
            {
                string[] f = System.IO.Directory.GetFiles(new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName, "Keel.DB.*.dll", System.IO.SearchOption.TopDirectoryOnly);
                foreach (var item in f)
                {
                    System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFile(item);
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                    Type t = asm.GetType("Keel.DB.Connect");
                    object o = Activator.CreateInstance(t);
                    if ((bool)t.InvokeMember("IsMe", BindingFlags.InvokeMethod, null, o, new object[] { dbname }))
                    {
                        Type dbtype = (Type)t.InvokeMember("GetDBType", BindingFlags.InvokeMethod, null, o, new object[] { });
                        rem = new Remote(connectstring, dbtype);
                        dicRemote.Add(dbname + connectstring, rem);
                        break;
                    }
                }
            }
            return rem;
        }
        static Dictionary<string, System.Reflection.Assembly> dicAsms = new Dictionary<string, Assembly>();
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {

            if (!dicAsms.ContainsKey(args.Name))
            {
                string[] f = System.IO.Directory.GetFiles(
                                   new System.IO.FileInfo(args.RequestingAssembly.Location).DirectoryName, "*.dll",
                                   System.IO.SearchOption.TopDirectoryOnly);
                foreach (var item in f)
                {
                    try
                    {
                        Assembly asm = System.Reflection.Assembly.LoadFile(item);
                        if (!dicAsms.ContainsKey(asm.FullName))
                        {
                            dicAsms.Add(asm.FullName, asm);
                        }
                    }
                    catch (Exception)
                    {


                    }
                }
            }
            Assembly asmx;
            if (!dicAsms.TryGetValue(args.Name, out asmx))
            {
                throw new System.Reflection.TargetInvocationException(new Exception(args.Name + " can't found"));
            }
            return asmx;


        }

        static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return System.Reflection.Assembly.GetAssembly(typeof(string));
        }

        static Module asm_ModuleResolve(object sender, ResolveEventArgs e)
        {
            return e.RequestingAssembly.GetModule("");
        }

        #region IDatabase 成员
        /// <summary>
        /// 获得当前数据库的提供程序
        /// </summary>
        /// <returns></returns>
        public DbProviderFactory GetProviderFactory()
        {
            if (NowDataBase == null) throw new DataBaseNotConfigException();
            return NowDataBase.GetProviderFactory();
        }
        /// <summary>
        /// 获得当前数据库的连接字符串
        /// </summary>
        public string ConnectString
        {
            get
            {
                if (NowDataBase == null) throw new DataBaseNotConfigException();
                return NowDataBase.ConnectString;
            }
            set
            {
                if (NowDataBase == null) throw new DataBaseNotConfigException();
                NowDataBase.ConnectString = value;
            }

        }

        /// <summary>
        /// 数据库类型转换为系统类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public Type PasteType(string dbtypestring)
        {
            if (NowDataBase == null) throw new DataBaseNotConfigException();
            return NowDataBase.PasteType(dbtypestring);
        }


        /// <summary>
        /// 将数据库类型转换为系统类型
        /// </summary>
        /// <param name="dbtypestring">数据库类型</param>
        /// <returns></returns>
        public Type DBTypeToType(string dbtypestring)
        {
            return MetaType.GetMetaTypeFromDbType(PasteDBType(dbtypestring)).ClassType;
        }

        /// <summary>
        /// 将字符串形式的据库类型转换为数据库类型
        /// </summary>
        /// <param name="dbtypestring">数据库类型字符串形式</param>
        /// <returns></returns>
        public DbType PasteDBType(string dbtypestring)
        {
            return NowDataBase.PasteDBType(dbtypestring);
        }
        /// <summary>
        /// 将一个系统类型粘贴为数据库类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public DbType PasteDBType(Type t)
        {
            return NowDataBase.PasteType(t);
        }
        #endregion
        /// <summary>
        /// 将数据库字符串形式的类型装欢为数据库类型
        /// </summary>
        /// <param name="dbtypestring"></param>
        /// <returns></returns>
        public static DbType GetDBTypeByString(string dbtypestring)
        {
            return (DbType)Enum.Parse(typeof(DbType), dbtypestring, true);
        }
        /// <summary>
        /// 将一个结构转换为字符串
        /// </summary>
        /// <param name="t"></param>
        /// <returns>返回一个字符串</returns>
        public static string StructToString(object t)
        {
            int rawsize = Marshal.SizeOf(t);//得到内存大小
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);//分配内存
            Marshal.StructureToPtr(t, buffer, true);//转换结构
            byte[] rawdatas = new byte[rawsize];
            Marshal.Copy(buffer, rawdatas, 0, rawsize);//拷贝内存
            Marshal.FreeHGlobal(buffer); //释放内存
            return Encoding.Default.GetString(rawdatas);
        }
        /// <summary>
        /// 将一个字符串装转换为结构
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="anytype">结构</param>
        /// <returns>返回一个结构</returns>
        public static object StringToStruct(string s, Type anytype)
        {
            object t = new object();
            byte[] rawdatas = Encoding.Default.GetBytes(s);
            int rawsize = Marshal.SizeOf(anytype);
            if (rawsize > rawdatas.Length)
                t = Activator.CreateInstance(anytype);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawdatas, 0, buffer, rawsize);
            object retobj = Marshal.PtrToStructure(buffer, anytype);
            Marshal.FreeHGlobal(buffer);
            t = retobj;
            return t;
        }

        #region IDatabase 成员

        /// <summary>
        /// 使用当前数据库粘贴系统类型到数据库类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public DbType PasteType(Type t)
        {
            return NowDataBase.PasteType(t);
        }

        #endregion

        #region IDatabase 成员

        /// <summary>
        /// 取得标识结束符
        /// </summary>
        /// <returns></returns>
        public string GetIdentifierEndChar()
        {
            return NowDataBase.GetIdentifierEndChar();
        }
        /// <summary>
        /// 取得标识开始符号 
        /// </summary>
        /// <returns></returns>
        public string GetIdentifierStartChar()
        {
            return NowDataBase.GetIdentifierStartChar();
        }
        /// <summary>
        /// 返回使用关键词却表标识符标识了得名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetWithIdentifier(string name)
        {
            return NowDataBase.GetIdentifierStartChar() + name + NowDataBase.GetIdentifierEndChar();
        }

        #endregion

        #region IDatabase 成员

        /// <summary>
        ///  参数前导符号例如:mysql 是 ? mssql 是 @
        /// </summary>
        /// <returns></returns>
        public string GetParamIdentifierChar()
        {
            return NowDataBase.GetParamIdentifierChar();
        }

        #endregion



    }
}
