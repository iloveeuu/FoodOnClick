<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="adminstratorManageRegistrations.aspx.vb" Inherits="FoodOnClick.adminstratorManageRegistrations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Approval</h1>
    <h1>Total Pending Approval Case</h1>
    <asp:Label ID="totalPendingCase" runat="server"></asp:Label>
    <br />
    <br />
    <asp:label ID="document_useriID" runat="server"></asp:label>
    <asp:button id="systemAdminRegistration_Approve" Text="Approve" runat="server"/>
    <asp:button id="systemAdminRegistration_Reject" Text="Reject" runat="server" />
    <table>
        <tr>
            <td><h2>Type</h2></td>        
            <td><h2>URL</h2></td>
        </tr>
        <tr>
            <td>Restaurant Logo</td>
            <td><asp:label ID="document_restaurantLogo" runat="server"></asp:label></td>
        </tr>
        <tr>
            <td>Business License</td>
            <td><asp:label ID="document_businessLicense" runat="server"></asp:label></td>
        </tr>
        <tr>
            <td>Halal</td>
            <td><asp:label ID="document_halal" runat="server"></asp:label></td>
        </tr>
    </table>
    


</asp:Content>
