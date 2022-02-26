<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerRestaurant.aspx.vb" Inherits="FoodOnClick.customerDeliveryHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="CSS/design.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
		<tr>
			<td>
				<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
			</td>
			<td>
				<asp:Button ID="btnSearch" runat="server" Text="Search" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:DropDownList ID="ddlCatergory" runat="server">
					<asp:ListItem value="All" selected="True">All</asp:ListItem>  
					<asp:ListItem value="Halal" >Halal</asp:ListItem> 
					<asp:ListItem value="Western">Western</asp:ListItem>  
					<asp:ListItem value="Chinese">Chinese</asp:ListItem>  
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<asp:Label ID="Label1" runat="server" Text="List Rstaurants Here"></asp:Label>
		</tr>
	</table>
</asp:Content>
