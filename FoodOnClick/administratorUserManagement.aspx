<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="administratorUserManagement.aspx.vb" Inherits="FoodOnClick.administratorUserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        <br />
        <br />
        <h1>Administrator User Management</h1>
        </div>

        <table>
            <tr>
                <td>
                     <asp:button runat="server" ID="customerManagement" Text="Customer Management"/>
                </td>
               
            </tr>
            <tr>
                <td>
                    <asp:button runat="server" ID="restaurantManagement" Text="Restaurant Management"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:button runat="server" ID="riderManagement" Text="Rider Management"/>
                </td>
            </tr>

        </table>


</asp:Content>
