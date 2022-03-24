<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchOrderSelection.aspx.vb" Inherits="FoodOnClick.branchOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableStyle">
        <tr>
            <td><asp:Button runat="server" ID="btnHome" Text="Home" OnClick="btnHome_Click"/></td>
        </tr>
        <tr>
            <td><h2>Select order type</h2></td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="btnOrder" OnClick="btnOrder_Click"  Text="Orders"/></td>
            <td><asp:Button runat="server" ID="btnRecurring" OnClick="btnRecurring_Click" Text="Recurring Order"/></td>
        </tr>
    </table>
</asp:Content>
