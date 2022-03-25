Imports System.Configuration
Imports System.Data.SqlClient

Public Class Customer

    Inherits User

    'Protected str_type As String

    'Public Property type() As String
    '    Get
    '        type = str_type
    '    End Get
    '    Set(ByVal Value As String)
    '        str_type = Value
    '    End Set
    'End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal sFirstName As String, ByVal sLastName As String, ByVal sAddress As String, ByVal sContactNo As String _
            , ByVal sGender As String, ByVal sDOB As String, ByVal sType As String, ByVal sUsername As String, ByVal sPass As String, ByVal sEmail As String)
        MyBase.New(sFirstName, sLastName, sAddress, sContactNo, sGender, sDOB, sType, sUsername, sPass, sEmail)
        'str_type = "customer"
    End Sub

    Public Sub InsertCustomer()
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

    Public Sub UpdateCustomer(ByVal sFirstName As String, ByVal sLastName As String, ByVal sAddress As String, ByVal iContactNo As Int32 _
            , ByVal sGender As String, ByVal sDOB As String, ByVal sEmail As String, ByVal iUserID As Int32)

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "Update UserAccount set firstname=@firstname, lastname=@lastname, address=@address, " &
                            "phoneNum=@phoneNum, gender=@gender, dateOfBirth=@dateOfBirth " &
                            "where email=@email and userid=@userId "
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@firstname", SqlDbType.NVarChar).Value = sFirstName
                    .Parameters.Add("@lastname", SqlDbType.NVarChar).Value = sLastName
                    .Parameters.Add("@address", SqlDbType.NVarChar).Value = sAddress
                    .Parameters.Add("@phoneNum", SqlDbType.BigInt).Value = iContactNo
                    .Parameters.Add("@gender", SqlDbType.NVarChar).Value = sGender
                    .Parameters.Add("@dateOfBirth", SqlDbType.NVarChar).Value = sDOB
                    .Parameters.Add("@email", SqlDbType.NVarChar).Value = sEmail
                    .Parameters.Add("@userId", SqlDbType.Int).Value = iUserID
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

    Public Sub UpdatePassword(ByVal sPass As String, ByVal sEmail As String, ByVal iUserID As Int32)

        Dim pass As Encryption = New Encryption(sPass)
        Dim encrypted As String = pass.Encrypt()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "Update UserAccount set " &
                            "password=@password " &
                            "where email=@email and userid=@userId "
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@password", SqlDbType.NVarChar).Value = encrypted
                    .Parameters.Add("@email", SqlDbType.NVarChar).Value = sEmail
                    .Parameters.Add("@userId", SqlDbType.Int).Value = iUserID
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

    Public Function GetCustomerDetail(ByVal iUserId As Int32)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As Customer = New Customer()
        Dim Query As String = "SELECT * from userAccount where userID = @userID "
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userID", SqlDbType.Int).Value = iUserId
                End With
                Try
                    'Dim tempObj As Restaurant = New Restaurant()
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnObject.str_firstName = reader("firstName")
                        returnObject.str_lastName = reader("lastName")
                        returnObject.str_email = reader("email")
                        returnObject.str_address = reader("address")
                        returnObject.str_phone = reader("phoneNum")
                        returnObject.str_gender = reader("gender")
                        returnObject.str_dateOfBirth = reader("dateOfBirth")
                    End While

                Catch ex As SqlException

                End Try
            End Using
        End Using
        Return returnObject
    End Function
End Class
