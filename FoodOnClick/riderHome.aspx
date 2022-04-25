<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="riderHome.aspx.vb" Inherits="FoodOnClick.riderHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://gothere.sg/jsapi?sensor=false"> </script>
    <script type="text/javascript">
<%--        gothere.load("maps");
        function initialize(lat, long) {
            if (GBrowserIsCompatible()) {
                //// Create the Gothere map object.
                var map = new GMap2(document.getElementById("map"));
                //// Set the center of the map.
                //map.setCenter(new GLatLng(1.362083, 103.819836), 11);
                //// Add zoom controls on the top left of the map.
                //map.addControl(new GSmallMapControl());
                //// Add a scale bar at the bottom left of the map.
                //map.addControl(new GScaleControl());
                // Create a map.
                //var map = new GMap2(document.getElementById("map"));
                //// Create a directions object.
                //var directions = new GDirections(map, document.getElementById("panel"));
                //// Get public transport directions.
                //var options = { travelMode: G_TRAVEL_MODE_TRANSIT };
                //directions.load("from:orchard road to:changi airport", options);
                // Create a directions object.
                if (document.getElementById('<%= hfID.ClientID %>') != null) {
                    var msg = document.getElementById('<%= hfID.ClientID %>').value;
                }
                var directions = new GDirections(map, document.getElementById("panel"));
                // Alert the user when the directions are loaded.
                GEvent.addListener(directions, "load", function () {
                    alert("Status code: " + directions.getDistance().html);
                });

                // Send a directions request.
                directions.load("from:" + lat + "," + long + " to:bedok");
            }
        }--%>
        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function showPosition(position) {
            window.location = 'riderHome.aspx?lat=' + position.coords.latitude + '&long=' + position.coords.longitude;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <div id="map" style="width: 500px; height: 300px; visibility: hidden;"></div>
    <div id="panel" style="width: 500px; height: 300px; visibility: hidden;"></div>--%>
    <table>
        <%--        <tr>
            <td colspan="3">
                <asp:Button runat="server" ID="btnRefresh" Text="Refresh" Visible="false" OnClick="btnRefresh_Click" />
            </td>  
        </tr>--%>
        <tr>
            <td colspan="3">
                <asp:Button runat="server" ID="btnStart" Text="Start" OnClick="btnStart_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <div id="divRpt" runat="server" style="height: 400px; overflow-y: auto;overflow-x:auto; width: 100%;">
                    <asp:Repeater runat="server" ID="rptOrders" EnableViewState="true" OnItemDataBound="rptOrders_ItemDataBound" OnItemCommand="rptOrders_ItemCommand">
                        <ItemTemplate>
                            <table style="margin:0px 0px">
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lblOrderId" Font-Bold="true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lblRestaurantName"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lblRestaurantAddress"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lbladdress"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lbluseraddress"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lblResToUser"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lblPaymentMethod"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lblDeliveryCharges"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label runat="server" ID="lbltotalcharges"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Button runat="server" ID="btnAccept" CommandName="Accept" CommandArgument='<%#Eval("batchid") %>' Text="Accept Order" /></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:Label ID="lblDefaultMessage" Font-Size="Larger" runat="server" Text="Sorry, There is no nearby job. Please press refresh to look for job" Visible="false"></asp:Label>
            </td>
        </tr>
        <%--        <tr>
            <td colspan="2"></td>
            <td>
                <asp:Button runat="server" ID="btnNotifySupport" Text="Notify Support" OnClick="btnNotifySupport_Click" /></td>
        </tr>--%>
<%--        <tr>
            <td colspan="2"></td>
            <td>
                <asp:Button runat="server" ID="btnSearch" Text="Search" /></td>
        </tr>--%>
        <tr>
            <td colspan="3"></td>
        </tr>
    </table>
    <%--    <asp:HiddenField runat="server" ID="lat" />
    <asp:HiddenField runat="server" ID="long" />--%>
</asp:Content>
