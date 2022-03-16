Public Class Masterpage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Session("userid") Is Nothing) Then
            lbLoginSignUp.Text = "Welcome " & Session("firstname") & " " & Session("lastname")
            lblLogOut.Visible = True
        Else
            lbLoginSignUp.Text = "Login/Sign Up"
            lblLogOut.Visible = False
        End If
    End Sub

    Protected Sub lbLoginSignUp_Click(sender As Object, e As EventArgs)
        If (Not Session("userid") Is Nothing) Then
            If Session("type") = "Customer" Then
                Response.Redirect("customerProfile.aspx")
            End If
        End If
    End Sub

    Protected Sub lblLogOut_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()
        lblLogOut.Visible = False
        Response.Redirect("login.aspx")

    End Sub
End Class