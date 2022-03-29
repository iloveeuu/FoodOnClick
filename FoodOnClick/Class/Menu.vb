Imports System.Data.SqlClient

Public Class Menu
    Inherits Branch
    'Menu Table
    Protected int_menuId As Integer
    Protected str_menuName As String
    Protected str_menuDescription As String
    Protected dec_menuCost As Decimal
    Protected str_menuImage As String
    Protected int_menuStatusId As Integer
    Protected int_menuDiscountId As Integer
    Protected int_menuBranchId As Integer
    Protected int_menuFoodTypeId As Integer
    Protected int_menuProtein As Decimal
    Protected int_menuEnergy As Decimal
    Protected int_menuCarbonhydrate As Decimal
    Protected int_menuGlucose As Decimal
    Protected int_menuFats As Decimal
    Protected int_menuSodium As Decimal
    'Menu Discount Table
    Protected int_FKmenuDiscountId As Integer
    Protected int_FKmenuDiscountAmount As Decimal
    Protected int_FKmenuDiscountType As String
    Protected str_FKmenuDiscountString As String
    'Menu Nutrient Table

    'Menu Status Table
    Protected int_FKmenuStatusId As Integer
    Protected int_FKmenuStatusType As String
    'Menu Type Table
    Protected int_FKmenuFoodTypeId As Integer
    Protected str_FKmenuFoodType As String

    Protected str_location As String
    Protected str_cuisineType As String
    Protected str_foodType As String
    Protected str_dishName As String
    Protected dbl_minPrice As Decimal
    Protected dbl_maxPrice As Decimal

