using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Keel;
using KeelKit.Core;
using KeelKit.Serialization;

namespace KeelKit.Generators
{
    public class SPGengerator:BaseGengerator
    {

        public static List<SQLTableName> GetSPNameList()
        {
            return ModelGengerator.GetSQLList("SPInfo");
        }
        
  
        public SPGengerator(string cfNameSpace, string cfClassName)
            : base(cfNameSpace )
        {
            string strTableName = cfClassName;
            ctd = new CodeTypeDeclaration(cfClassName);
            ctd.IsClass = true;
            cns.Types.Add(ctd);
            
        }

       private static   string spnamenow = null;
        private  static  bool FindByTableName(SPInfos  di)
        {
            if (spnamenow == null) return false;
            return di.sp_name   == spnamenow.Trim();
        }
        private static string GetFileNames(string path, string FileExtension)
        {
            string filename =path  ;
            string bf=filename ;
            if ( FileExtension[0] == '.')
            {
                filename += FileExtension;
            }
            else
            {
                filename += "." + FileExtension;
            }
            if (System.IO.File.Exists(filename))
            {
                filename = bf + Guid.NewGuid().ToString("N")+"." +FileExtension ;
            }
            return filename;
        }
        public static bool GeneratedCode(  EnvDTE.Project pjt, string classname)
        {
            bool ok=  Kit.CheckDataBase();
            if (ok)
            {
                DBHelper<SPInfos> dbspi = new DBHelper<SPInfos>();
                List<SPInfos> lspi = dbspi.GetDataViewForObjectList();
                ok = false;
                if (classname == null || classname == "")
                {
                    classname = "DALSP";
                }
                string[] dttmp = Kit.SlnKeel.DataSP.Split(";".ToCharArray(),  StringSplitOptions.RemoveEmptyEntries );

                SPGengerator mg = new SPGengerator(Kit. GetRootNamespace(pjt ), classname);
                List<KeelKit.Generators.SQLTableName> stb = Generators.SPGengerator.GetSPNameList();
                foreach (var item in dttmp )
                {
                    Predicate<SPInfos> pdbi = new Predicate<SPInfos>(FindByTableName);
                    spnamenow = item;
                    List<SPInfos> lstdb = lspi.FindAll(pdbi);

                    try
                    {
                          mg.AddMethod(lstdb,item );
                    }
                    catch (Exception)
                    {
                        
                       
                    }
       
                }
                 
                cfLangType cl = Kit.GetProjectLangType(pjt);
                string filename = mg.Save(Path.GetDirectoryName(pjt.FullName ) + "\\" + classname, cl, new DGetFileNames(GetFileNames));
                pjt.ProjectItems.AddFromFile(filename);
                ok = true;
                 
            }
            return ok;
        }

       
        string name;
        bool find( StoredProcedure v)
        {
            if (name == null || v == null) return false;
            return name == v.Name;
        }
        List<StoredProcedure> lstSp = null;
        public void AddMethod(List<SPInfos> spi,string mname)
        {
             StoredProcedure sp = GetpSP(mname);
           CodeTypeReference   t =new CodeTypeReference(typeof (object ));
           CodeTypeReference k = new CodeTypeReference(typeof(object  ));
           CodeTypeReference _ListT = null ;
            switch (sp.ExcMethod )
            {
                case SPExcMethod.ExecuteScalar:
                     t =new CodeTypeReference( Funs.TypeCodeToType(sp.ValueTypeCode));
                    break;
                case SPExcMethod.Fill:
                 
                    switch (sp.ForFillType )
                    {
                        default :
                        case SMEM_FillTo.UseDataTable:
                            t =new CodeTypeReference(typeof(DataTable));
       
                            break;
                        case SMEM_FillTo.UseDataSet:
                            t  =new CodeTypeReference( typeof(DataSet ));
                            break;
                    }
                    
                    break;
                case SPExcMethod.List:
                    t =new CodeTypeReference (typeof(int));
                    k   = new CodeTypeReference(sp.ModelName.Trim());
                    _ListT = new CodeTypeReference("List`1");
                    _ListT.TypeArguments.Add(k );
                    break;
                case SPExcMethod.Model:
                    t = new CodeTypeReference(sp.ModelName.Trim());
                    break;
                case SPExcMethod.ExecuteNonQuery:
                    t = new CodeTypeReference(typeof(int));
                    break;
                default:
                    break;
            }

            CodeMemberMethod cmmGetLenght = GetMethod(mname, t );
            if (_ListT != null)
                
            {

                CodeParameterDeclarationExpression lt = new CodeParameterDeclarationExpression(_ListT, "_ListOut_keel");
                lt.Direction = FieldDirection.Out;
                cmmGetLenght.Parameters.Add(lt );
            }
            CodeVariableDeclarationStatement dec_dbi = GetDBI(t,k  );
            cmmGetLenght.Statements.Add(dec_dbi);
            CodeVariableDeclarationStatement names = null;
            CodeVariableDeclarationStatement values = null;
            if (spi.Count > 0)
            {
                GetParams(spi, cmmGetLenght, out names, out values);
                cmmGetLenght.Statements.Add(names);
                cmmGetLenght.Statements.Add(values);
            }
  
            

            CodeMethodInvokeExpression cmie = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeVariableReferenceExpression(dec_dbi.Name), "ExcStoredProcedure")
              , new CodePrimitiveExpression(mname)
              , new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(new CodeTypeReference("Keel.SPExcMethod")),  Enum.GetName(typeof(Keel.SPExcMethod), sp.ExcMethod)));
            if (_ListT != null)
            {
                cmie.Parameters.Add( new CodeDirectionExpression( FieldDirection.Out , new CodeVariableReferenceExpression("_ListOut_keel")));
            }
            if (names != null) cmie.Parameters.Add(new CodeVariableReferenceExpression(names.Name));
            if (values != null) cmie.Parameters.Add(new CodeVariableReferenceExpression(values.Name));
     
            this.ctd.Members.Add(cmmGetLenght);
            cmmGetLenght.Statements.Add(new CodeMethodReturnStatement(cmie));
            Console.WriteLine("");
        }

        private StoredProcedure GetpSP(string mname)
        {
            if (lstSp == null)
            {
                lstSp = new List<StoredProcedure>();
                if (Kit.SlnKeel.StoredProcedureSettings != null)
                {
                    lstSp.AddRange(Kit.SlnKeel.StoredProcedureSettings);
                }
            }
            name = mname;
            StoredProcedure sp = lstSp.FindLast(new Predicate<StoredProcedure>(find));
            if (sp == null)
            {
                sp = new StoredProcedure();
                sp.Name = mname;
                sp.ExcMethod = SPExcMethod.ExecuteNonQuery;
                sp.ValueTypeCode = TypeCode.Int32;
            }
            return sp;
        }

        private CodeMemberMethod GetMethod(string mname, CodeTypeReference t)
        {
            CodeMemberMethod cmmGetLenght = new CodeMemberMethod();
            cmmGetLenght.Name = mname;
            cmmGetLenght.ReturnType =t ;
            cmmGetLenght.Attributes = (cmmGetLenght.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public | MemberAttributes.Static ;
            return cmmGetLenght;
        }

        private CodeVariableDeclarationStatement GetDBI(CodeTypeReference t, CodeTypeReference k)
        {
            CodeVariableDeclarationStatement dec_dbi = new CodeVariableDeclarationStatement();
            CodeObjectCreateExpression _new1 = new CodeObjectCreateExpression(t);
            CodeTypeReference _Keel_DBHelper_1_type1 = new CodeTypeReference("Keel.SPHelper`2");

            _new1.CreateType = _Keel_DBHelper_1_type1;
            dec_dbi.InitExpression = _new1;
            dec_dbi.Name = "dbi";
            _Keel_DBHelper_1_type1.TypeArguments.Add(t );
            _Keel_DBHelper_1_type1.TypeArguments.Add(k );
            CodeTypeReference _Keel_DBHelper_1_type2 = new CodeTypeReference("Keel.SPHelper`2");
            _Keel_DBHelper_1_type2.TypeArguments.Add(t );
            _Keel_DBHelper_1_type2.TypeArguments.Add(k );
            dec_dbi.Type = _Keel_DBHelper_1_type2;
            return dec_dbi;
        }

        private   void GetParams(List<SPInfos> spi,   CodeMemberMethod cmmGetLenght, out CodeVariableDeclarationStatement names, out CodeVariableDeclarationStatement values)
        {
            CodeTypeReference strary = new CodeTypeReference(new CodeTypeReference(typeof(string)), 1);
            CodeTypeReference objary = new CodeTypeReference(new CodeTypeReference(typeof(object)), 1);
            names = new CodeVariableDeclarationStatement(strary, "names");
            values = new CodeVariableDeclarationStatement(objary, "values");
            CodeArrayCreateExpression acnames = new CodeArrayCreateExpression(strary);
            CodeArrayCreateExpression acvalues = new CodeArrayCreateExpression(objary);
            foreach (var item in spi)
            {
                item.sp_paramname = item.sp_paramname.Replace("@", "");
                CodeParameterDeclarationExpression cmf = new CodeParameterDeclarationExpression(Keel.DB.Common.NowDataBase.PasteType(item.sp_pmdatatype), item.sp_paramname);
                cmmGetLenght.Parameters.Add(cmf);
                acnames.Initializers.Add(new CodePrimitiveExpression(item.sp_paramname));
                acvalues.Initializers.Add(new CodeVariableReferenceExpression(cmf.Name));

            }
            names.InitExpression = acnames;
            values.InitExpression = acvalues;
        }

    }
}
