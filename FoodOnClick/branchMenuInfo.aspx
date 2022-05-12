<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchMenuInfo.aspx.vb" Inherits="FoodOnClick.branchMenuInfo" %>

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
            <td>Name:</td>
            <td>
                <asp:TextBox runat="server" ID="txtName" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description:</td>
            <td>
                <asp:TextBox runat="server" ID="txtDescription" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Price:</td>
            <td>
                <asp:TextBox runat="server" ID="txtCost" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Image:</td>
            <td style="float: left;">
                <asp:FileUpload runat="server" ID="FileUpload" /></td>
        </tr>
        <tr>
            <td>Status:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlStatus" Width="100%" DataTextField="FKmenuStatusType" DataValueField="FKmenuStatusId"></asp:DropDownList></td>
        </tr>
<%--        <tr>
            <td>Discount:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlDiscount" Width="100%" DataTextField="FKmenuDiscountString" DataValueField="FKmenuDiscountId"></asp:DropDownList></td>
        </tr>--%>
        <tr>
            <td>Type:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlFoodType" Width="100%" DataTextField="FKmenuFoodType" DataValueField="FKmenuFoodTypeId"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <h2>Nutrients</h2>
            </td>
        </tr>
        <tr>
            <td>Protein:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtProtein" Width="100%" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Energy:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEnergy" Width="100%" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Carbonhydrate:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCarbonhydrate" Width="100%" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Glucose:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtGlucose" Width="100%" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fats:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFats" Width="100%" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Sodium:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtSodium" Width="100%" Text="0"></asp:TextBox>
            </td>
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
    <asp:HiddenField runat="server" ID="imgurl"/>
</asp:Content>
