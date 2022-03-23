Public Class customerOrderDetail
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

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        Dim ord As Order = New Order()
        ord.userId = Session("userid")
        ord.batchId = Session("batchId")
        Dim boolPending As Boolean = ord.CheckPreOrderPending()
        If boolPending = False Then
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Status has been updated by restaurant, not allow to cancel order")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        Else
            ord.CancelOrder()

            Dim clsOrderDetail As OrderDetail = New OrderDetail()
            clsOrderDetail.batchId = Session("batchId")
            Dim dtTable As DataTable = clsOrderDetail.GetOrderDetail()

            Dim subject As String = "Delivery Order with ID: " & Session("orderID") & " Cancelled"

            Dim sHtmlTable As String = ""
            For Each row As DataRow In dtTable.Rows
                sHtmlTable += "<tr><td>" & row("menu") & "</td><td>" & row("orderQuantity") & "</td><td>" & row("price") & "</td></tr>"
            Next row

            Dim body As String = "<html> " &
                                "<body>" &
                                "<p>Dear " & lblRestName.Text & ",</p>" &
                                "<p>At " & lblAddress.Text & ",</p>" &
                                "<br/>" &
                                "<p>You have Pre-Order CANCELLED from " & Session("firstname") & " " & Session("lastname") & " at " & Session("date") & " time " & Session("time") & " for " & Session("pax") & " pax.</p>" &
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
            'smtp.SendMail(email, subject, body, Nothing, True)

            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append("Delivery Order Cancelled")
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

            DataBind()
        End If
    End Sub

    Protected Sub DataBind()
        Dim clsOrderDetail As OrderDetail = New OrderDetail()
        clsOrderDetail.batchId = Session("batchId")
        clsOrderDetail.userId = Session("userid")

        Dim boolPending As Boolean = clsOrderDetail.CheckOrderPending()
        If boolPending = False Then
            btnCancel.Visible = False
        End If

        Dim dtTable As DataTable = clsOrderDetail.GetOrderDetail()
        gvMenu.DataSource = dtTable
        gvMenu.DataBind()

        h2ID.InnerText = "Delivery Order, ID: " & Session("orderID")
        lblRestName.Text = Session("restName")
        lblAddress.Text = Session("address")
        lblTotal.Text = "$" + dtTable.Rows(0)(4).ToString()
        lblStatus.Text = dtTable.Rows(0)(5).ToString()

    End Sub
End Class