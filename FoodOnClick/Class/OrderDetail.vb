Imports System.Configuration
Imports System.Data.SqlClient

Public Class OrderDetail
    Inherits Order

    Protected iMenuid As Integer
    Protected iOrderQuantity As Integer
    Protected dPrice As Decimal
    Protected str_fromdate As String
    Protected str_todate As String

#Region "Objects"
    Public Property menuid() As Integer
        Get
            menuid = iMenuid
        End Get
        Set(ByVal Value As Integer)
            iMenuid = Value
        End Set
    End Property

    Public Property orderQuantity() As Integer
        Get
            orderQuantity = iOrderQuantity
        End Get
        Set(ByVal Value As Integer)
            iOrderQuantity = Value
        End Set
    End Property

    Public Property price() As Decimal
        Get
            price = dPrice
        End Get
        Set(ByVal Value As Decimal)
            dPrice = Value
        End Set
    End Property

    Public Property fromdate() As String
        Get
            fromdate = str_fromdate
        End Get
        Set(ByVal Value As String)
            str_fromdate = Value
        End Set
    End Property

    Public Property todate() As String
        Get
            todate = str_todate
        End Get
        Set(ByVal Value As String)
            str_todate = Value
        End Set
    End Property

#End Region

    Public Sub New()
    End Sub

    Public Sub New(ByVal iMenuid As Integer, ByVal iOrderQuantity As Integer,
                   ByVal dPrice As Decimal)
        Me.menuid = iMenuid
        Me.orderQuantity = iOrderQuantity
        Me.price = dPrice
    End Sub

#Region "Functions"
    Public Sub InsertOrderDetail()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        If MyBase.orderTypeID = 10 Then
            Query = "INSERT INTO OrderDetails (orderNum, menuid, orderQuantity, price) " &
                            "VALUES (@orderNum,@menuid, @orderQuantity, @price)"
        ElseIf MyBase.orderTypeID = 11 Then
            Query = "INSERT INTO OrderDetails (orderNum, menuid, orderQuantity, price) " &
                            "SELECT @orderNum, menuid, quantity, price FROM shoppingcart_menu Where cartid = @cartid"
        End If

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userID", SqlDbType.Int).Value = MyBase.userId
                    .Parameters.Add("@menuid", SqlDbType.Int).Value = Me.menuid
                    .Parameters.Add("@orderQuantity", SqlDbType.Int).Value = Me.orderQuantity
                    .Parameters.Add("@price", SqlDbType.Decimal).Value = Me.price
                    .Parameters.Add("@orderNum", SqlDbType.Decimal).Value = Me.orderNum
                    .Parameters.Add("@cartid", SqlDbType.Decimal).Value = Me.cartId
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

    Public Function GetOrderDetail()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""
        Dim dtOrderDetail = New DataTable()

        Query = "Select m.name as menu, od.orderQuantity, od.price, " &
                "(m.description + 'CHAR(13)CHAR(13)Energy: ' + CONVERT(nvarchar(20),m.energy) + ' cal.' + " &
                            "'CHAR(13)Protein: ' + CONVERT(nvarchar(20),m.protein) + ' g' + " &
                            "'CHAR(13)Carbs: ' + CONVERT(nvarchar(20),m.carbonhydrate) + ' g' + " &
                            "'CHAR(13)Sugar: ' + CONVERT(nvarchar(20),m.glucose) + ' g' + " &
                            "'CHAR(13)Fats: ' + CONVERT(nvarchar(20),m.fats) + ' g' + " &
                            "'CHAR(13)Sodium: ' + CONVERT(nvarchar(20),m.sodium) + ' g' " &
                            ") As describe, o.totalcharges, os.type as status, o.deliveryCharges, " &
                            "('~/images/menu/' + m.image) As path, ft.type " &
                "From batchorders as bo " &
                "inner join orders as o on o.batchid = bo.batchid " &
                "inner join orderstatus as os on os.orderStatusID = o.orderStatusID " &
                "inner join orderdetails as od on od.ordernum = o.ordernum " &
                "inner join menu as m on m.menuid = od.menuid " &
                "inner Join FoodType As ft On m.foodtypeID = ft.foodtypeID " &
                "Where bo.batchid = @batchid"

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
                        dtOrderDetail.Load(reader)
                        dtOrderDetail.Columns(3).ReadOnly = False

                        For i As Integer = 0 To dtOrderDetail.Rows.Count - 1
                            dtOrderDetail.Rows(i)(3) = dtOrderDetail.Rows(i)(3).ToString().Replace("CHAR(13)", "<br/>")
                        Next
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return dtOrderDetail
    End Function

    Public Function GetDeliveryOrderHistory()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtHistory = New DataTable()

        Dim Query As String = "SELECT b.email, o.orderNum,r.name as restName, b.address, bo.batchid, os.type as status, b.branchid, bo.orderdate, Isnull(o.riderID,'') as riderID " &
                                "from branch as b " &
                                "inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                "inner join batchOrders as bo on bo.branchid = b.branchid " &
                                "inner join orders as o on o.batchid = bo.batchid " &
                                "inner join orderstatus as os on os.orderStatusID = o.orderStatusID " &
                                "inner join delivertype as dt on dt.deliveryTypeID = bo.deliveryTypeID " &
                                "where bo.userID = @userId and bo.deliveryTypeID = 2 "

        If fromdate.Trim() <> "" Then
            Query += " And bo.orderdate >= '" + fromdate.Trim() + "' "
        End If

        If todate.Trim() <> "" Then
            Query += " And bo.orderdate <= '" + todate.Trim() + "' "
        End If

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtHistory.Load(reader)
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return dtHistory
    End Function
#End Region

End Class
