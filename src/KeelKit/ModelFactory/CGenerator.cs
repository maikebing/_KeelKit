using System;
using System.Data;
using System.IO;
using Keel;

namespace KeelKit.Generators
{
    public class CGenerator
    {

        public CGenerator(string outgccpath)
        {
            OutPathGCC = outgccpath;
        }
        private string _param;

        public string Param
        {
            get { return _param; }
            set { _param = value; }
        }

        public void GeneratedCode()
        {
            Common.ShowInfo("正在检查数据库是否可用!");
            if (Kit.CheckDataBase())
            {
 
                Common.ShowInfo("正在从数据库中读取表信息...");
                EnvDTE.Project pjt = Kit.GetProjectModel();
                DBHelper<SQLTableInfo> dbi = new DBHelper<SQLTableInfo>();
                DataTable DBFullInfo = dbi.GetDataViewForDataTable();
                string  lsttab = (Kit.SlnKeel.DataTables + Kit.SlnKeel.DataViews);
                DataRow[] tbs = DBFullInfo.Select("t_fieldindex =1");//查询出所有的
                for (int i = 0; i < tbs.Length; i++)
                {
                    DataRow dr = tbs[i];
                    string t_tablename = dr["t_tablename"].ToString();
                    if (lsttab.ToLower().Contains(t_tablename.ToLower().Trim() + ";"))
                    {
                        DataRow[] fields = DBFullInfo.Select("t_tablename ='" + t_tablename + "'");
                        Common.ShowInfo("正在生成表:" + t_tablename + "...");
                        BuildTable_HFile(t_tablename, fields);
                        BuildTable_CFile(t_tablename, fields);
                    }
                }
                Common.ShowInfo("生成完毕!");
                DBFullInfo.Dispose(); ;
            }
         
        }
        public string OutPathGCC { get; set; }
        /// <summary>
        /// 生成.c文件
        /// </summary>
        /// <param name="t_tablename">表名</param>
        /// <param name="drs">字段详细信息</param>
        void BuildTable_CFile(string t_tablename, DataRow[] drs)
        {
            Common.ShowInfo(string.Format("正在准备{0}.c...", t_tablename));
            string outpath = Path.Combine(OutPathGCC, t_tablename + ".c");
            StreamWriter sw = File.CreateText(outpath);
            sw.WriteLine("//By {0}   CreateDate:{1}", this.ToString(), DateTime.Now.ToString());
            sw.WriteLine("#include \"include/{0}.h\"", t_tablename);//引用头文件
            string stname = "MSG_" + t_tablename.ToUpper();
            string msgname = "Msg" + t_tablename;
            sw.WriteLine("struct {0} {1};", stname, msgname);//声明结构
            //写初始化结构的函数
            sw.WriteLine("void Init{0}(void)", msgname);
            sw.WriteLine("{");
            sw.WriteLine("memset((char *)&{0},'0',sizeof(struct {1}));", msgname, stname);//	memset((char *)&MsgTcscOpe,'0',sizeof(struct MSG_TCSC_OPE));
            sw.WriteLine("}");
            //写获取函数
            sw.WriteLine("struct {0} *Get{1}(void)", stname, msgname);//struct MSG_TCSC_OPE  *GetMsgTcscOpe()
            sw.WriteLine("{");
            sw.WriteLine("return (struct {0}  *)&{1};", stname, msgname);//return (struct MSG_TCSC_OPE  *)&MsgTcscOpe;
            sw.WriteLine("}");
            //访问接口的声明
            for (int i = 0; i < drs.Length; i++)
            {
                DataRow dr = drs[i];
                int l = (int.Parse(dr["t_fieldlenght"].ToString()));
                if (dr["t_fielddesc"].ToString() != "")
                {
                    sw.WriteLine("//" + dr["t_fielddesc"].ToString());
                }
                switch (dr["t_fieldtype"].ToString())
                {
                    case "image":
                        sw.WriteLine("//不支持image类型的字段{0}", dr["t_fieldtype"].ToString());
                        break;
                    case "char":
                    case "datetime":
                    case "varchar":
                    default:
                        if (l == 1)
                        {
                            sw.WriteLine("void Set{1}Msg{0}(char Input{0})", dr["t_fieldname"].ToString(), t_tablename);
                            sw.WriteLine("{");
                            sw.WriteLine("  {0}.{1}=Input{1};", msgname, dr["t_fieldname"].ToString());//xx.xx=x
                            sw.WriteLine("}");
                        }
                        else
                        {
                            sw.WriteLine("void Set{1}Msg{0}(char* Input{0})", dr["t_fieldname"].ToString(), t_tablename);
                            sw.WriteLine("{");
                            sw.WriteLine("	strncpy({0}.{1},Input{1},sizeof({0}.{1}));"
                                             , msgname, dr["t_fieldname"].ToString());
                            sw.WriteLine("}");
                        }
                        break;
                    case "int":
                    case "smallint":
                        sw.WriteLine("void Set{1}Msg{0}(int Input{0})", dr["t_fieldname"].ToString(), t_tablename);
                        sw.WriteLine("{");
                        sw.WriteLine("	sprintf({0}.{1},\"%0{2}d\",Input{1});"
                                            , msgname, dr["t_fieldname"].ToString(), dr["t_fieldlenght"].ToString());//	sprintf(MsgWeight.FareBaseNoTon,"%04d",InputFareBaseNoTon);
                        sw.WriteLine("}");
                        break;
                    case "float":
                        sw.WriteLine("void Set{1}Msg{0}(int Input{0})", dr["t_fieldname"].ToString(), t_tablename);
                        sw.WriteLine("{");
                        sw.WriteLine("	sprintf({0}.{1},\"%0{2}f\",Input{1});"
                                            , msgname, dr["t_fieldname"].ToString(), dr["t_fieldlenght"].ToString());//	sprintf(MsgWeight.FareBaseNoTon,"%04d",InputFareBaseNoTon);
                        sw.WriteLine("}");
                        break;
                }


            }
            sw.WriteLine(); ;
            sw.WriteLine("//end_" + t_tablename);
            sw.Close();
            Common.ShowInfo(string.Format("{0}的.c文件已写入至{1}", t_tablename, outpath));
        }

