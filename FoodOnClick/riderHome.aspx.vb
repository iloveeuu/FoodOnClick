Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports GoogleMaps.LocationServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class riderHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If (Request.QueryString("lat") Is Nothing AndAlso Request.QueryString("long") Is Nothing) Then
                'Javascript is not postback
                Dim script As String = "window.onload = function() { getLocation(); };"
                ClientScript.RegisterStartupScript(Me.GetType(), "UpdateTime", script, True)
            End If
        End If
        Dim clsOrder As Order = New Order(Convert.ToInt32(System.Web.HttpContext.Current.Session("userid")))
        Dim onJob As Boolean = clsOrder.CurrentlyOnJob()
        If onJob Then
            Response.Redirect("riderDelivery.aspx")
        End If
    End Sub

    'Protected Sub btnNotifySupport_Click(sender As Object, e As EventArgs)
    '    'Dim mail As New SMTP()
    '    'Dim ToAddressies As String() = {"fypfoodonclick@gmail.com", "fypfoodonclick@gmail.com"}
    '    'Dim attachs() As String = {}
    '    ''"d:\temp_Excell226.xlsx", "d:\temp_Excell224.xlsx", "d:\temp_Excell225.xlsx"
    '    'Dim subject As String = "Testing on local"
    '    'Dim body As String = "From local pc hello"
    '    'Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
    '    'If result Then
    '    '    MsgBox("mails sended successfully", MsgBoxStyle.Information)
    '    'Else
    '    '    MsgBox(mail.ErrorText, MsgBoxStyle.Critical)
    '    'End If
    'End Sub

    Protected Sub rptOrders_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

        Dim orderNum As Integer = DataBinder.Eval(e.Item.DataItem, "orderNum")
        Dim RestaurantName As String = DataBinder.Eval(e.Item.DataItem, "name").ToString()
        Dim RestaurantAddress As String = DataBinder.Eval(e.Item.DataItem, "timeDelivered").ToString()
        Dim MeToRestaurant As String = DataBinder.Eval(e.Item.DataItem, "orderTime").ToString()
        Dim useraddressDistance As String = DataBinder.Eval(e.Item.DataItem, "temp").ToString()
        Dim deliveryCharges As Decimal = DataBinder.Eval(e.Item.DataItem, "deliverycharges")
        Dim userAddress As String = DataBinder.Eval(e.Item.DataItem, "timePicked")
        Dim paymentMethod As String = DataBinder.Eval(e.Item.DataItem, "paymentMethod")
        Dim totalcharges As Decimal = DataBinder.Eval(e.Item.DataItem, "totalcharges")

        Dim userAddress1 As Label = (TryCast(e.Item.FindControl("lbluseraddress"), Label))
        Dim RestaurantName1 As Label = (TryCast(e.Item.FindControl("lblRestaurantName"), Label))
        Dim RestaurantAddress1 As Label = (TryCast(e.Item.FindControl("lblRestaurantAddress"), Label))
        Dim orderNum1 As Label = (TryCast(e.Item.FindControl("lblOrderId"), Label))
        Dim MeToRestaurant1 As Label = (TryCast(e.Item.FindControl("lbladdress"), Label))
        Dim userAddressDistance1 As Label = (TryCast(e.Item.FindControl("lblResToUser"), Label))
        Dim deliveryCharges1 As Label = (TryCast(e.Item.FindControl("lblDeliveryCharges"), Label))
        Dim paymentMethod1 As Label = (TryCast(e.Item.FindControl("lblPaymentMethod"), Label))
        Dim totalcharges1 As Label = (TryCast(e.Item.FindControl("lbltotalcharges"), Label))
        orderNum1.Text = "Order ID: " & orderNum

        RestaurantName1.Text = "Restaurant: " & RestaurantName & " <b>" & MeToRestaurant & "</b>"
        RestaurantAddress1.Text = "Address: " & RestaurantAddress
        'MeToRestaurant1.Text = "Distance to Restaurant: " & MeToRestaurant
        userAddress1.Text = "Customer: " & userAddress & " <b>" & useraddressDistance & "</b>"
        'userAddressDistance1.Text = "Restaurant to Customer: " & useraddressDistance
        deliveryCharges1.Text = "Delivery Charges: $" & deliveryCharges
        'paymentMethod1.Text = "Payment Mode: " & paymentMethod
        totalcharges1.Text = "Total: $" & totalcharges & " <b>" & paymentMethod & "</b>"
    End Sub

    Protected Sub btnStart_Click(sender As Object, e As EventArgs)
        If (Request.QueryString("lat") Is Nothing AndAlso Request.QueryString("long") Is Nothing) Then
            Dim message As String = "Please allow geolocation services to our website. Please refresh the page after turning it on"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Else
            bindPendingOrders()
        End If

    End Sub


    Protected Sub bindPendingOrders()
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim tempclsOrder As Order = New Order()
        Dim listOfAvailableBranch As List(Of Order) = New List(Of Order)
        Dim listOfOrders As List(Of Order) = tempclsOrder.CheckRiderPendingOrders()
        Dim latlong As String = Page.Request.QueryString("lat") + "," + Page.Request.QueryString("long")
        'btnRefresh.Visible = True
        divRpt.Style.Add("border", "1px solid black")
        Dim RiderAllowedDistance As Integer = 0
        If rbtn1.Checked Then
            RiderAllowedDistance = rbtn1.Text.Substring(1, 1)
        ElseIf rbtn2.Checked Then
            RiderAllowedDistance = rbtn2.Text.Substring(1, 1)
        ElseIf rbtn4.Checked Then
            RiderAllowedDistance = rbtn4.Text.Substring(1, 1)
        End If
        For Each item In listOfOrders
            'Distance between Rider and Restaurant
            Dim api As String = "https://maps.googleapis.com/maps/api/directions/json?destination=" + item.timeDelivered.Replace("#", "%23") + "&origin=" + latlong + "&region=SG&mode=bicycling&key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U"
            request = DirectCast(WebRequest.Create(api), HttpWebRequest)
            request.Timeout = 3000
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
            Dim rawresp As String
            rawresp = reader.ReadToEnd()
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rawresp)
            Dim distanceArr As String() = jsonResult("routes")(0)("legs")(0)("distance")("text").ToString().Split(" ")
            response.Dispose()
            'Only show jobs available within this distance
            If (Convert.ToDecimal(distanceArr(0)) <= RiderAllowedDistance) Then
                item.orderTime = distanceArr(0) & " " & distanceArr(1)
                api = "https://maps.googleapis.com/maps/api/directions/json?destination=" + item.timeDelivered.Replace("#", "%23") + "&origin=" + item.timePicked.Replace("#", "%23") + "&region=SG&mode=bicycling&key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U"
                request = DirectCast(WebRequest.Create(api), HttpWebRequest)
                request.Timeout = 3000
                response = DirectCast(request.GetResponse(), HttpWebResponse)
                reader = New StreamReader(response.GetResponseStream())
                rawresp = reader.ReadToEnd()
                jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rawresp)
                Dim distance As String = jsonResult("routes")(0)("legs")(0)("distance")("text").ToString()
                item.temp = distance
                listOfAvailableBranch.Add(item)
            End If
        Next
        If listOfAvailableBranch.Count = 0 Then
            lblDefaultMessage.Visible = True
        Else
            lblDefaultMessage.Visible = False
            rptOrders.DataSource = listOfAvailableBranch
        End If
        rptOrders.DataBind()
        'rptOrders.DataSource = clsOrder.CheckRiderPendingOrders()
        'rptOrders.DataBind()


        'Dim array As JObject = JObject.Parse(rawresp)
        'Dim jResults As JObject = JObject.Parse("JsonString")
        'Dim naming As [String] = jResults("sensors")("naming ")
        'Dim unit As [String] = jResults("sensors")("unit ")

    End Sub
    Public Shared Function DistanceTo(ByVal lat1 As Double, ByVal lon1 As Double, ByVal lat2 As Double, ByVal lon2 As Double, ByVal Optional unit As Char = "K"c) As Double
        Dim rlat1 As Double = Math.PI * lat1 / 180
        Dim rlat2 As Double = Math.PI * lat2 / 180
        Dim theta As Double = lon1 - lon2
        Dim rtheta As Double = Math.PI * theta / 180
        Dim dist As Double = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta)
        dist = Math.Acos(dist)
        dist = dist * 180 / Math.PI
        dist = dist * 60 * 1.1515

        Select Case unit
            Case "K"c
                Return dist * 1.609344
            Case "N"c
                Return dist * 0.8684
            Case "M"c
                Return dist
        End Select

        Return dist
    End Function

    Protected Sub rptOrders_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Accept") Then
            Dim clsDeliveryOrder As Order = New Order(Convert.ToInt32(e.CommandArgument().ToString()))
            Dim IsOrderAvailable As Boolean = clsDeliveryOrder.CheckIfOrderIsAvailable()
            If IsOrderAvailable Then
                'Job can be accepted
                clsDeliveryOrder = New Order(Convert.ToInt32(e.CommandArgument().ToString()), Convert.ToInt32(System.Web.HttpContext.Current.Session("userid")))
                IsOrderAvailable = clsDeliveryOrder.AcceptOrderJob()
                If IsOrderAvailable Then
                    System.Web.HttpContext.Current.Session("orderbatchid") = e.CommandArgument().ToString()
                    Response.Redirect("riderDelivery.aspx?lat=" & Request.QueryString("lat").ToString() & "&long=" & Request.QueryString("long").ToString())
                Else
                    'Some issue with the backend
                    Dim message As String = "Please try again."
                    Dim sb As New System.Text.StringBuilder()
                    sb.Append("<script type = 'text/javascript'>")
                    sb.Append("window.onload=function(){")
                    sb.Append("alert('")
                    sb.Append(message)
                    sb.Append("')};")
                    sb.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                    bindPendingOrders()
                End If
            Else
                Dim message As String = "Job has been taken by other rider."
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                bindPendingOrders()
            End If
        End If
    End Sub

    Protected Sub report_click(sender As Object, e As EventArgs)
        Response.Redirect("riderReport.aspx")

    End Sub

    Protected Sub btnReview_Click(sender As Object, e As EventArgs)
        Response.Redirect("riderReviews.aspx")
    End Sub
End Class