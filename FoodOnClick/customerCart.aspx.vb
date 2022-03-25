Public Class customerCart
    Inherits System.Web.UI.Page
    Private boolMerged As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                DataBind()
            End If
        End If
    End Sub


    Protected Sub DataBind()
        Dim dtData As DataTable
        Dim clsCart As ShoppingCartDetail = New ShoppingCartDetail()
        clsCart.userID = Session("userid")

        dtData = clsCart.GetAllCartByUserID()

        'ViewState("rowCount") = dtData.Rows.Count()

        gvCart.DataSource = dtData
        gvCart.DataBind()

        Merge(dtData.Rows.Count())
    End Sub

    Protected Sub gvCart_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim Index As Int32 = -1

        Dim hfMenuId As HiddenField = Nothing
        Dim hfCartId As HiddenField = Nothing
        Dim hfEmail As HiddenField = Nothing
        Dim iMenuId As Integer = 0
        Dim iCartId As Integer = 0
        Dim sEmail As String = ""

        Dim hfCompareCartId As HiddenField = Nothing
        Dim iCCompareCartId As Integer = 0


        Dim hfUnitPrice As HiddenField = Nothing
        Dim dbUnitPrice As Decimal = 0

        Dim txtQuantity As TextBox = Nothing
        Dim iQuantity As Integer = 0

        If e.CommandName = "doCancel" Then

            Index = Convert.ToInt32(e.CommandArgument)

            hfMenuId = gvCart.Rows(Index).FindControl("hfMenuId")
            iMenuId = hfMenuId.Value

            hfCartId = gvCart.Rows(Index).FindControl("hfCartId")
            iCartId = hfCartId.Value

            Dim clsCart As ShoppingCartDetail = New ShoppingCartDetail()
            clsCart.userID = Session("userid")
            clsCart.menuid = iMenuId
            clsCart.cartID = iCartId
            clsCart.CancelOrderedMenuInShoppingCart()

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Order Menu Cancelled")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            DataBind()

        ElseIf e.CommandName = "doCheckOut" Then
            Index = Convert.ToInt32(e.CommandArgument)

            hfCartId = gvCart.Rows(Index).FindControl("hfCartId")
            iCartId = hfCartId.Value

            Dim clsSC As ShoppingCartDetail = New ShoppingCartDetail()
            clsSC.cartID = iCartId
            clsSC.ClearShoppingCart()

            'update again because possible got new input
            For Each row As GridViewRow In gvCart.Rows
                hfCompareCartId = row.FindControl("hfCartId")
                iCCompareCartId = hfCompareCartId.Value
                If iCartId = iCCompareCartId Then
                    hfUnitPrice = row.FindControl("hfUnitPrice")
                    dbUnitPrice = hfUnitPrice.Value

                    txtQuantity = row.FindControl("txtQuantity")
                    iQuantity = txtQuantity.Text.Trim()

                    hfMenuId = row.FindControl("hfMenuId")
                    iMenuId = hfMenuId.Value

                    clsSC.menuid = iMenuId
                    clsSC.quantity = iQuantity
                    clsSC.price = dbUnitPrice
                    clsSC.cartID = iCartId
                    clsSC.userID = Session("userid")

                    clsSC.UpdateShoppingCart()
                End If
            Next
            Session("cartId") = iCartId
            Response.Redirect("customerCheckOut.aspx")
        End If
    End Sub

    Protected Sub gvCart_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        Dim hCartId As HiddenField = Nothing
        Dim hPrevCartId As HiddenField = Nothing
        Dim iCartID As Integer = 0
        Dim iPreviousCatID As String = 0

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            'merge rows
            For i As Integer = gvCart.Rows.Count - 1 To 1 Step -1
                Dim row As GridViewRow = gvCart.Rows(i)
                Dim previousRow As GridViewRow = gvCart.Rows(i - 1)

                For j As Integer = 0 To row.Cells.Count - 1
                    If row.Cells(j).Text = previousRow.Cells(j).Text And j <> 7 And j <> 6 Then

                        If row.Cells(j).RowSpan = 0 Then
                            previousRow.Cells(j).RowSpan += 2
                        Else
                            previousRow.Cells(j).RowSpan = row.Cells(j).RowSpan + 1
                        End If
                        row.Cells(j).Visible = False
                    End If

                    boolMerged = True
                Next
            Next
        End If

        If boolMerged = False And ViewState("rowCount") = 2 Then
            For i As Integer = gvCart.Rows.Count - 1 To 1 Step -1
                Dim row As GridViewRow = gvCart.Rows(i)
                Dim previousRow As GridViewRow = gvCart.Rows(i - 1)

                hCartId = gvCart.Rows(i).FindControl("hfCartId")
                iCartID = hCartId.Value

                hPrevCartId = gvCart.Rows(i - 1).FindControl("hfCartId")
                iPreviousCatID = hPrevCartId.Value

                If iCartID = iPreviousCatID Then
                    For j As Integer = 0 To row.Cells.Count - 1
                        If row.Cells(j).Text = previousRow.Cells(j).Text And j <> 7 And j <> 6 Then

                            If row.Cells(j).RowSpan = 0 Then
                                previousRow.Cells(j).RowSpan += 2
                            Else
                                previousRow.Cells(j).RowSpan = row.Cells(j).RowSpan + 1
                            End If
                            row.Cells(j).Visible = False
                        End If
                    Next
                End If

            Next
        End If
    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub


    Protected Sub Merge(ByVal rowCount As Integer)
        Dim hCartId As HiddenField = Nothing
        Dim hPrevCartId As HiddenField = Nothing
        Dim iCartID As Integer = 0
        Dim iPreviousCatID As String = 0

        For i As Integer = rowCount - 1 To 1 Step -1
            Dim row As GridViewRow = gvCart.Rows(i)
            Dim previousRow As GridViewRow = gvCart.Rows(i - 1)

            hCartId = gvCart.Rows(i).FindControl("hfCartId")
            iCartID = hCartId.Value.ToString()

            hPrevCartId = gvCart.Rows(i - 1).FindControl("hfCartId")
            iPreviousCatID = hPrevCartId.Value.ToString()

            If iCartID = iPreviousCatID Then
                For j As Integer = 0 To row.Cells.Count - 1
                    If row.Cells(j).Text = previousRow.Cells(j).Text And j <> 7 And j <> 6 Then

                        If row.Cells(j).RowSpan = 0 Then
                            previousRow.Cells(j).RowSpan += 2
                        Else
                            previousRow.Cells(j).RowSpan = row.Cells(j).RowSpan + 1
                        End If
                        row.Cells(j).Visible = False
                    End If
                Next
            End If
        Next
    End Sub
End Class