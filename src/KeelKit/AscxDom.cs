using System;
using System.Text;
using KeelKit.Generators;

namespace KeelKit
{
    [Serializable]
    public class AscxDom
    {
        private StringBuilder CtlHtml = new StringBuilder("");

        public string  AddMapping(SQLTableInfo item)
        {
            if (item != null)
            {
                Type t = Keel.DB.Common.NowDataBase.PasteType(item.t_fieldtype);
                string fieldname = BaseGengerator.ClearBadChars(item.t_fieldname);
                string m = "";
                #region 类型映射
                string ext = "";
                switch (Type.GetTypeCode(t))
                {
                    case TypeCode.Boolean:
                        m = Mapping_Boolean;
                        bool b = item.t_fielddefaultvalue.Contains("1");
                        m = m.Replace("_defaultvalue_", b.ToString());
                        ext = "chk";
                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.DateTime:
                        m = Mapping_DateTime;
                        string strxdt = item.t_fielddefaultvalue;
                        if (strxdt.StartsWith("(") && strxdt.EndsWith(")"))
                        {
                            string[] ffdt = strxdt.Split("'".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (ffdt.Length >= 2)
                            {
                                strxdt = ffdt[1];
                            }

                        }
                        m = m.Replace("_defaultvalue_", strxdt);
                        ext = "dte";
                        break;
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Char:
                    case TypeCode.String:
                        m = Mapping_String;
                        string strx = item.t_fielddefaultvalue;
                        if (strx.StartsWith("(") && strx.EndsWith(")"))
                        {
                            string[] ff = strx.Split("'".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (ff.Length >= 2)
                            {
                                strx = ff[1];
                            }

                        }
                        m = m.Replace("_defaultvalue_", strx);
                        ext = "txt";
                        break;
                    case TypeCode.Decimal:
                    case TypeCode.Byte:
                    case TypeCode.Double:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.SByte:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        m = Mapping_Decimal;
                        decimal d;
                        string bxf = "";
                        if (item.t_fielddefaultvalue != "" && decimal.TryParse(item.t_fielddefaultvalue.Replace("(", "").Replace(")", ""), out d)) bxf = d.ToString();
                        m = m.Replace("_defaultvalue_", bxf);
                        ext = "dec";
                        break;
                    case TypeCode.Object:
                    default:
                        m = Mapping_Unknow;
                        m = m.Replace("_defaultvalue_", item.t_fielddefaultvalue);
                        ext = "ukw";
                        break;
                }
                #endregion
                string _name_ = "keelctl_" + ext + "_" + fieldname;
                m = m.Replace("_name_", _name_);
                m = m.Replace("_desc_", item.t_fielddesc.Trim() != "" ? item.t_fielddesc : item.t_fieldname);

                m = m.Replace("_lenght_", item.t_fieldlenght.ToString());
                m = m.Replace("_bitcount_", item.t_fieldbitcount.ToString());
                CtlHtml.AppendLine(m);
                return _name_;
            }
            else
            {
                return null;
            }
        }

        public string GenerateCodeFromAscxDom()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<!--KeelKit 版本 {1} {0} -->{2}", "此页面由工具生成,对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), System.Environment.NewLine);
            sb.AppendLine (Header);
            sb.AppendLine(CtlHtml.ToString());
            sb.AppendLine(Footer);
            return sb.ToString();
        }
       
        public void Add_Space()
        {
            CtlHtml.Append("&nbsp;");
        }
        public void Add_Text(string context)
        {
            CtlHtml.Append(context);
        }
        public string Footer { get; set; }
        public string Header { get; set; }
        public string Mapping_Decimal { get; set; }
        public string Mapping_String { get; set; }
        public string Mapping_DateTime { get; set; }
        public string Mapping_Boolean { get; set; }
        public string Mapping_Unknow { get; set; }
    }
}
