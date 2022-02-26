<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerFoodList.aspx.vb" Inherits="FoodOnClick.customerFoodList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/design.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
		<tr>
			<td colspan="2">
				<asp:Image ID="imgRestaurant" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblInfo" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
</asp:Content>
