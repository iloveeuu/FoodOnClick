Imports System.Configuration
Imports System.Data.SqlClient

Public Class Reservation
    Inherits Branch

    Protected str_reservationId As Int32
    Protected str_preordermeals As String
    Protected dt_date As Date
    Protected str_time As String
    Protected int_pax As Int32
    Protected str_status As String
    Protected int_batchid As Int32
    Protected dec_tempCost As Decimal
    Protected dec_tempTotalCost As Decimal
    Protected str_tempPaymentType As String
    Protected dec_tempDeliveryCharges As Decimal
    Protected str_duration As String


#Region "Objects"
    Public Property reservationId() As Int32
        Get
            reservationId = str_reservationId
        End Get
        Set(ByVal Value As Int32)
            str_reservationId = Value
        End Set
    End Property

    Public Property preordermeals() As String
        Get
            preordermeals = str_preordermeals
        End Get
        Set(ByVal Value As String)
            str_preordermeals = Value
        End Set
    End Property

    Public Property dtdate() As Date
        Get
            dtdate = dt_date
        End Get
        Set(ByVal Value As Date)
            dt_date = Value
        End Set
    End Property

    Public Property strtime() As String
        Get
            strtime = str_time
        End Get
        Set(ByVal Value As String)
            str_time = Value
        End Set
    End Property

    Public Property pax() As Int32
        Get
            pax = int_pax
        End Get
        Set(ByVal Value As Int32)
            int_pax = Value
        End Set
    End Property

    Public Property status() As String
        Get
            status = str_status
        End Get
        Set(ByVal Value As String)
            str_status = Value
        End Set
    End Property

    Public Property branchId() As Int32
        Get
            branchId = int_branchId
        End Get
        Set(ByVal Value As Int32)
            int_branchId = Value
        End Set
    End Property

    Public Property userid() As Int32
        Get
            userid = int_userId
        End Get
        Set(ByVal Value As Int32)
            int_userId = Value
        End Set
    End Property

    Public Property batchid() As Int32
        Get
            batchid = int_batchid
        End Get
        Set(ByVal Value As Int32)
            int_batchid = Value
        End Set
    End Property

    Public Property tempCost() As Decimal
        Get
            tempCost = dec_tempCost
        End Get
        Set(ByVal Value As Decimal)
            dec_tempCost = Value
        End Set
    End Property

    Public Property tempTotalCost() As Decimal
        Get
            tempTotalCost = dec_tempTotalCost
        End Get
        Set(ByVal Value As Decimal)
            dec_tempTotalCost = Value
        End Set
    End Property
    Public Property tempPaymentType() As String
        Get
            tempPaymentType = str_tempPaymentType
        End Get
        Set(ByVal Value As String)
            str_tempPaymentType = Value
        End Set
    End Property

    Public Property tempDeliveryCharges() As Decimal
        Get
            tempDeliveryCharges = dec_tempDeliveryCharges
        End Get
        Set(ByVal Value As Decimal)
            dec_tempDeliveryCharges = Value
        End Set
    End Property

    Public Property duration() As String
        Get
            duration = str_duration
        End Get
        Set(ByVal Value As String)
            str_duration = Value
        End Set
    End Property


