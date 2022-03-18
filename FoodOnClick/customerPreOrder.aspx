<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerPreOrder.aspx.vb" Inherits="FoodOnClick.customerPreOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
		<tr>
			<td>
				<asp:Button ID="btnProfile" Width="100%" Height="80%" runat="server" OnClick="btnProfile_Click" Text="Profile" />
			</td>
			<td>
				<asp:Button ID="btnHome" Width="100%" Height="80%" runat="server" OnClick="btnHome_Click" Text="Home" />
			</td>
		</tr>
    </table>
	<div>
        <h2>Reservation Pre-Order</h2>
    </div>
    <br/>
	<div>
		<asp:GridView ID="gvPreOrder" Width="40%" runat="server" AutoGenerateColumns="false" Height="100%">
                <Columns>
                    <asp:BoundField DataField="dishName" HeaderText="Menu" HeaderStyle-Width="80%" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="txtNumber" runat="server" TextMode="Number" Width="20%"></asp:TextBox>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doAdd"/>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
               
            </asp:GridView>
	</div>
	<br />
    <div>
        <h2>Add Pre-Order List</h2>
    </div>
    <div>
		<asp:GridView ID="gvCart" Width="40%" runat="server" AutoGenerateColumns="false" Height="100%">
                <Columns>
                    <asp:BoundField DataField="dishName" HeaderText="Menu" HeaderStyle-Width="80%" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="txtNumber" runat="server" TextMode="Number" Width="20%"></asp:TextBox>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doCancel"/>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
               
            </asp:GridView>
	</div>
	<br />
    <div>
        <asp:Button ID="btnPreOrder" runat="server"  Width="50%" Text="Create Pre-Order" />
    </div>
</asp:Content>
