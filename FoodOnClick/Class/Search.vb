Imports System.Configuration
Imports System.Data.SqlClient

Public Class Search

    Protected str_location As String
    Protected str_restaurantName As String
    Protected str_cuisineType As String
    Protected str_foodType As String
    Protected str_dishName As String
    Protected str_halal As String
    Protected dbl_minPrice As Decimal
    Protected dbl_maxPrice As Decimal

#Region "Objects"
    Public Property location() As String
        Get
            location = str_location
        End Get
        Set(ByVal Value As String)
            str_location = Value
        End Set
    End Property

    Public Property restaurantName() As String
        Get
            restaurantName = str_restaurantName
        End Get
        Set(ByVal Value As String)
            str_restaurantName = Value
        End Set
    End Property

    Public Property cuisineType() As String
        Get
            cuisineType = str_cuisineType
        End Get
        Set(ByVal Value As String)
            str_cuisineType = Value
        End Set
    End Property

    Public Property foodType() As String
        Get
            foodType = str_foodType
        End Get
        Set(ByVal Value As String)
            str_foodType = Value
        End Set
    End Property

    Public Property dishName() As String
        Get
            dishName = str_dishName
        End Get
        Set(ByVal Value As String)
            str_dishName = Value
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

    Public Property minPrice() As Double
        Get
            minPrice = dbl_minPrice
        End Get
        Set(ByVal Value As Double)
            dbl_minPrice = Value
        End Set
    End Property

    Public Property maxPrice() As Double
        Get
            maxPrice = dbl_maxPrice
        End Get
        Set(ByVal Value As Double)
            dbl_maxPrice = Value
        End Set
    End Property

