Public Class restaurantReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim clsReport As Report = New Report()
        restaurantReport.DataSource = clsReport.getRestaurantReport(Session("userid"), restaurantReportFilterButton.SelectedValue)
        restaurantReport.DataBind()
    End Sub



    Protected Sub restaruantReportFilter(sender As Object, e As EventArgs)
        Dim clsReport As Report = New Report()
        restaurantReport.DataSource = clsReport.getRestaurantReport(Session("userid"), restaurantReportFilterButton.SelectedValue)
        restaurantReport.DataBind()

    End Sub



    Protected Sub restaurantReport_ItemDataBound(sender As Object, e As EventArgs)


    End Sub

    Protected Sub restaurantReport_ItemCommand(source As Object, e As RepeaterCommandEventArgs)

    End Sub






End Class