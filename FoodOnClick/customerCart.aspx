<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerCart.aspx.vb" Inherits="FoodOnClick.customerCart" %>
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
        <h2>Cart List</h2>
    </div>
    <br/>
    <div style="overflow-x:auto;">
        <%--CssClass="table table-responsive table-striped"--%>
        <%--OnRowDataBound="gvCart_RowDataBound"--%>
		<asp:GridView ID="gvCart" Width="50%" runat="server" OnRowCommand="gvCart_RowCommand" AutoGenerateColumns="false" Height="100%" >
                <Columns>
                    <asp:BoundField DataField="restName" HeaderText="Restaurant" HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="type" HeaderText="Type" HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="totalPrice" HeaderText="Total Price ($)" HeaderStyle-Width="10%" />
                    <asp:TemplateField HeaderText="Menu" HeaderStyle-Width="30%">
                        <ItemTemplate>
							<div style="border: 1px solid black;display:inline-grid;text-align:center;">
								 <center>
									 <asp:Image runat="server" ID="imgRest" Width="150px" Height="150px" ImageUrl='<%#Eval("path") %>' />
								 </center>
								<asp:Label runat="server" ID="menu" Text='<%#Eval("dishName") %>'></asp:Label>
								<asp:Label runat="server" ID="lblFType" style="text-transform: capitalize;" Text='<%#Eval("foodType") %>'></asp:Label>
                                <asp:Label runat="server" ID="lblPrice" Text='<%# "$ " + Eval("price").ToString() %>'></asp:Label>
							</div>
						</ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfMenuId" runat="server" Value='<%# Eval("menuid") %>' />
                            <asp:HiddenField ID="hfUnitPrice" runat="server" Value='<%# Eval("unitprice") %>' />
                            <asp:TextBox ID="txtQuantity" Width="50%" runat="server" Text='<%# Eval("quantity") %>' TextMode="Number"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Cannot < 1" Operator="GreaterThan" 
					        Type="Integer" ValueToCompare="0" ForeColor="Red" />
                            <%--<br />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Container.DataItemIndex %>' CommandName="doUpdate"/>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cancel Menu" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Container.DataItemIndex %>' CommandName="doCancel"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfCartId" runat="server" Value='<%# Eval("cartId") %>' />
                            <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("email") %>' />
                            <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" CommandArgument='<%# Container.DataItemIndex %>' CommandName="doCheckOut"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
	</div>
    <br />
</asp:Content>
