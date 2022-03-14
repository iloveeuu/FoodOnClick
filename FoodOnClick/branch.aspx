<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branch.aspx.vb" Inherits="FoodOnClick.Branch1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/design.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td><h1><asp:Label runat="server" ID="lblTitle"></asp:Label></h1></td>
        </tr>
    </table>
    <asp:Repeater ID="rptBranch" runat="server" OnItemDataBound="rptBranch_ItemDataBound" OnItemCommand="rptBranch_ItemCommand">
        <ItemTemplate>
            <table>
                <tr>
                    <td colspan="3">
                        <asp:Label runat="server" ID="branchName" Text='<%#Eval("restaurantName") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSelect" Text="Select" CommandName="Select" CommandArgument='<%#Eval("branchId") %>' />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("branchId") %>' />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <div class="alignTxtMid">
        <asp:Label runat="server" ID="lblNothing" Text="Currently no branch registered" Visible="False"></asp:Label>
    </div>
    <asp:Button runat="server" ID="btnAdd" Width="100%" Text="Add Branch" OnClick="btnAdd_Click" />
</asp:Content>
