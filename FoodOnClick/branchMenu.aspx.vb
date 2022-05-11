Public Class branchMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Or Session("branchid") Is Nothing Then
                Response.Redirect("login.aspx")
            End If
            If (Session("userid") = 0) Then
                btnHome.Visible = False
            Else
                btnHome.Visible = True
            End If
        End If

            bindrestaurantdata()
    End Sub

    Protected Sub rptBranch_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim price As Decimal = DataBinder.Eval(e.Item.DataItem, "menuCost")
        Dim lblPrice As Label = (TryCast(e.Item.FindControl("menuPrice"), Label))
        lblPrice.Text = "$" & price
        Dim imageUrl As String = DataBinder.Eval(e.Item.DataItem, "menuImage")
        Dim img As Image = (TryCast(e.Item.FindControl("menuImage"), Image))
        Dim url As String = "~/images/menu/" & imageUrl
        img.Style.Add("vertical-align", "middle")
        img.ImageUrl = url
    End Sub

    Protected Sub rptBranch_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edit") Then
            System.Web.HttpContext.Current.Session("menuid") = e.CommandArgument.ToString()
            Response.Redirect("branchMenuInfo.aspx")
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        System.Web.HttpContext.Current.Session("menuid") = Nothing
        Response.Redirect("branchMenuInfo.aspx")
    End Sub

    Protected Sub bindrestaurantdata()
        Dim clsRestaurantMenuInfo As Menu = New Menu(Convert.ToInt32(Session("branchid").ToString()))
        Dim clsBranch As Branch = clsRestaurantMenuInfo.RetrieveRestaurantBranchInfoByBranchId()
        lblTitle.Text = clsBranch.restaurantName & " - " & clsBranch.branchCity & " Branch"
        'lblWallet.Text = "Wallet: $" & clsBranch.branchwallet.ToString()
        Dim listOfBranch As List(Of Menu) = clsRestaurantMenuInfo.RetrieveMenuInfo()
        If listOfBranch.Count() > 0 Then
            rptBranch.DataSource = listOfBranch
            rptBranch.DataBind()
        Else
            lblNothing.Visible = True
        End If
    End Sub

    Protected Sub btnReservations_Click(sender As Object, e As EventArgs)
        System.Web.HttpContext.Current.Session("branchid") = Convert.ToInt32(Session("branchid").ToString())
        Response.Redirect("branchReservation.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("branch.aspx")
    End Sub

    Protected Sub btnOrders_Click(sender As Object, e As EventArgs)
        System.Web.HttpContext.Current.Session("branchid") = Convert.ToInt32(Session("branchid").ToString())
        Response.Redirect("branchOrder.aspx")
    End Sub

    Protected Sub btnReviews_Click(sender As Object, e As EventArgs)
        System.Web.HttpContext.Current.Session("branchid") = Convert.ToInt32(Session("branchid").ToString())
        Response.Redirect("branchReviews.aspx")
    End Sub
End Class