<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="branchReviews.aspx.vb" Inherits="FoodOnClick.branchReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableStyle">
        <tr>
            <td><asp:Button runat="server" ID="btnHome" OnClick="btnHome_Click" Text="Home" Width="100%" /></td>
        </tr>
    </table>
    <div class="alignTxtMid">
        <h1>View Reviews</h1>
        <asp:Label runat="server" Text="From "></asp:Label><asp:TextBox runat="server" ID="dateFrom" TextMode="Date"></asp:TextBox>
        <asp:Label runat="server" Text="To  " /><asp:TextBox runat="server" ID="dateTo" TextMode="Date"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
        <asp:Button runat="server" ID="btnClear" Text="Clear" OnClick="btnClear_Click" />
        <%--        <h2>
            <asp:Label runat="server" ID="lblTitle"></asp:Label></h2>--%>
    </div>
    <div style="width: 80%; margin-left: 30%">
        <asp:Repeater runat="server" ID="rptReview" OnItemDataBound="rptReview_ItemDataBound">
            <ItemTemplate>
                <table style="text-align: left !important; display: block; margin: 24px 0px 24px 0px">
                    <tr style="margin: 12px 0px 12px 0px">
                        <td>
                            <asp:Label runat="server" Text="Name: "></asp:Label>
                        </td>
                        <td style="text-align: left; padding: 2px 0px 2px 0px">
                            <asp:Label runat="server" ID="lblName" Text='<%#Eval("descriptiondel") %>'></asp:Label></td>
                    </tr>
                    <tr style="margin: 12px 0px 12px 0px">
                        <td>Rating: </td>
                        <td style="text-align: left; padding: 2px 0px 2px 0px">

                            <asp:Label runat="server" ID="lblRating"></asp:Label><asp:Label runat="server" ID="lblDate"></asp:Label></td>
                    </tr>
                    <tr style="margin: 12px 0px 12px 0px">
                        <td style="vertical-align:top">Feedback: </td>
                        <td style="text-align: left; padding: 2px 0px 2px 0px">

                            <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("description") %>'></asp:Label></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
