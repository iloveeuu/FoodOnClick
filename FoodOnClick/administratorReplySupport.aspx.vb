Public Class AdministratorReplySupport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsSupport As Support = New Support()
        rptReplyUser.DataSource = clsSupport.getSupport(UserType.SelectedValue, ReplyStatus.SelectedValue)
        rptReplyUser.DataBind()




    End Sub

    Protected Sub rptReplyUser_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

    End Sub



    Protected Sub UserTypes(sender As Object, e As EventArgs)

        Dim clsSupport As Support = New Support()
        rptReplyUser.DataSource = clsSupport.getSupport(UserType.SelectedValue, ReplyStatus.SelectedValue)
        rptReplyUser.DataBind()



    End Sub



    Protected Sub ReplyStatuses(sender As Object, e As EventArgs)
        Dim clsSupport As Support = New Support()
        rptReplyUser.DataSource = clsSupport.getSupport(UserType.SelectedValue, ReplyStatus.SelectedValue)
        rptReplyUser.DataBind()



    End Sub

    Protected Sub rptReplyUser_ItemCommand(source As Object, e As RepeaterCommandEventArgs)

        If e.CommandName = "Reply" Then

            Dim currentStatus As String
            Dim clsSupport As Support = New Support()
            currentStatus = clsSupport.getSpecificSupport(e.CommandArgument).status

            If currentStatus = "Solved" Then
                Dim message1 As String
                Dim sb1 As New System.Text.StringBuilder()
                message1 = " Sorry,the supportID is already solved"
                sb1.Append("<script type='text/javascript'>")
                sb1.Append("window.onload=function(){")
                sb1.Append("alert('")
                sb1.Append(message1)
                sb1.Append("');window.location='administratorReplySupportDetail.aspx';};")
                sb1.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())

            Else
                Session("SupportID") = e.CommandArgument
                Response.Redirect("administratorReplySupportDetail.aspx")
            End If


        End If

    End Sub




End Class