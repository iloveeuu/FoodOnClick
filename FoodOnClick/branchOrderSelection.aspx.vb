Public Class branchOrders
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("branchmenu.aspx")
    End Sub

    Protected Sub btnOrder_Click(sender As Object, e As EventArgs)
        Response.Redirect("branchOrder.aspx")
    End Sub

    Protected Sub btnRecurring_Click(sender As Object, e As EventArgs)

    End Sub
End Class