<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="restaurantMenu.aspx.vb" Inherits="FoodOnClick.restaurantMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/design.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table id="tableStyle">
		<tr>
			<td>
				<asp:TextBox  ID="restaurantMenuMenuBar" runat="server"> </asp:TextBox>
			</td>
			<td>
				<asp:Button ID="restaurantMenuLoginSignup" runat="server" Text="Login/Signup"/>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="restaurantMenuManageAnnouncements" runat="server" Text="Manage Announcements"/>
			</td>
			<td>
				<asp:Button ID="restaurantMenuManageReservations" runat="server" Text="Manage Reservations"/>
			</td>
			<td>
				<asp:Button ID="restaurantMenuManageOrders" runat="server" Text="Manage Orders"/>
			</td>
						<td>
				<asp:Button ID="restaurantMenuViewReviews" runat="server" Text="Manage Reviews"/>
			</td>

		</tr>
		<tr>
			<td>
				<asp:textbox ID="restaurantHomeMenu" runat="server"> </asp:textbox>
			</td>
			<td>
				<asp:Button ID="restaurantHomeEditButton" runat="server" Text="Edit"/>
			</td>
			<td>
				<asp:Button ID="restaurantHomeDeleteButton" runat="server" Text="Delete"/>
			</td>
		</tr>

	</table>
</asp:Content>
