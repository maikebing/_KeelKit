using System;
using System.Collections.Generic;
using KeelKit.Core.Serialization;

namespace KeelKit.Serialization
{
    [Serializable()]
    public class KeelExt
    {
        #region Model相关配置
        public enum ModelKind
        {
            /// <summary>
            /// .Net软件与.Net软件交互的Model
            /// </summary>
            DotNetAndDotNet,
            /// <summary>
            /// DotNet和C交互的Model
            /// </summary>
            DotNetAndC,
            /// <summary>
            /// Grove的Model
            /// </summary>
            Grove,
        }
        /// <summary>
        /// Model项目名称
        /// </summary>
        public string ModelProjectName { get; set; }
        /// <summary>
        /// Model种类
        /// </summary>
        public ModelKind ModelProjectKind { get; set; }
        /// <summary>
        /// 是否生成其他语言的Model
        /// </summary>
        public bool ModelGenerateMore { get; set; }
        /// <summary>
        /// 是否添加一些高级程序员使用的内容
        /// </summary>
        public bool ModelAddMore { get; set; }
        public string  DataViews { get;set; }
        public string DataSP { get; set; }
        public string   DataTables { get; set; }
        public string DataTableForms { get; set; }
        public string DataViewForms { get; set; }
        public   bool FormForInherit { get; set; }
        public bool ModelForUI { get; set; }
        public   　List<StoredProcedure> StoredProcedureSettings{get ;set ;}
 
        public string  ModelForCPath { get; set; }
        /// <summary>
        /// 是否支持xml序列化
        /// </summary>
        public bool ModelCanSerialization { get; set; }
        #endregion 
        /// <summary>
        /// DAL项目名称
        /// </summary>
        public string DALProjectName { get; set; }

        #region UI相关选项
        /// <summary>
        /// UI项目名称
        /// </summary>
        public string UIProjectName { get; set; }
        public bool  UIAddForm { get; set; }
        public bool UIModifyForm { get; set; }
        public bool UIQueryForm { get; set; }
        public bool UIPrinterForm { get; set; }
        #endregion 
        #region 组件
        public string ComponentProjectName { get; set; }
        #endregion 


        #region 数据库链接
        /// <summary>
        /// 数据源名称 
        /// </summary>
        public string DataSourceName { get; set; }
        /// <summary>
        /// 提供程序名称
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string ConnectString { get; set; }
        #endregion 


        /// <summary>
        /// 数据库文档页眉
        /// </summary>
        public string DBDoc_Header { get; set; }
        /// <summary>
        /// 做文档处理的表
        /// </summary>
        public string DBDoc_DataTables { get; set; }
        /// <summary>
        /// 自动版本号配置
        /// </summary>
        public  AutoVersionSetting AutoVersion { get; set; }
        /// <summary>
        /// 代码行统计配置
        /// </summary>
        public  ClcSetting CodeLineCounter { get; set; }
        /// <summary>
        /// 语言代码提供器配置
        /// </summary>
        public LangCodeProvider CodeProviderRouter { get; set; }
        /// <summary>
        /// 单元测试配置
        /// </summary>
        public NUnitSetting Nunit { get; set; }
    }
}
