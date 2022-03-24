<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchReservation.aspx.vb" Inherits="FoodOnClick.branchReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        a.popup:target {
            display: block;
        }

            a.popup:target + div.popup {
                display: block;
            }

        a.popup {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            z-index: 3;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.8);
            cursor: default;
        }

        div.popup {
            display: none;
            background: white;
            width: 30%;
            height: 40%;
            position: fixed;
            top: 35%;
            left: 35%;
            /*margin-left: -320px;*/ /* = -width / 2 */
            /*margin-top: -240px;*/ /* = -height / 2 */
            z-index: 4;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }

            /* links to close popup */
            div.popup > a.close {
                color: white;
                position: absolute;
                font-weight: bold;
                right: 10px;
            }

                div.popup > a.close.word {
                    top: 100%;
                    margin-top: 5px;
                }

                div.popup > a.close.x {
                    bottom: 100%;
                    margin-bottom: 5px;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="overflow-x: auto;">
        <table id="tableStyle">
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnBack" Text="Home" Width="100%" OnClick="btnBack_Click" /></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">
                    <h1 style="text-align: center">Reservations</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnToday" Text="Today" Width="100%" OnClick="btnToday_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="btnUpcoming" Text="Upcoming" Width="100%" OnClick="btnUpcoming_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="btnHistory" Text="History" Width="100%" OnClick="btnHistory_Click" /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <h2>
                        <asp:Label runat="server" ID="lblTitle"></asp:Label></h2>
                </td>
            </tr>
        </table>

        <asp:GridView ID="gvReservationToday" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%" OnRowCommand="gvReservation_RowCommand">
            <Columns>
                <asp:BoundField DataField="firstname" HeaderText="Name" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="preordermeals" HeaderText="Meals Ordered" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="20%" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnApprove" Text="Approve" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Pending", True, False) %>' CommandName="Approve" CommandArgument='<%#Eval("reservationid")%>' />
                        <asp:Button runat="server" CssClass="btn1" ID="btnComplete" Text="Complete" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Approved", True, False) %>' CommandName="Complete" CommandArgument='<%#Eval("reservationid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnReject" Text="Reject" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Pending", True, False) %>' CommandName="Reject" CommandArgument='<%#Eval("reservationid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnView" Text="View" UseSubmitBehavior="false" Visible='<%# If(Eval("preordermeals").ToString() = "Yes", True, False) %>' CommandName="View" CommandArgument='<%#Eval("batchid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:GridView ID="gvReservationUpcoming" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%" OnRowCommand="gvReservationUpcoming_RowCommand">
            <Columns>
                <asp:BoundField DataField="firstname" HeaderText="Name" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="preordermeals" HeaderText="Meals Ordered" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="20%" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnApprove" Text="Approve" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Pending", True, False) %>' CommandName="Approve" CommandArgument='<%#Eval("reservationid")%>' />
                        <asp:Button runat="server" CssClass="btn1" ID="btnComplete" Text="Complete" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Approved", True, False) %>' CommandName="Complete" CommandArgument='<%#Eval("reservationid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnReject" Text="Reject" UseSubmitBehavior="false" Visible='<%# If(Eval("Status").ToString() = "Pending", True, False) %>' CommandName="Reject" CommandArgument='<%#Eval("reservationid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnView" Text="View" UseSubmitBehavior="false" Visible='<%# If(Eval("preordermeals").ToString() = "Yes", True, False) %>' CommandName="View" CommandArgument='<%#Eval("batchid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvReservationHistory" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%">
            <Columns>
                <asp:BoundField DataField="firstname" HeaderText="Name" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="preordermeals" HeaderText="Meals Ordered" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="20%" />
            </Columns>
        </asp:GridView>
    </div>

    <table class="tableStyle">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblNothing"></asp:Label>
            </td>
        </tr>
    </table>
    <a runat="server" id="my_popup" class="popup"></a>
    <div runat="server" id="popup" class="popup">
        <h3>Menu preordered</h3>
        <asp:HiddenField runat="server" ID="hfbatch" />
        <asp:HiddenField runat="server" ID="hfstatus" />
        <asp:Repeater runat="server" ID="rptMenuOrdered" OnItemDataBound="rptMenuOrdered_ItemDataBound">
            <ItemTemplate>
                <div style="overflow-x: auto;">
                <table>
                    <tr>
                        <td>
                            <asp:Literal runat="server" ID="litName"></asp:Literal></td>
                        <td>
                            <asp:Literal runat="server" ID="litQuantity"></asp:Literal></td>
                        <td>
                            <asp:Literal runat="server" ID="litCost"></asp:Literal></td>
                    </tr>
                </table>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="alignTxtMid">
            <br />
            Payment Mode : <asp:Label runat="server" ID="lblPaymentMode"></asp:Label>
            <br />
            <br />
            Total cost :
                <asp:Label runat="server" ID="lblTotal"></asp:Label>
        </div>
        <div class="alignTxtMid">
            <br />
            <asp:Button runat="server" ID="btnApproveMenu" Text="Approve" OnClick="btnApproveMenu_Click" />
            <asp:Button runat="server" ID="btnRejectMenu" Text="Reject" OnClick="btnRejectMenu_Click" />
        </div>
        <a class="close x">
            <asp:LinkButton runat="server" CssClass="close x" OnClick="Unnamed_Click">x</asp:LinkButton></a>
        <a class="close word">
            <asp:LinkButton runat="server" CssClass="close word" OnClick="Unnamed_Click">Close</asp:LinkButton></a>
    </div>

</asp:Content>
