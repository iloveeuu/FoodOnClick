Imports System.Data.SqlClient

Public Class notifySupport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim message As String

        If (txtMsg.Text.Trim() = "") Then
            message = "Please fill in the message"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Else

            Dim clsSupport As Support = New Support()
            clsSupport.insertIntoNewRecord(ddlMsgType.SelectedValue, txtMsg.Text, Session("userid"))
            If Session("type") = "Rider" Then
                message = "Support form submitted!"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("');window.location='riderHome.aspx';};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                message = "Support form submitted!"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("');window.location='customerHome.aspx';};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            End If



            Dim clsSupport2 As Support = New Support()




            Dim subject As String = "Support Ticket ID: " & clsSupport2.getMaxSupport().supportid & " "

            Dim body As String = "<html> " &
                                "<body>" &
                                "<h3>Dear System Administrator</h3>" &
                                "<h1>New support issues alert</h1>" &
                                "<h3>User id : " & clsSupport2.getMaxSupport().userid & " <br/> Email: " & clsSupport2.getMaxSupport().email & " </h3>" &
                                "<h3>Subject : " & ddlMsgType.Text & "  <br/> " & "Description : " & txtMsg.Text & "</h3>" &
                                "<br/>" &
                                "<h3>Regards,</h3>" &
                                "<h3>Food on Click</h3>" &
                                "</body>" &
                                "</html>"

            Dim smtp As SMTP = New SMTP()
            Dim email() As String = {"will.ariez@gmail.com"}



            smtp.SendMail(email, subject, body, Nothing, True)

        End If

    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("notifySupportHome.aspx")
    End Sub

End Class