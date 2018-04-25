using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using KeelKit.Generators;
using System.CodeDom.Compiler;
using KeelKit.Core;
using System.IO;

namespace KeelKit.ModelFactory
{
    public class KeelContextGengerator
    {
        protected CodeCompileUnit ccu = new CodeCompileUnit();
        protected CodeNamespace cns = null;
        protected CodeTypeDeclaration ctd = null;
        public void Gengerator(string cfNameSpace, string[] tables)
        {
            #region 生成命名空间引用
            cns = new CodeNamespace(cfNameSpace);
            cns.Imports.Add(new CodeNamespaceImport("System"));
            cns.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            cns.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));
            cns.Imports.Add(new CodeNamespaceImport("System.Data"));
            cns.Imports.Add(new CodeNamespaceImport("System.Text"));
            cns.Imports.Add(new CodeNamespaceImport("Keel"));
            cns.Comments.Add(new CodeCommentStatement(BaseGengerator.AddKeelKitInfo(false)));
           
            #endregion

            #region 生成类头部
            ctd = new CodeTypeDeclaration("KeelEntities");
            ctd.IsClass = true;
            ctd.Attributes = (ctd.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Private;
            ctd.IsClass = true;
            CodeTypeReference _KeelContext_type1 = new CodeTypeReference(typeof(Keel.KeelContext));
            ctd.BaseTypes.Add(_KeelContext_type1);

            #endregion

            #region 生成类的实例化部分

            //
            // Field idb
            //
            CodeMemberField _idb_field1 = new CodeMemberField();
            _idb_field1.Attributes = (_idb_field1.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Private;
            _idb_field1.Name = "idb";
            CodeTypeReference _IDatabase_type1 = new CodeTypeReference("IDatabase");
            _idb_field1.Type = _IDatabase_type1;
            ctd.Members.Add(_idb_field1);


            //
            // Field dbo
            //
            CodeMemberField _dbo_field1 = new CodeMemberField();
            _dbo_field1.Attributes = (_dbo_field1.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Private;
            _dbo_field1.Name = "dbo";
            CodeTypeReference _DBOperator1_type1 = new CodeTypeReference("DBOperator");
            _DBOperator1_type1.TypeArguments.Add(typeof(Keel.IDatabase));
            _dbo_field1.Type = _DBOperator1_type1;
            ctd.Members.Add(_dbo_field1);
            //
            // Constructor()
            //
            CodeConstructor __ctor_ctor1 = new CodeConstructor();
            __ctor_ctor1.Attributes = (__ctor_ctor1.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            CodePropertyReferenceExpression _prop1 = new CodePropertyReferenceExpression();
            _prop1.PropertyName = "NowDataBase";
            CodeTypeReferenceExpression _ref1 = new CodeTypeReferenceExpression();
            CodeTypeReference _Keel_DB_Common_type1 = new CodeTypeReference(typeof(Keel.DB.Common));
            _ref1.Type = _Keel_DB_Common_type1;
            _prop1.TargetObject = _ref1;
            __ctor_ctor1.ChainedConstructorArgs.Add(_prop1);

            ctd.Members.Add(__ctor_ctor1);


            //
            // Constructor(IDatabase _idb)
            //
            CodeConstructor __ctor_ctor2 = new CodeConstructor();
            __ctor_ctor2.Attributes = (__ctor_ctor2.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            CodeTypeReference _IDatabase_type2 = new CodeTypeReference(typeof(Keel.IDatabase));
            CodeParameterDeclarationExpression __idb_arg1 = new CodeParameterDeclarationExpression(_IDatabase_type2, "_idb");
            __idb_arg1.Direction = FieldDirection.In;
            __idb_arg1.Name = "_idb";
            CodeTypeReference _IDatabase_type3 = new CodeTypeReference(typeof(Keel.IDatabase));
            __idb_arg1.Type = _IDatabase_type3;
            __ctor_ctor2.Parameters.Add(__idb_arg1);

            CodeAssignStatement _assign1 = new CodeAssignStatement();
            CodeFieldReferenceExpression _field1 = new CodeFieldReferenceExpression();
            _field1.FieldName = "idb";
            CodeThisReferenceExpression _this1 = new CodeThisReferenceExpression();
            _field1.TargetObject = _this1;
            _assign1.Left = _field1;
            CodeVariableReferenceExpression _arg1 = new CodeVariableReferenceExpression();
            _arg1.VariableName = "_idb";
            _assign1.Right = _arg1;
            __ctor_ctor2.Statements.Add(_assign1);

            ctd.Members.Add(__ctor_ctor2);





            //
            // Constructor(DBOperator`1 _odb)
            //
            CodeConstructor __ctor_ctor3 = new CodeConstructor();
            __ctor_ctor3.Attributes = (__ctor_ctor3.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            CodeTypeReference _DBOperator1_type2 = new CodeTypeReference("DBOperator");
            _DBOperator1_type2.TypeArguments.Add(typeof(Keel.IDatabase));
            CodeParameterDeclarationExpression __odb_arg1 = new CodeParameterDeclarationExpression(_DBOperator1_type2, "_odb");
            __odb_arg1.Direction = FieldDirection.In;
            __odb_arg1.Name = "_odb";
            CodeTypeReference _DBOperator1_type3 = new CodeTypeReference("DBOperator");
            _DBOperator1_type3.TypeArguments.Add(typeof(Keel.IDatabase));
            __odb_arg1.Type = _DBOperator1_type3;
            __ctor_ctor3.Parameters.Add(__odb_arg1);

            CodeAssignStatement _assign2 = new CodeAssignStatement();
            CodeFieldReferenceExpression _field2 = new CodeFieldReferenceExpression();
            _field2.FieldName = "dbo";
            CodeThisReferenceExpression _this2 = new CodeThisReferenceExpression();
            _field2.TargetObject = _this2;
            _assign2.Left = _field2;
            CodeVariableReferenceExpression _arg2 = new CodeVariableReferenceExpression();
            _arg2.VariableName = "_odb";
            _assign2.Right = _arg2;
            __ctor_ctor3.Statements.Add(_assign2);

            ctd.Members.Add(__ctor_ctor3);
            #endregion

            foreach (var item in tables)
            {
                AddItem(item);
            }
            cns.Types.Add(ctd);
            ccu.Namespaces.Add(cns);



        }

        private void AddItem(string item)
        {

            AddVar(item);

 
            CodeMemberProperty _property = new CodeMemberProperty();
            _property.Attributes = (_property.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            _property.Name = item;
            CodeTypeReference _Keel_DBHelper1_type1 = new CodeTypeReference("Keel.DBHelper", CodeTypeReferenceOptions.GenericTypeParameter );
            _Keel_DBHelper1_type1.TypeArguments.Add(item);
            _property.Type = _Keel_DBHelper1_type1;
            _property.HasGet = true;
            AddSomeCode(item, _property);//在 get  { }中 写入一部分代码

            CodeMethodReturnStatement _return1 = new CodeMethodReturnStatement();
            CodePropertyReferenceExpression _prop8 = new CodePropertyReferenceExpression();
            _prop8.PropertyName = "var_"+item ;
            CodeThisReferenceExpression _this8 = new CodeThisReferenceExpression();
            _prop8.TargetObject = _this8;
            _return1.Expression = _prop8;
            _property.GetStatements.Add(_return1);

            _property.HasSet = true;
            CodeAssignStatement _assign3 = new CodeAssignStatement();
            CodePropertyReferenceExpression _prop9 = new CodePropertyReferenceExpression();
            _prop9.PropertyName = "var_"+item ;
            CodeThisReferenceExpression _this9 = new CodeThisReferenceExpression();
            _prop9.TargetObject = _this9;
            _assign3.Left = _prop9;
            
            _assign3.Right = new  CodePropertySetValueReferenceExpression();
            _property.SetStatements.Add(_assign3);

            ctd.Members.Add(_property);
        }

        private static void AddSomeCode(string item, CodeMemberProperty _property)
        {
            CodeConditionStatement _if1 = new CodeConditionStatement();
            CodeBinaryOperatorExpression _binop1 = new CodeBinaryOperatorExpression();
            CodePropertyReferenceExpression _prop1 = new CodePropertyReferenceExpression();
            _prop1.PropertyName = "var_" + item;
            CodeThisReferenceExpression _this1 = new CodeThisReferenceExpression();
            _prop1.TargetObject = _this1;
            _binop1.Left = _prop1;
            _binop1.Operator = CodeBinaryOperatorType.IdentityEquality;
            CodePrimitiveExpression _value1 = new CodePrimitiveExpression();
            _value1.Value = null;
            _binop1.Right = _value1;
            _if1.Condition = _binop1;
            CodeConditionStatement _if2 = new CodeConditionStatement();
            CodeBinaryOperatorExpression _binop2 = new CodeBinaryOperatorExpression();
            CodePropertyReferenceExpression _prop2 = new CodePropertyReferenceExpression();
            _prop2.PropertyName = "idb";
            CodeThisReferenceExpression _this2 = new CodeThisReferenceExpression();
            _prop2.TargetObject = _this2;
            _binop2.Left = _prop2;
            _binop2.Operator = CodeBinaryOperatorType.IdentityInequality;
            CodePrimitiveExpression _value2 = new CodePrimitiveExpression();
            _value2.Value = null;
            _binop2.Right = _value2;
            _if2.Condition = _binop2;
            CodeAssignStatement _assign1 = new CodeAssignStatement();
            CodePropertyReferenceExpression _prop3 = new CodePropertyReferenceExpression();
            _prop3.PropertyName = "var_" + item;
            CodeThisReferenceExpression _this3 = new CodeThisReferenceExpression();
            _prop3.TargetObject = _this3;
            _assign1.Left = _prop3;
            CodeObjectCreateExpression _new1 = new CodeObjectCreateExpression();
            CodeTypeReference _Keel_DBHelper1_type2 = new CodeTypeReference("Keel.DBHelper", CodeTypeReferenceOptions.GenericTypeParameter);
            _Keel_DBHelper1_type2.TypeArguments.Add(item);
            _new1.CreateType = _Keel_DBHelper1_type2;
            CodePropertyReferenceExpression _prop4 = new CodePropertyReferenceExpression();
            _prop4.PropertyName = "idb";
            CodeThisReferenceExpression _this4 = new CodeThisReferenceExpression();
            _prop4.TargetObject = _this4;
            _new1.Parameters.Add(_prop4);

            _assign1.Right = _new1;
            _if2.TrueStatements.Add(_assign1);

            CodeConditionStatement _if3 = new CodeConditionStatement();
            CodeBinaryOperatorExpression _binop3 = new CodeBinaryOperatorExpression();
            CodePropertyReferenceExpression _prop5 = new CodePropertyReferenceExpression();
            _prop5.PropertyName = "dbo";
            CodeThisReferenceExpression _this5 = new CodeThisReferenceExpression();
            _prop5.TargetObject = _this5;
            _binop3.Left = _prop5;
            _binop3.Operator = CodeBinaryOperatorType.IdentityInequality;
            CodePrimitiveExpression _value3 = new CodePrimitiveExpression();
            _value3.Value = null;
            _binop3.Right = _value3;
            _if3.Condition = _binop3;
            CodeAssignStatement _assign2 = new CodeAssignStatement();
            CodePropertyReferenceExpression _prop6 = new CodePropertyReferenceExpression();
            _prop6.PropertyName = "var_" + item;
            CodeThisReferenceExpression _this6 = new CodeThisReferenceExpression();
            _prop6.TargetObject = _this6;
            _assign2.Left = _prop6;
            CodeObjectCreateExpression _new2 = new CodeObjectCreateExpression();
            CodeTypeReference _Keel_DBHelper1_type3 = new CodeTypeReference("Keel.DBHelper", CodeTypeReferenceOptions.GenericTypeParameter);
            _Keel_DBHelper1_type3.TypeArguments.Add(item);
            _new2.CreateType = _Keel_DBHelper1_type3;
            CodePropertyReferenceExpression _prop7 = new CodePropertyReferenceExpression();
            _prop7.PropertyName = "dbo";
            CodeThisReferenceExpression _this7 = new CodeThisReferenceExpression();
            _prop7.TargetObject = _this7;
            _new2.Parameters.Add(_prop7);

            _assign2.Right = _new2;
            _if3.TrueStatements.Add(_assign2);

            _if2.FalseStatements.Add(_if3);

            _if1.TrueStatements.Add(_if2);

            _property.GetStatements.Add(_if1);
        }

        private void AddVar(string item)
        {
            CodeMemberField _var_field = new CodeMemberField();
            _var_field.Attributes = MemberAttributes.Assembly | MemberAttributes.FamilyOrAssembly | MemberAttributes.Private;
            _var_field.Name = "var_" + item;
            CodeTypeReference _Keel_DBHelper1_type11 = new CodeTypeReference("Keel.DBHelper");
            _Keel_DBHelper1_type11.TypeArguments.Add(item);
            _var_field.Type = _Keel_DBHelper1_type11;
            ctd.Members.Add(_var_field);
        }



        public string Save(string path, cfLangType clt)
        {
            return Save(path, clt, new KeelKit.Generators.BaseGengerator.DGetFileNames(GetFileNames));
        }
        private string GetFileNames(string path, string FileExtension)
        {
            string filename = Path.GetDirectoryName(path) + "\\" + ctd.Name;
            if (FileExtension[0] == '.')
            {
                filename += FileExtension;
            }
            else
            {
                filename += "." + FileExtension;
            }
            if (System.IO.File.Exists(filename))
            {
                if (System.IO.File.GetAttributes(filename) != FileAttributes.Normal)
                {
                    System.IO.File.SetAttributes(filename, FileAttributes.Normal);
                }
            }
            return filename;
        }
        public string Save(string path, cfLangType clt, KeelKit.Generators.BaseGengerator.DGetFileNames getfilename)
        {

            CodeDomProvider provider = BaseGengerator.GetProvider(clt);

            string filename = getfilename != null ? getfilename(path, provider.FileExtension) : GetFileNames(path, provider.FileExtension);

            IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(filename, false, Encoding.UTF8), "    ");
            provider.GenerateCodeFromCompileUnit(ccu, tw, new CodeGeneratorOptions());
            tw.Close();
            string context = System.IO.File.ReadAllText(filename, Encoding.UTF8);
            if (!context.Contains("<auto-generated>") && ccu.Namespaces.Count > 0)
            {
                ccu.Namespaces[0].Comments.Clear();
                ccu.Namespaces[0].Comments.Add(new CodeCommentStatement(BaseGengerator.AddKeelKitInfo()));
                tw = new IndentedTextWriter(new StreamWriter(filename, false, Encoding.UTF8), "    ");
                provider.GenerateCodeFromCompileUnit(ccu, tw, new CodeGeneratorOptions());
                tw.Close();
            }
            return filename;
        }

    }
}
