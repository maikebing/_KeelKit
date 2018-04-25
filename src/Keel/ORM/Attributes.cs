using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Keel.ORM
{
    /// <summary>
    /// 主键字段属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldEditorAttribute:Attribute 
    {
        /// <summary>
        /// 主键字段
        /// </summary>
        /// <param name="columnname">字段名</param>
        public FieldEditorAttribute(string typestring  , string propertyname)
        {
            Editor = Type.GetType (typestring) ;
            PropertyName = propertyname;
        }
        /// <summary>
        /// 主键字段
        /// </summary>
        /// <param name="columnname">字段名</param>
        public FieldEditorAttribute(Type  ctl,string propertyname)
        {
            Editor = ctl;
            PropertyName = propertyname; 
        }
        /// <summary>
        /// 用于赋值的属性名称
        /// </summary>
        public string  PropertyName { get; set; }
        /// <summary>
        /// 编辑器
        /// </summary>
        public Type Editor { get; set; }

    }
    /// <summary>
    /// 主键字段属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyFieldAttribute : DataFieldAttribute
    {
        /// <summary>
        /// 主键字段
        /// </summary>
        /// <param name="columnname">字段名</param>
        public KeyFieldAttribute(string columnname )
            : base(columnname, null , null, false, true, true, null, -1, false)
        {

        }
        /// <summary>
        /// 主键字段
        /// </summary>
        /// <param name="columnname">字段名</param>
        /// <param name="dbtype">数据库类型</param>
        public KeyFieldAttribute(string columnname,string   dbtype)
            :base(columnname ,dbtype,  null ,false ,true ,true ,null , -1,false )
        {
         
        }
        /// <summary>
        /// 主键字段
        /// </summary>
        /// <param name="columnname">字段名</param>
        /// <param name="dbtype">数据库类型</param>
        /// <param name="isautoidentitiy">是否为自动标识</param>
        public KeyFieldAttribute(string columnname, string  dbtype, bool isautoidentitiy)
            : base(columnname,dbtype ,null ,false ,true,isautoidentitiy ,null ,-1,false )
        {

        }
 
    }
    /// <summary>
    /// 数据字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DataFieldAttribute : Attribute
    {
        internal  DataFieldAttribute(string columnname, string dbtype, object defaultvalue, bool cannull, bool iskey, bool isautoidentitiy, string description, int index, bool iscomputed)
        {
            ColumnName = columnname;
            IsKey = iskey;
            IsAutoIdentitiy = isautoidentitiy;
            Index = index;
            CanNull = cannull;
            DefaultValue = defaultvalue;
            Description = Description;
            DBType = dbtype;
            IsComputed = iscomputed;
        }

 
 

        /// <summary>
        /// 数据字段描述
        /// </summary>
        /// <param name="columnname">列名</param>
        /// <param name="defaultvalue">默认值</param>
        /// <param name="cannull">是否允许为空</param>
        /// <param name="description">描述</param>
        /// <param name="index">顺序</param>
        /// <param name="dbtype">数据库类型</param>
        /// <param name="lenght">长度</param>
        public DataFieldAttribute(string columnname, string dbtype, object defaultvalue, bool cannull, string description, int index, int lenght )
        {
            ColumnName = columnname;
            IsKey = false;
            IsAutoIdentitiy = false;
            Index = index;
            CanNull = cannull;
            DefaultValue = defaultvalue;
            Description = Description;
            Lenght = lenght;
            DBType = dbtype;
            IsComputed = false;
        }
        /// <summary>
        /// 数据字段描述
        /// </summary>
        /// <param name="columnname">列名</param>
        /// <param name="dbtype">数据类型</param>
        /// <param name="defaultvalue">默认值</param>
        /// <param name="cannull">是否允许空</param>
        /// <param name="description">描述</param>
        /// <param name="index">顺序</param>
        /// <param name="lenght">长度</param>
        /// <param name="iscomputed">是否自动计算</param>
        /// <param name="isautoidentitiy">是否是自动标识</param>
        public DataFieldAttribute(string columnname, string dbtype, object defaultvalue, bool cannull, string description, int index, int lenght, bool iscomputed, bool isautoidentitiy)
        {
            ColumnName = columnname;
            IsKey = false;
            IsAutoIdentitiy = isautoidentitiy;
            Index = index;
            CanNull = cannull;
            DefaultValue = defaultvalue;
            Description = Description;
            Lenght = lenght;
            DBType = dbtype;
            IsComputed = iscomputed;
        }
  
        /// <summary>
        /// 此构造方法仅用于视图
        /// </summary>
        /// <param name="columnname">列名</param>
        /// <remarks>仅仅用于视图</remarks>
        public DataFieldAttribute(string columnname )
        {
            ColumnName = columnname;
            IsKey = false;
            IsAutoIdentitiy = false;
        }
        /// <summary>
        ///数据字段描述
        /// </summary>
        /// <param name="columnname">列名</param>
        /// <param name="dbtype">类别字符串根据数据提供者</param>
        public DataFieldAttribute(string columnname, string  dbtype)
        {
            ColumnName = columnname;
            IsKey = false;
            IsAutoIdentitiy = false;
            DBType = dbtype;
        }
        /// <summary>
        ///数据字段描述
        /// </summary>
        /// <param name="columnname">列名</param>
        /// <param name="dbtype">数据库类型</param>
        /// <param name="iscomputed">自动计算</param>
        /// <param name="isautoidentitiy">自动标识列</param>
        public DataFieldAttribute(string columnname, string dbtype, bool iscomputed, bool isautoidentitiy)
        {
            ColumnName = columnname;
            IsKey = false;
            DBType = dbtype;
            IsAutoIdentitiy = isautoidentitiy;
            IsComputed = iscomputed;
        }
        /// <summary>
        /// 该列是否是服务器计算的
        /// </summary>
        public bool IsComputed { set; get; }
 
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 数据库中的提供程序的数据类型
        /// </summary>
        public string  DBType { get; set; }
        /// <summary>
        /// 字段值长度
        /// </summary>
        public int  Lenght { get; set; }
        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool IsKey { get; set; }
        /// <summary>
        /// 是否为自动生成，如果为true则自动增加，如果为false则需要您指定
        /// </summary>
        public bool IsAutoIdentitiy { get; set; }
        /// <summary>
        /// 字段在表中的顺序
        /// </summary>
        public int  Index { get; set; }
        /// <summary>
        /// 是否可以为NULL
        /// </summary>
        public bool CanNull { get; set; }
        /// <summary>
        /// 默认值,一般用于给UI控件付默认值
        /// </summary>
        public object DefaultValue { get; set; }
        /// <summary>
        /// 描述，一般用于生成文档和UI的Lable
        /// </summary>
        public string Description { get; set; }
    }
    
 
    /// <summary>
    /// 数据库表描述
    /// </summary>
    [AttributeUsage( AttributeTargets.Class)]
    public class DataTableAttribute : Attribute
    {
        /// <summary>
        /// 数据表
        /// </summary>
        /// <param name="tableName">表名称</param>
        public DataTableAttribute(string tableName)
        {
            TableName = tableName;
        }
        /// <summary>
        /// 表名
        /// </summary>
        public string  TableName { get; set; }
    }
    /// <summary>
    /// 数据库K视图描述
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DataViewAttribute : Attribute
    {
        /// <summary>
        /// 实例化一个数据库K视图描述
        /// </summary>
        /// <param name="viewname"></param>
        public DataViewAttribute(string viewname)
        {
            ViewName = viewname;
        }
        /// <summary>
        /// 自定义SQL语句的视图
        /// </summary>
        /// <param name="viewname">视图名称</param>
        /// <param name="sqlstring">生成此视图的SQL语句</param>
        public DataViewAttribute(string viewname,string sqlstring)
        {
            ViewName = viewname;
            SQLString = sqlstring;
        }
        /// <summary>
        /// SQL语句类型
        /// </summary>
        public string SQLString { get; set; }
        /// <summary>
        /// 视图名称
        /// </summary>
        public string ViewName { get; set; }

    }
    /// <summary>
    /// 数据库SQL语句描述
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DataViewSQLAttribute : Attribute
    {
        /// <summary>
        /// 在连接字符串所链接的数据库中执行一个简单的sql语句condition,如果语句返回字符串OK,则执行sqlstring.
        /// </summary>
        /// <param name="condition">条件语句，此SQL语句如返回"OK",则执行sqlstring中的sql语句</param>
        /// <param name="value">条件语句返回值</param>
        /// 
        /// <param name="sqlstring">当条件语句返回"OK"时执行本语句</param>
        public DataViewSQLAttribute(string condition,string value , string sqlstring)
        {
            Value = value;
            Condition = condition;
            SQLString = sqlstring;
        }
        /// <summary>
        /// SQL语句
        /// </summary>
        public string SQLString { get; set; }
        /// <summary>
        /// 条件SQL语句
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
  
  

 

}
