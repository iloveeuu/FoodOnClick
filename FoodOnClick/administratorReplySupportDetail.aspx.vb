Public Class administratorReplySupportDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'show specific one support information
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
        replyMessage = replyMessage + vbNewLine + "+++" + CType(Today, String) + "   Admin:  " + AdminReplyBox.Text
        clsSupport.updateSupportConversation(replyMessage, Session("SupportID"))


        Dim ToAddressies As String() = {clsSupport.getSpecificSupport(Session("SupportID")).email()}
        Dim attachs() As String = {}
        Dim subject As String = "SupportID " + Session("SupportID") + "---Reply from Admin"
        Dim body As String = "Dear User   " + vbNewLine + AdminReplyBox.Text + vbNewLine + " please check details in your user Support interface  and close support if it is solved"
        Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)



        Response.Redirect("administratorReplySupport.aspx")

    End Sub



End Class