Imports System.IO

Public Class branchMenuInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If (Session("userid") Is Nothing Or Session("restaurantid") Is Nothing Or Session("branchid") Is Nothing) Then
                Response.Redirect("login.aspx")
            End If
            Dim clsRestaurantBranchInfo As Branch = New Branch(Convert.ToInt32(Session("branchid")))
            Dim singleArrOfRestaurant As Branch = clsRestaurantBranchInfo.RetrieveRestaurantBranchInfoByBranchId()
            Dim ddlMenuInfo As Menu = New Menu()
            ddlStatus.DataSource = ddlMenuInfo.RetrieveAllMenuStatus()
            ddlStatus.DataBind()
            'ddlDiscount.DataSource = ddlMenuInfo.RetrieveAllMenuDiscount()
            'ddlDiscount.DataBind()
            ddlFoodType.DataSource = ddlMenuInfo.RetrieveAllMenuFoodType()
            ddlFoodType.DataBind()
            If (Session("menuid")) Is Nothing Then
                btnSubmit.Text = "Create menu"
                lbltitle.Text = "Create menu for " & singleArrOfRestaurant.restaurantName & " - " & singleArrOfRestaurant.branchCity
            Else
                ddlMenuInfo.menuId = Convert.ToInt32(Session("menuid"))
                Dim editInfo As Menu = ddlMenuInfo.RetrieveAllMenuInfoByMenuId()
                txtName.Text = editInfo.menuName
                txtDescription.Text = editInfo.menuDescription
                txtCost.Text = editInfo.menuCost
                ddlStatus.SelectedValue = editInfo.menuStatusId
                'ddlDiscount.SelectedValue = editInfo.menuDiscountId
                ddlFoodType.SelectedValue = editInfo.menuFoodTypeId
                txtProtein.Text = editInfo.menuProtein
                txtEnergy.Text = editInfo.menuEnergy
                txtCarbonhydrate.Text = editInfo.menuCarbonhydrate
                txtGlucose.Text = editInfo.menuGlucose
                txtFats.Text = editInfo.menuFats
                txtSodium.Text = editInfo.menuSodium
                imgurl.Value = editInfo.menuImage
                btnSubmit.Text = "Update menu"
                lbltitle.Text = "Update menu for " & singleArrOfRestaurant.restaurantName & " - " & singleArrOfRestaurant.branchCity
            End If
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim message As String = ""
        If (txtName.Text = "" Or txtDescription.Text = "" Or txtCost.Text = "" Or txtProtein.Text = "" Or txtEnergy.Text = "" Or txtCarbonhydrate.Text = "" Or txtGlucose.Text = "" Or txtFats.Text = "" Or txtSodium.Text = "") Then
            message = "Please fill up the form"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Return
        End If

        If (btnSubmit.Text = "Create menu") Then
            Dim imageUrl As String = ""
            If (FileUpload.HasFile) Then
                Dim ID As String = Guid.NewGuid().ToString("N").Substring(0, 10)
                Dim testImageName As Menu = New Menu(ID)
                While (Not testImageName.CheckImageNameIsUnique())
                    ID = Guid.NewGuid().ToString("N").Substring(0, 10)
                    testImageName = New Menu(ID)
                End While
                FileUpload.SaveAs(Server.MapPath("images//menu//" + ID + Path.GetExtension(FileUpload.FileName)))
                imageUrl = ID + Path.GetExtension(FileUpload.FileName)
            End If
            Dim clsMenu As Menu = New Menu(txtName.Text.Trim(), txtDescription.Text.Trim(), txtCost.Text.Trim(), imageUrl, ddlStatus.SelectedValue, 1, Convert.ToInt32(Session("branchid")), ddlFoodType.SelectedValue, txtProtein.Text.Trim(), txtEnergy.Text.Trim(), txtCarbonhydrate.Text.Trim(), txtGlucose.Text.Trim(), txtFats.Text.Trim(), txtSodium.Text.Trim())
            Dim msg As String = clsMenu.CreateMenu()
            If (msg = "True") Then
                message = "Successfully created menu"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("');window.location='branchMenu.aspx';};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                'Response.Redirect("branchMenu.aspx")
            Else
                message = msg
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            End If

        ElseIf (btnSubmit.Text = "Update menu") Then
            Dim imageUrl As String = ""
            If (FileUpload.HasFile) Then
                Dim ID As String = Guid.NewGuid().ToString("N").Substring(0, 10)
                Dim testImageName As Menu = New Menu(ID)
                While (Not testImageName.CheckImageNameIsUnique())
                    ID = Guid.NewGuid().ToString("N").Substring(0, 10)
                    testImageName = New Menu(ID)
                End While
                FileUpload.SaveAs(Server.MapPath("images//menu//" + ID + Path.GetExtension(FileUpload.FileName)))
                imageUrl = ID + Path.GetExtension(FileUpload.FileName)
            Else
                imageUrl = imgurl.Value
            End If
            Dim clsMenu As Menu = New Menu(txtName.Text.Trim(), txtDescription.Text.Trim(), txtCost.Text.Trim(), imageUrl, ddlStatus.SelectedValue, 1, Convert.ToInt32(Session("branchid")), ddlFoodType.SelectedValue, txtProtein.Text.Trim(), txtEnergy.Text.Trim(), txtCarbonhydrate.Text.Trim(), txtGlucose.Text.Trim(), txtFats.Text.Trim(), txtSodium.Text.Trim(), Convert.ToInt32(Session("menuid")))
            Dim msg As String = clsMenu.UpdateMenu()
            If (msg = "True") Then
                message = "Successfully updated menu"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("');window.location='branchMenu.aspx';};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                message = msg
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("branchMenu.aspx")
    End Sub

    Protected Sub btnCancel_Click1(sender As Object, e As EventArgs)

    End Sub
End Class