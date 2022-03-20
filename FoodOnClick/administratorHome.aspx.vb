Public Class administratorHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub manageApprovalClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles manageApproval.cick
        Response.Redirect("administratorManageRegistrations.aspx")


    End Sub

End Class