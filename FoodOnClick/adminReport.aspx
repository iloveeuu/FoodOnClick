<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="adminReport.aspx.vb" Inherits="FoodOnClick.adminReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div>
        <br />
        <br />
        <h1>Admin Report </h1>
        </div>
        

        <br />
  

        
         <table style="width:100%" >
                            <tr>
                                <td>
                                     <asp:RadioButtonList ID="adminReportFilterButton" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="adminReportFilter" AutoPostBack="True"> 
                                        <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Daily" Value="Date"></asp:ListItem>
                                        <asp:ListItem Text="Weekly" Value="Week"></asp:ListItem>
                                        <asp:ListItem Text="Monthly" Value="Month"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                            </tr>

        </table>
        <br />
        <br />

        <table style="width:50%">
            <tr>
                <td><asp:Label runat="server" Text="Total Customer:"></asp:Label></td>
                <td><asp:Label runat="server" ID="customerNum" ></asp:Label></td>
                <td><asp:Label runat="server" Text="Total Rider:"></asp:Label></td>
                <td><asp:Label runat="server" ID="riderNum"></asp:Label></td>
                <td><asp:Label runat="server" Text="Total Restaurant:"></asp:Label></td>
                <td><asp:Label runat="server" ID="restaurantNum" ></asp:Label></td>
            </tr>


        </table>

        <br />
        <br />

        <div style="overflow-x: auto; text-align: center; width: 100%">
            <div style="width:80%;margin:0 auto">
                <asp:Repeater  runat="server" ID="adminReport" OnItemDataBound="adminReport_ItemDataBound" OnItemCommand="adminReport_ItemCommand" EnableViewState="false">
                    <HeaderTemplate>
                     
                       <br />
                       <br />
                       <br />
                       <br />
                       <table style="width:80%" border="1">
                           <tr>
                                <td width="30%">Restaurant</td>
                                <td width="40%">Period</td>
                                <td width="15%">OrderNum</td>
                                <td widht="15%">Sales</td>
                           </tr>
                           
                       </table>
                  </HeaderTemplate>
                 
            <ItemTemplate>
                 <table style="width:80%">
                     <tr>
                           <td width="30%"><asp:Label runat="server" ID="restaurant" Text='<%#Eval("username") %>'></asp:Label></td>
                           <td width="40%"><asp:Label runat="server" ID="period" Text='<%#Eval("period") %>'></asp:Label></td>
                           <td width="15%"><asp:Label runat="server" ID="OrderNum" Text='<%#Eval("totalOrder") %>'></asp:Label></td>
                           <td width="15%"><asp:Label runat="server" ID="Sales" Text='<%#Eval("sales") %>'></asp:Label></td>
                     </tr>
  
                </table>   
                <br />
            </ItemTemplate>
        </asp:Repeater>
        </div>
        </div>




</asp:Content>