#Region "Objects"
    Public Property menuId() As Integer
        Get
            menuId = int_menuId
        End Get
        Set(ByVal Value As Integer)
            int_menuId = Value
        End Set
    End Property

    Public Property menuName() As String
        Get
            menuName = str_menuName
        End Get
        Set(ByVal Value As String)
            str_menuName = Value
        End Set
    End Property

    Public Property menuDescription() As String
        Get
            menuDescription = str_menuDescription
        End Get
        Set(ByVal Value As String)
            str_menuDescription = Value
        End Set
    End Property

    Public Property menuCost() As Decimal
        Get
            menuCost = dec_menuCost
        End Get
        Set(ByVal Value As Decimal)
            dec_menuCost = Value
        End Set
    End Property

    Public Property menuImage() As String
        Get
            menuImage = str_menuImage
        End Get
        Set(ByVal Value As String)
            str_menuImage = Value
        End Set
    End Property

    Public Property menuStatusId() As Integer
        Get
            menuStatusId = int_menuStatusId
        End Get
        Set(ByVal Value As Integer)
            int_menuStatusId = Value
        End Set
    End Property

    Public Property menuDiscountId() As Integer
        Get
            menuDiscountId = int_menuDiscountId
        End Get
        Set(ByVal Value As Integer)
            int_menuDiscountId = Value
        End Set
    End Property

    Public Property menuBranchId() As Integer
        Get
            menuBranchId = int_menuBranchId
        End Get
        Set(ByVal Value As Integer)
            int_menuBranchId = Value
        End Set
    End Property

    Public Property menuFoodTypeId() As Integer
        Get
            menuFoodTypeId = int_menuFoodTypeId
        End Get
        Set(ByVal Value As Integer)
            int_menuFoodTypeId = Value
        End Set
    End Property

    Public Property FKmenuDiscountId() As Integer
        Get
            FKmenuDiscountId = int_FKmenuDiscountId
        End Get
        Set(ByVal Value As Integer)
            int_FKmenuDiscountId = Value
        End Set
    End Property

    Public Property FKmenuDiscountType() As String
        Get
            FKmenuDiscountType = int_FKmenuDiscountType
        End Get
        Set(ByVal Value As String)
            int_FKmenuDiscountType = Value
        End Set
    End Property
    Public Property FKmenuDiscountAmount() As Decimal
        Get
            FKmenuDiscountAmount = int_FKmenuDiscountAmount
        End Get
        Set(ByVal Value As Decimal)
            int_FKmenuDiscountAmount = Value
        End Set
    End Property

    Public Property FKmenuDiscountString() As String
        Get
            FKmenuDiscountString = str_FKmenuDiscountString
        End Get
        Set(ByVal Value As String)
            str_FKmenuDiscountString = Value
        End Set
    End Property

    Public Property menuProtein() As Decimal
        Get
            menuProtein = int_menuProtein
        End Get
        Set(ByVal Value As Decimal)
            int_menuProtein = Value
        End Set
    End Property

    Public Property menuEnergy() As Decimal
        Get
            menuEnergy = int_menuEnergy
        End Get
        Set(ByVal Value As Decimal)
            int_menuEnergy = Value
        End Set
    End Property

    Public Property menuCarbonhydrate() As Decimal
        Get
            menuCarbonhydrate = int_menuCarbonhydrate
        End Get
        Set(ByVal Value As Decimal)
            int_menuCarbonhydrate = Value
        End Set
    End Property

    Public Property menuGlucose() As Decimal
        Get
            menuGlucose = int_menuGlucose
        End Get
        Set(ByVal Value As Decimal)
            int_menuGlucose = Value
        End Set
    End Property

    Public Property menuFats() As Decimal
        Get
            menuFats = int_menuFats
        End Get
        Set(ByVal Value As Decimal)
            int_menuFats = Value
        End Set
    End Property

    Public Property menuSodium() As Decimal
        Get
            menuSodium = int_menuSodium
        End Get
        Set(ByVal Value As Decimal)
            int_menuSodium = Value
        End Set
    End Property
    'Menu Status Table

    Public Property FKmenuStatusId() As Integer
        Get
            FKmenuStatusId = int_FKmenuStatusId
        End Get
        Set(ByVal Value As Integer)
            int_FKmenuStatusId = Value
        End Set
    End Property

    Public Property FKmenuStatusType() As String
        Get
            FKmenuStatusType = int_FKmenuStatusType
        End Get
        Set(ByVal Value As String)
            int_FKmenuStatusType = Value
        End Set
    End Property

    Public Property FKmenuFoodTypeId() As Integer
        Get
            FKmenuFoodTypeId = int_FKmenuFoodTypeId
        End Get
        Set(ByVal Value As Integer)
            int_FKmenuFoodTypeId = Value
        End Set
    End Property

    Public Property FKmenuFoodType() As String
        Get
            FKmenuFoodType = str_FKmenuFoodType
        End Get
        Set(ByVal Value As String)
            str_FKmenuFoodType = Value
        End Set
    End Property

    Public Property location() As String
        Get
            location = str_location
        End Get
        Set(ByVal Value As String)
            str_location = Value
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

    Public Sub New(ByVal restaurantid As Integer, ByVal branchid As Integer)
        Me.restaurantId = restaurantid
        Me.branchId = branchid
    End Sub
    Public Sub New(ByVal image As String)
        Me.menuImage = image
    End Sub
    Public Sub New(ByVal branchid As Integer)
        Me.branchId = branchid
    End Sub
    Public Sub New()
    End Sub
    Public Sub New(ByVal name As String, ByVal description As String, ByVal cost As Decimal, ByVal image As String, ByVal statusid As Integer, ByVal discountid As Integer, ByVal branchid As Integer, ByVal foodtypeid As Integer, ByVal protein As Decimal, ByVal energy As Decimal, ByVal carbohydrate As Decimal, ByVal glucose As Decimal, ByVal fats As Decimal, ByVal sodium As Decimal, ByVal menuid As Integer)
        Me.menuName = name
        Me.menuDescription = description
        Me.menuCost = cost
        Me.menuImage = image
        Me.menuStatusId = statusid
        Me.menuDiscountId = discountid
        Me.menuFoodTypeId = foodtypeid
        Me.menuProtein = protein
        Me.menuEnergy = energy
        Me.menuCarbonhydrate = carbohydrate
        Me.menuGlucose = glucose
        Me.menuFats = fats
        Me.menuSodium = sodium
        Me.menuId = menuid
    End Sub
    Public Sub New(ByVal name As String, ByVal description As String, ByVal cost As Decimal, ByVal image As String, ByVal statusid As Integer, ByVal discountid As Integer, ByVal branchid As Integer, ByVal foodtypeid As Integer, ByVal protein As Decimal, ByVal energy As Decimal, ByVal carbohydrate As Decimal, ByVal glucose As Decimal, ByVal fats As Decimal, ByVal sodium As Decimal)
        Me.menuName = name
        Me.menuDescription = description
        Me.menuCost = cost
        Me.menuImage = image
        Me.menuStatusId = statusid
        Me.menuDiscountId = discountid
        Me.menuBranchId = branchid
        Me.menuFoodTypeId = foodtypeid
        Me.menuProtein = protein
        Me.menuEnergy = energy
        Me.menuCarbonhydrate = carbohydrate
        Me.menuGlucose = glucose
        Me.menuFats = fats
        Me.menuSodium = sodium
    End Sub

    Public Function UpdateMenu() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE menu set name=@name,description=@description, cost=@cost,image=@image, statusid=@statusid, discountid=@discountid,foodtypeid=@foodtypeid,protein=@protein,energy=@energy,carbonhydrate=@carbonhydrate,glucose=@glucose,fats=@fats,sodium=@sodium where menuid=@menuid"
        Dim bool As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@name", SqlDbType.VarChar).Value = Me.menuName
                    .Parameters.Add("@description", SqlDbType.VarChar).Value = Me.menuDescription
                    .Parameters.Add("@cost", SqlDbType.Decimal).Value = Me.menuCost
                    .Parameters.Add("@image", SqlDbType.VarChar).Value = Me.menuImage
                    .Parameters.Add("@statusid", SqlDbType.Int).Value = Me.menuStatusId
                    .Parameters.Add("@discountid", SqlDbType.Int).Value = Me.menuDiscountId
                    .Parameters.Add("@foodtypeid", SqlDbType.Int).Value = Me.menuFoodTypeId
                    .Parameters.Add("@protein", SqlDbType.Decimal).Value = Me.menuProtein
                    .Parameters.Add("@energy", SqlDbType.Decimal).Value = Me.menuEnergy
                    .Parameters.Add("@carbonhydrate", SqlDbType.Decimal).Value = Me.menuCarbonhydrate
                    .Parameters.Add("@glucose", SqlDbType.Decimal).Value = Me.menuGlucose
                    .Parameters.Add("@fats", SqlDbType.Decimal).Value = Me.menuFats
                    .Parameters.Add("@sodium", SqlDbType.Decimal).Value = Me.menuSodium
                    .Parameters.Add("@menuid", SqlDbType.Int).Value = Me.menuId
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                    bool = ex.Message
                End Try
            End Using
        End Using
        Return bool
    End Function
    Public Function CreateMenu() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "INSERT INTO menu values(@name,@description,@cost,@image,@statusid,@discountid,@branchid,@foodtypeid,@protein,@energy,@carbonhydrate,@glucose,@fats,@sodium)"
        Dim bool As String = "True"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@name", SqlDbType.VarChar).Value = Me.menuName
                    .Parameters.Add("@description", SqlDbType.VarChar).Value = Me.menuDescription
                    .Parameters.Add("@cost", SqlDbType.Decimal).Value = Me.menuCost
                    .Parameters.Add("@image", SqlDbType.VarChar).Value = Me.menuImage
                    .Parameters.Add("@statusid", SqlDbType.Int).Value = Me.menuStatusId
                    .Parameters.Add("@discountid", SqlDbType.Int).Value = Me.menuDiscountId
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = Me.menuBranchId
                    .Parameters.Add("@foodtypeid", SqlDbType.Int).Value = Me.menuFoodTypeId
                    .Parameters.Add("@protein", SqlDbType.Decimal).Value = Me.menuProtein
                    .Parameters.Add("@energy", SqlDbType.Decimal).Value = Me.menuEnergy
                    .Parameters.Add("@carbonhydrate", SqlDbType.Decimal).Value = Me.menuCarbonhydrate
                    .Parameters.Add("@glucose", SqlDbType.Decimal).Value = Me.menuGlucose
                    .Parameters.Add("@fats", SqlDbType.Decimal).Value = Me.menuFats
                    .Parameters.Add("@sodium", SqlDbType.Decimal).Value = Me.menuSodium
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                    bool = ex.Message
                End Try
            End Using
        End Using
        Return bool
    End Function
    Public Function RetrieveAllMenuInfoByMenuId()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As Menu = New Menu
        Dim Query As String = "SELECT * from menu join menudiscount on menu.discountid = menudiscount.menu_discount_id join menustatus on menu.statusid = menustatus.menu_status_id join foodtype on menu.foodtypeid = foodtype.foodtypeid where menu.menuid = @menuid"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@menuid", SqlDbType.VarChar).Value = Me.menuId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        returnObject.menuName = reader("name")
                        returnObject.menuDescription = reader("description")
                        returnObject.menuCost = reader("cost")
                        returnObject.menuImage = reader("image")
                        returnObject.menuStatusId = reader("statusid")
                        'returnObject.FKmenuStatusType = reader("type")
                        returnObject.menuDiscountId = reader("discountid")
                        returnObject.branchId = reader("branchid")
                        returnObject.menuFoodTypeId = reader("foodtypeid")
                        returnObject.menuProtein = reader("protein")
                        returnObject.menuEnergy = reader("energy")
                        returnObject.menuCarbonhydrate = reader("carbonhydrate")
                        returnObject.menuGlucose = reader("glucose")
                        returnObject.menuFats = reader("fats")
                        returnObject.menuSodium = reader("sodium")
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function

