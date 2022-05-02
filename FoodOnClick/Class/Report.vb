Imports System.Configuration
Imports System.Data.SqlClient


Public Class Report
    Inherits User
    Protected int_totalOrder As Int32
    Protected double_totalDeliveryCharges As Double
    Protected string_period As String

    Protected string_cuisineName As String
    Protected double_sales As Double


    Public Property totalOrder() As Int32
        Get
            totalOrder = int_totalOrder
        End Get
        Set(ByVal Value As Int32)
            int_totalOrder = Value
        End Set
    End Property

    Public Property totalDeliveryCharges() As Double
        Get
            totalDeliveryCharges = double_totalDeliveryCharges
        End Get
        Set(ByVal Value As Double)
            double_totalDeliveryCharges = Value
        End Set
    End Property

    Public Property period() As String
        Get
            period = string_period
        End Get
        Set(ByVal Value As String)
            string_period = Value
        End Set
    End Property


    Public Property cuisineName() As String
        Get
            cuisineName = string_cuisineName
        End Get
        Set(ByVal Value As String)
            string_cuisineName = Value
        End Set
    End Property


    Public Property sales() As Double
        Get
            sales = double_sales
        End Get
        Set(ByVal Value As Double)
            double_sales = Value
        End Set
    End Property



    Public Sub New()
    End Sub


    Public Function getRiderReport(myUserID As Int32, periodType As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Report) = New List(Of Report)
        Dim queryDate As String = "SELECT CAST(orders.time_picked AS DATE) AS DATE, count(orders.time_picked) AS OrderNum,COALESCE(sum(deliveryCharges),0) as deliverycharges FROM RIDER JOIN ORDERS ON RIDER.RIDERID=ORDERS.RIDERID where rider.userid=@userid  group by CAST(orders.time_picked AS DATE)"
        Dim queryWeek As String = "SELECT DATEPART(WEEK,orders.time_picked) AS Week, count(orders.time_picked) AS OrderNum,COALESCE(sum(deliveryCharges),0) as deliverycharges FROM RIDER JOIN ORDERS ON RIDER.RIDERID=ORDERS.RIDERID where rider.userid=@userid group by DATEPART(WEEK,orders.time_picked)"
        Dim queryMonth As String = "SELECT DATEPART(MONTH,orders.time_picked) AS Month, count(orders.time_picked) AS OrderNum,COALESCE(sum(deliveryCharges),0) as deliverycharges FROM RIDER JOIN ORDERS ON RIDER.RIDERID=ORDERS.RIDERID where rider.userid=@userid group by DATEPART(Month,orders.time_picked)"
        Dim queryALl As String = "SELECT  count(orders.time_picked) AS OrderNum,COALESCE(sum(deliveryCharges),0) as deliverycharges FROM RIDER JOIN ORDERS ON RIDER.RIDERID=ORDERS.RIDERID where rider.userid=@userid"


        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    If periodType = "All" Then
                        .CommandText = queryALl
                    ElseIf periodType = "Date" Then
                        .CommandText = queryDate
                    ElseIf periodType = "Week" Then
                        .CommandText = queryWeek
                    ElseIf periodType = "Month" Then
                        .CommandText = queryMonth
                    End If
                    .Parameters.AddWithValue("@userid", myUserID)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    Dim counter As Integer = 1
                    Dim tempobj As Report = New Report()
                    While reader.Read()


                        If periodType = "All" Then
                            tempobj.period = ""
                        ElseIf periodType = "Date" Then
                            tempobj.period = reader("DATE")
                        ElseIf periodType = "Week" Then
                            tempobj.period = reader("Week")
                        ElseIf periodType = "Month" Then
                            tempobj.period = reader("Month")
                        End If
                        tempobj.totalDeliveryCharges = reader("deliverycharges")
                        tempobj.totalOrder = reader("OrderNum")


                        returnObject.Add(tempobj)
                        tempobj = New Report()
                    End While
                Catch ex As SqlException

                End Try
            End Using
        End Using





        Return returnObject
    End Function

    Public Function getRestaurantReport(myUserID As Int32, periodType As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Report) = New List(Of Report)
        Dim queryDate As String = "SELECT BRANCH.ADDRESS, CAST(batchorders.orderdate AS DATE)  AS PERIOD,MENU.NAME,COUNT(ORDERDETAILS.MENUID) AS ORDERNUM ,sum(OrderDetails.Price) AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BRANCH.BRANCHID=BATCHORDERS.BRANCHID JOIN ORDERS ON ORDERS.BATCHID=BATCHORDERS.BATCHID JOIN ORDERDETAILS ON ORDERS.ORDERNUM=ORDERDETAILS.ORDERNUM JOIN MENU ON ORDERDETAILS.MENUID=MENU.MENUID WHERE USERACCOUNT.USERID=@userid GROUP BY MENU.NAME,BRANCH.ADDRESS,CAST(batchorders.orderdate AS DATE) ORDER BY ORDERNUM DESC"
        Dim queryWeek As String = "SELECT BRANCH.ADDRESS, DATEPART(WEEK,batchorders.orderdate) AS PERIOD,MENU.NAME,COUNT(ORDERDETAILS.MENUID) AS ORDERNUM ,sum(OrderDetails.Price) AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BRANCH.BRANCHID=BATCHORDERS.BRANCHID JOIN ORDERS ON ORDERS.BATCHID=BATCHORDERS.BATCHID JOIN ORDERDETAILS ON ORDERS.ORDERNUM=ORDERDETAILS.ORDERNUM JOIN MENU ON ORDERDETAILS.MENUID=MENU.MENUID WHERE USERACCOUNT.USERID=@userid GROUP BY MENU.NAME,BRANCH.ADDRESS,DATEPART(WEEK,batchorders.orderdate) ORDER BY ORDERNUM DESC"
        Dim queryMonth As String = "SELECT BRANCH.ADDRESS, DATEPART(MONTH,batchorders.orderdate) AS PERIOD,MENU.NAME,COUNT(ORDERDETAILS.MENUID) AS ORDERNUM ,sum(OrderDetails.Price) AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BRANCH.BRANCHID=BATCHORDERS.BRANCHID JOIN ORDERS ON ORDERS.BATCHID=BATCHORDERS.BATCHID JOIN ORDERDETAILS ON ORDERS.ORDERNUM=ORDERDETAILS.ORDERNUM JOIN MENU ON ORDERDETAILS.MENUID=MENU.MENUID WHERE USERACCOUNT.USERID=@userid GROUP BY MENU.NAME,BRANCH.ADDRESS,DATEPART(MONTH,batchorders.orderdate) ORDER BY ORDERNUM DESC"
        Dim queryAll As String = "SELECT BRANCH.ADDRESS, MENU.NAME,COUNT(ORDERDETAILS.MENUID) AS ORDERNUM,sum(OrderDetails.Price) AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BRANCH.BRANCHID=BATCHORDERS.BRANCHID JOIN ORDERS ON ORDERS.BATCHID=BATCHORDERS.BATCHID JOIN ORDERDETAILS ON ORDERS.ORDERNUM=ORDERDETAILS.ORDERNUM JOIN MENU ON ORDERDETAILS.MENUID=MENU.MENUID WHERE USERACCOUNT.USERID=@userid GROUP BY MENU.NAME,BRANCH.ADDRESS ORDER BY ORDERNUM DESC"


        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    If periodType = "All" Then
                        .CommandText = queryAll
                    ElseIf periodType = "Date" Then
                        .CommandText = queryDate
                    ElseIf periodType = "Week" Then
                        .CommandText = queryWeek
                    ElseIf periodType = "Month" Then
                        .CommandText = queryMonth
                    End If
                    .Parameters.AddWithValue("@userid", myUserID)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    Dim counter As Integer = 1
                    Dim tempobj As Report = New Report()
                    While reader.Read()


                        If periodType = "All" Then
                            tempobj.period = ""
                            tempobj.totalOrder = reader("ORDERNUM")
                        ElseIf periodType = "Date" Then
                            tempobj.period = reader("PERIOD")
                            tempobj.totalOrder = reader("ORDERNUM")
                        ElseIf periodType = "Week" Then
                            tempobj.period = reader("PERIOD")
                            tempobj.totalOrder = reader("ORDERNUM")
                        ElseIf periodType = "Month" Then
                            tempobj.period = reader("PERIOD")
                            tempobj.totalOrder = reader("ORDERNUM")
                        End If

                        tempobj.cuisineName = reader("NAME")
                        tempobj.address = reader("ADDRESS")
                        tempobj.sales = reader("sales")
                        returnObject.Add(tempobj)
                        tempobj = New Report()
                    End While
                Catch ex As SqlException

                End Try
            End Using
        End Using





        Return returnObject
    End Function

End Class