        /// <summary>
        /// 生成c语法的结构和结构的访问头文件。 
        /// </summary>
        /// <param name="t_tablename">表名</param>
        /// <param name="drs">字段信息</param>
        /// <example> BuildTable_HFile(t_tablename, fields);</example>
        /// <remarks>文件将生成在OutPath参数下的include目录</remarks>
        void BuildTable_HFile(string t_tablename, DataRow[] drs)
        {
            Common.ShowInfo(string.Format("正在准备{0}.h文件...", t_tablename));
            const string fistspace = "     ";
            string p1 = Path.Combine(OutPathGCC, "include");
            if (Directory.Exists(p1) == false)
            {
                Directory.CreateDirectory(p1);
            }
            string outpath = Path.Combine(p1, t_tablename + ".h");
            StreamWriter sw = File.CreateText(outpath);
            sw.WriteLine("//By {0}   CreateDate:{1}", this.ToString(), DateTime.Now.ToString());
            sw.WriteLine("#ifndef _" + t_tablename + "_H_");
            sw.WriteLine("#define _" + t_tablename + "_H_");
            string stname = "MSG_" + t_tablename.ToUpper();
            sw.WriteLine("struct {0}", stname);
            sw.WriteLine("{");
            int msglenght = 0;
            for (int i = 0; i < drs.Length; i++)
            {
                DataRow dr = drs[i];
               
                int l1 = (int.Parse(dr["t_fieldbitcount"].ToString()));
                int l2 = (int.Parse(dr["t_fieldlenght"].ToString()));
                int l = (int)l1  >l2  ?l1  : l2 ;
                msglenght += l;//统计这个结构的长度
                string code = string.Format("{0} char {1}", fistspace, dr["t_fieldname"].ToString());
                if (l == 1)
                {
                    code += ";";
                }
                else
                {
                    code += string.Format("[{0}];", l.ToString());

                }
                if (dr["t_fielddesc"].ToString() != "")
                {
                    code += "//" + dr["t_fielddesc"].ToString();
                }
                if (dr["t_fielddefaultvalue"].ToString() != "")
                {
                    code += "//:默认值" + dr["t_fielddefaultvalue"].ToString();
                }
                switch (dr["t_fieldtype"].ToString())
                {
                    case "image":
                        sw.WriteLine("        //不支持image类型的字段{0}", dr["t_fieldtype"].ToString());
                        break;
                    default:
                        sw.WriteLine(code);
                        break;
                }
            }
            sw.WriteLine("};//endstruct" + t_tablename);

            //消息结构长度 
            sw.WriteLine("#define  LENGHT_{0} {1}", stname, msglenght.ToString());

            //访问接口的声明
            sw.WriteLine("void InitMsg{0}(void);", t_tablename);
            sw.WriteLine("struct {0} *GetMsg{1}(void);", stname, t_tablename);
            for (int i = 0; i < drs.Length; i++)
            {
                DataRow dr = drs[i];
                int l = (int.Parse(dr["t_fieldlenght"].ToString()));
                string code;
                switch (dr["t_fieldtype"].ToString())
                {
                    case "image":
                        code = "        //不支持image类型的字段 " + dr["t_fieldtype"].ToString();
                        break;
                    case "char":
                    case "datetime":
                    case "varchar":
                        if (l == 1)
                        {
                            code = string.Format("void Set{1}Msg{0}(char Input{0});", dr["t_fieldname"].ToString(), t_tablename);
                        }
                        else
                        {
                            code = string.Format("void Set{1}Msg{0}(char* Input{0});", dr["t_fieldname"].ToString(), t_tablename);
                        }
                        break;
                    case "int":
                        code = string.Format("void Set{1}Msg{0}(int Input{0});", dr["t_fieldname"].ToString(), t_tablename);
                        break;
                    case "smallint":
                        code = string.Format("void Set{1}Msg{0}(short  Input{0});", dr["t_fieldname"].ToString(), t_tablename);
                        break;
                    case "float":
                        code = string.Format("void Set{1}Msg{0}(float  Input{0});", dr["t_fieldname"].ToString(), t_tablename);
                        break;
                    default:
                        code = string.Format("void Set{1}Msg{0}(char*  Input{0});", dr["t_fieldname"].ToString(), l.ToString());
                        break;
                }
                if (dr["t_fielddesc"].ToString() != "")
                {
                    code += "//" + dr["t_fielddesc"].ToString();
                }
                if (dr["t_fielddefaultvalue"].ToString() != "")
                {
                    code += "//:默认值" + dr["t_fielddefaultvalue"].ToString();
                }
                sw.WriteLine(code);
            }
            sw.WriteLine("#endif //define t_tablename");
            sw.WriteLine();
            sw.Close();
            Common.ShowInfo(string.Format("{0}的头文件已写入至{1}", t_tablename, outpath));
        }


    }
}
