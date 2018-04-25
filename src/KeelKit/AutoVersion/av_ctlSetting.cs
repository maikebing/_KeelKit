using System;
using System.ComponentModel;
using System.Windows.Forms;
using KeelKit.Serialization;

namespace KeelKit.AutoVersion
{
 
    public partial class av_ctlSetting : UserControl
    {
        public av_ctlSetting()
        {
            InitializeComponent();
        }
        AutoVersionSetting _Setting=null  ;
        [Browsable(false ) ]
        public AutoVersionSetting Setting
        {
            get
            {
                if (this.DesignMode) return null;
                if (_Setting == null) _Setting = new AutoVersionSetting();
                _Setting.OneVersion = this.chkAllInOne.Checked;
                _Setting.Enable = this.chkAutoVer.Checked;
                _Setting.RndBuildRev = this.chkVerRnd.Checked;
                if (rbbuild_Count.Checked) _Setting.buildVerType = VersionType.Counter;
                if (this.rbbuild_nocontrol.Checked) _Setting.buildVerType = VersionType.NoControl;
                if (this.rbrev_nocontrol.Checked) _Setting.revisionVerType = VersionType.NoControl;
                if (this.rbsvnrev.Checked) _Setting.revisionVerType = VersionType.SCV;
                _Setting.ProjectBase = this.cbxPjtsVer.ProjectName;
                _Setting.major = txtmajor.Text;
                _Setting.minor = txtminor.Text;
                if (rbTpl.Checked)
                {
                    _Setting.Kind = VersionKind.KVT;
                }
                else
                {
                    _Setting.Kind = VersionKind.Default;
                }
                if (this.rballdir .Checked)
                {
                    _Setting.searchOption = System.IO.SearchOption.AllDirectories ;
                }
                else 
                {
                    _Setting.searchOption = System.IO.SearchOption.TopDirectoryOnly ;
                }
                return _Setting;
            }


            set
            {
                _Setting = value;
                if (_Setting == null || _Setting.major ==null || _Setting.major.Trim ()==""  || _Setting.minor ==null || _Setting.minor.Trim()=="")
                {
                    if (this.DesignMode) return;
                  if  (_Setting == null)  _Setting = new AutoVersionSetting();
                  ReadProjectVers();
                }
                this.chkAllInOne.Checked = _Setting.OneVersion;
                this.chkAutoVer.Checked = _Setting.Enable;
                this.chkVerRnd.Checked = _Setting.RndBuildRev;
                UpdateVerstring();
                this.cbxPjtsVer.ProjectName  = _Setting.ProjectBase;
                this.rbbuild_Count.Checked = _Setting.buildVerType == VersionType.Counter;
                this.rbbuild_nocontrol.Checked = _Setting.buildVerType == VersionType.NoControl;
                this.rbrev_nocontrol.Checked = _Setting.revisionVerType == VersionType.NoControl;
                this.rbsvnrev.Checked = _Setting.revisionVerType == VersionType.SCV;
                if (_Setting.Kind == VersionKind.KVT)
                {
                    this.rbTpl.Checked = true;
                    this.rbauto.Checked = false;
                }
                else
                {
                    this.rbTpl.Checked = false ;
                    this.rbauto.Checked = true ;
                }
                switch (_Setting.searchOption)
                {
                    case System.IO.SearchOption.AllDirectories:
                        this.rballdir.Checked = true;
                        this.rbtopdir.Checked = false;
                        break;
                    case System.IO.SearchOption.TopDirectoryOnly:
                        this.rballdir.Checked = false ;
                        this.rbtopdir.Checked = true ;
                        break;
                    default:
                        break;
                }
                chkAutoVer_CheckedChanged(null, null);
                chkVerRnd_CheckedChanged(null, null);
            }

        }

        private void UpdateVerstring()
        {
            if (_Setting != null)
            {
                this.txtmajor.Text = _Setting.major;
                this.txtminor.Text = _Setting.minor;
            }
        }

        private void ReadProjectVers()
        {
            EnvDTE.Project pjt = null;
            if (_Setting.ProjectBase != null && _Setting.ProjectBase.Trim() != "")
            {
                pjt = Kit.GetProjectByName(_Setting.ProjectBase);
            }
            if (pjt != null)
            {
                object o = pjt.Properties.Item("AssemblyVersion").Value;
                string asmver = pjt.Properties.Item("AssemblyVersion").Value as string;
                string[] vary = asmver.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (vary.Length >= 1) _Setting.major = vary[0];
                if (vary.Length >= 2) _Setting.minor = vary[1];
                if (vary.Length >= 3) _Setting.build = vary[2];
                if (vary.Length >= 4) _Setting.revision = vary[3];
                if (_Setting.build != null && _Setting.build.Contains("*")) _Setting.RndBuildRev = true;
            }
        }

        private void chkAutoVer_CheckedChanged(object sender, EventArgs e)
        {
            gbVer.Enabled = chkAutoVer.Checked;
            if (sender != null   )
            {
                ReadProjectVers();
             
            }
        }

        private void chkVerRnd_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = !chkVerRnd.Checked;
            panel2.Enabled = !chkVerRnd.Checked;
        }

        private void cbxPjtsVer_SelectedProject(object sender, EventArgs e)
        {
            if (_Setting != null)
            {
                _Setting.ProjectBase = cbxPjtsVer.ProjectName;
            }
            ReadProjectVers();
            UpdateVerstring();
        }

        private void rbTpl_CheckedChanged(object sender, EventArgs e)
        {
            gbkvt.Enabled = rbTpl.Checked;
        }

       
    }
}