#End Region

    Public Sub New()
    End Sub

    Public Sub New(ByVal location As String, ByVal restaurantName As String, ByVal cuisineType As String,
                   ByVal foodType As String, ByVal dishName As String,
                   ByVal halal As String, ByVal minPrice As Double, ByVal maxPrice As Double)
        Me.location = location
        Me.restaurantName = restaurantName
        Me.cuisineType = cuisineType
        Me.foodType = foodType
        Me.dishName = dishName
        Me.halal = halal
        Me.minPrice = minPrice
        Me.maxPrice = maxPrice
    End Sub

    Public Function GetSearchReservation()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtSearch = New DataTable()
        Dim Query As String = "SELECT r.restaurantID, ua.firstname, b.email, b.branchid, (r.name + ' - ' + b.city) as restName, b.address, " &
                            "ISNULL(m.name,'') as dishName, b.halal, m.cost as price, b.time_open, b.time_closed " &
                            "from branch as b " &
                            "inner join restaurant as r on r.restaurantId = b.restaurantId " &
                            "inner join useraccount as ua on ua.userid = r.userid " &
                            "inner join CuisineType As c On c.cuisine_Typeid = b.cuisineTypeID " &
                            "left join Menu as m on b.branchid = m.branchid AND m.name Like (@dish_name) AND " &
                            "(m.cost >= @minPrice) AND m.cost <= IIF(@maxPrice = '0', (m.cost), (@maxPrice)) " &
                            "inner join MenuStatus As ms On m.Statusid = ms.menu_status_id And ms.type = 'Available' " &
                            "Left Join FoodType As ft On m.foodtypeID = ft.foodtypeID AND ft.type like (@food_type) " &
                            "WHERE r.status = 'IN BUSINESS' AND b.status = 'IN BUSINESS' And " &
                            "(CONCAT(b.address, ' ', b.city, ' ', b.postalcode) LIKE @location) AND " &
                            "r.name Like (@restaurant_name) AND " &
                            "c.foodtype Like @cuisine_type AND " &
                            "(b.halal like @halal) "

        '"SELECT r.restaurantID, ua.firstname, ua.email, b.branchid, r.name as restName, b.address, ISNULL(m.name,'') as dishName, b.halal from branch as b " &
        '                    "inner join restaurant as r on r.restaurantId = b.restaurantId " &
        '                    "inner join useraccount as ua on ua.userid = r.userid " &
        '                    "inner join CuisineType As c On c.cuisine_Typeid = b.cuisineTypeID " &
        '                    "left join Menu as m on b.branchid = m.branchid " &
        '                    "left join MenuStatus As ms On m.Statusid = ms.menu_status_id And ms.type = 'Available' " &
        '                    "Left Join FoodType As ft On m.foodtypeID = ft.foodtypeID " &
        '                    "WHERE r.status = 'IN BUSINESS' AND b.status = 'IN BUSINESS' And " &
        '                    "(CONCAT(b.address, ' ', b.city, ' ', b.postalcode) LIKE IIf(@location = '',CONCAT(b.address, ' ', b.city, ' ', b.postalcode),@location)) AND " &
        '                    "r.name Like IIf(@restaurant_name = '', (r.name), (@restaurant_name)) AND " &
        '                    "c.foodtype Like IIf(@cuisine_type = '', (c.foodtype), (@cuisine_type)) AND " &
        '                    "(b.halal like @halal)"
        'ISNULL(m.image,'') as dishImage
        'm.name Like IIf(@dish_name = '', (m.name), (@dish_name)) AND
        'ft.type like IIF(@food_type = '', (ft.type), ('%@food_type%')) AND
        '(m.cost > '@minPrice') AND m.cost < IIF('@maxPrice' = '0', (m.cost), ('@maxPrice')) 


        Dim sLocation As String
        Dim sRestName As String
        Dim sCuisinceType As String
        Dim sFoodType As String
        Dim sDishName As String
        Dim sHalal As String

        sLocation = "%" + Me.location + "%"
        sRestName = "%" + Me.restaurantName + "%"

        If Me.cuisineType = "Please select" Then
            sCuisinceType = "%%"
        Else
            sCuisinceType = "%" + Me.str_cuisineType + "%"
        End If

        If Me.foodType = "Please select" Then
            sFoodType = "%%"
        Else
            sFoodType = "%" + Me.foodType + "%"
        End If

        If Me.halal = "Please select" Then
            sHalal = "%%"
        Else
            sHalal = "%" + Me.halal + "%"
        End If

        sDishName = "%" + Me.dishName + "%"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@location", SqlDbType.VarChar).Value = sLocation
                    .Parameters.Add("@restaurant_name", SqlDbType.VarChar).Value = sRestName
                    .Parameters.Add("@cuisine_type", SqlDbType.VarChar).Value = sCuisinceType
                    .Parameters.Add("@food_type", SqlDbType.VarChar).Value = sFoodType
                    .Parameters.Add("@dish_name", SqlDbType.VarChar).Value = sDishName
                    .Parameters.Add("@halal", SqlDbType.VarChar).Value = sHalal
                    .Parameters.Add("@minPrice", SqlDbType.Decimal).Value = Me.minPrice
                    .Parameters.Add("@maxPrice", SqlDbType.Decimal).Value = Me.maxPrice
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtSearch.Load(reader)
                    End If

                    conn.Close()
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return dtSearch
    End Function

    Public Function GetSearchMenu()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtSearch = New DataTable()
        Dim Query As String = "SELECT b.branchid, m.menuid, m.name as dishName, m.cost as price, " &
                            "(m.description + 'CHAR(13)CHAR(13)Energy: ' + CONVERT(nvarchar(20),m.energy) + ' cal.' + " &
                            "'CHAR(13)Protein: ' + CONVERT(nvarchar(20),m.protein) + ' g' + " &
                            "'CHAR(13)Carbs: ' + CONVERT(nvarchar(20),m.carbonhydrate) + ' g' + " &
                            "'CHAR(13)Sugar: ' + CONVERT(nvarchar(20),m.glucose) + ' g' + " &
                            "'CHAR(13)Fats: ' + CONVERT(nvarchar(20),m.fats) + ' g' + " &
                            "'CHAR(13)Sodium: ' + CONVERT(nvarchar(20),m.sodium) + ' g' " &
                            ") As describe " &
                            "from branch as b " &
                            "inner join Menu as m on b.branchid = m.branchid " &
                            "inner join MenuStatus As ms On m.Statusid = ms.menu_status_id And ms.type = 'Available' " &
                            "inner Join FoodType As ft On m.foodtypeID = ft.foodtypeID " &
                            "WHERE m.name Like (@dish_name) AND  " &
                            "(m.cost >= @minPrice) AND m.cost <= IIF(@maxPrice = '0', (m.cost), (@maxPrice)) AND " &
                            "ft.type like (@food_type)"

        '"(m.description + '<br/><br/>Protein: ' + m.energy + ' cal.<br/>' " &
        '                    "Protein: ' + m.protein + ' g<br/>' " &
        '                    "Carbs: ' + m.carbonhydrate + ' g<br/>' " &
        '                    "Sugar: ' + m.glucose + ' g<br/>' " &
        '                    "Fat: ' + m.fats + ' g<br/>' " &
        '                    "Sodium: ' + m.sodium + ' g') As desc " &
        Dim sFoodType As String
        Dim sDishName As String

        If Me.foodType = "Please select" Then
            sFoodType = "%%"
        Else
            sFoodType = "%" + Me.foodType + "%"
        End If

        sDishName = "%" + Me.dishName + "%"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@food_type", SqlDbType.VarChar).Value = sFoodType
                    .Parameters.Add("@dish_name", SqlDbType.VarChar).Value = sDishName
                    .Parameters.Add("@minPrice", SqlDbType.Decimal).Value = Me.minPrice
                    .Parameters.Add("@maxPrice", SqlDbType.Decimal).Value = Me.maxPrice
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtSearch.Load(reader)
                        dtSearch.Columns(4).ReadOnly = False

                        For i As Integer = 0 To dtSearch.Rows.Count - 1
                            dtSearch.Rows(i)(4) = dtSearch.Rows(i)(4).ToString().Replace("CHAR(13)", "<br/>")
                        Next
                    End If

                    conn.Close()
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return dtSearch
    End Function

End Class
