Public Class Masterpage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Session("userid") Is Nothing) Then
            hlLoginSignUp.Text = "Welcome " & Session("firstname") & " " & Session("lastname")
        Else
            hlLoginSignUp.Text = "Login/Sign Up"
        End If
    End Sub

End Class