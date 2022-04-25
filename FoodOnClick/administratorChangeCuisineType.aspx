<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="administratorChangeCuisineType.aspx.vb" Inherits="FoodOnClick.administratorChangeCuisineType_aspxt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="logo">
        <br />
        <br />
        <h1>Edit Cuisine Type</h1>
        </div>

       <br />
       <br />



    <div style="overflow-x: auto; text-align: center; width: 100%">
        <div style="width:40%;margin:0 auto">
        <asp:Repeater runat="server" ID="rptCuisine" OnItemDataBound="rptCuisine_ItemDataBound" OnItemCommand="rptCuisine_ItemCommand" EnableViewState  ="false">
            <HeaderTemplate>

                    


                    <table style="width:100%">
                        <tr>
                            <td width="40%"><asp:Label runat="server" Text="Please input Cuisine Type"></asp:Label></td>
                            <td width="40%"><asp:Textbox ID="addCuisineName" runat="server" ></asp:Textbox></td>
                            <td width="10%"><asp:Button ID="systemAdminChangeCuisine_Add" Text="Add" CommandName="Add"  runat  ="server"/></td>
                            <td width="10%"></td>
                        </tr>
                        <tr>
                            <td width="40%"><asp:Label runat="server" Text="Please input Cuisine type ID for enable or disable"></asp:Label></td>
                            <td width="40%"><asp:TextBox ID="cuisineIDForEnableDisable" runat="server" ></asp:TextBox></td>
                            <td width="10%"><asp:Button ID="systemAdminChangeCuisine_Enable" Text="Enable" CommandName="Enable" runat="server" /></td>
                            <td width="10%"><asp:Button ID="systemAdminChangeCuisine_Disable" Text="Disable" CommandName="Disable" runat="server"/></td>
                        </tr>
                     </table>
                    
                    
                    <br />
                    <br />
                    <br />
                    <table style="width:100%" border="1"  >
                        <tr>
                              <th width="10%">ID</th>
                              <th width="60%">FoodType</th>
                              <th width="30%">status</th>
                        </tr>
                    </table>

            </HeaderTemplate>
            
            
            <ItemTemplate>
                <div>
                    <table style="width:100%" border="1">
                        <tr>
                            <td width="10%"><asp:Label ID="cuisineID"  runat="server" ></asp:Label></td>
                            <td width="60%"><asp:Label ID="foodType"  runat="server" ></asp:Label></td>
                            <td width="30%"><asp:Label ID="status"  runat="server" ></asp:Label></td>
                        </tr>
                    </table>


                </div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </div>


              
        
</asp:Content>
