namespace CodeDomAssistant
{
    using Microsoft.CSharp;
    using RemoteLoader;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Text;

    public class CSharpSnippet
    {
        private List<string> assemblies = new List<string>();
        private string codesnippet = string.Empty;
        private List<string> namespaces = new List<string>();
        private CompilerParameters parameters = new CompilerParameters();

        public CSharpSnippet(string codesnippet)
        {
            this.codesnippet = codesnippet;
            this.parameters.ReferencedAssemblies.Add("System.dll");
            this.parameters.ReferencedAssemblies.Add("RemoteLoader.dll");
            this.namespaces.Add("System");
            this.namespaces.Add("System.Reflection");
            this.namespaces.Add("RemoteLoader");
        }

        public object Execute(string method, params object[] args)
        {
            object obj2 = null;
            AppDomain domain = null;
            string str = "script_" + Guid.NewGuid().ToString();
            try
            {
                StringBuilder sb = new StringBuilder();
                StringWriter writer = new StringWriter(sb);
                foreach (string str2 in this.namespaces)
                {
                    writer.WriteLine("using " + str2 + ";");
                }
                writer.WriteLine();
                writer.WriteLine("namespace CodeDomAssistant.Script {");
                writer.WriteLine("    // Encapsulate Code Snippet Script");
                writer.WriteLine("    public class CodeSnippet : MarshalByRefObject, IRemoteInterface {");
                writer.WriteLine("        // Invoke Method Through IRemoteInterface");
                writer.WriteLine("        public object Invoke(string method, object[] parms) {");
                writer.WriteLine("            return this.GetType().InvokeMember(method, BindingFlags.InvokeMethod, null, this, parms);");
                writer.WriteLine("        }");
                writer.WriteLine();
                writer.WriteLine(this.codesnippet);
                writer.WriteLine("    }");
                writer.WriteLine("}");
                writer.Flush();
                writer.Close();
                this.parameters.OutputAssembly = str + ".dll";
                new CSharpCodeProvider().CompileAssemblyFromSource(this.parameters, new string[] { sb.ToString() });
                AppDomainSetup info = new AppDomainSetup();
                info.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
                domain = AppDomain.CreateDomain("Scripting", null, info);
                RemoteLoaderFactory factory = (RemoteLoaderFactory) domain.CreateInstance("RemoteLoader", "RemoteLoader.RemoteLoaderFactory").Unwrap();
                obj2 = factory.Create(str + ".dll", "CodeDomAssistant.Script.CodeSnippet", null).Invoke(method, args);
            }
            finally
            {
                if (domain != null)
                {
                    AppDomain.Unload(domain);
                }
                if (File.Exists(str + ".dll"))
                {
                    File.Delete(str + ".dll");
                }
            }
            return obj2;
        }

        public List<string> Namespaces
        {
            get
            {
                return this.namespaces;
            }
        }

        public StringCollection ReferencedAssemblies
        {
            get
            {
                return this.parameters.ReferencedAssemblies;
            }
        }
    }
}

