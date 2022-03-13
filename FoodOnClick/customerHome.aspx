<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerHome.aspx.vb" Inherits="FoodOnClick.customerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<table id="tableStyle">
		<tr>
			<td>
				<asp:LinkButton ID="lbtnDelivery" runat="server">
					<img class="custBtnImage" src="../Images/delivery.png" alt="Delivery"/>
					<div class="custBtnDiv">
						Delivery
					</div>
				</asp:LinkButton>
			</td>
			<td>
				<asp:LinkButton ID="lbtnReservation" runat="server">
					<img class="custBtnImage" src="../Images/reservation.png" alt="Reservation" />
					<div class="custBtnDiv">
						Reserve
					</div>
				</asp:LinkButton>
			</td>
		</tr>
	</table>
</asp:Content>
