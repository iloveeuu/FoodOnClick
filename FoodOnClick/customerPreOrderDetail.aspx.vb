Public Class CustomerPreOrderDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                Dim clsOrderDetail As OrderDetail = New OrderDetail()
                clsOrderDetail.batchId = Session("batchId")
                Dim dtTable As DataTable = clsOrderDetail.GetOrderDetail()

                gvMenu.DataSource = dtTable
                gvMenu.DataBind()

                lblRestName.Text = Session("restName")
                lblAddress.Text = Session("address")
                lblDate.Text = Session("date")
                lblTime.Text = Session("time")
                lblTotal.Text = "$" + dtTable.Rows(0)(4).ToString()
            End If
        End If
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerHistory.aspx")
    End Sub
End Class