<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="customerHistory.aspx.vb" Inherits="FoodOnClick.customerHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            
            $(".rating-star-block .star").mouseenter(function () {
                var hoverVal = $(this).attr('rating');
                $(this).prevUntil().addClass("filled");
                $(this).addClass("filled");
                $("#RAT").html(hoverVal);
            });

            $(".rating-star-block .star").mouseleave(function () {
                $("#" + $(this).parent().attr('id') + " .star").each(function () {
                    $(this).addClass("outline");
                    $(this).removeClass("filled");
                });
            });

            $(".rating-star-block .star").click(function () {

                var v = $(this).attr('rating');
                for (let i = 0; i < v; i++) {
                    let element = document.getElementById('starId' + (i + 1).toString());
                    element.className += ' filled';
                }
                document.getElementById("<%=hfRating.ClientID%>").value = v.toString();
            });

            $(".rating-star-block1 .star").mouseenter(function () {
                var hoverVal = $(this).attr('rating');
                $(this).prevUntil().addClass("filled");
                $(this).addClass("filled");
                $("#RAT").html(hoverVal);
            });

            $(".rating-star-block1 .star").mouseleave(function () {
                $("#" + $(this).parent().attr('id') + " .star").each(function () {
                    $(this).addClass("outline");
                    $(this).removeClass("filled");
                });
            });

            $(".rating-star-block1 .star").click(function () {

                var v = $(this).attr('rating');
                for (let i = 0; i < v; i++) {
                    let element = document.getElementById('starIdRest' + (i + 1).toString());
                    element.className += ' filled';
                }
                document.getElementById("<%=hfRatingRest.ClientID%>").value = v.toString();
            });

            $(".rating-star-block2 .star").mouseenter(function () {
                var hoverVal = $(this).attr('rating');
                $(this).prevUntil().addClass("filled");
                $(this).addClass("filled");
                $("#RAT").html(hoverVal);
            });

            $(".rating-star-block2 .star").mouseleave(function () {
                $("#" + $(this).parent().attr('id') + " .star").each(function () {
                    $(this).addClass("outline");
                    $(this).removeClass("filled");
                });
            });

            $(".rating-star-block2 .star").click(function () {

                var v = $(this).attr('rating');
                for (let i = 0; i < v; i++) {
                    let element = document.getElementById('starIdDel' + (i + 1).toString());
                    element.className += ' filled';
                }
                document.getElementById("<%=hfRatingRider.ClientID%>").value = v.toString();
            });

        });

    </script>
    <style>
        .rating-star-block .star.outline {
            background: url("Images/star-empty-lg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
        }
        .rating-star-block .star.filled {
            background: url("Images/star-fill-lg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
        }
        .rating-star-block .star {
            color:rgba(0,0,0,0);
            display : inline-block;
            height:24px;
            overflow:hidden;
            text-indent:-999em;
            width:24px;
        }

        .rating-star-block1 .star.outline {
            background: url("Images/star-empty-lg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
        }
        .rating-star-block1 .star.filled {
            background: url("Images/star-fill-lg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
        }
        .rating-star-block1 .star {
            color:rgba(0,0,0,0);
            display : inline-block;
            height:24px;
            overflow:hidden;
            text-indent:-999em;
            width:24px;
        }

        .rating-star-block2 .star.outline {
            background: url("Images/star-empty-lg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
        }
        .rating-star-block2 .star.filled {
            background: url("Images/star-fill-lg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
        }
        .rating-star-block2 .star {
            color:rgba(0,0,0,0);
            display : inline-block;
            height:24px;
            overflow:hidden;
            text-indent:-999em;
            width:24px;
        }
        a {
            color:#005782;
            text-decoration:none;
        }

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
            z-index: 4;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }

            div.popup > a.close {
                color: white;
                position: absolute;
                font-weight: bold;
                right: 10px;
            }
                div.popup > a.close.x {
                    bottom: 100%;
                    margin-bottom: 5px;
                }

        a.popup2:target {
            display: block;
        }

            a.popup2:target + div.popup2 {
                display: block;
            }

        a.popup2 {
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

        div.popup2 {
            display: none;
            background: white;
            width: 30%;
            height: 60%;
            position: fixed;
            top: 35%;
            left: 35%;
            z-index: 4;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }

            div.popup2 > a.close {
                color: white;
                position: absolute;
                font-weight: bold;
                right: 10px;
            }
                div.popup2 > a.close.x {
                    bottom: 100%;
                    margin-bottom: 5px;
                }


        @media screen and (max-width: 1000px) {
            div.popup {
                display: none;
                background: white;
                width: 70%;
                position: fixed;
                top: 15%;
                left: 15%;
            }

            div.popup2 {
                display: none;
                background: white;
                position: fixed;
                width: 80%;
                height: 50%;
                top: 15%;
                left: 15%;
            }
        }
    </style>
    <table id="tableStyle">
		<tr>
			<td>
				<asp:Button ID="btnProfile" Width="100%" Height="80%" runat="server" OnClick="btnProfile_Click" Text="Profile" />
			</td>
			<td>
				<asp:Button ID="btnHome" Width="100%" Height="80%" runat="server" OnClick="btnHome_Click" Text="Home" />
			</td>
            <td>
				<asp:Button ID="btnCart" Width="100%" Height="80%" runat="server" OnClick="btnCart_Click" Text="Cart" />
			</td>
		</tr>
    </table>
    <div>
        <h2>Reservation List</h2>
    </div>
    <br/>
    <div style="overflow-x:auto;">
        <%--CssClass="table table-responsive table-striped"--%>
		<asp:GridView ID="gvReservation" Width="70%" runat="server" OnRowCommand="gvReservation_RowCommand" OnRowDataBound="gvReservation_RowDataBound" AutoGenerateColumns="false" Height="100%" >
                <Columns>
                    <asp:BoundField DataField="restName" HeaderText="Restaurant" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-Width="30%" />
                    <asp:BoundField DataField="pax" HeaderText="Pax" HeaderStyle-Width="5%" />
                    <asp:BoundField DataField="date" HeaderText="Date" DataFormatString = {0:d} HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="time" HeaderText="Time" HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="duration" HeaderText="Duration" HeaderStyle-Width="10%" />
                    <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="15%" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfBranchId" runat="server" Value='<%# Eval("branchId") %>' />
                            <asp:HiddenField ID="hfBatchId" runat="server" Value='<%# Eval("batchId") %>' />
                            <asp:HiddenField ID="hfReservationId" runat="server" Value='<%# Eval("reservationId") %>' />
                            <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("email") %>' />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Container.DataItemIndex %>' Visible="false" CommandName="doCancel"/>
                            <asp:Button ID="btnPreOrder" runat="server" Text="Order List" CommandArgument='<%# Container.DataItemIndex %>'   Visible="false" CommandName="doCheckPreOrder"/>
                            <asp:Button ID="btnFeedback" runat="server" Text="Feedback" CommandArgument='<%# Container.DataItemIndex %>'   Visible="false" CommandName="doFeedback"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
	</div>
    <br />
    <div>
        <h2>Delivery Order List</h2>
    </div>
    <br/>
    <div style="overflow-x:auto;">
        <%--CssClass="table table-responsive table-striped"--%>
		<asp:GridView ID="gvDelivery" Width="70%" runat="server" OnRowCommand="gvDelivery_RowCommand" OnRowDataBound="gvDelivery_RowDataBound" AutoGenerateColumns="false" Height="100%" >
                <Columns>
                    <asp:BoundField DataField="restName" HeaderText="Restaurant" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-Width="30%" />
                    <asp:BoundField DataField="orderNum" HeaderText="Order ID" HeaderStyle-Width="30%" />
                    <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="15%" />
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfBranchId" runat="server" Value='<%# Eval("branchId") %>' />
                            <asp:HiddenField ID="hfBatchId" runat="server" Value='<%# Eval("batchId") %>' />
                            <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("email") %>' />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Container.DataItemIndex %>' Visible="false" CommandName="doCancel"/>
                            <asp:Button ID="btnOrder" runat="server" Text="Order List" CommandArgument='<%# Container.DataItemIndex %>'  CommandName="doCheckOrder"/>
                            <asp:Button ID="btnFeedback" runat="server" Text="Feedback" CommandArgument='<%# Container.DataItemIndex %>'   Visible="false" CommandName="doFeedback"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
	</div>
    <br />
    <a runat="server" id="my_popup" class="popup"></a>
    <div runat="server" id="popup" class="popup">
        <h3>Feedback</h3>
            <div class="container">
		        <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:HiddenField ID="hfPopUpBranchId" runat="server" />
                      <asp:HiddenField ID="hfPopUpBatchId" runat="server" />
                      <asp:HiddenField ID="hfPopUpReservationId" runat="server" />
                      <asp:Label ID="lblRest1" runat="server" style=" text-transform: capitalize;" Font-Bold="True"></asp:Label>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <div class="rating-star-block" id="starId">
                            <a class="star outline" id="starId1" href="#" rating="1" title="vote 1"> vote 1</a>
                            <a class="star outline" id="starId2" href="#" rating="2" title="vote 2"> vote 2</a>
                            <a class="star outline" id="starId3" href="#" rating="3" title="vote 3"> vote 3</a>
                            <a class="star outline" id="starId4" href="#" rating="4" title="vote 4"> vote 4</a>
                            <a class="star outline" id="starId5" href="#" rating="5" title="vote 5"> vote 5</a>
                        </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:TextBox TextMode="MultiLine" onkeypress="return this.value.length<=100" ID="txtFeedback" Width="200px" Height="90px" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:CheckBox ID="chkFollowUp" runat="server" Text="Follow Up" AutoPostBack="True" OnCheckedChanged="chkFollowUp_CheckedChanged"/>
                  </div>
                </div>
                <div id="divShowHide" runat="server">
                    <div class="row">
                      <div class="col-100"  style="text-align: center;" >
                          <asp:Label ID="Label3" runat="server" style=" text-transform: capitalize;" Text="Phone Number" Font-Bold="True"></asp:Label>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-100"  style="text-align: center;" >
                          <asp:TextBox TextMode="Number" ID="txtPhone" Width="200px" runat="server"></asp:TextBox>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-100"  style="text-align: center;" >
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            ControlToValidate="txtPhone" runat="server"
                            ErrorMessage="Must be 8 numbers"
                            ValidationExpression="^[0-9]{8}$" ForeColor="Red">
                            </asp:RegularExpressionValidator>
                      </div>
                    </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:HiddenField ID="hfRating" runat="server" />
                      <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100%" OnClick="btnSubmit_Click"/>
                  </div>
                </div>
           </div>
        <a class="close x"><asp:LinkButton runat="server" CssClass="close x" OnClick="Unnamed_Click">X</asp:LinkButton></a>
    </div>

    <a runat="server" id="my_popup2" class="popup2"></a>
    <div runat="server" id="popup2" class="popup2">
        <h3>Feedback</h3>
            <div class="container">
		        <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:HiddenField ID="hfPopUpOrderIdDel" runat="server" />
                      <asp:HiddenField ID="hfPopUpBranchIdDel" runat="server" />
                      <asp:HiddenField ID="hfPopUpBatchIdDel" runat="server" />
                      <asp:HiddenField ID="hfPopUpEmailDel" runat="server" />
                      <asp:Label ID="lblRest2" runat="server" style="text-transform: capitalize;" Font-Bold="True"></asp:Label>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:Label ID="Label1" runat="server" style="text-transform: capitalize;" Text="Food Feedback"></asp:Label>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <div class="rating-star-block1" id="starIdRest">
                            <a class="star outline" id="starIdRest1" href="#" rating="1" title="vote 1"> vote 1</a>
                            <a class="star outline" id="starIdRest2" href="#" rating="2" title="vote 2"> vote 2</a>
                            <a class="star outline" id="starIdRest3" href="#" rating="3" title="vote 3"> vote 3</a>
                            <a class="star outline" id="starIdRest4" href="#" rating="4" title="vote 4"> vote 4</a>
                            <a class="star outline" id="starIdRest5" href="#" rating="5" title="vote 5"> vote 5</a>
                        </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:TextBox TextMode="MultiLine" ID="txtFeedbackRest" Width="200px" Height="90px" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:CheckBox ID="chkFollowUp2" runat="server" Text="Follow Up" AutoPostBack="True" OnCheckedChanged="chkFollowUp2_CheckedChanged"/>
                  </div>
                </div>
                <div id="divShowHide2" runat="server">
                    <div class="row">
                      <div class="col-100"  style="text-align: center;" >
                          <asp:Label ID="Label4" runat="server" style=" text-transform: capitalize;" Text="Phone Number" Font-Bold="True"></asp:Label>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-100"  style="text-align: center;" >
                          <asp:TextBox MinLength="8" MaxLength="8" ID="txtPhone2" Width="200px" runat="server"></asp:TextBox>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-100"  style="text-align: center;" >
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                            ControlToValidate="txtPhone2" runat="server"
                            ErrorMessage="Must be 8 numbers"
                            ValidationExpression="^[0-9]{8}$" ForeColor="Red">
                            </asp:RegularExpressionValidator>
                      </div>
                    </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:Label ID="Label2" runat="server" style="text-transform: capitalize;" Text="Rider Feedback"></asp:Label>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <div class="rating-star-block2" id="starIdDel">
                            <a class="star outline" id="starIdDel1" href="#" rating="1" title="vote 1"> vote 1</a>
                            <a class="star outline" id="starIdDel2" href="#" rating="2" title="vote 2"> vote 2</a>
                            <a class="star outline" id="starIdDel3" href="#" rating="3" title="vote 3"> vote 3</a>
                            <a class="star outline" id="starIdDel4" href="#" rating="4" title="vote 4"> vote 4</a>
                            <a class="star outline" id="starIdDel5" href="#" rating="5" title="vote 5"> vote 5</a>
                        </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:TextBox TextMode="MultiLine" ID="txtFeedbackRider" Width="200px" Height="90px" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="row">
                  <div class="col-100"  style="text-align: center;" >
                      <asp:HiddenField ID="hfRatingRest" runat="server" />
                      <asp:HiddenField ID="hfRatingRider" runat="server" />
                      <asp:Button ID="btnSubmitDel" runat="server" Text="Submit" Width="100%" OnClick="btnSubmitDel_Click"/>
                  </div>
                </div>
           </div>
        <a class="close x"><asp:LinkButton runat="server" CssClass="close x" OnClick="Unnamed_Click">X</asp:LinkButton></a>
    </div>
</asp:Content>
