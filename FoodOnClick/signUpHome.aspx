<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="signUpHome.aspx.vb" Inherits="FoodOnClick.signUpHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Sign Up Food On Click</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table id="tableStyle">
		<tr>
			<td colspan="2">
				<p style="font-weight: bold;">Please choose which user account to register : </p>
			</td>
		</tr>
	

	   <tr>
			<td>
				<asp:LinkButton ID="lbtnCustomerAcc" runat="server" style="text-decoration:none" Font-Bold="true">
					<img class="custBtnImage" src="../Images/addCustomer.png" alt="customer"/>
					<div class="custBtnDiv">
						Customer Account
					</div>
				</asp:LinkButton>
			</td>
			<td>
				<asp:LinkButton ID="lbtnRestaurantAcc" runat="server" style="text-decoration:none" Font-Bold="true">
					<img class="custBtnImage" src="../Images/addRestaurant.png" alt="restaurant" />
					<div class="custBtnDiv">
						Restarant Account
					</div>
				</asp:LinkButton>
			</td>
		      <td>
				<asp:LinkButton ID="lbtnRiderAcc" runat="server" style="text-decoration:none" Font-Bold="true">
					<img class="custBtnImage" src="../Images/addRider.png" alt="rider" />
					<div class="custBtnDiv">
						 Rider Account
					</div>
				</asp:LinkButton>
			</td>
		</tr>
	</table>
</asp:Content>