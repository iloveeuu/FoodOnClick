﻿Public Class customerPreOrder
    Inherits System.Web.UI.Page
    Private dtAdd As New DataTable

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
                lblDuration.Text = Session("duration")
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

            divShowHide.Visible = False
        End If
    End Sub


    Protected Sub rptMenu_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim boolDataExist = False
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

        Dim dbTotPrice As Double = 0

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

        ElseIf e.CommandName = "doAdd" Then
            iMenuId = Convert.ToInt32(e.CommandArgument)

            hfBranchId = e.Item.FindControl("hfBranchId")
            iBranchId = hfBranchId.Value

            lblDishName = e.Item.FindControl("lblDishName")
            sMenu = lblDishName.Text

            txtQty = e.Item.FindControl("txtQty")

            dtAdd = Session("dtTable")

            If txtQty.Text <> "" Then
                iQty = txtQty.Text
            End If

            If txtQty.Text = "" Or iQty < 1 Then
                errorText.Attributes("style") = "display: block; text-align: center; color:red;"
                errorText2.Attributes("style") = "display: none;"
            Else
                errorText.Attributes("style") = "display: none;"
                errorText2.Attributes("style") = "display: none;"

                lblPrice = e.Item.FindControl("lblPrice")
                sPrice = lblPrice.Text
                sPrice = sPrice.Replace("$ ", "")

                dbPrice = Convert.ToDouble(sPrice)

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

            rptMenu.DataSource = dtSearch
            rptMenu.DataBind()
        End If
    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        my_popup.Style.Add("display", "none")
        popup.Style.Add("display", "none")

        my_popup2.Style.Add("display", "none")
        compare_popup.Style.Add("display", "none")
    End Sub

    Protected Sub gvPreOrder_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim Index As Int32 = -1
        Dim sMenu As String = ""

        If e.CommandName = "doCancel" Then

            errorText.Attributes("style") = "display: none;"
            errorText2.Attributes("style") = "display: none;"

            Index = Convert.ToInt32(e.CommandArgument)
            sMenu = gvPreOrder.Rows(Index).Cells(0).Text

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

            If ddlPayment.SelectedValue <> "Cash" Then

                Dim masterCardRegex As String = "^(?:5[1-5][0-9]{14})$"
                Dim visaCardRegex As String = "^(?:4[0-9]{12})(?:[0-9]{3})$"

                If ddlCardType.SelectedValue = "Master" Then
                    Dim mcRegex As New Regex(masterCardRegex)

                    If mcRegex.IsMatch(txtCardNo.Text.Trim()) = False Then
                        errorText3.Attributes("style") = "display: block; text-align: center; color:red;"

                        Exit Sub
                    End If
                ElseIf ddlCardType.SelectedValue = "Visa" Then
                    Dim vRegex As New Regex(visaCardRegex)

                    If vRegex.IsMatch(txtCardNo.Text.Trim()) = False Then
                        errorText3.Attributes("style") = "display: block; text-align: center; color:red;"

                        Exit Sub
                    End If
                End If
            End If

            errorText3.Attributes("style") = "display: none;"

            dtAdd = Session("dtTable")

            Dim dNow As Date = Date.Now
            Dim dTotalCharges As Double = Convert.ToDouble(dtAdd.Compute("SUM(totPrice)", String.Empty))

            Dim od As OrderDetail = New OrderDetail()
            od.orderDate = dNow
            od.orderTime = dNow.ToString("H:mm")
            od.branchId = Session("branchid")
            od.userId = Session("userid")
            od.orderTypeID = 10
            od.totalcharges = dTotalCharges
            od.orderStatusID = 6
            od.paymentMethod = ddlPayment.SelectedItem.ToString()

            Dim iBatchId As Integer = od.InsertBatchOrder()

            Dim resv As Reservation = New Reservation("Yes", lblDate.Text.Trim(), lblTime.Text.Trim(), lblPax.Text.Trim(), "Pending", Session("branchid"), Session("userid"), iBatchId, lblDuration.Text.Trim())
            resv.InsertReservation()

            od.batchId = iBatchId
            Dim iOrderId As Integer = od.InsertReservationOrder()

            For Each row As DataRow In dtAdd.Rows
                od.menuid = row("menuId")
                od.price = row("totPrice")
                od.orderQuantity = row("qty")
                od.orderNum = iOrderId
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
            smtp.SendMail(email, subject, body, Nothing, True)

            Response.Write("<script language='javascript'>window.alert('Reservation Created, Please Wait for Confirmation');window.location='customerHome.aspx';</script>")

        End If
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHistory.aspx")
    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerCart.aspx")
    End Sub

    Protected Sub gvCompare_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim boolDataExist = False
        Dim Index As Int32 = -1

        Dim iMenuId As Integer = 0
        Dim hfMenuId As HiddenField = Nothing
        Dim hfBranchId As HiddenField = Nothing
        Dim iBranchId As Integer = 0

        Dim txtQty As TextBox = Nothing
        Dim iQty As Integer = 0

        Dim lblPrice As Label = Nothing
        Dim sPrice As String = ""
        Dim dbPrice As Double = 0

        Dim dbTotPrice As Double = 0

        Dim lblDishName As Label = Nothing
        Dim sMenu As String = ""

        If e.CommandName = "doAdd" Then
            iMenuId = Convert.ToInt32(e.CommandArgument)

            Index = Convert.ToInt32(e.CommandArgument)

            hfBranchId = gvCompare.Rows(Index).FindControl("hfBranchId")
            iBranchId = hfBranchId.Value

            lblDishName = gvCompare.Rows(Index).FindControl("lblDishName")
            sMenu = lblDishName.Text

            txtQty = gvCompare.Rows(Index).FindControl("txtQty")

            dtAdd = Session("dtTable")

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

                lblPrice = gvCompare.Rows(Index).FindControl("lblPrice")
                sPrice = lblPrice.Text
                sPrice = sPrice.Replace("$ ", "")

                dbPrice = Convert.ToDouble(sPrice)

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

        If Session("compare_menuid") Is Nothing OrElse Session("compare_menuid") = "" Then
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
            compare_popup.Style.Add("display", "block")
        End If
    End Sub

    Protected Sub ddlPayment_SelectedIndexChanged(sender As Object, e As EventArgs)
        divShowHide.Visible = IIf(ddlPayment.SelectedValue = "Cash", False, True)
        errorText.Attributes("style") = "display: none;"
    End Sub
End Class