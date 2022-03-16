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
            ddlDiscount.DataSource = ddlMenuInfo.RetrieveAllMenuDiscount()
            ddlDiscount.DataBind()
            ddlFoodType.DataSource = ddlMenuInfo.RetrieveAllMenuFoodType()
            ddlFoodType.DataBind()
            If (Session("menuid")) Is Nothing Then
                btnSubmit.Text = "Create menu"
                lbltitle.Text = "Create menu for " & singleArrOfRestaurant.restaurantName & " - " & singleArrOfRestaurant.branchCity
            Else
                'clsRestaurantInfo.branchId = Convert.ToInt32(Session("branchid"))
                'Dim editInfo As Branch = clsRestaurantInfo.RetrieveAllBranchInfoByBranchId
                'txtpostalcode.Text = editInfo.branchPostalcode
                'txtCity.Text = editInfo.branchCity
                'txtaddress.Text = editInfo.branchAddress
                'ddlStatus.SelectedValue = editInfo.branchStatus
                'ddlHalal.SelectedValue = editInfo.halal
                'ddlCuisine.SelectedValue = editInfo.branchCuisineId
                btnSubmit.Text = "Update menu"
                lbltitle.Text = "Update menu for " & singleArrOfRestaurant.restaurantName & " - " & singleArrOfRestaurant.branchCity
            End If
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
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
            Dim clsMenu As Menu = New Menu(txtName.Text.Trim(), txtDescription.Text.Trim(), txtCost.Text.Trim(), imageUrl, ddlStatus.SelectedValue, ddlDiscount.SelectedValue, Convert.ToInt32(Session("branchid")), ddlFoodType.SelectedValue, txtProtein.Text.Trim(), txtEnergy.Text.Trim(), txtCarbonhydrate.Text.Trim(), txtGlucose.Text.Trim(), txtFats.Text.Trim(), txtSodium.Text.Trim())
            Dim msg As String = clsMenu.CreateMenu()
            If (msg = "True") Then
                MsgBox("Successfully created menu", MsgBoxStyle.Information, "Success")
                Response.Redirect("branchMenu.aspx")
            Else
                MsgBox(msg, MsgBoxStyle.Information, "Error")
            End If
        ElseIf (btnSubmit.Text = "Update menu") Then
            'Dim clsBranch As Menu = New Menu()
            'Dim msg As String = clsBranch.UpdateBranch()
            'If (msg = "True") Then
            '    MsgBox("Successfully updated branch", MsgBoxStyle.Information, "Success")
            '    Response.Redirect("branch.aspx")
            'Else
            '    MsgBox(msg, MsgBoxStyle.Information, "Error")
            'End If
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("branchMenu.aspx")
    End Sub
End Class