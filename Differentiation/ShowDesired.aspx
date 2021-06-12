<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDesired.aspx.cs" Inherits="Differentiation.ShowDesired" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8"/>
    <link href="Design/AddStudent/bootstrap-icons.css" rel="stylesheet" />
    <link href="Design/AddStudent/bootstrap.css" rel="stylesheet" />
    <link href="Design/AddStudent/Text.css" rel="stylesheet" />

    <script src="Design/JavaScript/bootstrap.bundle.js"></script>
    <title>Show Desires</title>
    </head>
<body>
      
    <form id="form1" runat="server">
                        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
  <div id="div1" class="container-fluid">
    <a class="navbar-brand" href="#">Home</a>
      <ul class="navbar-nav me-auto mb-2 mb-auto">
        <li class="nav-item">
        <a class="nav-link active" aria-current="page" href="LogIn.aspx">LogIn</a>
      </li>
    </ul>
  </div>
</nav>
        <div>

        </div>
        <center>
    <div style="padding-top:100px">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" CellSpacing="2" 
            OnRowCommand="GridView1_RowCommand1">
            <Columns>
                 <asp:TemplateField>
                        <ItemTemplate>
                           <%-- <asp:LinkButton ID="lbEdit" CommandArgument='<%# Eval("Factuly_Id") %>'
                                 CommandName="EditRow" ForeColor="#8c4510" runat="server">
                               _تعديل ترتيب الرغبة __
                            </asp:LinkButton>--%>
                             <asp:Button runat="server" Text="تعديل ترتيب الرغبة" ForeColor="#8c4510" ID="lbEdit"
                                 CommandName="EditRow" CommandArgument='<%# Eval("Factuly_Id") %>' />
                                 <asp:Button Text="حذف الرغبة" ID="lbDelete" CommandArgument='<%# Bind("Factuly_Id") %>'
                                 CommandName="DeleteRow" ForeColor="#8c4510" runat="server" />
                            <%-- <asp:LinkButton ID="lbDelete" CommandArgument='<%# Bind("Factuly_Id") %>'
                                 CommandName="DeleteRow" ForeColor="#8c4510" runat="server">
                                حذف الرغبة
                            </asp:LinkButton>--%>
                        </ItemTemplate>
                        <EditItemTemplate>
                       <%--        <asp:LinkButton ID="lbUpdate" CommandArgument='<%# Eval("Factuly_Id") %>'
                                 CommandName="UpdateRow" ForeColor="#8c4510" runat="server">
                                Update
                            </asp:LinkButton>--%>
                            <asp:Button Text="حفظ" ID="lbUpdate" CommandArgument='<%# Eval("Factuly_Id") %>'
                                 CommandName="UpdateRow" ForeColor="#8c4510" runat="server" />
                <%--                   <asp:LinkButton ID="lbCancel" CommandArgument='<%# Bind("Factuly_Id") %>'
                                 CommandName="CancelRow" ForeColor="#8c4510" runat="server">
                                Cancel
                            </asp:LinkButton>--%>
                            <asp:Button Text="إلغاء" ID="lbCancel" CommandArgument='<%# Bind("Factuly_Id") %>'
                                 CommandName="CancelRow" ForeColor="#8c4510" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="رمز الكلية" InsertVisible="False" SortExpression="Factuly_Id">
                    <EditItemTemplate>
                        <asp:Label ID="id1" runat="server" Text='<%# Bind("Factuly_Id") %>'></asp:Label>
                        <%--<asp:TextBox ID="TextBox1" ReadOnly="true"  runat="server" Text='<%# Bind("Factuly_Id") %>'>
                        </asp:TextBox>--%>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="id2"  runat="server" Text='<%# Bind("Factuly_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ترتيب الرغبات" SortExpression="Desire_Sequence">
                    <EditItemTemplate>
                        <asp:DropDownList ID="drp1" runat="server"
                            SelectedValue='<%# Bind("Desire_Id") %>'>
<%--                            <asp:ListItem>ترتيب الرغبة</asp:ListItem>--%>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Desire_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="اسم الكلية" InsertVisible="False" SortExpression="Factuly_Name">
                    <EditItemTemplate>
                        <asp:Label ID="NameF" runat="server" Text='<%# Bind("Factuly_Name") %>'></asp:Label>
                        <%--<asp:TextBox ID="TextBox1" ReadOnly="true"  runat="server" Text='<%# Bind("Factuly_Id") %>'>
                        </asp:TextBox>--%>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="NameF1"  runat="server" Text='<%# Bind("Factuly_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
                    </div>
            <div style="padding-top:100px">
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false"
        BackColor="#DEBA84" 
        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3"
        Width="16px" CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510"  />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
         <Columns>
             <asp:BoundField  HeaderText="الرقم الوطني" DataField="Id_Number" />
             <asp:BoundField  HeaderText="رقم الاكتتاب" DataField="IPO_Number" />
             <asp:BoundField  HeaderText="الاسم الكامل" DataField="Student_Full_Name" />
             <asp:BoundField  HeaderText="اسم الأم" DataField="Student_Mother_Name" />
             <asp:BoundField  HeaderText="الجنس" DataField="Gender" />
             <asp:BoundField  HeaderText="تاريخ الميلاد" DataField="Date_Of_Birth" />
             <asp:BoundField  HeaderText="الجنسية" DataField="Student_Nationality" />
             <asp:BoundField  HeaderText="سنة الشهادة" DataField="year" />
             <asp:BoundField  HeaderText="مصدر الشهادة" DataField="Source" />
             <asp:BoundField  HeaderText="العنوان" DataField="Address" />
             <asp:BoundField  HeaderText="رقم الهاتف"  DataField="Phone" />
             <asp:BoundField  HeaderText="رياضيات"  DataField="Maths" />
             <asp:BoundField  HeaderText="فيزياء"  DataField="physics" />
             <asp:BoundField  HeaderText="الكيمياء"  DataField="chemistry" />
             <asp:BoundField  HeaderText="لغة الاجنبية"  DataField="English" />
             <asp:BoundField  HeaderText="لغة الفرنسية"  DataField="French" />
             <asp:BoundField  HeaderText="اللغة العربية"  DataField="Arabic" />
             <asp:BoundField  HeaderText="القومية"  DataField="National" />
             <asp:BoundField  HeaderText="الديانة"  DataField="Religious" />
             <asp:BoundField  HeaderText="العلوم"  DataField="Sciences" />
             <asp:BoundField  HeaderText="المجموع الكلي"  DataField="Mark_Total" />
                </Columns>
        </asp:GridView>
    </div>
            <asp:Button ID="ShowFaculy" runat="server" Text="عرض الكليات" class="btn btn-primary" OnClick="ShowFactuly_Click1" Height="37px" Width="217px" />
            </center>
    </form>
</body>
</html>
