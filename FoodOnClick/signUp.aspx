<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="signUp.aspx.vb" Inherits="FoodOnClick.signUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Sign Up Food On Click</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="signup-page" runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <h3>Sign Up form</h3>
        <br />
        <hr />
        <br />
        <table id="tableStyle">
            <tr>
                <td>Email:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
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
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
          <%--  <tr>
                <td>User Type:
                </td>
                <td>
                    <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem Value="Customer" Selected="True">Customer</asp:ListItem>
                        <asp:ListItem Value="Restaurant">Restaurant</asp:ListItem>
                        <asp:ListItem Value="Rider">Rider</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>--%>
            <tr>
                <td colspan=" 2">
                    <br />
                    <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" Style="width: 100%" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="width: 100%" />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
