namespace CodeDomAssistant
{
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public class CodeGenerator : ICodeGenerator
    {
        private Hashtable codedomVar = new Hashtable();

        public string CreateEscapedIdentifier(string value)
        {
            return null;
        }

        public string CreateValidIdentifier(string value)
        {
            return this.GetNextVar(value);
        }

        private string Escape(string value)
        {
            return value;
        }

        private string GenerateCodeAttributeArgument(string context, CodeAttributeArgument argument, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar(argument.Name + "_arg");
            string str2 = this.GenerateCodeExpression(null, argument.Value, w, o);
            w.WriteLine("CodeAttributeArgument {0} = new CodeAttributeArgument(\"{1}\", {2});", nextVar, argument.Name, str2);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeAttributeArguments(string context, CodeAttributeArgumentCollection arguments, TextWriter w, CodeGeneratorOptions o)
        {
            if (arguments.Count > 0)
            {
                foreach (CodeAttributeArgument argument in arguments)
                {
                    this.GenerateCodeAttributeArgument(context, argument, w, o);
                }
            }
        }

        private string GenerateCodeAttributeDeclaration(string context, CodeAttributeDeclaration attribute, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar(attribute.Name + "_attr");
            w.WriteLine("CodeAttributeDeclaration {0} = new CodeAttributeDeclaration(\"{1}\");", nextVar, attribute.Name);
            this.GenerateCodeAttributeArguments(string.Format("{0}.Arguments", new object[0]), attribute.Arguments, w, o);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeAttributeDeclarations(string context, CodeAttributeDeclarationCollection attributes, TextWriter w, CodeGeneratorOptions o)
        {
            if (attributes.Count > 0)
            {
                foreach (CodeAttributeDeclaration declaration in attributes)
                {
                    this.GenerateCodeAttributeDeclaration(context, declaration, w, o);
                }
            }
        }

        private string GenerateCodeCatchClause(string context, CodeCatchClause catchclause, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar(catchclause.LocalName + "_exception");
            w.WriteLine("CodeCatchClause {0} = new CodeCatchClause();", nextVar);
            if ((catchclause.LocalName != null) && (catchclause.LocalName.Length > 0))
            {
                w.WriteLine("{0}.LocalName = \"{1}\";", nextVar, catchclause.LocalName);
            }
            w.WriteLine("{0}.CatchExceptionType = {1};", nextVar, this.GenerateCodeTypeReference(null, catchclause.CatchExceptionType, w, o));
            this.GenerateCodeStatements(string.Format("{0}.Statements", nextVar), catchclause.Statements, w, o);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeCatchClauses(string context, CodeCatchClauseCollection catchclauses, TextWriter w, CodeGeneratorOptions o)
        {
            if (catchclauses.Count > 0)
            {
                foreach (CodeCatchClause clause in catchclauses)
                {
                    this.GenerateCodeCatchClause(context, clause, w, o);
                }
            }
        }

        private string GenerateCodeComment(string context, CodeComment comment, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar("comment");
            w.WriteLine("CodeComment {0} = new CodeComment();", nextVar);
            if (comment.DocComment)
            {
                w.WriteLine("{0}.DocComment = {1};", nextVar, comment.DocComment.ToString().ToLower());
            }
            if ((comment.Text != null) && (comment.Text.Length > 0))
            {
                w.WriteLine("{0}.Text = \"{1}\";", nextVar, comment.Text);
            }
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeComments(string context, CodeCommentStatementCollection comments, TextWriter w, CodeGeneratorOptions o)
        {
            if (comments.Count > 0)
            {
                foreach (CodeCommentStatement statement in comments)
                {
                    w.WriteLine("{0}.Add(new CodeCommentStatement(\"{1}\", {2}));", context, statement.Comment.Text, statement.Comment.DocComment);
                }
            }
        }

        private void GenerateCodeCompileUnit(CodeCompileUnit e, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar("compileunit");
            w.WriteLine("// CodeDom Compile Unit");
            w.WriteLine("CodeCompileUnit {0} = new CodeCompileUnit();", nextVar);
            if (e.ReferencedAssemblies.Count > 0)
            {
                if (o.BlankLinesBetweenMembers)
                {
                    w.WriteLine();
                }
                w.WriteLine("// Referenced Assemblies");
                foreach (string str2 in e.ReferencedAssemblies)
                {
                    w.WriteLine("{0}.ReferencedAssemblies.Add(\"{1}\");", nextVar, str2);
                }
            }
            this.GenerateCodeNamespaces(string.Format("{0}.Namespaces", nextVar), e.Namespaces, w, o);
        }

        private string GenerateCodeDirective(string context, CodeDirective e, TextWriter w, CodeGeneratorOptions o)
        {
            if (e == null)
            {
                return "null";
            }
            if (e is CodeChecksumPragma)
            {
                CodeChecksumPragma pragma = (CodeChecksumPragma) e;
                string str = this.GetNextVar("checksum");
                w.WriteLine("CodeChecksumPragma {0} = new CodeChecksumPragma();", str);
                w.WriteLine("{0}.ChecksumAlgorithmId = new Guid(\"{1}\");", str, pragma.ChecksumAlgorithmId.ToString("B"));
                w.WriteLine("{0}.ChecksumData = new byte[] { {1} };", str, this.GetByteData(pragma.ChecksumData));
                w.WriteLine("{0}.FileName = \"{1}\";", str, pragma.FileName);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str);
                    w.WriteLine();
                }
                return str;
            }
            if (!(e is CodeRegionDirective))
            {
                return null;
            }
            CodeRegionDirective directive = (CodeRegionDirective) e;
            string nextVar = this.GetNextVar("region");
            w.WriteLine("CodeRegionDirective {0} = new CodeRegionDirective();", nextVar);
            w.WriteLine("{0}.RegionMode = {1};", nextVar, this.GetCodeRegionMode(directive.RegionMode));
            w.WriteLine("{0}.RegionText = \"{1}\";", nextVar, directive.RegionText);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeDirectives(string context, CodeDirectiveCollection directives, TextWriter w, CodeGeneratorOptions o)
        {
            if (directives.Count > 0)
            {
                foreach (CodeDirective directive in directives)
                {
                    this.GenerateCodeDirective(context, directive, w, o);
                }
            }
        }

        private string GenerateCodeEventReferenceExpression(string context, CodeEventReferenceExpression e, TextWriter w, CodeGeneratorOptions o)
        {
            CodeEventReferenceExpression expression = e;
            string nextVar = this.GetNextVar("event");
            w.WriteLine("CodeEventReferenceExpression {0} = new CodeEventReferenceExpression();", nextVar);
            w.WriteLine("{0}.EventName = \"{1}\";", nextVar, expression.EventName);
            w.WriteLine("{0}.TargetObject = {1};", nextVar, this.GenerateCodeExpression(null, expression.TargetObject, w, o));
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private string GenerateCodeExpression(string context, CodeExpression e, TextWriter w, CodeGeneratorOptions o)
        {
            if (e == null)
            {
                return "null";
            }
            if (e is CodeArrayCreateExpression)
            {
                CodeArrayCreateExpression expression = (CodeArrayCreateExpression) e;
                string str = this.GetNextVar("arr");
                w.WriteLine("CodeArrayCreateExpression {0} = new CodeArrayCreateExpression();", str);
                if (expression.CreateType != null)
                {
                    string str2 = this.GenerateCodeTypeReference(null, expression.CreateType, w, o);
                    w.WriteLine("{0}.CreateType = {1};", str, str2);
                }
                this.GenerateCodeExpressions(string.Format("{0}.Initializers", str), expression.Initializers, w, o);
                w.WriteLine("{0}.Size = {1};", str, expression.Size);
                if (expression.SizeExpression != null)
                {
                    string str3 = this.GenerateCodeExpression(null, expression.SizeExpression, w, o);
                    w.WriteLine("{0}.SizeExpression = {1};", str, str3);
                }
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str);
                    w.WriteLine();
                }
                return str;
            }
            if (e is CodeBaseReferenceExpression)
            {
                CodeBaseReferenceExpression expression1 = (CodeBaseReferenceExpression) e;
                string str4 = this.GetNextVar("base");
                w.WriteLine("CodeBaseReferenceExpression {0} = new CodeBaseReferenceExpression();", str4);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str4);
                    w.WriteLine();
                }
                return str4;
            }
            if (e is CodeBinaryOperatorExpression)
            {
                CodeBinaryOperatorExpression expression2 = (CodeBinaryOperatorExpression) e;
                string str5 = this.GetNextVar("binop");
                w.WriteLine("CodeBinaryOperatorExpression {0} = new CodeBinaryOperatorExpression();", str5);
                w.WriteLine("{0}.Left = {1};", str5, this.GenerateCodeExpression(null, expression2.Left, w, o));
                w.WriteLine("{0}.Operator = {1};", str5, this.GetCodeBinaryOperatorType(expression2.Operator));
                w.WriteLine("{0}.Right = {1};", str5, this.GenerateCodeExpression(null, expression2.Right, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str5);
                    w.WriteLine();
                }
                return str5;
            }
            if (e is CodeCastExpression)
            {
                CodeCastExpression expression3 = (CodeCastExpression) e;
                string str6 = this.GetNextVar("cast");
                w.WriteLine("CodeCastExpression {0} = new CodeCastExpression();", str6);
                w.WriteLine("{0}.Expression = {1};", str6, this.GenerateCodeExpression(null, expression3.Expression, w, o));
                w.WriteLine("{0}.TargetType = {1};", str6, this.GenerateCodeTypeReference(null, expression3.TargetType, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str6);
                    w.WriteLine();
                }
                return str6;
            }
            if (e is CodeDelegateCreateExpression)
            {
                CodeDelegateCreateExpression expression4 = (CodeDelegateCreateExpression) e;
                string str7 = this.GetNextVar("delegate");
                w.WriteLine("CodeDelegateCreateExpression {0} = new CodeDelegateCreateExpression();", str7);
                w.WriteLine("{0}.DelegateType = {1};", str7, this.GenerateCodeTypeReference(null, expression4.DelegateType, w, o));
                w.WriteLine("{0}.MethodName = \"{1}\";", str7, expression4.MethodName);
                w.WriteLine("{0}.TargetObject = {1};", str7, this.GenerateCodeExpression(null, expression4.TargetObject, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str7);
                    w.WriteLine();
                }
                return str7;
            }
            if (e is CodeFieldReferenceExpression)
            {
                CodeFieldReferenceExpression expression5 = (CodeFieldReferenceExpression) e;
                string str8 = this.GetNextVar("field");
                w.WriteLine("CodeFieldReferenceExpression {0} = new CodeFieldReferenceExpression();", str8);
                w.WriteLine("{0}.FieldName = \"{1}\";", str8, expression5.FieldName);
                w.WriteLine("{0}.TargetObject = {1};", str8, this.GenerateCodeExpression(null, expression5.TargetObject, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str8);
                    w.WriteLine();
                }
                return str8;
            }
            if (e is CodeArgumentReferenceExpression)
            {
                CodeArgumentReferenceExpression expression6 = (CodeArgumentReferenceExpression) e;
                string str9 = this.GetNextVar("arg");
                w.WriteLine("CodeArgumentReferenceExpression {0} = new CodeArgumentReferenceExpression();", str9);
                w.WriteLine("{0}.ParameterName = \"{1}\";", str9, expression6.ParameterName);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str9);
                    w.WriteLine();
                }
                return str9;
            }
            if (e is CodeVariableReferenceExpression)
            {
                CodeVariableReferenceExpression expression7 = (CodeVariableReferenceExpression) e;
                string str10 = this.GetNextVar("arg");
                w.WriteLine("CodeVariableReferenceExpression {0} = new CodeVariableReferenceExpression();", str10);
                w.WriteLine("{0}.VariableName = \"{1}\";", str10, expression7.VariableName);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str10);
                    w.WriteLine();
                }
                return str10;
            }
            if (e is CodeIndexerExpression)
            {
                CodeIndexerExpression expression8 = (CodeIndexerExpression) e;
                string str11 = this.GetNextVar("index");
                w.WriteLine("CodeIndexerExpression {0} = new CodeIndexerExpression();", str11);
                this.GenerateCodeExpressions(string.Format("{0}.Indices", str11), expression8.Indices, w, o);
                w.WriteLine("{0}.TargetObject = {1};", str11, this.GenerateCodeExpression(null, expression8.TargetObject, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str11);
                    w.WriteLine();
                }
                return str11;
            }
            if (e is CodeArrayIndexerExpression)
            {
                CodeArrayIndexerExpression expression9 = (CodeArrayIndexerExpression) e;
                string str12 = this.GetNextVar("arrindex");
                w.WriteLine("CodeArrayIndexerExpression {0} = new CodeArrayIndexerExpression();", str12);
                this.GenerateCodeExpressions(string.Format("{0}.Indices", str12), expression9.Indices, w, o);
                w.WriteLine("{0}.TargetObject = {1};", str12, this.GenerateCodeExpression(null, expression9.TargetObject, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str12);
                    w.WriteLine();
                }
                return str12;
            }
            if (e is CodeSnippetExpression)
            {
                CodeSnippetExpression expression10 = (CodeSnippetExpression) e;
                string str13 = this.GetNextVar("snippet");
                w.WriteLine("CodeSnippetExpression {0} = new CodeSnippetExpression();", str13);
                w.WriteLine("{0}.Value = \"{1}\";", str13, this.Escape(expression10.Value));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str13);
                    w.WriteLine();
                }
                return str13;
            }
            if (e is CodeMethodInvokeExpression)
            {
                CodeMethodInvokeExpression expression11 = (CodeMethodInvokeExpression) e;
                string str14 = this.GetNextVar("invoke");
                w.WriteLine("CodeMethodInvokeExpression {0} = new CodeMethodInvokeExpression();", str14);
                this.GenerateCodeExpressions(string.Format("{0}.Parameters", str14), expression11.Parameters, w, o);
                w.WriteLine("{0}.Method = {1};", str14, this.GenerateCodeMethodReferenceExpression(null, expression11.Method, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str14);
                    w.WriteLine();
                }
                return str14;
            }
            if (e is CodeMethodReferenceExpression)
            {
                CodeMethodReferenceExpression expression12 = (CodeMethodReferenceExpression) e;
                string str15 = this.GetNextVar("method");
                w.WriteLine("CodeMethodReferenceExpression {0} = new CodeMethodReferenceExpression();", str15);
                w.WriteLine("{0}.MethodName = \"{1}\";", str15, expression12.MethodName);
                w.WriteLine("{0}.TargetObject = {1};", str15, this.GenerateCodeExpression(null, expression12.TargetObject, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str15);
                    w.WriteLine();
                }
                return str15;
            }
            if (e is CodeEventReferenceExpression)
            {
                return this.GenerateCodeEventReferenceExpression(context, (CodeEventReferenceExpression) e, w, o);
            }
            if (e is CodeDelegateInvokeExpression)
            {
                CodeDelegateInvokeExpression expression13 = (CodeDelegateInvokeExpression) e;
                string str16 = this.GetNextVar("invokedelegate");
                w.WriteLine("CodeDelegateInvokeExpression {0} = new CodeDelegateInvokeExpression();", str16);
                this.GenerateCodeExpressions(string.Format("{0}.Parameters", str16), expression13.Parameters, w, o);
                w.WriteLine("{0}.TargetObject = {1};", str16, this.GenerateCodeExpression(null, expression13.TargetObject, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str16);
                    w.WriteLine();
                }
                return str16;
            }
            if (e is CodeObjectCreateExpression)
            {
                CodeObjectCreateExpression expression14 = (CodeObjectCreateExpression) e;
                string str17 = this.GetNextVar("new");
                w.WriteLine("CodeObjectCreateExpression {0} = new CodeObjectCreateExpression();", str17);
                w.WriteLine("{0}.CreateType = {1};", str17, this.GenerateCodeTypeReference(null, expression14.CreateType, w, o));
                this.GenerateCodeExpressions(string.Format("{0}.Parameters", str17), expression14.Parameters, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str17);
                    w.WriteLine();
                }
                return str17;
            }
            if (e is CodeParameterDeclarationExpression)
            {
                return this.GenerateCodeParameterDeclarationExpression(context, (CodeParameterDeclarationExpression) e, w, o);
            }
            if (e is CodeDirectionExpression)
            {
                CodeDirectionExpression expression15 = (CodeDirectionExpression) e;
                string str18 = this.GetNextVar("dir");
                w.WriteLine("CodeDirectionExpression {0} = new CodeDirectionExpression();", str18);
                w.WriteLine("{0}.Direction = {1};", str18, this.GetFieldDirection(expression15.Direction));
                w.WriteLine("{0}.Expression = {1};", str18, this.GenerateCodeExpression(null, expression15.Expression, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str18);
                    w.WriteLine();
                }
                return str18;
            }
            if (e is CodePrimitiveExpression)
            {
                CodePrimitiveExpression expression16 = (CodePrimitiveExpression) e;
                string str19 = this.GetNextVar("value");
                w.WriteLine("CodePrimitiveExpression {0} = new CodePrimitiveExpression();", str19);
                if (expression16.Value == null)
                {
                    w.WriteLine("{0}.Value = null;", str19);
                }
                else if (expression16.Value.GetType() == typeof(char))
                {
                    w.WriteLine("{0}.Value = '{1}';", str19, expression16.Value.ToString());
                }
                else if (expression16.Value.GetType() == typeof(string))
                {
                    w.WriteLine("{0}.Value = \"{1}\";", str19, expression16.Value.ToString());
                }
                else if (expression16.Value.GetType() == typeof(bool))
                {
                    w.WriteLine("{0}.Value = {1};", str19, expression16.Value.ToString().ToLower());
                }
                else
                {
                    w.WriteLine("{0}.Value = {1};", str19, expression16.Value.ToString());
                }
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str19);
                    w.WriteLine();
                }
                return str19;
            }
            if (e is CodePropertyReferenceExpression)
            {
                CodePropertyReferenceExpression expression17 = (CodePropertyReferenceExpression) e;
                string str20 = this.GetNextVar("prop");
                w.WriteLine("CodePropertyReferenceExpression {0} = new CodePropertyReferenceExpression();", str20);
                w.WriteLine("{0}.PropertyName = \"{1}\";", str20, expression17.PropertyName);
                w.WriteLine("{0}.TargetObject = {1};", str20, this.GenerateCodeExpression(null, expression17.TargetObject, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str20);
                    w.WriteLine();
                }
                return str20;
            }
            if (e is CodePropertySetValueReferenceExpression)
            {
                CodePropertySetValueReferenceExpression expression20 = (CodePropertySetValueReferenceExpression) e;
                string str21 = this.GetNextVar("setprop");
                w.WriteLine("CodePropertySetValueReferenceExpression {0} = new CodePropertySetValueReferenceExpression();", str21);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str21);
                    w.WriteLine();
                }
                return str21;
            }
            if (e is CodeThisReferenceExpression)
            {
                CodeThisReferenceExpression expression21 = (CodeThisReferenceExpression) e;
                string str22 = this.GetNextVar("this");
                w.WriteLine("CodeThisReferenceExpression {0} = new CodeThisReferenceExpression();", str22);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str22);
                    w.WriteLine();
                }
                return str22;
            }
            if (e is CodeTypeReferenceExpression)
            {
                CodeTypeReferenceExpression expression18 = (CodeTypeReferenceExpression) e;
                string str23 = this.GetNextVar("ref");
                w.WriteLine("CodeTypeReferenceExpression {0} = new CodeTypeReferenceExpression();", str23);
                w.WriteLine("{0}.Type = {1};", str23, this.GenerateCodeTypeReference(null, expression18.Type, w, o));
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str23);
                    w.WriteLine();
                }
                return str23;
            }
            if (!(e is CodeTypeOfExpression))
            {
                return null;
            }
            CodeTypeOfExpression expression19 = (CodeTypeOfExpression) e;
            string nextVar = this.GetNextVar("typeof");
            w.WriteLine("CodeTypeOfExpression {0} = new CodeTypeOfExpression();", nextVar);
            w.WriteLine("{0}.Type = {1};", nextVar, this.GenerateCodeTypeReference(null, expression19.Type, w, o));
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeExpressions(string context, CodeExpressionCollection exprs, TextWriter w, CodeGeneratorOptions o)
        {
            if (exprs.Count > 0)
            {
                foreach (CodeExpression expression in exprs)
                {
                    this.GenerateCodeExpression(context, expression, w, o);
                }
            }
        }

        public void GenerateCodeFromCompileUnit(CodeCompileUnit e, TextWriter w, CodeGeneratorOptions o)
        {
            this.GenerateCodeCompileUnit(e, w, o);
        }

        public void GenerateCodeFromExpression(CodeExpression e, TextWriter w, CodeGeneratorOptions o)
        {
            this.GenerateCodeExpression(null, e, w, o);
        }

        public void GenerateCodeFromNamespace(CodeNamespace e, TextWriter w, CodeGeneratorOptions o)
        {
            this.GenerateCodeNamespace(null, e, w, o);
        }

        public void GenerateCodeFromStatement(CodeStatement e, TextWriter w, CodeGeneratorOptions o)
        {
            this.GenerateCodeStatement(null, e, w, o);
        }

        public void GenerateCodeFromType(CodeTypeDeclaration e, TextWriter w, CodeGeneratorOptions o)
        {
            this.GenerateCodeTypeDeclaration(null, e, w, o);
        }

        private string GenerateCodeMethodReferenceExpression(string context, CodeMethodReferenceExpression methodref, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar(methodref.MethodName + "_method");
            w.WriteLine("CodeMethodReferenceExpression {0} = new CodeMethodReferenceExpression();", nextVar);
            w.WriteLine("{0}.MethodName = \"{1}\";", nextVar, methodref.MethodName);
            w.WriteLine("{0}.TargetObject = {1};", nextVar, this.GenerateCodeExpression(null, methodref.TargetObject, w, o));
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private string GenerateCodeNamespace(string context, CodeNamespace ns, TextWriter w, CodeGeneratorOptions o)
        {
            if (o.BlankLinesBetweenMembers)
            {
                w.WriteLine();
            }
            w.WriteLine("//");
            w.WriteLine("// Namespace {0}", ns.Name);
            w.WriteLine("//");
            string nextVar = this.GetNextVar(ns.Name + "_namespace");
            w.WriteLine("CodeNamespace {0} = new CodeNamespace(\"{1}\");", nextVar, ns.Name);
            this.GenerateCodeComments(string.Format("{0}.Comments", nextVar), ns.Comments, w, o);
            this.GenerateCodeNamespaceImports(string.Format("{0}.Imports", nextVar), ns.Imports, w, o);
            this.GenerateCodeTypeDeclarations(string.Format("{0}.Types", nextVar), ns.Types, w, o);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeNamespaceImports(string context, CodeNamespaceImportCollection imports, TextWriter w, CodeGeneratorOptions o)
        {
            if (imports.Count > 0)
            {
                if (o.BlankLinesBetweenMembers)
                {
                    w.WriteLine();
                }
                w.WriteLine("// Imports");
                foreach (CodeNamespaceImport import in imports)
                {
                    w.WriteLine("{0}.Add(new CodeNamespaceImport(\"{1}\"));", context, import.Namespace);
                }
            }
        }

        private void GenerateCodeNamespaces(string context, CodeNamespaceCollection namespaces, TextWriter w, CodeGeneratorOptions o)
        {
            if (namespaces.Count > 0)
            {
                if (o.BlankLinesBetweenMembers)
                {
                    w.WriteLine();
                }
                foreach (CodeNamespace namespace2 in namespaces)
                {
                    this.GenerateCodeNamespace(context, namespace2, w, o);
                }
            }
        }

        private string GenerateCodeParameterDeclarationExpression(string context, CodeParameterDeclarationExpression arg, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar(arg.Name + "_arg");
            w.WriteLine("CodeParameterDeclarationExpression {0} = new CodeParameterDeclarationExpression({1}, \"{2}\");", nextVar, this.GenerateCodeTypeReference(null, arg.Type, w, o), arg.Name);
            this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", nextVar), arg.CustomAttributes, w, o);
            w.WriteLine("{0}.Direction = {1};", nextVar, this.GetFieldDirection(arg.Direction));
            w.WriteLine("{0}.Name = \"{1}\";", nextVar, arg.Name);
            w.WriteLine("{0}.Type = {1};", nextVar, this.GenerateCodeTypeReference(null, arg.Type, w, o));
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeParameterDeclarationExpressions(string context, CodeParameterDeclarationExpressionCollection args, TextWriter w, CodeGeneratorOptions o)
        {
            if (args.Count > 0)
            {
                foreach (CodeParameterDeclarationExpression expression in args)
                {
                    this.GenerateCodeParameterDeclarationExpression(context, expression, w, o);
                }
            }
        }

        private string GenerateCodeStatement(string context, CodeStatement e, TextWriter w, CodeGeneratorOptions o)
        {
            if (e == null)
            {
                return "null";
            }
            if (e is CodeMethodReturnStatement)
            {
                CodeMethodReturnStatement statement = (CodeMethodReturnStatement) e;
                string str = this.GetNextVar("return");
                w.WriteLine("CodeMethodReturnStatement {0} = new CodeMethodReturnStatement();", str);
                if (statement.Expression != null)
                {
                    w.WriteLine("{0}.Expression = {1};", str, this.GenerateCodeExpression(null, statement.Expression, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str), statement.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str), statement.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str);
                    w.WriteLine();
                }
                return str;
            }
            if (e is CodeCommentStatement)
            {
                CodeCommentStatement statement2 = (CodeCommentStatement) e;
                string str2 = this.GetNextVar("comment");
                w.WriteLine("CodeCommentStatement {0} = new CodeCommentStatement();", str2);
                w.WriteLine("{0}.Comment = {1};", str2, this.GenerateCodeComment(null, statement2.Comment, w, o));
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str2), statement2.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str2), statement2.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str2);
                    w.WriteLine();
                }
                return str2;
            }
            if (e is CodeMethodReturnStatement)
            {
                CodeMethodReturnStatement statement3 = (CodeMethodReturnStatement) e;
                string str3 = this.GetNextVar("return");
                w.WriteLine("CodeMethodReturnStatement {0} = new CodeMethodReturnStatement();", str3);
                if (statement3.Expression != null)
                {
                    w.WriteLine("{0}.Expression = {1};", str3, this.GenerateCodeExpression(null, statement3.Expression, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str3), statement3.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str3), statement3.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str3);
                    w.WriteLine();
                }
                return str3;
            }
            if (e is CodeConditionStatement)
            {
                CodeConditionStatement statement4 = (CodeConditionStatement) e;
                string str4 = this.GetNextVar("if");
                w.WriteLine("CodeConditionStatement {0} = new CodeConditionStatement();", str4);
                w.WriteLine("{0}.Condition = {1};", str4, this.GenerateCodeExpression(null, statement4.Condition, w, o));
                this.GenerateCodeStatements(string.Format("{0}.TrueStatements", str4), statement4.TrueStatements, w, o);
                this.GenerateCodeStatements(string.Format("{0}.FalseStatements", str4), statement4.FalseStatements, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str4), statement4.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str4), statement4.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str4);
                    w.WriteLine();
                }
                return str4;
            }
            if (e is CodeTryCatchFinallyStatement)
            {
                CodeTryCatchFinallyStatement statement5 = (CodeTryCatchFinallyStatement) e;
                string str5 = this.GetNextVar("try");
                w.WriteLine("CodeTryCatchFinallyStatement {0} = new CodeTryCatchFinallyStatement();", str5);
                this.GenerateCodeStatements(string.Format("{0}.TryStatements", str5), statement5.TryStatements, w, o);
                this.GenerateCodeCatchClauses(string.Format("{0}.CatchClauses", str5), statement5.CatchClauses, w, o);
                this.GenerateCodeStatements(string.Format("{0}.FinallyStatements", str5), statement5.FinallyStatements, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str5), statement5.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str5), statement5.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str5);
                    w.WriteLine();
                }
                return str5;
            }
            if (e is CodeAssignStatement)
            {
                CodeAssignStatement statement6 = (CodeAssignStatement) e;
                string str6 = this.GetNextVar("assign");
                w.WriteLine("CodeAssignStatement {0} = new CodeAssignStatement();", str6);
                if (statement6.Left != null)
                {
                    w.WriteLine("{0}.Left = {1};", str6, this.GenerateCodeExpression(null, statement6.Left, w, o));
                }
                if (statement6.Right != null)
                {
                    w.WriteLine("{0}.Right = {1};", str6, this.GenerateCodeExpression(null, statement6.Right, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str6), statement6.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str6), statement6.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str6);
                    w.WriteLine();
                }
                return str6;
            }
            if (e is CodeExpressionStatement)
            {
                CodeExpressionStatement statement7 = (CodeExpressionStatement) e;
                string str7 = this.GetNextVar("expr");
                w.WriteLine("CodeExpressionStatement {0} = new CodeExpressionStatement();", str7);
                if (statement7.Expression != null)
                {
                    w.WriteLine("{0}.Expression = {1};", str7, this.GenerateCodeExpression(null, statement7.Expression, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str7), statement7.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str7), statement7.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str7);
                    w.WriteLine();
                }
                return str7;
            }
            if (e is CodeIterationStatement)
            {
                CodeIterationStatement statement8 = (CodeIterationStatement) e;
                string str8 = this.GetNextVar("for");
                w.WriteLine("CodeIterationStatement {0} = new CodeIterationStatement();", str8);
                if (statement8.InitStatement != null)
                {
                    w.WriteLine("{0}.InitStatement = {1};", str8, this.GenerateCodeStatement(null, statement8.InitStatement, w, o));
                }
                if (statement8.TestExpression != null)
                {
                    w.WriteLine("{0}.TestExpression = {1};", str8, this.GenerateCodeExpression(null, statement8.TestExpression, w, o));
                }
                if (statement8.IncrementStatement != null)
                {
                    w.WriteLine("{0}.IncrementStatement = {1};", str8, this.GenerateCodeStatement(null, statement8.IncrementStatement, w, o));
                }
                this.GenerateCodeStatements(string.Format("{0}.Statements", str8), statement8.Statements, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str8), statement8.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str8), statement8.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str8);
                    w.WriteLine();
                }
                return str8;
            }
            if (e is CodeThrowExceptionStatement)
            {
                CodeThrowExceptionStatement statement9 = (CodeThrowExceptionStatement) e;
                string str9 = this.GetNextVar("throw");
                w.WriteLine("CodeThrowExceptionStatement {0} = new CodeThrowExceptionStatement();", str9);
                if (statement9.ToThrow != null)
                {
                    w.WriteLine("{0}.ToThrow = {1};", str9, this.GenerateCodeExpression(null, statement9.ToThrow, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str9), statement9.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str9), statement9.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str9);
                    w.WriteLine();
                }
                return str9;
            }
            if (e is CodeSnippetStatement)
            {
                CodeSnippetStatement statement10 = (CodeSnippetStatement) e;
                string str10 = this.GetNextVar("snippet");
                w.WriteLine("CodeSnippetStatement {0} = new CodeSnippetStatement();", str10);
                if (statement10.Value != null)
                {
                    w.WriteLine("{0}.Value = \"{1}\";", str10, statement10.Value);
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str10), statement10.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str10), statement10.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str10);
                    w.WriteLine();
                }
                return str10;
            }
            if (e is CodeVariableDeclarationStatement)
            {
                CodeVariableDeclarationStatement statement11 = (CodeVariableDeclarationStatement) e;
                string str11 = this.GetNextVar("decl");
                w.WriteLine("CodeVariableDeclarationStatement {0} = new CodeVariableDeclarationStatement();", str11);
                if (statement11.InitExpression != null)
                {
                    w.WriteLine("{0}.InitExpression = {1};", str11, this.GenerateCodeExpression(null, statement11.InitExpression, w, o));
                }
                w.WriteLine("{0}.Name = \"{1}\";", str11, statement11.Name);
                if (statement11.Type != null)
                {
                    w.WriteLine("{0}.Type = {1};", str11, this.GenerateCodeTypeReference(null, statement11.Type, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str11), statement11.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str11), statement11.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str11);
                    w.WriteLine();
                }
                return str11;
            }
            if (e is CodeAttachEventStatement)
            {
                CodeAttachEventStatement statement12 = (CodeAttachEventStatement) e;
                string str12 = this.GetNextVar("addevent");
                w.WriteLine("CodeAttachEventStatement {0} = new CodeAttachEventStatement();", str12);
                if (statement12.Event != null)
                {
                    w.WriteLine("{0}.Event = {1};", str12, this.GenerateCodeEventReferenceExpression(null, statement12.Event, w, o));
                }
                if (statement12.Listener != null)
                {
                    w.WriteLine("{0}.Listener = {1};", str12, this.GenerateCodeExpression(null, statement12.Listener, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str12), statement12.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str12), statement12.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str12);
                    w.WriteLine();
                }
                return str12;
            }
            if (e is CodeRemoveEventStatement)
            {
                CodeRemoveEventStatement statement13 = (CodeRemoveEventStatement) e;
                string str13 = this.GetNextVar("removeevent");
                w.WriteLine("CodeRemoveEventStatement {0} = new CodeRemoveEventStatement();", str13);
                if (statement13.Event != null)
                {
                    w.WriteLine("{0}.Event = {1};", str13, this.GenerateCodeEventReferenceExpression(null, statement13.Event, w, o));
                }
                if (statement13.Listener != null)
                {
                    w.WriteLine("{0}.Listener = {1};", str13, this.GenerateCodeExpression(null, statement13.Listener, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str13), statement13.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str13), statement13.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str13);
                    w.WriteLine();
                }
                return str13;
            }
            if (e is CodeGotoStatement)
            {
                CodeGotoStatement statement14 = (CodeGotoStatement) e;
                string str14 = this.GetNextVar("goto");
                w.WriteLine("CodeGotoStatement {0} = new CodeGotoStatement();", str14);
                if (statement14.Label != null)
                {
                    w.WriteLine("{0}.Label = \"{1}\";", str14, statement14.Label);
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str14), statement14.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str14), statement14.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str14);
                    w.WriteLine();
                }
                return str14;
            }
            if (!(e is CodeLabeledStatement))
            {
                return null;
            }
            CodeLabeledStatement statement15 = (CodeLabeledStatement) e;
            string nextVar = this.GetNextVar("label");
            w.WriteLine("CodeLabeledStatement {0} = new CodeLabeledStatement();", nextVar);
            if (statement15.Label != null)
            {
                w.WriteLine("{0}.Label = \"{1}\";", nextVar, statement15.Label);
            }
            if (statement15.Statement != null)
            {
                w.WriteLine("{0}.Statement = {1};", nextVar, this.GenerateCodeStatement(null, statement15.Statement, w, o));
            }
            this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", nextVar), statement15.StartDirectives, w, o);
            this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", nextVar), statement15.EndDirectives, w, o);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeStatements(string context, CodeStatementCollection stmts, TextWriter w, CodeGeneratorOptions o)
        {
            if (stmts.Count > 0)
            {
                foreach (CodeStatement statement in stmts)
                {
                    this.GenerateCodeStatement(context, statement, w, o);
                }
            }
        }

        private string GenerateCodeTypeDeclaration(string context, CodeTypeDeclaration decl, TextWriter w, CodeGeneratorOptions o)
        {
            if (o.BlankLinesBetweenMembers)
            {
                w.WriteLine();
            }
            w.WriteLine("//");
            string str = string.Empty;
            if (decl.IsClass)
            {
                str = "class";
            }
            else if (decl.IsEnum)
            {
                str = "enum";
            }
            else if (decl.IsInterface)
            {
                str = "interface";
            }
            else if (decl.IsStruct)
            {
                str = "struct";
            }
            w.WriteLine("//");
            w.WriteLine("// {0} {1}", str, decl.Name);
            w.WriteLine("//");
            string nextVar = this.GetNextVar(decl.Name + "_" + str);
            w.WriteLine("CodeTypeDeclaration {0} = new CodeTypeDeclaration(\"{1}\");", nextVar, decl.Name);
            w.WriteLine("{0}.Attributes = {1};", nextVar, this.GetMemberAttributes(decl.Attributes));
            if (decl.IsClass)
            {
                w.WriteLine("{0}.IsClass = true;", nextVar);
            }
            else if (decl.IsEnum)
            {
                w.WriteLine("{0}.IsEnum = true;", nextVar);
            }
            else if (decl.IsInterface)
            {
                w.WriteLine("{0}.IsInterface = true;", nextVar);
            }
            else if (decl.IsStruct)
            {
                w.WriteLine("{0}.IsStruct = true;", nextVar);
            }
            this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", nextVar), decl.CustomAttributes, w, o);
            this.GenerateCodeTypeReferences(string.Format("{0}.BaseTypes", nextVar), decl.BaseTypes, w, o);
            this.GenerateCodeComments(string.Format("{0}.Comments", nextVar), decl.Comments, w, o);
            this.GenerateCodeTypeMembers(string.Format("{0}.Members", nextVar), decl.Members, w, o);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeTypeDeclarations(string context, CodeTypeDeclarationCollection types, TextWriter w, CodeGeneratorOptions o)
        {
            if (types.Count > 0)
            {
                foreach (CodeTypeDeclaration declaration in types)
                {
                    this.GenerateCodeTypeDeclaration(context, declaration, w, o);
                }
            }
        }

        private string GenerateCodeTypeMember(string context, CodeTypeMember m, TextWriter w, CodeGeneratorOptions o)
        {
            if (o.BlankLinesBetweenMembers)
            {
                w.WriteLine();
            }
            if (m is CodeConstructor)
            {
                CodeConstructor constructor = (CodeConstructor) m;
                string str = this.GetNextVar(constructor.Name + "_ctor");
                string str2 = string.Empty;
                foreach (CodeParameterDeclarationExpression expression in constructor.Parameters)
                {
                    if (str2.Length > 0)
                    {
                        str2 = str2 + ", ";
                    }
                    str2 = str2 + expression.Type.BaseType + " " + expression.Name;
                }
                w.WriteLine("//");
                w.WriteLine("// Constructor({0})", str2);
                w.WriteLine("//");
                w.WriteLine("CodeConstructor {0} = new CodeConstructor();", str);
                w.WriteLine("{0}.Attributes = {1};", str, this.GetMemberAttributes(constructor.Attributes));
                this.GenerateCodeExpressions(string.Format("{0}.BaseConstructorArgs", str), constructor.BaseConstructorArgs, w, o);
                this.GenerateCodeExpressions(string.Format("{0}.ChainedConstructorArgs", str), constructor.ChainedConstructorArgs, w, o);
                this.GenerateCodeComments(string.Format("{0}.Comments", str), constructor.Comments, w, o);
                this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", str), constructor.CustomAttributes, w, o);
                this.GenerateCodeTypeReferences(string.Format("{0}.ImplementationTypes", str), constructor.ImplementationTypes, w, o);
                this.GenerateCodeParameterDeclarationExpressions(string.Format("{0}.Parameters", str), constructor.Parameters, w, o);
                if (constructor.PrivateImplementationType != null)
                {
                    w.WriteLine("{0}.PrivateImplementationType = {1};", str, this.GenerateCodeTypeReference(null, constructor.PrivateImplementationType, w, o));
                }
                if ((constructor.ReturnType != null) && (constructor.ReturnType.BaseType != "System.Void"))
                {
                    string str3 = this.GenerateCodeTypeReference(null, constructor.ReturnType, w, o);
                    w.WriteLine("{0}.ReturnType = {1};", str, str3);
                }
                this.GenerateCodeAttributeDeclarations(string.Format("{0}.ReturnTypeCustomAttributes", str), constructor.ReturnTypeCustomAttributes, w, o);
                this.GenerateCodeStatements(string.Format("{0}.Statements", str), constructor.Statements, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str), constructor.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str), constructor.EndDirectives, w, o);
                this.GenerateCodeTypeParameters(string.Format("{0}.TypeParameters", str), constructor.TypeParameters, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str);
                    w.WriteLine();
                }
                return str;
            }
            if (m is CodeMemberField)
            {
                CodeMemberField field = (CodeMemberField) m;
                string str4 = this.GetNextVar(field.Name + "_field");
                w.WriteLine("//");
                w.WriteLine("// Field {0}", field.Name);
                w.WriteLine("//");
                w.WriteLine("CodeMemberField {0} = new CodeMemberField();", str4);
                w.WriteLine("{0}.Attributes = {1};", str4, this.GetMemberAttributes(field.Attributes));
                this.GenerateCodeComments(string.Format("{0}.Comments", str4), field.Comments, w, o);
                this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", str4), field.CustomAttributes, w, o);
                if (field.InitExpression != null)
                {
                    string str5 = this.GenerateCodeExpression(null, field.InitExpression, w, o);
                    w.WriteLine("{0}.InitExpression = {1};", str4, str5);
                }
                w.WriteLine("{0}.Name = \"{1}\";", str4, field.Name);
                if (field.Type != null)
                {
                    string str6 = this.GenerateCodeTypeReference(null, field.Type, w, o);
                    w.WriteLine("{0}.Type = {1};", str4, str6);
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str4), field.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str4), field.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str4);
                    w.WriteLine();
                }
                return str4;
            }
            if (m is CodeMemberEvent)
            {
                CodeMemberEvent event2 = (CodeMemberEvent) m;
                string str7 = this.GetNextVar(event2.Name + "_event");
                w.WriteLine("//");
                w.WriteLine("// Event {0}", event2.Name);
                w.WriteLine("//");
                w.WriteLine("CodeMemberEvent {0} = new CodeMemberEvent();", str7);
                w.WriteLine("{0}.Attributes = {1};", str7, this.GetMemberAttributes(event2.Attributes));
                this.GenerateCodeComments(string.Format("{0}.Comments", str7), event2.Comments, w, o);
                this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", str7), event2.CustomAttributes, w, o);
                w.WriteLine("{0}.Name = \"{1}\";", str7, event2.Name);
                if (event2.Type != null)
                {
                    w.WriteLine("{0}.Type = {1};", str7, this.GenerateCodeTypeReference(null, event2.Type, w, o));
                }
                this.GenerateCodeTypeReferences(string.Format("{0}.ImplementationTypes", str7), event2.ImplementationTypes, w, o);
                if (event2.PrivateImplementationType != null)
                {
                    w.WriteLine("{0}.PrivateImplementationType = {1};", str7, this.GenerateCodeTypeReference(null, event2.PrivateImplementationType, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str7), event2.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str7), event2.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str7);
                    w.WriteLine();
                }
                return str7;
            }
            if (m is CodeMemberProperty)
            {
                CodeMemberProperty property = (CodeMemberProperty) m;
                string str8 = this.GetNextVar(property.Name + "_property");
                string str9 = string.Empty;
                foreach (CodeParameterDeclarationExpression expression2 in property.Parameters)
                {
                    if (str9.Length > 0)
                    {
                        str9 = str9 + ", ";
                    }
                    str9 = str9 + expression2.Type.BaseType + " " + expression2.Name;
                }
                w.WriteLine("//");
                if (str9.Length == 0)
                {
                    w.WriteLine("// Property {0}", property.Name);
                }
                else
                {
                    w.WriteLine("// Property {0}[{1}]", property.Name, str9);
                }
                w.WriteLine("//");
                w.WriteLine("CodeMemberProperty {0} = new CodeMemberProperty();", str8);
                w.WriteLine("{0}.Attributes = {1};", str8, this.GetMemberAttributes(property.Attributes));
                this.GenerateCodeComments(string.Format("{0}.Comments", str8), property.Comments, w, o);
                this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", str8), property.CustomAttributes, w, o);
                w.WriteLine("{0}.Name = \"{1}\";", str8, property.Name);
                w.WriteLine("{0}.Type = {1};", str8, this.GenerateCodeTypeReference(null, property.Type, w, o));
                this.GenerateCodeParameterDeclarationExpressions(string.Format("{0}.Parameters", str8), property.Parameters, w, o);
                w.WriteLine("{0}.HasGet = {1};", str8, property.HasGet.ToString().ToLower());
                if (property.HasGet)
                {
                    this.GenerateCodeStatements(string.Format("{0}.GetStatements", str8), property.GetStatements, w, o);
                }
                w.WriteLine("{0}.HasSet = {1};", str8, property.HasSet.ToString().ToLower());
                if (property.HasSet)
                {
                    this.GenerateCodeStatements(string.Format("{0}.SetStatements", str8), property.SetStatements, w, o);
                }
                this.GenerateCodeTypeReferences(string.Format("{0}.ImplementationTypes", str8), property.ImplementationTypes, w, o);
                if (property.PrivateImplementationType != null)
                {
                    w.WriteLine("{0}.PrivateImplementationType = {1};", str8, this.GenerateCodeTypeReference(null, property.PrivateImplementationType, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str8), property.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str8), property.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str8);
                    w.WriteLine();
                }
                return str8;
            }
            if (m is CodeMemberMethod)
            {
                CodeMemberMethod method = (CodeMemberMethod) m;
                string str10 = this.GetNextVar(method.Name + "_method");
                string str11 = string.Empty;
                foreach (CodeParameterDeclarationExpression expression3 in method.Parameters)
                {
                    if (str11.Length > 0)
                    {
                        str11 = str11 + ", ";
                    }
                    str11 = str11 + expression3.Type.BaseType + " " + expression3.Name;
                }
                w.WriteLine("//");
                w.WriteLine("// Function {0}({1})", method.Name, str11);
                w.WriteLine("//");
                w.WriteLine("CodeMemberMethod {0} = new CodeMemberMethod();", str10);
                w.WriteLine("{0}.Attributes = {1};", str10, this.GetMemberAttributes(method.Attributes));
                this.GenerateCodeComments(string.Format("{0}.Comments", str10), method.Comments, w, o);
                this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", str10), method.CustomAttributes, w, o);
                w.WriteLine("{0}.Name = \"{1}\";", str10, method.Name);
                this.GenerateCodeParameterDeclarationExpressions(string.Format("{0}.Parameters", str10), method.Parameters, w, o);
                if ((method.ReturnType != null) && (method.ReturnType.BaseType != "System.Void"))
                {
                    string str12 = this.GenerateCodeTypeReference(null, method.ReturnType, w, o);
                    w.WriteLine("{0}.ReturnType = {1};", str10, str12);
                }
                this.GenerateCodeTypeParameters(string.Format("{0}.TypeParameters", str10), method.TypeParameters, w, o);
                this.GenerateCodeAttributeDeclarations(string.Format("{0}.ReturnTypeCustomAttributes", str10), method.ReturnTypeCustomAttributes, w, o);
                this.GenerateCodeStatements(string.Format("{0}.Statements", str10), method.Statements, w, o);
                this.GenerateCodeTypeReferences(string.Format("{0}.ImplementationTypes", str10), method.ImplementationTypes, w, o);
                if (method.PrivateImplementationType != null)
                {
                    w.WriteLine("{0}.PrivateImplementationType = {1};", str10, this.GenerateCodeTypeReference(null, method.PrivateImplementationType, w, o));
                }
                this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", str10), method.StartDirectives, w, o);
                this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", str10), method.EndDirectives, w, o);
                if ((context != null) && (context.Length > 0))
                {
                    w.WriteLine("{0}.Add({1});", context, str10);
                    w.WriteLine();
                }
                return str10;
            }
            if (!(m is CodeTypeDelegate))
            {
                return null;
            }
            CodeTypeDelegate delegate2 = (CodeTypeDelegate) m;
            string nextVar = this.GetNextVar(delegate2.Name + "_delegate");
            string str14 = string.Empty;
            foreach (CodeParameterDeclarationExpression expression4 in delegate2.Parameters)
            {
                if (str14.Length > 0)
                {
                    str14 = str14 + ", ";
                }
                str14 = str14 + expression4.Type.BaseType + " " + expression4.Name;
            }
            w.WriteLine("//");
            w.WriteLine("// Delegate {0}({1})", delegate2.Name, str14);
            w.WriteLine("//");
            w.WriteLine("CodeTypeDelegate {0} = new CodeTypeDelegate();", nextVar);
            w.WriteLine("{0}.Attributes = {1};", nextVar, this.GetMemberAttributes(delegate2.Attributes));
            this.GenerateCodeTypeReferences(string.Format("{0}.BaseTypes", nextVar), delegate2.BaseTypes, w, o);
            this.GenerateCodeComments(string.Format("{0}.Comments", nextVar), delegate2.Comments, w, o);
            this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", nextVar), delegate2.CustomAttributes, w, o);
            w.WriteLine("{0}.Name = \"{1}\";", nextVar, delegate2.Name);
            if (delegate2.IsClass)
            {
                w.WriteLine("{0}.IsClass = true;", nextVar);
            }
            if (delegate2.IsEnum)
            {
                w.WriteLine("{0}.IsEnum = true;", nextVar);
            }
            if (delegate2.IsInterface)
            {
                w.WriteLine("{0}.IsInterface = true;", nextVar);
            }
            if (delegate2.IsPartial)
            {
                w.WriteLine("{0}.IsPartial = true;", nextVar);
            }
            if (delegate2.IsStruct)
            {
                w.WriteLine("{0}.IsStruct = true;", nextVar);
            }
            this.GenerateCodeTypeMembers(string.Format("{0}.Members", nextVar), delegate2.Members, w, o);
            this.GenerateCodeParameterDeclarationExpressions(string.Format("{0}.Parameters", nextVar), delegate2.Parameters, w, o);
            if ((delegate2.ReturnType != null) && (delegate2.ReturnType.BaseType != "System.Void"))
            {
                string str15 = this.GenerateCodeTypeReference(null, delegate2.ReturnType, w, o);
                w.WriteLine("{0}.ReturnType = {1};", nextVar, str15);
            }
            w.WriteLine("{0}.TypeAttributes = {1};", nextVar, this.GetTypeAttributes(delegate2.TypeAttributes));
            this.GenerateCodeTypeParameters(string.Format("{0}.TypeParameters", nextVar), delegate2.TypeParameters, w, o);
            this.GenerateCodeDirectives(string.Format("{0}.StartDirectives", nextVar), delegate2.StartDirectives, w, o);
            this.GenerateCodeDirectives(string.Format("{0}.EndDirectives", nextVar), delegate2.EndDirectives, w, o);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeTypeMembers(string context, CodeTypeMemberCollection members, TextWriter w, CodeGeneratorOptions o)
        {
            if (members.Count > 0)
            {
                foreach (CodeTypeMember member in members)
                {
                    this.GenerateCodeTypeMember(context, member, w, o);
                }
            }
        }

        private string GenerateCodeTypeParameter(string context, CodeTypeParameter param, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar(param.Name + "_param");
            w.WriteLine("CodeTypeParameter {0} = new CodeTypeParameter();", nextVar);
            this.GenerateCodeTypeReferences(string.Format("{0}.Constraints", context), param.Constraints, w, o);
            this.GenerateCodeAttributeDeclarations(string.Format("{0}.CustomAttributes", nextVar), param.CustomAttributes, w, o);
            w.WriteLine("{0}.HasConstructorConstraint = {1};", nextVar, param.HasConstructorConstraint.ToString().ToLower());
            w.WriteLine("{0}.Name = \"{1}\";", nextVar, param.Name);
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeTypeParameters(string context, CodeTypeParameterCollection paramss, TextWriter w, CodeGeneratorOptions o)
        {
            if (paramss.Count > 0)
            {
                foreach (CodeTypeParameter parameter in paramss)
                {
                    this.GenerateCodeTypeParameter(context, parameter, w, o);
                }
            }
        }

        private string GenerateCodeTypeReference(string context, CodeTypeReference typeref, TextWriter w, CodeGeneratorOptions o)
        {
            string nextVar = this.GetNextVar(typeref.BaseType + "_type");
            if (typeref.ArrayElementType == null)
            {
                w.WriteLine("CodeTypeReference {0} = new CodeTypeReference(\"{1}\");", nextVar, typeref.BaseType);
            }
            else
            {
                w.WriteLine("CodeTypeReference {0} = new CodeTypeReference(\"{1}\", {2});", nextVar, typeref.BaseType, typeref.ArrayRank);
                this.GenerateCodeTypeReference(string.Format("{0}.ArrayElementType", context), typeref.ArrayElementType, w, o);
            }
            if ((context != null) && (context.Length > 0))
            {
                w.WriteLine("{0}.Add({1});", context, nextVar);
                w.WriteLine();
            }
            return nextVar;
        }

        private void GenerateCodeTypeReferences(string context, CodeTypeReferenceCollection typerefs, TextWriter w, CodeGeneratorOptions o)
        {
            if (typerefs.Count > 0)
            {
                foreach (CodeTypeReference reference in typerefs)
                {
                    this.GenerateCodeTypeReference(context, reference, w, o);
                }
            }
        }

        private string GetByteData(byte[] data)
        {
            if (data == null)
            {
                return "null";
            }
            string str = "new byte[] { ";
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 0)
                {
                    str = str + ", ";
                }
                str = str + "0x" + data[i].ToString("X2");
            }
            return (str + " }");
        }

        private string GetCodeBinaryOperatorType(CodeBinaryOperatorType op)
        {
            return ("CodeBinaryOperatorType." + op.ToString());
        }

        private string GetCodeRegionMode(CodeRegionMode attributes)
        {
            string str = string.Empty;
            CodeRegionMode[] values = (CodeRegionMode[]) Enum.GetValues(typeof(CodeRegionMode));
            foreach (CodeRegionMode mode in values)
            {
                if ((mode & attributes) == mode)
                {
                    if (str.Length != 0)
                    {
                        str = str + "|";
                    }
                    str = str + "CodeRegionMode." + mode.ToString();
                }
            }
            if (str.Length == 0)
            {
                return "CodeRegionMode.None";
            }
            return str;
        }

        private string GetFieldDirection(FieldDirection attributes)
        {
            string str = string.Empty;
            FieldDirection[] values = (FieldDirection[]) Enum.GetValues(typeof(FieldDirection));
            foreach (FieldDirection direction in values)
            {
                if ((direction & attributes) == direction)
                {
                    if (str.Length != 0)
                    {
                        str = str + "|";
                    }
                    str = str + "FieldDirection." + direction.ToString();
                }
            }
            if (str.Length == 0)
            {
                str = "FieldDirection.In";
            }
            return str;
        }

        private string GetMemberAttributes(MemberAttributes attributes)
        {
            string str = string.Empty;
            MemberAttributes[] values = (MemberAttributes[]) Enum.GetValues(typeof(MemberAttributes));
            foreach (MemberAttributes attributes2 in values)
            {
                if ((attributes2 & attributes) == attributes2)
                {
                    if (str.Length != 0)
                    {
                        str = str + "|";
                    }
                    str = str + "MemberAttributes." + attributes2.ToString();
                }
            }
            if (str.Length == 0)
            {
                str = "MemberAttributes.Private";
            }
            return str;
        }

        private string GetNextVar(string name)
        {
            if (name == string.Empty)
            {
                name = "codedom";
            }
            if (this.codedomVar.ContainsKey(name))
            {
                int num = ((int) this.codedomVar[name]) + 1;
                this.codedomVar[name] = num;
                return (this.MakeName(name) + num.ToString());
            }
            this.codedomVar[name] = 1;
            return (this.MakeName(name) + "1");
        }

        private string GetTypeAttributes(TypeAttributes attributes)
        {
            string str = string.Empty;
            TypeAttributes[] values = (TypeAttributes[]) Enum.GetValues(typeof(TypeAttributes));
            foreach (TypeAttributes attributes2 in values)
            {
                if ((attributes2 & attributes) == attributes2)
                {
                    if (str.Length != 0)
                    {
                        str = str + "|";
                    }
                    str = str + "System.Reflection.TypeAttributes." + attributes2.ToString();
                }
            }
            if (str.Length == 0)
            {
                str = "System.Reflection.TypeAttributes.Private";
            }
            return str;
        }

        public string GetTypeOutput(CodeTypeReference type)
        {
            return null;
        }

        public bool IsValidIdentifier(string value)
        {
            return false;
        }

        private string MakeName(string name)
        {
            name = name.Replace(".", "_");
            return ("_" + name);
        }

        public bool Supports(GeneratorSupport supports)
        {
            return true;
        }

        public void ValidateIdentifier(string value)
        {
        }
    }
}

