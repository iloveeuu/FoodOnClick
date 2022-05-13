<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="restaurantReport.aspx.vb" Inherits="FoodOnClick.restaurantReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <div>
        <br />
        <br />
        <h1>Restaurant Report </h1>
        </div>
        

        <br />
  

        
         <table style="width:100%" >
                            <tr>
                                <td>
                                     <asp:RadioButtonList ID="restaurantReportFilterButton" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="restaruantReportFilter" AutoPostBack="True"> 
                                        <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Daily" Value="Date"></asp:ListItem>
                                        <asp:ListItem Text="Weekly" Value="Week"></asp:ListItem>
                                        <asp:ListItem Text="Monthly" Value="Month"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                            </tr>

        </table>





        <div style="overflow-x: auto; text-align: center; width: 100%">
            <div style="width:80%;margin:0 auto">
                <asp:Repeater  runat="server" ID="restaurantReport" OnItemDataBound="restaurantReport_ItemDataBound" OnItemCommand="restaurantReport_ItemCommand" EnableViewState="false">
                    <HeaderTemplate>
                     
                       <br />
                       <table style="width:80%" border="1">
                           <tr>
                                <td width="30%">Branch</td>
                                <td width="20%">Period</td>
                                <td width="30%">Menu</td>
                                <td width="10%">TotalOrder</td>
                                <td widht="10%">Sales($)</td>
                  </HeaderTemplate>
                 
            <ItemTemplate>
                     <tr>
                           <td width="30%"><asp:Label runat="server" ID="branch" Text='<%#Eval("address") %>'></asp:Label></td>
                           <td width="20%"><asp:Label runat="server" ID="period" Text='<%#Eval("period") %>'></asp:Label></td>
                           <td width="30%"><asp:Label runat="server" ID="menu" Text='<%#Eval("cuisineName") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="OrderNum" Text='<%#Eval("totalOrder") %>'></asp:Label></td>
                           <td width="10%"><asp:Label runat="server" ID="Sales" Text='<%#Eval("sales") %>'></asp:Label></td>
                     </tr> 
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        </div>
        </div>




</asp:Content>




