﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Click +=new EventHandler(Button1_Click); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "afsdasfd";
    }
    
}
