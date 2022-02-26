<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerCheckOut.aspx.vb" Inherits="FoodOnClick.customerCheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
		<tr>
			<td>
				<asp:Label ID="lblListOrders" runat="server" Text="Order Lists Here"></asp:Label>
			</td>
			<td>
				<asp:Label ID="lblQty" runat="server" Text="Order Qty Here"></asp:Label>
			</td>
			<td>
				<asp:Label ID="lblPrices" runat="server" Text="Order Prices Here"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblTotPrice" runat="server" Text="Total Price"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				<asp:DropDownList ID="ddlPaymentMethod" runat="server">
					<asp:ListItem value="Credit/Debit Card">Credit/Debit Card</asp:ListItem> 
					<asp:ListItem value="Cash">Cash</asp:ListItem>  
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="btnCheckOut" runat="server" Text="Check Out"></asp:Label>
			</td>
		</tr>
	</table>
</asp:Content>
