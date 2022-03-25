<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="administratorHome.aspx.vb" Inherits="FoodOnClick.administratorHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="logo">
        <br />
        <br />
        <h1>Administrator Home Page</h1>
        </div>
        

        <table>
            <tr>
                <td><h2>Pending Approval</h2></td>
                <td><asp:Label ID="totalPendingCaseHome" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><h2>Pending Support Issue </h2></td>
                <td><asp:Label ID="totalSupportCaseHome" runat="server"></asp:Label></td>
            </tr>
        </table>

        <table>
<%--            <tr>
                <td>
                    <asp:button  runat="server" ID="dashBoard" Text="Dashboard"/>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:button runat="server" ID="manageApproval" Text="Manage Registrations"/>    
                </td>
            </tr>
            <tr>
               <td>
                   <asp:button runat="server" ID="manageOrders" Text="Manage Orders"/>
               </td>
            </tr>
            <tr>
                <td>
                    <asp:button runat="server" ID="supportIssues" Text="Support Issues"/>
                </td>
            </tr>
       

        </table>


</asp:Content>
