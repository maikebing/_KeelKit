using System;
using System.Data;
using System.IO;
using System.Text;
using EnvDTE;
using Keel;
using KeelKit.Generators;

namespace KeelKit.ModelFactory
{
    internal class GroveGenerator
    {
        public class Config
        {
            public static string OutPathCSharp { get; set; }
            public static string cs_Namespace { get; set; }
            public static string ConnectString { get; set; }
        }
        private static DataTable _DBFullInfo;
        public static DataTable DBFullInfo
        {
            get { return _DBFullInfo; }
            set { _DBFullInfo = value; }
        }
        public static DataTable InitDBFullInfo()
        {
            DBHelper<SQLTableInfo> dbi = new DBHelper<SQLTableInfo>();
            return dbi.GetDataViewForDataTable();
        }

        public static void GeneratedCode()
        {

            Project pjt = null;
            _DBFullInfo = null;
            try
            {
                pjt = KeelKit.Kit.GetProjectModel();
                if (pjt != null)
                {
                    Config.ConnectString = KeelKit.Kit.SlnKeel.ConnectString;
                    Config.OutPathCSharp = new System.IO.FileInfo(pjt.FileName).DirectoryName;
                    Config.cs_Namespace = KeelKit.Kit.GetRootNamespace(pjt);
                    if (Kit.CheckDataBase())
                    {
                        _DBFullInfo = InitDBFullInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                KeelKit.Common.ShowInfo("KeelKit.Generator.Grove 在初始化数据库信息时遇到问题:" + ex.Message);
            }
            if (pjt != null && _DBFullInfo != null)
            {
                DataRow[] tbs = DBFullInfo.Select("t_fieldindex =1");//查询出所有的
                string lsttab = (Kit.SlnKeel.DataTables + Kit.SlnKeel.DataViews);
                for (int i = 0; i < tbs.Length; i++)
                {
                    DataRow dr = tbs[i];
                    string t_tablename = dr["t_tablename"].ToString();
                    if (lsttab.ToLower().Contains(t_tablename.ToLower().Trim() + ";"))
                    {
                        KeelKit.Common.ShowInfo("KeelKit.Generator.Grove正在生成" + t_tablename);
                        DataRow[] fields = DBFullInfo.Select("t_tablename ='" + t_tablename + "'");
                        string filename = BuildCSStruct(t_tablename, fields);
                        pjt.ProjectItems.AddFromFile(filename);
                    }
                }
                KeelKit.Common.ShowInfo("KeelKit.Generator.Grove生成完毕!");
            }
            else
            {
                KeelKit.Common.ShowInfo("KeelKit.Generator.Grove 请先指定Model项目并保证数据库可用!");
            }
         
        }

        public static string BuildCSStruct(string t_tablename, DataRow[] fields)
        {
            string outpath = Path.Combine(Config.OutPathCSharp, t_tablename + ".cs");
            StreamWriter sw = new StreamWriter(outpath, false, Encoding.Unicode);

            string stname = "MSG_" + t_tablename.ToUpper();
            string msgname = "Msg" + t_tablename;
            #region 生成引用代码
            sw.WriteLine("//By {0}   CreateDate:{1}", "KeelKit.Generator.Grove", DateTime.Now.ToString());
            sw.WriteLine("using System;");
            sw.WriteLine("using System.Collections.Generic;");
            sw.WriteLine("using System.ComponentModel;");
            sw.WriteLine("using System.Data;");
            sw.WriteLine("using System.Text;");
            sw.WriteLine("using System.Runtime.InteropServices;");
            sw.WriteLine("using Grove.ORM;");

            #endregion
            sw.WriteLine("namespace {0}", Config.cs_Namespace);
            sw.WriteLine("{");
            #region 生成结构体
            sw.WriteLine("    /// <summary>");
            sw.WriteLine("    ///表名称{0},字段数目{1}", t_tablename, fields.Length);
            sw.WriteLine("    /// </summary>");
            sw.WriteLine("    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]");
            sw.WriteLine("    public struct {0}", stname);
            sw.WriteLine("    {");
            for (int i = 0; i < fields.Length; i++)
            {
                DataRow dr = fields[i];
                if (dr["t_fielddesc"].ToString() != "")
                {
                    sw.WriteLine("        /// <summary>{0}</summary>", dr["t_fielddesc"].ToString().Replace(System.Environment.NewLine, "///"));
                }
                switch (dr["t_fieldtype"].ToString())
                {
                    case "image":
                        sw.WriteLine("        //不支持image类型的字段{0}", dr["t_fieldtype"].ToString());
                        break;
                    default:
                        sw.WriteLine("        [MarshalAs(UnmanagedType.ByValArray, SizeConst ={0})]", dr["t_fieldlenght"].ToString());
                        sw.WriteLine("        public byte[] {0};", dr["t_fieldname"].ToString());
                        break;
                }
            }
            sw.WriteLine("    }//" + t_tablename);
            #endregion
            sw.WriteLine("    [DataTable(\"{0}\")]", t_tablename);
            sw.WriteLine("    public class {0}", t_tablename);
            sw.WriteLine("    {");
            sw.WriteLine("        {0}  _{0};", stname);
            sw.WriteLine("        public {0}({1} ___{1})", t_tablename, stname);
            sw.WriteLine("        {");
            sw.WriteLine("            _{0} = ___{0};", stname);
            sw.WriteLine("        }");
            sw.WriteLine("        public {0}()", t_tablename);
            sw.WriteLine("        {");
            sw.WriteLine("            Parse(\"\".PadRight(GetLenght(), ' '));");
            sw.WriteLine("        }");
            sw.WriteLine("        public {0}(string s)", t_tablename);
            sw.WriteLine("        {");
            sw.WriteLine("            Parse(s);");
            sw.WriteLine("        }");
            sw.WriteLine("        public int GetLenght()");
            sw.WriteLine("        {");
            sw.WriteLine("            return Marshal.SizeOf(_{0});", stname);
            sw.WriteLine("        }");
            sw.WriteLine("          //由一个string隐式构造一个{0} ", t_tablename);
            sw.WriteLine("          public static implicit operator {0}(string  s)", t_tablename);
            sw.WriteLine("         {");
            sw.WriteLine("             return new {0}(s);", t_tablename);
            sw.WriteLine("          }");

            sw.WriteLine("           //由一个{0}显式返回一个string", t_tablename);
            sw.WriteLine("           public static explicit operator string ({0} ret)", t_tablename);
            sw.WriteLine("           {");
            sw.WriteLine("               return  ret.ToString() ;");
            sw.WriteLine("           }");

            #region 生成访问接口


            for (int ii = 0; ii < fields.Length; ii++)
            {
                DataRow dr = fields[ii];
                string t_fieldname = dr["t_fieldname"].ToString();
                string nosame_t_fieldname = t_fieldname;
                if (t_tablename.ToLower() == t_fieldname.ToLower())
                {
                    nosame_t_fieldname += "_";//如果表明和字段名重复 ，则地下价 _
                }
                if (dr["t_fielddesc"].ToString() != "")
                {
                    sw.WriteLine("        /// <summary>{0}</summary>", dr["t_fielddesc"].ToString().Replace(System.Environment.NewLine, "///"));
                }
                switch (dr["t_fieldtype"].ToString())
                {
                    default:
                        if (dr["t_tablekey"].ToString() != "")
                        {
                            sw.WriteLine("        [KeyField(\"{0}\")]", t_fieldname);
                        }
                        else
                        {
                            sw.WriteLine("        [DataField(\"{0}\")]", t_fieldname);
                        }
                        break;
                    case "image":
                        sw.WriteLine("        //不支持image类型的字段{0}", nosame_t_fieldname);
                        break;
                }

                switch (dr["t_fieldtype"].ToString())
                {
                    case "datetime":
                        sw.WriteLine("        public DateTime  {0}", nosame_t_fieldname);
                        sw.WriteLine("        {");
                        sw.WriteLine("            get {");
                        sw.WriteLine("                return  DateTime.Parse(Encoding.GetEncoding(936).GetString(_{0}.{1}));", stname, t_fieldname);
                        sw.WriteLine("            }");
                        sw.WriteLine("            set {");
                        sw.WriteLine("                _{0}.{1}= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight({2},' '));", stname, t_fieldname, dr["t_fieldlenght"].ToString());
                        sw.WriteLine("            }");
                        sw.WriteLine("        }");
                        break;
                    case "image":
                        sw.WriteLine("        //不支持image类型的字段{0}", nosame_t_fieldname);
                        break;
                    case "char":
                    case "varchar":
                    default:
                        sw.WriteLine("        public string  {0}", nosame_t_fieldname);
                        sw.WriteLine("        {");
                        sw.WriteLine("            get {");
                        sw.WriteLine("                return Encoding.GetEncoding(936).GetString(_{0}.{1});", stname, t_fieldname);
                        sw.WriteLine("            }");
                        sw.WriteLine("            set {");
                        sw.WriteLine("                _{0}.{1}= Encoding.GetEncoding(936).GetBytes(value.PadRight({2},' '));", stname, t_fieldname, dr["t_fieldlenght"].ToString());
                        sw.WriteLine("            }");
                        sw.WriteLine("        }");
                        break;
                    case "int":
                        sw.WriteLine("        public Int32  {0}", nosame_t_fieldname);
                        sw.WriteLine("        {");
                        sw.WriteLine("            get {");
                        sw.WriteLine("                return   Int32.Parse(Encoding.GetEncoding(936).GetString(_{0}.{1}));", stname, t_fieldname);
                        sw.WriteLine("            }");
                        sw.WriteLine("            set {");
                        sw.WriteLine("                _{0}.{1}= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight({2},' '));", stname, t_fieldname, dr["t_fieldlenght"].ToString());
                        sw.WriteLine("            }");
                        sw.WriteLine("        }");
                        break;
                    case "smallint":
                        sw.WriteLine("        public  Int16  {0}", nosame_t_fieldname);
                        sw.WriteLine("        {");
                        sw.WriteLine("            get {");
                        sw.WriteLine("                return   Int16.Parse(Encoding.GetEncoding(936).GetString(_{0}.{1}));", stname, t_fieldname);
                        sw.WriteLine("            }");
                        sw.WriteLine("            set {");
                        sw.WriteLine("                _{0}.{1}= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight({2},' '));", stname, t_fieldname, dr["t_fieldlenght"].ToString());
                        sw.WriteLine("            }");
                        sw.WriteLine("        }");
                        break;
                    case "float":
                        sw.WriteLine("        public float  {0}", nosame_t_fieldname);
                        sw.WriteLine("        {");
                        sw.WriteLine("            get {");
                        sw.WriteLine("                return   float.Parse(Encoding.GetEncoding(936).GetString(_{0}.{1}));", stname, t_fieldname);
                        sw.WriteLine("            }");
                        sw.WriteLine("            set {");
                        sw.WriteLine("                _{0}.{1}= Encoding.GetEncoding(936).GetBytes(value.ToString().PadRight({2},' '));", stname, t_fieldname, dr["t_fieldlenght"].ToString());
                        sw.WriteLine("            }");
                        sw.WriteLine("        }");
                        break;
                }
            }
            #endregion

            #region 生成ToString 和 Pase 函数

            sw.WriteLine("        public override string ToString()");
            sw.WriteLine("        {");
            sw.WriteLine("          int rawsize = Marshal.SizeOf(_{0});//得到内存大小", stname);
            sw.WriteLine("          IntPtr buffer = Marshal.AllocHGlobal(rawsize);//分配内存");
            sw.WriteLine("          Marshal.StructureToPtr(_{0}, buffer, true);//转换结构", stname);
            sw.WriteLine("          byte[] rawdatas = new byte[rawsize];");
            sw.WriteLine("          Marshal.Copy(buffer, rawdatas, 0, rawsize);//拷贝内存");
            sw.WriteLine("          Marshal.FreeHGlobal(buffer); //释放内存");
            sw.WriteLine("          return Encoding.GetEncoding(936).GetString(rawdatas);");
            sw.WriteLine("        }");


            sw.WriteLine("        public  void Parse(string s)");
            sw.WriteLine("        {");
            sw.WriteLine("             Type anytype = typeof({0});", stname);
            sw.WriteLine("             byte[] rawdatas = Encoding.GetEncoding(936).GetBytes(s);");
            sw.WriteLine("             int rawsize = Marshal.SizeOf(anytype);");
            sw.WriteLine("             if (rawsize > rawdatas.Length)");
            sw.WriteLine("                   _{0}= new {0}();", stname);
            sw.WriteLine("             IntPtr buffer = Marshal.AllocHGlobal(rawsize);");
            sw.WriteLine("             Marshal.Copy(rawdatas, 0, buffer, rawsize);");
            sw.WriteLine("             object retobj = Marshal.PtrToStructure(buffer, anytype);");
            sw.WriteLine("             Marshal.FreeHGlobal(buffer);");
            sw.WriteLine("              _{0}=({0})retobj;", stname);
            sw.WriteLine("        }");
            #endregion



            sw.WriteLine("      }//" + t_tablename);
            sw.WriteLine(" }//" + Config.cs_Namespace);//namespace
            sw.Close();
            Console.WriteLine("解析和插入表{0}的CSharp代码已生成!", t_tablename);
            return outpath;
        }

    }
}
