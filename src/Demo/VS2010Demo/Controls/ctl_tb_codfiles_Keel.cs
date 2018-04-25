using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls
{
    public partial class ctl_tb_codfiles_Keel : UserControl
    {
        public ctl_tb_codfiles_Keel()
        {
            InitializeComponent();
        }

        private void txtfilemd5_TextChanged(object sender, EventArgs e)
        {
            this.txtfilemd5.Text = "asdf";
            
        }
    }
}
