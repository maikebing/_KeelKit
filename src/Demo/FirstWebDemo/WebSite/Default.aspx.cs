﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirstWebDemo.Mode;

public partial class _Default : System.Web.UI.Page
{
 
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Keel.DBHelper<Table_1> dbt = new Keel.DBHelper<FirstWebDemo.Mode.Table_1>();
        Table_1 t = dbt.Distill(this.ctl_Table_1_Keel1);
        dbt.Fill(this.ctl_Table_1_Keel2, t);
    }
}
