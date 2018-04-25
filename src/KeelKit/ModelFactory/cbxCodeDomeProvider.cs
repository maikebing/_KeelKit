using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeelKit.Core.Serialization;

namespace KeelKit.Controls
{
    public partial class cbxCodeDomeProvider : UserControl
    {
        public cbxCodeDomeProvider()
        {
            InitializeComponent();
            UserControl1_Resize(null, null);
            if (Common.chDTE == null) return;
 
        }

        public void UpdateCodeDomProvider(List<ProviderInfo> ls)
        {
            providerInfoBindingSource.DataSource = ls;  
        }
        public event EventHandler SelectedProject;

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            cbxBase.Top = 0;
            cbxBase.Left = 0;
            cbxBase.Width = this.Width;
            this.Height = cbxBase.Height;
        }
        public ProviderInfo ProviderInfo
        {
            get
            {
                return providerInfoBindingSource.Current  as ProviderInfo; 
            }
            set
            {
                try
                {
                    if (this.Site != null && this.Site.DesignMode) return;
            
                    for (int i = 0; i < providerInfoBindingSource.Count ; i++)
                    {
                        if ((providerInfoBindingSource[i] as ProviderInfo).TypeName == value.TypeName)
                        {
                            providerInfoBindingSource.Position = i;
                            break;
                        }
                    }
                    this.Update();
                }
                catch (Exception)
                {
                }
            }
        }
  
        private void cbxBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Site != null && this.Site.DesignMode) return;
            if (SelectedProject != null)
            {
                 SelectedProject( this , e);
            }
        }

  
        
    }
}
