<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudentData.aspx.cs" Inherits="Differentiation.AddStudentData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <meta charset="utf-8"/>
    <link href="Design/AddStudent/bootstrap-icons.css" rel="stylesheet" />
    <link href="Design/AddStudent/bootstrap.css" rel="stylesheet" />
    <link href="Design/AddStudent/Text.css" rel="stylesheet" />

    <script src="Design/JavaScript/bootstrap.bundle.js"></script>
    <title>Import Student Information</title>
</head>
<body>  
     
    <form id="form1" runat="server">
        <asp:Button ID="LogOut" runat="server" Text="LogOut"  class="btn btn-danger" OnClick="Logout_Click" Width="104px" />
         <center> 
        <div style="padding-top:100px" >
            <asp:FileUpload ID="FileUploadStudent" class="btn btn-secondary btn-lg" runat="server" Width="136px" />
            <br />  
            <asp:Button ID="ImpInfoStd" runat="server" Text="Import Information Student" class="btn btn-primary" OnClick="ImpInfoStd_Click1" Height="37px" Width="217px" />   
                <br />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>      
                <br />
                <br />
             <asp:FileUpload ID="FileUploadMark" class="btn btn-secondary btn-lg" runat="server" Width="136px" />        
            <br />
            <asp:Button ID="Mark" runat="server" OnClick="Mark_Click" class="btn btn-primary" Text="Import Student Mark" Height="37px" />               
            <br />              
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>            
            <br />              
          
            <br />
                         <asp:FileUpload ID="FileUploadFactuly" class="btn btn-secondary btn-lg"  runat="server" Width="136px" />        
            <br />       
            <asp:Button ID="btnAddFactuly" runat="server" OnClick="btnAddFactuly_Click" class="btn btn-primary" Text="Import Factuly" Height="37px" />
                <br />
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
              <br />
                </div>                 
              <br />
              <asp:Button ID="btnMarquee" runat="server" Text="Add News" class="btn btn-danger" OnClick="btnMarquee_Click1" Height="46px" Width="217px" />

              &nbsp;&nbsp;
              <asp:TextBox ID="txtMarquee"  runat="server" Height="32px" TextMode="MultiLine" Width="323px"></asp:TextBox>

              <br />
              <br />
        <asp:Button ID="OpenPage" runat="server" Text="To Open the Web page"  class="btn btn-primary" BackColor="Green" OnClick="open_Click1" Height="37px" Width="217px" />
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="closePage" runat="server" Text="To close the web page" class="btn  btn-dark" OnClick="close_Click1" Height="37px" Width="217px" />
        &nbsp;&nbsp;&nbsp;
              <br />
              <br />
        <asp:Button ID="Statistics" runat="server" Text="Processing" class="btn btn-primary" OnClick="Statistics_Click1" Height="37px" Width="217px" />
             </center>
    </form>
</body>

</html>
