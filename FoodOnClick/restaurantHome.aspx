<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="restaurantHome.aspx.vb" Inherits="FoodOnClick.restaurantHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<table id="tableStyle">
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
	</table>--%>
	

	<asp:Repeater ID="rptRestaurant" runat="server" OnItemDataBound="rptRestaurant_ItemDataBound" OnItemCommand="rptRestaurant_ItemCommand">
		<ItemTemplate>
			<table>
				<tr>
					<td colspan="3">
						<asp:Label runat="server" ID="resName" Text='<%#Eval("restaurantName") %>'></asp:Label>
					</td>
					<td>
						<asp:Button runat="server" ID="btnSelect" Text="Select" CommandName="Select" CommandArgument='<%#Eval("restaurantId") %>'/>
					</td>
					<td>
						<asp:Button runat="server" ID="btnEdit" Text="Edit"/>
					</td>
					<td>
						<asp:Button runat="server" ID="btnDelete" Text="Delete"/>
					</td>
				</tr>
			</table>
		</ItemTemplate>
	</asp:Repeater>
	<div class="alignTxtMid">
	<asp:Label runat="server" ID="lblNothing" Text="Currently no restaurants registered" Visible="False"></asp:Label>
		</div>
	<table id="tableStyle">
		<tr>
			<td><asp:Button runat="server" ID="btnAdd" Width="100%" Text="Add Restaurant" OnClick="btnAdd_Click"/></td>
		</tr>
	</table>
	
</asp:Content>
