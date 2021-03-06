Public Class Branch1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                Dim getRestaurantId As User = New User(Convert.ToInt32(Session("userid")))
                Session("restaurantid") = Convert.ToInt32(getRestaurantId.getResId())
            End If
        End If
        binddata()

    End Sub

    Protected Sub rptBranch_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim city As String = DataBinder.Eval(e.Item.DataItem, "branchCity").ToString()
            Dim name As Label = TryCast(e.Item.FindControl("branchName"), Label)
            name.Text = name.Text & " - " & city
            'If (DataBinder.Eval(e.Item.DataItem, "branchStatus").ToString() = "In Business") Then
            '    Dim btnDelete As Button = TryCast(e.Item.FindControl("btnDelete"), Button)
            '    btnDelete.Enabled = False
            'End If
        End If
    End Sub

    Protected Sub rptBranch_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edit") Then
            System.Web.HttpContext.Current.Session("branchid") = e.CommandArgument.ToString()
            Response.Redirect("branchInfo.aspx")
        ElseIf (e.CommandName = "Delete") Then
            'Dim result As  = ("Are you sure you want to delete this branch", .YesNo)
            'If result = result.Yes Then
            '    Dim branch As Branch = New Branch(Convert.ToInt32(e.CommandArgument.ToString()))
            '    If (branch.DeleteBranch() = "True") Then
            '        binddata()
            '        ("Successfully deleted branch", .Information, "Success")
            '    End If
            'End If
        ElseIf (e.CommandName = "Select") Then
            System.Web.HttpContext.Current.Session("branchid") = e.CommandArgument.ToString()
            Response.Redirect("branchMenu.aspx")

        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        System.Web.HttpContext.Current.Session("branchid") = Nothing
        Response.Redirect("branchInfo.aspx")
    End Sub

    Protected Sub binddata()
        Dim clsBranch As Branch = New Branch(Convert.ToInt32(Session("userid").ToString()), Convert.ToInt32(Session("restaurantid").ToString()))
        menuImage.ImageUrl = clsBranch.RetrieveImageByUserId()
        Dim title As Restaurant = clsBranch.RetrieveRestaurantInfoByRestaurantId()
        lblTitle.Text = title.restaurantName & " Branches"
        Dim listOfBranch As List(Of Branch) = clsBranch.RetrieveBranchInfo()
        If listOfBranch.Count() > 0 Then
            rptBranch.DataSource = listOfBranch
            rptBranch.DataBind()
        Else
            lblNothing.Visible = True
        End If
    End Sub

    Protected Sub report_click(sender As Object, e As EventArgs)
        Response.Redirect("restaurantReport.aspx")
    End Sub


End Class