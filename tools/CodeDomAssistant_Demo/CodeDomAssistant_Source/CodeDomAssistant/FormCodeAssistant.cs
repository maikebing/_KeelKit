namespace CodeDomAssistant
{
    using ICSharpCode.Core;
    using ICSharpCode.NRefactory;
    using ICSharpCode.NRefactory.PrettyPrinter;
    using ICSharpCode.NRefactory.Visitors;
    using ScintillaNet;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class FormCodeAssistant : Form
    {
        private Button button1;
        private Button buttonGenerate;
        private Button buttonTestCodeDom;
        private ComboBox cbCodeDom;
        private ComboBox cbOutput;
        private ToolStripMenuItem codeDomProvidersToolStripMenuItem;
        private IContainer components;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private FindReplaceDialog findReplaceDialog;
        private ToolStripMenuItem findToolStripMenuItem;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private string outputfilename = string.Empty;
        private FormCodeDomProviderAssemblies providerAssemblies;
        private RadioButton radioCSharp;
        private RadioButton radioVB;
        private List<string> savefilters = new List<string>();
        private ToolStripMenuItem saveOutputStripMenuItem;
        private Scintilla scintillaInput;
        private Scintilla scintillaOutput;
        private Scintilla scintillaTestCodeDom;
        private TabControl tabControl1;
        private TabPage tabInputCode;
        private TabPage tabOutputCode;
        private TabPage tabTestCodeDom;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;

        public FormCodeAssistant()
        {
            this.InitializeComponent();
            this.scintillaInput.ConfigurationManager.Language = "cs";
            this.scintillaInput.FileDrop += new EventHandler<FileDropEventArgs>(this.scintillaCode_FileDrop);
            this.LoadLists();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.tabOutputCode;
            SupportedLanguage cSharp = SupportedLanguage.CSharp;
            if (this.radioVB.Checked)
            {
                cSharp = SupportedLanguage.VBNet;
            }
            TextReader inputstream = new StringReader(this.scintillaInput.Text);
            try
            {
                OutputClass selectedItem = (OutputClass) this.cbOutput.SelectedItem;
                this.Generate(cSharp, inputstream, selectedItem);
                this.buttonTestCodeDom.Enabled = selectedItem.CanTestCodeDom;
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
            finally
            {
                inputstream.Close();
            }
        }

        private void buttonTestCodeDom_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.tabControl1.SelectedTab = this.tabTestCodeDom;
                this.CompileTestCodeDom(this.scintillaOutput.Text);
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void codeDomProvidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.providerAssemblies == null)
                {
                    this.providerAssemblies = new FormCodeDomProviderAssemblies();
                    this.providerAssemblies.FormClosed += new FormClosedEventHandler(this.providerAssemblies_FormClosed);
                    this.providerAssemblies.Show();
                    this.providerAssemblies.LoadAssemblies(false);
                }
                else
                {
                    this.providerAssemblies.Activate();
                }
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
        }

        private void CompileTestCodeDom(string code)
        {
            try
            {
                OutputClass selectedItem = (OutputClass) this.cbCodeDom.SelectedItem;
                CodeDomProvider codeDomProvider = selectedItem.CodeDomProvider;
                CSharpSnippet snippet = new CSharpSnippet("\r\n    public string GenerateCode()\r\n    {\r\n        " + code + "\r\n\r\n        CodeGeneratorOptions codegenopt = new CodeGeneratorOptions();\r\n        codegenopt.BlankLinesBetweenMembers = true;\r\n\r\n        using (System.IO.StringWriter sw = new System.IO.StringWriter())\r\n        {\r\n            " + codeDomProvider.GetType().Name + " provider = new " + codeDomProvider.GetType().Name + "();\r\n\r\n            provider.GenerateCodeFromCompileUnit(_compileunit1, sw, codegenopt);\r\n\r\n            return sw.ToString();\r\n        }\r\n    }   \r\n");
                snippet.Namespaces.Add("System.CodeDom");
                snippet.Namespaces.Add("System.CodeDom.Compiler");
                snippet.Namespaces.Add(codeDomProvider.GetType().Namespace);
                Assembly assembly = codeDomProvider.GetType().Assembly;
                if (!assembly.GlobalAssemblyCache)
                {
                    snippet.ReferencedAssemblies.Add(assembly.Location);
                }
                object[] args = new object[0];
                object obj2 = snippet.Execute("GenerateCode", args);
                if (obj2 != null)
                {
                    this.scintillaTestCodeDom.Text = obj2.ToString();
                }
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void findReplaceDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.findReplaceDialog = null;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.findReplaceDialog == null)
            {
                this.findReplaceDialog = new FindReplaceDialog();
                this.findReplaceDialog.FormClosing += new FormClosingEventHandler(this.findReplaceDialog_FormClosing);
            }
            this.InitFindReplace();
        }

        private void Generate(SupportedLanguage language, TextReader inputstream, OutputClass output)
        {
            IParser parser = ParserFactory.CreateParser(language, inputstream);
            parser.Parse();
            if (parser.Errors.Count > 0)
            {
                new ExceptionDialog(null, "Error Parsing Input Code").ShowDialog();
            }
            else if (output.CodeDomProvider != null)
            {
                CodeDomVisitor visitor = new CodeDomVisitor();
                visitor.VisitCompilationUnit(parser.CompilationUnit, null);
                for (int i = visitor.codeCompileUnit.Namespaces.Count - 1; i >= 0; i--)
                {
                    if (visitor.codeCompileUnit.Namespaces[i].Types.Count == 0)
                    {
                        visitor.codeCompileUnit.Namespaces.RemoveAt(i);
                    }
                }
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BlankLinesBetweenMembers = true;
                StringWriter writer = new StringWriter();
                output.CodeDomProvider.GenerateCodeFromCompileUnit(visitor.codeCompileUnit, writer, options);
                this.scintillaOutput.Text = writer.ToString();
                writer.Close();
            }
            else
            {
                AbstractAstTransformer transformer = output.CreateTransformer();
                List<ISpecial> currentSpecials = parser.Lexer.SpecialTracker.CurrentSpecials;
                if ((language == SupportedLanguage.CSharp) && (transformer is ToVBNetConvertVisitor))
                {
                    PreprocessingDirective.CSharpToVB(currentSpecials);
                }
                else if ((language == SupportedLanguage.VBNet) && (transformer is ToCSharpConvertVisitor))
                {
                    PreprocessingDirective.VBToCSharp(currentSpecials);
                }
                parser.CompilationUnit.AcceptVisitor(transformer, null);
                IOutputAstVisitor outputVisitor = output.CreatePrettyPrinter();
                using (SpecialNodesInserter.Install(currentSpecials, outputVisitor))
                {
                    outputVisitor.VisitCompilationUnit(parser.CompilationUnit, null);
                }
                this.scintillaOutput.Text = outputVisitor.Text;
            }
        }

        private void InitFindReplace()
        {
            if (this.findReplaceDialog != null)
            {
                if (this.tabControl1.SelectedTab == this.tabTestCodeDom)
                {
                    this.findReplaceDialog.Scintilla = this.scintillaTestCodeDom;
                }
                else if (this.tabControl1.SelectedTab == this.tabOutputCode)
                {
                    this.findReplaceDialog.Scintilla = this.scintillaOutput;
                }
                else
                {
                    this.findReplaceDialog.Scintilla = this.scintillaInput;
                }
                this.findReplaceDialog.Show();
            }
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new TabControl();
            this.tabInputCode = new TabPage();
            this.scintillaInput = new Scintilla();
            this.tabOutputCode = new TabPage();
            this.scintillaOutput = new Scintilla();
            this.tabTestCodeDom = new TabPage();
            this.scintillaTestCodeDom = new Scintilla();
            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.openToolStripMenuItem = new ToolStripMenuItem();
            this.saveOutputStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.editToolStripMenuItem = new ToolStripMenuItem();
            this.findToolStripMenuItem = new ToolStripMenuItem();
            this.toolsToolStripMenuItem = new ToolStripMenuItem();
            this.codeDomProvidersToolStripMenuItem = new ToolStripMenuItem();
            this.groupBox1 = new GroupBox();
            this.button1 = new Button();
            this.radioVB = new RadioButton();
            this.radioCSharp = new RadioButton();
            this.groupBox2 = new GroupBox();
            this.buttonGenerate = new Button();
            this.cbOutput = new ComboBox();
            this.groupBox3 = new GroupBox();
            this.buttonTestCodeDom = new Button();
            this.cbCodeDom = new ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabInputCode.SuspendLayout();
            this.scintillaInput.BeginInit();
            this.tabOutputCode.SuspendLayout();
            this.scintillaOutput.BeginInit();
            this.tabTestCodeDom.SuspendLayout();
            this.scintillaTestCodeDom.BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.tabControl1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.tabControl1.Controls.Add(this.tabInputCode);
            this.tabControl1.Controls.Add(this.tabOutputCode);
            this.tabControl1.Controls.Add(this.tabTestCodeDom);
            this.tabControl1.Location = new Point(0, 0x18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x2e8, 0x1a2);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabInputCode.Controls.Add(this.scintillaInput);
            this.tabInputCode.Location = new Point(4, 0x19);
            this.tabInputCode.Name = "tabInputCode";
            this.tabInputCode.Padding = new Padding(3);
            this.tabInputCode.Size = new Size(0x2e0, 0x185);
            this.tabInputCode.TabIndex = 0;
            this.tabInputCode.Text = "Input Code";
            this.tabInputCode.UseVisualStyleBackColor = true;
            this.scintillaInput.Caret.Style = CaretStyle.Invisible;
            this.scintillaInput.CurrentPos = 0;
            this.scintillaInput.Dock = DockStyle.Fill;
            this.scintillaInput.LineWrap.PositionCacheSize = 0;
            this.scintillaInput.Location = new Point(3, 3);
            this.scintillaInput.Name = "scintillaInput";
            this.scintillaInput.Printing.PageSettings.Color = false;
            this.scintillaInput.Size = new Size(730, 0x17f);
            this.scintillaInput.TabIndex = 0;
            this.tabOutputCode.Controls.Add(this.scintillaOutput);
            this.tabOutputCode.Location = new Point(4, 0x19);
            this.tabOutputCode.Name = "tabOutputCode";
            this.tabOutputCode.Padding = new Padding(3);
            this.tabOutputCode.Size = new Size(0x2e0, 0x185);
            this.tabOutputCode.TabIndex = 1;
            this.tabOutputCode.Text = "Output Code";
            this.tabOutputCode.UseVisualStyleBackColor = true;
            this.scintillaOutput.Caret.Style = CaretStyle.Invisible;
            this.scintillaOutput.CurrentPos = 0;
            this.scintillaOutput.Dock = DockStyle.Fill;
            this.scintillaOutput.LineWrap.PositionCacheSize = 0;
            this.scintillaOutput.Location = new Point(3, 3);
            this.scintillaOutput.Name = "scintillaOutput";
            this.scintillaOutput.Printing.PageSettings.Color = false;
            this.scintillaOutput.Size = new Size(730, 0x17f);
            this.scintillaOutput.TabIndex = 0;
            this.tabTestCodeDom.Controls.Add(this.scintillaTestCodeDom);
            this.tabTestCodeDom.Location = new Point(4, 0x19);
            this.tabTestCodeDom.Name = "tabTestCodeDom";
            this.tabTestCodeDom.Size = new Size(0x2e0, 0x185);
            this.tabTestCodeDom.TabIndex = 2;
            this.tabTestCodeDom.Text = "Test CodeDom";
            this.tabTestCodeDom.UseVisualStyleBackColor = true;
            this.scintillaTestCodeDom.Caret.Style = CaretStyle.Invisible;
            this.scintillaTestCodeDom.CurrentPos = 0;
            this.scintillaTestCodeDom.Dock = DockStyle.Fill;
            this.scintillaTestCodeDom.LineWrap.PositionCacheSize = 0;
            this.scintillaTestCodeDom.Location = new Point(0, 0);
            this.scintillaTestCodeDom.Name = "scintillaTestCodeDom";
            this.scintillaTestCodeDom.Printing.PageSettings.Color = false;
            this.scintillaTestCodeDom.Size = new Size(0x2e0, 0x185);
            this.scintillaTestCodeDom.TabIndex = 0;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.fileToolStripMenuItem, this.editToolStripMenuItem, this.toolsToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x2e8, 0x1a);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.openToolStripMenuItem, this.saveOutputStripMenuItem, this.toolStripSeparator1, this.exitToolStripMenuItem });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(40, 0x16);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new EventHandler(this.fileToolStripMenuItem_Click);
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            this.openToolStripMenuItem.Size = new Size(0xf2, 0x16);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
            this.saveOutputStripMenuItem.Name = "saveOutputStripMenuItem";
            this.saveOutputStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.saveOutputStripMenuItem.Size = new Size(0xf2, 0x16);
            this.saveOutputStripMenuItem.Text = "Save Output As";
            this.saveOutputStripMenuItem.Click += new EventHandler(this.saveOutputStripMenuItem_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(0xef, 6);
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.X;
            this.exitToolStripMenuItem.Size = new Size(0xf2, 0x16);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            this.editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.findToolStripMenuItem });
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new Size(0x2b, 0x16);
            this.editToolStripMenuItem.Text = "Edit";
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            this.findToolStripMenuItem.Size = new Size(0xf9, 0x16);
            this.findToolStripMenuItem.Text = "Find and Replace";
            this.findToolStripMenuItem.Click += new EventHandler(this.findToolStripMenuItem_Click);
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.codeDomProvidersToolStripMenuItem });
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new Size(0x37, 0x16);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.codeDomProvidersToolStripMenuItem.Name = "codeDomProvidersToolStripMenuItem";
            this.codeDomProvidersToolStripMenuItem.Size = new Size(0xe5, 0x16);
            this.codeDomProvidersToolStripMenuItem.Text = "CodeDomProviders...";
            this.codeDomProvidersToolStripMenuItem.Click += new EventHandler(this.codeDomProvidersToolStripMenuItem_Click);
            this.groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radioVB);
            this.groupBox1.Controls.Add(this.radioCSharp);
            this.groupBox1.Location = new Point(13, 0x1bc);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x94, 0x42);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Parser";
            this.button1.Location = new Point(0x129, 0x12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.radioVB.AutoSize = true;
            this.radioVB.Location = new Point(0x53, 0x1b);
            this.radioVB.Name = "radioVB";
            this.radioVB.Size = new Size(0x2f, 0x15);
            this.radioVB.TabIndex = 5;
            this.radioVB.Text = "VB";
            this.radioVB.UseVisualStyleBackColor = true;
            this.radioVB.CheckedChanged += new EventHandler(this.radioVB_CheckedChanged);
            this.radioCSharp.AutoSize = true;
            this.radioCSharp.Checked = true;
            this.radioCSharp.Location = new Point(6, 0x1c);
            this.radioCSharp.Name = "radioCSharp";
            this.radioCSharp.Size = new Size(0x2e, 0x15);
            this.radioCSharp.TabIndex = 4;
            this.radioCSharp.TabStop = true;
            this.radioCSharp.Text = "C#";
            this.radioCSharp.UseVisualStyleBackColor = true;
            this.radioCSharp.CheckedChanged += new EventHandler(this.radioCSharp_CheckedChanged);
            this.groupBox2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.buttonGenerate);
            this.groupBox2.Controls.Add(this.cbOutput);
            this.groupBox2.Location = new Point(0xb1, 0x1bc);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x231, 0x41);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Code";
            this.buttonGenerate.Location = new Point(390, 0x12);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new Size(0x9a, 0x21);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Generate >>";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new EventHandler(this.buttonGenerate_Click);
            this.cbOutput.FormattingEnabled = true;
            this.cbOutput.Location = new Point(0x12, 0x1c);
            this.cbOutput.Name = "cbOutput";
            this.cbOutput.Size = new Size(0x102, 0x18);
            this.cbOutput.TabIndex = 0;
            this.groupBox3.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.buttonTestCodeDom);
            this.groupBox3.Controls.Add(this.cbCodeDom);
            this.groupBox3.Location = new Point(0xb1, 0x203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x22f, 0x40);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test CodeDom";
            this.buttonTestCodeDom.Enabled = false;
            this.buttonTestCodeDom.Location = new Point(0x185, 0x12);
            this.buttonTestCodeDom.Name = "buttonTestCodeDom";
            this.buttonTestCodeDom.Size = new Size(0x9a, 0x21);
            this.buttonTestCodeDom.TabIndex = 3;
            this.buttonTestCodeDom.Text = "Test CodeDom >>";
            this.buttonTestCodeDom.UseVisualStyleBackColor = true;
            this.buttonTestCodeDom.Click += new EventHandler(this.buttonTestCodeDom_Click);
            this.cbCodeDom.FormattingEnabled = true;
            this.cbCodeDom.Location = new Point(0x11, 0x1c);
            this.cbCodeDom.Name = "cbCodeDom";
            this.cbCodeDom.Size = new Size(0x102, 0x18);
            this.cbCodeDom.TabIndex = 2;
            base.AutoScaleDimensions = new SizeF(8f, 16f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2e8, 0x24c);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.tabControl1);
            base.Controls.Add(this.menuStrip1);
            base.MainMenuStrip = this.menuStrip1;
            base.Name = "FormCodeAssistant";
            this.Text = "CodeDom Assistant";
            this.tabControl1.ResumeLayout(false);
            this.tabInputCode.ResumeLayout(false);
            this.scintillaInput.EndInit();
            this.tabOutputCode.ResumeLayout(false);
            this.scintillaOutput.EndInit();
            this.tabTestCodeDom.ResumeLayout(false);
            this.scintillaTestCodeDom.EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void LoadCodeDomAssemblies()
        {
            foreach (DataRow row in DynProvider.GetAssemblyInfo().Tables[0].Rows)
            {
                bool flag = (bool) row["Load"];
                if (((bool) row["HasProvider"]) && flag)
                {
                    string path = (string) row["Path"];
                    if ((bool) row["IsGAC"])
                    {
                        Assembly.LoadWithPartialName(Path.GetFileNameWithoutExtension(path));
                    }
                    else
                    {
                        Assembly.LoadFile(path);
                    }
                }
            }
        }

        private void LoadLists()
        {
            this.savefilters.Clear();
            this.cbOutput.Items.Clear();
            this.cbCodeDom.Items.Clear();
            this.savefilters.Add("CS|*.cs");
            this.cbOutput.Items.Add(new OutputClass("C#", new ToCSharpConvertVisitor(), new CSharpOutputVisitor(), 0));
            this.savefilters.Add("VB|*.vb");
            this.cbOutput.Items.Add(new OutputClass("VB", new ToVBNetConvertVisitor(), new VBNetOutputVisitor(), 1));
            this.LoadCodeDomAssemblies();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (System.Type type in assembly.GetExportedTypes())
                {
                    if (type.IsSubclassOf(typeof(CodeDomProvider)))
                    {
                        CodeDomProvider codedomprovider = (CodeDomProvider) assembly.CreateInstance(type.FullName);
                        string fileExtension = codedomprovider.FileExtension;
                        string item = fileExtension.ToUpper() + "|*." + fileExtension.ToLower();
                        int savefilterindex = -1;
                        for (int i = 0; i < this.savefilters.Count; i++)
                        {
                            if (this.savefilters[i] == item)
                            {
                                savefilterindex = i;
                                break;
                            }
                        }
                        if (savefilterindex == -1)
                        {
                            savefilterindex = this.savefilters.Count;
                            this.savefilters.Add(item);
                        }
                        OutputClass class2 = new OutputClass(type.Name, codedomprovider, savefilterindex);
                        if (type == typeof(CodeDomCodeProvider))
                        {
                            class2.CanTestCodeDom = true;
                        }
                        else
                        {
                            this.cbCodeDom.Items.Add(class2);
                        }
                        this.cbOutput.Items.Add(class2);
                    }
                }
            }
            this.cbOutput.SelectedIndex = 0;
            this.cbCodeDom.SelectedIndex = 0;
        }

        private void OpenInputFile(string filename)
        {
            string str = string.Empty;
            if (File.Exists(filename))
            {
                StreamReader reader = File.OpenText(filename);
                str = reader.ReadToEnd();
                reader.Close();
            }
            this.scintillaInput.Text = str;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "C#|*.cs|VB|*.vb|All Files|*.*";
                dialog.FilterIndex = 0;
                dialog.Title = "Open Source File";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.OpenInputFile(dialog.FileName);
                }
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void providerAssemblies_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((this.providerAssemblies != null) && (this.providerAssemblies.DialogResult == DialogResult.OK))
            {
                this.LoadLists();
            }
            this.providerAssemblies = null;
        }

        private void radioCSharp_CheckedChanged(object sender, EventArgs e)
        {
            this.scintillaInput.ConfigurationManager.Language = "cs";
        }

        private void radioVB_CheckedChanged(object sender, EventArgs e)
        {
            this.scintillaInput.ConfigurationManager.Language = "vb";
        }

        private void SaveOutputFile(string filename)
        {
            if (filename.Length != 0)
            {
                StreamWriter writer = new StreamWriter(filename);
                writer.Write(this.scintillaOutput.Text);
                writer.Flush();
                writer.Close();
                this.outputfilename = filename;
            }
        }

        private void saveOutputStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string str = string.Empty;
                foreach (string str2 in this.savefilters)
                {
                    if (str.Length > 0)
                    {
                        str = str + "|";
                    }
                    str = str + str2;
                }
                if (str.Length > 0)
                {
                    str = str + "|";
                }
                str = str + "All Files|*.*";
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = str;
                dialog.FilterIndex = ((OutputClass) this.cbOutput.SelectedItem).SaveFilterIndex + 1;
                dialog.Title = "Save Output File";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;
                dialog.ValidateNames = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.SaveOutputFile(dialog.FileName);
                }
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void scintillaCode_FileDrop(object sender, FileDropEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (e.FileNames.Length > 0)
                {
                    this.OpenInputFile(e.FileNames[0]);
                }
            }
            catch (Exception exception)
            {
                new ExceptionDialog(exception, "Error Generating CodeDom").ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitFindReplace();
        }
    }
}

