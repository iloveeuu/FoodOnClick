<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="notifySupport.aspx.vb" Inherits="FoodOnClick.notifySupport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="signup-page" runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <h3>Support form</h3>
        <br />
        <hr />
        <br />
        <table id="tableStyle">
            <tr>
                <td>Subject:
                </td>
                <td>
                    <asp:DropDownList ID="ddlMsgType" runat="server" width ="200">
                        <asp:ListItem Value="Order related Issues" Selected="True">Order related Issues</asp:ListItem>
                        <asp:ListItem Value="Technical issues">Technical issues</asp:ListItem>
                        <asp:ListItem Value="App issues and Feedback">App issues and Feedback</asp:ListItem>
                        <asp:ListItem Value="Account and Security">Account and Security</asp:ListItem>
                        <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>Message:
                </td>
                <td>
                    <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine"  placeholder ="Please include Order ID for order related issues, Thank you." Width="250" Height="150"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan=" 2">
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="width: 100%" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="width: 100%" />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
