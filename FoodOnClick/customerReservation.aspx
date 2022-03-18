<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerReservation.aspx.vb" Inherits="FoodOnClick.customerReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
        <h2>Reservation</h2>
    </div>
    <br/>
    <div class="container">
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Restaurant Name:
          </div>
			<div class="col-50">
				<asp:Label ID="lblRestName" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Halal:
          </div>
			<div class="col-50">
				<asp:Label ID="lblHalal" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Address:
          </div>
			<div class="col-50">
				<asp:Label ID="lblAddress" runat="server"></asp:Label>
			  </div>
        </div>
        <div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Pax:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtPax" CssClass="textWidth"  Width="30%" runat="server" TextMode="Number"></asp:TextBox>
				<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPax" ErrorMessage="Must be more than 0" Operator="GreaterThan" 
					Type="Integer" ValueToCompare="0" ForeColor="Red" />
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			 Reserve Date:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtDate" CssClass="textWidth"  Width="30%" runat="server" TextMode="Date"></asp:TextBox>
				<asp:CompareValidator ID="CompareEndTodayValidator" Operator="GreaterThanEqual" type="Date" ControltoValidate="txtDate" 
					ErrorMessage="Must be &gt;= today" runat="server" ForeColor="Red" />
			  </div>
        </div>
		<div class="row">
          <div class="col-50" style="text-align: right;" >
			  Time:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtTime" CssClass="textWidth"  Width="30%" runat="server" TextMode="Time"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:Button ID="btnReserve"  CssClass="textWidth" OnClick="btnReserve_Click" runat="server"  Width="50%" Text="Reserve" />
			</div>
		</div>
			<p id="errorText" width="100%" runat="server" style="display:none;">
				Please fill up all fields.
			</p>
   </div>
	<br />
	<br />
	<table id="tblStyle" runat="server" style="display:none; width: 20%; margin-left: auto; margin-right: auto;">
		<tr>
			<td colspan="2">
				Do you wish to have pre-order food?
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click"/>
			</td>
			<td>
				<asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click"/>
			</td>
		</tr>
	</table>
	<br />
	<br />
</asp:Content>
