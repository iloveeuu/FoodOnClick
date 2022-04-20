Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException


Public Class administratorUserManagementRider
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsRider As Rider = New Rider()
        rptAdminRider.DataSource = clsRider.GetRiderDetailByAdmin()
        rptAdminRider.DataBind()
    End Sub



    Protected Sub rptAdminRider_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

    End Sub

    Protected Sub rptAdminRider_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim myuser As User = New User()
        If (e.CommandName = "Activate") Then

            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String


            myuser.updateStatusAfterApproval(e, "Activate")


            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is activated"
            Dim sb1 As New System.Text.StringBuilder()
            sb1.Append("<script type='text/javascript'>")
            sb1.Append("window.onload=function(){")
            sb1.Append("alert('")
            sb1.Append(message1)
            sb1.Append("');window.location='administratorUserManagementRider.aspx';};")
            sb1.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())

            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))


            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Rider account ----- Activate"
            Dim body As String = "Dear Rider , we are pleased to inform you that your account is activated."
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='administratorUserManagementRider.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='administratorUserManagementRider.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If


        ElseIf (e.CommandName = "Deactivate") Then

            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String


            myuser.updateStatusAfterApproval(e, "Deactivate")

            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is deactivated"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type='text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message1)
            sb.Append("');window.location='administratorUserManagementRider.aspx';};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())



            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))

            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Rider account ----- Deactivate"
            Dim body As String = "Dear Rider  , we are sorry to inform you that your account is deactivated"
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='administratorUserManagementRider.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='administratorUserManagementRider.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If

        ElseIf (e.CommandName = "Block") Then

            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String


            myuser.updateStatusAfterApproval(e, "Block")

            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is blocked"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type='text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message1)
            sb.Append("');window.location='administratorUserManagementRider.aspx';};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())



            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))

            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Rider account ----- Blocked"
            Dim body As String = "Dear Rider  , we are sorry to inform you that your account is blocked"
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='administratorUserManagementRider.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='administratorUserManagementRider.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If


        End If
    End Sub

End Class