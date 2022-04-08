Public Class signUpHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lbtnCustomerAcc_Click(sender As Object, e As EventArgs) Handles lbtnCustomerAcc.Click
        Session("accountType") = "Customer"
        Response.Redirect("signUp.aspx")
    End Sub

    Protected Sub lbtnRestaurantAcc_Click(sender As Object, e As EventArgs) Handles lbtnRestaurantAcc.Click
        Session("accountType") = "Restaurant"
        Response.Redirect("signUp.aspx")
    End Sub

    Protected Sub lbtnRider_Click(sender As Object, e As EventArgs) Handles lbtnRiderAcc.Click
        Session("accountType") = "Rider"
        Response.Redirect("signUp.aspx")
    End Sub

End Class
