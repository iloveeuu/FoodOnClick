Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException


Public Class administratorManage
    Inherits System.Web.UI.Page

    Dim userID As Int32
    Dim emailAddress As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=foodonclick.mssql.somee.com;Initial Catalog=foodonclick;User ID=fypfoodonclick_SQLLogin_1;Password=eeq5c9sxpx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid where dbo.UserAccount.status='VETTING'"

        dr = cmd.ExecuteReader

        If dr.HasRows Then
            cmd.CommandText = "SELECT COUNT(DISTINCT(dbo.document.userid)) FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid where dbo.UserAccount.status='VETTING'"
            dr = cmd.ExecuteReader
            totalPendingCase.Text = dr.GetInt32(0)

            cmd.CommandText = "SELECT TOP 1 dbo.UserAccount.userid, dbo.UserAccount.email  FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING'  ORDER BY dbo.UserAccount.userid"
            dr = cmd.ExecuteReader
            document_useriID.Text = dr.GetInt32(0)
            userID = dr.GetInt32(0)
            emailAddress = dr.GetString(1)


            cmd.CommandText = "Select dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID AND dbo.document.type='Restaurant Logo'"
            dr = cmd.ExecuteReader
            document_restaurantLogo.Text = dr.GetString(0)

            cmd.CommandText = "Select dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID AND dbo.document.type='Business License'"
            dr = cmd.ExecuteReader
            document_businessLicense.Text = dr.GetString(0)

            cmd.CommandText = "Select  dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID AND dbo.document.type='Halal'"
            dr = cmd.ExecuteReader
            document_halal.Text = dr.GetString(0)

            con.Close()

        Else
            MsgBox("Congraulation, you have cleared all Pending Approvals")
            totalPendingCase.Text = 0
            document_restaurantLogo.Text = ""
            document_businessLicense.Text = ""
            document_halal.Text = ""



            con.Close()
        End If

    End Sub

    Protected Sub systemAdminRegistrationApprove(sender As Object, e As EventArgs) Handles systemAdminRegistration_Approve.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim mail As New SMTP()


        con.ConnectionString = "Data Source=foodonclick.mssql.somee.com;Initial Catalog=foodonclick;User ID=fypfoodonclick_SQLLogin_1;Password=eeq5c9sxpx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.status='APPROVED' WHERE userid=@userID;"


        Dim ToAddressies As String() = {"fyp-foodonclick@hotmail.com", emailAddress}
        Dim attachs() As String = {}
        Dim subject As String = "Registration Request---Approved"
        Dim body As String = "Dear customer , we are pleased to inform you that your registration request has been approved, we are looking forward to starting business with you."
        Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
        If result Then
            MsgBox("mails sended successfully", MsgBoxStyle.Information)
        Else
            MsgBox(mail.ErrorText, MsgBoxStyle.Critical)
        End If

        con.Close()
        Response.Redirect("adminstratorManageRegistrations.aspx")
    End Sub


    Protected Sub systemAdminRegistrationReject(sender As Object, e As EventArgs) Handles systemAdminRegistration_Reject.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim mail As New SMTP()


        con.ConnectionString = "Data Source=foodonclick.mssql.somee.com;Initial Catalog=foodonclick;User ID=fypfoodonclick_SQLLogin_1;Password=eeq5c9sxpx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.status='REJECTED' WHERE userid=@userID;"


        Dim ToAddressies As String() = {"fyp-foodonclick@hotmail.com", emailAddress}
        Dim attachs() As String = {}
        Dim subject As String = "Registration Request---Rejected"
        Dim body As String = "Dear customer , we are sorry to inform you that your request is rejected"
        Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
        If result Then
            MsgBox("mails sended successfully", MsgBoxStyle.Information)
        Else
            MsgBox(mail.ErrorText, MsgBoxStyle.Critical)
        End If

        con.Close()
        Response.Redirect("adminstratorManageRegistrations.aspx")
    End Sub




End Class