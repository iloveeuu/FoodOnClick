Imports System.Data.SqlClient

Public Class Branch
    Inherits Restaurant
    Protected int_branchId As Integer
    Protected str_branchEmail As String
    Protected str_branchPassword As String
    Protected str_branchAddress As String
    Protected str_halal As String
    Protected str_branchPostalcode As String
    Protected str_branchStartTime As String
    Protected str_branchEndTime As String
    Protected str_branchStatus As String
    Protected str_branchCity As String
    Protected int_branchCuisineId As Integer
    Protected str_branchCuisine As String
    Protected str_branchReservation As String
    Protected str_branchdrivethru As String
#Region "Objects"
    Public Property branchId() As Integer
        Get
            branchId = int_branchId
        End Get
        Set(ByVal Value As Integer)
            int_branchId = Value
        End Set
    End Property
    Public Property branchCuisineId() As Integer
        Get
            branchCuisineId = int_branchCuisineId
        End Get
        Set(ByVal Value As Integer)
            int_branchCuisineId = Value
        End Set
    End Property

    Public Property branchAddress() As String
        Get
            branchAddress = str_branchAddress
        End Get
        Set(ByVal Value As String)
            str_branchAddress = Value
        End Set
    End Property
    Public Property branchPassword() As String
        Get
            branchPassword = str_branchPassword
        End Get
        Set(ByVal Value As String)
            str_branchPassword = Value
        End Set
    End Property
    Public Property branchStartTime() As String
        Get
            branchStartTime = str_branchStartTime
        End Get
        Set(ByVal Value As String)
            str_branchStartTime = Value
        End Set
    End Property
    Public Property branchEndTime() As String
        Get
            branchEndTime = str_branchEndTime
        End Get
        Set(ByVal Value As String)
            str_branchEndTime = Value
        End Set
    End Property
    Public Property branchEmail() As String
        Get
            branchEmail = str_branchEmail
        End Get
        Set(ByVal Value As String)
            str_branchEmail = Value
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
    Public Property branchPostalcode() As String
        Get
            branchPostalcode = str_branchPostalcode
        End Get
        Set(ByVal Value As String)
            str_branchPostalcode = Value
        End Set
    End Property
    Public Property branchStatus() As String
        Get
            branchStatus = str_branchStatus
        End Get
        Set(ByVal Value As String)
            str_branchStatus = Value
        End Set
    End Property
    Public Property branchCity() As String
        Get
            branchCity = str_branchCity
        End Get
        Set(ByVal Value As String)
            str_branchCity = Value
        End Set
    End Property
    Public Property branchCuisine() As String
        Get
            branchCuisine = str_branchCuisine
        End Get
        Set(ByVal Value As String)
            str_branchCuisine = Value
        End Set
    End Property

    Public Property branchReservation() As String
        Get
            branchReservation = str_branchReservation
        End Get
        Set(ByVal Value As String)
            str_branchReservation = Value
        End Set
    End Property

    Public Property branchdrivethru() As String
        Get
            branchdrivethru = str_branchdrivethru
        End Get
        Set(ByVal Value As String)
            str_branchdrivethru = Value
        End Set
    End Property
