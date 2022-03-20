Public Class branchReservation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Or Session("branchid") Is Nothing Then
                Response.Redirect("login.aspx")
            End If
            binddataToday()
            lblTitle.Text = "Today"
        End If

    End Sub
    Protected Sub binddataToday()

        Dim dtReservation As DataTable
        Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(Session("branchid")), Date.Today)
        dtReservation = clsReservation.GetReservationToday()
        gvReservationToday.DataSource = dtReservation
        gvReservationToday.DataBind()
        If dtReservation.Rows.Count() = 0 Then
            lblNothing.Visible = True
            lblNothing.Text = "No reservations today"
        Else
            lblNothing.Visible = False
        End If
    End Sub
    Protected Sub binddataHistory()

        Dim dtReservation As DataTable
        Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(Session("branchid")), Date.Today)
        dtReservation = clsReservation.GetBranchReservationHistory()
        gvReservationHistory.DataSource = dtReservation
        gvReservationHistory.DataBind()
        If dtReservation.Rows.Count() = 0 Then
            lblNothing.Visible = True
            lblNothing.Text = "No history reservations"
        Else
            lblNothing.Visible = False
        End If
    End Sub
    Protected Sub binddataUpcoming()

        Dim dtReservation As DataTable
        Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(Session("branchid")), Date.Today)
        dtReservation = clsReservation.GetReservationUpcoming()
        gvReservationUpcoming.DataSource = dtReservation
        gvReservationUpcoming.DataBind()
        If dtReservation.Rows.Count() = 0 Then
            lblNothing.Visible = True
            lblNothing.Text = "No upcoming reservations"
        Else
            lblNothing.Visible = False
        End If
    End Sub

    Protected Sub gvReservation_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim message As String = ""
        If (e.CommandName = "Approve") Then
            Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument), "Approved")
            Dim userInfo As Reservation = clsReservation.RetrieveReservationEmail()
            If (Not userInfo.status = "Pending") Then
                message = "Unable to approve reservation. Refreshing page"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                If (clsReservation.UpdateReservation() = "True") Then
                    If userInfo.preordermeals = "Yes" Then
                        sendEmail(userInfo, "APPROVED", 2)
                    Else
                        sendEmail(userInfo, "APPROVED", 1)
                    End If
                End If
            End If
        ElseIf (e.CommandName = "Reject") Then
            Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument), "Rejected")
            Dim userInfo As Reservation = clsReservation.RetrieveReservationEmail()
            If (Not userInfo.status = "Pending") Then
                message = "Unable to reject reservation. Refreshing page"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                If (clsReservation.UpdateReservation() = "True") Then
                    If userInfo.preordermeals = "Yes" Then
                        Dim batchid As Integer = clsReservation.RetrieveBatchOrderIdByReservationID()
                        clsReservation = New Reservation(batchid, "8")
                        clsReservation.UpdateReservationOrder()
                        sendEmail(userInfo, "REJECTED", 0)
                    Else
                        sendEmail(userInfo, "REJECTED", 0)
                    End If
                End If
            End If
        ElseIf (e.CommandName = "View") Then
            Dim menuInfo As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument))
            rptMenuOrdered.DataSource = menuInfo.RetrievePreOrderMenu()
            rptMenuOrdered.DataBind()
            my_popup.Style.Add("display", "block")
            popup.Style.Add("display", "block")
            btnApproveMenu.Enabled = True
            btnRejectMenu.Enabled = True
        End If
        binddataToday()
    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As EventArgs)
        lblTitle.Text = "History"
        gvReservationToday.Visible = False
        gvReservationUpcoming.Visible = False
        gvReservationHistory.Visible = True
        binddataHistory()
    End Sub

    Protected Sub btnUpcoming_Click(sender As Object, e As EventArgs)
        lblTitle.Text = "Upcoming"
        gvReservationUpcoming.Visible = True
        gvReservationHistory.Visible = False
        gvReservationToday.Visible = False
        binddataUpcoming()
    End Sub

    Protected Sub btnToday_Click(sender As Object, e As EventArgs)
        lblTitle.Text = "Today"
        gvReservationToday.Visible = True
        gvReservationUpcoming.Visible = False
        gvReservationHistory.Visible = False
        binddataToday()
    End Sub

    Protected Sub gvReservation_RowDataBound(sender As Object, e As GridViewRowEventArgs)

    End Sub

    Protected Sub sendEmail(info As Reservation, status As String, confirmation As Integer)

        Dim subject As String = "Reservation for " & info.firstName & " " & info.lastName & ", " & info.dtdate
        Dim body As String = ""
        Dim message As String = ""
        Select Case confirmation
            Case 2 'If preoder = "Yes"'
                body = "<html> " &
                    "<body>" &
                    "<p>Dear " & info.firstName & " " & info.lastName & ",</p>" &
                    "<p>At " & info.branchAddress & ",</p>" &
                    "<br/><br/>" &
                    "<p>Your reservation has been " & status & " for " & info.firstName & " " & info.lastName & " at " & info.dtdate & " time " & info.strtime & " for " & info.pax & " pax </p>" &
                    "<p>Please check on your pre order menu status and display your reservation when you arrive.</p>" &
                    "<br/><br/>" &
                    "<p>Regards,</p>" &
                    "<p>" & info.restaurantName & " - " & info.branchCity & "</p>" &
                    "</body>" &
                    "</html>"
            Case 1 'If preoder = "No"'
                body = "<html> " &
                    "<body>" &
                    "<p>Dear " & info.firstName & " " & info.lastName & ",</p>" &
                    "<p>At " & info.branchAddress & ",</p>" &
                    "<br/><br/>" &
                    "<p>Your reservation has been " & status & " for " & info.firstName & " " & info.lastName & " at " & info.dtdate & " time " & info.strtime & " for " & info.pax & " pax </p>" &
                    "<p>Please display your reservation when you arrive.</p>" &
                    "<br/><br/>" &
                    "<p>Regards,</p>" &
                    "<p>" & info.restaurantName & " - " & info.branchCity & "</p>" &
                    "</body>" &
                    "</html>"
            Case 0
                body = "<html> " &
                    "<body>" &
                    "<p>Dear " & info.firstName & " " & info.lastName & ",</p>" &
                    "<p>At " & info.branchAddress & ",</p>" &
                    "<br/><br/>" &
                    "<p>Your reservation has been " & status & " for " & info.firstName & " " & info.lastName & " at " & info.dtdate & " time " & info.strtime & " for " & info.pax & " pax </p>" &
                    "<p>We are sorry for the inconvenience.</p>" &
                    "<br/><br/>" &
                    "<p>Regards,</p>" &
                    "<p>" & info.restaurantName & " - " & info.branchCity & "</p>" &
                    "</body>" &
                    "</html>"
        End Select

        Dim smtp As SMTP = New SMTP()
        Dim email() As String = {info.email}
        smtp.SendMail(email, subject, body, Nothing, True)
        message = "Reservation have been " & status
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub

    Protected Sub gvReservationUpcoming_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim message As String = ""
        If (e.CommandName = "Approve") Then
            Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument), "Approved")
            Dim userInfo As Reservation = clsReservation.RetrieveReservationEmail()
            If (Not userInfo.status = "Pending") Then
                message = "Unable to approve reservation. Refreshing page"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                If (clsReservation.UpdateReservation() = "True") Then
                    If userInfo.preordermeals = "Yes" Then
                        sendEmail(userInfo, "APPROVED", 2)
                    Else
                        sendEmail(userInfo, "APPROVED", 1)
                    End If
                End If
            End If
        ElseIf (e.CommandName = "Reject") Then
            Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument), "Rejected")
            Dim userInfo As Reservation = clsReservation.RetrieveReservationEmail()
            If (Not userInfo.status = "Pending") Then
                message = "Unable to reject reservation. Refreshing page"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                If (clsReservation.UpdateReservation() = "True") Then
                    If userInfo.preordermeals = "Yes" Then
                        Dim batchid As Integer = clsReservation.RetrieveBatchOrderIdByReservationID()
                        clsReservation = New Reservation(batchid, "8")
                        clsReservation.UpdateReservationOrder()
                        sendEmail(userInfo, "REJECTED", 0)
                    Else
                        sendEmail(userInfo, "REJECTED", 0)
                    End If
                End If
            End If
        ElseIf (e.CommandName = "View") Then
            Dim menuInfo As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument))
            rptMenuOrdered.DataSource = menuInfo.RetrievePreOrderMenu()
            rptMenuOrdered.DataBind()
            my_popup.Style.Add("display", "block")
            popup.Style.Add("display", "block")
            btnApproveMenu.Enabled = True
            btnRejectMenu.Enabled = True
        End If
        binddataUpcoming()
    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        my_popup.Style.Add("display", "none")
        popup.Style.Add("display", "none")
    End Sub

    Protected Sub rptMenuOrdered_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim menuName As String = DataBinder.Eval(e.Item.DataItem, "restaurantName").ToString()
            Dim menuQuantity As String = DataBinder.Eval(e.Item.DataItem, "pax").ToString()
            Dim singleCost As Decimal = DataBinder.Eval(e.Item.DataItem, "tempCost")
            Dim totalCost As Decimal = DataBinder.Eval(e.Item.DataItem, "tempTotalCost")
            Dim orderStatus As Integer = DataBinder.Eval(e.Item.DataItem, "userid")
            Dim name As Literal = (TryCast(e.Item.FindControl("litName"), Literal))
            Dim quantity As Literal = (TryCast(e.Item.FindControl("litQuantity"), Literal))
            Dim cost As Literal = (TryCast(e.Item.FindControl("litCost"), Literal))
            name.Text = menuName
            quantity.Text = "x" & menuQuantity
            cost.Text = "$" & singleCost
            lblTotal.Text = "$" & totalCost
            If (orderStatus = 6) Then
                btnApproveMenu.Visible = True
                btnRejectMenu.Visible = True
            Else
                btnApproveMenu.Visible = False
                btnRejectMenu.Visible = False
            End If
            hfbatch.Value = DataBinder.Eval(e.Item.DataItem, "batchid")
        End If
    End Sub

    Protected Sub btnApproveMenu_Click(sender As Object, e As EventArgs)
        Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(hfbatch.Value), "7")
        clsReservation.UpdateReservationOrder()
        btnApproveMenu.Enabled = False
        btnRejectMenu.Enabled = False
        Dim message As String = ""
        message = "Approved menu"
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub

    Protected Sub btnRejectMenu_Click(sender As Object, e As EventArgs)
        Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(hfbatch.Value), "8")
        clsReservation.UpdateReservationOrder()
        btnApproveMenu.Enabled = False
        btnRejectMenu.Enabled = False
        Dim message As String = ""
        message = "Rejected menu"
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Response.Redirect("branchMenu")
    End Sub
End Class