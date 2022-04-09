Imports System.Data.SqlClient

Public Class Document
    Inherits User
    Protected str_restaurantLogo As String
    Protected str_businessLicense As String
    Protected str_halal As String

    Public Property restaurantLogo() As String
        Get
            restaurantLogo = str_restaurantLogo
        End Get
        Set(ByVal Value As String)
            str_restaurantLogo = Value
        End Set
    End Property
    Public Property businessLicense() As String
        Get
            businessLicense = str_businessLicense
        End Get
        Set(ByVal Value As String)
            str_businessLicense = Value
        End Set
    End Property
    Public Property halal() As String
        Get
            halal = str_halal
        End Get
        Set(ByVal Value As String)
            str_halal = Value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal userid As Int32)
        MyBase.userId = userid
    End Sub

    Public Function GetRestaurantDocument()
        Dim returnMsg As String = "False"
        Dim returnObject As List(Of Document) = New List(Of Document)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT useraccount.userid,firstname,lastname,phoneNum,email,document.type,url from document join useraccount on document.userid = useraccount.userid where useraccount.status = 'VETTING' and useraccount.type = 'Restaurant'  order by document.userid asc"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    Dim counter As Integer = 1
                    Dim tempobj As Document = New Document()
                    While reader.Read()
                        tempobj.userId = reader("userid")
                        tempobj.firstName = reader("firstname")
                        tempobj.lastName = reader("lastname")
                        tempobj.phone = reader("phoneNum")
                        tempobj.email = reader("email")
                        tempobj.type = reader("type")
                        If (reader("type") = "Restaurant Logo") Then
                            tempobj.restaurantLogo = reader("url")
                        ElseIf (reader("type") = "Business License") Then
                            tempobj.businessLicense = reader("url")
                        ElseIf (reader("type") = "Halal") Then
                            tempobj.halal = reader("url")
                        End If
                        If (counter Mod 3 = 0) Then
                            returnObject.Add(tempobj)
                            tempobj = New Document()
                        End If
                        counter += 1
                    End While
                    Dim tempobj1 As Document = New Document()
                Catch ex As SqlException

                End Try
            End Using
        End Using
        Return returnObject
    End Function
    Public Function GetCountRestaurantUser()
        Dim returnInt As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "Select COUNT(DISTINCT(dbo.document.userid)) As COUNT FROM dbo.document join dbo.UserAccount On dbo.UserAccount.userid=dbo.document.userid where dbo.UserAccount.status='VETTING' and dbo.UserAccount.type = 'Restaurant'"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnInt = Convert.ToInt32(reader("COUNT"))
                    End While
                Catch ex As SqlException

                End Try
            End Using
        End Using
        Return returnInt
    End Function
End Class
