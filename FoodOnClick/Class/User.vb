Imports System.Data.SqlClient

Public Class User
    Protected int_userId As Integer
    Protected str_firstName As String
    Protected str_lastName As String
    Protected str_address As String
    Protected str_phone As String
    Protected str_gender As String
    Protected str_dateOfBirth As String
    Protected str_type As String
    Protected str_username As String
    Protected str_password As String
    Protected str_email As String
    Public Property userId() As Integer
        Get
            userId = int_userId
        End Get
        Set(ByVal Value As Integer)
            int_userId = Value
        End Set
    End Property
    Public Property firstName() As String
        Get
            firstName = str_firstName
        End Get
        Set(ByVal Value As String)
            str_firstName = Value
        End Set
    End Property
    Public Property lastName() As String
        Get
            lastName = str_lastName
        End Get
        Set(ByVal Value As String)
            str_lastName = Value
        End Set
    End Property
    Public Property address() As String
        Get
            address = str_address
        End Get
        Set(ByVal Value As String)
            str_address = Value
        End Set
    End Property
    Public Property phone() As String
        Get
            phone = str_phone
        End Get
        Set(ByVal Value As String)
            str_phone = Value
        End Set
    End Property
    Public Property gender() As String
        Get
            gender = str_gender
        End Get
        Set(ByVal Value As String)
            str_gender = Value
        End Set
    End Property
    Public Property dateOfBirth() As String
        Get
            dateOfBirth = str_dateOfBirth
        End Get
        Set(ByVal Value As String)
            str_dateOfBirth = Value
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
    Public Property username() As String
        Get
            username = str_username
        End Get
        Set(ByVal Value As String)
            str_username = Value
        End Set
    End Property
    Public Property password() As String
        Get
            password = str_password
        End Get
        Set(ByVal Value As String)
            str_password = Value
        End Set
    End Property

    Public Property email() As String
        Get
            email = str_email
        End Get
        Set(ByVal Value As String)
            str_email = Value
        End Set
    End Property

    Public Sub New()
        str_firstName = ""
        str_lastName = ""
        str_address = ""
        str_phone = ""
        str_gender = ""
        str_dateOfBirth = ""
        str_type = ""
        str_username = ""
        str_password = ""
    End Sub
    Public Sub New(ByVal userid As Integer)
        Me.userId = userid
    End Sub

    Public Sub New(ByVal username As String, ByVal password As String)
        str_username = username
        str_password = password
    End Sub

    Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal address As String, ByVal phone As Integer, ByVal gender As String, ByVal dateOfBirth As String, ByVal type As String, ByVal username As String, ByVal password As String, ByVal email As String)
        str_firstName = firstName
        str_lastName = lastName
        str_address = address
        str_phone = phone
        str_gender = gender
        str_dateOfBirth = dateOfBirth
        str_type = type
        str_username = username
        str_password = password
        str_email = email
    End Sub
    Public Sub New(ByVal email As String)
        Me.email = email
    End Sub
    Public Function getResId() As String
        Dim returnMsg As String = ""
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT restaurantid from restaurant join useraccount on restaurant.userid = useraccount.userid where useraccount.userid = @id"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@id", SqlDbType.NVarChar).Value = Me.userId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnMsg = reader("restaurantid")
                    End While

                Catch ex As SqlException
                    returnMsg = ex.Message
                End Try
            End Using
        End Using
        Return returnMsg
    End Function

    Public Function CheckUserLoginAccess() As String
        Dim returnMsg As String = ""
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT * from UserAccount where LOWER(email) = @email and password = @password and LOWER(status) = 'approved'"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@email", SqlDbType.NVarChar).Value = Me.str_username.ToLower()
                    .Parameters.Add("@password", SqlDbType.NVarChar).Value = Me.str_password
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnMsg = reader("type")
                        System.Web.HttpContext.Current.Session("userid") = reader("userid")
                        System.Web.HttpContext.Current.Session("firstname") = reader("firstName")
                        System.Web.HttpContext.Current.Session("lastname") = reader("lastName")
                        System.Web.HttpContext.Current.Session("address") = reader("address")
                        System.Web.HttpContext.Current.Session("phonenum") = reader("phoneNum")
                        System.Web.HttpContext.Current.Session("gender") = reader("gender")
                        System.Web.HttpContext.Current.Session("dateofbirth") = reader("dateofBirth")
                        System.Web.HttpContext.Current.Session("type") = reader("type")
                        System.Web.HttpContext.Current.Session("email") = reader("email")
                    End While

                Catch ex As SqlException
                    returnMsg = ex.Message
                End Try
            End Using
        End Using
        Return returnMsg
    End Function

    Public Function addNewUserAccount(txtFirstName, txtlastName, txtAddress, txtContactNo, txtGender, txtDOB, accountType, txtPass, txtEmail, status) As Boolean

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        con.ConnectionString = connectionString
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select * from UserAccount where email = '" & txtEmail & "'"
        Dim returnValue As Boolean

        dr = cmd.ExecuteReader
        If dr.HasRows Then
            returnValue = False
            con.Close()
        Else
            con.Close()

            con.Open()
            Dim pass As Encryption = New Encryption(txtPass)
            Dim encrypted As String = pass.Encrypt()

            cmd = New SqlCommand("INSERT INTO UserAccount
                                 values ('" & txtFirstName & "','" & txtlastName & "',
                                 '" & txtAddress & "', '" & txtContactNo & "', '" & txtGender & "'
                                 ,'" & txtDOB & "', '" & accountType & "'
                                 ,'" & encrypted & "' ,'" & txtEmail & "', '" & status & "')", con)


            cmd.ExecuteNonQuery()
            'MsgBox("Successfully Stored", MsgBoxStyle.Information, "Success")
            returnValue = True
            con.Close()
        End If
        Return returnValue
    End Function

    Public Function ForgetPassword() As String
        Dim returnMsg As String = "False"
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT * from UserAccount where LOWER(email) = @email and LOWER(status) = 'approved'"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@email", SqlDbType.NVarChar).Value = Me.email.ToLower()
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    If reader.HasRows() Then
                        returnMsg = "True"
                    End If
                    conn.Close()
                Catch ex As SqlException
                    returnMsg = "False"
                End Try
                If (returnMsg = "True") Then
                    Try
                        Query = "UPDATE useraccount set password =@password where LOWER(email) = @email1"
                        Dim rawPassword As String = Guid.NewGuid().ToString("N").Substring(0, 6)
                        Dim pass As Encryption = New Encryption(rawPassword)
                        Dim encrypted As String = pass.Encrypt()
                        With comm
                            Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = Query
                            .Parameters.Add("@password", SqlDbType.NVarChar).Value = encrypted
                            .Parameters.Add("@email1", SqlDbType.NVarChar).Value = Me.email.ToLower()
                        End With
                        conn.Open()
                        comm.ExecuteNonQuery()
                        conn.Close()
                        returnMsg = rawPassword
                    Catch ex As SqlException
                        returnMsg = "False"
                    End Try
                End If

            End Using
        End Using
        Return returnMsg
    End Function



End Class
