Imports System.Configuration
Imports System.Data.SqlClient

Public Class Rider
    Inherits User

    Protected str_type As String
    Protected str_userStatus As String
    Protected str_deliveryStatus As String
    Protected int_totalOrder As Int32
    Protected double_totalDeliveryCharges As Double


    Public Property type() As String
        Get
            type = str_type
        End Get
        Set(ByVal Value As String)
            str_type = Value
        End Set
    End Property
    Public Property deliveryStatus() As String
        Get
            deliveryStatus = str_deliveryStatus
        End Get
        Set(ByVal Value As String)
            str_deliveryStatus = Value
        End Set
    End Property




    Public Property userStatus() As String
        Get
            userStatus = str_userStatus
        End Get
        Set(ByVal Value As String)
            str_userStatus = Value
        End Set
    End Property




    Public Property totalOrder() As Int32
        Get
            totalOrder = int_totalOrder
        End Get
        Set(ByVal Value As Int32)
            int_totalOrder = Value
        End Set
    End Property

    Public Property totalDeliveryCharges() As Double
        Get
            totalDeliveryCharges = double_totalDeliveryCharges
        End Get
        Set(ByVal Value As Double)
            double_totalDeliveryCharges = Value
        End Set
    End Property



    Public Sub New()
    End Sub
    Public Sub New(ByVal sFirstName As String, ByVal sLastName As String, ByVal sAddress As String, ByVal sContactNo As String _
            , ByVal sGender As String, ByVal sDOB As String, ByVal sType As String, ByVal sUsername As String, ByVal sPass As String, ByVal sEmail As String)
        MyBase.New(sFirstName, sLastName, sAddress, sContactNo, sGender, sDOB, sType, sUsername, sPass, sEmail)
        'str_type = "customer"
    End Sub

    Public Sub InsertRider()
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

    Public Function getUserId()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        Dim userid1 As Integer

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            cmd = New SqlCommand("select MAX(userid) from UserAccount where type = 'Rider' ", conn)
            userid1 = cmd.ExecuteScalar()

            conn.Close()
        End Using
        Return userid1
    End Function


    Public Function uploadRiderDocuments(url, type)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "insert into Document (type, url, userid) values (@type, @url, @userid) "
        getUserId()

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@type", SqlDbType.NVarChar).Value = type
                    .Parameters.Add("@url", SqlDbType.NVarChar).Value = url
                    .Parameters.Add("@userid", SqlDbType.Int).Value = getUserId()
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                End Try
            End Using
        End Using
    End Function



    Public Function GetRiderDetailByAdmin()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Rider) = New List(Of Rider)
        Dim Query As String = "select useraccount.userid,firstname,lastname,address,phonenum,gender,dateofbirth,deliverystatus, statusafterapproved, count(OrderNum) as orderNum,COALESCE(sum(deliverycharges),0) as totalCharges from useraccount  left join rider on useraccount.userid=rider.userid left join orders on rider.riderid=orders.riderid where type='rider' and statusafterapproved is not null group by useraccount.userid,firstname,lastname,address,phonenum,gender,dateofbirth,deliverystatus, statusafterapproved"
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
                    Dim tempobj As Rider = New Rider()
                    While reader.Read()
                        tempobj.userId = reader("userid")
                        tempobj.firstName = reader("firstname")
                        tempobj.lastName = reader("lastname")
                        tempobj.address = reader("address")
                        tempobj.phone = reader("phoneNum")
                        tempobj.gender = reader("gender")
                        tempobj.dateOfBirth = reader("dateofbirth")
                        tempobj.deliveryStatus = reader("deliverystatus")
                        tempobj.userStatus = reader("statusafterapproved")
                        tempobj.totalOrder = reader("OrderNum")
                        tempobj.totalDeliveryCharges = reader("totalCharges")


                        returnObject.Add(tempobj)
                        tempobj = New Rider()
                    End While
                    Dim tempobj1 As Document = New Document()
                Catch ex As SqlException

                End Try
            End Using
        End Using





        Return returnObject
    End Function



End Class
