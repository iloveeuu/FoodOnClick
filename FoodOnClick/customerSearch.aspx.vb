Public Class customerSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                Dim clsBranch As Branch = New Branch()
                ddlCategory.DataSource = clsBranch.RetrieveAllCuisineType()
                ddlCategory.DataBind()
            End If
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        '    - cuisine category (e.g. Thai / Western / Chinese / Vietnamese / Japanese / Korean / etc)
        ' - food type (e.g. main meal, side dish, dessert, beverage, etc)
        ' - price range (e.g. min - max)
        ' - menu from a single / pre-specified sub-set of restaurants (e.g. tick checkbox of which restaurants)
        ' - menu from a particular restaurant location / branch
        ' - partial / exact match of dish name (e.g. "wonton noodle", "thai fried rice", etc
        '- any other relevant criteria ...
        Dim dtSearch As DataTable

        Dim dblMinPrice As Double
        Dim dblMaxPrice As Double

        If txtMinPrice.Text.Trim() = "" Then
            dblMinPrice = 0
        Else
            dblMinPrice = txtMinPrice.Text.Trim()
        End If

        If txtMaxPrice.Text.Trim() = "" Then
            dblMaxPrice = 0
        Else
            dblMaxPrice = txtMaxPrice.Text.Trim()
        End If

        If Session("orderType") = "reservation" Then
            'ddlType.SelectedItem.ToString()
            Dim clsSearch As Search = New Search(txtLocation.Text.Trim(), txtRestaurant.Text.Trim(), ddlCategory.SelectedItem.ToString(), "",
                                           txtDishName.Text.Trim(), ddlHalal.SelectedItem.ToString(), dblMinPrice, dblMaxPrice)
            dtSearch = clsSearch.GetSearchReservation()

            gvSearch.DataSource = dtSearch
            gvSearch.DataBind()
        End If

    End Sub

    Protected Sub gvSearch_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim Index As Int32 = -1
        Dim gvRow As GridViewRow = Nothing
        Dim hRestaurantId As HiddenField = Nothing
        Dim hBranchId As HiddenField = Nothing
        Dim hUserId As HiddenField = Nothing
        Dim hEmail As HiddenField = Nothing
        Dim sRestaurantId As String = ""
        Dim sUserId As String = ""
        Dim sBranchId As String = ""
        Dim sEmail As String = ""

        Dim sRestName As String = ""
        Dim sHalal As String = ""
        Dim sAddress As String = ""
        Dim sDishName As String = ""

        If e.CommandName = "doReservation" Then

            Index = Convert.ToInt32(e.CommandArgument)

            hRestaurantId = gvSearch.Rows(Index).FindControl("hfRestId")
            sRestaurantId = hRestaurantId.Value

            'hUserId = gvSearch.Rows(Index).FindControl("hfUserId")
            'sUserId = hUserId.Value

            hBranchId = gvSearch.Rows(Index).FindControl("hfBranchId")
            sBranchId = hBranchId.Value

            hEmail = gvSearch.Rows(Index).FindControl("hfEmail")
            sEmail = hEmail.Value

            sRestName = gvSearch.Rows(Index).Cells(0).Text
            sHalal = gvSearch.Rows(Index).Cells(1).Text
            sAddress = gvSearch.Rows(Index).Cells(2).Text
            sDishName = gvSearch.Rows(Index).Cells(3).Text

            Session("userid") = Session("userid")
            Session("email") = sEmail
            Session("branchid") = sBranchId
            Session("restName") = sRestName
            Session("halal") = sHalal
            Session("address") = sAddress

            Response.Redirect("customerReservation.aspx")
        End If

    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub
End Class