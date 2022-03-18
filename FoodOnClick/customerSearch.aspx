<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerSearch.aspx.vb" Inherits="FoodOnClick.customerSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<table id="tableStyle">
		<tr>
			<td colspan="3">
				<p>What are you craving?</p>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label2" runat="server" Text="Category: "></asp:Label>
				<asp:DropDownList ID="ddlCategory1" runat="server"></asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="Label3" runat="server" Text="Food Type: "></asp:Label>
				<asp:DropDownList ID="ddlFoodType" runat="server"></asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="Label6" runat="server" Text="Restaurant Name: "></asp:Label>
				<asp:TextBox ID="txtRestaurant1" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label5" runat="server" Text="Location: "></asp:Label>
				<asp:TextBox ID="txtLocation1" runat="server"></asp:TextBox>
			</td>
			<td>
				<asp:Label ID="Label4" runat="server" Text="Dish Name: "></asp:Label>
				<asp:TextBox ID="txtDishName" runat="server"></asp:TextBox>
			</td>
			<td>
				<asp:Button ID="btnSearch" runat="server" Text="Search" />
			</td>
		</tr>
		<tr>
			<td colspan="2"><asp:Label ID="Label1" runat="server" Text="List Rstaurants Here"></asp:Label></td>
		</tr>
	</table>--%>
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
        <h2>Search Restaurant or Cuisine</h2>
    </div>
    <br/>
	<div class="container">
        <div class="row">
          <div class="col-20">
				<asp:Label ID="Label7" runat="server"  Text="Category:"></asp:Label>
          </div>
          <div class="col-30">
				<asp:DropDownList ID="ddlCategory" CssClass="ddlWidthCustSearch" runat="server" DataTextField="branchCuisine" DataValueField="branchCuisineId"></asp:DropDownList>
          </div>
          <div class="col-20">
             <asp:Label ID="Label8" runat="server" CssClass="textWidthCustSearch" Text="Food Type:"></asp:Label>
          </div>
          <div class="col-30">
			<asp:DropDownList ID="ddlType" CssClass="ddlWidthCustSearch" runat="server"></asp:DropDownList>
          </div>
        </div>
        <div class="row">
			<div class="col-20">
			<asp:Label ID="Label9" runat="server" Text="Restaurant Name:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtRestaurant" CssClass="textWidthCustSearch"  runat="server"></asp:TextBox>
			  </div>
			<div class="col-20">
			<asp:Label ID="Label10" runat="server" Text="Location:"></asp:Label>
			</div>
          <div class="col-30">
			<asp:TextBox ID="txtLocation" CssClass="textWidthCustSearch" runat="server"></asp:TextBox>
			</div>
        </div>
		<div class="row">
			<div class="col-20">
				<asp:Label ID="Label11" runat="server" Text="Dish Name:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtDishName" CssClass="textWidthCustSearch" runat="server"></asp:TextBox>
			  </div>
			<div class="col-20">
				<asp:Label ID="Label3" runat="server" Text="Halal:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:DropDownList runat="server" ID="ddlHalal" CssClass="ddlWidthCustSearch">
                    <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                    <asp:ListItem Value="Yes">Yes</asp:ListItem>

                </asp:DropDownList>
			</div>
        </div>
		<div class="row">
			<div class="col-20">
				<asp:Label ID="Label1" runat="server" Text="Min. Price:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtMinPrice" CssClass="textWidthCustSearch" runat="server" TextMode="Number"></asp:TextBox>
			  </div>
			<div class="col-20">
				<asp:Label ID="Label2" runat="server" Text="Max. Price:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtMaxPrice" CssClass="textWidthCustSearch" runat="server" TextMode="Number"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:Button ID="btnSearch" runat="server"  Width="50%" Text="Search" />
			</div>
		</div>
   </div>
	
	<br />
	<br />
	<div style="overflow-x:auto;">
		<asp:GridView ID="gvSearch" OnRowCommand="gvSearch_RowCommand" Width="60%" runat="server" AutoGenerateColumns="false" Height="100%">
                <Columns>
                    <asp:BoundField DataField="restName" HeaderText="Restaurant" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="halal" HeaderText="Halal" HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-Width="40%" />
                    <asp:BoundField DataField="dishName" HeaderText="Menu" HeaderStyle-Width="40%" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnReserve" runat="server" Text="Reserve" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doReservation"/>
                            <asp:HiddenField ID="hfRestId" runat="server" Value='<%# Eval("restaurantID") %>' />
                            <asp:HiddenField ID="hfUserId" runat="server" Value='<%# Eval("firstname") %>' />
                            <asp:HiddenField ID="hfBranchId" runat="server" Value='<%# Eval("branchid") %>' />
                            <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("email") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
               
            </asp:GridView>
	</div>
	<br />
	<br />
</asp:Content>
