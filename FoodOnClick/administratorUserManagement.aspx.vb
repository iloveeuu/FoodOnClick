Public Class administratorUserManagement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub manageCustomer(ByVal sender As Object, ByVal e As System.EventArgs) Handles customerManagement.Click
        Response.Redirect("administratorUserManagementCustomer.aspx")
    End Sub


    Protected Sub manageRestaurant(ByVal sender As Object, ByVal e As System.EventArgs) Handles restaurantManagement.Click
        Response.Redirect("administratorUserManagementRestaurant.aspx")
    End Sub



    Protected Sub manageRider(ByVal sender As Object, ByVal e As System.EventArgs) Handles riderManagement.Click
        Response.Redirect("administratorUserManagementRider.aspx")
    End Sub




End Class