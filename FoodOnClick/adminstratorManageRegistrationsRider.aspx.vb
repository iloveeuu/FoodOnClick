Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException

Public Class AdminApprovalRejectRider
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsDocument As Document = New Document()
        rptUser.DataSource = clsDocument.GetRiderDocument()
        rptUser.DataBind()
        totalPendingCase.Text = clsDocument.GetCountRiderUser()


    End Sub


    Protected Sub rptUser_ItemDataBound(source As Object, e As RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then

            Dim ic As String = DataBinder.Eval(e.Item.DataItem, "riderNRIC").ToString()
            Dim lbic As HyperLink = TryCast(e.Item.FindControl("IC"), HyperLink)
            lbic.NavigateUrl = ic
            lbic.Text = "Rider NRIC "
            lbic.Target = "_blank"

        End If

    End Sub


    Protected Sub rptUser_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim myuser As New User()
        If (e.CommandName = "Approve") Then

            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String




            myuser.updateStatusDuringRegitration(e, "Approve", "rider")



            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is approved"
            Dim sb1 As New System.Text.StringBuilder()
            sb1.Append("<script type='text/javascript'>")
            sb1.Append("window.onload=function(){")
            sb1.Append("alert('")
            sb1.Append(message1)
            sb1.Append("');window.location='adminstratorManageRegistrationsRider.aspx';};")
            sb1.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())

            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))


            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Registration Request---Approved"
            Dim body As String = "Dear Rider , we are pleased to inform you that your registration request has been approved, we are looking forward to cooperate with you."
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='adminstratorManageRegistrationsRider.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='adminstratorManageRegistrationsRider.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If



        ElseIf (e.CommandName = "Reject") Then

            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String

            myuser.updateStatusDuringRegitration(e, "Reject", "rider")



            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is rejected"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type='text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message1)
            sb.Append("');window.location='adminstratorManageRegistrationsRider.aspx';};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())



            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))

            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Registration Request---Rejected"
            Dim body As String = "Dear Rider , we are sorry to inform you that your request is rejected"
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='adminstratorManageRegistrationsRider.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='adminstratorManageRegistrationsRider.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If
        End If



    End Sub


End Class