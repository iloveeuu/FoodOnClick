Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException

Public Class administratorUserManagementCustomer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsCustomer As Customer = New Customer()
        rptAdminCustomer.DataSource = clsCustomer.GetCustomerDetailByAdmin()
        rptAdminCustomer.DataBind()

    End Sub


    Protected Sub rptAdminCustomer_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

    End Sub



    Protected Sub rptAdminCustomer_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Activate") Then
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String

            con.ConnectionString = "workstation id=foodonclick2.mssql.somee.com;packet size=4096;user id=fypfoodonclick_SQLLogin_1;pwd=eeq5c9sxpx;data source=foodonclick2.mssql.somee.com;persist security info=False;initial catalog=foodonclick2"
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.statusAfterApproved='AVAILABLE' WHERE userid=@userID;"
            cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(e.CommandArgument))
            cmd.ExecuteNonQuery()

            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is activated"
            Dim sb1 As New System.Text.StringBuilder()
            sb1.Append("<script type='text/javascript'>")
            sb1.Append("window.onload=function(){")
            sb1.Append("alert('")
            sb1.Append(message1)
            sb1.Append("');window.location='administratorUserManagementCustomer.aspx';};")
            sb1.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())

            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))


            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Customer account ----- Activate"
            Dim body As String = "Dear Customer , we are pleased to inform you that your account is activated."
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='administratorUserManagementCustomer.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='administratorUserManagementCustomer.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If





            con.Close()
        ElseIf (e.CommandName = "Deactivate") Then
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String


            con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.statusAfterApproved='UNAVAILABLE' WHERE userid=@userID;"
            cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(e.CommandArgument))
            cmd.ExecuteNonQuery()


            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is deactivated"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type='text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message1)
            sb.Append("');window.location='administratorUserManagementCustomer.aspx';};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            con.Close()

            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))

            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Customer account ----- Deactivate"
            Dim body As String = "Dear Customer  , we are sorry to inform you that your account is deactivated"
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='administratorUserManagementCustomer.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='administratorUserManagementCustomer.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If

        ElseIf (e.CommandName = "Block") Then
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String


            con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.statusAfterApproved='BLOCKED' WHERE userid=@userID;"
            cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(e.CommandArgument))
            cmd.ExecuteNonQuery()


            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is blocked"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type='text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message1)
            sb.Append("');window.location='administratorUserManagementCustomer.aspx';};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            con.Close()

            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))

            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Customer account ----- Blocked"
            Dim body As String = "Dear Customer  , we are sorry to inform you that your account is blocked"
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='administratorUserManagementCustomer.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='administratorUserManagementCustomer.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If


        End If


    End Sub



End Class