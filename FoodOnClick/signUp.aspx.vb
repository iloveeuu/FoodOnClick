Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException

Public Class signUp
    Inherits System.Web.UI.Page
    Dim gender As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click

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

            con.Open()
            cmd = New SqlCommand("INSERT INTO UserAccount
                                 values ('" & txtFirstName.Text & "','" & txtLastName.Text & "',
                                 '" & txtAddress.Text & "', '" & txtContactNo.Text & "', '" & gender & "'
                                 ,'" & txtDOB.Text & "', '" & ddlUserType.Text & "', '" & txtUsername.Text & "'
                                 ,'" & txtPass.Text & "' ,'" & txtEmail.Text & "')", con)

            If (txtFirstName.Text = "" Or txtLastName.Text = "" Or txtAddress.Text = "" Or txtContactNo.Text = "" Or txtDOB.Text = "" Or ddlUserType.Text = "" Or txtUsername.Text = "" Or txtPass.Text = "" Or txtEmail.Text = "") Then
                MsgBox("Please enter the correct details!")
            Else
                cmd.ExecuteNonQuery()
                MsgBox("Successfully Stored", MsgBoxStyle.Information, "Success")
                Response.Redirect("Contact.aspx")
            End If
            con.Close()
        End If

        If ddlUserType.SelectedValue = "Customer" Then
            Dim customer As Customer = New Customer(txtUsername.Text.Trim(), txtPass.Text.Trim())

            customer.InsertCustomer()
        ElseIf ddlUserType.SelectedValue = "Restaurant" Then
            Dim merchant As Merchant = New Merchant(txtUsername.Text.Trim(), txtPass.Text.Trim())

            merchant.InsertMerchant()
        ElseIf ddlUserType.SelectedValue = "Rider" Then
            Dim rider As Rider = New Rider(txtUsername.Text.Trim(), txtPass.Text.Trim())

            rider.InsertRider()
        End If
    End Sub

    Protected Sub RadioButtonM_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonM.CheckedChanged
        gender = "Male"

    End Sub

    Protected Sub RadioButtonF_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonF.CheckedChanged
        gender = "Female"
    End Sub

End Class