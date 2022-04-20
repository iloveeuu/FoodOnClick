Imports System.Configuration
Imports System.Data.SqlClient

Public Class Order
    Inherits BatchOrder

    Protected iOrderNum As Integer
    Protected dTotalcharges As Decimal
    Protected dDeliverycharges As Decimal
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

    Public Property deliverycharges() As Decimal
        Get
            deliverycharges = dDeliverycharges
        End Get
        Set(ByVal Value As Decimal)
            dDeliverycharges = Value
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
    Public Sub New(ByVal ibatchid As Integer)
        Me.batchId = ibatchid
    End Sub

    Public Sub New(ByVal ibatchid As Integer, ByVal iuserid As Integer)
        Me.batchId = ibatchid
        Me.userId = iuserid
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
            Query = "INSERT INTO Orders (totalcharges, orderStatusID, batchID, deliveryCharges) " &
                            "VALUES ((SELECT TOP 1 totalprice FROM shoppingcart WHERE cartID = @cartId), 6, @batchid, @deliverycharges);SELECT SCOPE_IDENTITY();"
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
                    .Parameters.Add("@deliverycharges", SqlDbType.Decimal).Value = Me.deliverycharges
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

    Public Function CheckOrderPending() As Boolean
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
    Public Function CheckRiderPendingOrders()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Order) = New List(Of Order)
        Dim Query As String = "Select bo.paymentmethod,u.address as useraddress,r.name,b.address,bo.ordertime,bo.orderdate,os.type,o.totalcharges,o.orderNum,o.deliveryCharges,bo.batchid from batchorders As bo join deliverType As dt On bo.deliveryTypeID = dt.deliveryTypeID join orderType As ot On bo.orderTypeID = ot.orderTypeID join orders As o On bo.batchid = o.batchid join orderstatus As os On o.orderStatusID = os.orderStatusID join branch As b On b.branchid =bo.branchid join restaurant As r On r.restaurantid = b.restaurantid join useraccount as u on u.userid =bo.userid where bo.orderTypeID = 11 And o.orderStatusID = 1 And bo.deliveryTypeID = 2 And o.riderid is null"
        'Dim Query As String = "SELECT u.userid,u.firstName,u.lastName,dt.type,bo.ordertime,bo.orderdate,os.type,o.totalcharges,ot.type,o.orderNum,o.deliveryCharges,bo.batchid from useraccount as u join batchorders as bo on u.userid = bo.userid join deliverType as dt on bo.deliveryTypeID = dt.deliveryTypeID join orderType as ot on bo.orderTypeID = ot.orderTypeID join orders as o on bo.batchid = o.batchid join orderstatus as os on o.orderStatusID = os.orderStatusID where bo.branchid = @branchid and bo.orderTypeID = 11 and o.orderStatusID = 6 and bo.deliveryTypeID = 2"

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

                    If (reader.HasRows) Then

                        While reader.Read()
                            Dim tempobj As Order = New Order()
                            tempobj.name = reader("name")
                            tempobj.timeDelivered = reader("address")
                            tempobj.strOrderTime = reader("ordertime").ToString()
                            tempobj.totalcharges = reader("totalcharges")
                            tempobj.orderNum = reader("orderNum")
                            tempobj.deliverycharges = reader("deliveryCharges")
                            tempobj.batchId = reader("batchid")
                            tempobj.timePicked = reader("useraddress")
                            tempobj.batchId = reader("batchid")
                            tempobj.paymentMethod = reader("paymentMethod")
                            returnObject.Add(tempobj)
                        End While
                    End If
                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return returnObject
    End Function

    Public Function CheckIfOrderIsAvailable() As Boolean
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As Boolean = True
        Dim Query As String = "Select o.riderID from batchorders as bo join orders as o on bo.batchid = o.batchid where batchid = @batchid"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.batchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        returnObject = False
                    End If
                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return returnObject
    End Function

    Public Function AcceptOrderJob() As Boolean
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As Boolean = True
        Dim Query As String = "update orders set riderID = (select riderid from rider where userid = @riderid) where batchid = @batchid"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.batchId
                    .Parameters.Add("@riderid", SqlDbType.Int).Value = Me.userId
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    conn.Close()
                Catch ex As SqlException
                    returnObject = False
                End Try
            End Using
            Query = "update rider set deliverystatus = 'Deliverying' where userid = @riderid"
            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.batchId
                    .Parameters.Add("@riderid", SqlDbType.Int).Value = Me.userId
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    conn.Close()
                Catch ex As SqlException
                    returnObject = False
                End Try
            End Using
        End Using
        Return returnObject
    End Function
    Public Function CurrentlyOnJob() As Boolean
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As Boolean = False
        'Dim Query As String = "Select * from orders where (riderid=@riderid and orderstatusid = 1) or (riderid=@riderid and orderstatusid = 2)"
        Dim Query As String = "Select * From orders Where riderID =@riderid And orderstatusid in (1,2)"


        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@riderid", SqlDbType.Int).Value = Me.batchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        returnObject = True
                    End If
                    conn.Close()
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function
#End Region

End Class
