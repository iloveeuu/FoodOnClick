<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="login.aspx.vb" Inherits="FoodOnClick.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/design.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
        <tr>
            <td>Username:
            </td>
            <td>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink runat="server" ID="hpForgetPassword" NavigateUrl="~/login.aspx" Text="Forget Password"></asp:HyperLink>
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
            <td colspan="2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" style="width:100%"/>
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
