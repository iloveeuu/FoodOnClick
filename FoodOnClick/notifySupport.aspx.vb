Imports System.Data.SqlClient

Public Class notifySupport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Session("userid") Is Nothing) Then
            Response.Redirect("login.aspx")
        End If
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
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            con.ConnectionString = connectionString
            cmd.Connection = con
            con.Open()
            Dim CurrentDateTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            cmd = New SqlCommand("INSERT INTO Support (subject, description, userid, datesubmitted, status)
                                 values ('" & ddlMsgType.SelectedValue & "','" & txtMsg.Text & "',
                                 '" & Session("userid") & "', '" & CurrentDateTime & "','" & "Pending" & "')", con)

            cmd.ExecuteNonQuery()
            con.Close()

            message = "Support form submitted!"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("');window.location='customerHome.aspx';};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            con.Open()
            Dim userid As Integer
            Dim supportid As Integer
            Dim userEmail As String
            Dim userType As String
            Dim cmd1 As New SqlCommand
            Dim cmd2 As New SqlCommand
            Dim cmd3 As New SqlCommand
            Dim cmd4 As New SqlCommand


            cmd1 = New SqlCommand("select MAX(Supportid) from support", con)
            supportid = cmd1.ExecuteScalar()
            cmd2 = New SqlCommand("select userid from support where supportid = '" & supportid & "'", con)
            userid = cmd2.ExecuteScalar()
            cmd3 = New SqlCommand("select email from useraccount where userid = '" & userid & "'", con)
            userEmail = cmd3.ExecuteScalar()
            cmd4 = New SqlCommand("select type from useraccount where userid = '" & userid & "'", con)
            userType = cmd4.ExecuteScalar()
            con.Close()

            Dim subject As String = "Support Ticket ID: " & supportid & " "

            Dim body As String = "<html> " &
                                "<body>" &
                                "<h3>Dear System Administrator</h3>" &
                                "<h1>New support issues alert</h1>" &
                                "<h3>User id : " & userid & " <br/> Email: " & userEmail & " </h3>" &
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

End Class