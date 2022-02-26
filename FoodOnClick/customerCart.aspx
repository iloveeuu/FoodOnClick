<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerCart.aspx.vb" Inherits="FoodOnClick.customerCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
		<tr>
			<td>
				<asp:Label ID="lblListOrders" runat="server" Text="Order Lists Here"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="btnPlaceOrder" runat="server" Text="Place Order"></asp:Label>
			</td>
		</tr>
	</table>
</asp:Content>
