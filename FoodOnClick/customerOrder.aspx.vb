Public Class customerOrder
    Inherits System.Web.UI.Page
    Private boolAdded As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                lblRestName.Text = Session("restName")
                lblHalal.Text = Session("halal")
                lblAddress.Text = Session("address")
            End If

            Session("compare_menuid") = ""

            Dim dtSearch As DataTable

            Dim clsMenu As Menu = New Menu()
            ddlType.DataSource = clsMenu.RetrieveAllMenuFoodType()
            ddlType.DataBind()

            Dim clsSearch As Menu = New Menu()
            dtSearch = clsSearch.GetSearchMenu(Session("branchid"), "", "", 0, 0)

            rptMenu.DataSource = dtSearch
            rptMenu.DataBind()

            ddlType.Items.Insert(0, New ListItem("Please select", ""))
            ddlType.SelectedIndex = 0

            If ViewState("boolAdded") Is Nothing Or ViewState("boolAdded") = False Then
                ViewState("boolAdded") = False
            Else
                ViewState("boolAdded") = True
            End If
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
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

        Dim clsMenu As Menu = New Menu()
        dtSearch = clsMenu.GetSearchMenu(Session("branchid"), ddlType.SelectedItem.ToString(),
                                           txtDishName.Text.Trim(), dblMinPrice, dblMaxPrice)

        rptMenu.DataSource = dtSearch
        rptMenu.DataBind()
    End Sub

    'Protected Sub gvMenu_RowCommand(sender As Object, e As GridViewCommandEventArgs)
    '    Dim boolDataExist = False
    '    Dim Index As Int32 = -1

    '    Dim iMenuId As Integer = 0
    '    Dim hfMenuId As HiddenField = Nothing
    '    Dim hfBranchId As HiddenField = Nothing
    '    Dim iBranchId As Integer = 0
    '    Dim sMenu As String = ""
    '    Dim txtQty As TextBox = Nothing
    '    Dim dbPrice As Double = 0
    '    Dim iQty As Integer = 0

    '    Dim dbTotPrice As Double = 0

    '    If e.CommandName = "doAddCart" Then

    '        Index = Convert.ToInt32(e.CommandArgument)

    '        sMenu = gvMenu.Rows(Index).Cells(0).Text
    '        dbPrice = Convert.ToDouble(gvMenu.Rows(Index).Cells(1).Text)
    '        txtQty = gvMenu.Rows(Index).FindControl("txtQty")

    '        hfMenuId = gvMenu.Rows(Index).FindControl("hfMenuId")
    '        iMenuId = hfMenuId.Value

    '        hfBranchId = gvMenu.Rows(Index).FindControl("hfBranchId")
    '        iBranchId = hfBranchId.Value

    '        If txtQty.Text = "" Then
    '            errorText.Attributes("style") = "display: block; text-align: center; color:red;"
    '        Else
    '            errorText.Attributes("style") = "display: none;"

    '            iQty = txtQty.Text

    '            Dim scd As ShoppingCartDetail = New ShoppingCartDetail()
    '            scd.userID = Session("userid")
    '            scd.branchId = iBranchId

    '            Dim iCartID As Integer = scd.CheckRestaurantInCart()

    '            If iCartID = 0 Then
    '                scd.totalprices = 0
    '                scd.type = "Delivery"
    '                iCartID = scd.InsertShoppinngCart()
    '                ViewState("boolAdded") = True
    '            End If

    '            scd.menuid = iMenuId

    '            Dim iMenuInsrted As Integer = scd.CheckMenuInsertedInCart()

    '            If iMenuInsrted = 0 Then
    '                scd.quantity = iQty
    '                scd.price = dbPrice
    '                scd.cartID = iCartID
    '                scd.InsertShoppingCartDetail()
    '            Else
    '                scd.menuid = iMenuId
    '                scd.quantity = iQty
    '                scd.price = dbPrice
    '                scd.cartID = iMenuInsrted
    '                scd.UpdateShoppingCart()
    '            End If

    '            Dim sb As New System.Text.StringBuilder()
    '            sb.Append("<script type = 'text/javascript'>")
    '            sb.Append("window.onload=function(){")
    '            sb.Append("alert('")
    '            sb.Append("Added to Shopping Cart")
    '            sb.Append("')};")
    '            sb.Append("</script>")
    '            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    '        End If
    '    End If
    'End Sub

    Protected Sub btnShoppingCart_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Response.Redirect("customerCart.aspx")
    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        ViewState("boolAdded") = False
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        ViewState("boolAdded") = False
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Session("orderType") = "delivery"
        Response.Redirect("customerSearch.aspx")
    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        my_popup.Style.Add("display", "none")
        popup.Style.Add("display", "none")

        my_popup2.Style.Add("display", "none")
        compare_popup.Style.Add("display", "none")
    End Sub

    Protected Sub rptMenu_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim iMenuId As Integer = 0

        Dim lblDishName As Label = Nothing
        Dim sMenu As String = ""

        Dim lblType As Label = Nothing
        Dim sType As String = ""

        Dim lblPrice As Label = Nothing
        Dim sPrice As String = ""
        Dim dbPrice As Double = 0

        Dim txtQty As TextBox = Nothing
        Dim iQty As Integer = 0

        Dim hfBranchId As HiddenField = Nothing
        Dim iBranchId As Integer = 0

        If (e.CommandName = "viewDetail") Then
            Dim dtMenu As DataTable
            Dim clsSearch As Menu = New Menu()
            iMenuId = Convert.ToInt32(e.CommandArgument)

            dtMenu = clsSearch.GetSearchMenu(Session("branchid"), "", "", 0, 0, iMenuId)

            lblPopUpDishName.Text = dtMenu.Rows(0)(2).ToString()

            lblPopUpFoodType.Text = dtMenu.Rows(0)(6).ToString()

            lblPopUpPrice.Text = "$ " + dtMenu.Rows(0)(3).ToString()

            lblPopUpDesc.Text = dtMenu.Rows(0)(4).ToString()

            my_popup.Style.Add("display", "block")
            popup.Style.Add("display", "block")

        ElseIf e.CommandName = "doAddCart" Then
            iMenuId = Convert.ToInt32(e.CommandArgument)

            hfBranchId = e.Item.FindControl("hfBranchId")
            iBranchId = hfBranchId.Value

            lblDishName = e.Item.FindControl("lblDishName")
            sMenu = lblDishName.Text

            txtQty = e.Item.FindControl("txtQty")

            If txtQty.Text <> "" Then
                iQty = txtQty.Text
            End If

            If txtQty.Text = "" Or iQty < 1 Then
                errorText.Attributes("style") = "display: block; text-align: center; color:red;"
            Else
                lblPrice = e.Item.FindControl("lblPrice")
                sPrice = lblPrice.Text
                sPrice = sPrice.Replace("$ ", "")

                dbPrice = Convert.ToDouble(sPrice)

                errorText.Attributes("style") = "display: none;"

                Dim scd As ShoppingCartDetail = New ShoppingCartDetail()
                scd.userID = Session("userid")
                scd.branchId = iBranchId

                Dim iCartID As Integer = scd.CheckRestaurantInCart()

                If iCartID = 0 Then
                    scd.totalprices = 0
                    scd.type = "Delivery"
                    iCartID = scd.InsertShoppinngCart()
                    ViewState("boolAdded") = True
                End If

                scd.menuid = iMenuId

                Dim iMenuInsrted As Integer = scd.CheckMenuInsertedInCart()

                If iMenuInsrted = 0 Then
                    scd.quantity = iQty
                    scd.price = dbPrice
                    scd.cartID = iCartID
                    scd.InsertShoppingCartDetail()
                Else
                    scd.menuid = iMenuId
                    scd.quantity = iQty
                    scd.price = dbPrice
                    scd.cartID = iMenuInsrted
                    scd.UpdateShoppingCart()
                End If

                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append("Added to Shopping Cart")
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            End If
        ElseIf e.CommandName = "doAddCompare" Then

            iMenuId = Convert.ToInt32(e.CommandArgument)

            Dim strSession() As String = Session("compare_menuid").ToString().Split(",")

            For Each s As String In strSession
                If s = iMenuId.ToString() Then
                    Dim sb1 As New System.Text.StringBuilder()
                    sb1.Append("<script type = 'text/javascript'>")
                    sb1.Append("window.onload=function(){")
                    sb1.Append("alert('")
                    sb1.Append("Menu Already Added for Compare")
                    sb1.Append("')};")
                    sb1.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())
                    Exit Sub
                End If
            Next


            Session("compare_menuid") = Session("compare_menuid") + iMenuId.ToString + ","

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Added for Compare")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        End If
    End Sub

    Protected Sub gvCompare_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim boolDataExist = False
        Dim Index As Int32 = -1

        Dim iMenuId As Integer = 0
        Dim hfMenuId As HiddenField = Nothing
        Dim hfBranchId As HiddenField = Nothing
        Dim iBranchId As Integer = 0
        Dim sMenu As String = ""

        Dim txtQty As TextBox = Nothing
        Dim iQty As Integer = 0

        Dim lblPrice As Label = Nothing
        Dim sPrice As String = ""
        Dim dbPrice As Double = 0

        Dim dbTotPrice As Double = 0

        If e.CommandName = "doAddCart" Then

            Index = Convert.ToInt32(e.CommandArgument)

            sMenu = gvCompare.Rows(Index).Cells(0).Text

            lblPrice = gvCompare.Rows(Index).FindControl("lblPrice")
            sPrice = lblPrice.Text
            sPrice = sPrice.Replace("$ ", "")

            dbPrice = Convert.ToDouble(sPrice)

            txtQty = gvCompare.Rows(Index).FindControl("txtQty")

            hfMenuId = gvCompare.Rows(Index).FindControl("hfMenuId")
            iMenuId = hfMenuId.Value

            hfBranchId = gvCompare.Rows(Index).FindControl("hfBranchId")
            iBranchId = hfBranchId.Value

            If txtQty.Text <> "" Then
                iQty = txtQty.Text
            End If

            If txtQty.Text = "" Or iQty < 1 Then
                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append("Quantity must more than 0")
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                errorText.Attributes("style") = "display: none;"

                iQty = txtQty.Text

                Dim scd As ShoppingCartDetail = New ShoppingCartDetail()
                scd.userID = Session("userid")
                scd.branchId = iBranchId

                Dim iCartID As Integer = scd.CheckRestaurantInCart()

                If iCartID = 0 Then
                    scd.totalprices = 0
                    scd.type = "Delivery"
                    iCartID = scd.InsertShoppinngCart()
                    ViewState("boolAdded") = True
                End If

                scd.menuid = iMenuId

                Dim iMenuInsrted As Integer = scd.CheckMenuInsertedInCart()

                If iMenuInsrted = 0 Then
                    scd.quantity = iQty
                    scd.price = dbPrice
                    scd.cartID = iCartID
                    scd.InsertShoppingCartDetail()
                Else
                    scd.menuid = iMenuId
                    scd.quantity = iQty
                    scd.price = dbPrice
                    scd.cartID = iMenuInsrted
                    scd.UpdateShoppingCart()
                End If

                Dim sb As New System.Text.StringBuilder()
                sb.Append("<script type = 'text/javascript'>")
                sb.Append("window.onload=function(){")
                sb.Append("alert('")
                sb.Append("Added to Shopping Cart")
                sb.Append("')};")
                sb.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            End If

        ElseIf e.CommandName = "doRemove" Then
            Dim compare_menuid As String
            Dim dtCompare As DataTable

            Index = Convert.ToInt32(e.CommandArgument)

            hfMenuId = gvCompare.Rows(Index).FindControl("hfMenuId")
            iMenuId = hfMenuId.Value

            Session("compare_menuid") = Session("compare_menuid").ToString().Replace(iMenuId.ToString() + ",", "")

            compare_menuid = Session("compare_menuid")

            compare_menuid = compare_menuid.TrimEnd(CChar(","))

            Dim clsMenu As Menu = New Menu()
            dtCompare = clsMenu.GetMenuByIdList(compare_menuid)

            gvCompare.DataSource = dtCompare
            gvCompare.DataBind()
        End If
    End Sub

    Protected Sub btnCompare_Click(sender As Object, e As EventArgs)

        Dim compare_menuid As String
        Dim dtCompare As DataTable

        If Session("compare_menuid") Is Nothing Then
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("No Comparison Added")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Else
            compare_menuid = Session("compare_menuid")

            compare_menuid = compare_menuid.TrimEnd(CChar(","))

            Dim clsMenu As Menu = New Menu()
            dtCompare = clsMenu.GetMenuByIdList(compare_menuid)

            gvCompare.DataSource = dtCompare
            gvCompare.DataBind()


            my_popup2.Style.Add("display", "block")

            'compare_popup.Style.Add("height", Convert.ToString((gvCompare.Height.Value * 3)) + "px;")

            'Dim height As String = Convert.ToString((gvCompare.Height.Value * gvCompare.Rows.Count * 8)) + "px;"
            'compare_popup.Style.Add("height", height)
            'compare_popup.Style.Add("height", "100%")

            compare_popup.Style.Add("display", "block")
        End If
    End Sub
End Class