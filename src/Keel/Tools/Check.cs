using System;
using System.Collections.Generic;
using System.Text;

namespace Keel.Tools
{
    /// <summary>
    /// 数据检查工具类
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// 检查指定类型是否为Keel的Model 
        /// </summary>
        /// <param name="model">类型</param>
        /// <returns></returns>
        public static bool CheckIsKeelModel(Type model)
        {
            bool result = false;
            if (model != null)
            {
                object[] objs = model.GetCustomAttributes(typeof(Keel.ORM.DataTableAttribute), true);
                result = objs.Length > 0;
            }
            return result;
        }
    }
}
