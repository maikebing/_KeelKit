using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQL2KDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Keel.DBHelper<Model.Customers> ddd = new Keel.DBHelper<SQL2KDemo.Model.Customers>();
        private void button1_Click(object sender, EventArgs e)
        {
           
            this.customersBindingSource.DataSource = ddd.SelectEntitys();
        }

        private void customersBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ddd.Fill( this.ctl_Customers_Keel1,(this.customersBindingSource.Current as Model.Customers ));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ddd.Update(ddd.Distill(this.ctl_Customers_Keel1));
            button1_Click(null, null);
        }
    }
}
