Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim username As String = HttpUtility.HtmlEncode(txtUser.Text.Trim())
        Dim password As String = HttpUtility.HtmlEncode(txtPass.Text.Trim())

        Dim pass As Encryption = New Encryption(password)
        Dim encrypted As String = pass.Encrypt()

        Dim clsUser As User = New User(username.Trim(), encrypted)
        Select Case clsUser.CheckUserLoginAccess()
            Case "Administrator"
                Response.Redirect("administratorHome.aspx")
            Case "Rider"
                Response.Redirect("riderHome.aspx")
            Case "Restaurant"
                Response.Redirect("branch.aspx")
            Case "Customer"
                Response.Redirect("customerHome.aspx")
            Case Else
                Dim clsBranch As Branch = New Branch(username.Trim(), encrypted)
                If (clsBranch.CheckBranchLogin() = "True") Then
                    Response.Redirect("branchMenu.aspx")
                Else
                    'No user found, can display no user found msg or smth'
                    lblWrong.Visible = True
                End If


        End Select
    End Sub

    Protected Sub btnSignUp_Click(sender As Object, e As EventArgs)
        Response.Redirect("signUp.aspx")
    End Sub
End Class