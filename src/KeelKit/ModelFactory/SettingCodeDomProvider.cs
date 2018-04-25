using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using KeelKit.Controls;
using KeelKit.Core;
using KeelKit.Core.Serialization;

namespace KeelKit.ModelFactory
{
    public partial class SettingCodeDomProvider : UserControl
    {
        private  LangCodeProvider CodeProviderRouter { get; set; }
        public SettingCodeDomProvider()
        {
            InitializeComponent();
           
        }
        public void SetInfo(LangCodeProvider _CodeProviderRouter)
       {
           CodeProviderRouter = _CodeProviderRouter;
           if (this.Site == null || this.Site.DesignMode == false)
           {

               LoadRouterInfo();
           }

       }
        public LangCodeProvider GetInfo()
        {
            return CodeProviderRouter;
        }
        private void LoadRouterInfo()
        {
            try
            {
                UpdateCodeDomProviders(false );
            }
            catch (Exception ex)
            {

                Common.ShowInfo("加载代码提供器时遇到问题"+ex.Message );
            }
            if (CodeProviderRouter == null)
            {
                if (KeelKit.Kit.SlnKeel != null && KeelKit.Kit.SlnKeel.CodeProviderRouter != null)
                {
                    CodeProviderRouter = KeelKit.Kit.SlnKeel.CodeProviderRouter;
                }
                else
                {
                    Common.ShowInfo("解决方案配置不正确!");
                   
                }
            }
            if (CodeProviderRouter != null)
            {
                try
                {
                    ReloadRouterInfo();
                    this.lstAsms.Items.Clear();
                    if (CodeProviderRouter.OtherProvider != null)
                    {
                        this.lstAsms.Items.AddRange(CodeProviderRouter.OtherProvider.ToArray());
                    }
                }
                catch (Exception)
                {

                    Common.ShowInfo("加载代码提供器信息时遇到问题!");
                }
            }

        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            try
            {
                UpdateCodeDomProviders(true );
                LoadRouterInfo();
            }
            catch (Exception ex)
            {
                Common.ShowInfo("强制更新提供器列表时遇到未预料的问题:" + ex.Message);
               
            }
            btnUpdate.Enabled = true ;
        }
       public static  List<ProviderInfo> ls = new List<ProviderInfo>();
        private void UpdateCodeDomProviders(bool must)
        {
            if (must ||  ls.Count ==0 )
            {
              
                if (CodeProviderRouter == null)
                {
                    CodeProviderRouter = new LangCodeProvider();
                    CodeProviderRouter.OtherProvider = new List<string>();
                }
                    ls = GetProviderList(CodeProviderRouter.OtherProvider.ToArray());
                    foreach (var item in Enum.GetNames(typeof(cfLangType)))
                    {
                        ProviderInfo pi = typeof(LangCodeProvider).InvokeMember(item, BindingFlags.GetProperty, null, Kit.GetDefaultCodeProviderRouter(), new object[] { }) as ProviderInfo;
                        if (!Exists(pi))
                        {
                            ls.Add(pi);
                        }
                    }
                
            }
            foreach (var item in Enum.GetNames(typeof(cfLangType)))
            {
                if (this.Controls.ContainsKey("cbx" + item))
                {
                    cbxCodeDomeProvider cbx = this.Controls["cbx" + item] as cbxCodeDomeProvider;
                    if (cbx != null)
                    {
                        cbx.UpdateCodeDomProvider(ls);
                    }
                }
            }
        }

        public bool Exists(ProviderInfo pix)
        {
            bool result = false;
            foreach (var item in ls)
            {
                result = item.TypeName == pix.TypeName;
                if (result) break;
            }
            return result;
        }
    
