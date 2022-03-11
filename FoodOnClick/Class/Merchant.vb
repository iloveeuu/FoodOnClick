Imports System.Configuration
Imports System.Data.SqlClient

Public Class Merchant
    Inherits User

    Protected str_type As String

    Public Property type() As String
        Get
            type = str_type
        End Get
        Set(ByVal Value As String)
            str_type = Value
        End Set
    End Property

    Public Sub New(ByVal sFirstName As String, ByVal sLastName As String, ByVal sAddress As String, ByVal sContactNo As String _
            , ByVal sGender As String, ByVal sDOB As String, ByVal sType As String, ByVal sUsername As String, ByVal sPass As String, ByVal sEmail As String)
        MyBase.New(sFirstName, sLastName, sAddress, sContactNo, sGender, sDOB, sType, sUsername, sPass, sEmail)
        'str_type = "customer"
    End Sub

    Public Sub InsertMerchant()
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
                    .Parameters.Add("@Type", SqlDbType.VarChar).Value = MyBase.str_type
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


End Class
