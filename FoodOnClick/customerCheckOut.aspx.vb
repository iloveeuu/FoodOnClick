Public Class customerCheckOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                DataBind()
            End If
        End If
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnHistory_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerHistory.aspx")
    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Response.Redirect("customerCart.aspx")
    End Sub

    Protected Sub btnOrder_Click(sender As Object, e As EventArgs)
        Dim clsSC As ShoppingCartDetail = New ShoppingCartDetail()
        clsSC.cartID = Session("cartId")
        clsSC.userID = Session("userid")

        Dim dtTable As DataTable = clsSC.GetAllCartByCartID()

        Dim dNow As Date = Date.Now

        Dim serverDate As Date = dNow.AddHours(13)

        Dim od As OrderDetail = New OrderDetail()
        od.orderDate = serverDate
        od.orderTime = serverDate.ToString("H:mm")
        od.userId = Session("userid")
        od.branchId = dtTable.Rows(0)(2)
        od.orderTypeID = 11
        od.orderStatusID = 6
        od.deliveryTypeID = 2
        od.paymentMethod = ddlPayment.SelectedItem.ToString()
        od.cartID = Session("cartId")

        Dim iBatchId As Integer = od.InsertBatchOrder()

        od.batchId = iBatchId

        Dim delCharges As Double = CalculateDeliveryCharges(dtTable.Rows.Count())

        od.deliverycharges = delCharges
        Dim iOrderId As Integer = od.InsertDeliveryOrder()

        od.orderNum = iOrderId
        od.InsertOrderDetail()

        Dim sHtmlTable As String = ""
        For Each row As DataRow In dtTable.Rows
            sHtmlTable += "<tr><td>" & row("menu") & "</td><td>" & row("quantity") & "</td><td>" & row("price") & "</td></tr>"
        Next row

        Dim subject As String = "Delivery Order ID: " & iOrderId.ToString()

        Dim body As String = "<html> " &
                                "<body>" &
                                "<p>Dear " & lblRestName.Text & ",</p>" &
                                "<p>At " & lblAddress.Text & ",</p>" &
                                "<br/>" &
                                "<p>You have delivery order. with order ID: " & iOrderId.ToString() & "</p>" &
                                "<table style='border:1px solid #333'><tr><th>Menu</th><th>Quantity</th><th>Price</th></tr>" &
                                "" & sHtmlTable & "</table>" &
                                "<p>Please check your order list and response the status</p>" &
                                "<br/>" &
                                "<p>Regards,</p>" &
                                "<p>Food on Click</p>" &
                                "</body>" &
                                "</html>"

        Dim smtp As SMTP = New SMTP()
        Dim email() As String = {dtTable.Rows(0)(10)}

        'Dim email() As String = {"will.ariez@gmail.com"}
        smtp.SendMail(email, subject, body, Nothing, True)

        clsSC.DeleteShoppingCart()

        Response.Write("<script language='javascript'>window.alert('Delivery Order Created, Please Wait for Confirmation');window.location='customerHome.aspx';</script>")

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Response.Redirect("customerCart.aspx")
    End Sub

    Protected Sub DataBind()
        Dim clsSC As ShoppingCartDetail = New ShoppingCartDetail()
        clsSC.cartID = Session("cartId")
        clsSC.userID = Session("userid")

        Dim dtTable As DataTable = clsSC.GetAllCartByCartID()
        gvMenu.DataSource = dtTable
        gvMenu.DataBind()

        lblRestName.Text = dtTable.Rows(0)(0)
        lblAddress.Text = dtTable.Rows(0)(3)
        lblType.Text = dtTable.Rows(0)(5)

        Dim delCharges As Double = CalculateDeliveryCharges(dtTable.Rows.Count())

        lblDelCharges.Text = "$" + Convert.ToString(delCharges)

        lblTotal.Text = "$" + Convert.ToString(dtTable.Rows(0)(6) + delCharges)

    End Sub

    Protected Function CalculateDeliveryCharges(ByVal iTotalOrders As Integer)
        Dim charges As Decimal

        If iTotalOrders > 0 And iTotalOrders <= 3 Then
            charges = 5
        ElseIf iTotalOrders > 3 And iTotalOrders <= 6 Then
            charges = 5.5
        ElseIf iTotalOrders > 6 And iTotalOrders <= 8 Then
            charges = 6
        Else
            charges = 10
        End If

        Return charges
    End Function
End Class