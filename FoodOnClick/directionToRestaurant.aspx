<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="directionToRestaurant.aspx.vb" Inherits="FoodOnClick.directionToRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* Optional: Makes the sample page fill the window. */
        html,
        body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #container {
            height: 100%;
            display: flex;
        }

        #sidebar {
            flex-basis: 15rem;
            flex-grow: 1;
            padding: 1rem;
            max-width: 30rem;
            height: 100%;
            box-sizing: border-box;
            overflow: auto;
        }

        #map {
            flex-basis: 0;
            flex-grow: 4;
            height: 100%;
            height: 400px;
        }
    </style>
    <script
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U&v=weekly">
    
    </script>
    <script type="text/javascript">
        function initMap() {
            var lat1 = parseFloat(document.getElementById("<%=hfLat.ClientID%>").value);
            var long1 = parseFloat(document.getElementById("<%=hfLong.ClientID%>").value);
            const myLatlng = { lat: lat1, lng: long1};
            const map = new google.maps.Map(document.getElementById("map"), {
                zoom: 23,
                //center: {
                //    lat: lat1, lng: long1
                //},
                gestureHandling: "greedy",
            });
            //const marker = new google.maps.Marker({
            //    position: myLatlng,
            //    map,
            //});
            
            map.setZoom(23);

            //map.setCenter(marker.getPosition());
            const directionsService = new google.maps.DirectionsService();
            const directionsRenderer = new google.maps.DirectionsRenderer({
                draggable: true,
                map,
                panel: document.getElementById("panel"),
            });

            //directionsRenderer.addListener("directions_changed", () => {
            //    const directions = directionsRenderer.getDirections();
            //    if (directions) {
            //        //computeTotalDistance(directions);
            //    }
            //});
            displayRoute(
                document.getElementById("<%=hfLoc.ClientID%>").value,
                document.getElementById("<%=hfCustomerAddress.ClientID%>").value,
                directionsService,
                directionsRenderer
            );
        }

        function displayRoute(origin, destination, service, display) {
            service
                .route({
                    origin: origin,
                    destination: destination,
                    travelMode: google.maps.TravelMode.BICYCLING,
                    region:"SG",

                })
                .then((result) => {
                    display.setDirections(result);
                })
                .catch((e) => {
                    alert("Could not display directions due to: " + e);
                });
        }

        function computeTotalDistance(result) {
            let total = 0;
            const myroute = result.routes[0];

            if (!myroute) {
                return;
            }

            for (let i = 0; i < myroute.legs.length; i++) {
                total += myroute.legs[i].distance.value;
            }

            total = total / 1000;
            document.getElementById("total").innerHTML = total + " km";
        }



        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.watchPosition(setPosition);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function setPosition(position) {
<%--            document.getElementById("<%=hfLat.ClientID%>").value = position.coords.latitude;
            document.getElementById("<%=hfLong.ClientID%>").value = position.coords.longitude;
            document.getElementById("<%=hfLoc.ClientID%>").value = position.coords.latitude + "," + position.coords.longitude;
            initMap();--%>
            ////alert(document.getElementById("<%=hfLoc.ClientID%>").value + "HEllo");
            //alert("hey");
            //if (sessionStorage.getItem("lat") == null && sessionStorage.getItem("long") == null) {
            //alert("First SEt");
            //sessionStorage.setItem("lat", position.coords.latitude);
            //sessionStorage.setItem("long", position.coords.longitude);
            window.document.getElementById('iframeMaps').src = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U&origin=" + position.coords.latitude + "," + position.coords.longitude + "&destination=" + document.getElementById("<%=hfCustomerAddress.ClientID%>").value + "&region=SG&mode=bicycling&center=" + position.coords.latitude + "," + position.coords.longitude + "&zoom=19";
<%--            }
            else if (sessionStorage.getItem("lat") != position.coords.latitude && sessionStorage.getItem("long") != position.coords.longitude)
            {
                alert("Moving");
                window.document.getElementById('iframeMaps').src = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U&origin=" + position.coords.latitude + "," + position.coords.longitude + "&destination=" + document.getElementById("<%=hfCustomerAddress.ClientID%>").value + "&region=SG&mode=bicycling&center=" + position.coords.latitude + "," + position.coords.longitude + "&zoom=18";
            }
            else {
                return false;
            } --%>    
        }
        window.getLocation = getLocation();
        //window.initMap = initMap;

    </script>
</head>
<body>

    <form id="form1" runat="server">
<%--        <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upMap" UpdateMode="Always">
            <ContentTemplate>
                <div id="container">
                    <div id="map"></div>
                    <div id="sidebar">
                        <p>Total Distance: <span id="total"></span></p>
                        <div id="panel"></div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>--%>
                <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upMap" UpdateMode="Always">
            <ContentTemplate>
        <%--                        <div id="map" style="float: left; width: 70%; height: 100%"></div>
                <div id="directionsPanel" style="float: right; width: 30%; height: 100%"></div>--%>
        <asp:HiddenField ID="hfCustomerAddress" runat="server" />
        <asp:HiddenField ID="hfLoc" runat="server" />
        <asp:HiddenField ID="hfLat" runat="server" />
        <asp:HiddenField ID="hfLong" runat="server" />
                        <iframe id="iframeMaps"
                    style="width: 100%; height: 450px;"
                    frameborder="0"></iframe>
                    </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
<%--<script type="text/javascript"> 
    setTimeout(function () {
        window.location.reload();
    }, 5000);
</script>--%>
<%--    <script>
        setTimeout(function () {
            map.setZoom(23);
            console.log('zoomed');
        }, 1);
    </script>--%>
</html>
