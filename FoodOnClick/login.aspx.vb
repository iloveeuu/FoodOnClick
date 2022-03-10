﻿Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim username As String = HttpUtility.HtmlEncode(txtUser.Text)
        Dim password As String = HttpUtility.HtmlEncode(txtPass.Text)
        Dim clsUser As User = New User(username.Trim(), password.Trim())
        Select Case clsUser.CheckUserLoginAccess()
            Case "Administrator"
                Response.Redirect("administratorHome.aspx")
            Case "Rider"
                Response.Redirect("riderHome.aspx")
            Case "Restaurant"
                Response.Redirect("restaurantHome.aspx")
            Case "Customer"
                Response.Redirect("customerHome.aspx")
        End Select
    End Sub
End Class