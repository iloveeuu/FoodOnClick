Public Class customerReservation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                lblRestName.Text = Session("restName")
                lblHalal.Text = Session("halal")
                lblAddress.Text = Session("address")

                lblOpenTime.Text = Session("timeOpen")
                lblCloseTime.Text = Session("timeClosed")

                CompareEndTodayValidator.ValueToCompare = DateTime.Now.AddHours(13).ToShortDateString()

                rvTime.MinimumValue = Session("timeOpen")
                rvTime.MaximumValue = Session("timeClosed")

                'default
                txtPax.Text = 1
                txtDate.Text = DateTime.Now.AddHours(13).ToShortDateString()
            End If
        End If
    End Sub

    Protected Sub btnReserve_Click(sender As Object, e As EventArgs)

        If txtDate.Text.Trim() = "" Or txtPax.Text.Trim() = "" Or txtTime.Text.Trim() = "" Then
            errorText.Attributes("style") = "display: block; text-align: center; color:red;"
        Else
            errorText.Attributes("style") = "display: none"
            tblStyle.Attributes("style") = "display: block;width: 20%;height: 60%;margin-left: auto;margin-right: auto;"
            btnReserve.Visible = False
        End If

    End Sub

    Protected Sub btnNo_Click(sender As Object, e As EventArgs)
        Dim duration As String = Convert.ToString(txtDuration.Text.Trim()) + " hrs"
        Dim user As User = New User()
        Dim resv As Reservation = New Reservation("No", txtDate.Text.Trim(), txtTime.Text.Trim(), txtPax.Text.Trim(), "Pending", Session("branchid"), Session("userid"), Nothing, duration)
        resv.InsertReservation()

        Dim subject As String = "Reservation from " & Session("firstname") & " " & Session("lastname") & ", " & txtDate.Text.Trim()

        Dim body As String = "<html> " &
                            "<body>" &
                            "<p>Dear " & lblRestName.Text & ",</p>" &
                            "<p>At " & lblAddress.Text & ",</p>" &
                            "<br/>" &
                            "<p>You have reservation from " & Session("firstname") & " " & Session("lastname") & " at " & txtDate.Text.Trim() & " time " & txtTime.Text.Trim() & " for " & txtPax.Text.Trim() & " pax </p>" &
                            "<p>Please check your reservation list and response the status</p>" &
                            "<br/>" &
                            "<p>Regards,</p>" &
                            "<p>Food on Click</p>" &
                            "</body>" &
                            "</html>"

        Dim smtp As SMTP = New SMTP()
        Dim email() As String = {Session("email")}
        smtp.SendMail(email, subject, body, Nothing, True)

        Response.Write("<script language='javascript'>window.alert('Reservation Created, Please Wait for Confirmation');window.location='customerHome.aspx';</script>")

    End Sub

    Protected Sub btnYes_Click(sender As Object, e As EventArgs)
        Dim duration As String = Convert.ToString(txtDuration.Text.Trim()) + " hrs"

        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Session("branchid") = Session("branchid")
        Session("restName") = Session("restName")
        Session("halal") = Session("halal")
        Session("address") = Session("address")
        Session("pax") = txtPax.Text.Trim()
        Session("date") = txtDate.Text.Trim()
        Session("time") = txtTime.Text.Trim()
        Session("duration") = duration

        Session("dtTable") = Nothing
        Response.Redirect("customerPreOrder.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHistory.aspx")
    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerCart.aspx")
    End Sub
End Class