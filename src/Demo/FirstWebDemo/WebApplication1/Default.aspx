<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<%@ Register src="ctl_Table_1_Keel.ascx" tagname="ctl_Table_1_Keel" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:ctl_Table_1_Keel ID="ctl_Table_1_Keel1" runat="server" />
    
    </div>
    <uc1:ctl_Table_1_Keel ID="ctl_Table_1_Keel2" runat="server" />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
