Public Class signUpMerchant
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSignUpMerchant_Click(sender As Object, e As EventArgs) Handles btnSignUpMerchant.Click

        MsgBox("Successfully Stored, Please wait for Approval", MsgBoxStyle.Information, "Success")
        Response.Redirect("login.aspx")

    End Sub
End Class