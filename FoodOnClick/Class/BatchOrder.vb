Imports System.Configuration
Imports System.Data.SqlClient

Public Class BatchOrder
    Public iBatchId As Integer
    Public dtOrderDate As Date
    Public strOrderTime As String
    Public iBranchId As Integer
    Public iUserId As Integer
    Public iCardID As Integer
    Public iOrderTypeID As Integer
    Public iDeliveryTypeID As Integer

#Region "Objects"
    Public Property batchId() As Integer
        Get
            batchId = iBatchId
        End Get
        Set(ByVal Value As Integer)
            iBatchId = Value
        End Set
    End Property

    Public Property orderDate() As Date
        Get
            orderDate = dtOrderDate
        End Get
        Set(ByVal Value As Date)
            dtOrderDate = Value
        End Set
    End Property

    Public Property orderTime() As String
        Get
            orderTime = strOrderTime
        End Get
        Set(ByVal Value As String)
            strOrderTime = Value
        End Set
    End Property

    Public Property branchId() As Integer
        Get
            branchId = iBranchId
        End Get
        Set(ByVal Value As Integer)
            iBranchId = Value
        End Set
    End Property

    Public Property userId() As Integer
        Get
            userId = iUserId
        End Get
        Set(ByVal Value As Integer)
            iUserId = Value
        End Set
    End Property

    Public Property cardID() As Integer
        Get
            cardID = iCardID
        End Get
        Set(ByVal Value As Integer)
            iCardID = Value
        End Set
    End Property

    Public Property orderTypeID() As Integer
        Get
            orderTypeID = iOrderTypeID
        End Get
        Set(ByVal Value As Integer)
            iOrderTypeID = Value
        End Set
    End Property

    Public Property deliveryTypeID() As Integer
        Get
            deliveryTypeID = iDeliveryTypeID
        End Get
        Set(ByVal Value As Integer)
            iDeliveryTypeID = Value
        End Set
    End Property
#End Region

    Public Sub New()
    End Sub

    Public Sub New(ByVal dtOrderDate As Date,
                   ByVal strTime As String, ByVal iBranchId As Integer,
                   ByVal iUserId As Integer, ByVal iCardID As Integer,
                   ByVal iOrderTypeID As Integer, ByVal iDeliveryTypeID As Integer)
        Me.orderDate = dtOrderDate
        Me.orderTime = strTime
        Me.branchId = iBranchId
        Me.userId = iUserId
        Me.cardID = iCardID
        Me.orderTypeID = iOrderTypeID
        Me.deliveryTypeID = iDeliveryTypeID
    End Sub

#Region "Functions"
    Public Sub InsertBatchOrder()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        If Me.orderTypeID = 10 Then
            Query = "INSERT INTO BatchOrders (branchid, orderTypeID, userid, ordertime, orderdate) " &
                            "VALUES (@branchid, @orderTypeID, @userid, @ordertime, @orderdate) "
        Else
            Query = "INSERT INTO BatchOrders (branchid, orderTypeID, cardid, userid, deliveryTypeID, ordertime, orderdate) " &
                            "VALUES (@branchid, @orderTypeID, @cardid, @userid, @deliveryTypeID, @ordertime, @orderdate) "
        End If

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = Me.branchId
                    .Parameters.Add("@orderTypeID", SqlDbType.Int).Value = Me.orderTypeID
                    .Parameters.Add("@cardid", SqlDbType.Int).Value = Me.cardID
                    .Parameters.Add("@userid", SqlDbType.Int).Value = Me.userId
                    .Parameters.Add("@deliveryTypeID", SqlDbType.Int).Value = Me.deliveryTypeID
                    .Parameters.Add("@ordertime", SqlDbType.NVarChar).Value = Me.orderTime
                    .Parameters.Add("@orderdate", SqlDbType.Date).Value = Me.orderDate

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
#End Region

End Class
