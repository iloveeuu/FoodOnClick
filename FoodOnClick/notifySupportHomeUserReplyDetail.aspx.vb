Public Class notifySupportHomeUserReply
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsSupport As Support = New Support()
        UserID.Text = clsSupport.getSpecificSupport(Session("SupportID")).userID.ToString()
        SupportID.Text = Session("SupportID")
        Type.Text = clsSupport.getSpecificSupport(Session("SupportID")).type()
        Subject.Text = clsSupport.getSpecificSupport(Session("SupportID")).subject()
        Description.Text = clsSupport.getSpecificSupport(Session("SupportID")).description()
        DateSubmitted.Text = clsSupport.getSpecificSupport(Session("SupportID")).datesubmitted()
        PreviousConversation.Text = clsSupport.getSpecificSupport(Session("SupportID")).conversation()


    End Sub


    Protected Sub ReplyAnswer(ByVal sender As Object, ByVal e As System.EventArgs) Handles reply.Click
        Dim replyMessage As String
        Dim clsSupport As Support = New Support()
        Dim mail As New SMTP()

        replyMessage = clsSupport.getSpecificSupport(Session("SupportID")).conversation
        If replyMessage = "No Conversation Yet" Then
            replyMessage = ""
        End If
        replyMessage = replyMessage + vbNewLine + "+++" + CType(Today, String) + "   User:  " + AdminReplyBox.Text
        clsSupport.updateSupportConversation(replyMessage, Session("SupportID"))


        Dim ToAddressies As String() = {"fypfoodonclick@gmail.com"}
        Dim attachs() As String = {}
        Dim subject As String = "SupportID " + Session("SupportID") + "---Reply from User"
        Dim body As String = "Dear Admin   " + vbNewLine + AdminReplyBox.Text + vbNewLine
        Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)



        Response.Redirect("notifySupportHome.aspx")

    End Sub




End Class