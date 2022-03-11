Imports System.Configuration
Imports System.Data.SqlClient

Public Class Restaurant
    Inherits User

    Protected str_type As String
    Protected int_restaurantId As Integer
    Protected str_restaurantName As String
    Protected str_restaurantType As String


    Public Property restaurantId() As Integer
        Get
            restaurantId = int_restaurantId
        End Get
        Set(ByVal Value As Integer)
            int_restaurantId = Value
        End Set
    End Property

    Public Property restaurantName() As String
        Get
            restaurantName = str_restaurantName
        End Get
        Set(ByVal Value As String)
            str_restaurantName = Value
        End Set
    End Property
    Public Property restaurantType() As String
        Get
            restaurantType = str_restaurantType
        End Get
        Set(ByVal Value As String)
            str_restaurantType = Value
        End Set
    End Property
    Public Property type() As String
        Get
            type = str_type
        End Get
        Set(ByVal Value As String)
            str_type = Value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal username As String, ByVal password As String)
        MyBase.New(username, password)
        str_type = "Restaurant"
    End Sub

    Public Sub InsertRestaurant()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "INSERT INTO Account (Username, Password, Type) VALUES (@username, @Name, @Type) "
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@username", SqlDbType.NVarChar).Value = MyBase.str_username
                    .Parameters.Add("@Name", SqlDbType.NVarChar).Value = MyBase.str_password
                    .Parameters.Add("@Type", SqlDbType.VarChar).Value = str_type
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
    End Sub
    Public Function RetrieveRestaurantInfo()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Restaurant) = New List(Of Restaurant)
        Dim Query As String = "SELECT * from restaurant where userId = @userid"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userid", SqlDbType.Int).Value = Me.userId
                End With
                Try
                    'Dim tempObj As Restaurant = New Restaurant()
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Me.restaurantId = reader("restaurantId")
                        Me.restaurantName = reader("name")
                        Me.restaurantType = reader("type")
                        Me.userId = reader("userId")
                        returnObject.Add(Me)
                    End While

                Catch ex As SqlException

                End Try
            End Using
        End Using
        Return returnObject
    End Function


End Class
