<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerOrder.aspx.vb" Inherits="FoodOnClick.customerOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table id="tableStyle">
		<tr>
			<td>
				<asp:Button ID="btnProfile" Width="100%" Height="80%" runat="server" OnClick="btnProfile_Click" Text="Profile" />
			</td>
			<td>
				<asp:Button ID="btnHome" Width="100%" Height="80%" runat="server" OnClick="btnHome_Click" Text="Home" />
			</td>
		</tr>
    </table>
    <div>
        <h2>Order</h2>
    </div>
    <br />
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
   </div>
    <br/>
    <div>
        <h3>Search Menu</h3>
    </div>
    <br/>
	<div class="container">
        <div class="row">
            <div class="col-20">
				<asp:Label ID="Label11" runat="server" Text="Dish Name:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtDishName" CssClass="textWidthCustSearch" runat="server"></asp:TextBox>
			  </div>
          <div class="col-20">
             <asp:Label ID="Label8" runat="server" CssClass="textWidthCustSearch" Text="Food Type:"></asp:Label>
          </div>
          <div class="col-30">
			<asp:DropDownList ID="ddlType" CssClass="ddlWidthCustSearch" runat="server"  DataTextField="FKmenuFoodType" DataValueField="FKmenuFoodTypeId"></asp:DropDownList>
          </div>
        </div>
		<div class="row">
			<div class="col-20">
				<asp:Label ID="Label1" runat="server" Text="Min. Price:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtMinPrice" CssClass="textWidthCustSearch" runat="server" TextMode="Number"></asp:TextBox>
			  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtMinPrice" ErrorMessage="Cannot less than 0" Operator="GreaterThanEqual" 
					Type="Integer" ValueToCompare="0" ForeColor="Red" />
			  </div>
			<div class="col-20">
				<asp:Label ID="Label2" runat="server" Text="Max. Price:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtMaxPrice" CssClass="textWidthCustSearch" runat="server" TextMode="Number"></asp:TextBox>
			  <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtMaxPrice" ErrorMessage="Cannot less than 0" Operator="GreaterThanEqual" 
					Type="Integer" ValueToCompare="0" ForeColor="Red" />
			  </div>
        </div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click"  Width="50%" Text="Search" />
			</div>
		</div>
   </div>
	<br />
	<div>
        <p id="errorText" width="100%" runat="server" style="display:none;">
				Please fill up quantity
			</p>
		<asp:GridView ID="gvMenu" Class="gvMenu" OnRowCommand="gvMenu_RowCommand" runat="server" AutoGenerateColumns="false" Height="100%">
                <Columns>
                    <asp:BoundField DataField="dishName" HeaderText="Menu" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="price" HeaderText="Price ($)" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="describe" HeaderText="Description" HtmlEncode="false" HeaderStyle-Width="40%" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfMenuId" runat="server" Value='<%# Eval("menuid") %>' />
                            <asp:HiddenField ID="hfBranchId" runat="server" Value='<%# Eval("branchid") %>' />
                            <asp:TextBox ID="txtQty" runat="server" TextMode="Number" Width="20%"></asp:TextBox><br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="Must be more than 0" Operator="GreaterThan" 
					            Type="Integer" ValueToCompare="0" ForeColor="Red" /><br />
                            <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doAddCart"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
	</div>
	<br />
    <div class="container">
        <div class="row">
			<div class="col-100" style="text-align: center;">
                <asp:Button ID="btnShoppingCart" runat="server" OnClick="btnShoppingCart_Click"  Width="30%" Text="Go to Shopping Cart" />
			</div>
		</div>
    </div>
</asp:Content>
