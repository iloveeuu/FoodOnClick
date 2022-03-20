Public Class adminstratorHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub manageApprovalClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles manageApproval.Load
        Response.Redirect("adminstratorManageRegistrations.aspx")



    End Sub

End Class