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
                'txtReservationCapacity.Text = editInfo.branchReservationCapacity
                ddlReservation.SelectedValue = editInfo.branchReservation
                'ddlDrivethru.SelectedValue = editInfo.branchdrivethru
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
        Dim message As String = ""
        If (txtEmail.Text = "" Or txtPassword.Text = "" Or txtCity.Text = "" Or txtaddress.Text = "" Or txtpostalcode.Text = "" Or txtStart.Text = "" Or txtEnd.Text = "") Then
            message = "Please fill up the form properly"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Return
            'ElseIf (Convert.ToInt32(txtReservationCapacity.Text) < 0) Then
            '    message = "Please fill up the form properly"
            '    Dim sb As New System.Text.StringBuilder()
            '    sb.Append("<script type = 'text/javascript'>")
            '    sb.Append("window.onload=function(){")
            '    sb.Append("alert('")
            '    sb.Append(message)
            '    sb.Append("')};")
            '    sb.Append("</script>")
            '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            '    Return
        End If
        If (txtStart.Text > txtEnd.Text) Then
            message = "Start time cannot be later then end time"
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
        Dim pass As Encryption = New Encryption(txtPassword.Text)
        Dim encrypted As String = pass.Encrypt()

        If (btnSubmit.Text = "Create branch") Then
            Dim clsBranch As Branch = New Branch(ddlReservation.SelectedValue, txtEmail.Text.Trim(), encrypted, txtStart.Text.Trim(), txtEnd.Text.Trim(), ddlHalal.SelectedValue, Convert.ToInt32(Session("restaurantid")), txtaddress.Text.Trim(), txtpostalcode.Text.Trim(), ddlStatus.SelectedValue, txtCity.Text.Trim(), ddlCuisine.SelectedValue)
            Dim msg As String = clsBranch.CreateBranch()
            If (msg = "True") Then
                message = "Successfully created branch"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("');window.location='branch.aspx';};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                'Response.Redirect("branch.aspx")
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
        ElseIf (btnSubmit.Text = "Update branch") Then
            Dim clsBranch As Branch = New Branch(ddlReservation.SelectedValue, txtEmail.Text.Trim(), encrypted, txtStart.Text.Trim(), txtEnd.Text.Trim(), ddlHalal.SelectedValue, Convert.ToInt32(Session("restaurantid")), txtaddress.Text.Trim(), txtpostalcode.Text.Trim(), ddlStatus.SelectedValue, txtCity.Text.Trim(), ddlCuisine.SelectedValue, Convert.ToInt32(Session("branchid")))
            Dim msg As String = clsBranch.UpdateBranch()
            If (msg = "True") Then
                message = "Successfully updated branch"
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append(message)
                sb.Append("');window.location='branch.aspx';};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                'Response.Redirect("branch.aspx")
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
        Response.Redirect("branch.aspx")
    End Sub


End Class