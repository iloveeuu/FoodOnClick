Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports GoogleMaps.LocationServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class riderDelivery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Web.HttpContext.Current.Session("orderbatchid") = Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid"))
        If Not Page.IsPostBack Then
            'Dim Script As String = "window.onload = function() { getLocation(); };"
            'ClientScript.RegisterStartupScript(Me.GetType(), "UpdateTime", Script, True)
            Dim clsOrder As Order = New Order(Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid")))
            clsOrder = clsOrder.RetrieveOrderDetailsByBatchId()
            If (clsOrder.branchId = 1) Then
                lblOrderNum.Text = clsOrder.orderNum
                lblRestaurantName.Text = clsOrder.name
                lblRestaurantAddress.Text = clsOrder.timePicked
                lblOrderTime.Text = clsOrder.orderTime
                tblDelivering.Visible = False
                tblPickUp.Visible = True
                iframee.Src = "directionToRestaurant.aspx"
            ElseIf (clsOrder.branchId = 2) Then
                clsOrder = New Order(Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid")))
                clsOrder = clsOrder.RetrieveCustomerOrderDetailsByBatchId()
                lblOrderNum1.Text = clsOrder.orderNum
                lblCustomerName.Text = clsOrder.name
                lblCustomerAddress.Text = clsOrder.timePicked
                lblPhoneNumber.Text = clsOrder.timeDelivered
                lblPaymentMethod.Text = clsOrder.paymentMethod
                'lblDeliveryCharges.Text = clsOrder.deliverycharges
                lblTotalCharges.Text = "$" & clsOrder.totalcharges
                tblDelivering.Visible = True
                tblPickUp.Visible = False
                iframee.Src = "directionToCustomer.aspx"
            End If

        End If

    End Sub

    Protected Sub btnDirectionToRestaurant_Click(sender As Object, e As EventArgs)
        'hlMap.Text = "Click to Show Map"
        'hlMap.NavigateUrl = "https://www.google.com/maps/dir/?api=1&origin=1.3492299,103.7485746&destination=Blk%2011,%20%2301-11,%20Ang%20Mo%20Kio%20Central"
    End Sub

    Protected Sub btnPickUp_Click(sender As Object, e As EventArgs)
        Dim clsOrder As Order = New Order(Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid")))
        clsOrder.InsertPickUpTiming()
        tblDelivering.Visible = True
        tblPickUp.Visible = False
        iframee.Src = "directionToCustomer.aspx"
        clsOrder = clsOrder.RetrieveCustomerOrderDetailsByBatchId()
        lblOrderNum1.Text = clsOrder.orderNum
        lblCustomerAddress.Text = clsOrder.timePicked
        lblCustomerName.Text = clsOrder.name
        lblPhoneNumber.Text = clsOrder.timeDelivered
        lblPaymentMethod.Text = clsOrder.paymentMethod
        'lblDeliveryCharges.Text = clsOrder.deliverycharges
        lblTotalCharges.Text = "$" & clsOrder.totalcharges
        'lblDeliveryCharges.Visible = False
        'lblTotalCharges.Visible = True
    End Sub

    Protected Sub btnDelivery_Click(sender As Object, e As EventArgs)
        Dim clsOrder As Order = New Order(Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid")))
        clsOrder.UpdateTimeDeliverednStatus()
        clsOrder = New Order(Convert.ToInt32(System.Web.HttpContext.Current.Session("userid")))
        clsOrder.SetRiderToAvailable()

        'Dim totalCost As Decimal = clsOrder.RetrieveOrderDetailsByBatchId.totalcharges()
        'clsOrder.UpdateEarningsForRestaurant

        Response.Redirect("riderHome.aspx")
    End Sub
End Class