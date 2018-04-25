using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Keel;
using KeelKit.Core;
using KeelKit.Serialization;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Data.OleDb;
using Keel.DB;
using KeelKit.ModelFactory;
namespace KeelKit.Generators
{
    public class ModelGengerator : BaseGengerator
    {
        public ModelGengerator(string cfNameSpace, string cfClassName)
            : base(cfNameSpace)
        {
            string strTableName = cfClassName;
            ctd = new CodeTypeDeclaration(cfClassName.Replace(' ', '_'));
            ctd.IsClass = true;
            cns.Types.Add(ctd);
            CodeAttributeDeclaration cad = new CodeAttributeDeclaration(new CodeTypeReference(typeof(Keel.ORM.DataTableAttribute))
                 , new CodeAttributeArgument(new CodePrimitiveExpression(cfClassName))
                );
            ctd.CustomAttributes.Add(cad);
            CodeAttributeDeclaration dsta = new CodeAttributeDeclaration(new CodeTypeReference(typeof(System.Diagnostics.DebuggerStepThroughAttribute)));
            ctd.CustomAttributes.Add(dsta);
            //加入可序列化内容。 
            if (Kit.SlnKeel.ModelCanSerialization)
            {
                CodeAttributeDeclaration xmls = new CodeAttributeDeclaration(new CodeTypeReference(typeof(SerializableAttribute)));
                ctd.CustomAttributes.Add(xmls);
            }
            CodeMemberMethod cmmClone = new CodeMemberMethod();
            cmmClone.Name = "Clone";
            CodeMethodReturnStatement _return1 = new CodeMethodReturnStatement();
            CodeCastExpression _cast1 = new CodeCastExpression();
            CodeMethodInvokeExpression _invoke1 = new CodeMethodInvokeExpression();
            CodeMethodReferenceExpression _MemberwiseClone_method1 = new CodeMethodReferenceExpression();
            _MemberwiseClone_method1.MethodName = "MemberwiseClone";
            CodeThisReferenceExpression _this1 = new CodeThisReferenceExpression();
            _MemberwiseClone_method1.TargetObject = _this1;
            _invoke1.Method = _MemberwiseClone_method1;
            _cast1.Expression = _invoke1;
            CodeTypeReference _System_Object_type1 = new CodeTypeReference(ctd.Name);
            _cast1.TargetType = _System_Object_type1;
            _return1.Expression = _cast1;
            cmmClone.Statements.Add(_return1);
            cmmClone.ReturnType = _System_Object_type1;
            cmmClone.Attributes = (cmmClone.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            // cmmClone.Comments.Add(new CodeCommentStatement("创建一个对象的副本"));
            ctd.Members.Add(cmmClone);

        }

        public void AddFunForStructModel()
        {
            if (Kit.SlnKeel.ModelProjectKind == KeelExt.ModelKind.DotNetAndC)
            {
                CodeMemberMethod cmmGetLenght = new CodeMemberMethod();
                cmmGetLenght.Name = "GetLenght";
                cmmGetLenght.ReturnType = new CodeTypeReference(typeof(int));
                cmmGetLenght.Attributes = (cmmGetLenght.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
                cmmGetLenght.Statements.Add(new CodeMethodReturnStatement(
                    new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
                        new CodeTypeReferenceExpression(typeof(Marshal))
                        , "SizeOf"), new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "var_" + ctst.Name))));
                cmmGetLenght.Comments.Add(new CodeCommentStatement("获取以字节为单位的结构总长度"));
                ctd.Members.Add(cmmGetLenght);

            }
        }

