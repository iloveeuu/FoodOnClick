<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="notifySupportHomeUserReplyDetail.aspx.vb" Inherits="FoodOnClick.notifySupportHomeUserReply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
        <br />
        <br />
        <h1>User Reply Support </h1>
        </div>
        

        <br />

        <table style="width:60%" border="1">
            <tr>
                <th width="10%">UserID</th>
                <th width="10%">SupportID</th>
                <th widht="10%">Type</th>
                <th width="10%">DateSubmitted</th>
                <th width="20%">Subject</th>
                <th width="40%">Description</th>
            </tr>
            <tr>
                <th width="10%"><asp:Label ID="UserID" runat="server"></asp:Label></th>
                <th width="10%"><asp:Label ID="SupportID" runat="server"></asp:Label></th>
                <th width="10%"><asp:Label ID="Type" runat="server" ></asp:Label></th>
                <th width="10%"><asp:Label ID="DateSubmitted" runat="server"></asp:Label></th>
                <th width="20%"><asp:Label ID="Subject" runat="server"></asp:Label></th>
                <th width="40%"><asp:Label ID="Description" runat="server"></asp:Label></th>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <table style="width:60%">
            <tr>
                <th>Previous Conversation</th>
            </tr>
            <tr>
                <td >
                    <asp:Label runat="server" ID="PreviousConversation"  Rows="10" width="100%" Visible="true"/>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:TextBox runat="server" ID="AdminReplyBox" TextMode="MultiLine" Rows="10" width="100%" placeholder="Please input your reply"/>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="reply" Text="Reply" CommandName="Reply" runat="server" width="100%" onclick="ReplyAnswer" CommandArgument='<%#Eval("supportid") %>'/></td>
            </tr>
        
 
        </table>












</asp:Content>
