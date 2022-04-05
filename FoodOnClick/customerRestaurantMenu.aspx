<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerRestaurantMenu.aspx.vb" Inherits="FoodOnClick.customerRestaurantMenu" %>
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
        <h2>Restaurant</h2>
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
		<div class="row">
          <div class="col-50" style="text-align: right;" >
			  Open Time:
          </div>
			<div class="col-50">
				<asp:Label ID="lblOpenTime" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
          <div class="col-50" style="text-align: right;" >
			  Close Time:
          </div>
			<div class="col-50">
				<asp:Label ID="lblCloseTime" runat="server"></asp:Label>
			  </div>
        </div>
		<div class="row">
			<div class="col-50" style="text-align: center;">
				<asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Width="80%" Text="Back" />
			</div>
			<div class="col-50" style="text-align: center;">
				<asp:Button ID="btnReserve" OnClick="btnResere_Click" runat="server" Width="80%" Text="Reserve" />
			</div>
		</div>
   </div>
	<br />
	<div>
        <h3>Restaurant Menu</h3>
    </div>
	<br />
	<div style="text-align:center;">
	    <asp:Repeater runat="server" ID="rptMenu" EnableViewState="true" OnItemCommand="rptMenu_ItemCommand">
            <ItemTemplate>
            <div style="border: 1px solid black;display:inline-grid;text-align:center;width:150px;height:230px;" >
					<center><asp:ImageButton runat="server" CommandName="viewDetail" 
						CommandArgument='<%#Eval("menuid") %>' ID="imgRest" Width="130px" Height="130px" ImageUrl='<%#Eval("path") %>' />
							</center>
					<asp:Label runat="server" ID="lblDishName" style="text-transform: capitalize;" Text='<%#Eval("dishName") %>'></asp:Label>
					<asp:Label runat="server" ID="lblType" style="text-transform: capitalize;" Text='<%#Eval("type") %>'></asp:Label>
					<asp:Label runat="server" ID="lblPrice" Text='<%# "$ " + Eval("price").ToString() %>'></asp:Label>
				</div>
            </ItemTemplate>
        </asp:Repeater>
	</div>
	<br />
	<a runat="server" id="my_popup" class="popup"></a>
    <div runat="server" id="popup" class="popup">
        <h3>Menu Detail</h3>
            <div class="container">
		        <div class="row">
                  <div class="col-100"  style="text-align: center;" >
			          <asp:Label ID="lblDishName" runat="server" style="text-transform: capitalize;"></asp:Label>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
			          <asp:Label ID="lblFoodType" runat="server" style="text-transform: capitalize;"></asp:Label>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
			          <asp:Label ID="lblPrice" runat="server"></asp:Label>
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
			          <asp:Label ID="lblDesc" runat="server"></asp:Label>
                  </div>
                </div>
           </div>
        <a class="close x">
            <asp:LinkButton runat="server" CssClass="close x" OnClick="Unnamed_Click">x</asp:LinkButton></a>
        <a class="close word">
            <asp:LinkButton runat="server" CssClass="close word" OnClick="Unnamed_Click">Close</asp:LinkButton></a>
    </div>
</asp:Content>
