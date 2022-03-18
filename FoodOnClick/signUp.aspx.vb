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


        newUserAdd = newUser.addNewUserAccount(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtContactNo.Text.Trim(), gender, txtDOB.Text.Trim(),
                             ddlUserType.Text, txtPass.Text.Trim(), txtEmail.Text.Trim(), "Vetting")

        If newUserAdd = True And ddlUserType.Text.Equals("Restaurant") Then
            Response.Redirect("restaurantUploadDocuments.aspx")
            sendAdminEmail(txtEmail.Text.Trim(), ddlUserType.Text)
        ElseIf newUserAdd = True Then
            sendAdminEmail(txtEmail.Text.Trim(), ddlUserType.Text)
            Response.Redirect("login.aspx")
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
        Dim email() As String = {Session("email")}

        smtp.SendMail(email, subject, body, Nothing, True)

        MsgBox("New user account Created, Please Wait for administrator's approval")

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