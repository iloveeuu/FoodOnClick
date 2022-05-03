Public Class directionToRestaurant
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'System.Web.HttpContext.Current.Session("orderbatchid") = Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid"))
            'Dim clsOrder As Order = New Order(Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid")))
            'hfCustomerAddress.Value = clsOrder.RetrieveOrderDetailsByBatchId.timeDelivered
            'Dim Script As String = "window.onload = function() { getLocation(); };"
            'ClientScript.RegisterStartupScript(Me.GetType(), "UpdateTime", Script, True)
            'Dim Script As String = "window.onload = function() { initMap(); };"
            'ClientScript.RegisterStartupScript(Me.GetType(), "UpdateTime", Script, True)
            System.Web.HttpContext.Current.Session("orderbatchid") = Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid"))
            Dim clsOrder As Order = New Order(Convert.ToInt32(System.Web.HttpContext.Current.Session("orderbatchid")))
            hfCustomerAddress.Value = clsOrder.RetrieveOrderDetailsByBatchId.timePicked
        Else

            'Dim Script As String = "window.onload = function() { getLocation(); };"
            'ClientScript.RegisterStartupScript(Me.GetType(), "UpdateTime", Script, True)
        End If

        'Dim Script As String = "window.onload = function() { getLocation(); };"
        'ClientScript.RegisterStartupScript(Me.GetType(), "UpdateTime", Script, True)
    End Sub

End Class