<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="riderDelivery.aspx.vb" Inherits="FoodOnClick.riderDelivery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #map {
            height: 350px;
            width: 100%;
        }
    </style>
    <script type="text/javascript">
<%--        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(setPosition);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function setPosition(position) {
            console.log(document.getElementById("<%=hfLocLatitude.ClientID%>".value));
            if (document.getElementById("<%=hfLocLatitude.ClientID%>").value = "0") {
                document.getElementById("<%=hfLocLatitude.ClientID%>").value = position.coords.latitude;
                document.getElementById("<%=hfLocLongitude.ClientID%>").value = position.coords.longitude;
                console.log(document.getElementById("<%=hfLocLatitude.ClientID%>").value + " Set liao");
            }
            else if (document.getElementById("<%=hfLocLatitude.ClientID%>").value !== position.coords.latitude && document.getElementById("<%=hfLocLongitude.ClientID%>").value !== position.coords.longitude)
            {
                getLocation1();
            }
            
        }
        function getLocation1() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(setPosition1);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function setPosition1(position) {
            console.log(typeof(document.getElementById("<%=hfLocLatitude.ClientID%>").value) + " SetPositon1");
            document.getElementById("<%=hfLocLatitude.ClientID%>").value = position.coords.latitude;
            document.getElementById("<%=hfLocLongitude.ClientID%>").value = position.coords.longitude;
        }--%>

        //var directionsService = new google.maps.DirectionsService();
        //var directionsDisplay = new google.maps.DirectionsRenderer();

        //var map = new google.maps.Map(document.getElementById('map'), {
        //    zoom: 7,
        //    mapTypeId: google.maps.MapTypeId.ROADMAP
        //});

        //directionsDisplay.setMap(map);

        //var request = {
        //    origin: position.coords.latitude + "," + position.coords.longitude,
        //    destination: "Blk 11, #01-11, Ang Mo Kio Central",
        //    travelMode: google.maps.DirectionsTravelMode.Bicycle
        //};

        //directionsService.route(request, function (response, status) {
        //    if (status == google.maps.DirectionsStatus.OK) {
        //        directionsDisplay.setDirections(response);
        //    }
        //});

        //function initMap() {

        //    var macc = { lat: 42.1382114, lng: -71.5212585 };

        //    var map = new google.maps.Map(

        //        document.getElementById('map'), { zoom: 15, center: macc });

        //    var marker = new google.maps.Marker({ position: macc, map: map });

        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfLocLatitude" runat="server" Value="0" />
    <asp:HiddenField ID="hfLocLongitude" runat="server" Value="0" />
    <div style="width: 100%">
        <iframe style="width: 100%; height: 500px;" runat="server" id="iframee"></iframe>
    </div>
    <table class="tableStyle" id="tblPickUp" runat="server">
        <tr>
            <td>Order ID:</td>
            <td>
                <asp:Label runat="server" ID="lblOrderNum"></asp:Label></td>
        </tr>
        <tr>
            <td>Name:</td>
            <td>
                <asp:Label runat="server" ID="lblRestaurantName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:Label runat="server" ID="lblRestaurantAddress"></asp:Label></td>
        </tr>
        <tr>
            <td>Ordered At:</td>
            <td>
                <asp:Label runat="server" ID="lblOrderTime"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnPickUp" Text="Collected Food" OnClick="btnPickUp_Click" Width="100%" Height="30px"  />
            </td>
        </tr>
    </table>
    <table class="tableStyle" id="tblDelivering" runat="server">
        <tr>
            <td>Order ID:</td>
            <td>
                <asp:Label runat="server" ID="lblOrderNum1"></asp:Label></td>
        </tr>
        <tr>
            <td>Name:</td>
            <td>
                <asp:Label runat="server" ID="lblCustomerName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:Label runat="server" ID="lblCustomerAddress"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Phone:</td>
            <td>
                <asp:Label runat="server" ID="lblPhoneNumber"></asp:Label></td>
        </tr>
        <tr>
            <td>Payment :</td>
            <td>
                <asp:Label runat="server" ID="lblPaymentMethod"></asp:Label>
            </td>
        </tr>
<%--        <tr>
            <td>Delivery Charges:</td>
            <td>
                <asp:Label runat="server" ID="lblDeliveryCharges"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td>Total cost:</td>
            <td>
                <asp:Label runat="server" ID="lblTotalCharges"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnDelivery" Text="Delivered Food" OnClick="btnDelivery_Click" Width="100%" Height="30px" />
            </td>
        </tr>
    </table>
    <%--<div id="map" ></div>--%>
    <%--    <h1>Show Map</h1>
    <asp:HyperLink ID="hlMap" Target="_blank" runat="server"></asp:HyperLink>
    <asp:Button ID="btnDirectionToRestaurant" Style="display: none;" runat="server" OnClick="btnDirectionToRestaurant_Click" />--%>

    <%--<script async defer
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U&sensor=false">
    </script>--%>

    <%--<script async defer

    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U&callback=initMap">

    </script>--%>
</asp:Content>
