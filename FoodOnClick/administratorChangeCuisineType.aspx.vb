Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException

Public Class administratorChangeCuisineType_aspxt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim cuisineTypeData As CuisineType = New CuisineType()
        rptCuisine.DataSource = cuisineTypeData.getCuisineType()
        rptCuisine.DataBind()



    End Sub


    Protected Sub rptCuisine_ItemDataBound(source As Object, e As RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim lcuisine_Typeid As String = DataBinder.Eval(e.Item.DataItem, "cuisineTypeID").ToString()
            Dim llcuisine_Typeid As Label = CType(e.Item.FindControl("cuisineID"), Label)
            llcuisine_Typeid.Text = lcuisine_Typeid


            Dim lfoodType As String = DataBinder.Eval(e.Item.DataItem, "foodType").ToString()
            Dim llfoodType As Label = CType(e.Item.FindControl("foodType"), Label)
            llfoodType.Text = lfoodType

            Dim lstatus As String = DataBinder.Eval(e.Item.DataItem, "status").ToString()
            Dim llstatus As Label = CType(e.Item.FindControl("status"), Label)
            llstatus.Text = lstatus



        End If




    End Sub

    Protected Sub rptCuisine_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim cuisintetypesample As CuisineType = New CuisineType()
        If (e.CommandName = "Add") Then
            Dim toAddCuisineType As String
            Dim lltoAddCuisineType = CType(e.Item.FindControl("addCuisineName"), TextBox)
            toAddCuisineType = lltoAddCuisineType.Text
            If (toAddCuisineType = "" Or toAddCuisineType = "Please input Cuisine Type") Then
                Dim message1 As String = "You have not enter correct cuisinetypeID "
                Dim sb1 As New System.Text.StringBuilder()
                sb1.Append("<script type='text/javascript'>")
                sb1.Append("window.onload=function(){")
                sb1.Append("alert('")
                sb1.Append(message1)
                sb1.Append("');window.location='administratorChangeCuisineType.aspx';};")
                sb1.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())
            Else
                cuisintetypesample.AddCuisineType(toAddCuisineType)
                Response.Redirect("administratorChangeCuisineType.aspx")
            End If

        ElseIf (e.CommandName = "Enable") Then
            Dim toinputID As Int32
            Dim lltoinputID = CType(e.Item.FindControl("cuisineIDForEnableDisable"), TextBox)
            If (lltoinputID.Text = "" Or lltoinputID.Text = "Please input Cuisinetype ID for enable or disable") Then
                Dim message1 As String = "You have not enter correct cuisine type "
                Dim sb1 As New System.Text.StringBuilder()
                sb1.Append("<script type='text/javascript'>")
                sb1.Append("window.onload=function(){")
                sb1.Append("alert('")
                sb1.Append(message1)
                sb1.Append("');window.location='administratorChangeCuisineType.aspx';};")
                sb1.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())
            Else
                toinputID = Convert.ToInt32(lltoinputID.Text)
                cuisintetypesample.EnableCuisineType(toinputID)
                Response.Redirect("administratorChangeCuisineType.aspx")
            End If


        ElseIf (e.CommandName = "Disable") Then
            Dim toinputID As Int32
            Dim lltoinputID = CType(e.Item.FindControl("cuisineIDForEnableDisable"), TextBox)
            If (lltoinputID.Text = "" Or lltoinputID.Text = "Please input Cuisinetype ID for enable or disable") Then
                Dim message1 As String = "You have not enter correct cuisinetypeID "
                Dim sb1 As New System.Text.StringBuilder()
                sb1.Append("<script type='text/javascript'>")
                sb1.Append("window.onload=function(){")
                sb1.Append("alert('")
                sb1.Append(message1)
                sb1.Append("');window.location='administratorChangeCuisineType.aspx';};")
                sb1.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())
            Else
                toinputID = Convert.ToInt32(lltoinputID.Text)
                cuisintetypesample.DisableCuisineType(toinputID)
                Response.Redirect("administratorChangeCuisineType.aspx")
            End If

        End If


    End Sub


End Class