Public Class customerPreOrder
    Inherits System.Web.UI.Page
    Dim dtAdd As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                lblRestName.Text = Session("restName")
                lblHalal.Text = Session("halal")
                lblAddress.Text = Session("address")
                lblDate.Text = Session("date")
                lblTime.Text = Session("time")
                lblPax.Text = Session("pax")
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

            If Session("dtTable") Is Nothing Then
                ' Create dataTable Columns
                dtAdd.Columns.Add("menuId", GetType(Integer))
                dtAdd.Columns.Add("menu", GetType(String))
                dtAdd.Columns.Add("qty", GetType(Integer))
                dtAdd.Columns.Add("totPrice", GetType(Double))

                Session("dtTable") = dtAdd
            Else
                gvPreOrder.DataSource = Session("dtTable")
                gvPreOrder.DataBind()
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

        If Session("orderType") = "reservation" Then
            'ddlType.SelectedItem.ToString()
            Dim clsMenu As Menu = New Menu()
            dtSearch = clsMenu.GetSearchMenu(Session("branchid"), ddlType.SelectedItem.ToString(),
                                           txtDishName.Text.Trim(), dblMinPrice, dblMaxPrice)

            gvMenu.DataSource = dtSearch
            gvMenu.DataBind()
        End If
    End Sub

    Protected Sub gvMenu_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        Dim boolDataExist = False
        Dim Index As Int32 = -1

        Dim iMenuId As Integer = 0
        Dim hfMenuId As HiddenField = Nothing
        Dim sMenu As String = ""
        Dim txtQty As TextBox = Nothing
        Dim dbPrice As Double = 0
        Dim iQty As Integer = 0

        Dim dbTotPrice As Double = 0

        If e.CommandName = "doAdd" Then

            Index = Convert.ToInt32(e.CommandArgument)

            sMenu = gvMenu.Rows(Index).Cells(0).Text
            dbPrice = Convert.ToDouble(gvMenu.Rows(Index).Cells(1).Text)
            txtQty = gvMenu.Rows(Index).FindControl("txtQty")

            hfMenuId = gvMenu.Rows(Index).FindControl("hfMenuId")
            iMenuId = hfMenuId.Value

            dtAdd = Session("dtTable")

            If txtQty.Text = "" Then
                errorText.Attributes("style") = "display: block; text-align: center; color:red;"
                errorText2.Attributes("style") = "display: none;"
            Else
                errorText.Attributes("style") = "display: none;"
                errorText2.Attributes("style") = "display: none;"

                iQty = txtQty.Text

                dbTotPrice = dbPrice * Convert.ToDouble(iQty)

                For Each row As DataRow In dtAdd.Rows
                    If (row("menu").ToString() = sMenu) Then
                        row("qty") += iQty
                        row("totPrice") += dbTotPrice

                        boolDataExist = True
                    End If
                Next

                If boolDataExist = False Then
                    dtAdd.Rows.Add(iMenuId, sMenu, iQty, dbTotPrice)
                End If

                Session("dtTable") = dtAdd

                gvPreOrder.DataSource = dtAdd
                gvPreOrder.DataBind()

                lblTotal.Text = " $" + Convert.ToString(dtAdd.Compute("SUM(totPrice)", String.Empty))
            End If

        End If
    End Sub

    Protected Sub gvPreOrder_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim Index As Int32 = -1
        Dim sMenu As String = ""

        If e.CommandName = "doCancel" Then

            errorText.Attributes("style") = "display: none;"
            errorText2.Attributes("style") = "display: none;"

            Index = Convert.ToInt32(e.CommandArgument)
            sMenu = gvMenu.Rows(Index).Cells(0).Text

            dtAdd = Session("dtTable")

            For Each row As DataRow In dtAdd.Rows
                If (row("menu").ToString() = sMenu) Then
                    dtAdd.Rows.Remove(row)

                    Exit For
                End If
            Next

            Session("dtTable") = dtAdd

            gvPreOrder.DataSource = dtAdd
            gvPreOrder.DataBind()

            lblTotal.Text = " $" + Convert.ToString(dtAdd.Compute("SUM(totPrice)", String.Empty))
        End If
    End Sub

    Protected Sub btnPreOrder_Click(sender As Object, e As EventArgs)

        If lblTotal.Text = "" Then
            errorText2.Attributes("style") = "display: block; text-align: center; color:red;"
            errorText.Attributes("style") = "display: none;"
        Else
            errorText2.Attributes("style") = "display: none;"
            errorText.Attributes("style") = "display: none;"

            dtAdd = Session("dtTable")

            Dim dNow As Date = Date.Now
            Dim dTotalCharges As Double = Convert.ToDouble(dtAdd.Compute("SUM(totPrice)", String.Empty))

            'Dim bo As BatchOrder = New BatchOrder(dNow, dNow.ToString("H:mm"), Session("branchid"),
            '           Session("userid"), Nothing, 10, Nothing)
            'bo.InsertBatchOrder()

            'Dim order As Order = New Order(Nothing, dTotalCharges, 6, Nothing, Nothing, Nothing, Nothing)
            'order.InsertOrder()

            Dim od As OrderDetail = New OrderDetail()
            od.orderDate = dNow
            od.orderTime = dNow.ToString("H:mm")
            od.branchId = Session("branchid")
            od.userId = Session("userid")
            od.orderTypeID = 10
            od.totalcharges = dTotalCharges
            od.orderStatusID = 6

            od.InsertBatchOrder()

            Dim resv As Reservation = New Reservation("Yes", lblDate.Text.Trim(), lblTime.Text.Trim(), lblPax.Text.Trim(), "Pending", Session("branchid"), Session("userid"), Nothing)
            resv.InsertReservation()

            od.InsertOrder()

            For Each row As DataRow In dtAdd.Rows
                od.menuid = row("menuId")
                od.price = row("totPrice")
                od.orderQuantity = row("qty")
                od.InsertOrderDetail()
            Next row

            Dim sHtmlTable As String = ""
            For Each row As DataRow In dtAdd.Rows
                sHtmlTable += "<tr><td>" & row("menu") & "</td><td>" & row("qty") & "</td><td>" & row("totPrice") & "</td></tr>"
            Next row

            Dim subject As String = "Reservation with Pre-Order from " & Session("firstname") & " " & Session("lastname") & ", " & Session("date")

            Dim body As String = "<html> " &
                                "<body>" &
                                "<p>Dear " & lblRestName.Text & ",</p>" &
                                "<p>At " & lblAddress.Text & ",</p>" &
                                "<br/>" &
                                "<p>You have reservation from " & Session("firstname") & " " & Session("lastname") & " at " & Session("date") & " time " & Session("time") & " for " & Session("pax") & " pax. With following pre-order list.</p>" &
                                "<p>Pre Order List</p>" &
                                "<table style='border:1px solid #333'><tr><th>Menu</th><th>Quantity</th><th>Price</th></tr>" &
                                "" & sHtmlTable & "</table>" &
                                "<p>Please check your reservation list and response the status</p>" &
                                "<br/>" &
                                "<p>Regards,</p>" &
                                "<p>Food on Click</p>" &
                                "</body>" &
                                "</html>"

            Dim smtp As SMTP = New SMTP()
            Dim email() As String = {Session("email")}
            'Dim email() As String = {"will.ariez@gmail.com"}
            smtp.SendMail(email, subject, body, Nothing, True)

            'Dim sb As New System.Text.StringBuilder()
            'sb.Append("<script type = 'text/javascript'>")
            'sb.Append("window.onload=function(){")
            'sb.Append("alert('")
            'sb.Append("Reservation Created, Please Wait for Confirmation")
            'sb.Append("')};")
            'sb.Append("window.location = '")
            'sb.Append("customerHome.aspx")
            'sb.Append("'; }")
            'sb.Append("</script>")
            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            Response.Write("<script language='javascript'>window.alert('Reservation Created, Please Wait for Confirmation');window.location='customerHome.aspx';</script>")

            'Response.Redirect("customerHome.aspx")
        End If
    End Sub

End Class