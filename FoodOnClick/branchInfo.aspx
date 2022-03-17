<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchInfo.aspx.vb" Inherits="FoodOnClick.branchInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
        <tr>
            <td colspan="2">
                <h1>
                    <asp:Label runat="server" ID="lbltitle" Width="100%"></asp:Label></h1>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Location:</td>
            <td>
                <asp:TextBox runat="server" ID="txtCity" placeholder="e.g Ang Mo Kio" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox runat="server" ID="txtaddress" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Postal Code:</td>
            <td>
                <asp:TextBox runat="server" ID="txtpostalcode" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Cuisine:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCuisine" Width="100%" DataTextField="branchCuisine" DataValueField="branchCuisineId">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>Halal:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlHalal" Width="100%">
                    <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                    <asp:ListItem Value="Yes">Yes</asp:ListItem>

                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>Status:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlStatus" Width="100%">
                    <asp:ListItem Selected="True" Value="Idle">Idle</asp:ListItem>
                    <asp:ListItem Value="In Business">In Business</asp:ListItem>
                    <asp:ListItem Value="Closed">Closed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>Time Start:</td>
            <td>
                <asp:TextBox runat="server" ID="txtStart" TextMode="Time" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Time End:</td>
            <td>
                <asp:TextBox runat="server" ID="txtEnd" TextMode="Time" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="Cancel" Width="100%" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Width="100%" />
            </td>
        </tr>
    </table>
</asp:Content>
