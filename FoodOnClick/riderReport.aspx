<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="riderReport.aspx.vb" Inherits="FoodOnClick.riderReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div>
        <br />
        <br />
        <h1>Rider Report </h1>
        </div>
        

        <br />
  

        
         <table style="width:100%" >
                            <tr>
                                <td>
                                     <asp:RadioButtonList ID="riderReportFilterButton" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="riderReportFilter" AutoPostBack="True"> 
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
                <asp:Repeater  runat="server" ID="riderReport" OnItemDataBound="riderReport_ItemDataBound" OnItemCommand="riderReport_ItemCommand" EnableViewState="false">
                    <HeaderTemplate>
                     
                       <br />
                       <table style="width:60%" border="1">
                           <tr>
                                <td width="40%">Period</td>
                                <td width="30%">TotalOrder</td>
                                <td width="30%">Income($)</td>
                           </tr>
                           
                  </HeaderTemplate>
                 
            <ItemTemplate>
                     <tr>
                           <td width="40%"><asp:Label runat="server" ID="period" Text='<%#Eval("period") %>'></asp:Label></td>
                           <td width="30%"><asp:Label runat="server" ID="orderNum" Text='<%#Eval("totalOrder") %>'></asp:Label></td>
                           <td width="30%"><asp:Label runat="server" ID="deliveryCharges" Text='<%#Eval("totalDeliveryCharges") %>'></asp:Label></td>
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




