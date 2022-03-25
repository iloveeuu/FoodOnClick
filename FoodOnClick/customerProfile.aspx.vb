﻿Public Class customerProfile
    Inherits System.Web.UI.Page
    Dim gender As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                If (Session("type") = "Restaurant") Then
                    btnHistory.Visible = False
                    btnCart.Visible = False
                End If
                If (Session("type") = "Administrator") Then
                    btnHistory.Visible = False
                    btnCart.Visible = False
                End If
                DataBind()
            End If
        End If
    End Sub

    Protected Sub DataBind()
        Dim customer As Customer = New Customer()
        Dim data As Customer = customer.GetCustomerDetail(Session("userid"))
        Dim dtDate As Date

        lblEmail.Text = Session("email")
        txtFirstName.Text = data.firstName
        txtLastName.Text = data.lastName
        txtPhone.Text = data.phone
        txtAddress.Text = data.address

        If data.gender = "Male" Then
            gender = "Male"
            rbMale.Checked = True
        ElseIf data.gender = "Female" Then
            gender = "Female"
            rbFemale.Checked = True
        End If

        dtDate = data.dateOfBirth
        txtDOB.Text = String.Format("{0:yyyy-MM-dd}", dtDate)
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        If Session("type") = "Restaurant" Then
            Response.Redirect("branch.aspx")
        ElseIf Session("type") = "Customer" Then
            Response.Redirect("customerHome.aspx")
        ElseIf Session("type") = "Administrator" Then
            Response.Redirect("administratorHome.aspx")
        End If

    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerHistory.aspx")
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)

        If rbMale.Checked = True Then
            gender = "Male"
        ElseIf rbFemale.Checked = True Then
            gender = "Female"
        End If

        If txtFirstName.Text.Trim() = "" Or txtLastName.Text.Trim() = "" Or txtPhone.Text.Trim() = "" Or txtAddress.Text.Trim() = "" Or gender = "" Or txtDOB.Text.Trim() = "" Then
            errorText.Attributes("style") = "display: block; text-align: center; color:red;"
        Else
            Dim customer As Customer = New Customer()
            customer.UpdateCustomer(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtPhone.Text.Trim(), gender, txtDOB.Text.Trim(), Session("email"), Session("userid"))

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Profile Updated")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

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

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Password Changed")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())


            DataBind()
        End If
    End Sub

    Protected Sub RadioButtonM_CheckedChanged(sender As Object, e As EventArgs) Handles rbMale.CheckedChanged
        gender = "Male"
    End Sub

    Protected Sub RadioButtonF_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemale.CheckedChanged
        gender = "Female"
    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Response.Redirect("customerCart.aspx")
    End Sub
End Class