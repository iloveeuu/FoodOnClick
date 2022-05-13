<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="administratorReplySupport.aspx.vb" Inherits="FoodOnClick.AdministratorReplySupport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
        <br />
        <br />
        <h1>Administrator Reply Support </h1>
        </div>
        

        <br />
  

        
         <table style="width:100%" >
                            <tr>
                                <td>
                                     <asp:RadioButtonList ID="UserType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="UserTypes" AutoPostBack="True"> 
                                        <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                                        <asp:ListItem Text="Rider" Value="Rider"></asp:ListItem>
                                        <asp:ListItem Text="Restaurant" Value="Restaurant"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                     <asp:RadioButtonList ID="ReplyStatus" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="ReplyStatuses"  AutoPostBack="True">
                                        <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                        <asp:ListItem Text="Solved" Value="Solved"></asp:ListItem>
                                     </asp:RadioButtonList>
                                </td>
                                

                            </tr>
        </table>





        <div style="overflow-x: auto; text-align: center; width: 100%">
            <div style="width:80%;margin:0 auto">
                <asp:Repeater  runat="server" ID="rptReplyUser" OnItemDataBound="rptReplyUser_ItemDataBound" OnItemCommand="rptReplyUser_ItemCommand" EnableViewState="false">
                    <HeaderTemplate>
                     
                       <br />
                       <br />
                       <br />
                       <br />
                       <table style="width:100%" border="1">
                           <tr>
                                <td width="5%">SupportID</td>
                                <td width="5%">Status</td>
                                <td width="5%">UserID</td>
                                <td width="10%">Type</td>
                                <td width="20%">Subject</td>
                                <td width="25%">Description</td>
                                <td width="10%">DateSubmitted</td>
                                <td width="10%">DateClosed</td>
                                <td width="10%">Reply</td>
                     
                           </tr>
                           
                      
    

                  </HeaderTemplate>
                    



            <ItemTemplate>
                     <tr>
                           <td width="5%"><asp:Label runat="server" ID="supportID" Text='<%#Eval("supportid") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="status" Text='<%#Eval("status") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="userID" Text='<%#Eval("userID") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="type" Text='<%#Eval("type") %>'></asp:Label></td>
                           <td width="20%"><asp:Label runat="server" ID="subject" Text='<%#Eval("subject") %>'></asp:Label></td>
                           <td width="25%"><asp:Label runat="server" ID="description" Text='<%#Eval("description") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="datesubmitted" Text='<%#Eval("datesubmitted") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="dateclose" Text='<%#Eval("dateclose") %>'></asp:Label></td>
                           <td width="10%"><asp:Button ID="replySupport" Text="Reply" CommandName="Reply" runat="server" CommandArgument='<%#Eval("supportid") %>'/></td>
                        
                     </tr> 
                <br />
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        </div>
        </div>




</asp:Content>
