Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports GoogleMaps.LocationServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class riderDelivery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim script As String = "window.onload = function() { getLocation(); };"
            ClientScript.RegisterStartupScript(Me.GetType(), "UpdateTime", script, True)
        End If
    End Sub

    Protected Sub btnDirectionToRestaurant_Click(sender As Object, e As EventArgs)
        hlMap.Text = "Click to Show Map"
        hlMap.NavigateUrl = "https://www.google.com/maps/dir/?api=1&origin=1.3492299,103.7485746&destination=Blk%2011,%20%2301-11,%20Ang%20Mo%20Kio%20Central"
    End Sub
End Class