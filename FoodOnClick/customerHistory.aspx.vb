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
        Dim btnFeedback As Button = Nothing
        Dim hfBatchId As HiddenField = Nothing

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If (e.Row.Cells(6).Text = "Pending") Then
                btnCancel = e.Row.FindControl("btnCancel")
                btnCancel.Visible = True
                btnCancel.Attributes("onclick") = "return confirm('Do you want to cancel this reservation?');"

            ElseIf (e.Row.Cells(6).Text = "Completed") Then
                btnFeedback = e.Row.FindControl("btnFeedback")
                btnFeedback.Visible = True
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
        Dim hfBranchId As HiddenField = Nothing
        Dim hfReservationId As HiddenField = Nothing
        Dim hfEmail As HiddenField = Nothing
        Dim sEmail As String = ""
        Dim iBatchId As Integer = 0
        Dim iBranchId As Integer = 0
        Dim iReservationId As Integer = 0
        Dim message As String
        Index = Convert.ToInt32(e.CommandArgument)

        hfBranchId = gvReservation.Rows(Index).FindControl("hfBranchId")
        iBranchId = hfBranchId.Value

        hfBatchId = gvReservation.Rows(Index).FindControl("hfBatchId")
        iBatchId = hfBatchId.Value

        hfReservationId = gvReservation.Rows(Index).FindControl("hfReservationId")
        iReservationId = hfReservationId.Value


        If e.CommandName = "doCheckPreOrder" Then
            Session("batchId") = iBatchId
            Session("restName") = gvReservation.Rows(Index).Cells(0).Text
            Session("address") = gvReservation.Rows(Index).Cells(1).Text
            Session("pax") = gvReservation.Rows(Index).Cells(2).Text
            Session("date") = gvReservation.Rows(Index).Cells(3).Text
            Session("time") = gvReservation.Rows(Index).Cells(4).Text
            Session("duration") = gvReservation.Rows(Index).Cells(5).Text
            Session("status") = gvReservation.Rows(Index).Cells(6).Text

            Response.Redirect("customerPreOrderDetail.aspx")
        ElseIf e.CommandName = "doCancel" Then

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
        ElseIf e.CommandName = "doFeedback" Then
            If chkFollowUp.Checked = True Then
                divShowHide.Style.Add("display", "block")
            End If
            lblRest1.Text = gvReservation.Rows(Index).Cells(0).Text
            hfPopUpBatchId.Value = iBatchId
            hfPopUpBranchId.Value = iBranchId
            hfPopUpReservationId.Value = iReservationId
            my_popup.Style.Add("display", "block")
            popup.Style.Add("display", "block")
        End If
    End Sub

    Protected Sub DataBind()
        Dim dtReservation As DataTable
        Dim clsReservation As Reservation = New Reservation(Session("userid"))
        clsReservation.fromdate = txtFromDate.Text.Trim()
        clsReservation.todate = txtToDate.Text.Trim()
        dtReservation = clsReservation.GetReservationHistory()
        gvReservation.DataSource = dtReservation
        gvReservation.DataBind()

        Dim dtDelivery As DataTable
        Dim clsDelivery As OrderDetail = New OrderDetail()
        clsDelivery.fromdate = txtFromDate.Text.Trim()
        clsDelivery.todate = txtToDate.Text.Trim()
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
        Dim hfBranchId As HiddenField = Nothing
        Dim hfEmail As HiddenField = Nothing
        Dim hfRiderId As HiddenField = Nothing
        Dim sEmail As String = ""
        Dim iBatchId As Integer = 0
        Dim iBranchId As Integer = 0
        Dim iRiderId As Integer = 0
        Dim btnFeedback As Button = Nothing
        Dim message As String = ""
        Index = Convert.ToInt32(e.CommandArgument)

        hfBatchId = gvDelivery.Rows(Index).FindControl("hfBatchId")
        iBatchId = hfBatchId.Value

        hfBranchId = gvDelivery.Rows(Index).FindControl("hfBranchId")
        iBranchId = hfBranchId.Value

        hfEmail = gvDelivery.Rows(Index).FindControl("hfEmail")
        sEmail = hfEmail.Value

        hfRiderId = gvDelivery.Rows(Index).FindControl("hfRiderId")
        iRiderId = hfRiderId.Value

        If e.CommandName = "doCheckOrder" Then

            Session("restName") = gvDelivery.Rows(Index).Cells(0).Text
            Session("orderID") = gvDelivery.Rows(Index).Cells(2).Text
            Session("batchId") = iBatchId

            Response.Redirect("customerOrderDetail.aspx")
        ElseIf e.CommandName = "doCancel" Then

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

                hfEmail = gvDelivery.Rows(Index).FindControl("hfEmail")
                sEmail = hfEmail.Value

                Dim smtp As SMTP = New SMTP()
                Dim email() As String = {sEmail}
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
        ElseIf e.CommandName = "doFeedback" Then
            If chkFollowUp2.Checked = True Then
                divShowHide2.Style.Add("display", "block")
            End If
            lblRest2.Text = gvDelivery.Rows(Index).Cells(0).Text
            hfPopUpBatchIdDel.Value = iBatchId
            hfPopUpBranchIdDel.Value = iBranchId
            hfPopUpOrderIdDel.Value = gvDelivery.Rows(Index).Cells(2).Text
            hfPopUpRiderIdDel.Value = iRiderId
            my_popup2.Style.Add("display", "block")
            popup2.Style.Add("display", "block")
        End If
    End Sub

    Protected Sub gvDelivery_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Dim btnCancel As Button = Nothing
        Dim btnOrder As Button = Nothing
        Dim btnFeedback As Button = Nothing
        Dim hfBatchId As HiddenField = Nothing

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If (e.Row.Cells(4).Text = "<div style=""text-transform:capitalize"">pending</div>") Then
                btnCancel = e.Row.FindControl("btnCancel")
                btnCancel.Visible = True
                btnCancel.Attributes("onclick") = "return confirm('Do you want to cancel this delivery order?');"

            ElseIf (e.Row.Cells(4).Text = "<div style=""text-transform:capitalize"">delivered</div>") Then
                btnFeedback = e.Row.FindControl("btnFeedback")
                btnFeedback.Visible = True
            End If
        End If
    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        my_popup.Style.Add("display", "none")
        popup.Style.Add("display", "none")

        my_popup2.Style.Add("display", "none")
        popup2.Style.Add("display", "none")
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim rating As String
        rating = hfRating.Value

        If chkFollowUp.Checked = True And txtPhone.Text.Trim() = "" Then
            errorText.Attributes("style") = "display: block; text-align: center; color:red;"
            divShowHide.Style.Add("display", "block")
            Exit Sub
        End If

        If rating = "" OrElse txtFeedback.Text.Trim() = "" Then
            errorText.Attributes("style") = "display: block; text-align: center; color:red;"
            If chkFollowUp.Checked Then
                divShowHide.Style.Add("display", "block")
            Else
                divShowHide.Style.Add("display", "none")
            End If
        Else
            errorText.Attributes("style") = "display: none; text-align: center; color:red;"

            Dim strFeedback As String = txtFeedback.Text.Trim().Replace(Environment.NewLine, "CHAR(13)")

            If chkFollowUp.Checked = True Then
                strFeedback += "CHAR(13)Follow Up: " + txtPhone.Text.Trim()
            End If

            Dim rev As Review = New Review()
            rev.Description = strFeedback
            rev.Userid = Session("userid")
            rev.Batchid = hfPopUpBatchId.Value
            rev.BranchID = hfPopUpBranchId.Value
            rev.ReservationId = hfPopUpReservationId.Value
            rev.RatingRest = rating
            rev.InsertReviewReservation()

            my_popup.Style.Add("display", "none")
            popup.Style.Add("display", "none")

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Review Submitted")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            DataBind()
        End If
    End Sub

    Protected Sub btnSubmitDel_Click(sender As Object, e As EventArgs)
        Dim ratingRest As String
        ratingRest = hfRatingRest.Value

        Dim ratingRider As String
        ratingRider = hfRatingRider.Value

        If chkFollowUp2.Checked = True And txtPhone2.Text.Trim() = "" Then
            errorText2.Attributes("style") = "display: block; text-align: center; color:red;"
            divShowHide2.Style.Add("display", "block")
            Exit Sub
        End If

        If ratingRest = "" OrElse ratingRider = "" OrElse txtFeedbackRest.Text.Trim() = "" OrElse txtFeedbackRider.Text.Trim() = "" Then
            errorText2.Attributes("style") = "display: block; text-align: center; color:red;"
            If chkFollowUp2.Checked Then
                divShowHide2.Style.Add("display", "block")
            Else
                divShowHide2.Style.Add("display", "none")
            End If
        Else
            errorText2.Attributes("style") = "display: none; text-align: center; color:red;"

            Dim strFeedbackRest As String = txtFeedbackRest.Text.Trim().Replace(Environment.NewLine, "CHAR(13)")

            If chkFollowUp2.Checked = True Then
                strFeedbackRest += "CHAR(13)Follow Up: " + txtPhone2.Text.Trim()
            End If

            Dim strFeedbackRider As String = txtFeedbackRider.Text.Trim().Replace(Environment.NewLine, "CHAR(13)")

            Dim rev As Review = New Review()
            rev.Description = strFeedbackRest
            rev.DescriptionDel = strFeedbackRider
            rev.Userid = Session("userid")
            rev.Batchid = hfPopUpBatchIdDel.Value
            rev.BranchID = hfPopUpBranchIdDel.Value
            rev.RiderID = hfPopUpRiderIdDel.Value
            rev.RatingRest = ratingRest
            rev.RatingDel = ratingRider
            rev.InsertReviewDelivery()

            my_popup2.Style.Add("display", "none")
            popup2.Style.Add("display", "none")

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Review Submitted")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            DataBind()
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        DataBind()
    End Sub
End Class