﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using KeelKit.Core;
using KeelKit.Core.Serialization;
using System.Collections.Generic;

namespace KeelKit.Generators
{
 
   public  class BaseGengerator
    {
       protected  CodeCompileUnit ccu = new CodeCompileUnit();
       protected CodeNamespace cns = null;
       protected CodeTypeDeclaration ctd = null;
       protected  BaseGengerator(string cfNameSpace)
        {
            cns = new CodeNamespace(cfNameSpace);
            cns.Imports.Add(new CodeNamespaceImport("System"));
            cns.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            cns.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));
            cns.Imports.Add(new CodeNamespaceImport("System.Data"));
            cns.Imports.Add(new CodeNamespaceImport("System.Text"));
            cns.Imports.Add(new CodeNamespaceImport("Keel.ORM"));
            cns.Comments.Add(new CodeCommentStatement(AddKeelKitInfo(false )));
            ccu.Namespaces.Add(cns);
        }
 
         public bool AddProperty(string name, Type type, CodeAttributeDeclaration cad,string desc)
       {
           bool  i = false  ;
           try
           { 
               string tmpvarname= "_" + GetNameByFieldName(name);
               CodeMemberField cmf = new CodeMemberField(type, tmpvarname);
               CodeMemberProperty cmp = new CodeMemberProperty();
               cmp.Name =GetNameByFieldName( name);
               cmp.CustomAttributes.Add(cad);
               cmp.Type = new CodeTypeReference(type);
               cmp.Attributes = (cmp.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
               cmp.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),tmpvarname)));
               cmp.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),tmpvarname),new CodePropertySetValueReferenceExpression()));
               if (desc != null && desc.Trim() != "")
               {
                   cmf.Comments.Add(new CodeCommentStatement("<summary>", true));
                   cmf.Comments.Add(new CodeCommentStatement( desc,true ));
                   cmf.Comments.Add(new CodeCommentStatement("</summary>", true));
                   cmp.Comments.Add(new CodeCommentStatement("<summary>", true));
                   cmp.Comments.Add(new CodeCommentStatement(desc,true ));
                   cmp.Comments.Add(new CodeCommentStatement("</summary>", true));
               }
               ctd.Members.Add(cmf);
               ctd.Members.Add(cmp);
               i = true ;
           }
           catch (Exception)
           {
               i = false;
           }
           return i;
       }

       public bool AddProperty(string name, Type type,string desc)
       {
           bool i = false;
           try
           {
               CodeAttributeDeclaration cad = new CodeAttributeDeclaration(
                        new CodeTypeReference(typeof(Keel.ORM.DataFieldAttribute)),
                        new CodeAttributeArgument(new CodePrimitiveExpression(name))
                        );
               i = AddProperty(name, type, cad,desc );
           }
           catch (Exception)
           {
               i = false;
           }
           return i;
       }

       public string Save(string path, cfLangType clt)
       {
           return Save(path, clt, new DGetFileNames(GetFileNames));
       }
       public string Save(string path, cfLangType clt, DGetFileNames getfilename)
       {

           CodeDomProvider provider = GetProvider(clt);

           string filename =getfilename!=null ? getfilename(path, provider.FileExtension):GetFileNames(path ,provider.FileExtension );

           IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(filename, false, Encoding.UTF8), "    ");
           provider.GenerateCodeFromCompileUnit(ccu, tw, new CodeGeneratorOptions());
           tw.Close();
           string context= System.IO.File.ReadAllText(filename, Encoding.UTF8);
           if (!context.Contains("<auto-generated>") && ccu.Namespaces.Count >0)
           {
               ccu.Namespaces[0].Comments.Clear();
               ccu.Namespaces[0].Comments.Add(new CodeCommentStatement(AddKeelKitInfo()));
               tw = new IndentedTextWriter(new StreamWriter(filename, false, Encoding.UTF8), "    ");
               provider.GenerateCodeFromCompileUnit(ccu, tw, new CodeGeneratorOptions());
               tw.Close();
           }
           return filename;
       }

       public  static CodeDomProvider GetProvider(cfLangType clt)
       {
           CodeDomProvider provider = null;
           #region 生成序列化代码
           //LangCodeProvider lcp = new LangCodeProvider();
           //System.Reflection.Assembly asm = System.Reflection.Assembly.Load("CppCodeProvider, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");//"Microsoft.VisualC.VSCodeProvider, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
           //provider = asm.CreateInstance("Microsoft.VisualC.CppCodeProvider7") as CodeDomProvider;
           //lcp.CPP =new ProviderInfo(typeof( Microsoft.VisualC.VSCodeProvider).Assembly.FullName ,null  ,"Microsoft.VisualC.VSCodeProvider");
           //lcp.CSharp = new ProviderInfo(typeof(Microsoft.CSharp.CSharpCodeProvider).Assembly.FullName ,null  ,"Microsoft.CSharp.CSharpCodeProvider");
           //lcp.FSharp = new ProviderInfo(typeof (Microsoft.FSharp.Compiler.CodeDom.FSharpCodeProvider).Assembly.FullName ,typeof (Microsoft.FSharp.Compiler.CodeDom.FSharpCodeProvider).Assembly.Location ,"Microsoft.FSharp.Compiler.CodeDom.FSharpCodeProvider");
           //lcp.IronPython = new ProviderInfo(typeof(IronPython.CodeDom.PythonProvider).Assembly.FullName, typeof(IronPython.CodeDom.PythonProvider).Assembly.Location, "IronPython.CodeDom.PythonProvider");
           //lcp.VBDotNet = new ProviderInfo(typeof(Microsoft.VisualBasic.VBCodeProvider).Assembly.FullName, null , "Microsoft.VisualBasic.VBCodeProvider");

           //System.IO.File.WriteAllBytes("c:\\ddd.xml", XMLRW<LangCodeProvider>.Write(lcp));
           #endregion 
           string name = Enum.GetName(typeof(cfLangType), clt);
           ProviderInfo pi = typeof(LangCodeProvider).InvokeMember(name, System.Reflection.BindingFlags.GetProperty, null, Kit.GetCodeProviderRouter (), new object[] { }) as ProviderInfo;
           if (pi == null)
           {
               pi = typeof(LangCodeProvider).InvokeMember(name, System.Reflection.BindingFlags.GetProperty, null, Kit.GetDefaultCodeProviderRouter(), new object[] { }) as ProviderInfo;
           }
           System.Reflection.Assembly asm=null  ;
           if (pi.Location != null)
           {
               if (asm == null)
               {
                   try
                   {
                        asm = System.Reflection.Assembly.Load(pi.AsmFullName);
                   }
                   catch (Exception)
                   {
                       asm = null;
                   }
               }
               if (System.IO.File.Exists(pi.Location))
               {
                   try
                   {
                       asm = System.Reflection.Assembly.LoadFile(pi.Location);
                   }
                   catch (Exception ex)
                   {
                       asm = null;
                   }
               }
                if (asm==null )
               {
                   string f = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\" + pi.Location;
                   if (System.IO.File.Exists(f ))
                   {
                       try
                       {
                           asm = System.Reflection.Assembly.LoadFile(f);
                       }
                       catch (Exception ex)
                       {

                           Common.ShowInfo("装载" + f + "失败:" + ex.Message);
                       }
                      
                   }
               }
           }
         
           if (asm != null)
           {
               try
               {
                   provider = asm.CreateInstance(pi.TypeName) as CodeDomProvider;
               }
               catch (Exception ex)
               {
                   Common.ShowInfo("类型" + pi.TypeName + "创建失败:"+ex.Message );

               }
           }
           #region 旧代码
           //switch (clt)
           //{ 
           //    default:
           //    case cfLangType.CSharp:
           //        provider = new CSharpCodeProvider()  ;
           //        break;
           //    case cfLangType.CPP:
           //        provider = new Microsoft.VisualC.VSCodeProvider() ;
           //        break;
           //    case cfLangType.VBDotNet:
           //        provider = new VBCodeProvider();
           //        break;
           //    case cfLangType.IronPython:
           //        provider = new IronPython.CodeDom.PythonProvider();
           //        break;
           //    case cfLangType.FSharp:
           //        provider = new Microsoft.FSharp.Compiler.CodeDom.FSharpCodeProvider();
           //        break;
           //}
           #endregion 
           return provider;
       }
       public static  string ClearBadChars(string context)
       {
           List<char> ccc = new List<char>(System.IO.Path.GetInvalidFileNameChars());
           foreach (var item in ccc)
           {
               context = context.Replace(item.ToString (),"");
           }
           return context;
   }
       public   delegate   string DGetFileNames(string path, string  FileExtension);
       private   string GetFileNames(string path, string FileExtension)
       {
           string filename = Path.GetDirectoryName(path) + "\\" + ctd.Name;
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
               if (System.IO.File.GetAttributes(filename) != FileAttributes.Normal)
               {
                   System.IO.File.SetAttributes(filename, FileAttributes.Normal);
               }
           }
           return filename;
       }
       public void AddTableNameConst(string name,string desc)
       {
           CodeMemberField cmfStaticConst = new CodeMemberField();
           cmfStaticConst.Attributes =    MemberAttributes.Override | MemberAttributes.Const | MemberAttributes.FamilyAndAssembly | MemberAttributes.FamilyOrAssembly | MemberAttributes.Public;
           CodePrimitiveExpression _value1 = new CodePrimitiveExpression();
           _value1.Value = name ;
           cmfStaticConst.InitExpression = _value1;
           cmfStaticConst.Name = "fn_"+GetNameByFieldName(name);
           CodeTypeReference _System_String_type1 = new CodeTypeReference(typeof(string ));
           cmfStaticConst.Type = _System_String_type1;
           if (desc != null && desc.Trim() != "")
           {
               cmfStaticConst.Comments.Add(new CodeCommentStatement("<summary>", true));
               cmfStaticConst.Comments.Add(new CodeCommentStatement(desc, true));
               cmfStaticConst.Comments.Add(new CodeCommentStatement("</summary>", true));
           }
           ctd.Members.Add(cmfStaticConst);
       }
        
       public  string GetNameByFieldName(string fieldname )
       {
           string result = fieldname.Replace(" ","");
           if (result == ctd.Name)
           {
               result += "_field";
           }
           result =ClearBadChars(result );
           return result;
       }
       public static string AddKeelKitInfo( )
       {
         return   AddKeelKitInfo(true);
       }
       public static string AddKeelKitInfo(bool w)
       {
           return AddKeelKitInfo(w, "");
       }
       public  static string AddKeelKitInfo(bool w,string linefirstchars)
       {
         
           StringBuilder context = new StringBuilder();
           if (w) context.AppendLine(linefirstchars+"----------------------------------------------------------------------------");
           context.AppendLine(linefirstchars+"    此文件由KeelKit自动生成");
           context.AppendLine(linefirstchars + "    生成器版本:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
           if (w) context.AppendLine(linefirstchars+"    运行时版本:" + System.Environment.Version.ToString());
           if (w) context.AppendLine(linefirstchars+"");
           if (w) context.AppendLine(linefirstchars+"    对此文件的更改可能会导致不正确的行为，并且如果");
           if (w) context.AppendLine(linefirstchars+"    重新生成代码，这些更改将会丢失。");
           //context.AppendLine(linefirstchars+"    生成日期:" + DateTime.Now.ToString("yyyyMMddHHmmss"));
           if (w) context.AppendLine(linefirstchars+"----------------------------------------------------------------------------");
           return w ? context.ToString() : context.ToString().Replace(System.Environment.NewLine, "").Replace("    ", " ").Trim();
       }

    }
}