<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="restaurantHome.aspx.vb" Inherits="FoodOnClick.restaurantHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/design.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table id="tableStyle">
		<tr>
			<td>
				<asp:TextBox  ID="restaurantHomeMenuBar" runat="server"> </asp:TextBox>
			</td>
			<td>
				<asp:Button ID="restaurantHomeLoginSignup" runat="server" Text="Login/Signup"/>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="restaurantHomeAddBranch" runat="server" Text="AddBranch"/>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Dropdownlist ID="restaurantHomeselectBanchRestaurant" runat="server"> </asp:Dropdownlist>
			</td>
			<td>
				<asp:Button ID="restaurantHomeSelectButton" runat="server" Text="Select"/>
			</td>
			<td>
				<asp:Button ID="restaurantHomeEditButton" runat="server" Text="Edit"/>
			</td>
		</tr>
	</table>
</asp:Content>
