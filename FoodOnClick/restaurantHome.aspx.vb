Public Class restaurantHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            Dim clsRestaurant As Restaurant = New Restaurant()
            clsRestaurant.userId = Session("userid")
            Dim listOfRestaurant As List(Of Restaurant) = clsRestaurant.RetrieveRestaurantInfo()
            If listOfRestaurant.Count() > 0 Then

            Else
                lblNothing.Visible = True
            End If
        End If
    End Sub

    Protected Sub rptRestaurant_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)

    End Sub
End Class
