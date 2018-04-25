using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Keel
{
    /// <summary>
    /// 存储过程访问器
    /// </summary>
    /// <typeparam name="T">返回类型</typeparam>
    /// <typeparam name="K">Out时类型</typeparam>
   public sealed  class SPHelper<T,K>

    {
       DBOperator<Keel.IDatabase> idb=null ;
        /// <summary>
        /// 使用通用数据库，即 Keel.DB.Common.NowDataBase,在程序启动时需要为此赋值
        /// </summary>
       public SPHelper()
       {
           idb = new DBOperator<IDatabase>(new Keel.DB.Common());
       }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spname">存储过程名称</param>
        /// <param name="sp_exctype">支持 ExecuteScalar 、 Fill、 Model 、ExecuteNonQuery 、List 五种方法</param>
        /// <returns>根据执行方法不同返回值不同
        /// ExecuteScalar 支持任何基本类型
        /// ExecuteNonQuery仅仅支持 int  
        /// Fill 支持 DataTable和 DataSet</returns>
        /// <param name="drlt"></param>
        public T   ExcStoredProcedure(string spname, SPExcMethod sp_exctype, out List<K> drlt)
        {
            return ExcStoredProcedure(spname, sp_exctype, out drlt, null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spname">存储过程名称</param>
        /// <param name="sp_exctype">支持 ExecuteScalar 、 Fill、 Model 、ExecuteNonQuery 、List 五种方法</param>
        /// <returns>根据执行方法不同返回值不同
        /// ExecuteScalar 支持任何基本类型
        /// ExecuteNonQuery仅仅支持 int  
        /// Fill 支持 DataTable和 DataSet</returns>
        public T  ExcStoredProcedure(string spname, SPExcMethod sp_exctype)
        {
            List<K> drlt;
            return ExcStoredProcedure(spname, sp_exctype, out drlt, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spname">存储过程名称</param>
        /// <param name="sp_exctype">支持 ExecuteScalar 、 Fill、 Model 、ExecuteNonQuery 、List 五种方法</param>
        /// <returns>根据执行方法不同返回值不同
        /// ExecuteScalar 支持任何基本类型
        /// ExecuteNonQuery仅仅支持 int  
        /// Fill 支持 DataTable和 DataSet</returns>
        /// <param name="ary"></param>
        /// <param name="names"></param>
        public T   ExcStoredProcedure(string spname, SPExcMethod sp_exctype, string[] names, Array ary)
        {
            List<K> drlt;
            return ExcStoredProcedure(spname, sp_exctype, out drlt, names, ary);
        }


        /// <summary>
        /// 存储过程调用
        /// </summary>
        /// <param name="spname">存储过程名称</param>
        /// <param name="ary"></param>
        /// <param name="drlt"></param>
        /// <param name="names">名称</param>
        /// <param name="sp_exctype">支持 ExecuteScalar 、 Fill、 Model 、ExecuteNonQuery 、List 五种方法</param>
        /// <returns>根据执行方法不同返回值不同
        /// ExecuteScalar 支持任何基本类型
        /// ExecuteNonQuery仅仅支持 int  
        /// Fill中支持 DataTable和 DataSet
        /// List 方法支持int类型,返回值在 ,out List【T】 drlt中返回 
        /// </returns>
        public T  ExcStoredProcedure(string spname, SPExcMethod sp_exctype, out List<K> drlt, string[] names, Array ary)
        {
            T t = default(T);
            drlt = null;
            DbCommand dbc = idb.CreateDbCommand();
            dbc.CommandType = CommandType.StoredProcedure;
            dbc.CommandText = spname;
            if (names != null && ary != null)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    DbParameter dbp = dbc.CreateParameter();
                    dbp.ParameterName = names[i];
                    if (i <= ary.Length)
                    {
                        dbp.Value = ary.GetValue(i);
                        dbc.Parameters.Add(dbp);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            dbc.Connection.Open();
            switch (sp_exctype)
            {
                case SPExcMethod.ExecuteScalar:
                    object o = dbc.ExecuteScalar();
                    if (o != null && o != DBNull.Value)
                    {
                        t = (T)o;
                    }
                    break;
                case SPExcMethod.Fill:
                    DbDataAdapter da = idb.CreateDataAdapter();
                    da.SelectCommand = dbc;
                    if (typeof(T) == typeof(DataTable))
                    {
                        DataTable dt = new DataTable(spname);
                        da.Fill(dt);
                        t = (T)System.Convert.ChangeType(dt, typeof(T)); ;
                    }
                    else if (typeof(T) == typeof(DataSet))
                    {
                        DataSet dt = new DataSet(spname);
                        da.Fill(dt);
                        t = (T)System.Convert.ChangeType(dt, typeof(T)); ;
                    }
                    break;
                case SPExcMethod.Model:
                    DbDataReader dr = dbc.ExecuteReader();
                    while ((dr.Read()))
                    {

                        T t1 = Activator.CreateInstance<T>();
                        foreach (var item in typeof(T).GetProperties())
                        {
                            string colname = ((Keel.ORM.DataFieldAttribute)item.GetCustomAttributes(typeof(Keel.ORM.DataFieldAttribute), true)[0]).ColumnName;
                            if (dr[colname] != DBNull.Value)
                            {
                                item.SetValue(t1, dr[colname], null);
                            }
                        }
                        if (sp_exctype == SPExcMethod.Model)
                        {
                            t = t1;
                            break;
                        }
                    }
                    dr.Close();
                    t = (T)System.Convert.ChangeType(drlt.Count, typeof(T));
                    break;
                case SPExcMethod.List:
                    drlt = new List<K>();
                    DbDataReader dr1 = dbc.ExecuteReader();
                    while ((dr1.Read()))
                    {

                        K t1 = Activator.CreateInstance<K>();
                        foreach (var item in typeof(T).GetProperties())
                        {
                            string colname = ((Keel.ORM.DataFieldAttribute)item.GetCustomAttributes(typeof(Keel.ORM.DataFieldAttribute), true)[0]).ColumnName;
                            if (dr1[colname] != DBNull.Value)
                            {
                                item.SetValue(t1, dr1[colname], null);
                            }
                        }
                        
                        drlt.Add(t1);
                    }
                    dr1.Close();
                    t = (T)System.Convert.ChangeType(drlt.Count , typeof(T));
                    break;
                case SPExcMethod.ExecuteNonQuery:
                default:
                    if (typeof(T) == typeof(int))
                    {

                        int i = dbc.ExecuteNonQuery();
                        t = (T)System.Convert.ChangeType(i, typeof(T));
                    }
                    break;
            }
            dbc.Connection.Close();
            return t;
        }
    }
}