#End Region

    Public Function RetrieveMenuInfo()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Menu) = New List(Of Menu)
        Dim Query As String = "SELECT m.menuid,m.name,m.description,m.cost,m.image,m.statusid,m.discountid,m.branchid,m.foodtypeid,m.protein,m.energy,m.carbonhydrate,m.glucose,m.fats,m.sodium,menustatus.type as statustype,foodtype.type as foodtype from menu as m join menustatus on m.Statusid = menustatus.menu_status_id join foodtype on m.foodTypeID = foodtype.foodTypeID where branchid = @branchid"
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
                    While reader.Read()
                        Dim tempobj As Menu = New Menu()
                        tempobj.menuId = reader("menuid")
                        tempobj.menuName = reader("name")
                        tempobj.menuDescription = reader("description")
                        tempobj.menuCost = reader("cost")
                        tempobj.menuImage = reader("image")
                        tempobj.menuStatusId = reader("Statusid")
                        tempobj.FKmenuStatusType = reader("statustype")
                        tempobj.FKmenuFoodType = reader("foodtype")
                        tempobj.menuDiscountId = reader("discountid")
                        tempobj.menuBranchId = reader("branchid")
                        tempobj.menuFoodTypeId = reader("foodtypeID")
                        tempobj.menuProtein = reader("protein")
                        tempobj.menuEnergy = reader("energy")
                        tempobj.menuCarbonhydrate = reader("carbonhydrate")
                        tempobj.menuGlucose = reader("glucose")
                        tempobj.menuFats = reader("fats")
                        tempobj.menuSodium = reader("sodium")
                        returnObject.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function
    Public Function RetrieveAllMenuStatus()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Menu) = New List(Of Menu)
        Dim Query As String = "SELECT * from MenuStatus"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Dim tempobj As Menu = New Menu()
                        tempobj.FKmenuStatusId = reader("menu_status_id")
                        tempobj.FKmenuStatusType = reader("type")
                        returnObject.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function

    Public Function RetrieveAllMenuDiscount()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Menu) = New List(Of Menu)
        Dim Query As String = "SELECT * from MenuDiscount"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Dim tempobj As Menu = New Menu()
                        tempobj.FKmenuDiscountId = reader("menu_Discount_id")
                        tempobj.FKmenuDiscountString = reader("discountAmount") & " " & reader("discountType")
                        tempobj.FKmenuDiscountAmount = reader("discountAmount")
                        tempobj.FKmenuDiscountType = reader("discountType")
                        returnObject.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function

    Public Function RetrieveAllMenuFoodType()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Menu) = New List(Of Menu)
        Dim Query As String = "SELECT * from Foodtype"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Dim tempobj As Menu = New Menu()
                        tempobj.FKmenuFoodTypeId = reader("foodTypeID")
                        tempobj.FKmenuFoodType = reader("type")
                        returnObject.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function
    Public Function CheckImageNameIsUnique() As Boolean
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "Select image from menu where image = @imageid"
        Dim bool As Boolean = True
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@imageid", SqlDbType.VarChar).Value = Me.menuImage
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        bool = False
                    End While
                Catch ex As SqlException
                    bool = ex.Message
                End Try
            End Using
        End Using
        Return bool
    End Function


    Public Function GetSearchReservation(ByVal location As String, ByVal restaurantName As String, ByVal category As String, ByVal type As String,
                                           ByVal dishName As String, ByVal halal As String, ByVal dblMinPrice As Double, ByVal dblMaxPrice As Double)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtSearch = New DataTable()
        Dim Query As String = "SELECT r.restaurantID, ua.firstname, b.email, b.branchid, (r.name + ' - ' + b.city) as restName, b.address, " &
                            "ISNULL(m.name,'') as dishName, b.halal,m.image, m.cost as price, b.time_open, b.time_closed " &
                            "from branch as b " &
                            "inner join restaurant as r on r.restaurantId = b.restaurantId " &
                            "inner join useraccount as ua on ua.userid = r.userid " &
                            "inner join CuisineType As c On c.cuisine_Typeid = b.cuisineTypeID " &
                            "left join Menu as m on b.branchid = m.branchid AND m.name Like (@dish_name) AND " &
                            "(m.cost >= @minPrice) AND m.cost <= IIF(@maxPrice = '0', (m.cost), (@maxPrice)) " &
                            "inner join MenuStatus As ms On m.Statusid = ms.menu_status_id And ms.type = 'Available' " &
                            "Left Join FoodType As ft On m.foodtypeID = ft.foodtypeID " &
                            "WHERE b.reservation = 'Allowed' and r.status = 'IN BUSINESS' AND b.status = 'IN BUSINESS' And " &
                            "(CONCAT(b.address, ' ', b.city, ' ', b.postalcode) LIKE @location) AND " &
                            "r.name Like (@restaurant_name) AND " &
                            "c.foodtype Like @cuisine_type AND " &
                            "ft.type like (@food_type) AND " &
                            "(b.halal like @halal) Order By r.restaurantID, b.branchid"

        ' AND 

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

        sLocation = "%" + location + "%"
        sRestName = "%" + restaurantName + "%"

        If category = "Please select" Then
            sCuisinceType = "%%"
        Else
            sCuisinceType = "%" + category + "%"
        End If

        If type = "Please select" Then
            sFoodType = "%%"
        Else
            sFoodType = "%" + type + "%"
        End If

        If halal = "Please select" Then
            sHalal = "%%"
        Else
            sHalal = "%" + halal + "%"
        End If

        sDishName = "%" + dishName + "%"

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
                    .Parameters.Add("@minPrice", SqlDbType.Decimal).Value = dblMinPrice
                    .Parameters.Add("@maxPrice", SqlDbType.Decimal).Value = dblMaxPrice
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

    Public Function GetSearchDelivery(ByVal location As String, ByVal restaurantName As String, ByVal category As String, ByVal type As String,
                                           ByVal dishName As String, ByVal halal As String, ByVal dblMinPrice As Double, ByVal dblMaxPrice As Double)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtSearch = New DataTable()
        Dim Query As String = "SELECT r.restaurantID, ua.firstname, b.email, b.branchid, (r.name + ' - ' + b.city) as restName, b.address, " &
                            "ISNULL(m.name,'') as dishName, b.halal,m.image, m.cost as price, b.time_open, b.time_closed " &
                            "from branch as b " &
                            "inner join restaurant as r on r.restaurantId = b.restaurantId " &
                            "inner join useraccount as ua on ua.userid = r.userid " &
                            "inner join CuisineType As c On c.cuisine_Typeid = b.cuisineTypeID " &
                            "left join Menu as m on b.branchid = m.branchid AND m.name Like (@dish_name) AND " &
                            "(m.cost >= @minPrice) AND m.cost <= IIF(@maxPrice = '0', (m.cost), (@maxPrice)) " &
                            "inner join MenuStatus As ms On m.Statusid = ms.menu_status_id And ms.type = 'Available' " &
                            "Left Join FoodType As ft On m.foodtypeID = ft.foodtypeID " &
                            "WHERE r.status = 'IN BUSINESS' AND b.status = 'IN BUSINESS' And " &
                            "(CONCAT(b.address, ' ', b.city, ' ', b.postalcode) LIKE @location) AND " &
                            "r.name Like (@restaurant_name) AND " &
                            "c.foodtype Like @cuisine_type AND " &
                            "ft.type like (@food_type) AND " &
                            "(b.halal like @halal) Order By r.restaurantID, b.branchid"

        Dim sLocation As String
        Dim sRestName As String
        Dim sCuisinceType As String
        Dim sFoodType As String
        Dim sDishName As String
        Dim sHalal As String

        sLocation = "%" + location + "%"
        sRestName = "%" + restaurantName + "%"

        If category = "Please select" Then
            sCuisinceType = "%%"
        Else
            sCuisinceType = "%" + category + "%"
        End If

        If type = "Please select" Then
            sFoodType = "%%"
        Else
            sFoodType = "%" + type + "%"
        End If

        If halal = "Please select" Then
            sHalal = "%%"
        Else
            sHalal = "%" + halal + "%"
        End If

        sDishName = "%" + dishName + "%"

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
                    .Parameters.Add("@minPrice", SqlDbType.Decimal).Value = dblMinPrice
                    .Parameters.Add("@maxPrice", SqlDbType.Decimal).Value = dblMaxPrice
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


    Public Function GetSearchMenu(ByVal iBranchId As Integer, ByVal type As String, ByVal dishName As String, ByVal dblMinPrice As Double, ByVal dblMaxPrice As Double)
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
                            "ft.type like (@food_type) and b.branchid=@branchId "

        '"(m.description + '<br/><br/>Protein: ' + m.energy + ' cal.<br/>' " &
        '                    "Protein: ' + m.protein + ' g<br/>' " &
        '                    "Carbs: ' + m.carbonhydrate + ' g<br/>' " &
        '                    "Sugar: ' + m.glucose + ' g<br/>' " &
        '                    "Fat: ' + m.fats + ' g<br/>' " &
        '                    "Sodium: ' + m.sodium + ' g') As desc " &
        Dim sFoodType As String
        Dim sDishName As String

        If type = "Please select" Then
            sFoodType = "%%"
        Else
            sFoodType = "%" + type + "%"
        End If

        sDishName = "%" + dishName + "%"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@branchId", SqlDbType.Int).Value = iBranchId
                    .Parameters.Add("@food_type", SqlDbType.VarChar).Value = sFoodType
                    .Parameters.Add("@dish_name", SqlDbType.VarChar).Value = sDishName
                    .Parameters.Add("@minPrice", SqlDbType.Decimal).Value = dblMinPrice
                    .Parameters.Add("@maxPrice", SqlDbType.Decimal).Value = dblMaxPrice
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
