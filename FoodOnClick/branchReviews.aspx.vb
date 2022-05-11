Public Class branchReviews
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            bindData()
        End If
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        dateFrom.Text = ""
        dateTo.Text = ""
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        If (dateFrom.Text = "" Or dateTo.Text = "") Then
            bindData()
        Else
            Dim clsReview As Review = New Review()
            rptReview.DataSource = clsReview.RetrieveBranchReviewsByDate(Convert.ToInt32(Session("branchid")), dateFrom.Text.Trim(), dateTo.Text.Trim())
            rptReview.DataBind()
        End If
    End Sub

    Protected Sub bindData()
        'lblTitle.Text = "All Reviews"
        Dim clsReview As Review = New Review()
        rptReview.DataSource = clsReview.RetrieveBranchReviews(Convert.ToInt32(Session("branchid")))
        rptReview.DataBind()
    End Sub

    Protected Sub rptReview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim description As String = DataBinder.Eval(e.Item.DataItem, "description")
        Dim lblDescription As Label = (TryCast(e.Item.FindControl("lblDescription"), Label))
        lblDescription.Text = description.Replace("CHAR(13)", "<br/>")
        Dim name As String = DataBinder.Eval(e.Item.DataItem, "descriptiondel")
        Dim lblName As Label = (TryCast(e.Item.FindControl("lblName"), Label))
        lblName.Text = name
        Dim rating As String = DataBinder.Eval(e.Item.DataItem, "ratingrest")
        Dim lblRating As Label = (TryCast(e.Item.FindControl("lblRating"), Label))
        lblRating.Text = "<b>" & rating & "/5" & "</b>"
        Dim date1 As DateTime = DataBinder.Eval(e.Item.DataItem, "dateid")
        Dim lblDate1 As Label = (TryCast(e.Item.FindControl("lblDate"), Label))
        lblDate1.Text = " Date: " & date1
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("branchMenu.aspx")
    End Sub
End Class