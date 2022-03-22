Public Class forgetPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs)
        Dim clsUser As User = New User(txtEmail.Text.Trim())
        Dim rawPw As String = clsUser.ForgetPassword()
        If (rawPw = "False") Then
            Dim message As String = "Wrong email address"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Else
            sendEmail(txtEmail.Text.Trim(), rawPw)
        End If
    End Sub
    Protected Sub sendEmail(email1 As String, password As String)

        Dim subject As String = "Forget password for " & email1
        Dim body As String = ""
        Dim message As String = ""
        body = "<html> " &
                    "<body>" &
                    "<p>Dear " & email1 & ",</p>" &
                    "<br/><br/>" &
                    "<p>Your new password is " & password &
                    "<br/><br/>" &
                    "<p>Regards,</p>" &
                    "<p>Food on Click</p>" &
                    "</body>" &
                    "</html>"

        Dim smtp As SMTP = New SMTP()
        Dim email() As String = {email1}
        smtp.SendMail(email, subject, body, Nothing, True)
        message = "New Password has been sent to your email"
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub
End Class