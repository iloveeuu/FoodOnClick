<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="forgetPassword.aspx.vb" Inherits="FoodOnClick.forgetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableStyle">
        <tr>
            <td colspan="3">
                <h1>Forget Password</h1>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox runat="server" ID="txtEmail" TextMode="Email"></asp:TextBox></td>
            <td><asp:Button runat="server" ID="btnReset" Text="Reset Password" OnClick="btnReset_Click"/></td>
        </tr>
    </table>
</asp:Content>
