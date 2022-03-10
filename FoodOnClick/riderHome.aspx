<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="riderHome.aspx.vb" Inherits="FoodOnClick.riderHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="3">
                <asp:Button runat="server" ID="btnStartStopServices" Text="Start/Stop Delivery" />
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td><asp:Button runat="server" ID="btnNotifySupport" Text="Notify Support" OnClick="btnNotifySupport_Click" /></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td><asp:Button runat="server" ID="btnSearch" Text="Search"/></td>
        </tr>
        <tr>
            <td colspan="3">

            </td>
        </tr>
    </table>
</asp:Content>
