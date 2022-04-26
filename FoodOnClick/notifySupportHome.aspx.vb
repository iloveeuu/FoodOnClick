Public Class notifySupportHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsSupport As Support = New Support()
        rptUserSupportSummary.DataSource = clsSupport.getSupportFromUser(Session("userid"))
        rptUserSupportSummary.DataBind()



    End Sub


    Protected Sub rptUserSupport_ItemBound(sender As Object, e As EventArgs)




    End Sub

    Protected Sub rptReplyUser_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Session("supportID") = e.CommandArgument
        If e.CommandName = "Reply" Then

            Dim clsSupport As Support = New Support()
            Dim currentStatus As String = clsSupport.getSpecificSupport(e.CommandArgument).status

            If currentStatus = "Solved" Then
                Dim message1 As String
                Dim sb1 As New System.Text.StringBuilder()
                message1 = " Sorry,the supportID is already solved"
                sb1.Append("<script type='text/javascript'>")
                sb1.Append("window.onload=function(){")
                sb1.Append("alert('")
                sb1.Append(message1)
                sb1.Append("');window.location='notifySupportHome.aspx';};")
                sb1.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())
            Else
                Response.Redirect("notifySupportHomeUserReplyDetail.aspx")

            End If

        ElseIf e.CommandName = "Close" Then
            Dim clsSupport As Support = New Support()
            clsSupport.updateSupportStatusSolved(e.CommandArgument, CType(Today, String))
            Dim mail As New SMTP()
            Dim ToAddressies As String() = {"fypfoodonclick@gmail.com"}
            Dim attachs() As String = {}
            Dim subject As String = "SupportID " + Session("SupportID") + "  is solved "
            Dim body As String = "Dear Admin  Please be inforomed that the support is solved"
            Dim result As Boolean = Mail.SendMail(ToAddressies, subject, body, attachs)


            Response.Redirect("notifySupportHome.aspx")
        End If
    End Sub

    Protected Sub submitNewSupportl(ByVal sender As Object, ByVal e As System.EventArgs) Handles submitNewSupport.Click
        Response.Redirect("notifySupportNew.aspx")

    End Sub

End Class