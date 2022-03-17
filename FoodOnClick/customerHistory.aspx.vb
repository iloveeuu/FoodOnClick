Public Class customerHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                Dim dtReservation As DataTable
                Dim clsReservation As Reservation = New Reservation(Session("userid"))
                dtReservation = clsReservation.GetReservationHistory()
                gvReservation.DataSource = dtReservation
                gvReservation.DataBind()
            End If
        End If
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerProfile.aspx")
    End Sub
End Class