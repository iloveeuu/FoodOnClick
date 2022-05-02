Public Class adminReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsReport As Report = New Report()
        adminReport.DataSource = clsReport.getAdminReport(adminReportFilterButton.SelectedValue)
        adminReport.DataBind()

        customerNum.Text = clsReport.getAdminReportUserNo("Customer")
        riderNum.Text = clsReport.getAdminReportUserNo("Rider")
        restaurantNum.Text = clsReport.getAdminReportUserNo("Restaurant")
    End Sub


    Protected Sub adminReportFilter(sender As Object, e As EventArgs)
        Dim clsReport As Report = New Report()
        adminReport.DataSource = clsReport.getAdminReport(adminReportFilterButton.SelectedValue)
        adminReport.DataBind()

    End Sub

    Protected Sub adminReport_ItemDataBound(sender As Object, e As EventArgs)


    End Sub

    Protected Sub adminReport_ItemCommand(source As Object, e As RepeaterCommandEventArgs)

    End Sub


End Class