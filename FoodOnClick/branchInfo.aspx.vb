Public Class branchInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If (Session("userid") Is Nothing Or Session("restaurantid") Is Nothing) Then
                Response.Redirect("login.aspx")
            End If
            Dim clsRestaurantInfo As Branch = New Branch(Convert.ToInt32(Session("userid")), Convert.ToInt32(Session("restaurantid")))
            Dim singleArrOfRestaurant As Restaurant = clsRestaurantInfo.RetrieveRestaurantInfoByRestaurantId()
            ddlCuisine.DataSource = clsRestaurantInfo.RetrieveAllCuisineType()
            ddlCuisine.DataBind()
            If (Session("branchid")) Is Nothing Then
                btnSubmit.Text = "Create branch"
                lbltitle.Text = "Create menu for " & singleArrOfRestaurant.restaurantName
            Else
                clsRestaurantInfo.branchId = Convert.ToInt32(Session("branchid"))
                Dim editInfo As Branch = clsRestaurantInfo.RetrieveAllBranchInfoByBranchId
                Dim pass As Encryption = New Encryption(editInfo.branchPassword)
                Dim decrypted As String = pass.Decrypt()
                txtEmail.Text = editInfo.branchEmail
                txtPassword.Text = decrypted
                txtpostalcode.Text = editInfo.branchPostalcode
                txtCity.Text = editInfo.branchCity
                txtaddress.Text = editInfo.branchAddress
                ddlStatus.SelectedValue = editInfo.branchStatus
                ddlHalal.SelectedValue = editInfo.halal
                ddlCuisine.SelectedValue = editInfo.branchCuisineId
                txtStart.Text = editInfo.branchStartTime
                txtEnd.Text = editInfo.branchEndTime
                btnSubmit.Text = "Update branch"
                lbltitle.Text = "Update branch for " & singleArrOfRestaurant.restaurantName
            End If
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        Dim pass As Encryption = New Encryption(txtPassword.Text)
        Dim encrypted As String = pass.Encrypt()
        If (btnSubmit.Text = "Create branch") Then
            Dim clsBranch As Branch = New Branch(txtEmail.Text.Trim(), encrypted, txtStart.Text.Trim(), txtEnd.Text.Trim(), ddlHalal.SelectedValue, Convert.ToInt32(Session("restaurantid")), txtaddress.Text.Trim(), txtpostalcode.Text.Trim(), ddlStatus.SelectedValue, txtCity.Text.Trim(), ddlCuisine.SelectedValue)
            Dim msg As String = clsBranch.CreateBranch()
            If (msg = "True") Then
                MsgBox("Successfully created branch", MsgBoxStyle.Information, "Success")
                Response.Redirect("branch.aspx")
            Else
                MsgBox(msg, MsgBoxStyle.Information, "Error")
            End If
        ElseIf (btnSubmit.Text = "Update branch") Then
            Dim clsBranch As Branch = New Branch(txtEmail.Text.Trim(), encrypted, txtStart.Text.Trim(), txtEnd.Text.Trim(), ddlHalal.SelectedValue, Convert.ToInt32(Session("restaurantid")), txtaddress.Text.Trim(), txtpostalcode.Text.Trim(), ddlStatus.SelectedValue, txtCity.Text.Trim(), ddlCuisine.SelectedValue, Convert.ToInt32(Session("branchid")))
            Dim msg As String = clsBranch.UpdateBranch()
            If (msg = "True") Then
                MsgBox("Successfully updated branch", MsgBoxStyle.Information, "Success")
                Response.Redirect("branch.aspx")
            Else
                MsgBox(msg, MsgBoxStyle.Information, "Error")
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("branch.aspx")
    End Sub


End Class