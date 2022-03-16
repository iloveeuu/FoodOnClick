Imports System.Configuration
Imports System.Data.SqlClient

Public Class Reservation
    Inherits User

    Dim str_reservationId As Int32
    Dim str_preordermeals As String
    Dim dt_date As Date
    Dim str_time As String
    Dim int_pax As Int32
    Dim str_status As String
    Dim int_branchId As Int32
    Dim int_userId As Int32
    Dim int_batchid As Int32

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

#End Region

    Public Sub New()
    End Sub

    Public Sub New(ByVal userid As Int32)
        Me.userid = userid
    End Sub

    Public Sub New(ByVal preordermeals As String, ByVal dtdate As Date,
                   ByVal strtime As String, ByVal pax As Int32,
                   ByVal status As String, ByVal branchId As Int32, ByVal userid As Int32, ByVal batchid As Int32)
        Me.preordermeals = preordermeals
        Me.dtdate = dtdate
        Me.strtime = strtime
        Me.pax = pax
        Me.status = status
        Me.branchId = branchId
        Me.userId = userid
        Me.batchid = batchid
    End Sub

    Public Sub InsertReservation()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        If Me.str_preordermeals = "No" Then
            Query = "INSERT INTO Reservation (preordermeals, date, time, pax, status, branchId, userId) " &
                            "VALUES (@preordermeals, @dtdate, @strtime, @pax, @status, @branchId, @userId) "
        Else
            Query = "INSERT INTO Reservation (preordermeals, date, time, pax, status, branchId, userId, batchid) " &
                            "VALUES (@preordermeals, @dtdate, @strtime, @pax, @status, @branchId, @userId, @batchid) "
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
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.int_batchid

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

        Dim Query As String = "SELECT r.name as restName, b.address, re.pax, re.date, re.time, re.status from branch as b " &
                                " inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                " inner join reservation as re on re.branchId = b.branchId " &
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

End Class
