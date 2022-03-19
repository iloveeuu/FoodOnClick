<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchReservation.aspx.vb" Inherits="FoodOnClick.branchReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
        <tr>
            <td colspan="3"><h1 style="text-align:center">Reservations</h1></td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="btnToday" Text="Today" width="100%" OnClick="btnToday_Click"/></td>
            <td><asp:Button runat="server" ID="btnUpcoming" Text="Upcoming" width="100%" OnClick="btnUpcoming_Click"/></td>
            <td><asp:Button runat="server" ID="btnHistory" Text="History" width="100%" OnClick="btnHistory_Click"/></td>
        </tr>
        <tr>
            <td colspan="4"><h2><asp:Label runat="server" ID="lblTitle"></asp:Label></h2></td>
        </tr>
    </table>
    <asp:GridView ID="gvReservationToday" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%" OnRowCommand="gvReservation_RowCommand">
        <Columns>
            <asp:BoundField DataField="firstname" HeaderText="Name" HeaderStyle-width="20%" />
            <asp:BoundField DataField="preordermeals" HeaderText="Meals Ordered" HeaderStyle-width="15%" />
            <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="10%" />
            <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}" HeaderStyle-Width="25%" />
            <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="25%" />
            <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="20%" />
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnApprove" Text="Confirm" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Pending", True, False) %>' CommandName="Approve" CommandArgument='<%#Eval("reservationid")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnReject" Text="Cancel" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Pending", True, False) %>' CommandName="Reject" CommandArgument='<%#Eval("reservationid")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:GridView ID="gvReservationUpcoming" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%" OnRowCommand="gvReservationUpcoming_RowCommand">
        <Columns>
            <asp:BoundField DataField="firstname" HeaderText="Name" HeaderStyle-width="20%" />
            <asp:BoundField DataField="preordermeals" HeaderText="Meals Ordered" HeaderStyle-width="15%" />
            <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="10%" />
            <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}" HeaderStyle-Width="25%" />
            <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="25%" />
            <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="20%" />
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnApprove" Text="Confirm" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Pending", True, False) %>' CommandName="Approve" CommandArgument='<%#Eval("reservationid")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnReject" Text="Cancel" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Pending", True, False) %>' CommandName="Reject" CommandArgument='<%#Eval("reservationid")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:GridView ID="gvReservationHistory" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%">
        <Columns>
            <asp:BoundField DataField="firstname" HeaderText="Name" HeaderStyle-width="20%" />
            <asp:BoundField DataField="preordermeals" HeaderText="Meals Ordered" HeaderStyle-width="15%" />
            <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="10%" />
            <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}" HeaderStyle-Width="25%" />
            <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="25%" />
            <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="20%" />
        </Columns>
    </asp:GridView>
    <table class="tableStyle">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblNothing"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>
