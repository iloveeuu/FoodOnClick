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

            gvSearch.DataSource = dtSearch
            gvSearch.DataBind()

        ElseIf Session("orderType") = "delivery" Then
            Dim clsMenu As Menu = New Menu()
            dtSearch = clsMenu.GetSearchDelivery(txtLocation.Text.Trim(), txtRestaurant.Text.Trim(), ddlCategory.SelectedItem.ToString(), ddlType.SelectedItem.ToString(),
                                               txtDishName.Text.Trim(), ddlHalal.SelectedItem.ToString(), dblMinPrice, dblMaxPrice)

            gvSearch.DataSource = dtSearch
            gvSearch.DataBind()
        End If

    End Sub

    Protected Sub gvSearch_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim Index As Int32 = -1
        Dim hRestaurantId As HiddenField = Nothing
        Dim hBranchId As HiddenField = Nothing
        Dim hUserId As HiddenField = Nothing
        Dim hEmail As HiddenField = Nothing
        Dim hTimeOpen As HiddenField = Nothing
        Dim hTImeClosed As HiddenField = Nothing
        Dim sRestaurantId As String = ""
        Dim sUserId As String = ""
        Dim sBranchId As String = ""
        Dim sEmail As String = ""

        Dim sRestName As String = ""
        Dim sHalal As String = ""
        Dim sAddress As String = ""
        Dim sDishName As String = ""
        Dim sTimeOpen As String = ""
        Dim sTimeClosed As String = ""

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

            hTimeOpen = gvSearch.Rows(Index).FindControl("hfTimeOpen")
            sTimeOpen = hTimeOpen.Value

            hTImeClosed = gvSearch.Rows(Index).FindControl("hfTimeClosed")
            sTimeClosed = hTImeClosed.Value

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
            Session("timeOpen") = sTimeOpen
            Session("timeClosed") = sTimeClosed

            Response.Redirect("customerReservation.aspx")
        ElseIf e.CommandName = "doDelivery" Then
            Index = Convert.ToInt32(e.CommandArgument)

            hRestaurantId = gvSearch.Rows(Index).FindControl("hfRestId")
            sRestaurantId = hRestaurantId.Value

            hBranchId = gvSearch.Rows(Index).FindControl("hfBranchId")
            sBranchId = hBranchId.Value

            hEmail = gvSearch.Rows(Index).FindControl("hfEmail")
            sEmail = hEmail.Value

            hTimeOpen = gvSearch.Rows(Index).FindControl("hfTimeOpen")
            sTimeOpen = hTimeOpen.Value

            hTImeClosed = gvSearch.Rows(Index).FindControl("hfTimeClosed")
            sTimeClosed = hTImeClosed.Value

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
            Session("timeOpen") = sTimeOpen
            Session("timeClosed") = sTimeClosed

            Response.Redirect("customerOrder.aspx")
        End If

    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub gvSearch_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Dim hBranchId As HiddenField = Nothing
        Dim hPrevBranchId As HiddenField = Nothing
        Dim sBranchID As String = ""
        Dim sPreviousBranchID As String = ""


        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    If (e.Row.RowIndex > 0) Then
        '        Dim previousRow As GridViewRow = gvSearch.Rows(e.Row.RowIndex - 1)
        '        If (e.Row.Cells(0).Text = previousRow.Cells(0).Text) Then
        '            If (previousRow.Cells(0).RowSpan = 0) Then
        '                previousRow.Cells(0).RowSpan += 3
        '                e.Row.Cells(0).Visible = False
        '            End If
        '        End If
        '    End If
        'End If

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'hide button
            If Session("orderType") = "reservation" Then
                Dim btnReserve As Button = e.Row.FindControl("btnReserve")
                btnReserve.Visible = True
                Dim btnDelivery As Button = e.Row.FindControl("btnDelivery")
                btnDelivery.Visible = False
            ElseIf Session("orderType") = "delivery" Then
                Dim btnReserve As Button = e.Row.FindControl("btnReserve")
                btnReserve.Visible = False
                Dim btnDelivery As Button = e.Row.FindControl("btnDelivery")
                btnDelivery.Visible = True
            End If

            'merge rows
            For i As Integer = gvSearch.Rows.Count - 1 To 1 Step -1
                Dim row As GridViewRow = gvSearch.Rows(i)
                Dim previousRow As GridViewRow = gvSearch.Rows(i - 1)

                'hBranchId = gvSearch.Rows(i).FindControl("hfBranchId")
                'sBranchID = hBranchId.Value.ToString()

                'hPrevBranchId = gvSearch.Rows(i - 1).FindControl("hfBranchId")
                'sPreviousBranchID = hPrevBranchId.Value.ToString()


                'merge only if branch id same
                'If sBranchID = sPreviousBranchID Then
                For j As Integer = 0 To row.Cells.Count - 1
                    If row.Cells(j).Text = previousRow.Cells(j).Text Then

                        If row.Cells(j).RowSpan = 0 Then
                            previousRow.Cells(j).RowSpan += 2
                        Else
                            previousRow.Cells(j).RowSpan = row.Cells(j).RowSpan + 1
                        End If
                        row.Cells(j).Visible = False
                    End If
                Next
                'End If
            Next
        End If

    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerCart.aspx")
    End Sub
End Class