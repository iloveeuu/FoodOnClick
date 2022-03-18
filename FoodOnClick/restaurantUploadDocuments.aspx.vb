Public Class restaurantUploadDocuments
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnUploadDocuments_Click(sender As Object, e As EventArgs) Handles btnUploadDocuments.Click

        Dim newRestaurant As Restaurant = New Restaurant()


        Dim userId = newRestaurant.getUserId()

        'If fuPhotoRestaurant.HasFile Then
        '    newRestaurant.uploadRestaurantDocuments(fuPhotoRestaurant.FileName, "restaurant image")
        '    fuPhotoRestaurant.SaveAs(Server.MapPath("~/NewFolder1/fuPhotoRestaurant.FileName"))
        'End If

        'If fuBusinessLicense.HasFile Then
        '    newRestaurant.uploadRestaurantDocuments(fuBusinessLicense.FileName, "company license")
        'End If

        'If fuHalalLicense.HasFile Then
        '    newRestaurant.uploadRestaurantDocuments(fuHalalLicense.FileName, "halal license")
        'End If


        If Not File1.PostedFile Is Nothing And
             File1.PostedFile.ContentLength > 0 And Not File2.PostedFile Is Nothing And
           File2.PostedFile.ContentLength > 0 And Not File3.PostedFile Is Nothing And
         File3.PostedFile.ContentLength > 0 And txtResName.Text.Trim().Length() > 0 And txtDescription.Text.Trim().Length() > 0 Then




            Dim fn1 As String = System.IO.Path.GetFileName(File1.
                                                          PostedFile.
                                                          FileName)

            Dim fn2 As String = System.IO.Path.GetFileName(File2.
                                                          PostedFile.
                                                          FileName)

            Dim fn3 As String = System.IO.Path.GetFileName(File3.
                                                          PostedFile.
                                                          FileName)

            Dim SaveLocation1 As String = Server.MapPath("~/uploadDocuments/") & userId & "_RestaurantLogo_" & fn1
            Dim SaveLocation2 As String = Server.MapPath("~/uploadDocuments/") & userId & "_Business_" & fn2
            Dim SaveLocation3 As String = Server.MapPath("~/uploadDocuments/") & userId & "_Halal_" & fn3

            Try
                File1.PostedFile.SaveAs(SaveLocation1)
                File2.PostedFile.SaveAs(SaveLocation2)
                File3.PostedFile.SaveAs(SaveLocation3)
                MsgBox("The files have been uploaded.", MsgBoxStyle.Information, "Success")
                newRestaurant.insertRestaurantDetails(txtResName.Text.Trim(), txtDescription.Text.Trim())
                newRestaurant.uploadRestaurantDocuments(SaveLocation1, "Restaurant Logo")
                newRestaurant.uploadRestaurantDocuments(SaveLocation2, "Business License")
                newRestaurant.uploadRestaurantDocuments(SaveLocation3, "Halal")
            Catch Exc As Exception
                MsgBox("Error: " & Exc.Message)
            End Try
            Response.Redirect("login.aspx")
        Else
            MsgBox("Please Upload All Required Files!", MsgBoxStyle.Critical)
        End If


        'If Not File2.PostedFile Is Nothing And
        '   File2.PostedFile.ContentLength > 0 Then

        '    Dim fn As String = System.IO.Path.GetFileName(File2.
        '                                                  PostedFile.
        '                                                  FileName)

        '    Dim SaveLocation As String = Server.MapPath("~/NewFolder1/") & userId & "_" & fn
        '    Try
        '        File2.PostedFile.SaveAs(SaveLocation)
        '        Response.Write("The file has been uploaded.")
        '    Catch Exc As Exception
        '        Response.Write("Error: " & Exc.Message)
        '    End Try
        'Else
        '    Response.Write("Please select a file to upload.")
        'End If


        'If Not File3.PostedFile Is Nothing And
        ' File3.PostedFile.ContentLength > 0 Then

        '    Dim fn As String = System.IO.Path.GetFileName(File3.
        '                                                  PostedFile.
        '                                                  FileName)

        '    Dim SaveLocation As String = Server.MapPath("~/NewFolder1/") & userId & "_" & fn
        '    Try
        '        File3.PostedFile.SaveAs(SaveLocation)
        '        Response.Write("The file has been uploaded.")
        '    Catch Exc As Exception
        '        Response.Write("Error: " & Exc.Message)
        '    End Try
        'Else
        '    Response.Write("Please select a file to upload.")
        'End If


    End Sub

    ''Private Sub Submit1_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick
    ''    If Not File1.PostedFile Is Nothing And
    ''      File1.PostedFile.ContentLength > 0 Then

    ''        Dim fn As String = System.IO.Path.GetFileName(File1.
    ''                                                      PostedFile.
    ''                                                      FileName)

    ''        Dim SaveLocation As String = Server.MapPath("~/NewFolder1/") & "userid_" & "Restaurant_" & fn
    ''        Try
    ''            File1.PostedFile.SaveAs(SaveLocation)
    ''            Response.Write("The file has been uploaded.")
    ''        Catch Exc As Exception
    ''            Response.Write("Error: " & Exc.Message)
    ''        End Try
    ''    Else
    ''        Response.Write("Please select a file to upload.")
    ''    End If

    'End Sub
End Class