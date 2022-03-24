<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchMenu.aspx.vb" Inherits="FoodOnClick.branchMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        td{
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="overflow-x:auto;">
        
    <table class="tableStyle">
        <tr>
            <td></td>
            <td colspan="2"><asp:Button runat="server" ID="btnHome" OnClick ="btnHome_Click" Text="Home" Width="100%"/></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="4">
                <h1>
                    <asp:Label runat="server" ID="lblTitle"></asp:Label></h1>
            </td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="btnAnnouncements" Text="Manage Announcements" Width="100%" /></td>
            <td><asp:Button runat="server" ID="btnReservations" Text="Manage Reservations" Width="100%" OnClick="btnReservations_Click" /></td>
            <td><asp:Button runat="server" ID="btnOrders" Text="Manage Orders" Width="100%" OnClick="btnOrders_Click" /></td>
            <td><asp:Button runat="server" ID="btnReviews" Text="View reviews" Width="100%" /></td>
            
        </tr>
    </table>
    <table>
        <tr>
            <td><h2><asp:Label runat="server" ID="lblTitleMenu" Text="Menu"></asp:Label></h2></td>
        </tr>
    </table>
    <asp:Repeater ID="rptBranch" runat="server" OnItemDataBound="rptBranch_ItemDataBound" OnItemCommand="rptBranch_ItemCommand" EnableViewState="false">
        <ItemTemplate>
            <table id="tableStyle">
                <tr>
                        
                    <td>
                        <asp:Image runat="server" ID="menuImage" Width="100px"/>
                        <asp:Label runat="server" ID="menuName" Text='<%#Eval("menuName") %>'></asp:Label>

                    </td>
                    <%--                    <td>
                        <asp:Button runat="server" ID="btnSelect" Text="Select" CommandName="Select"  />
                    </td>--%>
                    <td>
                        $<asp:Label runat="server" ID="menuPrice" Text='<%#Eval("menuCost") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("menuId") %>' />
                    </td>
                    <%--                    <td>
                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="Delete"/>
                    </td>--%>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <div class="alignTxtMid">
        <asp:Label runat="server" ID="lblNothing" Text="Currently no menu registered" Visible="False"></asp:Label>
    </div>
    <table id="tableStyle">
        <tr>
            <td>
                <asp:Button runat="server" ID="btnAdd" Width="100%" Text="Add Menu" OnClick="btnAdd_Click" /></td>
        </tr>
    </table>
        </div>
</asp:Content>
