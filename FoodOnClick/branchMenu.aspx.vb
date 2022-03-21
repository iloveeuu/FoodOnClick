Public Class branchMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Or Session("branchid") Is Nothing Then
                Response.Redirect("login.aspx")
            End If
        End If

        bindrestaurantdata()
    End Sub

    Protected Sub rptBranch_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim imageUrl As String = DataBinder.Eval(e.Item.DataItem, "menuImage")
        Dim img As Image = (TryCast(e.Item.FindControl("menuImage"), Image))
        Dim url As String = "~/images/menu/" & imageUrl
        img.Style.Add("vertical-align", "middle")
        img.ImageUrl = url
        'Server.MapPath()
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
End Class