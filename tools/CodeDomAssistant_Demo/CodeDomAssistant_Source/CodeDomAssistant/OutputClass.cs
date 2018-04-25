namespace CodeDomAssistant
{
    using ICSharpCode.NRefactory.PrettyPrinter;
    using ICSharpCode.NRefactory.Visitors;
    using System;
    using System.CodeDom.Compiler;

    public class OutputClass
    {
        private bool cantestcodedom;
        private System.CodeDom.Compiler.CodeDomProvider codedomprovider;
        private string name;
        private IOutputAstVisitor prettyprinter;
        private int savefilterindex;
        private AbstractAstTransformer transformer;

        public OutputClass()
        {
            this.name = string.Empty;
        }

        public OutputClass(string name, System.CodeDom.Compiler.CodeDomProvider codedomprovider, int savefilterindex)
        {
            this.name = string.Empty;
            this.name = name;
            this.codedomprovider = codedomprovider;
            this.savefilterindex = savefilterindex;
        }

        public OutputClass(string name, AbstractAstTransformer visitor, IOutputAstVisitor prettyprinter, int savefilterindex)
        {
            this.name = string.Empty;
            this.name = name;
            this.transformer = visitor;
            this.prettyprinter = prettyprinter;
            this.savefilterindex = savefilterindex;
        }

        public IOutputAstVisitor CreatePrettyPrinter()
        {
            if (this.prettyprinter == null)
            {
                return null;
            }
            return (IOutputAstVisitor) this.prettyprinter.GetType().Assembly.CreateInstance(this.prettyprinter.GetType().FullName);
        }

        public AbstractAstTransformer CreateTransformer()
        {
            if (this.transformer == null)
            {
                return null;
            }
            return (AbstractAstTransformer) this.transformer.GetType().Assembly.CreateInstance(this.transformer.GetType().FullName);
        }

        public override string ToString()
        {
            return this.name;
        }

        public bool CanTestCodeDom
        {
            get
            {
                return this.cantestcodedom;
            }
            set
            {
                this.cantestcodedom = value;
            }
        }

        public System.CodeDom.Compiler.CodeDomProvider CodeDomProvider
        {
            get
            {
                return this.codedomprovider;
            }
            set
            {
                this.codedomprovider = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int SaveFilterIndex
        {
            get
            {
                return this.savefilterindex;
            }
            set
            {
                this.savefilterindex = value;
            }
        }
    }
}

