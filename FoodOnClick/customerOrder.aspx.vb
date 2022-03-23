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

            Dim dtSearch As DataTable

            Dim clsMenu As Menu = New Menu()
            ddlType.DataSource = clsMenu.RetrieveAllMenuFoodType()
            ddlType.DataBind()

            Dim clsSearch As Menu = New Menu()
            dtSearch = clsSearch.GetSearchMenu(Session("branchid"), "", "", 0, 0)

            gvMenu.DataSource = dtSearch
            gvMenu.DataBind()

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

        gvMenu.DataSource = dtSearch
        gvMenu.DataBind()
    End Sub

    Protected Sub gvMenu_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim boolDataExist = False
        Dim Index As Int32 = -1

        Dim iMenuId As Integer = 0
        Dim hfMenuId As HiddenField = Nothing
        Dim hfBranchId As HiddenField = Nothing
        Dim iBranchId As Integer = 0
        Dim sMenu As String = ""
        Dim txtQty As TextBox = Nothing
        Dim dbPrice As Double = 0
        Dim iQty As Integer = 0

        Dim dbTotPrice As Double = 0

        If e.CommandName = "doAddCart" Then

            Index = Convert.ToInt32(e.CommandArgument)

            sMenu = gvMenu.Rows(Index).Cells(0).Text
            dbPrice = Convert.ToDouble(gvMenu.Rows(Index).Cells(1).Text)
            txtQty = gvMenu.Rows(Index).FindControl("txtQty")

            hfMenuId = gvMenu.Rows(Index).FindControl("hfMenuId")
            iMenuId = hfMenuId.Value

            hfBranchId = gvMenu.Rows(Index).FindControl("hfBranchId")
            iBranchId = hfBranchId.Value

            If txtQty.Text = "" Then
                errorText.Attributes("style") = "display: block; text-align: center; color:red;"
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
        End If
    End Sub

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
End Class