#End Region
    Public Sub New()
    End Sub
    Public Sub New(ByVal userId As Integer, ByVal restaurantId As Integer)
        MyBase.userId = userId
        MyBase.restaurantId = restaurantId
    End Sub

    Public Sub New(ByVal email As String, ByVal password As String)
        Me.branchEmail = email
        Me.branchPassword = password
    End Sub

    Public Sub New(ByVal branchid As Integer)
        Me.branchId = branchid
    End Sub
    Public Sub New(ByVal reservation As String, ByVal drivethru As String, ByVal email As String, ByVal password As String, ByVal startTime As String, ByVal endTime As String, ByVal halal As String, ByVal restaurantId As Integer, ByVal address As String, ByVal postalCode As String, ByVal status As String, ByVal city As String, ByVal cuisineid As String, Optional ByVal branchid As Integer = 0)
        Me.branchReservation = reservation
        Me.branchdrivethru = drivethru
        Me.branchEmail = email
        Me.branchPassword = password
        Me.branchStartTime = startTime
        Me.branchEndTime = endTime
        Me.halal = halal
        MyBase.restaurantId = restaurantId
        Me.branchAddress = address
        Me.branchPostalcode = postalCode
        Me.branchStatus = status
        Me.branchCity = city
        Me.branchCuisineId = cuisineid
        Me.branchId = branchid
    End Sub

    Public Function CheckBranchLogin() As String
        Dim returnMsg As String = "False"
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT branchid, email, restaurantid from branch where LOWER(email) = @email and branchPassword = @password"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@email", SqlDbType.NVarChar).Value = Me.branchEmail.ToLower()
                    .Parameters.Add("@password", SqlDbType.NVarChar).Value = Me.branchPassword
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnMsg = "True"
                        System.Web.HttpContext.Current.Session("branchid") = reader("branchid")
                        System.Web.HttpContext.Current.Session("userid") = 0
                        System.Web.HttpContext.Current.Session("firstname") = reader("email")
                        System.Web.HttpContext.Current.Session("restaurantid") = reader("restaurantid")
                    End While

                Catch ex As SqlException

                End Try
            End Using
        End Using
        Return returnMsg
    End Function

    Public Function UpdateBranch() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE Branch set reservation=@reservation,drivethru=@drivethru, email=@branchEmail, branchPassword = @branchPassword, time_open=@startTime, time_closed = @endTime, city = @city, postalCode = @postalcode, address = @address, cuisineTypeID = @cuisineid, halal = @halal, status = @status where branchid = @branchid"
        Dim bool As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@reservation", SqlDbType.VarChar).Value = Me.branchReservation
                    .Parameters.Add("@drivethru", SqlDbType.VarChar).Value = Me.branchdrivethru
                    .Parameters.Add("@branchEmail", SqlDbType.VarChar).Value = Me.branchEmail
                    .Parameters.Add("@branchPassword", SqlDbType.VarChar).Value = Me.branchPassword
                    .Parameters.Add("@startTime", SqlDbType.VarChar).Value = Me.branchStartTime
                    .Parameters.Add("@endTime", SqlDbType.VarChar).Value = Me.branchEndTime
                    .Parameters.Add("@halal", SqlDbType.VarChar).Value = Me.halal
                    .Parameters.Add("@restaurantid", SqlDbType.Int).Value = MyBase.restaurantId
                    .Parameters.Add("@address", SqlDbType.VarChar).Value = Me.branchAddress
                    .Parameters.Add("@postalcode", SqlDbType.VarChar).Value = Me.branchPostalcode
                    .Parameters.Add("@status", SqlDbType.VarChar).Value = Me.branchStatus
                    .Parameters.Add("@city", SqlDbType.VarChar).Value = Me.branchCity
                    .Parameters.Add("@cuisineid", SqlDbType.VarChar).Value = Me.branchCuisineId
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = Me.branchId
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                    bool = ex.Message
                End Try
            End Using
        End Using
        Return bool
    End Function
    Public Function DeleteBranch() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "DELETE FROM Branch where branchid = @branchid and status <> 'In Business'"
        Dim bool As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = Me.branchId
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                    bool = ex.Message
                End Try
            End Using
        End Using
        Return bool
    End Function

    Public Function CreateBranch() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "INSERT INTO branch values(@city,@postalcode,@address,@cuisineid,@halal,@status,@restaurantid,@startTime,@endTime,@branchEmail,@branchPassword,@reservation,@drivethru)"
        Dim bool As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@reservation", SqlDbType.VarChar).Value = Me.branchReservation
                    .Parameters.Add("@drivethru", SqlDbType.VarChar).Value = Me.branchdrivethru
                    .Parameters.Add("@branchEmail", SqlDbType.VarChar).Value = Me.branchEmail
                    .Parameters.Add("@branchPassword", SqlDbType.VarChar).Value = Me.branchPassword
                    .Parameters.Add("@startTime", SqlDbType.VarChar).Value = Me.branchStartTime
                    .Parameters.Add("@endTime", SqlDbType.VarChar).Value = Me.branchEndTime
                    .Parameters.Add("@halal", SqlDbType.VarChar).Value = Me.halal
                    .Parameters.Add("@restaurantid", SqlDbType.Int).Value = MyBase.restaurantId
                    .Parameters.Add("@address", SqlDbType.VarChar).Value = Me.branchAddress
                    .Parameters.Add("@postalcode", SqlDbType.VarChar).Value = Me.branchPostalcode
                    .Parameters.Add("@status", SqlDbType.VarChar).Value = Me.branchStatus
                    .Parameters.Add("@city", SqlDbType.VarChar).Value = Me.branchCity
                    .Parameters.Add("@cuisineid", SqlDbType.VarChar).Value = Me.branchCuisineId
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                    bool = ex.Message
                End Try
            End Using
        End Using
        Return bool
    End Function

    Public Function RetrieveAllCuisineType()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Branch) = New List(Of Branch)
        Dim Query As String = "SELECT * from CuisineType"
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
                        Dim tempobj As Branch = New Branch()
                        tempobj.branchCuisineId = reader("cuisine_Typeid")
                        tempobj.branchCuisine = reader("foodType")
                        returnObject.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function
    Public Function RetrieveAllBranchInfoByBranchId()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As Branch = New Branch
        Dim Query As String = "SELECT * from branch where branchid = @branchid"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@branchid", SqlDbType.VarChar).Value = Me.branchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnObject.branchEmail = reader("email")
                        returnObject.branchPassword = reader("branchPassword").ToString()
                        returnObject.branchStartTime = reader("time_open").ToString()
                        returnObject.branchEndTime = reader("time_closed").ToString()
                        returnObject.branchCity = reader("city")
                        returnObject.branchPostalcode = reader("postalCode")
                        returnObject.branchAddress = reader("address")
                        returnObject.branchCuisineId = reader("cuisineTypeID")
                        returnObject.halal = reader("halal")
                        returnObject.branchStatus = reader("status")
                        returnObject.branchdrivethru = reader("drivethru")
                        returnObject.branchReservation = reader("reservation")
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function

    Public Function RetrieveBranchInfo()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Branch) = New List(Of Branch)
        Dim Query As String = "SELECT * from branch join restaurant on userId = @userid join CuisineType on CuisineType.cuisine_Typeid = Branch.cuisineTypeID where branch.restaurantId = @restaurantid"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userid", SqlDbType.Int).Value = MyBase.userId
                    .Parameters.Add("@restaurantid", SqlDbType.Int).Value = MyBase.restaurantId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Dim tempobj As Branch = New Branch()
                        tempobj.branchId = reader("branchId")
                        tempobj.branchAddress = reader("address")
                        tempobj.halal = reader("halal")
                        tempobj.branchPostalcode = reader("postalcode")
                        tempobj.branchStatus = reader("status")
                        tempobj.branchCuisine = reader("foodType")
                        tempobj.branchCity = reader("city")
                        tempobj.restaurantId = reader("restaurantId")
                        tempobj.restaurantName = reader("name")
                        tempobj.restaurantType = reader("description")
                        tempobj.userId = reader("userId")
                        returnObject.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function

    Public Function RetrieveRestaurantBranchInfoByBranchId()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As Branch = New Branch
        Dim Query As String = "SELECT * from branch join restaurant on restaurant.restaurantid = branch.restaurantid where branch.branchid = @branchid"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = Me.branchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnObject.branchId = reader("branchId")
                        returnObject.branchAddress = reader("address")
                        returnObject.halal = reader("halal")
                        returnObject.branchPostalcode = reader("postalcode")
                        returnObject.branchStatus = reader("status")
                        returnObject.branchCuisineId = reader("cuisineTypeID")
                        returnObject.branchCity = reader("city")
                        returnObject.restaurantId = reader("restaurantId")
                        returnObject.restaurantName = reader("name")
                        returnObject.restaurantType = reader("description")
                        returnObject.userId = reader("userId")
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function
End Class
