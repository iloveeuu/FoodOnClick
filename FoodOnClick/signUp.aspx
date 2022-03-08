<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="signUp.aspx.vb" Inherits="FoodOnClick.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up Food On Click</title>
    <link href="CSS/design.css" rel="stylesheet" />
</head>
<body>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <h1>Food On Click</h1>
    <h3>Sign Up</h3>
    <br />
    <hr />
    <br />
    <form id="form2" runat="server">
        <table id="tableStyle">
            <tr>
                <td>Username:
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>First Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Last Name:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contact No:
                </td>
                <td>
                    <asp:TextBox ID="txtContactNo" runat="server" TextMode="Phone"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender :
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonM" GroupName="gender" runat="server" Text="Male" />
                    <asp:RadioButton ID="RadioButtonF" GroupName="gender" runat="server" Text="Female" />           
                </td>
            </tr>
            <tr>
                <td>Date Of Birth :
                </td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>Address :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>User Type:
                </td>
                <td>
                    <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem Value="Customer" Selected="True">Customer</asp:ListItem>
                        <asp:ListItem Value="Restaurant">Restaurant</asp:ListItem>
                        <asp:ListItem Value="Delivery Rider">Rider</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" />
                </td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
