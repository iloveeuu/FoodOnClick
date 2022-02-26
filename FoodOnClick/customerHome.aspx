<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerHome.aspx.vb" Inherits="FoodOnClick.customerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	
    <link href="CSS/design.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<table id="tableStyle">
		<tr>
			<td colspan="2">
				<asp:Image ID="imgAnnouncement" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:ImageButton ID="ibtnDelivery" runat="server" />
			</td>
			<td>
				<asp:ImageButton ID="ibtnReservation" runat="server" />
			</td>
		</tr>
	</table>
</asp:Content>
