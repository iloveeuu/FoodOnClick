<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerPreOrder.aspx.vb" Inherits="FoodOnClick.customerPreOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<table id="tableStyle">
		<tr>
			<td>
				<asp:Button ID="btnProfile" Width="100%" Height="80%" runat="server" OnClick="btnProfile_Click" Text="Profile" />
			</td>
			<td>
				<asp:Button ID="btnHome" Width="100%" Height="80%" runat="server" OnClick="btnHome_Click" Text="Home" />
			</td>
		</tr>
    </table>--%>
	<div>
        <h2>Reservation Pre-Order</h2>
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
        <div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Pax:
          </div>
			<div class="col-50">
				<asp:Label ID="lblPax" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			 Reserve Date:
          </div>
			<div class="col-50">
				
				<asp:Label ID="lblDate" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50" style="text-align: right;" >
			  Reserve Time:
          </div>
			<div class="col-50">
				<asp:Label ID="lblTime" runat="server"></asp:Label>
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
                            <asp:TextBox ID="txtQty" runat="server" TextMode="Number" Width="20%"></asp:TextBox><br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="Must be more than 0" Operator="GreaterThan" 
					Type="Integer" ValueToCompare="0" ForeColor="Red" /><br />
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doAdd"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
               
            </asp:GridView>
	</div>
	<br />
    <div>
        <h3>Added Pre-Order List</h3>
    </div>
    <div>
		<asp:GridView ID="gvPreOrder" Class="gvPreOrder" OnRowCommand="gvPreOrder_RowCommand" runat="server" AutoGenerateColumns="false" Height="100%">
                <Columns>
                    <asp:BoundField DataField="menu" HeaderText="Menu" HeaderStyle-Width="50%" />
                    <asp:BoundField DataField="qty" HeaderText="Quantity" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="totPrice" HeaderText="Price ($)" HeaderStyle-Width="30%" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doCancel"/>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
               
            </asp:GridView>
	</div>
	<br />
    <div class="container">
        <div class="row">
            <div class="col-50" style="text-align: right;">
				<asp:Label ID="Label3" runat="server" Text="Total Charges:"></asp:Label>
			</div>
          <div class="col-50">
				<asp:Label ID="lblTotal" runat="server"></asp:Label>
			  </div>
        </div>
        <div class="row">
			<div class="col-100" style="text-align: center;">
                <asp:Button ID="btnPreOrder" runat="server" OnClick="btnPreOrder_Click"  Width="30%" Text="Confirm Pre-Order" />
			</div>
		</div>
        <p id="errorText2" width="100%" runat="server" style="display:none;">
				No pre-order added
			</p>
    </div>
	<%--<div align="center">
        <asp:Button ID="btnPreOrder" runat="server" OnClick="btnPreOrder_Click"  Width="30%" Text="Confirm Pre-Order" />
    </div>--%>
</asp:Content>
