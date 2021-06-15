<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudentData.aspx.cs" Inherits="Differentiation.AddStudentData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <meta charset="utf-8"/>
    <link href="Design/AddStudent/bootstrap.css" rel="stylesheet" />
    <script src="Design/JavaScript/bootstrap.bundle.js"></script>
    <link href="Design/ShowDesired/StyleSheet1.css" rel="stylesheet" />
    <title>Import Student Information</title>
</head>
<body>  
     
    <form id="form1" runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" >
       <a id="n1" class="navbar-brand" href="#" style="margin-right:20px;">
         <img  src="Design/Home/logo.png" style="width: 15%;margin-right:10px;"/>
            University Differentiation
       </a>
  <div id="div1" class="container-fluid">
    <a class="navbar-brand" href="default.aspx">Home</a>
      <ul class="navbar-nav me-auto mb-2 mb-auto">
          <asp:Button ID="Button1" runat="server" Text="Logout" CssClass="btn btn-danger bt-md" 
              Style="margin-left:840px;" OnClick="Logout_Click" />
    </ul>
  </div>
</nav>
        <asp:Button ID="LogOut" runat="server" Text="LogOut"  class="btn btn-danger" 
            OnClick="Logout_Click" Width="104px" />
         <center> 
        <div style="padding-top:60px" >
            <asp:FileUpload ID="FileUploadStudent" class="btn btn-secondary btn-lg" runat="server"
                Width="360px" />
            <br />  
            <br />
            <asp:Button ID="ImpInfoStd" runat="server" Text="Import Information Student" 
                class="btn btn-primary" OnClick="ImpInfoStd_Click1" Height="37px" Width="217px" />   
                <br />
            <br />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>      
                <br />
                <br />
             <asp:FileUpload ID="FileUploadMark" class="btn btn-secondary btn-lg" runat="server" Width="360px" />        
            <br />
            <br />
            <asp:Button ID="Mark" runat="server" OnClick="Mark_Click" class="btn btn-primary"
                Text="Import Student Mark" Height="37px" />               
            <br />              
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>            
            <br />                       
            <br />
            <asp:FileUpload ID="FileUploadFactuly" class="btn btn-secondary btn-lg" runat="server" Width="360px" />        
            <br />
            <br />       
            <asp:Button ID="btnAddFactuly" runat="server" OnClick="btnAddFactuly_Click"
                class="btn btn-primary" Text="Import Factuly" Height="37px" />
                <br />
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
              <br />
                </div>                 
              <br />
        <asp:Button ID="Statistics" runat="server" Text="Processing" class="btn btn-primary"
            OnClick="Statistics_Click1" Height="37px" Width="217px" />
             </center>
    </form>
</body>

</html>