#End Region

    Public Sub New()
    End Sub


    Public Sub New(ByVal userid As Int32)
        Me.userid = userid
    End Sub

    Public Sub New(ByVal branchid As Integer, ByVal date1 As Date)
        Me.branchId = branchid
        Me.dtdate = date1
    End Sub

    Public Sub New(ByVal reservationid As Integer, ByVal status As String)
        Me.reservationId = reservationid
        Me.status = status
    End Sub

    Public Sub New(ByVal preordermeals As String, ByVal dtdate As Date,
                   ByVal strtime As String, ByVal pax As Int32,
                   ByVal status As String, ByVal branchId As Int32, ByVal userid As Int32, ByVal batchid As Int32, ByVal duration As String)
        Me.preordermeals = preordermeals
        Me.dtdate = dtdate
        Me.strtime = strtime
        Me.pax = pax
        Me.status = status
        Me.branchId = branchId
        Me.userid = userid
        Me.batchid = batchid
        Me.str_duration = duration
    End Sub

    Public Sub InsertReservation()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        If Me.str_preordermeals = "No" Then
            Query = "INSERT INTO Reservation (preordermeals, date, time, pax, status, branchId, userId, duration) " &
                            "VALUES (@preordermeals, @dtdate, @strtime, @pax, @status, @branchId, @userId, @duration) "
        Else
            Query = "INSERT INTO Reservation (preordermeals, date, time, pax, status, branchId, userId, batchid, duration) " &
                            "VALUES (@preordermeals, @dtdate, @strtime, @pax, @status, @branchId, @userId, " &
                            "@batchid, @duration) "
        End If

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@preordermeals", SqlDbType.NVarChar).Value = Me.str_preordermeals
                    .Parameters.Add("@dtdate", SqlDbType.Date).Value = Me.dt_date
                    .Parameters.Add("@strtime", SqlDbType.VarChar).Value = Me.str_time
                    .Parameters.Add("@pax", SqlDbType.Int).Value = Me.int_pax
                    .Parameters.Add("@status", SqlDbType.VarChar).Value = Me.str_status
                    .Parameters.Add("@branchId", SqlDbType.Int).Value = Me.int_branchId
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userid
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.batchid
                    .Parameters.Add("@duration", SqlDbType.Int).Value = Me.duration
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    conn.Close()

                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
    End Sub

    Public Function GetReservationHistory()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtReservation = New DataTable()

        Dim Query As String = "SELECT re.reservationId, b.email, r.name as restName, b.address, re.pax, re.date, re.time, re.status, ISNULL(re.batchid,'') as batchId, b.branchid, r.duration  from branch as b " &
                                " inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                " inner join reservation as re on re.branchId = b.branchId " &
                                " left join batchOrders as bo on bo.batchid = re.batchid " &
                                " where re.userID = @userId"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userid
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtReservation.Load(reader)
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return dtReservation
    End Function

    Public Sub GetLatestPendingReservationByUserID()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtReservation = New DataTable()

        Dim Query As String = "SELECT * from reservation " &
                                " where userID = @userId And status = 'Pending' "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userid
                End With
                Try
                    conn.Open()

                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        reservationId = reader("reservationId")
                        preordermeals = reader("preordermeals")
                        dtdate = reader("date")
                        strtime = reader("time")
                        pax = reader("pax")
                        status = reader("status")
                        branchId = reader("branchId")
                        userid = reader("userid")
                        batchid = reader("batchid")
                    End While

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
    End Sub

    Public Function CheckReservationPending()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim returnObject As Reservation = New Reservation

        Dim Query As String = "select top 1 status from reservation " &
                                " where userID = @userId And reservationID = @reservationID And status = 'Pending' "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userid
                    .Parameters.Add("@reservationID", SqlDbType.Int).Value = Me.reservationId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        returnObject.status = "Pending"
                    Else
                        returnObject.status = ""
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return returnObject
    End Function
    Public Sub CancelReservation()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtReservation = New DataTable()

        Dim Query As String = "Update reservation set status = 'Cancelled' " &
                                " where userID = @userId And reservationID = @reservationID And status = 'Pending' "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userid
                    .Parameters.Add("@reservationID", SqlDbType.Int).Value = Me.reservationId
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    conn.Close()
                Catch ex As SqlException
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
    Public Function GetReservationToday()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtReservation = New DataTable()

        Dim Query As String = "SELECT re.reservationid, re.preordermeals, re.pax, re.date, re.time, re.status, re.batchid, u.firstname from branch as b " &
                                " inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                " inner join reservation as re on re.branchId = b.branchId " &
                                " inner join useraccount as u on u.userid = re.userid where b.branchid = @branchid and date = @date order by time asc"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@date", SqlDbType.Date).Value = Me.dtdate
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = Me.branchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtReservation.Load(reader)
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return dtReservation
    End Function
    Public Function GetReservationUpcoming()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtReservation = New DataTable()

        Dim Query As String = "SELECT re.reservationid, re.preordermeals, re.pax, re.date, re.time, re.status, re.batchid, u.firstname from branch as b " &
                                " inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                " inner join reservation as re on re.branchId = b.branchId " &
                                " inner join useraccount as u on u.userid = re.userid where b.branchid = @branchid and date > @date order by date, time"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@date", SqlDbType.Date).Value = Me.dtdate
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = Me.branchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtReservation.Load(reader)
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return dtReservation
    End Function
    Public Function GetBranchReservationHistory()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtReservation = New DataTable()

        Dim Query As String = "SELECT re.reservationid, re.preordermeals, re.pax, re.date, re.time, re.status, u.firstname from branch as b " &
                                " inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                " inner join reservation as re on re.branchId = b.branchId " &
                                " inner join useraccount as u on u.userid = re.userid where b.branchid = @branchid and date < @date order by date, time"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@date", SqlDbType.Date).Value = Me.dtdate
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = Me.branchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtReservation.Load(reader)
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return dtReservation
    End Function

    Public Function UpdateReservation() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE Reservation set status =@status where reservationid = @id"
        Dim returnMsg As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@status", SqlDbType.NVarChar).Value = Me.status
                    .Parameters.Add("@id", SqlDbType.Int).Value = Me.reservationId

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    conn.Close()

                Catch ex As SqlException
                    returnMsg = ex.Message
                End Try
            End Using
        End Using
        Return returnMsg
    End Function

    Public Function RetrieveBatchOrderIdByReservationID() As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT batchid from reservation where reservationid = @id"
        Dim returnMsg As Integer = 0
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@id", SqlDbType.Int).Value = Me.reservationId

                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnMsg = reader("batchid")
                    End While
                    conn.Close()

                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnMsg
    End Function

    Public Function UpdateReservationOrder() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE Orders set orderstatusid =@status where batchid = @id"
        Dim returnMsg As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@status", SqlDbType.Int).Value = Convert.ToInt32(Me.status)
                    .Parameters.Add("@id", SqlDbType.Int).Value = Me.reservationId

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    conn.Close()

                Catch ex As SqlException
                    returnMsg = ex.Message
                End Try
            End Using
        End Using
        Return returnMsg
    End Function

    Public Function RetrieveReservationEmail() As Reservation
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT uc.firstName,uc.lastName,uc.phoneNum,uc.email,r.status,r.preordermeals,r.date," &
                              "r.time,r.pax,b.city,b.postalcode,b.address,rc.name,rc.description from useraccount as uc" &
                              " join reservation as r on uc.userid = r.userid join branch as b on b.branchid = r.branchid" &
                              " join restaurant as rc on rc.restaurantid = b.restaurantid where r.reservationid = @id"
        Dim obj As Reservation = New Reservation()
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@id", SqlDbType.Int).Value = Me.reservationId

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        obj.firstName = reader("firstname")
                        obj.lastName = reader("lastname")
                        obj.phone = reader("phoneNum")
                        obj.email = reader("email")
                        obj.preordermeals = reader("preordermeals")
                        obj.dt_date = reader("date")
                        obj.strtime = reader("time").ToString()
                        obj.status = reader("status")
                        obj.pax = reader("pax")
                        obj.branchCity = reader("city")
                        obj.branchPostalcode = reader("postalcode")
                        obj.branchAddress = reader("address")
                        obj.restaurantName = reader("name")
                        obj.restaurantDescription = reader("description")
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return obj
    End Function

    Public Function RetrieveOrderEmail() As Reservation
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT uc.firstName,uc.lastName,uc.phoneNum,uc.email,b.city,b.postalcode,b.address,rc.name,rc.description,bo.paymentMethod,bo.ordertime,bo.orderdate,dt.type" &
            " from useraccount as uc join batchorders as bo on uc.userid = bo.userid join branch as b on b.branchid = bo.branchid" &
            " join restaurant as rc on rc.restaurantid = b.restaurantid join orders as o on bo.batchid = o.batchid"&" join deliverType as dt on bo.deliveryTypeID = dt.deliveryTypeID where bo.batchid = @batchid"
        Dim obj As Reservation = New Reservation()
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.reservationId

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        obj.firstName = reader("firstname")
                        obj.lastName = reader("lastname")
                        obj.phone = reader("phoneNum")
                        obj.email = reader("email")
                        obj.preordermeals = reader("paymentMethod")
                        obj.dt_date = reader("orderdate")
                        obj.strtime = reader("ordertime").ToString()
                        obj.status = reader("type")
                        obj.branchCity = reader("city")
                        obj.branchPostalcode = reader("postalcode")
                        obj.branchAddress = reader("address")
                        obj.restaurantName = reader("name")
                        obj.restaurantDescription = reader("description")
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return obj
    End Function

    Public Function RetrievePreOrderMenu() As List(Of Reservation)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT od.orderQuantity, m.name, m.cost, o.totalcharges,o.batchid,o.orderstatusid,bo.paymentMethod from orders As o" &
                              " join orderdetails As od On o.orderNum = od.orderNum" &
                              " join menu As m On m.menuid = od.menuid" &
                              " join batchOrders as bo on o.batchid=bo.batchid where o.batchID = @batchid"
        Dim obj As List(Of Reservation) = New List(Of Reservation)
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.userid

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Dim tempobj As Reservation = New Reservation
                        tempobj.batchid = reader("batchid")
                        tempobj.userid = reader("orderstatusid")
                        tempobj.restaurantName = reader("name")
                        tempobj.pax = reader("orderQuantity")
                        tempobj.tempCost = reader("cost")
                        tempobj.tempTotalCost = reader("totalcharges")
                        tempobj.tempPaymentType = reader("paymentMethod").ToString()
                        obj.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return obj
    End Function

    Public Function RetrieveOrderMenu() As List(Of Reservation)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "SELECT od.orderQuantity, m.name, m.cost, o.totalcharges,o.batchid,o.orderstatusid,o.deliveryCharges,bo.paymentMethod from orders As o" &
                              " join orderdetails As od On o.orderNum = od.orderNum" &
                              " join menu As m On m.menuid = od.menuid" &
                              " join batchOrders as bo on o.batchid=bo.batchid where o.batchID = @batchid"
        Dim obj As List(Of Reservation) = New List(Of Reservation)
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.userid

                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Dim tempobj As Reservation = New Reservation
                        tempobj.batchid = reader("batchid")
                        tempobj.userid = reader("orderstatusid")
                        tempobj.restaurantName = reader("name")
                        tempobj.pax = reader("orderQuantity")
                        tempobj.tempCost = reader("cost")
                        tempobj.tempTotalCost = reader("totalcharges")
                        tempobj.tempPaymentType = reader("paymentMethod").ToString()
                        tempobj.tempDeliveryCharges = reader("deliveryCharges")
                        obj.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return obj
    End Function

End Class
