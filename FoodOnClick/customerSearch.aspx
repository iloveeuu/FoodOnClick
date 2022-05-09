<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerSearch.aspx.vb" Inherits="FoodOnClick.customerSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function showPosition(position) {
            window.location = 'customerSearch.aspx?lat=' + position.coords.latitude + '&long=' + position.coords.longitude;

        }
    </script>
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
			<td>
				<asp:Button ID="btnCart" Width="100%" Height="80%" runat="server" OnClick="btnCart_Click" Text="Cart" />
			</td>
		</tr>
    </table>
	<div>
        <h2>Search Restaurant</h2>
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
			<asp:DropDownList ID="ddlType" CssClass="ddlWidthCustSearch" runat="server"  DataTextField="FKmenuFoodType" DataValueField="FKmenuFoodTypeId"></asp:DropDownList>
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
				<asp:Button ID="btnSearch" runat="server"  Width="50%" Text="Search" />
			</div>
		</div>
   </div>
	<br />
	<br />
	<%--<div style="overflow-x:auto;overflow:auto;">
		<asp:GridView ID="gvSearch" Class="gvSearch" OnRowCommand="gvSearch_RowCommand" OnRowDataBound="gvSearch_RowDataBound"  runat="server" AutoGenerateColumns="false" Height="100%">
                <Columns>
					<asp:TemplateField HeaderText="Restaurant" HeaderStyle-Width="50%">
                        <ItemTemplate>
							<div style="border: 1px solid black;display:inline-grid;text-align:center;">
								 <center><asp:Image runat="server" ID="imgRest" Width="200px" Height="200px" ImageUrl='<%#Eval("logo") %>' />
									 </center>
								<asp:Label runat="server" ID="lblRestName" Text='<%#Eval("restName") %>'></asp:Label>
								<asp:Label runat="server" ID="lblHalal" Text='<%#Eval("halal") %>'></asp:Label>
							</div>
						</ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--<asp:BoundField DataField="restName" HeaderText="Restaurant" HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="halal" HeaderText="Halal" HeaderStyle-Width="3%" />
                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-Width="10%" />--%>
                    <%--<asp:BoundField DataField="dishName" HeaderText="Menu" HeaderStyle-Width="30%" />
                    <asp:BoundField DataField="price" HeaderText="Price ($)" HeaderStyle-Width="15%" />--%>
					<%--<asp:TemplateField HeaderText="Menu" HeaderStyle-Width="30%">
                        <ItemTemplate>
							<asp:Image runat="server" ID="menuImage" Width="50px" Height="50px" ImageUrl='<%#Eval("image") %>' />
								<asp:Label runat="server" ID="menuFoodtitle" Text='<%#Eval("dishName") %>'></asp:Label>
								<asp:Label runat="server" ID="menuPrice" Text='<%#Eval("price") %>'></asp:Label>
						</ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--<asp:TemplateField HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Button ID="btnReserve" runat="server" Text="Reserve" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doReservation"/>
							<asp:Button ID="btnDelivery" runat="server" Text="Delivery Order" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doDelivery"/>
                            <asp:HiddenField ID="hfRestId" runat="server" Value='<%# Eval("restaurantID") %>' />
                            <asp:HiddenField ID="hfUserId" runat="server" Value='<%# Eval("firstname") %>' />
                            <asp:HiddenField ID="hfBranchId" runat="server" Value='<%# Eval("branchid") %>' />
                            <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("email") %>' />
                            <asp:HiddenField ID="hfTimeOpen" runat="server" Value='<%# Eval("time_open") %>' />
                            <asp:HiddenField ID="hfTimeClosed" runat="server" Value='<%# Eval("time_closed") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
	</div>--%>
	<div style="text-align:center;border-radius: 5px;background-color: #f2f2f2;">
		<asp:Repeater ID="rptSearch" runat="server" EnableViewState="true" OnItemCommand="rptSearch_ItemCommand">
            <ItemTemplate>
                        <div style="border: 1px solid black;display:inline-grid;text-align:center;width:250px;height:250px;" >
								<center><asp:ImageButton runat="server" CommandName="viewMenu" CommandArgument='<%#Eval("restaurantID") %>' ID="imgRest" Width="200px" Height="200px" ImageUrl='<%#Eval("logo") %>' />
									 </center>
								<asp:Label runat="server" ID="lblRestName" Text='<%#Eval("restName") %>'></asp:Label>
								<asp:Label runat="server" ID="lblHalal" Text='<%#Eval("halal") %>'></asp:Label>
								<asp:HiddenField ID="hfAddress" runat="server" Value='<%# Eval("address") %>' />
								<asp:HiddenField ID="hfRestId" runat="server" Value='<%# Eval("restaurantID") %>' />
								<asp:HiddenField ID="hfUserId" runat="server" Value='<%# Eval("firstname") %>' />
								<asp:HiddenField ID="hfBranchId" runat="server" Value='<%# Eval("branchid") %>' />
								<asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("email") %>' />
								<asp:HiddenField ID="hfTimeOpen" runat="server" Value='<%# Eval("time_open") %>' />
								<asp:HiddenField ID="hfTimeClosed" runat="server" Value='<%# Eval("time_closed") %>' />
							</div>
            </ItemTemplate>
		</asp:Repeater> 
		<asp:Label ID="lblDefaultMessage" Font-Size="Larger" runat="server" Text="Sorry, There is no restaurant available nearby" Visible="false"></asp:Label>
	</div>
	<br />
	<br />
</asp:Content>
