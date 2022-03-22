Imports System.Configuration
Imports System.Data.SqlClient

Public Class BatchOrder
    Protected iBatchId As Integer
    Protected dtOrderDate As Date
    Protected strOrderTime As String
    Protected iBranchId As Integer
    Protected iUserId As Integer
    Protected iCardID As Integer
    Protected iOrderTypeID As Integer
    Protected iDeliveryTypeID As Integer
    Protected sPaymentMethod As String

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

    Public Property paymentMethod() As String
        Get
            paymentMethod = sPaymentMethod
        End Get
        Set(ByVal Value As String)
            sPaymentMethod = Value
        End Set
    End Property
#End Region

    Public Sub New()
    End Sub

    Public Sub New(ByVal dtOrderDate As Date,
                   ByVal strTime As String, ByVal iBranchId As Integer,
                   ByVal iUserId As Integer, ByVal iCardID As Integer,
                   ByVal iOrderTypeID As Integer, ByVal iDeliveryTypeID As Integer, ByVal sPaymentMethod As String)
        Me.orderDate = dtOrderDate
        Me.orderTime = strTime
        Me.branchId = iBranchId
        Me.userId = iUserId
        Me.cardID = iCardID
        Me.orderTypeID = iOrderTypeID
        Me.deliveryTypeID = iDeliveryTypeID
        Me.paymentMethod = sPaymentMethod
    End Sub

#Region "Functions"
    Public Function InsertBatchOrder()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        If Me.orderTypeID = 10 Then
            Query = "INSERT INTO BatchOrders (branchid, orderTypeID, userid, ordertime, orderdate, paymentMethod) " &
                            "VALUES (@branchid, @orderTypeID, @userid, @ordertime, @orderdate, @paymentMethod): SELECT SCOPE_IDENTITY();"
        ElseIf Me.orderTypeID = 11 Then
            Query = "INSERT INTO BatchOrders (branchid, orderTypeID, userid, deliveryTypeID, ordertime, orderdate, paymentMethod) " &
                            "VALUES (@branchid, @orderTypeID, @userid, @deliveryTypeID, @ordertime, @orderdate, @paymentMethod); SELECT SCOPE_IDENTITY();"
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
                    .Parameters.Add("@paymentMethod", SqlDbType.NVarChar).Value = Me.paymentMethod
                End With
                Try
                    conn.Open()
                    Dim returnObj As Object = comm.ExecuteScalar()
                    conn.Close()
                    Return returnObj
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
    End Function
#End Region

End Class
