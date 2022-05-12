Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports GoogleMaps.LocationServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class customerSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                Dim clsBranch As Branch = New Branch()
                ddlCategory.DataSource = clsBranch.RetrieveAllCuisineType()
                ddlCategory.DataBind()

                Dim clsMenu As Menu = New Menu()
                ddlType.DataSource = clsMenu.RetrieveAllMenuFoodType()
                ddlType.DataBind()

                ddlCategory.Items.Insert(0, New ListItem("Please select", ""))
                ddlCategory.SelectedIndex = 0

                ddlHalal.Items.Insert(0, New ListItem("Please select", ""))
                ddlHalal.SelectedIndex = 0

                ddlType.Items.Insert(0, New ListItem("Please select", ""))
                ddlType.SelectedIndex = 0
            End If
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If Session("orderType") = "reservation" Then

            bindReservationOrder()

        ElseIf Session("orderType") = "delivery" Then
            bindDeliveryOrder()
        End If

    End Sub

    Protected Sub bindReservationOrder()
        Dim dtSearch As DataTable

        Dim dblMinPrice As Double
        Dim dblMaxPrice As Double

        If txtMinPrice.Text.Trim() = "" Then
            dblMinPrice = 0
        Else
            dblMinPrice = txtMinPrice.Text.Trim()
        End If

        If txtMaxPrice.Text.Trim() = "" Then
            dblMaxPrice = 0
        Else
            dblMaxPrice = txtMaxPrice.Text.Trim()
        End If

        Dim clsMenu As Menu = New Menu()
        dtSearch = clsMenu.GetSearchReservation(txtLocation.Text.Trim(), txtRestaurant.Text.Trim(), ddlCategory.SelectedItem.ToString(), ddlType.SelectedItem.ToString(),
                                       txtDishName.Text.Trim(), ddlHalal.SelectedItem.ToString(), dblMinPrice, dblMaxPrice)

        rptSearch.DataSource = dtSearch
        rptSearch.DataBind()
    End Sub

    Protected Sub bindDeliveryOrder()
        Dim dtSearch As DataTable
        Dim dblMinPrice As Double
        Dim dblMaxPrice As Double
        Dim sAddress As String

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        If txtMinPrice.Text.Trim() = "" Then
            dblMinPrice = 0
        Else
            dblMinPrice = txtMinPrice.Text.Trim()
        End If

        If txtMaxPrice.Text.Trim() = "" Then
            dblMaxPrice = 0
        Else
            dblMaxPrice = txtMaxPrice.Text.Trim()
        End If

        Dim dtFiltered As DataTable = New DataTable()
        dtFiltered.Columns.Add("restaurantID", GetType(Integer))
        dtFiltered.Columns.Add("firstname", GetType(String))
        dtFiltered.Columns.Add("email", GetType(String))
        dtFiltered.Columns.Add("branchid", GetType(Integer))
        dtFiltered.Columns.Add("restName", GetType(String))
        dtFiltered.Columns.Add("address", GetType(String))
        dtFiltered.Columns.Add("halal", GetType(String))
        dtFiltered.Columns.Add("time_open", GetType(String))
        dtFiltered.Columns.Add("time_closed", GetType(String))
        dtFiltered.Columns.Add("logo", GetType(String))

        Dim clsMenu As Menu = New Menu()
        dtSearch = clsMenu.GetSearchDelivery(txtLocation.Text.Trim(), txtRestaurant.Text.Trim(), ddlCategory.SelectedItem.ToString(), ddlType.SelectedItem.ToString(),
                                           txtDishName.Text.Trim(), ddlHalal.SelectedItem.ToString(), dblMinPrice, dblMaxPrice)

        Dim clsUserInfo As Customer = New Customer()
        Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(Session("userid")))

        For Each row As DataRow In dtSearch.Rows
            sAddress = row.Item("address")

            Dim api As String = "https://maps.googleapis.com/maps/api/directions/json?destination=" + sAddress.Replace("#", "%23") + "&origin=" + user.address.Replace("#", "%23") + "&region=SG&mode=bicycling&key=AIzaSyCb_ivGtmAoh8YrYAPOobiiVfU0hvabH-U"
            request = DirectCast(WebRequest.Create(api), HttpWebRequest)
            request.Timeout = 3000
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
            Dim rawresp As String
            rawresp = reader.ReadToEnd()
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rawresp)
            Dim distanceArr As String() = jsonResult("routes")(0)("legs")(0)("distance")("text").ToString().Split(" ")
            response.Dispose()
            If (Convert.ToDecimal(distanceArr(0)) <= 4) Then
                dtFiltered.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9))
            End If
        Next row
        If dtFiltered.Rows.Count = 0 Then
            lblDefaultMessage.Visible = True
            dtFiltered = New DataTable()
            rptSearch.DataSource = dtFiltered
            rptSearch.DataBind()
        Else
            lblDefaultMessage.Visible = False
            rptSearch.DataSource = dtFiltered
            rptSearch.DataBind()
            dtFiltered = New DataTable()
        End If

    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub gvSearch_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Dim hBranchId As HiddenField = Nothing
        Dim hPrevBranchId As HiddenField = Nothing
        Dim sBranchID As String = ""
        Dim sPreviousBranchID As String = ""

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'hide button
            If Session("orderType") = "reservation" Then
                Dim btnReserve As Button = e.Row.FindControl("btnReserve")
                btnReserve.Visible = True
                Dim btnDelivery As Button = e.Row.FindControl("btnDelivery")
                btnDelivery.Visible = False
            ElseIf Session("orderType") = "delivery" Then
                Dim btnReserve As Button = e.Row.FindControl("btnReserve")
                btnReserve.Visible = False
                Dim btnDelivery As Button = e.Row.FindControl("btnDelivery")
                btnDelivery.Visible = True
            End If

        End If

    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerCart.aspx")
    End Sub

    Protected Sub rptSearch_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim hRestaurantId As HiddenField = Nothing
        Dim hBranchId As HiddenField = Nothing
        Dim hUserId As HiddenField = Nothing
        Dim hEmail As HiddenField = Nothing
        Dim hTimeOpen As HiddenField = Nothing
        Dim hTImeClosed As HiddenField = Nothing
        Dim hAddress As HiddenField = Nothing
        Dim lblRestName As Label = Nothing
        Dim lblHalal As Label = Nothing

        Dim sRestaurantId As String = ""
        Dim sUserId As String = ""
        Dim sBranchId As String = ""
        Dim sEmail As String = ""
        Dim sRestName As String = ""
        Dim sHalal As String = ""
        Dim sAddress As String = ""
        Dim sDishName As String = ""
        Dim sTimeOpen As String = ""
        Dim sTimeClosed As String = ""

        If (e.CommandName = "viewMenu") And (Session("orderType") = "reservation") Then

            hEmail = e.Item.FindControl("hfEmail")
            sEmail = hEmail.Value

            hBranchId = e.Item.FindControl("hfBranchId")
            sBranchId = hBranchId.Value

            lblRestName = e.Item.FindControl("lblRestName")
            sRestName = lblRestName.Text

            lblHalal = e.Item.FindControl("lblHalal")
            sHalal = lblHalal.Text

            If sHalal = "Halal: Yes" Then
                sHalal = "Yes"
            ElseIf sHalal = "Halal: No" Then
                sHalal = "No"
            End If

            hAddress = e.Item.FindControl("hfAddress")
            sAddress = hAddress.Value

            hTimeOpen = e.Item.FindControl("hfTimeOpen")
            sTimeOpen = hTimeOpen.Value

            hTImeClosed = e.Item.FindControl("hfTimeClosed")
            sTimeClosed = hTImeClosed.Value

            Session("userid") = Session("userid")
            Session("email") = sEmail
            Session("branchid") = sBranchId
            Session("restName") = sRestName
            Session("halal") = sHalal
            Session("address") = sAddress
            Session("timeOpen") = sTimeOpen
            Session("timeClosed") = sTimeClosed

            Response.Redirect("customerRestaurantMenu.aspx")

        ElseIf (e.CommandName = "viewMenu") And (Session("orderType") = "delivery") Then

            hEmail = e.Item.FindControl("hfEmail")
            sEmail = hEmail.Value

            hBranchId = e.Item.FindControl("hfBranchId")
            sBranchId = hBranchId.Value

            lblRestName = e.Item.FindControl("lblRestName")
            sRestName = lblRestName.Text

            lblHalal = e.Item.FindControl("lblHalal")
            sHalal = lblHalal.Text

            If sHalal = "Halal: Yes" Then
                sHalal = "Yes"
            ElseIf sHalal = "Halal: No" Then
                sHalal = "No"
            End If

            hAddress = e.Item.FindControl("hfAddress")
            sAddress = hAddress.Value

            hTimeOpen = e.Item.FindControl("hfTimeOpen")
            sTimeOpen = hTimeOpen.Value

            hTImeClosed = e.Item.FindControl("hfTimeClosed")
            sTimeClosed = hTImeClosed.Value

            Session("userid") = Session("userid")
            Session("email") = sEmail
            Session("branchid") = sBranchId
            Session("restName") = sRestName
            Session("halal") = sHalal
            Session("address") = sAddress
            Session("timeOpen") = sTimeOpen
            Session("timeClosed") = sTimeClosed

            Response.Redirect("customerOrder.aspx")
        End If
    End Sub

End Class