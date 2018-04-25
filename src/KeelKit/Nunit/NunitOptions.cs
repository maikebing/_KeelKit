using System.Windows.Forms;
using KeelKit.Core.Serialization;

namespace KeelKit.Nunit
{
    public partial class NunitOptions : UserControl
    {
        public NunitOptions()
        {
            InitializeComponent();
        }

        public void SetNunit(  NUnitSetting  ns  )
        {
            if (ns == null) ns = new NUnitSetting();
            chkEnable.Checked  = ns.Enable;
            cbxNunitProject.ProjectName = ns.NunitProject;
            txtNunit.Text = ns.NUnitRoot;
        }
        public NUnitSetting GetNunit()
        {
            NUnitSetting ns = new NUnitSetting();
            ns.Enable = chkEnable.Checked ;
            ns.NunitProject = cbxNunitProject.ProjectName;
            ns.NUnitRoot = txtNunit.Text;
            return ns;
        }
        
    }
}
