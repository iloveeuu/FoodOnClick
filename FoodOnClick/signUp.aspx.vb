Public Class signUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click

        If ddlType.SelectedValue = "Customer" Then
            Dim customer As Customer = New Customer(txtUser.Text.Trim(), txtPass.Text.Trim())

            customer.InsertCustomer()
        ElseIf ddlType.SelectedValue = "Restaurant" Then
            Dim merchant As Merchant = New Merchant(txtUser.Text.Trim(), txtPass.Text.Trim())

            merchant.InsertMerchant()
        ElseIf ddlType.SelectedValue = "Rider" Then
            Dim rider As Rider = New Rider(txtUser.Text.Trim(), txtPass.Text.Trim())

            rider.InsertRider()
        End If
    End Sub

End Class