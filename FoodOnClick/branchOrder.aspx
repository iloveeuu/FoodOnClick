<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchOrder.aspx.vb" Inherits="FoodOnClick.branchOrder" %>
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
                <td colspan="2">
                    <asp:Button runat="server" ID="btnBack" Text="Home" Width="100%" OnClick="btnBack_Click"/></td>
            </tr>
            <tr>
                <td colspan="2">
                    <h1 style="text-align: center">Orders</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnPending" Text="Pending" Width="100%" OnClick="btnPending_Click"/></td>
                <td>
                    <asp:Button runat="server" ID="btnCompleted" Text="History" Width="100%" OnClick="btnCompleted_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <h2>
                        <asp:Label runat="server" ID="lblTitle"></asp:Label></h2>
                </td>
            </tr>
        </table>

        <asp:GridView ID="gvOrders" Width="70%" runat="server" AutoGenerateColumns="false" Height="100%" OnRowCommand="gvOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="firstname" HeaderText="First Name" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="lastname" HeaderText="Last Name" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="type" HeaderText="Type" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="orderdate" HeaderText="Date" DataFormatString="{0:d}" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="ordertime" HeaderText="Time" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="type1" HeaderText="Status" HeaderStyle-Width="20%" />
<%--                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnApprove" Text="Accept" UseSubmitBehavior="false"  CommandName="Accept" CommandArgument='<%#Eval("batchid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnReject" Text="Reject" UseSubmitBehavior="false" CommandName="Reject" CommandArgument='<%#Eval("batchid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Button runat="server" CssClass="btn1" ID="btnView" Text="View" UseSubmitBehavior="false"  CommandName="View" CommandArgument='<%#Eval("batchid")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
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
        <h3>Menu order</h3>
        <asp:HiddenField runat="server" ID="hfbatch" />
        <asp:HiddenField runat="server" ID="hfstatus" />
        <asp:Repeater runat="server" ID="rptOrders"  OnItemDataBound="rptOrders_ItemDataBound">
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
            Payment mode : <asp:Label runat="server" ID="lblPaymentMode"></asp:Label>
            <br />
            <br />
            Delivery charges : <asp:Label runat="server" ID="lblDeliveryCharges"></asp:Label>
            <br />
            <br />
            <br />
            Total cost :
                <asp:Label runat="server" ID="lblTotal"></asp:Label>
        </div>
        <div class="alignTxtMid">
            <br />
            <asp:Button runat="server" ID="btnAcceptOrder" Text="Accept" OnClick="btnAcceptOrder_Click"/>
            <asp:Button runat="server" ID="btnRejectOrder" Text="Reject" OnClick="btnRejectOrder_Click"/>
        </div>
        <a class="close x">
            <asp:LinkButton runat="server" CssClass="close x" OnClick="Unnamed_Click">x</asp:LinkButton></a>
        <a class="close word">
            <asp:LinkButton runat="server" CssClass="close word" OnClick="Unnamed_Click">Close</asp:LinkButton></a>
    </div>
</asp:Content>
