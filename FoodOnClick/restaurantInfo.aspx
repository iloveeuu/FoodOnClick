<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="restaurantInfo.aspx.vb" Inherits="FoodOnClick.restaurantInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/design.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alignTxtMid">
        <h2>
            <asp:Label runat="server" ID="lbltitle"></asp:Label>
        </h2>
        <table>
            <tr>
                <td><asp:Label runat="server" ID="lblName" Text="Name:"></asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtName" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" ID="lbl" Text="Description:"></asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtDescription" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnSubmit" />
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
