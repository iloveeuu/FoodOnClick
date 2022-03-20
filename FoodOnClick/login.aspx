<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="login.aspx.vb" Inherits="FoodOnClick.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
        <tr>
            <td>Email:
            </td>
            <td>
                <asp:TextBox ID="txtUser" runat="server" TextMode="Email"></asp:TextBox>
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
            <td>
                
            </td>
            <td>
                <asp:HyperLink runat="server" ID="hpForgetPassword" NavigateUrl="~/login.aspx" Text="Forget Password"></asp:HyperLink></td>

        </tr>
        <tr>
            <td colspan="2"><asp:Label runat="server" ID="lblWrong" ForeColor="Red" Text="Wrong username/password" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Style="width: 100%" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" Style="width: 100%" />
            </td>
        </tr>
    </table>
</asp:Content>
