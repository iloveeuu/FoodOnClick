<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="administratorHome.aspx.vb" Inherits="FoodOnClick.administratorHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="logo">
        <h1>Food on Click</h1>
        <br />
        <br /
        <h1>Administrator Home Page</h1>
        </div>
        
        <table>
            <tr>
                <td><h2>Pending Approval</h2></td>
                <td><h2>55</h2></td>
            </tr>
            <tr>
                <td><h2>Pending Support Issue </h2></td>
                <td><h2>25</h2></td>
            </tr>
        </table>

        <table>
            <tr>
                <td>
                    DashBoard
                </td>
                <td>
                    <asp:button  runat="server" ID="dashBoard" />
                </td>
            </tr>
            <tr>
                <td>
                    Manage Registrations
                </td>
                <td>
                    <asp:button runat="server" ID="manageApproval" OnClick="manageApprovalClick"/>    
                </td>
            </tr>
            <tr>
               <td>
                   Manage Orders
               </td>
               <td>
                   <asp:button runat="server" ID="manageOrders" />
               </td>
            </tr>
            <tr>
                <td>
                    Support Issues
                </td>
                <td>
                    <asp:button runat="server" ID="supportIssues" />
                </td>
            </tr>
       

        </table>
   




</asp:Content>
