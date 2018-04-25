using System;
using System.CodeDom;
using System.Data;
using System.Text;
using Keel;
using KeelKit.Core;
namespace KeelKit.Generators
{
 
    public class ViewGenerator:BaseGengerator 
    {
   
        /// <summary>
        /// 根据命名空间类命和表明创建一个Model
        /// </summary>
        /// <param name="cfNameSpace"></param>
        /// <param name="cfClassName"></param>
        /// <param name="modTableName"></param>
        public ViewGenerator(string cfNameSpace, string cfClassName,string sql )
            :base(cfNameSpace )
        {
            string strTableName=cfClassName ;
            ctd = new CodeTypeDeclaration(cfClassName);
            ctd.IsClass = true;
            cns.Types.Add(ctd);
            CodeAttributeDeclaration cad = new CodeAttributeDeclaration(
             new CodeTypeReference(typeof(Keel.ORM.DataViewAttribute ))
          , new CodeAttributeArgument(new CodePrimitiveExpression(cfClassName ))
          , new CodeAttributeArgument(new CodePrimitiveExpression(Convert.ToBase64String(Encoding.Default.GetBytes( sql), Base64FormattingOptions.InsertLineBreaks )))
          );
            ctd.CustomAttributes.Add(cad); 
        }
        
 
        public static bool  GeneratedCode(string sql  ,EnvDTE.Project pjt,string classname)
        {
            bool ok=  Kit.CheckDataBase();
            if (ok)
            {
                DBOperator<Keel.DB.Common> obc = new DBOperator<Keel.DB.Common>();
                DataTable dt = obc.ExecuteFillDataTable(sql);
                ok = false;
                if (classname == null || classname == "")
                {
                    classname = dt.TableName;
                }
                if (classname != null && classname != "")
                {
                    ViewGenerator mg = new ViewGenerator((string)pjt.Properties.Item("RootNamespace").Value, classname, sql);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataColumn dc = dt.Columns[i];
                        mg.AddProperty(dc.ColumnName, dc.DataType,null );
                    }
                    cfLangType cl =Kit. GetProjectLangType(pjt);
                   string filename =  mg.Save(pjt.FileName,  cl );
                   pjt.ProjectItems.AddFromFile(filename);
                    ok = true;
                }
            }
            return ok;
        }


    }
}
