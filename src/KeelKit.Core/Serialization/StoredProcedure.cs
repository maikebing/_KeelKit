using System;
using System.ComponentModel;
using Keel;

namespace KeelKit.Serialization
{
    public enum SMEM_FillTo
    {
        UseDataTable,
        UseDataSet
    }
    [Serializable]
    [DefaultPropertyAttribute("Name")]
    public class StoredProcedure
    {
        [CategoryAttribute("名称"), DescriptionAttribute("存储过程名称")]
        public string Name { get; set; }
        SPExcMethod _em = SPExcMethod.ExecuteNonQuery;
        [CategoryAttribute("参数设置"), DescriptionAttribute("执行方式")]
        [DefaultValue(SPExcMethod.ExecuteNonQuery)]
        public SPExcMethod ExcMethod
        {
            get
            {
                return _em;
            }
            set
            {
                _em = value;
                switch (_em)
                {
                    case SPExcMethod.ExecuteScalar:
                        break;
                    case SPExcMethod.Fill:
                        ForFillType = SMEM_FillTo.UseDataSet;
                        break;
                    case SPExcMethod.Model:
                        break;
                    case SPExcMethod.List:

                        break;
                    case SPExcMethod.ExecuteNonQuery:
                        break;
                    default:
                        break;
                }
            }
        }
        [CategoryAttribute("参数设置"), DescriptionAttribute("返回值类型")]
        [DefaultValue(TypeCode.Int32)]
        public TypeCode ValueTypeCode { get; set; }
        [CategoryAttribute("参数设置"), DescriptionAttribute("如果是Fill模式，决定使用DataTable还是DataSet")]
        [DefaultValue(SMEM_FillTo.UseDataSet)]
        public SMEM_FillTo ForFillType { get; set; }
        public string ModelName { get; set; }
    }
}
