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
        Dim Query As String = "SELECT r.restaurantID, ua.firstname, ua.email, b.branchid, r.name as restName, b.address, ISNULL(m.name,'') as dishName, b.halal from branch as b " &
                            "inner join restaurant as r on r.restaurantId = b.restaurantId " &
                            "inner join useraccount as ua on ua.userid = r.userid " &
                            "inner join CuisineType As c On c.cuisine_Typeid = b.cuisineTypeID " &
                            "left join Menu as m on b.branchid = m.branchid " &
                            "left join MenuStatus As ms On m.Statusid = ms.menu_status_id And ms.type = 'Available' " &
                            "Left Join FoodType As ft On m.foodtypeID = ft.foodtypeID " &
                            "WHERE r.status = 'IN BUSINESS' AND b.status = 'IN BUSINESS' And " &
                            "(CONCAT(b.address, ' ', b.city, ' ', b.postalcode) LIKE IIf(@location = '',CONCAT(b.address, ' ', b.city, ' ', b.postalcode),@location)) AND " &
                            "r.name Like IIf(@restaurant_name = '', (r.name), (@restaurant_name)) AND " &
                            "c.foodtype Like IIf(@cuisine_type = '', (c.foodtype), (@cuisine_type)) AND " &
                            "(b.halal = @halal)"

        'ISNULL(m.image,'') as dishImage
        'm.name Like IIf(@dish_name = '', (m.name), (@dish_name)) AND
        'ft.type like IIF(@food_type = '', (ft.type), ('%@food_type%')) AND
        '(m.cost > '@minPrice') AND m.cost < IIF('@maxPrice' = '0', (m.cost), ('@maxPrice')) 


        Dim sLocation As String
        Dim sRestName As String
        Dim sCuisinceType As String
        Dim sFoodType As String
        Dim sDishName As String

        sLocation = "%" + Me.location + "%"
        sRestName = "%" + Me.restaurantName + "%"
        sCuisinceType = "%" + Me.cuisineType + "%"
        sFoodType = "%" + Me.foodType + "%"
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
                    .Parameters.Add("@halal", SqlDbType.VarChar).Value = Me.halal
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

End Class
