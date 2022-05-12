Public Class riderReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsReport As Report = New Report()
        riderReport.DataSource = clsReport.getRiderReport(Session("userid"), riderReportFilterButton.SelectedValue)
        riderReport.DataBind()

    End Sub


    Protected Sub riderReportFilter(sender As Object, e As EventArgs)
        Dim clsReport As Report = New Report()
        riderReport.DataSource = clsReport.getRiderReport(Session("userid"), riderReportFilterButton.SelectedValue)
        riderReport.DataBind()



    End Sub



    Protected Sub riderReport_ItemDataBound(sender As Object, e As EventArgs)


    End Sub

    Protected Sub riderReport_ItemCommand(source As Object, e As RepeaterCommandEventArgs)

    End Sub

    Protected Sub riderReport_RowCommand(sender As Object, e As GridViewCommandEventArgs)

    End Sub
End Class