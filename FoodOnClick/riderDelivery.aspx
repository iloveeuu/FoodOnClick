<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="riderDelivery.aspx.vb" Inherits="FoodOnClick.riderDelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #map {
          height: 350px;
          width: 100%;
        }
    </style>
    <script type="text/javascript">
        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(setPosition);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function setPosition(position) {
            document.getElementById("<%=hfLocLatitude.ClientID%>").value = position.coords.latitude;
            document.getElementById("<%=hfLocLongitude.ClientID%>").value = position.coords.longitude;

            document.getElementById("<%=btnDirectionToRestaurant.ClientID %>").click();
        }

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
    <asp:HiddenField ID="hfLocLatitude" runat="server" />
    <asp:HiddenField ID="hfLocLongitude" runat="server" />
    <%--<div id="map" ></div>--%>
    <h1>Show Map</h1>
    <asp:HyperLink ID="hlMap" Target="_blank" runat="server"></asp:HyperLink>
    <asp:Button ID="btnDirectionToRestaurant" style= "display:none;" runat="server" OnClick="btnDirectionToRestaurant_Click" />

    <%--<script async defer
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U&sensor=false">
    </script>--%>

    <%--<script async defer

    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U&callback=initMap">

    </script>--%>
</asp:Content>
