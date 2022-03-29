<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="adminstratorManageRegistrations.aspx.vb" Inherits="FoodOnClick.adminstratorManageRegistrations_aspxt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Approval</h1>

    <table>
        <tr>
            <td>
                <h4>Total Pending Application</h4>
            </td>
            <td>
                <asp:Label ID="totalPendingCase" runat="server"></asp:Label></td>
        </tr>
    </table>

    <br />
    <br />
    <div style="overflow-x: auto; text-align: center; width: 100%">
        <div style="width:40%;margin:0 auto">
        <asp:Repeater runat="server" ID="rptUser" OnItemDataBound="rptUser_ItemDataBound" OnItemCommand="rptUser_ItemCommand" EnableViewState="false">
            <ItemTemplate>
                <div>
                    <asp:Label runat="server" ID="lblUserId" Text='<%#Eval("userId") %>'></asp:Label>
                    <asp:Label runat="server" ID="lblRestaurantLogo" Text=" Restaurant Logo :"></asp:Label>
                    <asp:HyperLink runat="server" ID="restaurantLogo"></asp:HyperLink>
                    <asp:Label runat="server" ID="lblBusinessLicense" Text="Business License :"></asp:Label>
                    <asp:HyperLink runat="server" ID="businessLicense"></asp:HyperLink>
                    <asp:Label runat="server" ID="lblHalal" Text="Halal :"></asp:Label>
                    <asp:HyperLink runat="server" ID="halal"></asp:HyperLink>
                    <asp:Button ID="systemAdminRegistration_Approve" Text="Approve" CommandName="Approve" runat="server" CommandArgument='<%#Eval("userId") %>'/>
                    <asp:Button ID="systemAdminRegistration_Reject" Text="Reject" CommandName="Reject" runat="server" CommandArgument='<%#Eval("userId") %>'/>
                </div>
                <br />
            </ItemTemplate>
        </asp:Repeater>
            </div>
    </div>
    <%--<table>
        <tr>
            <td>
                <h4>UserID</h4>
            </td>
            <td>
                <asp:Label ID="document_useriID" runat="server"></asp:Label></td>
        </tr>
    </table>


    <table>
        <tr>
            <td>
                <h2>Type</h2>
            </td>
            <td>
                <h2>URL</h2>
            </td>
        </tr>
        <tr>
            <td>Restaurant Logo</td>
            <td>
                <asp:Label ID="document_restaurantLogo" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Business License</td>
            <td>
                <asp:Label ID="document_businessLicense" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Halal</td>
            <td>
                <asp:Label ID="document_halal" runat="server"></asp:Label></td>
        </tr>

    </table>--%>

<%--    <table>
        <tr>
            <td>
                <asp:Button ID="systemAdminRegistration_Approve" Text="Approve" runat="server" /></td>
            <td>
                <asp:Button ID="systemAdminRegistration_Reject" Text="Reject" runat="server" /></td>
        </tr>
    </table>--%>

</asp:Content>
