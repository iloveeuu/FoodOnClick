<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerReservationOrder.aspx.vb" Inherits="FoodOnClick.customerReservationOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table id="tableStyle">
		<tr>
			<td colspan="2">
				<asp:Image ID="Image1" runat="server" />
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="Label1" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="lblPerson" runat="server" Text="No. of persons"></asp:Label>
				<asp:TextBox ID="txtNoPerson" runat="server" TextMode="Number"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btnPreOrder" runat="server" Text="Pre Order Food" />
			</td>
			<td>
				<asp:Button ID="btnConfirm" runat="server" Text="Confirm Booking" />
			</td>
		</tr>
	</table>
</asp:Content>
