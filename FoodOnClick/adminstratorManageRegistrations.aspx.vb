Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException




Public Class adminstratorManageRegistrations_aspxt
    Inherits System.Web.UI.Page
    Dim userID As Integer
    Dim emailAddress As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim con As New SqlConnection
        'Dim cmd As New SqlCommand
        'Dim dr As SqlDataReader
        'Dim dtSearch = New DataTable()
        'Dim message As String
        'In Document class
        Dim clsDocument As Document = New Document()
        rptUser.DataSource = clsDocument.GetRestaurantDocument()
        rptUser.DataBind()
        totalPendingCase.Text = clsDocument.GetCountRestaurantUser()


        'con.ConnectionString = "workstation id=foodonclick2.mssql.somee.com;packet size=4096;user id=fypfoodonclick_SQLLogin_1;pwd=eeq5c9sxpx;data source=foodonclick2.mssql.somee.com;persist security info=False;initial catalog=foodonclick2"
        'con.Open()
        'cmd.Connection = con
        'cmd.CommandText = "SELECT * FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid where dbo.UserAccount.status='VETTING'"
        'dr = cmd.ExecuteReader

        'If dr.HasRows Then
        '    dr.Close()
        '    con.Close()
        '    con.Open()

        '    cmd = New SqlCommand("SELECT COUNT(DISTINCT(dbo.document.userid)) AS COUNT FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid where dbo.UserAccount.status='VETTING'", con)
        '    dr = cmd.ExecuteReader
        '    Do While dr.Read()
        '        totalPendingCase.Text = dr.GetInt32(0)
        '    Loop
        '    dr.Close()
        '    con.Close()


        '    con.Open()
        '    cmd = New SqlCommand("SELECT TOP 1 dbo.UserAccount.userid, dbo.UserAccount.email  FROM dbo.document join dbo.UserAccount ON dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING'  ORDER BY dbo.UserAccount.userid", con)
        '    dr = cmd.ExecuteReader
        '    Do While dr.Read()
        '        document_useriID.Text = dr.GetInt32(0)
        '        userID = dr.GetInt32(0)
        '        emailAddress = dr.GetString(1)
        '    Loop
        '    dr.Close()
        '    con.Close()


        '    'business Logo 
        '    con.Open()
        '    cmd = New SqlCommand("Select dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID  AND dbo.document.type='Restaurant Logo'", con)
        '    cmd.Parameters.AddWithValue("@userID", userID)
        '    dr = cmd.ExecuteReader

        '    Do While dr.Read()
        '        document_restaurantLogo.Text = dr.GetString(0).Replace(dr.GetString(0), "<a target='_blank' href='" & dr.GetString(0) & "'>" & dr.GetString(0) & "</a>")
        '    Loop
        '    dr.Close()
        '    con.Close()

        '    'business License 
        '    con.Open()
        '    cmd = New SqlCommand("Select dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID AND dbo.document.type='Business License'", con)
        '    cmd.Parameters.AddWithValue("@userID", userID)
        '    dr = cmd.ExecuteReader
        '    Do While dr.Read()
        '        document_businessLicense.Text = dr.GetString(0).Replace(dr.GetString(0), "<a target='_blank' href='" & dr.GetString(0) & "'>" & dr.GetString(0) & "</a>")
        '    Loop
        '    dr.Close()
        '    con.Close()

        '    'Halal
        '    con.Open()
        '    cmd = New SqlCommand("Select  dbo.document.url  FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid  where dbo.UserAccount.status='VETTING' AND dbo.UserAccount.userid=@userID AND dbo.document.type='Halal'", con)
        '    cmd.Parameters.AddWithValue("@userID", userID)
        '    dr = cmd.ExecuteReader
        '    Do While dr.Read()
        '        document_halal.Text = dr.GetString(0).Replace(dr.GetString(0), "<a target='_blank' href='" & dr.GetString(0) & "'>" & dr.GetString(0) & "</a>")
        '    Loop
        '    dr.Close()
        '    con.Close()


        'Else
        '    totalPendingCase.Text = 0
        '    document_restaurantLogo.Text = ""
        '    document_businessLicense.Text = ""
        '    document_halal.Text = ""
        '    dr.Close()
        '    con.Close()
        'End If

    End Sub

    'Protected Sub systemAdminRegistrationApprove(sender As Object, e As EventArgs) Handles systemAdminRegistration_Approve.Click
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim mail As New SMTP()
    '    Dim message1 As String
    '    Dim message2 As String
    '    Dim message3 As String

    '    con.ConnectionString = "workstation id=foodonclick2.mssql.somee.com;packet size=4096;user id=fypfoodonclick_SQLLogin_1;pwd=eeq5c9sxpx;data source=foodonclick2.mssql.somee.com;persist security info=False;initial catalog=foodonclick2"
    '    con.Open()
    '    cmd.Connection = con
    '    cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.status='APPROVED' WHERE userid=@userID;"
    '    cmd.Parameters.AddWithValue("@userID", userID)
    '    cmd.ExecuteNonQuery()

    '    message1 = "User ID " & userID & " is approved"
    '    Dim sb1 As New System.Text.StringBuilder()
    '    sb1.Append("<script type='text/javascript'>")
    '    sb1.Append("window.onload=function(){")
    '    sb1.Append("alert('")
    '    sb1.Append(message1)
    '    sb1.Append("');window.location='adminstratorManageRegistrations.aspx';};")
    '    sb1.Append("</script>")
    '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())



    '    Dim ToAddressies As String() = {emailAddress}
    '    Dim attachs() As String = {}
    '    Dim subject As String = "Registration Request---Approved"
    '    Dim body As String = "Dear customer , we are pleased to inform you that your registration request has been approved, we are looking forward to starting business with you."
    '    Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
    '    If result Then
    '        message2 = "Email is sent "
    '        Dim sb2 As New System.Text.StringBuilder()
    '        sb2.Append("<script type='text/javascript'>")
    '        sb2.Append("window.onload=function(){")
    '        sb2.Append("alert('")
    '        sb2.Append(message2)
    '        sb2.Append("');window.location='adminstratorManageRegistrations.aspx';};")
    '        sb2.Append("</script>")
    '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

    '    Else
    '        message3 = "Email is not sent,please check Email address"
    '        Dim sb3 As New System.Text.StringBuilder()
    '        sb3.Append("<script type='text/javascript'>")
    '        sb3.Append("window.onload=function(){")
    '        sb3.Append("alert('")
    '        sb3.Append(message3)
    '        sb3.Append("');window.location='adminstratorManageRegistrations.aspx';};")
    '        sb3.Append("</script>")
    '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
    '    End If





    '    con.Close()


    'End Sub


    'Protected Sub systemAdminRegistrationReject(sender As Object, e As EventArgs) Handles systemAdminRegistration_Reject.Click
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim mail As New SMTP()
    '    Dim message1 As String
    '    Dim message2 As String
    '    Dim message3 As String


    '    con.ConnectionString = "workstation id=foodonclick2.mssql.somee.com;packet size=4096;user id=fypfoodonclick_SQLLogin_1;pwd=eeq5c9sxpx;data source=foodonclick2.mssql.somee.com;persist security info=False;initial catalog=foodonclick2"
    '    con.Open()
    '    cmd.Connection = con
    '    cmd.CommandText = "UPDATE dbo.UserAccount SET dbo.UserAccount.status='REJECTED' WHERE userid=@userID;"
    '    cmd.Parameters.AddWithValue("@userID", userID)
    '    cmd.ExecuteNonQuery()


    '    message1 = "User ID " & userID & " is rejected"
    '    Dim sb As New System.Text.StringBuilder()
    '    sb.Append("<script type='text/javascript'>")
    '    sb.Append("window.onload=function(){")
    '    sb.Append("alert('")
    '    sb.Append(message1)
    '    sb.Append("');window.location='adminstratorManageRegistrations.aspx';};")
    '    sb.Append("</script>")

    '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())

    '    con.Close()



    '    Dim ToAddressies As String() = {emailAddress}
    '    Dim attachs() As String = {}
    '    Dim subject As String = "Registration Request---Rejected"
    '    Dim body As String = "Dear customer , we are sorry to inform you that your request is rejected"
    '    Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
    '    If result Then
    '        message2 = "Email is sent "
    '        Dim sb2 As New System.Text.StringBuilder()
    '        sb2.Append("<script type='text/javascript'>")
    '        sb2.Append("window.onload=function(){")
    '        sb2.Append("alert('")
    '        sb2.Append(message2)
    '        sb2.Append("');window.location='adminstratorManageRegistrations.aspx';};")
    '        sb2.Append("</script>")
    '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
    '    Else
    '        message3 = "Email is not sent,please check Email address"
    '        Dim sb3 As New System.Text.StringBuilder()
    '        sb3.Append("<script type='text/javascript'>")
    '        sb3.Append("window.onload=function(){")
    '        sb3.Append("alert('")
    '        sb3.Append(message3)
    '        sb3.Append("');window.location='adminstratorManageRegistrations.aspx';};")
    '        sb3.Append("</script>")
    '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
    '    End If






    'End Sub


    Protected Sub rptUser_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then


            Dim rLogo As String = DataBinder.Eval(e.Item.DataItem, "restaurantLogo").ToString()
            Dim lbllogo As HyperLink = TryCast(e.Item.FindControl("restaurantLogo"), HyperLink)
            lbllogo.NavigateUrl = rLogo
            lbllogo.Text = "Restaurant Logo"
            lbllogo.Target = "_blank"

            Dim rLicense As String = DataBinder.Eval(e.Item.DataItem, "businessLicense").ToString()
            Dim lblLicense As HyperLink = TryCast(e.Item.FindControl("businessLicense"), HyperLink)
            lblLicense.NavigateUrl = rLicense
            lblLicense.Text = "Business License"
            lblLicense.Target = "_blank"

            Dim rhalal As String = DataBinder.Eval(e.Item.DataItem, "halal").ToString()
            Dim lblhalal As HyperLink = TryCast(e.Item.FindControl("halal"), HyperLink)
            lblhalal.NavigateUrl = rhalal
            lblhalal.Text = "Halal License"
            lblhalal.Target = "_blank"

            'If (DataBinder.Eval(e.Item.DataItem, "branchStatus").ToString() = "In Business") Then
            '    Dim btnDelete As Button = TryCast(e.Item.FindControl("btnDelete"), Button)
            '    btnDelete.Enabled = False
            'End If
        End If
    End Sub

    Protected Sub rptUser_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Dim myuser As User = New User()
        If (e.CommandName = "Approve") Then

            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String

            myuser.updateStatusDuringRegitration(e, "Approve", "restaurant")



            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is approved"
            Dim sb1 As New System.Text.StringBuilder()
            sb1.Append("<script type='text/javascript'>")
            sb1.Append("window.onload=function(){")
            sb1.Append("alert('")
            sb1.Append(message1)
            sb1.Append("');window.location='adminstratorManageRegistrations.aspx';};")
            sb1.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb1.ToString())

            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))


            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Registration Request---Approved"
            Dim body As String = "Dear customer , we are pleased to inform you that your registration request has been approved, we are looking forward to starting business with you."
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='adminstratorManageRegistrations.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())

            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='adminstratorManageRegistrations.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If


        ElseIf (e.CommandName = "Reject") Then

            Dim mail As New SMTP()
            Dim message1 As String
            Dim message2 As String
            Dim message3 As String

            myuser.updateStatusDuringRegitration(e, "Reject", "restaurant")


            message1 = "User ID " & Convert.ToInt32(e.CommandArgument) & " is rejected"
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type='text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message1)
            sb.Append("');window.location='adminstratorManageRegistrations.aspx';};")
            sb.Append("</script>")

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())



            Dim clsUserInfo As Customer = New Customer()
            Dim user As Customer = clsUserInfo.GetCustomerDetail(Convert.ToInt32(e.CommandArgument))

            Dim ToAddressies As String() = {user.email}
            Dim attachs() As String = {}
            Dim subject As String = "Registration Request---Rejected"
            Dim body As String = "Dear customer , we are sorry to inform you that your request is rejected"
            Dim result As Boolean = mail.SendMail(ToAddressies, subject, body, attachs)
            If result Then
                message2 = "Email is sent "
                Dim sb2 As New System.Text.StringBuilder()
                sb2.Append("<script type='text/javascript'>")
                sb2.Append("window.onload=function(){")
                sb2.Append("alert('")
                sb2.Append(message2)
                sb2.Append("');window.location='adminstratorManageRegistrations.aspx';};")
                sb2.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
            Else
                message3 = "Email is not sent,please check Email address"
                Dim sb3 As New System.Text.StringBuilder()
                sb3.Append("<script type='text/javascript'>")
                sb3.Append("window.onload=function(){")
                sb3.Append("alert('")
                sb3.Append(message3)
                sb3.Append("');window.location='adminstratorManageRegistrations.aspx';};")
                sb3.Append("</script>")
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb3.ToString())
            End If
        End If


    End Sub
End Class