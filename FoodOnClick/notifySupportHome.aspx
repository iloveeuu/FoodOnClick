<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="notifySupportHome.aspx.vb" Inherits="FoodOnClick.notifySupportHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div>
        <br />
        <br />
        <h1>User Notify Support Home  </h1>
        </div>
        

        <br />
  

        
         <table style="width:100%" >
                            <tr>
                                <td>
                                    <asp:button ID="submitNewSupport" Text="Submit new Support" runat="server" />
                                </td>
                            </tr>
        </table>
        <br />
        <br />
 


        <div style="overflow-x: auto; text-align: center; width: 100%">
            <div style="width:80%;margin:0 auto">
                <asp:Repeater  runat="server" ID="rptUserSupportSummary" OnItemDataBound="rptUserSupport_ItemBound" OnItemCommand="rptReplyUser_ItemCommand" EnableViewState="false">
                    <HeaderTemplate>
                     
                       <br />
                       <table style="width:100%" border="1">
                           <tr>
                                <td width="5%">SupportID</td>
                                <td width="5%">Status</td>
                                <td width="5%">UserID</td>
                                <td width="10%">Subject</td>
                                <td width="20%">Description</td>
                                <td width="25%">Conversation</td>
                                <td width="5%">DateSubmitted</td>
                                <td width="5%">DateClosed</td>
                                <td width="10%">Reply</td>
                                <td width="10%">Close</td>
                     
                           </tr>
                  </HeaderTemplate>
                    



            <ItemTemplate>
                     <tr>
                           <td width="5%"><asp:Label runat="server" ID="supportID" Text='<%#Eval("supportid") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="status" Text='<%#Eval("status") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="userID" Text='<%#Eval("userID") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="subject" Text='<%#Eval("subject") %>'></asp:Label></td>
                           <td width="20%"><asp:Label runat="server" ID="description" Text='<%#Eval("description") %>'></asp:Label></td>
                           <td width="25%"><asp:Label runat="server" ID="conversation" Text='<%#Eval("conversation") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="datesubmitted" Text='<%#Eval("datesubmitted") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="dateclose" Text='<%#Eval("dateclose") %>'></asp:Label></td>
                           <td width="10%"><asp:Button ID="replySupport" Text="Reply" CommandName="Reply" runat="server" CommandArgument='<%#Eval("supportid") %>'/></td>
                           <td width="10%"><asp:Button ID="closesSupport" Text="Close" CommandName="Close" runat="server" CommandArgument='<%#Eval("supportid") %>'/></td>
               
                     </tr> 
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        </div>
        </div>




</asp:Content>
