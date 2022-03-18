<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerReservationSearch.aspx.vb" Inherits="FoodOnClick.customerReservationSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<div class="container">
        <div class="row">
          <div class="col-20">
				<asp:Label ID="Label7" runat="server"  Text="Category:"></asp:Label>
          </div>
          <div class="col-30">
				<asp:DropDownList ID="ddlCategory" CssClass="fullText" runat="server"></asp:DropDownList>
          </div>
          <div class="col-20">
             <asp:Label ID="Label8" runat="server" CssClass="fullText" Text="Food Type:"></asp:Label>
          </div>
          <div class="col-30">
			<asp:DropDownList ID="ddlType" CssClass="fullText" runat="server"></asp:DropDownList>
          </div>
        </div>
        <div class="row">
			<div class="col-20">
			<asp:Label ID="Label9" runat="server" Text="Restaurant Name:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtRestaurant" CssClass="fullText" runat="server"></asp:TextBox>
			  </div>
			<div class="col-20">
			<asp:Label ID="Label10" runat="server" Text="Location:"></asp:Label>
			</div>
          <div class="col-30">
			<asp:TextBox ID="txtLocation" CssClass="fullText" runat="server"></asp:TextBox>
			</div>
        </div>
		<div class="row">
			<div class="col-20">
				<asp:Label ID="Label11" runat="server" Text="Dish Name: "></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtDishName" CssClass="fullText" runat="server"></asp:TextBox>
			  </div>
			<div class="col-20">
			</div>
          <div class="col-30">
			<asp:Button ID="btnSearch"  CssClass="fullText" runat="server" Text="Search" />
			</div>
        </div>
   </div>
</asp:Content>
