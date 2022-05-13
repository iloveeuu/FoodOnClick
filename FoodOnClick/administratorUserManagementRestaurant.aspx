<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="administratorUserManagementRestaurant.aspx.vb" Inherits="FoodOnClick.administratorUserManagementRestaurant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        <br />
        <br />
        <h1>Restaurant Manager Management</h1>
        </div>
        
         <br />
         <br />
         <div style="overflow-x: auto; text-align: center; width: 100%">
            <div style="width:90%;margin:0 auto">
                <asp:Repeater  runat="server" ID="rptAdminRestaurant" OnItemDataBound="rptAdminRestaurant_ItemDataBound" OnItemCommand="rptAdminRestaurant_ItemCommand" EnableViewState="false">
                    <HeaderTemplate>
                        <table style="width:100%" border="1">
                            <tr>
                                <th width="5%">UserID</th>
                                <th width="5%">FirstName</th>
                                <th width="5%">LastName</th>
                                <th width="10%">Address</th>
                                <th width="10%">PhoneNumber</th>
                                <th width="5%">Gender</th>
                                <th width="10%">DateofBirth</th>
                                <th width="7.5%">UserStatus</th>
                                <th width="10%">TotalRestaurant</th>
                                <th width="10%">TotalOrders</th>
                                <th width="7.5%">Activate</th>
                                <th width="7.5%">Block</th>
                            </tr>
                  </HeaderTemplate>



            <ItemTemplate>
                     <tr>
                           <td width="5%"><asp:Label runat="server" ID="lblUserId" Text='<%#Eval("userId") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="firstName" Text='<%#Eval("firstName") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="lastName" Text='<%#Eval("lastName") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="address" Text='<%#Eval("address") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="phoneNumber" Text='<%#Eval("phone") %>'></asp:Label></td>
                           <td width="5%"><asp:Label runat="server" ID="gender" Text='<%#Eval("gender") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="dateofBirth" Text='<%#Eval("dateofbirth") %>'></asp:Label></td>
                           <td width="7.5%"><asp:Label runat="server" ID="statusAfterApproved" Text='<%#Eval("userStatus") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="countNumber" Text='<%#Eval("TotalRestaurant") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="totalDeliveryCharges" Text='<%#Eval("TotalOrders") %>'></asp:Label></td>
                           <td width="7.5%"><asp:Button ID="sysAdminCustomerActivate_Approve" Text="Activate" CommandName="Activate" runat="server" CommandArgument='<%#Eval("userId") %>'/></td>
                           <td width="7.5%"><asp:Button ID="sysAdminCustomerBlock" Text="Block" CommandName="Block" runat="server" CommandArgument='<%#Eval("userId") %>' /></td>
                     
                     </tr>
  
                <br />
            </ItemTemplate>
                    <FooterTemplate>
                </table>
            </FooterTemplate>
           </asp:Repeater>
                                      


</asp:Content>




