<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<%@ Register src="ctl_Table_1_Keel.ascx" tagname="ctl_Table_1_Keel" tagprefix="uc3" %>
<%@ Register src="ctl_tb_codfiles_Keel.ascx" tagname="ctl_tb_codfiles_Keel" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <uc3:ctl_Table_1_Keel ID="ctl_Table_1_Keel1" runat="server" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
            Text="Button" />
    </p>
    <uc3:ctl_Table_1_Keel ID="ctl_Table_1_Keel2" runat="server" />
    </form>
</body>
</html>
