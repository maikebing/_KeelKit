using System;
using System.Collections.Generic;
using System.Text;
using Keel.DB;
using System.Data.Common;
using System.Collections.Specialized;
using System.Collections;

namespace Keel
{
    public class Query
    {
        string Filter = null;
        public Query(string filter)
        {
            Filter = filter;
        }
        Hashtable dbparams = new Hashtable();
        public void  AddParam(string paramname , object paramvalue)
        {
            dbparams.Add(paramname, paramvalue);
        }
        public Query(string filter,  Hashtable qparam)
        {
            Filter = filter;
            dbparams = qparam;
         
        }

        internal string GetFilter()
        {
            return Filter;
        }
        
    }

    public class QP
    {
        /// <summary>
        /// 小于<![CDATA[<]]>
        /// </summary>
        public const string 小于 = " < ";//小于
        /// <summary>
        /// 小于等于<![CDATA[<=]]>
        /// </summary>
        public const string 小于等于 = " <= ";//小于等于
        /// <summary>
        /// 等于=
        /// </summary>
        public const string 等于 = " = ";//（等于） 3 
        /// <summary>
        /// 大于或等于 \>=
        /// </summary>
        public const string 大于等于 = " >= ";//（大于或等于） 4 
        /// <summary>
        /// 大于>
        /// </summary>
        public const string 大于 = " > ";//（大于）
        /// <summary>
        /// 而且And
        /// </summary>
        public const string 而且 = " And ";
        /// <summary>
        /// 或Or
        /// </summary>
        public const string 或 = " Or ";
        /// <summary>
        /// 类似 like
        /// </summary>
        public const string 类似 = "  Like";


        /// <summary>
        /// 小于<![CDATA[<]]>
        /// </summary>
        public const string LessThan = " < ";//小于
        /// <summary>
        /// 小于等于<![CDATA[<=]]>
        /// </summary>
        public const string SringlessThanOrEqual = " <= ";//小于等于
        /// <summary>
        /// 等于=
        /// </summary>
        public const string Stringequal = " = ";//（等于） 3 
        /// <summary>
        /// 大于或等于 \>=
        /// </summary>
        public const string StringgreaterThanOrEqual = " >= ";//（大于或等于） 4 
        /// <summary>
        /// 大于>
        /// </summary>
        public const string StringreaterThan = " > ";//（大于）
        /// <summary>
        /// 而且And
        /// </summary>
        public const string And = " And ";
        /// <summary>
        /// 或Or
        /// </summary>
        public const string Or = " Or ";
        /// <summary>
        /// 类似 like
        /// </summary>
        public const string Like = "  Like";
        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 操作符
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 对象值
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 笨表达式后面的运算符 一般是 or  and 等， 和下一个参数的关联性
        /// </summary>
        public string After { get; set; }
        /// <summary>
        /// 创建一个列等于某值的条件
        /// </summary>
        /// <param name="colname"></param>
        /// <param name="value"></param>
        public QP(string colname,   object value)
        {
            ColumnName = colname;
            Operator =   QP .Stringequal ;
            Value = value;
        
        }
        /// <summary>
        /// 创建一个某列使用操作符opert与value对比的条件
        /// </summary>
        /// <param name="colname"></param>
        /// <param name="opert"></param>
        /// <param name="value"></param>
        public QP(string colname, string opert, object value )
        {
            ColumnName = colname;
            Operator = opert;
            Value = value;
            After = "";
        }
        /// <summary>
        /// 创建一个某列使用操作符opert与value对比的条件,并且设置后续操作符
        /// </summary>
        /// <param name="colname"></param>
        /// <param name="opert"></param>
        /// <param name="value"></param>
        /// <param name="after"></param>
        public QP(string colname, string opert, object value, string after)
        {
            ColumnName = colname;
            Operator = opert;
            Value = value;
            After = after;

        }
    }
}
