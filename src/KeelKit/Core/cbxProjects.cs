using System;
using System.Windows.Forms;

namespace KeelKit.Controls
{
    public partial class cbxProjects : UserControl
    {
        public cbxProjects()
        {
            InitializeComponent();
            UserControl1_Resize(null, null);
            if (Common.chDTE == null) return;
            try
            {
                cbxBase.Items.Clear();
                for (int i = 1; i <= Common.chDTE.Solution.Projects.Count; i++)
                {
                    cbxBase.Items.Add(Common.chDTE.Solution.Projects.Item(i).Name);
                }
            }
            catch (Exception)
            {


            }
        }
        public event EventHandler SelectedProject;

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            cbxBase.Top = 0;
            cbxBase.Left = 0;
            cbxBase.Width = this.Width;
            this.Height = cbxBase.Height;
        }
        public string ProjectName
        {
            get { return cbxBase.Text; }
            set { cbxBase.Text = value; }
        }

        private void cbxBase_SelectionChangeCommitted(object sender, EventArgs e)
        {
           if (SelectedProject !=null )
           {
               Application.DoEvents();
               SelectedProject(sender, e);
           }
        }

  
        
    }
}
