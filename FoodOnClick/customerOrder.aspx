<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerOrder.aspx.vb" Inherits="FoodOnClick.customerOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        a.popup:target {
            display: block;
        }

            a.popup:target + div.popup {
                display: block;
            }

        a.popup {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            z-index: 3;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.8);
            cursor: default;
        }

        div.popup {
            display: none;
            background: white;
            width: 30%;
            height: 40%;
            position: fixed;
            top: 35%;
            left: 35%;
            /*margin-left: -320px;*/ /* = -width / 2 */
            /*margin-top: -240px;*/ /* = -height / 2 */
            z-index: 4;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }

            /* links to close popup */
            div.popup > a.close {
                color: white;
                position: absolute;
                font-weight: bold;
                right: 10px;
            }

                div.popup > a.close.word {
                    top: 100%;
                    margin-top: 5px;
                }

                div.popup > a.close.x {
                    bottom: 100%;
                    margin-bottom: 5px;
                }

        @media screen and (max-width: 1000px) {
            div.popup {
                display: none;
                background: white;
                width: 70%;
                height: 60%;
                position: fixed;
                top: 15%;
                left: 15%;
            }
        }
    </style>
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
        <h2>Order</h2>
    </div>
    <br />
    <div class="container">
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Restaurant Name:
          </div>
			<div class="col-50">
				<asp:Label ID="lblRestName" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Halal:
          </div>
			<div class="col-50">
				<asp:Label ID="lblHalal" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Address:
          </div>
			<div class="col-50">
				<asp:Label ID="lblAddress" runat="server"></asp:Label>
			  </div>
        </div>
   </div>
    <br/>
    <div>
        <h3>Search Menu</h3>
    </div>
    <br/>
	<div class="container">
        <div class="row">
            <div class="col-20">
				<asp:Label ID="Label11" runat="server" Text="Dish Name:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtDishName" CssClass="textWidthCustSearch" runat="server"></asp:TextBox>
			  </div>
          <div class="col-20">
             <asp:Label ID="Label8" runat="server" CssClass="textWidthCustSearch" Text="Food Type:"></asp:Label>
          </div>
          <div class="col-30">
			<asp:DropDownList ID="ddlType" CssClass="ddlWidthCustSearch" runat="server"  DataTextField="FKmenuFoodType" DataValueField="FKmenuFoodTypeId"></asp:DropDownList>
          </div>
        </div>
		<div class="row">
			<div class="col-20">
				<asp:Label ID="Label1" runat="server" Text="Min. Price:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtMinPrice" CssClass="textWidthCustSearch" runat="server" TextMode="Number"></asp:TextBox>
			  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtMinPrice" ErrorMessage="Cannot less than 0" Operator="GreaterThanEqual" 
					Type="Integer" ValueToCompare="0" ForeColor="Red" />
			  </div>
			<div class="col-20">
				<asp:Label ID="Label2" runat="server" Text="Max. Price:"></asp:Label>
			</div>
          <div class="col-30">
				<asp:TextBox ID="txtMaxPrice" CssClass="textWidthCustSearch" runat="server" TextMode="Number"></asp:TextBox>
			  <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtMaxPrice" ErrorMessage="Cannot less than 0" Operator="GreaterThanEqual" 
					Type="Integer" ValueToCompare="0" ForeColor="Red" />
			  </div>
        </div>
		<div class="row">
			<div class="col-50"  style="text-align: center;">
				<asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server"  Width="50%" Text="Back" />
			</div>
			<div class="col-50" style="text-align: center;">
				<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click"  Width="50%" Text="Search" />
			</div>
		</div>
   </div>
	<br />
		<%--<asp:GridView ID="gvMenu" Class="gvMenu" OnRowCommand="gvMenu_RowCommand" runat="server" AutoGenerateColumns="false" Height="100%">
                <Columns>
                    <asp:BoundField DataField="dishName" HeaderText="Menu" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="price" HeaderText="Price ($)" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="describe" HeaderText="Description" HtmlEncode="false" HeaderStyle-Width="40%" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfMenuId" runat="server" Value='<%# Eval("menuid") %>' />
                            <asp:HiddenField ID="hfBranchId" runat="server" Value='<%# Eval("branchid") %>' />
                            <asp:TextBox ID="txtQty" runat="server" TextMode="Number" Width="20%"></asp:TextBox><br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="Must be more than 0" Operator="GreaterThan" 
					            Type="Integer" ValueToCompare="0" ForeColor="Red" /><br />
                            <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doAddCart"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
	<div style="text-align:center;">
			<p id="errorText" width="100%" runat="server" style="display:none;">
				Please fill up correct quantity
			</p>
	    <asp:Repeater runat="server" ID="rptMenu" EnableViewState="true" OnItemCommand="rptMenu_ItemCommand">
            <ItemTemplate>
            <div style="border: 1px solid black;display:inline-grid;text-align:center;width:150px;height:270px;" >
				<center>
					<asp:ImageButton runat="server" CommandName="viewDetail" 
						CommandArgument='<%#Eval("menuid") %>' ID="imgRest" Width="130px" Height="130px" ImageUrl='<%#Eval("path") %>' />
				</center>
				<asp:Label runat="server" ID="lblDishName" style="text-transform: capitalize;" Text='<%#Eval("dishName") %>'></asp:Label>
				<asp:Label runat="server" ID="lblType" style="text-transform: capitalize;" Text='<%#Eval("type") %>'></asp:Label>
				<asp:Label runat="server" ID="lblPrice" Text='<%# "$ " + Eval("price").ToString() %>'></asp:Label>
                <asp:HiddenField ID="hfBranchId" runat="server" Value='<%# Eval("branchid") %>' />
				<center>
				<asp:TextBox ID="txtQty" runat="server" TextMode="Number" Width="20%"></asp:TextBox>
				</center>
				<asp:Button ID="btnAdd" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("menuid") %>'   CommandName="doAddCart"/>
			</div>
            </ItemTemplate>
        </asp:Repeater>
	</div>
	<br />
    <div class="container">
        <div class="row">
			<div class="col-100" style="text-align: center;">
                <asp:Button ID="btnShoppingCart" runat="server" OnClick="btnShoppingCart_Click"  Width="30%" Text="Go to Shopping Cart" />
			</div>
		</div>
    </div>
	<br />
	<a runat="server" id="my_popup" class="popup"></a>
    <div runat="server" id="popup" class="popup">
        <h3>Menu Detail</h3>
            <div class="container">
		        <div class="row">
                  <div class="col-100"  style="text-align: center;" >
			          <asp:Label ID="lblPopUpDishName" runat="server" style="text-transform: capitalize;"></asp:Label>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
			          <asp:Label ID="lblPopUpFoodType" runat="server" style="text-transform: capitalize;"></asp:Label>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
			          <asp:Label ID="lblPopUpPrice" runat="server"></asp:Label>
                  </div>
                </div>
                 <div class="row">
                  <div class="col-100"  style="text-align: center;" >
			          <br />
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      Description:
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
			          <asp:Label ID="lblPopUpDesc" runat="server"></asp:Label>
                  </div>
                </div>
           </div>
        <a class="close x">
            <asp:LinkButton runat="server" CssClass="close x" OnClick="Unnamed_Click">x</asp:LinkButton></a>
        <a class="close word">
            <asp:LinkButton runat="server" CssClass="close word" OnClick="Unnamed_Click">Close</asp:LinkButton></a>
    </div>
</asp:Content>
