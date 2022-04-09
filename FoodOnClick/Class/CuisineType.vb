Imports System.Data.SqlClient

Public Class CuisineType
    Protected int_cuisineTypeID As String
    Protected str_foodType As String
    Protected str_status As String

    Public Property cuisineTypeID() As String
        Get
            cuisineTypeID = int_cuisineTypeID
        End Get
        Set(ByVal value As String)
            int_cuisineTypeID = value
        End Set

    End Property

    Public Property foodType() As String
        Get
            foodType = str_foodType
        End Get
        Set(ByVal value As String)
            str_foodType = value
        End Set

    End Property

    Public Property status() As String
        Get
            status = str_status
        End Get
        Set(ByVal value As String)
            str_status = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Function getCuisineType()
        Dim returnObject As List(Of CuisineType) = New List(Of CuisineType)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT * FROM CUISINETYPE"
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
                    Dim tempobj As CuisineType = New CuisineType()
                    While reader.Read()
                        tempobj.cuisineTypeID = reader("cuisine_Typeid")
                        tempobj.foodType = reader("foodType")
                        tempobj.status = reader("status")
                        returnObject.Add(tempobj)
                        tempobj = New CuisineType()

                    End While
                Catch ex As SqlException

                End Try

            End Using

        End Using

        Return returnObject
    End Function


    Public Sub AddCuisineType(ByVal inputCuisineType As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "INSERT INTO dbo.CuisineType VALUES(@newfoodType,'Enabled'); "
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                conn.Open()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.AddWithValue("@newfoodType", inputCuisineType)
                    .ExecuteNonQuery()
                End With


            End Using

        End Using

    End Sub


    Public Sub EnableCuisineType(ByVal inputID As Int32)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE dbo.CuisineType SET status='Enabled' WHERE cuisine_Typeid=@changeCuisineID;"
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                conn.Open()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.AddWithValue("@changeCuisineID", inputID)
                    .ExecuteNonQuery()
                End With


            End Using

        End Using

    End Sub

    Public Sub DisableCuisineType(ByVal inputID As Int32)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE dbo.CuisineType SET status='Disabled' WHERE cuisine_Typeid=@changeCuisineID;"
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                conn.Open()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.AddWithValue("@changeCuisineID", inputID)
                    .ExecuteNonQuery()
                End With


            End Using

        End Using

    End Sub


End Class
