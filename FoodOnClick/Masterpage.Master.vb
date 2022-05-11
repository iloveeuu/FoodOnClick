Public Class Masterpage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Session("userid") Is Nothing) Then
            lbLoginSignUp.Text = "Welcome " & Session("firstname") & " " & Session("lastname")
            lblLogOut.Visible = True
            lbNotifySupport.Visible = True
        Else
            lbLoginSignUp.Text = "Login/Sign Up"
            lblLogOut.Visible = False
            lbNotifySupport.Visible = False
        End If
    End Sub

    Protected Sub lbLoginSignUp_Click(sender As Object, e As EventArgs)
        If (Not Session("userid") Is Nothing) Then
            If Session("type") = "Customer" Then
                Response.Redirect("customerProfile.aspx")
            End If
            If Session("type") = "Restaurant" Then
                Response.Redirect("customerProfile.aspx")
            End If
            If Session("type") = "Administrator" Then
                Response.Redirect("customerProfile.aspx")
            End If
            If Session("type") = "Rider" Then
                Response.Redirect("customerProfile.aspx")
            End If
            If Convert.ToInt32(Session("userid")) = 0 Then
                Response.Redirect("branchMenu.aspx")
            End If
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub lblLogOut_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()
        lblLogOut.Visible = False
        Response.Redirect("login.aspx")

    End Sub

    Protected Sub ibtnHome_Click(sender As Object, e As ImageClickEventArgs)
        If (Not Session("userid") Is Nothing) Then
            If Session("type") = "Customer" Then
                Response.Redirect("customerHome.aspx")
            End If
            If Session("type") = "Restaurant" Then
                Response.Redirect("branch.aspx")
            End If
            If Session("type") = "Administrator" Then
                Response.Redirect("administratorHome.aspx")
            End If
            If Session("type") = "Rider" Then
                Response.Redirect("riderHome.aspx")
            End If
            If Convert.ToInt32(Session("userid")) = 0 Then
                Response.Redirect("branchMenu.aspx")
            End If
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub lbNotifySupport_Click(sender As Object, e As EventArgs)

        If (Not Session("userid") Is Nothing) Then

            Response.Redirect("notifySupportHome.aspx")

        Else
            Response.Redirect("login.aspx")
        End If
    End Sub
End Class