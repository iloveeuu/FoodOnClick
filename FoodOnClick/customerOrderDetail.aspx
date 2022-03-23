<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerOrderDetail.aspx.vb" Inherits="FoodOnClick.customerOrderDetail" %>
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
		</tr>
	</table>
	<div>
        <h2 id="h2ID" runat="server">Delivery Order</h2>
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
			  Delivery Charges:
          </div>
			<div class="col-50">
				<asp:Label ID="lblDelCharges" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Total Charges:
          </div>
			<div class="col-50">
				<asp:Label ID="lblTotal" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Order Status:
          </div>
			<div class="col-50">
				<asp:Label ID="lblStatus" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:Button ID="btnCancel" runat="server" OnClientClick="return confirm('Do you want to cancel this delivery order?');"  OnClick="btnCancel_Click"  Width="50%" Text="Cancel" />
			</div>
		</div>
   </div>
	<br />
	<div style="overflow-x:auto;">
        <%--CssClass="table table-responsive table-striped"--%>
		<asp:GridView ID="gvMenu" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%" >
                 <Columns>
                    <asp:BoundField DataField="menu" HeaderText="Menu" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="describe" HeaderText="Description" HtmlEncode="false" HeaderStyle-Width="40%" />
                    <asp:BoundField DataField="orderQuantity" HeaderText="Order Quantity" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
					 <asp:BoundField DataField="price" HeaderText="Price ($)" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                </Columns>

            </asp:GridView>
	</div>
	<br />
</asp:Content>
