Public Class customerHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                DataBind()
            End If
        End If
    End Sub


    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub gvReservation_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Dim btnCancel As Button = Nothing
        Dim btnPreOrder As Button = Nothing
        Dim hfBatchId As HiddenField = Nothing

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If (e.Row.Cells(5).Text = "Pending") Then
                btnCancel = e.Row.FindControl("btnCancel")
                btnCancel.Visible = True
                btnCancel.Attributes("onclick") = "return confirm('Do you want to cancel this reservation?');"
            End If
            hfBatchId = e.Row.FindControl("hfBatchId")
            If (hfBatchId.Value <> "0") Then
                btnPreOrder = e.Row.FindControl("btnPreOrder")
                btnPreOrder.Visible = True
            End If
        End If
    End Sub

    Protected Sub gvReservation_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim Index As Int32 = -1
        Dim hfBatchId As HiddenField = Nothing
        Dim hfReservationId As HiddenField = Nothing
        Dim hfEmail As HiddenField = Nothing
        Dim sEmail As String = ""
        Dim iBatchId As Integer = 0
        Dim iReservationId As Integer = 0
        Dim message As String
        Index = Convert.ToInt32(e.CommandArgument)

        hfBatchId = gvReservation.Rows(Index).FindControl("hfBatchId")
        iBatchId = hfBatchId.Value

        If e.CommandName = "doCheckPreOrder" Then


            Session("batchId") = iBatchId
            Session("restName") = gvReservation.Rows(Index).Cells(0).Text
            Session("address") = gvReservation.Rows(Index).Cells(1).Text
            Session("pax") = gvReservation.Rows(Index).Cells(2).Text
            Session("date") = gvReservation.Rows(Index).Cells(3).Text
            Session("time") = gvReservation.Rows(Index).Cells(4).Text
            Session("status") = gvReservation.Rows(Index).Cells(5).Text

            Response.Redirect("customerPreOrderDetail.aspx")
        ElseIf e.CommandName = "doCancel" Then
            hfReservationId = gvReservation.Rows(Index).FindControl("hfReservationId")
            iReservationId = hfReservationId.Value

            Dim res As Reservation = New Reservation()
            res.reservationId = iReservationId
            res.userid = Session("userid")

            Dim ord As Order = New Order()
            ord.batchId = iBatchId

            Dim returnObject As Reservation = res.CheckReservationPending()

            If returnObject.status = "" Then
                message = "The reservation is already processed by the restaurant. You are not allowed to cancel it."
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                res.CancelReservation()
                ord.CancelOrder()

                Dim subject As String = "Reservation Cancelled from " & Session("firstname") & " " & Session("lastname") & ", " & gvReservation.Rows(Index).Cells(3).Text

                Dim body As String = "<html> " &
                                    "<body>" &
                                    "<p>Dear " & gvReservation.Rows(Index).Cells(0).Text & ",</p>" &
                                    "<p>At " & gvReservation.Rows(Index).Cells(1).Text & ",</p>" &
                                    "<br/>" &
                                    "<p>Reservation cancelled from " & Session("firstname") & " " & Session("lastname") & " at " & gvReservation.Rows(Index).Cells(3).Text & " time " & gvReservation.Rows(Index).Cells(4).Text & " for " & gvReservation.Rows(Index).Cells(2).Text & " pax.</p>" &
                                    "<br/>" &
                                    "<p>Regards,</p>" &
                                    "<p>Food on Click</p>" &
                                    "</body>" &
                                    "</html>"

                hfEmail = gvReservation.Rows(Index).FindControl("hfEmail")
                sEmail = hfEmail.Value

                Dim smtp As SMTP = New SMTP()
                Dim email() As String = {sEmail}
                smtp.SendMail(email, subject, body, Nothing, True)

                message = "Reservation cancelled"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            End If

            DataBind()
        End If
    End Sub

    Protected Sub DataBind()
        Dim dtReservation As DataTable
        Dim clsReservation As Reservation = New Reservation(Session("userid"))
        dtReservation = clsReservation.GetReservationHistory()
        gvReservation.DataSource = dtReservation
        gvReservation.DataBind()

        Dim dtDelivery As DataTable
        Dim clsDelivery As OrderDetail = New OrderDetail()
        clsDelivery.userId = Session("userid")
        dtDelivery = clsDelivery.GetDeliveryOrderHistory()
        gvDelivery.DataSource = dtDelivery
        gvDelivery.DataBind()
    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerCart.aspx")
    End Sub

    Protected Sub gvDelivery_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim Index As Int32 = -1
        Dim hfBatchId As HiddenField = Nothing
        Dim hfEmail As HiddenField = Nothing
        Dim sEmail As String = ""
        Dim iBatchId As Integer = 0
        Dim message As String
        Index = Convert.ToInt32(e.CommandArgument)

        hfBatchId = gvDelivery.Rows(Index).FindControl("hfBatchId")
        iBatchId = hfBatchId.Value

        If e.CommandName = "doCheckOrder" Then

            Session("restName") = gvDelivery.Rows(Index).Cells(0).Text
            Session("orderID") = gvDelivery.Rows(Index).Cells(2).Text
            Session("batchId") = iBatchId

            Response.Redirect("customerOrderDetail.aspx")
        ElseIf e.CommandName = "doCancel" Then
            hfEmail = gvReservation.Rows(Index).FindControl("hfEmail")
            sEmail = hfEmail.Value

            Dim ord As Order = New Order()
            ord.batchId = iBatchId
            ord.userId = Session("userid")

            Dim rtrnBool As Boolean = ord.CheckOrderPending()

            If rtrnBool = False Then
                message = "The delivery order is already processed by the restaurant. You are not allowed to cancel it."
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                ord.CancelOrder()

                Dim subject As String = "Delivery Order with ID: " & gvDelivery.Rows(Index).Cells(2).Text & " Cancelled"

                Dim body As String = "<html> " &
                                    "<body>" &
                                    "<p>Dear " & gvDelivery.Rows(Index).Cells(0).Text & ",</p>" &
                                    "<p>At " & gvDelivery.Rows(Index).Cells(1).Text & ",</p>" &
                                    "<br/>" &
                                    "<p>Delivery Order with ID: " & gvDelivery.Rows(Index).Cells(2).Text & " cancelled by customer</p>" &
                                    "<br/>" &
                                    "<p>Regards,</p>" &
                                    "<p>Food on Click</p>" &
                                    "</body>" &
                                    "</html>"

                hfEmail = gvReservation.Rows(Index).FindControl("hfEmail")
                sEmail = hfEmail.Value

                Dim smtp As SMTP = New SMTP()
                'Dim email() As String = {sEmail}
                Dim email() As String = {"will.ariez@gmail.com"}
                smtp.SendMail(email, subject, body, Nothing, True)

                message = "Delivery Order cancelled"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            End If

            DataBind()
        End If
    End Sub

    Protected Sub gvDelivery_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Dim btnCancel As Button = Nothing
        Dim btnOrder As Button = Nothing
        Dim hfBatchId As HiddenField = Nothing

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If (e.Row.Cells(3).Text = "pending") Then
                btnCancel = e.Row.FindControl("btnCancel")
                btnCancel.Visible = True
                btnCancel.Attributes("onclick") = "return confirm('Do you want to cancel this delivery order?');"
            End If
        End If
    End Sub
End Class