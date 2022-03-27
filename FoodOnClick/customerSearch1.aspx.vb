Public Class customerSearch1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                Dim clsBranch As Branch = New Branch()
                ddlCategory.DataSource = clsBranch.RetrieveAllCuisineType()
                ddlCategory.DataBind()

                Dim clsMenu As Menu = New Menu()
                ddlType.DataSource = clsMenu.RetrieveAllMenuFoodType()
                ddlType.DataBind()

                ddlCategory.Items.Insert(0, New ListItem("Please select", ""))
                ddlCategory.SelectedIndex = 0

                ddlHalal.Items.Insert(0, New ListItem("Please select", ""))
                ddlHalal.SelectedIndex = 0

                ddlType.Items.Insert(0, New ListItem("Please select", ""))
                ddlType.SelectedIndex = 0
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
            Dim clsMenu As Menu = New Menu()
            dtSearch = clsMenu.GetSearchReservation(txtLocation.Text.Trim(), txtRestaurant.Text.Trim(), ddlCategory.SelectedItem.ToString(), ddlType.SelectedItem.ToString(),
                                           txtDishName.Text.Trim(), ddlHalal.SelectedItem.ToString(), dblMinPrice, dblMaxPrice)

            rptCustomerSearch.DataSource = dtSearch
            rptCustomerSearch.DataBind()

            'Merge(gvSearch.Rows.Count())
        ElseIf Session("orderType") = "delivery" Then
            Dim clsMenu As Menu = New Menu()
            dtSearch = clsMenu.GetSearchDelivery(txtLocation.Text.Trim(), txtRestaurant.Text.Trim(), ddlCategory.SelectedItem.ToString(), ddlType.SelectedItem.ToString(),
                                               txtDishName.Text.Trim(), ddlHalal.SelectedItem.ToString(), dblMinPrice, dblMaxPrice)
            rptCustomerSearch.DataSource = dtSearch
            rptCustomerSearch.DataBind()
            'gvSearch.DataSource = dtSearch
            'gvSearch.DataBind()

            'Merge(gvSearch.Rows.Count())
        End If

    End Sub


    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerCart.aspx")
    End Sub

    Protected Sub rptCustomerSearch_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edit") Then
            System.Web.HttpContext.Current.Session("menuid") = e.CommandArgument.ToString()
            Response.Redirect("branchMenuInfo.aspx")
        End If
    End Sub

    Protected Sub rptCustomerSearch_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim imageUrl As String = DataBinder.Eval(e.Item.DataItem, "image")
        Dim img As Image = (TryCast(e.Item.FindControl("menuImage"), Image))
        Dim url As String = "~/images/menu/" & imageUrl
        img.Style.Add("vertical-align", "middle")
        img.ImageUrl = url
        Dim price As Decimal = DataBinder.Eval(e.Item.DataItem, "price")
        Dim lblPrice As Label = (TryCast(e.Item.FindControl("menuPrice"), Label))
        lblPrice.Text = "$" & price
        Dim dishname As String = DataBinder.Eval(e.Item.DataItem, "dishName")
        Dim lbldishName As Label = (TryCast(e.Item.FindControl("menuFoodtitle"), Label))
        lbldishName.Text = dishname
    End Sub
End Class