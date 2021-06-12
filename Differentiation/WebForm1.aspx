<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Differentiation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
             <div style="height: 30px; width:auto; background-color:lightpink;">
                     <marquee direction="right" onmouseover="this.stop()" onmouseout="this.start()">
                        <asp:Label ID="lblMarquee" runat="server" Text="Differentiation 2021"></asp:Label>
                    </marquee>
            </div>
        </div>
    </form>
</body>
</html>
