Public Class riderHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnNotifySupport_Click(sender As Object, e As EventArgs)
        Dim mail As New SMTP()
        Dim ToAddressies As String() = {"fypfoodonclick@gmail.com", "fypfoodonclick@gmail.com"}
        Dim attachs() As String = {}
        '"d:\temp_Excell226.xlsx", "d:\temp_Excell224.xlsx", "d:\temp_Excell225.xlsx"
        Dim subject As String = "Testing on local"
        Dim body As String = "From local pc hello"
        Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
        If result Then
            MsgBox("mails sended successfully", MsgBoxStyle.Information)
        Else
            MsgBox(mail.ErrorText, MsgBoxStyle.Critical)
        End If
    End Sub
End Class