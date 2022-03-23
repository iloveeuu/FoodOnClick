<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerProfile.aspx.vb" Inherits="FoodOnClick.customerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table id="tableStyle">
		<tr>
			<td>
				<asp:Button ID="btnHome" Width="100%" Height="80%" runat="server" OnClick="btnHome_Click" Text="Home" />
			</td>
			<td>
				<asp:Button ID="btnHistory" Width="100%" Height="80%" runat="server" OnClick="btnHistory_Click" Text="History" />
			</td>
			<td>
				<asp:Button ID="btnCart" Width="100%" Height="80%" runat="server" OnClick="btnCart_Click" Text="Cart" />
			</td>
		</tr>
	</table>
    <div>
        <h2>Profile</h2>
    </div>
    <br/>
    <div class="container">
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Email:
          </div>
			<div class="col-50">
				<asp:Label ID="lblEmail" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  First Name:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Last Name:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
			  </div>
        </div>
        <div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Contact No:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Address:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Gender:
          </div>
			<div class="col-50">
				<asp:RadioButton ID="rbMale" GroupName="gender" runat="server" Text="Male" />
                    <asp:RadioButton ID="rbFemale" GroupName="gender" runat="server" Text="Female" />   
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Date of Birth:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:Button ID="btnUpdate"  CssClass="textWidth" OnClick="btnUpdate_Click" runat="server"  Width="50%" Text="Update" />
			</div>
			<p id="errorText" width="100%" runat="server" style="display:none;">
				Please fill up all fields.
			</p>
		</div>
			
		<div class="row">
			<div class="col-100" style="text-align: center;">
				Update Password?
			</div>
		</div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  New Password:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Confirm Password:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:CompareValidator ID="cvPassword" runat="server" 
				 ControlToValidate="txtPassword"
				 CssClass="ValidationError"
				 ControlToCompare="txtPasswordConfirm"
				 ErrorMessage="Confirm Password must be the same" ForeColor="Red" 
				 ToolTip="Password must be the same" />
			</div>
		</div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:Button ID="btnChangePassword"  CssClass="textWidth" OnClick="btnChangePassword_Click" runat="server"  Width="50%" Text="Change Password" />
			</div>
		</div>
		<p id="errorPass" width="100%" runat="server" style="display:none;">
			<asp:Label ID="lblErrorPass" runat="server" Text="Please fill up both fields"></asp:Label>
		</p>
   </div>
</asp:Content>
