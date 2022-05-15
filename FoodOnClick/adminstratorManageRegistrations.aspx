<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="adminstratorManageRegistrations.aspx.vb" Inherits="FoodOnClick.adminstratorManageRegistrations_aspxt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Approval for Restaurant</h1>

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
        <div style="width:80%;margin:0 auto">
        <asp:Repeater  runat="server" ID="rptUser" OnItemDataBound="rptUser_ItemDataBound" OnItemCommand="rptUser_ItemCommand" EnableViewState="false">
             <HeaderTemplate>
                   <table style="width:100%" border="1">
                       <tr>
                           <th width="5%">UserID</th>
                           <th width="5%">FirstName</th>
                           <th width="5%">LastName</th>
                           <th width="10%">PhoneNumber</th>
                           <th width="10%">Email</th>
                           <th width="15%">BusinessLogo</th>
                           <th width="15%">RestaurantLogo</th>
                           <th width="15%">Halal</th>
                           <th width="10%">Approve</th>
                           <th width="10%">Reject</th>
                       </tr>
             </HeaderTemplate>

            <ItemTemplate>
                     <tr>
                           <td width="5%"><asp:Label runat="server" ID="lblUserId" Text='<%#Eval("userId") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="firstName" Text='<%#Eval("firstName") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="lastName" Text='<%#Eval("lastName") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="phoneNumber" Text='<%#Eval("phone") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="email" Text='<%#Eval("email") %>'></asp:Label></td>
                           <td width="15%"><asp:HyperLink runat="server" ID="businessLicense"></asp:HyperLink></td>
                           <td width="15%"><asp:HyperLink runat="server" ID="restaurantLogo"></asp:HyperLink></td>
                           <td width="15%"><asp:HyperLink runat="server" ID="halal"></asp:HyperLink></td>
                           <td width="10%"><asp:Button ID="systemAdminRegistration_Approve" Text="Approve" CommandName="Approve" runat="server" CommandArgument='<%#Eval("userId") %>'/></td>
                           <td width="10%"><asp:Button ID="systemAdminRegistration_Reject" Text="Reject" CommandName="Reject" runat="server" CommandArgument='<%#Eval("userId") %>' /></td>
                     </tr> 
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
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
