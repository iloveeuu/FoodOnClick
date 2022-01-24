<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="signUp.aspx.vb" Inherits="FoodOnClick.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up Food On Click</title>
</head>
<body>

<h1>Food On Click</h1>
<h3>Sign Up</h3>
<br/>
<hr/>
<br/>
<form id="form2" runat="server">
<table id="tableStyle">
		<tr>
			<td>
				Username:
			</td>
			<td>
				<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				Password:
			</td>
			<td>
				<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				Email:
			</td>
			<td>
				<asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				User Type:
			</td>
			<td>
				<asp:DropDownList ID="ddlType" runat="server">
					<asp:ListItem value="Customer" selected="True">Customer</asp:ListItem>  
					<asp:ListItem value="Restaurant" selected="True">Restaurant</asp:ListItem>  
					<asp:ListItem value="Delivery Rider" selected="True">Rider</asp:ListItem>  
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btnSignUp" runat="server" Text="Sign Up" />
			</td>
			<td></td>
		</tr>
	</table>
</form>
	</body>