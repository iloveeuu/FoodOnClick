Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException




Public Class adminstratorManageRegistrations_aspxt
    Inherits System.Web.UI.Page
    Dim userID As Integer
    Dim emailAddress As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim dtSearch = New DataTable()
        Dim message As String




        con.ConnectionString = "Data Source=foodonclick.mssql.somee.com;Initial Catalog=foodonclick;User ID=fypfoodonclick_SQLLogin_1;Password=eeq5c9sxpx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid where dbo.UserAccount.status='VETTING'"
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            dr.Close()
            con.Close()
            con.Open()

            cmd = New SqlCommand("SELECT COUNT(DISTINCT(dbo.document.userid)) AS COUNT FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid where dbo.UserAccount.status='VETTING'", con)
            dr = cmd.ExecuteReader
            Do While dr.Read()
                totalPendingCase.Text = dr.GetInt32(0)
            Loop
            dr.Close()
            con.Close()


            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 dbo.UserAccount.userid, dbo.UserAccount.email  FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING'  ORDER BY dbo.UserAccount.userid", con)
            dr = cmd.ExecuteReader
            Do While dr.Read()
                document_useriID.Text = dr.GetInt32(0)
                userID = dr.GetInt32(0)
                emailAddress = dr.GetString(1)
            Loop
            dr.Close()
            con.Close()


            'business Logo 
            con.Open()
            cmd = New SqlCommand("Select dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID  AND dbo.document.type='Restaurant Logo'", con)
            cmd.Parameters.AddWithValue("@userID", userID)
            dr = cmd.ExecuteReader

            Do While dr.Read()
                document_restaurantLogo.Text = dr.GetString(0)
            Loop
            dr.Close()
            con.Close()

            'business License 
            con.Open()
            cmd = New SqlCommand("Select dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID AND dbo.document.type='Business License'", con)
            cmd.Parameters.AddWithValue("@userID", userID)
            dr = cmd.ExecuteReader
            Do While dr.Read()
                document_businessLicense.Text = dr.GetString(0)
            Loop
            dr.Close()
            con.Close()

            'Halal
            con.Open()
            cmd = New SqlCommand("Select  dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID AND dbo.document.type='Halal'", con)
            cmd.Parameters.AddWithValue("@userID", userID)
            dr = cmd.ExecuteReader
            Do While dr.Read()
                document_halal.Text = dr.GetString(0)
            Loop
            dr.Close()
            con.Close()


        Else


            Message = "Congraulation, you have cleared all Pending Approvals"
            Dim sb1 As New System.Text.StringBuilder()
            sb1.Append("<script type='text/javascript'>")
            sb1.Append("window.onload=function(){")
            sb1.Append("alert('")
            sb1.Append(Message)
            sb1.Append("');window.location='adminstratorManageRegistrations.aspx';};")
            sb1.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())


            totalPendingCase.Text = 0
            document_restaurantLogo.Text = ""
            document_businessLicense.Text = ""
            document_halal.Text = ""
            dr.Close()
            con.Close()
        End If

    End Sub

    Protected Sub systemAdminRegistrationApprove(sender As Object, e As EventArgs) Handles systemAdminRegistration_Approve.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim mail As New SMTP()
        Dim message1 As String
        Dim message2 As String
        Dim message3 As String

        con.ConnectionString = "Data Source=foodonclick.mssql.somee.com;Initial Catalog=foodonclick;User ID=fypfoodonclick_SQLLogin_1;Password=eeq5c9sxpx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.status='APPROVED' WHERE userid=@userID;"
        cmd.Parameters.AddWithValue("@userID", userID)
        cmd.ExecuteNonQuery()

        message1 = "User ID " & userID & " is approved"
        Dim sb1 As New System.Text.StringBuilder()
        sb1.Append("<script type='text/javascript'>")
        sb1.Append("window.onload=function(){")
        sb1.Append("alert('")
        sb1.Append(message1)
        sb1.Append("');window.location='adminstratorManageRegistrations.aspx';};")
        sb1.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())



        Dim ToAddressies As String() = {emailAddress}
        Dim attachs() As String = {}
        Dim subject As String = "Registration Request---Approved"
        Dim body As String = "Dear customer , we are pleased to inform you that your registration request has been approved, we are looking forward to starting business with you."
        Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
        If result Then
            message2 = "Email is sent "
            Dim sb2 As New System.Text.StringBuilder()
            sb2.Append("<script type='text/javascript'>")
            sb2.Append("window.onload=function(){")
            sb2.Append("alert('")
            sb2.Append(message1)
            sb2.Append("');window.location='adminstratorManageRegistrations.aspx';};")
            sb2.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())
        Else
            message3 = "Email is not sent,please check Email address"
            Dim sb3 As New System.Text.StringBuilder()
            sb3.Append("<script type='text/javascript'>")
            sb3.Append("window.onload=function(){")
            sb3.Append("alert('")
            sb3.Append(message1)
            sb3.Append("');window.location='adminstratorManageRegistrations.aspx';};")
            sb3.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())
        End If





        con.Close()


    End Sub


    Protected Sub systemAdminRegistrationReject(sender As Object, e As EventArgs) Handles systemAdminRegistration_Reject.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim mail As New SMTP()
        Dim message1 As String
        Dim message2 As String
        Dim message3 As String


        con.ConnectionString = "Data Source=foodonclick.mssql.somee.com;Initial Catalog=foodonclick;User ID=fypfoodonclick_SQLLogin_1;Password=eeq5c9sxpx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.status='REJECTED' WHERE userid=@userID;"
        cmd.Parameters.AddWithValue("@userID", userID)
        cmd.ExecuteNonQuery()


        message1 = "User ID " & userID & " is rejected"
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type='text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message1)
        sb.Append("');window.location='adminstratorManageRegistrations.aspx';};")
        sb.Append("</script>")

        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

        con.Close()



        Dim ToAddressies As String() = {emailAddress}
        Dim attachs() As String = {}
        Dim subject As String = "Registration Request---Rejected"
        Dim body As String = "Dear customer , we are sorry to inform you that your request is rejected"
        Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
        If result Then
            message2 = "Email is sent "
            Dim sb2 As New System.Text.StringBuilder()
            sb2.Append("<script type='text/javascript'>")
            sb2.Append("window.onload=function(){")
            sb2.Append("alert('")
            sb2.Append(message1)
            sb2.Append("');window.location='adminstratorManageRegistrations.aspx';};")
            sb2.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
        Else
            message3 = "Email is not sent,please check Email address"
            Dim sb3 As New System.Text.StringBuilder()
            sb3.Append("<script type='text/javascript'>")
            sb3.Append("window.onload=function(){")
            sb3.Append("alert('")
            sb3.Append(message1)
            sb3.Append("');window.location='adminstratorManageRegistrations.aspx';};")
            sb3.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
        End If






    End Sub



End Class