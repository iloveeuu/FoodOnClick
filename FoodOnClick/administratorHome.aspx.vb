Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException

Public Class administratorHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim dtSearch = New DataTable()

        con.ConnectionString = "Data Source=foodonclick.mssql.somee.com;Initial Catalog=foodonclick;User ID=fypfoodonclick_SQLLogin_1;Password=eeq5c9sxpx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
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

End Class