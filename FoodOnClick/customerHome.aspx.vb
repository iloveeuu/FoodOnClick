Public Class customerHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            End If
        End If
    End Sub

    Protected Sub lbtnDelivery_Click(sender As Object, e As EventArgs) Handles lbtnDelivery.Click
        Session("orderType") = "delivery"
        Session("userid") = Session("userid")
        Session("firstname") = Session("firstname")
        Session("lastname") = Session("lastname")
        Session("address") = Session("address")
        Session("phonenum") = Session("phonenum")
        Session("gender") = Session("gender")
        Session("dateofbirth") = Session("dateofbirth")
        Session("type") = Session("type")
        Session("email") = Session("email")
        Response.Redirect("customerSearch.aspx")
    End Sub

    Protected Sub lbtnReservation_Click(sender As Object, e As EventArgs) Handles lbtnReservation.Click
        Session("orderType") = "reservation"
        Session("userid") = Session("userid")
        Session("firstname") = Session("firstname")
        Session("lastname") = Session("lastname")
        Session("address") = Session("address")
        Session("phonenum") = Session("phonenum")
        Session("gender") = Session("gender")
        Session("dateofbirth") = Session("dateofbirth")
        Session("type") = Session("type")
        Session("email") = Session("email")
        Response.Redirect("customerSearch.aspx")
    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerHistory.aspx")
    End Sub
End Class