Public Class riderUploadDocuments
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnUploadDocuments_Click(sender As Object, e As EventArgs) Handles btnUploadDocuments.Click

        Dim newRider As Rider = New Rider()
        Dim Message As String

        Dim userId = newRider.getUserId()

        If Not File1.PostedFile Is Nothing And
             File1.PostedFile.ContentLength > 0 Then

            Dim fn1 As String = System.IO.Path.GetFileName(File1.
                                                          PostedFile.
                                                          FileName)
            Dim SaveLocation1 As String = Server.MapPath("./uploadDocuments/") & userId & "_NRIC_" & fn1
            Dim upload1 As String = "./uploadDocuments/" & userId & "_NRIC_" & fn1
            Try
                File1.PostedFile.SaveAs(SaveLocation1)
                Message = "The files have been uploaded."
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(Message)
                sb.Append("');window.location='login.aspx';};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                newRider.uploadRiderDocuments(upload1, "Rider NRIC")
            Catch Exc As Exception
            End Try
        End If
    End Sub


End Class