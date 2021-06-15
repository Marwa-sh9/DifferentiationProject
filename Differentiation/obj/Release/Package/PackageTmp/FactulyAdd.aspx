<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FactulyAdd.aspx.cs" Inherits="Differentiation.FactulyAdd" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <meta charset="utf-8"/>
    <link href="Design/AddStudent/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="Design/FactulyAdd/StyleSheet1.css"/>
    <script src="Design/JavaScript/bootstrap.bundle.js"></script>
    <title>Factuly Add</title>
</head>
<body style="background-attachment:fixed;background-size:1540px 850px;
             background-repeat:no-repeat;background-position:center;background-image:linear-gradient(white,teal)">
    <form id="form1" runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" >
       <a id="n1" class="navbar-brand" href="#" style="margin-right:10px;">
         <img  src="Design/Home/logo.png" style="width: 15%;margin-right:20px;"/>
            University Differentiation
       </a>
  <div id="div1" class="container-fluid">
    <a class="navbar-brand" href="default.aspx">Home</a>
      <ul class="navbar-nav me-auto mb-2 mb-auto">
          <asp:Button ID="Logout" runat="server" Text="Logout" CssClass="btn btn-danger bt-md" Style="margin-left:840px;" OnClick="Logout_Click" />
    </ul>
  </div>
</nav>
        <center>
        <div style="padding-top:90px">
        </div>
        <div>
            <asp:GridView ID="GridView1" AllowPaging="True" CellPadding="4" PageSize="10" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="675px" OnPageIndexChanging="GridView1_PageIndexChanging">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelect"  runat="server" OnCheckedChanged="ChkSelect_CheckedChanged" AutoPostBack="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField  HeaderText="رمز الرغبة" DataField="Factuly_Id" />
                    <asp:BoundField  HeaderText="اسم الكلية" DataField="Factuly_Name" />
                    <asp:BoundField  HeaderText="الحد الأدنى للمجموع" DataField="Min_Mark_Total" />
                    <asp:BoundField  HeaderText="المحافظة" DataField="University_Name" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="GridView2" AutoGenerateColumns="false" EmptyDataText="لم يضاف رغبات بعد" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="673px">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
                <Columns>
                     <asp:BoundField  HeaderText="رمز الكلية" DataField="Factuly_Id" />
                    <asp:BoundField  HeaderText="اسم الكلية" DataField="Factuly_Name" />
                    <asp:BoundField  HeaderText="الحد الأدنى للمجموع" DataField="Min_Mark_Total" />
                    <asp:BoundField  HeaderText="المحافظة" DataField="University_Name" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label3" ForeColor="Red" runat="server" Text=""></asp:Label>

            <br />
           <asp:Label ID="Label2" ForeColor="Red" runat="server" Text=""></asp:Label>

            <br />
         <asp:Button ID="AddToDataBase" runat="server" Text="حفظ الرغبات" class="btn btn-primary" OnClick="AddToDataBase_Click1" Height="37px" Width="217px" />
            <asp:Label ID="Label1" ForeColor="Red" runat="server" Text=""></asp:Label>
            <br />
            <br />
                     <asp:Button ID="ShowDisers" runat="server" Text="عرض الرغبات" class="btn btn-primary"  BackColor="#990000" OnClick="ShowDisers_Click1" Height="37px" Width="217px" />

        </div>
            </center>
    </form>
</body>
</html>