﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchMenu.aspx.vb" Inherits="FoodOnClick.branchMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table>
        <tr>
            <td><h1><asp:Label runat="server" ID="lblTitle"></asp:Label></h1></td>
        </tr>
    </table>
    <asp:Repeater ID="rptBranch" runat="server" OnItemDataBound="rptBranch_ItemDataBound" OnItemCommand="rptBranch_ItemCommand" EnableViewState="false">
        <ItemTemplate>
            <table id="tableStyle">
                <tr>
                    <td>
                        <asp:Label runat="server" ID="menuName"  Text='<%#Eval("menuName") %>'></asp:Label>
                    </td>
<%--                    <td>
                        <asp:Button runat="server" ID="btnSelect" Text="Select" CommandName="Select"  />
                    </td>--%>
                    <td>
                        <asp:Button runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("menuId") %>'  />
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
            <td><asp:Button runat="server" ID="btnAdd" Width="100%" Text="Add Menu" OnClick="btnAdd_Click" /></td>
        </tr> 
        </table>
</asp:Content>
