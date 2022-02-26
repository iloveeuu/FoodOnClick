<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerSearch.aspx.vb" Inherits="FoodOnClick.customerSearch" %>
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
			<asp:Label ID="Label1" runat="server" Text="List Rstaurants Here"></asp:Label>
		</tr>
	</table>
</asp:Content>
