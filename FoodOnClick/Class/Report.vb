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
        Dim queryDate As String = "SELECT CAST(orders.time_picked AS DATE) AS DATE, count(orders.time_picked) AS OrderNum,COALESCE(sum(deliveryCharges),0) as deliverycharges FROM RIDER JOIN ORDERS ON RIDER.RIDERID=ORDERS.RIDERID where orders.orderStatusID in (3,10) and rider.userid=@userid  group by CAST(orders.time_picked AS DATE)"
        Dim queryWeek As String = "SELECT DATEPART(WEEK,orders.time_picked) AS Week, count(orders.time_picked) AS OrderNum,COALESCE(sum(deliveryCharges),0) as deliverycharges FROM RIDER JOIN ORDERS ON RIDER.RIDERID=ORDERS.RIDERID where orders.orderStatusID in (3,10) and rider.userid=@userid group by DATEPART(WEEK,orders.time_picked)"
        Dim queryMonth As String = "SELECT DATEPART(MONTH,orders.time_picked) AS Month, count(orders.time_picked) AS OrderNum,COALESCE(sum(deliveryCharges),0) as deliverycharges FROM RIDER JOIN ORDERS ON RIDER.RIDERID=ORDERS.RIDERID where orders.orderStatusID in (3,10) and rider.userid=@userid group by DATEPART(Month,orders.time_picked)"
        Dim queryALl As String = "SELECT  count(orders.time_picked) AS OrderNum,COALESCE(sum(deliveryCharges),0) as deliverycharges FROM RIDER JOIN ORDERS ON RIDER.RIDERID=ORDERS.RIDERID where orders.orderStatusID in (3,10) and rider.userid=@userid"


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
        Dim referenceObj As List(Of Report) = New List(Of Report)
        Dim queryDate As String = "SELECT BRANCH.ADDRESS, CAST(batchorders.orderdate AS DATE)  AS PERIOD,MENU.NAME,COUNT(ORDERDETAILS.MENUID) AS ORDERNUM ,sum(OrderDetails.Price)*0.9 AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BRANCH.BRANCHID=BATCHORDERS.BRANCHID JOIN ORDERS ON ORDERS.BATCHID=BATCHORDERS.BATCHID JOIN ORDERDETAILS ON ORDERS.ORDERNUM=ORDERDETAILS.ORDERNUM JOIN MENU ON ORDERDETAILS.MENUID=MENU.MENUID WHERE orders.orderStatusID in (3,9,10) and USERACCOUNT.USERID=@userid GROUP BY MENU.NAME,BRANCH.ADDRESS,CAST(batchorders.orderdate AS DATE) ORDER BY sales DESC"
        Dim queryWeek As String = "SELECT BRANCH.ADDRESS, DATEPART(WEEK,batchorders.orderdate) AS PERIOD,MENU.NAME,COUNT(ORDERDETAILS.MENUID) AS ORDERNUM ,sum(OrderDetails.Price)*0.9 AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BRANCH.BRANCHID=BATCHORDERS.BRANCHID JOIN ORDERS ON ORDERS.BATCHID=BATCHORDERS.BATCHID JOIN ORDERDETAILS ON ORDERS.ORDERNUM=ORDERDETAILS.ORDERNUM JOIN MENU ON ORDERDETAILS.MENUID=MENU.MENUID WHERE orders.orderStatusID in (3,9,10) and USERACCOUNT.USERID=@userid GROUP BY MENU.NAME,BRANCH.ADDRESS,DATEPART(WEEK,batchorders.orderdate) ORDER BY sales DESC"
        Dim queryMonth As String = "SELECT BRANCH.ADDRESS, DATEPART(MONTH,batchorders.orderdate) AS PERIOD,MENU.NAME,COUNT(ORDERDETAILS.MENUID) AS ORDERNUM ,sum(OrderDetails.Price)*0.9 AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BRANCH.BRANCHID=BATCHORDERS.BRANCHID JOIN ORDERS ON ORDERS.BATCHID=BATCHORDERS.BATCHID JOIN ORDERDETAILS ON ORDERS.ORDERNUM=ORDERDETAILS.ORDERNUM JOIN MENU ON ORDERDETAILS.MENUID=MENU.MENUID WHERE orders.orderStatusID in (3,9,10) and USERACCOUNT.USERID=@userid GROUP BY MENU.NAME,BRANCH.ADDRESS,DATEPART(MONTH,batchorders.orderdate) ORDER BY sales DESC"
        Dim queryAll As String = "SELECT BRANCH.ADDRESS, MENU.NAME,COUNT(ORDERDETAILS.MENUID) AS ORDERNUM,sum(OrderDetails.Price)*0.9 AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BRANCH.BRANCHID=BATCHORDERS.BRANCHID JOIN ORDERS ON ORDERS.BATCHID=BATCHORDERS.BATCHID JOIN ORDERDETAILS ON ORDERS.ORDERNUM=ORDERDETAILS.ORDERNUM JOIN MENU ON ORDERDETAILS.MENUID=MENU.MENUID WHERE orders.orderStatusID in (3,9,10) and  USERACCOUNT.USERID=@userid GROUP BY MENU.NAME,BRANCH.ADDRESS ORDER BY sales DESC"

        Dim queryReservationWithoutPreorderAllByDate As String = "SELECT BRANCH.ADDRESS,CAST(RESERVATION.DATE AS DATE) AS PERIOD , COUNT(*)*(-2) AS ReservationFee FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN RESERVATION ON RESERVATION.BRANCHID=BRANCH.BRANCHID  where preordermeals='No' and USERACCOUNT.userid=@userid  AND (RESERVATION.status='Approved' or RESERVATION.status= 'Completed') GROUP BY CAST(RESERVATION.DATE AS DATE),BRANCH.ADDRESS"
        Dim queryReservationWithoutPreorderAllByWeek As String = "SELECT BRANCH.ADDRESS ,DATEPART(WEEK,RESERVATION.DATE) AS PERIOD , COUNT(*)*(-2) AS ReservationFee FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN RESERVATION ON RESERVATION.BRANCHID=BRANCH.BRANCHID  where preordermeals='No' and USERACCOUNT.userid=@userid  AND (RESERVATION.status='Approved' or RESERVATION.status= 'Completed') GROUP BY DATEPART(WEEK,RESERVATION.DATE),BRANCH.ADDRESS"
        Dim queryReservationWithoutPreorderAllByMonth As String = "SELECT BRANCH.ADDRESS ,DATEPART(MONTH,RESERVATION.DATE) AS PERIOD , COUNT(*)*(-2) AS ReservationFee FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN RESERVATION ON RESERVATION.BRANCHID=BRANCH.BRANCHID  where preordermeals='No' and USERACCOUNT.userid=@userid AND (RESERVATION.status='Approved' or RESERVATION.status= 'Completed') GROUP BY DATEPART(MONTH,RESERVATION.DATE),BRANCH.ADDRESS"
        Dim queryReservationWithoutPreorderAll As String = "SELECT BRANCH.ADDRESS ,COUNT(*)*(-2) AS Reservationfee FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN RESERVATION ON RESERVATION.BRANCHID=BRANCH.BRANCHID  where preordermeals='No' and USERACCOUNT.userid=@userid  AND (RESERVATION.status='Approved' or RESERVATION.status= 'Completed') GROUP BY BRANCH.ADDRESS"

        Using conn1 As New SqlConnection(connectionString)

            Using comm1 As New SqlCommand()
                With comm1
                    Dim mycommand1 As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn1
                    .CommandType = CommandType.Text
                    If periodType = "All" Then
                        .CommandText = queryReservationWithoutPreorderAll
                    ElseIf periodType = "Date" Then
                        .CommandText = queryReservationWithoutPreorderAllByDate
                    ElseIf periodType = "Week" Then
                        .CommandText = queryReservationWithoutPreorderAllByWeek
                    ElseIf periodType = "Month" Then
                        .CommandText = queryReservationWithoutPreorderAllByMonth
                    End If
                    .Parameters.AddWithValue("@userid", myUserID)
                End With
                Try
                    conn1.Open()
                    Dim reader As SqlDataReader = comm1.ExecuteReader
                    Dim counter As Integer = 1
                    Dim tempobj As Report = New Report()
                    While reader.Read()


                        If periodType = "All" Then
                            tempobj.period = ""
                        ElseIf periodType = "Date" Then
                            tempobj.period = reader("PERIOD")
                        ElseIf periodType = "Week" Then
                            tempobj.period = reader("PERIOD")
                        ElseIf periodType = "Month" Then
                            tempobj.period = reader("PERIOD")

                        End If

                        tempobj.totalOrder = 0
                        tempobj.cuisineName = "Reservation cost"
                        tempobj.address = reader("ADDRESS")
                        tempobj.sales = reader("ReservationFee")
                        referenceObj.Add(tempobj)
                        tempobj = New Report()
                    End While
                Catch ex As SqlException

                End Try
            End Using
        End Using





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
                        ElseIf periodType = "Date" Then
                            tempobj.period = reader("PERIOD")
                        ElseIf periodType = "Week" Then
                            tempobj.period = reader("PERIOD")
                        ElseIf periodType = "Month" Then
                            tempobj.period = reader("PERIOD")

                        End If
                        tempobj.totalOrder = reader("ORDERNUM")
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

        For Each refobj In referenceObj
            returnObject.Add(refobj)
        Next





        Return returnObject
    End Function


    Public Function getAdminReport(periodType As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Report) = New List(Of Report)
        Dim referenceObj As List(Of Report) = New List(Of Report)
        Dim queryDate As String = "SELECT RESTAURANT.NAME,CAST(batchorders.orderdate AS DATE)  AS PERIOD,COUNT(*) AS ORDERNUM ,SUM(ORDERS.TOTALCHARGES)*0.1 AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BATCHORDERS.BRANCHID=BRANCH.BRANCHID JOIN ORDERS ON BATCHORDERS.BATCHID=ORDERS.BATCHID WHERE orders.orderStatusID in (3,9,10) GROUP BY RESTAURANT.NAME,CAST(batchorders.orderdate AS DATE) ORDER BY SUM(ORDERS.TOTALCHARGES) DESC  "
        Dim queryWeek As String = "SELECT RESTAURANT.NAME,DATEPART(WEEK,batchorders.orderdate) AS PERIOD,COUNT(*) AS ORDERNUM ,SUM(ORDERS.TOTALCHARGES)*0.1 AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BATCHORDERS.BRANCHID=BRANCH.BRANCHID JOIN ORDERS ON BATCHORDERS.BATCHID=ORDERS.BATCHID WHERE orders.orderStatusID in (3,9,10) GROUP BY RESTAURANT.NAME,DATEPART(WEEK,batchorders.orderdate) ORDER BY SUM(ORDERS.TOTALCHARGES) DESC "
        Dim queryMonth As String = "SELECT RESTAURANT.NAME,DATEPART(MONTH,batchorders.orderdate) AS PERIOD,COUNT(*) AS ORDERNUM ,SUM(ORDERS.TOTALCHARGES)*0.1 AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BATCHORDERS.BRANCHID=BRANCH.BRANCHID JOIN ORDERS ON BATCHORDERS.BATCHID=ORDERS.BATCHID WHERE orders.orderStatusID in (3,9,10) GROUP BY RESTAURANT.NAME,DATEPART(MONTH,batchorders.orderdate) ORDER BY SUM(ORDERS.TOTALCHARGES) DESC  "
        Dim queryAll As String = "SELECT RESTAURANT.NAME,COUNT(*) AS ORDERNUM ,SUM(ORDERS.TOTALCHARGES)*0.1 AS sales FROM USERACCOUNT JOIN RESTAURANT ON USERACCOUNT.USERID=RESTAURANT.USERID JOIN BRANCH ON RESTAURANT.RESTAURANTID=BRANCH.RESTAURANTID JOIN BATCHORDERS ON BATCHORDERS.BRANCHID=BRANCH.BRANCHID JOIN ORDERS ON BATCHORDERS.BATCHID=ORDERS.BATCHID WHERE orders.orderStatusID in (3,9,10) GROUP BY RESTAURANT.NAME ORDER BY SUM(ORDERS.TOTALCHARGES) DESC"



        Dim queryReservationWithoutPreorderAllByDate As String = "select CAST(RESERVATION.DATE AS DATE) AS PERIOD ,COUNT(*)*2 AS Reservationfee,RESTAURANT.NAME  from reservation join branch on branch.branchid=reservation.branchid join restaurant on branch.restaurantid=restaurant.restaurantid where preordermeals='No'  AND (RESERVATION.status='Approved' or RESERVATION.status= 'Completed') GROUP BY RESTAURANT.NAME,CAST(RESERVATION.DATE AS DATE) "
        Dim queryReservationWithoutPreorderAllByWeek As String = "select DATEPART(WEEK,RESERVATION.DATE) AS PERIOD ,COUNT(*)*2 AS Reservationfee,RESTAURANT.NAME  from reservation join branch on branch.branchid=reservation.branchid join restaurant on branch.restaurantid=restaurant.restaurantid where preordermeals='No'  AND (RESERVATION.status='Approved' or RESERVATION.status= 'Completed') GROUP BY RESTAURANT.NAME,DATEPART(WEEK,RESERVATION.DATE) "
        Dim queryReservationWithoutPreorderAllByMonth As String = "select DATEPART(MONTH,RESERVATION.DATE) AS PERIOD ,COUNT(*)*2 AS Reservationfee,RESTAURANT.NAME  from reservation join branch on branch.branchid=reservation.branchid join restaurant on branch.restaurantid=restaurant.restaurantid where preordermeals='No'  AND (RESERVATION.status='Approved' or RESERVATION.status= 'Completed') GROUP BY RESTAURANT.NAME,DATEPART(MONTH,RESERVATION.DATE) "
        Dim queryReservationWithoutPreorderAll As String = "select COUNT(*)*2 AS Reservationfee,RESTAURANT.NAME  from reservation join branch on branch.branchid=reservation.branchid join restaurant on branch.restaurantid=restaurant.restaurantid where preordermeals='No'  AND (RESERVATION.status='Approved' or RESERVATION.status= 'Completed') GROUP BY RESTAURANT.NAME"

        Using conn1 As New SqlConnection(connectionString)

            Using comm1 As New SqlCommand()
                With comm1
                    Dim mycommand1 As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn1
                    .CommandType = CommandType.Text
                    If periodType = "All" Then
                        .CommandText = queryReservationWithoutPreorderAll
                    ElseIf periodType = "Date" Then
                        .CommandText = queryReservationWithoutPreorderAllByDate
                    ElseIf periodType = "Week" Then
                        .CommandText = queryReservationWithoutPreorderAllByWeek
                    ElseIf periodType = "Month" Then
                        .CommandText = queryReservationWithoutPreorderAllByMonth
                    End If

                End With
                Try
                    conn1.Open()
                    Dim reader As SqlDataReader = comm1.ExecuteReader
                    Dim counter As Integer = 1
                    Dim tempobj As Report = New Report()
                    While reader.Read()


                        If periodType = "All" Then
                            tempobj.period = ""
                        ElseIf periodType = "Date" Then
                            tempobj.period = reader("PERIOD")
                        ElseIf periodType = "Week" Then
                            tempobj.period = reader("PERIOD")
                        ElseIf periodType = "Month" Then
                            tempobj.period = reader("PERIOD")

                        End If
                        tempobj.username = reader("NAME")
                        tempobj.totalOrder = 0
                        tempobj.sales = reader("ReservationFee")
                        referenceObj.Add(tempobj)
                        tempobj = New Report()
                    End While
                Catch ex As SqlException

                End Try
            End Using
        End Using




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

                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    Dim tempobj As Report = New Report()
                    While reader.Read()


                        If periodType = "All" Then
                            tempobj.period = ""
                        ElseIf periodType = "Date" Then
                            tempobj.period = reader("PERIOD")
                        ElseIf periodType = "Week" Then
                            tempobj.period = reader("PERIOD")
                        ElseIf periodType = "Month" Then
                            tempobj.period = reader("PERIOD")

                        End If
                        tempobj.username = reader("NAME")
                        tempobj.totalOrder = reader("ORDERNUM")
                        tempobj.sales = reader("sales")
                        returnObject.Add(tempobj)
                        tempobj = New Report()
                    End While
                Catch ex As SqlException

                End Try
            End Using
        End Using


        For Each refobj In referenceObj
            Dim counter As Integer = 1
            For Each retobj In returnObject
                If refobj.period = retobj.period And refobj.username = retobj.username Then
                    retobj.sales = retobj.sales + refobj.sales
                    counter = counter + 1
                End If
            Next
            If counter = 1 Then
                returnObject.Add(refobj)
            End If
        Next





        Return returnObject
    End Function


    Public Function getAdminReportUserNo(userType As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim query As String = "SELECT COUNT(*) AS NUMBER FROM USERACCOUNT WHERE TYPE=@usertype AND STATUS='APPROVED'"
        Dim userNum As Int32
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandText = query
                    .Parameters.AddWithValue("@usertype", userType)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    reader.Read()
                    userNum = reader("NUMBER")

                Catch ex As SqlException

                End Try
            End Using
        End Using


        Return userNum
    End Function




End Class
