Public Class branchOrder
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Or Session("branchid") Is Nothing Then
                Response.Redirect("login.aspx")
            End If
            binddataPending()
            lblTitle.Text = "Pending"
        End If
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Response.Redirect("branchMenu.aspx")
    End Sub

    Protected Sub btnPending_Click(sender As Object, e As EventArgs)
        binddataPending()
    End Sub

    Protected Sub btnCompleted_Click(sender As Object, e As EventArgs)
        binddataHistory()
    End Sub
    Protected Sub binddataHistory()
        lblTitle.Text = "History"
        Dim clsBatchOrder As BatchOrder = New BatchOrder(Convert.ToInt32(Session("branchid")))
        gvOrders.DataSource = clsBatchOrder.GetOrdersHistory()
        gvOrders.DataBind()
    End Sub

    Protected Sub binddataPending()
        lblTitle.Text = "Pending"
        Dim clsBatchOrder As BatchOrder = New BatchOrder(Convert.ToInt32(Session("branchid")))
        gvOrders.DataSource = clsBatchOrder.GetOrdersPending()
        gvOrders.DataBind()
    End Sub
    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        my_popup.Style.Add("display", "none")
        popup.Style.Add("display", "none")
    End Sub

    Protected Sub gvOrders_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If (e.CommandName = "View") Then
            Dim menuInfo As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument))
            rptOrders.DataSource = menuInfo.RetrieveOrderMenu()
            rptOrders.DataBind()
            my_popup.Style.Add("display", "block")
            popup.Style.Add("display", "block")
            btnAcceptOrder.Enabled = True
            btnRejectOrder.Enabled = True
        End If
    End Sub

    Protected Sub rptOrders_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim menuName As String = DataBinder.Eval(e.Item.DataItem, "restaurantName").ToString()
            Dim menuQuantity As String = DataBinder.Eval(e.Item.DataItem, "pax").ToString()
            Dim singleCost As Decimal = DataBinder.Eval(e.Item.DataItem, "tempCost")
            Dim totalCost As Decimal = DataBinder.Eval(e.Item.DataItem, "tempTotalCost")
            Dim deliveryCharges As Decimal = DataBinder.Eval(e.Item.DataItem, "tempDeliveryCharges")
            Dim paymentMode As String = DataBinder.Eval(e.Item.DataItem, "tempPaymentType")
            Dim orderStatus As Integer = DataBinder.Eval(e.Item.DataItem, "userid")
            Dim name As Literal = (TryCast(e.Item.FindControl("litName"), Literal))
            Dim quantity As Literal = (TryCast(e.Item.FindControl("litQuantity"), Literal))
            Dim cost As Literal = (TryCast(e.Item.FindControl("litCost"), Literal))
            name.Text = menuName
            quantity.Text = "x" & menuQuantity
            cost.Text = "$" & singleCost
            lblDeliveryCharges.Text = "$" & deliveryCharges
            lblPaymentMode.Text = paymentMode
            lblTotal.Text = "$" & (totalCost + deliveryCharges)
            If (orderStatus = 6) Then
                btnAcceptOrder.Visible = True
                btnRejectOrder.Visible = True
            Else
                btnAcceptOrder.Visible = False
                btnRejectOrder.Visible = False
            End If
            hfbatch.Value = DataBinder.Eval(e.Item.DataItem, "batchid")
        End If
    End Sub

    Protected Sub btnAcceptOrder_Click(sender As Object, e As EventArgs)
        Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(hfbatch.Value), "1")
        clsReservation.UpdateReservationOrder()
        Dim userInfo As Reservation = clsReservation.RetrieveOrderEmail()
        Dim clsReser As Reservation = New Reservation(Convert.ToInt32(hfbatch.Value))
        Dim menuInfo As List(Of Reservation) = clsReser.RetrieveOrderMenu()
        sendEmail(userInfo, menuInfo, "Accepted", 1)
        my_popup.Style.Add("display", "none")
        popup.Style.Add("display", "none")
        binddataPending()
    End Sub

    Protected Sub btnRejectOrder_Click(sender As Object, e As EventArgs)
        Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(hfbatch.Value), "8")
        clsReservation.UpdateReservationOrder()
        Dim userInfo As Reservation = clsReservation.RetrieveOrderEmail()
        Dim clsReser As Reservation = New Reservation(Convert.ToInt32(hfbatch.Value))
        Dim menuInfo As List(Of Reservation) = clsReser.RetrieveOrderMenu()
        sendEmail(userInfo, menuInfo, "Rejected", 0)
        my_popup.Style.Add("display", "none")
        popup.Style.Add("display", "none")
        binddataPending()
    End Sub
    Protected Sub sendEmail(info As Reservation, menu As List(Of Reservation), status As String, confirmation As Integer)

        Dim subject As String = "Order for " & info.firstName & " " & info.lastName & ", " & info.dtdate
        Dim body As String = ""
        Dim message As String = ""
        Dim menuBody As String = ""
        Dim paymentModee As String = ""
        Dim totalCost As Decimal = 0.00
        If Not menu.Count = 0 Then
            For i As Integer = 0 To menu.Count - 1
                Dim objMenu = menu(i)
                menuBody += "<p>" & objMenu.restaurantName & " x" & objMenu.pax & " $" & objMenu.tempCost & "</p>"
            Next
            menuBody += "<p>Payment method: " & menu(0).tempPaymentType & "</p>"
            menuBody += "<p>Delivery charge: " & menu(0).tempDeliveryCharges & "</p>"
            totalCost = menu(0).tempDeliveryCharges + menu(0).tempDeliveryCharges
            menuBody += "<p>Total cost: " & totalCost & "</p>"
        End If
        Select Case confirmation
            Case 1 'Accept Order'
                body = "<html> " &
                    "<body>" &
                    "<p>Dear " & info.firstName & " " & info.lastName & ",</p>" &
                    "<p>At " & info.branchAddress & ",</p>" &
                    "<br/><br/>" &
                    "<p>Your order has been " & status & ". Your order made at " & info.dtdate & " time " & info.strtime & " by " & info.status & "</p>" &
                    "<p><h2>Orders</h2></p>" &
                    menuBody &
                    "<br/><br/>" &
                    "<p>Regards,</p>" &
                    "<p>" & info.restaurantName & " - " & info.branchCity & "</p>" &
                    "</body>" &
                    "</html>"
            Case 0 'Reject Order
                body = "<html> " &
                    "<body>" &
                    "<p>Dear " & info.firstName & " " & info.lastName & ",</p>" &
                    "<p>At " & info.branchAddress & ",</p>" &
                    "<br/><br/>" &
                    "<p>Your order has been " & status & ". Your order made at " & info.dtdate & " time " & info.strtime & " by " & info.status & " pax </p>" &
                    "<p>Sorry for the inconvenience</p>" &
                    "<p><h2>Orders</h2></p>" &
                    menuBody &
                    "<br/><br/>" &
                    "<p>Regards,</p>" &
                    "<p>" & info.restaurantName & " - " & info.branchCity & "</p>" &
                    "</body>" &
                    "</html>"
        End Select

        Dim smtp As SMTP = New SMTP()
        Dim email() As String = {info.email}
        smtp.SendMail(email, subject, body, Nothing, True)
        message = "Order has been " & status
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub
End Class