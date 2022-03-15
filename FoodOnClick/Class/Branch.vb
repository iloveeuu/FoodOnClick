Imports System.Data.SqlClient

Public Class Branch
    Inherits Restaurant
    Protected int_branchId As Integer
    Protected str_branchAddress As String
    Protected str_halal As String
    Protected str_branchPostalcode As String
    Protected str_branchStatus As String
    Protected str_branchCity As String
    Protected int_branchCuisineId As Integer
    Protected str_branchCuisine As String
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
#End Region
    Public Sub New()
    End Sub
    Public Sub New(ByVal userId As Integer, ByVal restaurantId As Integer)
        MyBase.userId = userId
        MyBase.restaurantId = restaurantId
    End Sub
    Public Sub New(ByVal branchid As Integer)
        Me.branchId = branchid
    End Sub
    Public Sub New(ByVal halal As String, ByVal restaurantId As Integer, ByVal address As String, ByVal postalCode As String, ByVal status As String, ByVal city As String, ByVal cuisineid As String, Optional ByVal branchid As Integer = 0)
        Me.halal = halal
        MyBase.restaurantId = restaurantId
        Me.branchAddress = address
        Me.branchPostalcode = postalCode
        Me.branchStatus = status
        Me.branchCity = city
        Me.branchCuisineId = cuisineid
        Me.branchId = branchid
    End Sub

    Public Function UpdateBranch() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE Branch set city = @city, postalCode = @postalcode, address = @address, cuisineTypeID = @cuisineid, halal = @halal, status = @status where branchid = @branchid"
        Dim bool As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
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
        Dim Query As String = "INSERT INTO branch values(@city,@postalcode,@address,@cuisineid,@halal,@status,@restaurantid)"
        Dim bool As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
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
                        returnObject.branchCity = reader("city")
                        returnObject.branchPostalcode = reader("postalCode")
                        returnObject.branchAddress = reader("address")
                        returnObject.branchCuisineId = reader("cuisineTypeID")
                        returnObject.halal = reader("halal")
                        returnObject.branchStatus = reader("status")
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
End Class
