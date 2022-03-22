Imports System.Configuration
Imports System.Data.SqlClient

Public Class Order
    Inherits BatchOrder

    Protected iOrderNum As Integer
    Protected dTotalcharges As Decimal
    Protected iOrderStatusID As Integer
    Protected iRiderReviewID As Integer
    Protected sTimePicked As String
    Protected sTimeDelivered As String
    Protected iRiderID As Integer
    Protected iCartID As Integer

#Region "Objects"
    Public Property orderNum() As Integer
        Get
            orderNum = iOrderNum
        End Get
        Set(ByVal Value As Integer)
            iOrderNum = Value
        End Set
    End Property

    Public Property totalcharges() As Decimal
        Get
            totalcharges = dTotalcharges
        End Get
        Set(ByVal Value As Decimal)
            dTotalcharges = Value
        End Set
    End Property

    Public Property orderStatusID() As Integer
        Get
            orderStatusID = iOrderStatusID
        End Get
        Set(ByVal Value As Integer)
            iOrderStatusID = Value
        End Set
    End Property

    Public Property riderReviewID() As Integer
        Get
            riderReviewID = iRiderReviewID
        End Get
        Set(ByVal Value As Integer)
            iRiderReviewID = Value
        End Set
    End Property

    Public Property timePicked() As String
        Get
            timePicked = sTimePicked
        End Get
        Set(ByVal Value As String)
            sTimePicked = Value
        End Set
    End Property

    Public Property timeDelivered() As String
        Get
            timeDelivered = sTimeDelivered
        End Get
        Set(ByVal Value As String)
            sTimeDelivered = Value
        End Set
    End Property

    Public Property riderID() As Integer
        Get
            riderID = iRiderID
        End Get
        Set(ByVal Value As Integer)
            iRiderID = Value
        End Set
    End Property

    Public Property cartID() As Integer
        Get
            cartID = iCartID
        End Get
        Set(ByVal Value As Integer)
            iCartID = Value
        End Set
    End Property
#End Region

    Public Sub New()
    End Sub

    Public Sub New(ByVal iOrderNum As Integer, ByVal dTotalcharges As Decimal,
                   ByVal iOrderStatusID As Integer, ByVal iRiderReviewID As Integer,
                   ByVal sTimePicked As String, ByVal sTimeDelivered As String,
                   ByVal iRiderID As Integer)
        Me.orderNum = iOrderNum
        Me.totalcharges = dTotalcharges
        Me.orderStatusID = iOrderStatusID
        Me.riderReviewID = iRiderReviewID
        Me.timePicked = sTimePicked
        Me.timeDelivered = sTimeDelivered
        Me.riderID = iRiderID
    End Sub

#Region "Functions"
    Public Function InsertReservationOrder()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        If MyBase.orderTypeID = 10 Then
            Query = "INSERT INTO Orders (totalcharges, orderStatusID, batchID) " &
                            "VALUES (@totalcharges, 6, @batchid);SELECT SCOPE_IDENTITY();"
        End If

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@totalcharges", SqlDbType.Decimal).Value = Me.totalcharges
                    .Parameters.Add("@userID", SqlDbType.Int).Value = MyBase.userId
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = MyBase.batchId
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

    Public Function CheckPreOrderPending() As Boolean
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim returnBool As Boolean = False

        Dim Query As String = "select top 1 o.orderstatusid from batchorders as b inner join orders as o on o.batchid = b.batchid " &
                                " where b.userID = @userId And o.batchid = @batchid  And o.orderstatusid = 6 "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userId
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.batchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        returnBool = True
                    Else
                        returnBool = False
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return returnBool
    End Function

    Public Sub CancelOrder()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""


        Query = "Update Orders set orderStatusID = 4 Where batchId=@batchId "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@batchId", SqlDbType.Decimal).Value = Me.batchId
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

    Public Function InsertDeliveryOrder()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""
        Dim returnObj As Object

        If MyBase.orderTypeID = 11 Then
            Query = "INSERT INTO Orders (totalcharges, orderStatusID, batchID) " &
                            "VALUES ((SELECT TOP 1 totalprice FROM shoppingcart WHERE cartID = @cartId), 6, @batchid);SELECT SCOPE_IDENTITY();"
        End If

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@cartId", SqlDbType.Int).Value = Me.cartID
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = MyBase.batchId
                End With
                Try
                    conn.Open()
                    returnObj = comm.ExecuteScalar()
                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return returnObj
    End Function
#End Region

End Class