        public List<ProviderInfo> GetProviderList(string[] addasms)
        {
            List<ProviderInfo> lsx = new List<ProviderInfo>();
            lsx.Add(new ProviderInfo(null, null, "(None)"));
            // List<CodeDomProvider> lc = new List<CodeDomProvider>();
            List<System.Reflection.Assembly>  asms =new List<Assembly>( AppDomain.CurrentDomain.GetAssemblies());
            foreach (var item in addasms)
            {
                try
                {
                    asms.Add(System.Reflection.Assembly.LoadFile(item));
                }
                catch (Exception ex)
                {
                    Common.ShowInfo("加载手动添加的CodeDomProvide时遇到问题(不会影响下一步工作):"+ex.Message );
                }
            }
            foreach (Assembly assembly in asms)
            {
                try
                {
                    foreach (Type type in assembly.GetExportedTypes())
                    {
                        try
                        {
                            if (type.IsSubclassOf(typeof(CodeDomProvider)))
                            {
                                ProviderInfo pi = new ProviderInfo(assembly.FullName, assembly.Location, type.FullName);
                               
                                bool result=false ;
                                foreach (var item in lsx)
                                {
                                    result = item.TypeName == pi.TypeName;
                                    if (result)
                                    {
                                        break;
                                    }
                                }
                                if (!result)
                                {
                                    lsx.Add(pi);
                                }
                                //CodeDomProvider codedomprovider = (CodeDomProvider)assembly.CreateInstance(type.FullName);
                                //lc.Add(codedomprovider);
                                //System.Diagnostics.Debug.WriteLine(type.FullName);

                            }
                        }
                        catch (Exception)
                        {


                        }

                    }
                }
                catch (Exception)
                {


                }
            }
            return lsx;
        }

        private void cbxCodeDomeProvider_SelectedCodeDomProvider(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                cbxCodeDomeProvider cbx = sender as cbxCodeDomeProvider;

                if (CodeProviderRouter == null)
                {
                    ResetRouterInfo();
                }
                typeof(LangCodeProvider).InvokeMember(cbx.Name.Substring(3), BindingFlags.SetProperty, null, CodeProviderRouter, new object[] { cbx.ProviderInfo });

            }
            catch (Exception ex)
            {
                Common.ShowInfo("尝试更改CodeDomProvider时遇到问题"+ex.Message );
             
            }       
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            try
            {
                  ResetRouterInfo();
            }
            catch (Exception)
            {
                
               
            }
            btnReset.Enabled = true ;
        }

        private void ResetRouterInfo()
        {
            CodeProviderRouter = XMLRW<LangCodeProvider>.Read(Properties.Resources.CodeProviderRouter);
            ReloadRouterInfo();
        }

        private void ReloadRouterInfo()
        {
            foreach (var item in Enum.GetNames(typeof(cfLangType)))
            {
                if (this.Controls.ContainsKey("cbx" + item))
                {
                    cbxCodeDomeProvider cbx = this.Controls["cbx" + item] as cbxCodeDomeProvider;
                    if (cbx != null)
                    {
                        cbx.ProviderInfo = typeof(LangCodeProvider).InvokeMember(item, BindingFlags.GetProperty, null, CodeProviderRouter, new object[] { }) as ProviderInfo;
                        Application.DoEvents();
                    }
                    Application.DoEvents();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstAsms.SelectedIndex >= 0)
            {
                try
                {
                    CodeProviderRouter.OtherProvider.RemoveAt(lstAsms.SelectedIndex);
                    lstAsms.Items.RemoveAt(lstAsms.SelectedIndex);
                  
                }
                catch (Exception)
                {
                    
                    
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lstAsms.Items.Contains(txtAddtext.Text.Trim()))
                {
                    if (Kit.SearchFile(txtAddtext.Text.Trim()) != null)
                    {

                        lstAsms.Items.Add(txtAddtext.Text);
                        CodeProviderRouter.OtherProvider.Add(txtAddtext.Text);
                        txtAddtext.Text = "";
                       
                    }
                }
            }
            catch (Exception)
            { 
            }
        }

        
    }

}
