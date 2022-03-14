Public Class restaurantHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            End If
            Dim clsRestaurant As Restaurant = New Restaurant()
                clsRestaurant.userId = Session("userid")
                Dim listOfRestaurant As List(Of Restaurant) = clsRestaurant.RetrieveRestaurantInfo()
                If listOfRestaurant.Count() > 0 Then
                    rptRestaurant.DataSource = listOfRestaurant
                    rptRestaurant.DataBind()
                Else
                    lblNothing.Visible = True
                End If
            End If
    End Sub

    Protected Sub rptRestaurant_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then

            Dim customerId As String = (TryCast(e.Item.FindControl("resName"), Label)).Text

        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub rptRestaurant_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Select") Then
            System.Web.HttpContext.Current.Session("restaurantid") = e.CommandArgument.ToString()
            Response.Redirect("branch.aspx")
        End If
    End Sub
End Class
