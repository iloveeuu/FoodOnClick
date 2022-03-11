Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException

Public Class signUp
    Inherits System.Web.UI.Page
    Dim gender As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSignUpCustomer_Click(sender As Object, e As EventArgs) Handles btnSignUpCustomer.Click

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=foodonclick.mssql.somee.com;Initial Catalog=foodonclick;User ID=fypfoodonclick_SQLLogin_1;Password=eeq5c9sxpx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select * from UserAccount where email = '" & txtEmail.Text & "'"

        dr = cmd.ExecuteReader
        If dr.HasRows Then
            MsgBox("Email Already Exists", MsgBoxStyle.Critical)
            con.Close()
        Else
            con.Close()

            If (txtFirstName.Text.Trim() = "" Or txtLastName.Text.Trim() = "" Or txtAddress.Text.Trim() = "" Or txtContactNo.Text.Trim() = "" Or txtDOB.Text.Trim() = "" Or txtUsername.Text.Trim() = "" Or txtPass.Text.Trim() = "" Or txtEmail.Text.Trim() = "") Then
                MsgBox("Please enter the correct details!")
            Else
                Dim pass As Encryption = New Encryption(txtPass.Text.Trim())
                Dim encrypted As String = pass.Encrypt()

                Dim customer As Customer = New Customer(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtContactNo.Text.Trim(), gender _
                                 , txtDOB.Text.Trim(), "customer", txtUsername.Text.Trim(), encrypted, txtEmail.Text.Trim())

                customer.InsertCustomer()
                MsgBox("Successfully Stored", MsgBoxStyle.Information, "Success")
                Response.Redirect("Login.aspx")
            End If
        End If
    End Sub

    Protected Sub btnSignUpMerchant_Click(sender As Object, e As EventArgs) Handles btnSignUpMerchant.Click

        If (txtFirstName.Text.Trim() = "" Or txtLastName.Text.Trim() = "" Or txtAddress.Text.Trim() = "" Or txtContactNo.Text.Trim() = "" Or txtDOB.Text.Trim() = "" Or txtUsername.Text.Trim() = "" Or txtPass.Text.Trim() = "" Or txtEmail.Text.Trim() = "") Then
            MsgBox("Please enter the correct details!")
        Else

            Session("FirstName") = txtFirstName.Text.Trim()
            Session("LastName") = txtLastName.Text.Trim()
            Session("Address") = txtAddress.Text.Trim()
            Session("ContactNo") = txtContactNo.Text.Trim()
            Session("DOB") = txtDOB.Text.Trim()
            Session("Username") = txtUsername.Text.Trim()
            Session("Pass") = txtPass.Text.Trim()
            Session("Email") = txtEmail.Text.Trim()

            Response.Redirect("signUpMerchant.aspx")
        End If
    End Sub

    Protected Sub RadioButtonM_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonM.CheckedChanged
        gender = "Male"
    End Sub

    Protected Sub RadioButtonF_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonF.CheckedChanged
        gender = "Female"
    End Sub

End Class