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
		</tr>
    </table>
    <div>
        <h2>Reservation History</h2>
    </div>
    <br/>
    <div>
		<asp:GridView ID="gvReservation" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%">
                <Columns>
                    <asp:BoundField DataField="restName" HeaderText="Restaurant" HeaderStyle-Width="30%" />
                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-Width="40%" />
                    <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="date" HeaderText="Date" DataFormatString = {0:d} HeaderStyle-Width="40%" />
                    <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="40%" />
                    <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="20%" />
                </Columns>
            </asp:GridView>
	</div>
    <br />
    <br />
</asp:Content>
