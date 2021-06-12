<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs"
    Inherits="Differentiation.Registration" UnobtrusiveValidationMode="None" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <meta charset="utf-8" />    
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Design\Reg\StyleReg.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Enter Your ID_Number:</td>
                    <td>
                      <asp:TextBox ID="txtID_Number" runat="server"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ControlToValidate="txtID_Number"
                        ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                        ErrorMessage="Enter Your ID Number!" ValidationGroup="Save">
                    </asp:RequiredFieldValidator>
                </tr>
                <tr>
                <td>Enter Your IPO_Number:</td>
                <td>
                <asp:TextBox ID="txtIPO_Number" runat="server"></asp:TextBox></td>
              <asp:RequiredFieldValidator ControlToValidate="txtIPO_Number" Display="Dynamic"
                  ErrorMessage="Enter Your IPO Number!" ForeColor="Red" 
                  ID="RequiredFieldValidator2" runat="server" ValidationGroup="Save">
              </asp:RequiredFieldValidator>
                </tr>
                <tr>
               <td><asp:Label ID="lblStuValid" runat="server"></asp:Label></td>
                    <td>
                    <asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="Check" /></td>
                </tr>
                <tr>
                    <td>Enter Your Email:</td>
                    <td>
                    <asp:TextBox ID="txtStuEmail" runat="server"></asp:TextBox></td>
              <asp:RequiredFieldValidator ControlToValidate="txtStuEmail" Display="Dynamic"
                  ErrorMessage="Enter Your Email!" ForeColor="Red" 
                  ID="RequiredFieldValidator3" runat="server" ValidationGroup="Save">
              </asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td>Enter Your Password:</td>
                    <td>
                    <asp:TextBox type="password" ID="txtStuPass" runat="server"></asp:TextBox></td>
              <asp:RequiredFieldValidator ControlToValidate="txtStuPass" Display="Dynamic" 
                  ErrorMessage="Type Your Password!" ForeColor="Red" 
                  ID="RequiredFieldValidator4" runat="server" ValidationGroup="Save">
              </asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td>Re-enter Your Password:</td>
                    <td>
                    <asp:TextBox type="password" ID="txtStuRePass" runat="server"></asp:TextBox></td>
              <asp:RequiredFieldValidator ControlToValidate="txtStuRePass" Display="Dynamic" 
                  ErrorMessage="ReType Your Password!" ForeColor="Red" 
                  ID="RequiredFieldValidator5" runat="server" ValidationGroup="Save">
              </asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click"
                            Text="Register" ValidationGroup="Save" />
                    </td>
                    </tr>
            </table>
        </div>
    </form>

    <script src="Design/js/jquery-1.11.1.min.js"></script>
    <script src="Design/js1/bootstrap.min.js"></script>
</body>
</html>
