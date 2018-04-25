namespace CodeDomAssistant
{
    using System;
    using System.CodeDom.Compiler;

    public class CodeDomCodeProvider : CodeDomProvider
    {
        public override ICodeCompiler CreateCompiler()
        {
            return null;
        }

        public override ICodeGenerator CreateGenerator()
        {
            return new CodeDomAssistant.CodeGenerator();
        }

        public override string FileExtension
        {
            get
            {
                return "cs";
            }
        }
    }
}

