Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException

Public Class signUp
    Inherits System.Web.UI.Page
    Dim gender As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click

        Dim newUser As User = New User()
        Dim newUserAdd As Boolean
        Dim message As String

        If (RadioButtonM.Checked) Then
            gender = "Male"
        ElseIf (RadioButtonF.Checked) Then
            gender = "Female"
        End If
        If (txtFirstName.Text.Trim() = "" Or txtLastName.Text.Trim() = "" Or txtAddress.Text.Trim() = "" Or txtContactNo.Text.Trim() = "" Or gender = "" Or txtDOB.Text.Trim() = "" Or ddlUserType.Text = "" Or txtPass.Text.Trim() = "" Or txtEmail.Text.Trim() = "") Then
            message = "Please fill in all fields"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Else
            If ddlUserType.Text.Equals("Customer") Or ddlUserType.Text.Equals("Rider") Then
                newUserAdd = newUser.addNewUserAccount(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtContactNo.Text.Trim(), gender, txtDOB.Text.Trim(),
                    ddlUserType.Text, txtPass.Text.Trim(), txtEmail.Text.Trim(), "APPROVED")
            Else
                newUserAdd = newUser.addNewUserAccount(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtContactNo.Text.Trim(), gender, txtDOB.Text.Trim(),
                 ddlUserType.Text, txtPass.Text.Trim(), txtEmail.Text.Trim(), "VETTING")
            End If
            If newUserAdd = False Then
                message = "User exists"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                If newUserAdd = True And ddlUserType.Text.Equals("Restaurant") Then
                    sendAdminEmail(txtEmail.Text.Trim(), ddlUserType.Text)
                    message = "New user account Created, Please Wait for administrator\'s approval"
                    Dim sb As New System.Text.StringBuilder()
                    sb.Append("<script type = 'text/javascript'>")
                    sb.Append("window.onload=function(){")
                    sb.Append("alert('")
                    sb.Append(message)
                    sb.Append("');window.location='restaurantUploadDocuments.aspx';};")
                    sb.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                    'Response.Redirect("restaurantUploadDocuments.aspx")

                ElseIf newUserAdd = True Then
                    sendAdminEmail(txtEmail.Text.Trim(), ddlUserType.Text)

                    message = "New user account Created"
                    Dim sb As New System.Text.StringBuilder()
                    sb.Append("<script type = 'text/javascript'>")
                    sb.Append("window.onload=function(){")
                    sb.Append("alert('")
                    sb.Append(message)
                    sb.Append("');window.location='login.aspx';};")
                    sb.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                End If
            End If
        End If


    End Sub


    Protected Sub sendAdminEmail(useremail, usertype)

        Dim subject As String = "New User (" & useremail & " " & usertype & ", )"

        Dim body As String = "<html> " &
                            "<body>" &
                            "<p>Dear System Administrato</p>" &
                            "<p>New User Alert</p>" &
                            "<br/>" &
                            "<p>You have new user " & useremail & " " & usertype & " </p>" &
                            "<p>Please login to approve/reject user access</p>" &
                            "<br/>" &
                            "<p>Regards,</p>" &
                            "<p>Food on Click</p>" &
                            "</body>" &
                            "</html>"

        Dim smtp As SMTP = New SMTP()
        Dim email() As String = {"will.ariez@gmail.com"}

        smtp.SendMail(email, subject, body, Nothing, True)

        'MsgBox("New user account Created, Please Wait for administrator's approval")

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("login.aspx")
    End Sub

    Protected Sub RadioButtonM_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonM.CheckedChanged
        gender = "Male"
    End Sub

    Protected Sub RadioButtonF_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonF.CheckedChanged
        gender = "Female"
    End Sub

End Class