        public bool AddPropertyStruct(string name, Type type, System.CodeDom.CodeAttributeDeclaration cad, int len, string desc)
        {
            bool i = false;
            try
            {
                CodeMemberProperty cmp = new CodeMemberProperty();
                CodeMemberField cmf = new CodeMemberField(typeof(byte[]), "ary_" + name);
                if (desc != null && desc.Trim() != "")
                {
                    cmf.Comments.Add(new CodeCommentStatement(desc));
                    cmp.Comments.Add(new CodeCommentStatement(desc));
                }
                cmf.CustomAttributes.Add(
                    new CodeAttributeDeclaration(new CodeTypeReference(typeof(MarshalAsAttribute))
                                 , new CodeAttributeArgument(
                                           new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(typeof(UnmanagedType)),
                                                                            UnmanagedType.ByValArray.ToString()))


                , new CodeAttributeArgument("SizeConst", new CodePrimitiveExpression(len))));
                cmf.Attributes = (cmf.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
                ctst.Members.Add(cmf);

                cmp.Name = name;

                cmp.CustomAttributes.Add(cad);
                cmp.Type = new CodeTypeReference(type);
                cmp.Attributes = (cmp.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;

                CodeExpression csmt =
                        new CodeMethodInvokeExpression(
                            new CodeMethodReferenceExpression(
                                new CodeTypeReferenceExpression(typeof(Encoding))
                                , "Default.GetString")
                                , new CodeFieldReferenceExpression(new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), cmf_var.Name), cmf.Name));

                if (type.Equals(typeof(byte[])))
                {
                    cmp.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), cmf_var.Name), cmf.Name)));
                }

                else if (type.Equals(typeof(string)))
                {
                    cmp.GetStatements.Add(new CodeMethodReturnStatement(csmt));

                }
                else
                {
                    cmp.GetStatements.Add(new CodeMethodReturnStatement(
                        new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(type), "Parse"), csmt)));


                }

                if (type.Equals(typeof(byte[])))
                {
                    cmp.SetStatements.Add(
                    new CodeAssignStatement(
                    new CodeFieldReferenceExpression(
                    new CodePropertyReferenceExpression(
                    new CodeThisReferenceExpression(), cmf_var.Name), cmf.Name)
                    , new CodePropertySetValueReferenceExpression()
                     ));


                }
                else
                {
                    cmp.SetStatements.Add(
                        new CodeConditionStatement(
                        new CodeMethodInvokeExpression(
                        new CodeTypeReferenceExpression(typeof(object)), "Equals",
                        new CodePropertySetValueReferenceExpression(),
                        new CodePrimitiveExpression(null))
                        , new CodeMethodReturnStatement()));
                    cmp.SetStatements.Add(
                    new CodeAssignStatement(
                    new CodeFieldReferenceExpression(
                    new CodePropertyReferenceExpression(
                    new CodeThisReferenceExpression(), cmf_var.Name), cmf.Name),
                    new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                    new CodePropertyReferenceExpression(
                    new CodeTypeReferenceExpression(typeof(Encoding)), "Default")
                    , "GetBytes"),
                    new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
                    new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
                    new CodePropertySetValueReferenceExpression()
                    , "ToString")), "PadRight"), new CodePrimitiveExpression(len), new CodePrimitiveExpression(' '))

                    )));
                }

                ctd.Members.Add(cmp);
                i = true;
            }
            catch (Exception)
            {
                i = false;
            }
            return i;
        }
        public bool AddProperty(SQLTableInfo dbi)
        {
            return AddProperty(dbi, KeelExt.ModelKind.DotNetAndDotNet);
        }
        public bool AddProperty(SQLTableInfo dbi, KeelExt.ModelKind km)
        {
            string COK = "√";
            bool i = false;
            string t_fieldname = ClearBadChars(dbi.t_fieldname);
            CodeAttributeDeclaration cad = null;
            try
            {
                if (dbi.t_tablekey == COK)
                {
                    cad = new CodeAttributeDeclaration(new CodeTypeReference(typeof(Keel.ORM.KeyFieldAttribute)));
                    cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(dbi.t_fieldname)));
                    cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(Keel.DB.Common.NowDataBase.PasteDBType(dbi.t_fieldtype).ToString())));
                    if (dbi.t_identity != COK)
                    {
                        cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(false)));
                    }
                }
                else
                {
                    cad = new CodeAttributeDeclaration(new CodeTypeReference(typeof(Keel.ORM.DataFieldAttribute)));
                    cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(dbi.t_fieldname)));
                    cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(Keel.DB.Common.NowDataBase.PasteDBType(dbi.t_fieldtype).ToString())));
                    if (Kit.SlnKeel.ModelForUI)
                    {
                        cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression((object)dbi.t_fielddefaultvalue)));
                        cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression((dbi.t_fieldcannull == COK))));
                        cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(dbi.t_fielddesc)));
                        cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(dbi.t_fieldindex)));
                        cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(dbi.t_fieldlenght)));
                    }
                    if (dbi.t_fieldiscomputed == COK || dbi.t_identity == COK)
                    {
                        cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(dbi.t_fieldiscomputed == COK)));
                        cad.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(dbi.t_identity == COK)));
                    }
                }

                Type t = Keel.DB.Common.NowDataBase.PasteType(dbi.t_fieldtype);
                switch (km)
                {
                    case KeelExt.ModelKind.DotNetAndC:
                        int len = (int)dbi.t_fieldbitcount > dbi.t_fieldlenght ? dbi.t_fieldbitcount : dbi.t_fieldlenght;
                        i = AddPropertyStruct(t_fieldname, t, cad, len, dbi.t_fielddesc.ToString());
                        break;
                    case KeelExt.ModelKind.DotNetAndDotNet:
                    default:
                        i = AddProperty(t_fieldname, t, cad, (string)dbi.t_fielddesc);
                        break;
                }

            }
            catch (Exception ex)
            {
                Common.ShowInfo(string.Format("在处理属性{0}时遇到未料到的异常:{1}", dbi.t_fieldname, ex.Message));
            }
            return i;
        }


        const string OK = "√";
        public void AddCtor(List<SQLTableInfo> lst, KeelKit.Serialization.KeelExt.ModelKind mk)
        {

            CodeConstructor cc = new CodeConstructor();
            cc.Name = ctd.Name;
            cc.Attributes = (cc.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            CodeConstructor cc3 = new CodeConstructor();
            cc3.Name = ctd.Name;
            cc3.Attributes = (cc3.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;

            foreach (var dbi in lst)
            {
                if (dbi.t_fieldiscomputed != OK && dbi.t_identity != OK)
                {
                    Type t = Keel.DB.Common.NowDataBase.PasteType(dbi.t_fieldtype);
                    CodeParameterDeclarationExpression cpde = new CodeParameterDeclarationExpression(t, "param_" + BaseGengerator.ClearBadChars(dbi.t_fieldname));
                    CodeAssignStatement cas = new CodeAssignStatement(
                        new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), GetNameByFieldName(dbi.t_fieldname))
                            ,
                            new CodeVariableReferenceExpression("param_" + BaseGengerator.ClearBadChars(dbi.t_fieldname)));
                    cc.Parameters.Add(cpde);
                    cc.Statements.Add(cas);

                    if (dbi.t_fieldcannull != OK)
                    {
                        cc3.Parameters.Add(cpde);
                        cc3.Statements.Add(cas);
                    }
                }
            }
            if (mk != KeelExt.ModelKind.DotNetAndC)
            {
                CodeConstructor cc2 = new CodeConstructor();
                cc2.Name = ctd.Name;
                cc2.Comments.Add(new CodeCommentStatement("<summary>\r\n实例化一个\r\n</summary>" + cc2.Name));
                cc2.Attributes = (cc2.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
                ctd.Members.Add(cc2);
            }
            if (cc.Parameters.Count > 0)
            {
                cc.Comments.Add(new CodeCommentStatement(string.Format("<summary>\r\n实例化一个{0}，并填写所有字段的值\r\n({1}个)\r\n</summary>", cc.Name, cc.Parameters.Count), true));
                ctd.Members.Add(cc);
            }
            //必填参数数量必须大于0并且小于全部参数的数量。 
            if (cc3.Parameters.Count > 0 && cc3.Parameters.Count < cc.Parameters.Count)
            {
                cc3.Comments.Add(new CodeCommentStatement(string.Format("<summary>\r\n实例化一个{0}，并填写所有必填字段个的值\r\n(共{1})\r\n</summary>", cc3.Name, cc3.Parameters.Count), true));
                ctd.Members.Add(cc3);
            }
        }

        private static string tablenamenow = null;
        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="di"></param>
        /// <returns></returns>
        private static bool FindByTableName(SQLTableInfo di)
        {

            return di.t_tablename.ToLower().Trim() == tablenamenow.Trim().ToLower();
        }
        public static List<SQLTableName> GetSQLTableNameList()
        {
            return GetSQLList(null);
        }
        public static List<SQLTableName> GetSQLViewNameList()
        {
            return GetSQLList("ViewInfo");
        }

        public static List<SQLTableName> GetSQLList(string list)
        {
            Kit.CheckDataBase();
            List<SQLTableName> lsttab = null;
            if (Keel.DB.Common.NowDataBase.GetType() == typeof(Keel.DB.SQLServer))
            {
                DBHelper<SQLTableName> dbt = new DBHelper<SQLTableName>();
                lsttab = dbt.GetDataViewForObjectList(list);
            }
            else if (Keel.DB.Common.NowDataBase.GetType() == typeof(Keel.DB.MSAccess))
            {
                lsttab = new List<SQLTableName>();
                KeelKit.Core.DBInformer dbi = new DBInformer(Kit.SlnKeel.ConnectString);
                Hashtable dtm = list != "ViewInfo" ? dbi.GetUserTables() : dbi.GetUserViews();
                foreach (DictionaryEntry tb in dtm)
                {
                    SQLTableName st = new SQLTableName();
                    st.name = tb.Key.ToString();
                    lsttab.Add(st);

                }
            }
            else
            {
                lsttab = new List<SQLTableName>();
                System.Data.Common.DbConnection dbc = Keel.DB.Common.NowDataBase.GetProviderFactory().CreateConnection();
                dbc.ConnectionString = Keel.DB.Common.NowDataBase.ConnectString;
                dbc.Open();
                DataTable dt = dbc.GetSchema(list != "ViewInfo" ? "Tables" : "Views");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lsttab.Add(new SQLTableName() { name = (string)dt.Rows[i]["TABLE_NAME"] });
                }
                dbc.Close();

            }
            return lsttab;
        }
        public static void GeneratedCode()
        {
            GeneratedCode(KeelExt.ModelKind.DotNetAndDotNet);
        }
        CodeTypeDeclaration ctst = null;
        CodeMemberField cmf_var = null;
        public void AddStruct(string cfClassName)
        {
            ctst = new CodeTypeDeclaration("struct_" + cfClassName);
            ctst.IsStruct = true;
            ctst.CustomAttributes.Add(new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(StructLayoutAttribute))
                , new CodeAttributeArgument(

                     new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(typeof(LayoutKind)),
                                                                            LayoutKind.Sequential.ToString())

                    )
                , new CodeAttributeArgument("CharSet",
                     new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(typeof(CharSet)),
                                                                            CharSet.Ansi.ToString()))


                         , new CodeAttributeArgument("Pack", new CodePrimitiveExpression(1))

                                                                            ));

            cns.Types.Add(ctst);
            cmf_var = new CodeMemberField(ctst.Name, "var_" + ctst.Name);
            ctd.Members.Add(cmf_var);
            CodeConstructor cc1 = new CodeConstructor();
            cc1.Attributes = (cc1.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            cc1.Comments.Add(new CodeCommentStatement("<summary>使用空字符串初始化对象</summary>", true));
            cc1.Statements.Add(new CodeVariableDeclarationStatement(typeof(string), "s", new CodePrimitiveExpression("")));

            cc1.Statements.Add(
                new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), cmf_var.Name)

               , new CodeCastExpression(ctst.Name,

                            new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(typeof(Keel.DB.Common)), "StringToStruct"
           , new CodeMethodInvokeExpression(new CodeVariableReferenceExpression("s"), "PadRight",
                 new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "GetLenght"), new CodePrimitiveExpression(' '))
                             , new CodeTypeOfExpression(ctst.Name))


                     )));
            ctd.Members.Add(cc1);//添加默认初始化函数
            CodeConstructor cc = new CodeConstructor();
            cc.Comments.Add(new CodeCommentStatement("<summary>使用指定的字符串初始化对象</summary>", true));
            cc.Name = ctd.Name;
            cc.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "s"));
            cc.Attributes = (cc.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            cc.Statements.Add(

                new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), cmf_var.Name)

               , new CodeCastExpression(ctst.Name,

                            new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(typeof(Keel.DB.Common)), "StringToStruct"
                             , new CodeVariableReferenceExpression("s")
                             , new CodeTypeOfExpression(ctst.Name))


                     )));

            ctd.Members.Add(cc);//添加带字符串参数的初始化函数

            CodeMemberMethod cmmToString = new CodeMemberMethod();
            cmmToString.Name = "ToString";

            cmmToString.ReturnType = new CodeTypeReference(typeof(string));
            cmmToString.Attributes = (cmmToString.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public | MemberAttributes.New;
            cmmToString.Statements.Add(new CodeMethodReturnStatement(
                new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
                    new CodeTypeReferenceExpression(typeof(Keel.DB.Common))
                    , "StructToString"), new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), cmf_var.Name))));
            cmmToString.Comments.Add(new CodeCommentStatement("<summary>将结构转换为字符串</summary>", true));
            ctd.Members.Add(cmmToString);

        }
        public static void GeneratedCode(KeelExt.ModelKind mk)
        {
            Common.ShowInfo("正在检查数据库是否可用!");
            if (Kit.CheckDataBase())
            {
                Common.ShowInfo("正在从数据库中读取表信息...");
                EnvDTE.Project pjt = Kit.GetProjectModel();
                List<SQLTableInfo> dbix = GetSqlTableInfoList();
                string[] lsttab = (Kit.SlnKeel.DataTables + Kit.SlnKeel.DataViews).Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string keelcpp = null;
                foreach (var item in lsttab)
                {
                    #region 生成一个model
                    tablenamenow = item;
                    Common.ShowInfo(string.Format("正在生成{0}的实体,请稍候...", tablenamenow));
                    Predicate<SQLTableInfo> pdbi = new Predicate<SQLTableInfo>(FindByTableName);
                    List<SQLTableInfo> lstdb = dbix.FindAll(pdbi);
                    ModelGengerator mg = new ModelGengerator(Kit.GetRootNamespace(pjt), item);
                    if (mk == KeelExt.ModelKind.DotNetAndC)
                    {
                        mg.AddStruct(tablenamenow);
                        mg.AddFunForStructModel();
                    }
                    foreach (var tableitem in lstdb)
                    {
                        mg.AddProperty(tableitem, mk);
                        mg.AddTableNameConst(tableitem.t_fieldname, tableitem.t_tabledesc);
                    }
                    mg.AddCtor(lstdb, mk);
                    cfLangType cl = Kit.GetProjectLangType(pjt);
                    string filename = mg.Save(pjt.FullName, cl);

                    AddFileToProject(pjt, filename);
                    if (cl == cfLangType.CPP)
                    {
                        keelcpp += string.Format("#include \"{0}\"", new System.IO.FileInfo(filename).Name) + Environment.NewLine;
                    }
                    Common.ShowInfo(string.Format("恭喜!{0}的实体保存完毕!", tablenamenow));
                    #endregion
                }
                ForCpptoDo(pjt, keelcpp);
                Common.ShowInfo(string.Format("全部实体生成完毕，开始生产DBContext"));
                GenDAL(lsttab);
                Common.ShowInfo(string.Format("KeelKit所需生成的内容生成完毕！"));
            }
        }

        private static void GenDAL(string[] lsttab)
        {
            EnvDTE.Project pjtdal = Kit.GetProjectModel();
            KeelContextGengerator kcg = new KeelContextGengerator();
            kcg.Gengerator(Kit.GetRootNamespace(pjtdal), lsttab);
            string dalfilename = kcg.Save(pjtdal.FullName, Kit.GetProjectLangType(pjtdal));
            AddFileToProject(pjtdal, dalfilename);
        }

        private static void ForCpptoDo(EnvDTE.Project pjt, string keelcpp)
        {
            if (keelcpp != null)
            {
                try
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(pjt.FileName);
                    if (fi.Exists)
                    {
                        string keelcpppt = fi.Directory + "\\keel.cpp";
                        if (!System.IO.File.Exists(keelcpp))
                        {
                            System.IO.File.Delete(keelcpppt);
                        }
                        StringBuilder context = new StringBuilder();
                        context.Append(AddKeelKitInfo(true, "//"));
                        context.AppendLine("#include \"stdafx.h\"");
                        context.Append(keelcpp);
                        System.IO.File.WriteAllText(keelcpppt, context.ToString(), Encoding.UTF8);
                        AddFileToProject(pjt, keelcpppt);
                    }
                }
                catch (Exception ex)
                {
                    Common.ShowInfo(string.Format("在为VC++添加keel.cpp文件时遇到未处理的问题：" + ex.Message));
                }
            }
        }

        public static List<SQLTableInfo> GetSqlTableInfoList()
        {
            List<SQLTableInfo> dbix = new List<SQLTableInfo>();
            if (Keel.DB.Common.NowDataBase.GetType() == typeof(Keel.DB.SQLServer))
            {
                DBHelper<SQLTableInfo> dbi = new DBHelper<SQLTableInfo>();
                dbix = dbi.GetDataViewForObjectList();
                dbix.AddRange(dbi.GetDataViewForObjectList("ViewInfo"));
            }
            else if (Keel.DB.Common.NowDataBase.GetType() == typeof(Keel.DB.MSAccess))
            {
                KeelKit.Core.DBInformer dbi = new DBInformer(Kit.SlnKeel.ConnectString);
                //Hashtable dtm = list != "ViewInfo" ? dbi.GetUserTables() : dbi.GetUserViews();
                Hashtable dtm = dbi.GetUserTables();
                foreach (DictionaryEntry tb in dtm)
                {
                    ArrayList al = dbi.GetTableColumns(tb.Key.ToString());
                    DataTable pk = dbi.GetPrimaryKeys(tb.Key.ToString());
                    string keyx = "";
                    if (pk != null && pk.Rows.Count > 0)
                    {
                        keyx = pk.Rows[0]["COLUMN_NAME"].ToString();
                        //  t_identity=pk.Rows[0]["COLUMN_NAME"].ToString ()
                    }
                    DataTable fk = dbi.GetForeignKeys(tb.Key.ToString());
                    foreach (var item in al)
                    {
                        SQLTableInfo st = new SQLTableInfo();
                        DataFieldMetadata dfm = item as DataFieldMetadata;
                        st.t_fieldbitcount = dfm.Size;
                        st.t_fieldcannull = dfm.IsNullable ? OK : "";
                        st.t_fielddefaultvalue = dfm.DefaultValueStr as string;
                        //st.t_fielddesc =
                        //st.t_fieldindex =
                        //st.t_fieldiscomputed 
                        st.t_fieldlenght = dfm.Size;
                        st.t_fieldname = dfm.Name;
                        //st.t_fieldscale =

                        st.t_fieldtype = dbi.ConvertDataType2DBType(dfm.FieldType);
                        st.t_identity = dfm.Name == keyx ? OK : "";
                        st.t_tablekey = dfm.Name == keyx ? OK : "";
                        st.t_tablename = dfm.Table;
                        dbix.Add(st);
                    }

                }
            }
            else
            {

                System.Data.Common.DbConnection dbc = Keel.DB.Common.NowDataBase.GetProviderFactory().CreateConnection();
                dbc.ConnectionString = Keel.DB.Common.NowDataBase.ConnectString;
                dbc.Open();
                DataTable dt = dbc.GetSchema("Columns");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    SQLTableInfo sti = new SQLTableInfo();

                    try
                    {

                        sti.t_fieldbitcount = dr["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value ? 0 : (int)(ulong)dr["CHARACTER_MAXIMUM_LENGTH"];
                        sti.t_fieldcannull = ((string)dr["IS_NULLABLE"] != "NO" ? OK : "");
                        sti.t_fielddefaultvalue = dr["COLUMN_DEFAULT"] as string;
                        sti.t_fielddesc = (string)dr["COLUMN_COMMENT"];
                        sti.t_fieldindex = (int)((ulong)dr["ORDINAL_POSITION"]);
                        sti.t_fieldiscomputed = "";
                        sti.t_fieldlenght = dr["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value ? 0 : (int)(ulong)dr["CHARACTER_MAXIMUM_LENGTH"];
                        sti.t_fieldname = (string)dr["COLUMN_NAME"];
                        sti.t_fieldscale = dr["NUMERIC_SCALE"] == DBNull.Value ? 0 : (int)(ulong)dr["NUMERIC_SCALE"];
                        sti.t_fieldtype = (string)dr["DATA_TYPE"];
                        sti.t_identity = dr["EXTRA"] == DBNull.Value ? "" : (((string)dr["EXTRA"]).Contains("auto_increment") ? OK : "");
                        sti.t_tabledesc = (dr["TABLE_CATALOG"] as string + "," + dr["CHARACTER_SET_NAME"] as string);
                        sti.t_tablekey = ((string)dr["COLUMN_KEY"] == "PRI" ? OK : "");
                        sti.t_tablename = (string)dr["TABLE_NAME"];
                    }
                    catch (Exception ex)
                    {

                        Common.ShowInfo(ex.Message + "\r\n" + ex.StackTrace);
                    }
                    dbix.Add(sti);
                }
                dbc.Close();
            }
            return dbix;
        }



        private static void AddFileToProject(EnvDTE.Project pjt, string filename)
        {
            try
            {
                bool needadd = true;
                for (int i = 1; i <= pjt.ProjectItems.Count; i++)
                {
                    for (short ix = 1; ix <= pjt.ProjectItems.Item(i).FileCount; ix++)
                    {
                        if (pjt.ProjectItems.Item(i).get_FileNames(ix) == filename)
                        {
                            needadd = false;
                            goto lbl;
                        }
                    }
                }
            lbl:
                if (needadd)
                {
                    pjt.ProjectItems.AddFromFile(filename);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
