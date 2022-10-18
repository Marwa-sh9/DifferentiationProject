<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs"
     EnableViewState="true" ViewStateMode="Enabled" Inherits="Differentiation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <%--<asp:ListItem Text="English" Value="1"></asp:ListItem>
                <asp:ListItem Text="French" Value="2"></asp:ListItem>--%>
            </asp:RadioButtonList>
            

            
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style2" Height="20px" Width="77px">
        </asp:DropDownList>
          
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" 
                style="width: 56px" />
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>

        </div>
    </form>
</body>
</html>
