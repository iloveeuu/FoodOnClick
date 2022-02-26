<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerSelectedFood.aspx.vb" Inherits="FoodOnClick.customerSelectedFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
		<tr>
			<td colspan="2">
				<asp:Image ID="imgFood" runat="server" />
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="lblFood" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
				<asp:TextBox ID="txtQty" runat="server" TextMode="Number"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btnAddCart" runat="server" Text="Add to Cart" />
			</td>
		</tr>
	</table>
</asp:Content>
