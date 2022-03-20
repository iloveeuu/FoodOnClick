﻿Public Class branchReservation
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
        If (e.CommandName = "Approve") Then
            Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument), "Approved")
            Dim userInfo As Reservation = clsReservation.RetrieveReservationEmail()
            If (Not userInfo.status = "Pending") Then
                MsgBox("Unable to confirm reservation. Refreshing page")
            Else
                If (userInfo.preordermeals = "Yes") Then 'If there is preordermeal, popup Yes n No
                    Dim result As MsgBoxResult = MsgBox("Approve preorder menu?", MsgBoxStyle.YesNoCancel)
                    If result = result.Yes Then 'Approve reservation and preorder
                        If (clsReservation.UpdateReservation() = "True") Then
                            Dim batchid As Integer = clsReservation.RetrieveBatchOrderIdByReservationID()
                            clsReservation = New Reservation(batchid, "7")
                            If (clsReservation.UpdateReservationOrder() = "True") Then
                                sendEmail(userInfo, "APPROVED and preorder menu APPROVED")
                            End If
                        End If
                    ElseIf result = result.No Then 'Reject preorder Approve reservation
                        If (clsReservation.UpdateReservation() = "True") Then
                            Dim batchid As Integer = clsReservation.RetrieveBatchOrderIdByReservationID()
                            clsReservation = New Reservation(batchid, "8")
                            If (clsReservation.UpdateReservationOrder() = "True") Then
                                sendEmail(userInfo, "APPROVED but preorder menu REJECTED")
                            End If
                        End If
                    End If
                Else 'No preorder, so just update reservation 
                    If (clsReservation.UpdateReservation() = "True") Then
                        sendEmail(userInfo, "APPROVED")
                    End If
                End If
            End If
        ElseIf (e.CommandName = "Reject") Then
            Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument), "Rejected")
            Dim userInfo As Reservation = clsReservation.RetrieveReservationEmail()
            If (Not userInfo.status = "Pending") Then
                MsgBox("Unable to cancel reservation. Refreshing page")
            Else
                If (userInfo.preordermeals = "Yes") Then 'If there is preordermeal, popup Yes n No
                    If (clsReservation.UpdateReservation() = "True") Then
                        Dim batchid As Integer = clsReservation.RetrieveBatchOrderIdByReservationID()
                        clsReservation = New Reservation(batchid, "8")
                        If (clsReservation.UpdateReservationOrder() = "True") Then
                            sendEmail(userInfo, "REJECTED")
                        End If
                    End If
                Else 'No preorder, so just update reservation 
                    If (clsReservation.UpdateReservation() = "True") Then
                        sendEmail(userInfo, "REJECTED")
                    End If
                End If
            End If
        ElseIf (e.CommandName = "View") Then
            Dim menuInfo As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument))
            rptMenuOrdered.DataSource = menuInfo.RetrievePreOrderMenu()
            rptMenuOrdered.DataBind()
            my_popup.Style.Add("display", "block")
            popup.Style.Add("display", "block")
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

    Protected Sub sendEmail(info As Reservation, status As String)

        Dim subject As String = "Reservation for " & info.firstName & " " & info.lastName & ", " & info.dtdate
        Dim body As String = ""
        Select Case status
            Case "CONFIRMED"
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
            Case "CANCELLED"
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
        MsgBox("Reservation have been " & status)
    End Sub

    Protected Sub gvReservationUpcoming_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If (e.CommandName = "Approve") Then
            Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument), "Approved")
            Dim userInfo As Reservation = clsReservation.RetrieveReservationEmail()
            If (Not userInfo.status = "Pending") Then
                MsgBox("Unable to confirm reservation. Refreshing page")
            Else
                If (userInfo.preordermeals = "Yes") Then 'If there is preordermeal, popup Yes n No
                    Dim result As MsgBoxResult = MsgBox("Approve preorder menu?", MsgBoxStyle.YesNoCancel)
                    If result = result.Yes Then 'Approve reservation and preorder
                        If (clsReservation.UpdateReservation() = "True") Then
                            Dim batchid As Integer = clsReservation.RetrieveBatchOrderIdByReservationID()
                            clsReservation = New Reservation(batchid, "7")
                            If (clsReservation.UpdateReservationOrder() = "True") Then
                                sendEmail(userInfo, "APPROVED and preorder menu APPROVED")
                            End If
                        End If
                    ElseIf result = result.No Then 'Reject preorder Approve reservation
                        If (clsReservation.UpdateReservation() = "True") Then
                            Dim batchid As Integer = clsReservation.RetrieveBatchOrderIdByReservationID()
                            clsReservation = New Reservation(batchid, "8")
                            If (clsReservation.UpdateReservationOrder() = "True") Then
                                sendEmail(userInfo, "APPROVED but preorder menu REJECTED")
                            End If
                        End If
                    End If
                Else 'No preorder, so just update reservation 
                    If (clsReservation.UpdateReservation() = "True") Then
                        sendEmail(userInfo, "APPROVED")
                    End If
                End If
            End If
        ElseIf (e.CommandName = "Reject") Then
            Dim clsReservation As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument), "Rejected")
            Dim userInfo As Reservation = clsReservation.RetrieveReservationEmail()
            If (Not userInfo.status = "Pending") Then
                MsgBox("Unable to cancel reservation. Refreshing page")
            Else
                If (userInfo.preordermeals = "Yes") Then 'If there is preordermeal, popup Yes n No
                    If (clsReservation.UpdateReservation() = "True") Then
                        Dim batchid As Integer = clsReservation.RetrieveBatchOrderIdByReservationID()
                        clsReservation = New Reservation(batchid, "8")
                        If (clsReservation.UpdateReservationOrder() = "True") Then
                            sendEmail(userInfo, "REJECTED")
                        End If
                    End If
                Else 'No preorder, so just update reservation 
                    If (clsReservation.UpdateReservation() = "True") Then
                        sendEmail(userInfo, "REJECTED")
                    End If
                End If
            End If
        ElseIf (e.CommandName = "View") Then
            Dim menuInfo As Reservation = New Reservation(Convert.ToInt32(e.CommandArgument))
            rptMenuOrdered.DataSource = menuInfo.RetrievePreOrderMenu()
            rptMenuOrdered.DataBind()
            my_popup.Style.Add("display", "block")
            popup.Style.Add("display", "block")
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
            Dim name As Literal = (TryCast(e.Item.FindControl("litName"), Literal))
            Dim quantity As Literal = (TryCast(e.Item.FindControl("litQuantity"), Literal))
            Dim cost As Literal = (TryCast(e.Item.FindControl("litCost"), Literal))
            name.Text = menuName
            quantity.Text = "x" & menuQuantity
            cost.Text = "$" & singleCost
            lblTotal.Text = "$" & totalCost

        End If
    End Sub
End Class