Imports System.Configuration
Imports System.Data.SqlClient

Public Class Merchant
    Inherits User

    Protected str_type As String

    Protected str_userStatus As String
    Protected int_TotalRestaurant As Int32
    Protected int_TotalOrders As Int32


    Public Property type() As String
        Get
            type = str_type
        End Get
        Set(ByVal Value As String)
            str_type = Value
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

    Public Property TotalRestaurant() As Int32
        Get
            TotalRestaurant = int_TotalRestaurant
        End Get
        Set(ByVal Value As Int32)
            int_TotalRestaurant = Value
        End Set
    End Property

    Public Property TotalOrders() As Int32
        Get
            TotalOrders = int_TotalOrders
        End Get
        Set(ByVal Value As Int32)
            int_TotalOrders = Value
        End Set
    End Property


    Public Sub New(ByVal sFirstName As String, ByVal sLastName As String, ByVal sAddress As String, ByVal sContactNo As String _
            , ByVal sGender As String, ByVal sDOB As String, ByVal sType As String, ByVal sUsername As String, ByVal sPass As String, ByVal sEmail As String)
        MyBase.New(sFirstName, sLastName, sAddress, sContactNo, sGender, sDOB, sType, sUsername, sPass, sEmail)
        'str_type = "customer"
    End Sub


    Public Sub New()

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


    Public Function GetRestaurantDetailByAdmin()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Merchant) = New List(Of Merchant)
        Dim Query As String = "select useraccount.userid,firstname,lastname,address,phonenum,gender,dateofbirth, statusafterapproved, count(restaurantID) as restaurantNo, count(batchid) as orderNumber  from useraccount  left join restaurant on useraccount.userid=restaurant.userid left join batchorders on useraccount.userid=batchorders.batchid where type='restaurant' and statusafterapproved is not null group by useraccount.userid,firstname,lastname,address,phonenum,gender,dateofbirth, statusafterapproved"
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
                    Dim tempobj As Merchant = New Merchant()
                    While reader.Read()
                        tempobj.userId = reader("userid")
                        tempobj.firstName = reader("firstname")
                        tempobj.lastName = reader("lastname")
                        tempobj.address = reader("address")
                        tempobj.phone = reader("phoneNum")
                        tempobj.gender = reader("gender")
                        tempobj.dateOfBirth = reader("dateofbirth")
                        tempobj.userStatus = reader("statusafterapproved")
                        tempobj.TotalRestaurant = reader("restaurantNo")
                        tempobj.TotalOrders = reader("orderNumber")


                        returnObject.Add(tempobj)
                        tempobj = New Merchant()
                    End While
                    Dim tempobj1 As Merchant = New Merchant()
                Catch ex As SqlException

                End Try
            End Using
        End Using





        Return returnObject
    End Function



End Class
