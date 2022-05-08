<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerCheckOut.aspx.vb" Inherits="FoodOnClick.customerCheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table id="tableStyle">
		<tr>
			<td>
				<asp:Button ID="btnHome" Width="30%" Height="80%" runat="server" OnClick="btnHome_Click" Text="Home" />
				<asp:Button ID="btnHistory" Width="30%" Height="80%" runat="server" OnClick="btnHistory_Click" Text="History" />
				<asp:Button ID="btnCart" Width="30%" Height="80%" runat="server" OnClick="btnCart_Click" Text="Cart" />
			</td>
		</tr>
	</table>
	<div>
        <h2>Check Out</h2>
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
			  Address:
          </div>
			<div class="col-50">
				<asp:Label ID="lblAddress" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Type:
          </div>
			<div class="col-50">
				<asp:Label ID="lblType" runat="server"></asp:Label>
			  </div>
        </div>
   </div>
	<br />
	<div style="overflow-x:auto;">
        <%--CssClass="table table-responsive table-striped"--%>
		<asp:GridView ID="gvMenu" Width="40%" runat="server" AutoGenerateColumns="false" Height="100%" >
                 <Columns>
					 <asp:TemplateField HeaderText="Menu" HeaderStyle-Width="40%">
                        <ItemTemplate>
							<div style="display:inline-grid;text-align:center;">
								 <center>
									 <asp:Image runat="server" ID="imgRest" Width="150px" Height="150px" ImageUrl='<%#Eval("path") %>' />
								 </center>
								<asp:Label runat="server" ID="menu" Text='<%#Eval("menu") %>'></asp:Label>
								<asp:Label runat="server" ID="lblType" style="text-transform: capitalize;" Text='<%#Eval("foodType") %>'></asp:Label>
							</div>
						</ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="describe" HeaderText="Description" HtmlEncode="false" HeaderStyle-Width="40%" />
                    <asp:BoundField DataField="quantity" HeaderText="Order Quantity" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
					 <asp:BoundField DataField="price" HeaderText="Price ($)" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                </Columns>

            </asp:GridView>
	</div>
	<div class="container">
		<div class="row">
            <div class="col-50" style="text-align: right;">
				<asp:Label ID="Label1" runat="server" Text="Delivery Charges:"></asp:Label>
			</div>
          <div class="col-50">
				<asp:Label ID="lblDelCharges" runat="server"></asp:Label>
			  </div>
        </div>
        <div class="row">
            <div class="col-50" style="text-align: right;">
				<asp:Label ID="Label3" runat="server" Text="Total Charges:"></asp:Label>
			</div>
          <div class="col-50">
				<asp:Label ID="lblTotal" runat="server"></asp:Label>
			  </div>
        </div>
        <div class="row">
			<div class="col-50" style="text-align: right;">
				<asp:Label ID="Label4" runat="server" Text="Payment Method:"></asp:Label>
			</div>
          <div class="col-50">
			  <asp:DropDownList ID="ddlPayment" runat="server" OnSelectedIndexChanged="ddlPayment_SelectedIndexChanged">
                        <asp:ListItem Value="Cash" Selected="True">Cash</asp:ListItem>
                        <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                        <asp:ListItem Value="Debit Card">Debit Card</asp:ListItem>
                    </asp:DropDownList>
			  </div>
		</div>
		<div id="divShowHide" runat="server">

            <div class="row">
			    <div class="col-50" style="text-align: right;">
				    <asp:Label ID="Label5" runat="server" Text="Card Type:"></asp:Label>
			    </div>
              <div class="col-50">
			      <asp:DropDownList ID="ddlCardType" runat="server">
                            <asp:ListItem Value="Visa">Visa</asp:ListItem>
                            <asp:ListItem Value="Master">Master</asp:ListItem>
                        </asp:DropDownList>
			      </div>
		    </div>
			<div class="row">
			        <div class="col-50" style="text-align: right;">
				        <asp:Label ID="Label6" runat="server" Text="Card No:"></asp:Label>
			        </div>
                  <div class="col-50">
                      <asp:TextBox ID="txtCardNo" runat="server"></asp:TextBox>
		            </div>
		    </div>
			<div class="row">
				<div class="col-100">
				  <p id="errorText" width="100%" runat="server" style="display:none;">
					Invalid Card
					</p>
				</div>
			</div>
		</div>
        </div>
        <table width="100%">
		<tr>
			<td>
				<asp:Button ID="btnOrder" Width="50%" Height="80%" runat="server" OnClick="btnOrder_Click" Text="Confirm Order" />
				<br />
				<br />
				<asp:Button ID="btnCancel" Width="50%" Height="80%" runat="server" OnClick="btnCancel_Click" Text="Back" />
			</td>
		</tr>
		</table>
    </div>
</asp:Content>
