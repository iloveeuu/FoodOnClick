<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerHome.aspx.vb" Inherits="FoodOnClick.customerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table id="tableStyle">
		<tr>
			<td colspan="3">
				<asp:Button ID="btnProfile" Width="30%" Height="80%" runat="server" OnClick="btnProfile_Click" Text="Profile" />
				<asp:Button ID="btnHistory" Width="30%" Height="80%" runat="server" OnClick="btnHistory_Click" Text="History" />
				<asp:Button ID="btnCart" Width="30%" Height="80%" runat="server" OnClick="btnCart_Click" Text="Cart" />
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<p style="font-weight: bold;">Looking for anything to satisfy your hunger? We have following services for you to choose.</p>
			</td>
		</tr>
		<tr>
			<td>
				<asp:LinkButton ID="lbtnDelivery" runat="server" style="text-decoration:none" Font-Bold="true">
					<img class="custBtnImage" src="../Images/delivery.png" alt="Delivery"/>
					<div class="custBtnDiv">
						Delivery
					</div>
				</asp:LinkButton>
			</td>
			<td>
				<asp:LinkButton ID="lbtnReservation" runat="server" style="text-decoration:none" Font-Bold="true">
					<img class="custBtnImage" src="../Images/reservation.png" alt="Reservation" />
					<div class="custBtnDiv">
						Reservation
					</div>
				</asp:LinkButton>
			</td>
		</tr>
	</table>
</asp:Content>
