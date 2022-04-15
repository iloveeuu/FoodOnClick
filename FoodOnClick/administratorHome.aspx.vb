Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException

Public Class administratorHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim dtSearch = New DataTable()

        con.ConnectionString = "workstation id=foodonclick2.mssql.somee.com;packet size=4096;user id=fypfoodonclick_SQLLogin_1;pwd=eeq5c9sxpx;data source=foodonclick2.mssql.somee.com;persist security info=False;initial catalog=foodonclick2"
        con.Open()
        cmd.Connection = con

        cmd = New SqlCommand("SELECT COUNT(DISTINCT(dbo.document.userid)) AS COUNT FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid where dbo.UserAccount.status='VETTING'", con)
        dr = cmd.ExecuteReader
        Do While dr.Read()
            totalPendingCaseHome.Text = dr.GetInt32(0)
        Loop
        dr.Close()
        con.Close()



    End Sub

    Protected Sub manageApprovalClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles manageApproval.Click
        Response.Redirect("adminstratorManageRegistrations.aspx")

    End Sub

    Protected Sub manageCuisineTypeChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles changeCuisineType.Click
        Response.Redirect("administratorChangeCuisineType.aspx")
    End Sub


    Protected Sub manageApprovalClickRider(ByVal sender As Object, ByVal e As System.EventArgs) Handles manageRiderRegistration.Click
        Response.Redirect("adminstratorManageRegistrationsRider.aspx")
    End Sub


    Protected Sub manageUser(ByVal sender As Object, ByVal e As System.EventArgs) Handles userManagement.Click
        Response.Redirect("administratorUserManagement.aspx")
    End Sub

End Class