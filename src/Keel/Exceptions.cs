using System;
using System.Collections.Generic;
using System.Text;

namespace Keel.Exceptions
{
    /// <summary>
    /// 没有配置数据库
    /// </summary>
    public class DataBaseNotConfigException : Exception
    {
        /// <summary>
        /// 错误描述
        /// </summary>
        public override string Message
        {
            get
            {
                return "当前程序集使用的默认数据库尚未配置!";
            }
        }
    }
    public class KeyNotFountException : Exception
    {
        /// <summary>
        /// 错误描述
        /// </summary>
        public override string Message
        {
            get
            {
                return "未能找到主键!";
            }
        }
    }
    /// <summary>
    /// 不是KeelKit所能支持的Model
    /// </summary>
    public class NotAKeelModelException : Exception
    {
        /// <summary>
        /// 错误消息描述
        /// </summary>
        public override string Message
        {
            get
            {
                return  "不是Keel所能支持的Model!";
            }
        }
    }
    /// <summary>
    /// 配置程序的连接字符串异常
    /// </summary>
    public class DataBaseConnectionStringIsException : Exception
    {
        /// <summary>
        /// 错误信息描述
        /// </summary>
        public override string Message
        {
            get
            {
                return "配置程序的连接字符串异常或者无法正确读取!";
            }
        }


    }
}
