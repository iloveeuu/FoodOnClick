Public Class customerRestaurantMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            If Session("userid") Is Nothing Then
                Response.Redirect("login.aspx")
            Else
                lblRestName.Text = Session("restName")
                lblHalal.Text = Session("halal")
                lblAddress.Text = Session("address")

                lblOpenTime.Text = Session("timeOpen")
                lblCloseTime.Text = Session("timeClosed")

                Dim dtMenu As DataTable

                Dim clsSearch As Menu = New Menu()
                dtMenu = clsSearch.GetSearchMenu(Session("branchid"), "", "", 0, 0)

                rptMenu.DataSource = dtMenu
                rptMenu.DataBind()
            End If
        End If
    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerProfile.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("customerHome.aspx")
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Session("orderType") = "reservation"
        Response.Redirect("customerSearch.aspx")
    End Sub

    Protected Sub btnResere_Click(sender As Object, e As EventArgs)
        Session("userid") = Session("userid")
        Session("email") = Session("email")
        Session("branchid") = Session("branchid")
        Session("restName") = Session("restName")
        Session("halal") = Session("halal")
        Session("address") = Session("address")

        Response.Redirect("customerReservation.aspx")
    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        my_popup.Style.Add("display", "none")
        popup.Style.Add("display", "none")
    End Sub

    Protected Sub rptMenu_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "viewDetail") Then
            Dim dtMenu As DataTable
            Dim clsSearch As Menu = New Menu()
            Dim iMenuId As Integer = Convert.ToInt32(e.CommandArgument)

            dtMenu = clsSearch.GetSearchMenu(Session("branchid"), "", "", 0, 0, iMenuId)

            lblDishName.Text = dtMenu.Rows(0)(2).ToString()
            lblFoodType.Text = dtMenu.Rows(0)(6).ToString()
            lblPrice.Text = "$ " + dtMenu.Rows(0)(3).ToString()
            lblDesc.Text = dtMenu.Rows(0)(4).ToString()

            my_popup.Style.Add("display", "block")
            popup.Style.Add("display", "block")
        End If
    End Sub
End Class