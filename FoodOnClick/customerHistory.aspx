<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerHistory.aspx.vb" Inherits="FoodOnClick.customerHistory" %>

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
            <td>
				<asp:Button ID="btnCart" Width="100%" Height="80%" runat="server" OnClick="btnCart_Click" Text="Cart" />
			</td>
		</tr>
    </table>
    <div>
        <h2>Reservation List</h2>
    </div>
    <br/>
    <div style="overflow-x:auto;">
        <%--CssClass="table table-responsive table-striped"--%>
		<asp:GridView ID="gvReservation" Width="70%" runat="server" OnRowCommand="gvReservation_RowCommand" OnRowDataBound="gvReservation_RowDataBound" AutoGenerateColumns="false" Height="100%" >
                <Columns>
                    <asp:BoundField DataField="restName" HeaderText="Restaurant" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-Width="30%" />
                    <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="5%" />
                    <asp:BoundField DataField="date" HeaderText="Date" DataFormatString = {0:d} HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="15%" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfBatchId" runat="server" Value='<%# Eval("batchId") %>' />
                            <asp:HiddenField ID="hfReservationId" runat="server" Value='<%# Eval("reservationId") %>' />
                            <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("email") %>' />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Container.DataItemIndex %>' Visible="false" CommandName="doCancel"/>
                            <asp:Button ID="btnPreOrder" runat="server" Text="Order List" CommandArgument='<%# Container.DataItemIndex %>'   Visible="false" CommandName="doCheckPreOrder"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
	</div>
    <br />
    <div>
        <h2>Delivery Order List</h2>
    </div>
    <br/>
    <div style="overflow-x:auto;">
        <%--CssClass="table table-responsive table-striped"--%>
		<asp:GridView ID="gvDelivery" Width="70%" runat="server" OnRowCommand="gvDelivery_RowCommand" OnRowDataBound="gvDelivery_RowDataBound" AutoGenerateColumns="false" Height="100%" >
                <Columns>
                    <asp:BoundField DataField="restName" HeaderText="Restaurant" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-Width="30%" />
                    <asp:BoundField DataField="orderNum" HeaderText="Order ID" HeaderStyle-Width="30%" />
                    <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="15%" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfBatchId" runat="server" Value='<%# Eval("batchId") %>' />
                            <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("email") %>' />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Container.DataItemIndex %>' Visible="false" CommandName="doCancel"/>
                            <asp:Button ID="btnOrder" runat="server" Text="Order List" CommandArgument='<%# Container.DataItemIndex %>'  CommandName="doCheckOrder"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
	</div>
    <br />
</asp:Content>
