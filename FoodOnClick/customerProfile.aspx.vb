﻿Public Class customerProfile
    Inherits System.Web.UI.Page
    Dim gender As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                DataBind()
            End If
        End If
    End Sub

    Protected Sub DataBind()
        Dim customer As Customer = New Customer()
        Dim data As Customer = customer.GetCustomerDetail(Session("userid"), Session("email"))

        lblEmail.Text = data.email
        txtFirstName.Text = data.firstName
        txtLastName.Text = data.lastName
        txtPhone.Text = data.phone
        txtAddress.Text = data.address

        If data.gender = "Male" Then
            rbMale.Checked = True
        ElseIf data.gender = "Female" Then
            rbFemale.Checked = True
        End If
        txtDOB.Text = data.dateOfBirth
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

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)

        If txtFirstName.Text.Trim() = "" Or txtLastName.Text.Trim() = "" Or txtPhone.Text.Trim() = "" Or txtAddress.Text.Trim() = "" Or gender = "" Or gender Is Nothing Or txtDOB.Text.Trim() = "" Then
            errorText.Attributes("style") = "display: block; text-align: center; color:red;"
        Else
            Dim customer As Customer = New Customer()
            customer.UpdateCustomer(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtPhone.Text.Trim(), gender, txtDOB.Text.Trim(), Session("email"), Session("userid"))

            MsgBox("Profile Updated")

            DataBind()
        End If
    End Sub

    Protected Sub btnChangePassword_Click(sender As Object, e As EventArgs)
        If txtPassword.Text.Trim() = "" Or txtPasswordConfirm.Text.Trim() = "" Then
            errorPass.Attributes("style") = "display: block; text-align: center; color:red;"
            lblErrorPass.Text = "Please fill up both fields"
        Else
            Dim customer As Customer = New Customer()
            customer.UpdatePassword(txtPassword.Text.Trim(), Session("email"), Session("userid"))

            MsgBox("Password Changed")

            DataBind()
        End If
    End Sub

    Protected Sub RadioButtonM_CheckedChanged(sender As Object, e As EventArgs) Handles rbMale.CheckedChanged
        gender = "Male"
    End Sub

    Protected Sub RadioButtonF_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemale.CheckedChanged
        gender = "Female"
    End Sub

End Class