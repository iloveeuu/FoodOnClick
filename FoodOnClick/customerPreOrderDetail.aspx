<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerPreOrderDetail.aspx.vb" Inherits="FoodOnClick.CustomerPreOrderDetail" %>
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
			  Address:
          </div>
			<div class="col-50">
				<asp:Label ID="lblAddress" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Date:
          </div>
			<div class="col-50">
				<asp:Label ID="lblDate" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Time:
          </div>
			<div class="col-50">
				<asp:Label ID="lblTime" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Total Price:
          </div>
			<div class="col-50">
				<asp:Label ID="lblTotal" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Pre-Order Status:
          </div>
			<div class="col-50">
				<asp:Label ID="lblStatus" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:Button ID="btnCancel" runat="server" OnClientClick="return confirm('Do you want to cancel this pre-order?');" OnClick="btnCancel_Click"  Width="50%" Text="Cancel" />
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
							<div style="border: 1px solid black;display:inline-grid;text-align:center;">
								 <center>
									 <asp:Image runat="server" ID="imgRest" Width="150px" Height="150px" ImageUrl='<%#Eval("path") %>' />
								 </center>
								<asp:Label runat="server" ID="menu" Text='<%#Eval("menu") %>'></asp:Label>
								<asp:Label runat="server" ID="lblType" style="text-transform: capitalize;" Text='<%#Eval("type") %>'></asp:Label>
							</div>
						</ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="describe" HeaderText="Description" HtmlEncode="false" HeaderStyle-Width="40%" />
                    <asp:BoundField DataField="orderQuantity" HeaderText="Order Quantity" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
					 <asp:BoundField DataField="price" HeaderText="Price ($)" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                </Columns>

            </asp:GridView>
	</div>
	<br />
</asp:Content>
