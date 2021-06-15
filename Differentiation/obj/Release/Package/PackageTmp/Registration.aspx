<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs"
    Inherits="Differentiation.Registration" UnobtrusiveValidationMode="None" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <meta charset="utf-8" />    
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"
        integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
        crossorigin="anonymous"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Design/Content/bootstrap.min.css" rel="stylesheet"  />
    <link href="Design/Reg/StyleSheet2.css" rel="stylesheet" />
</head>
<body style="background-image:linear-gradient(white , teal)">
    <form id="form1" runat="server">
<div>
    <!-- Navbar -->
 <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" >
  <div class="container-fluid">

    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
          <li>
         <img src="Design/Home/logo.png" style=" width: 90%; height:90%; "/>
                  </li>
        <li class="nav-item">

          <a class="nav-link active" href="default.aspx" style="margin-left:30px;">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link active" style="margin-left:10px;" href="LogIn.aspx">LogIn</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
    <!-- // Navbar -->
        
    <div style="margin-left:150px; margin-top:40px;margin-right:120px;">
       
        <h1>Student Registration</h1>
        <br />
        <br />
        <br />
        <br />
        <img src="Design/Reg/V.png" />
        <br />
       <br />
        <label>Enter Your ID_Number:</label>
        <br />
        <br />
        <asp:TextBox ID="txtID_Number" runat="server" class="form-control" placeholder="ID" Width="515px" Height="50px" style="border-radius:150px;"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="txtID_Number" ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Enter Your ID Number!" ValidationGroup="Save">
        </asp:RequiredFieldValidator>
        <br />
        <br />
        <label>Enter Your IPO_Number:</label>
        <br />
        <br />
        <asp:TextBox ID="txtIPO_Number" runat="server" class="form-control" placeholder="IPO Number" Width="515px" Height="50px" style="border-radius:150px;"></asp:TextBox>

        <asp:RequiredFieldValidator ControlToValidate="txtIPO_Number" Display="Dynamic" ErrorMessage="Enter Your IPO Number!" ForeColor="Red"
            ID="RequiredFieldValidator2" runat="server" ValidationGroup="Save"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblStuValid" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnCheck" runat="server" class="btn btn-primary btn-lg" OnClick="btnCheck_Click" Text="Check" />
        <br />
        <br />
        <br />
        </div>
    <br />
    <hr />
    <br />
    <div style="margin-left:150px; margin-top:30px;margin-right:100px;">
        <img id="img2" src="Design/Reg/reg.png" />
           <label>Enter Your Email:</label>
           <br />
           <br />
               <asp:TextBox ID="txtStuEmail" runat="server" CssClass="form-control"
                   placeholder="@Email.com" Width="515px" Height="50px" style="border-radius:150px;">
               </asp:TextBox>
               <asp:RequiredFieldValidator ControlToValidate="txtStuEmail" Display="Dynamic" 
                   ErrorMessage="Enter Your Email!" ForeColor="Red" 
                   ID="RequiredFieldValidator3" runat="server" ValidationGroup="Save">
               </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ControlToValidate="txtStuEmail" ErrorMessage="RegularExpressionValidator" ForeColor="Red"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
        </asp:RegularExpressionValidator>
             <br />
           <br />
             <label>Enter Your Password:</label>
           <br />
           <br />
               <asp:TextBox ID="txtStuPass" type="password" runat="server" CssClass="form-control"
                   placeholder="Password" Width="515px" Height="50px" style="border-radius:150px;">
               </asp:TextBox>
              
        <asp:RequiredFieldValidator ControlToValidate="txtStuPass" Display="Dynamic"
            ErrorMessage="Enter Your Password!" ForeColor="Red" 
                                           ID="RequiredFieldValidator4" runat="server" ValidationGroup="Save">
               </asp:RequiredFieldValidator>
             <br />
           <br />
             <label>Re-enter Your Password:</label>    
           <br />
                   <asp:TextBox ID="txtStuRePass" type="password" runat="server" CssClass="form-control" placeholder="Re-Password" Width="515px" Height="50px" style="border-radius:150px;"></asp:TextBox>
                   <asp:RequiredFieldValidator ControlToValidate="txtStuRePass" Display="Dynamic" ErrorMessage="Re Your Password!" ForeColor="Red" 
                                               ID="RequiredFieldValidator5" runat="server" ValidationGroup="Save">
                   </asp:RequiredFieldValidator>
       <br />
       <br />
         <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-danger btn-lg" OnClick="btnRegister_Click" Text="Register" ValidationGroup="Save" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" class="btn btn-link btn-lg" Text="You Have An Account, Press Here!" ForeColor="White"></asp:Button>
       <br />
       <br />
       <br />
       <br />
      </div>
     </div>
   </form>
    
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="Design/js/jquery-1.11.1.min.js"></script>
    <script src="Design/js1/bootstrap.min.js"></script>
</body>
</html>
