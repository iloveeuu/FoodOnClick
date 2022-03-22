Imports System.Configuration
Imports System.Data.SqlClient

Public Class ShoppingCartDetail
    Inherits ShoppingCart

    Protected iMenuid As Integer
    Protected iQuantity As Integer
    Protected dPrice As Decimal
    Protected iBranchId As Decimal

#Region "Objects"
    Public Property menuid() As Integer
        Get
            menuid = iMenuid
        End Get
        Set(ByVal Value As Integer)
            iMenuid = Value
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

    Public Property quantity() As Integer
        Get
            quantity = iQuantity
        End Get
        Set(ByVal Value As Integer)
            iQuantity = Value
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

#End Region

    Public Sub New()
    End Sub

    Public Sub New(ByVal iMenuid As Integer, ByVal iQuantity As Integer,
                   ByVal dPrice As Decimal)
        Me.menuid = iMenuid
        Me.quantity = iQuantity
        Me.price = dPrice
    End Sub

#Region "Functions"
    Public Sub InsertShoppingCartDetail()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        Query = "INSERT INTO ShoppingCart_Menu (cartid, menuid, quantity, price) " &
                            "VALUES (@cartid, " &
                            "@menuid, @quantity, (CAST(@quantity AS Decimal(10,2)) * @price));" &
                "Update ShoppingCart set totalprice += (CAST(@quantity AS Decimal(10,2)) * @price) " &
                            "WHERE userid = @userID and cartid = @cartid; "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userID", SqlDbType.Int).Value = MyBase.userID
                    .Parameters.Add("@menuid", SqlDbType.Int).Value = Me.menuid
                    .Parameters.Add("@quantity", SqlDbType.Int).Value = Me.quantity
                    .Parameters.Add("@price", SqlDbType.Decimal).Value = Me.price
                    .Parameters.Add("@cartid", SqlDbType.Int).Value = Me.cartID
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

    Public Function CheckRestaurantInCart() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim returnInt As Integer

        Dim Query As String = "SELECT sc.cartid " &
                                "from branch as b " &
                                " inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                " inner join menu as m on m.branchId = b.branchId " &
                                " inner join shoppingcart_menu as scm on scm.menuid = m.menuid " &
                                " inner join shoppingcart as sc on sc.cartid = scm.cartid " &
                                "where sc.userid = @userID and b.branchid = @branchId  "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userID
                    .Parameters.Add("@branchId", SqlDbType.Int).Value = Me.branchId
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        While reader.Read()
                            returnInt = reader("cartid")
                        End While
                    Else
                        returnInt = 0
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return returnInt
    End Function


    Public Function CheckMenuInsertedInCart() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim returnInt As Integer

        Dim Query As String = "SELECT TOP 1 a.cartid FROM ShoppingCart_Menu As a inner join ShoppingCart as B on a.cartid = b.cartid WHERE b.userid = @userId and a.menuid = @menuid "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userId", SqlDbType.Int).Value = Me.userID
                    .Parameters.Add("@menuid", SqlDbType.Int).Value = Me.menuid
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        While reader.Read()
                            returnInt = reader("cartid")
                        End While
                    Else
                        returnInt = 0
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return returnInt
    End Function

    Public Sub UpdateShoppingCart()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        Query = "Update ShoppingCart_Menu set ShoppingCart_Menu.quantity += @quantity, ShoppingCart_Menu.price += (CAST(@quantity AS Decimal(10,2)) * @price) " &
                            "FROM ShoppingCart_Menu Inner join ShoppingCart on ShoppingCart_Menu.cartid = ShoppingCart.cartid " &
                            "WHERE ShoppingCart_Menu.menuid = @menuid and ShoppingCart.userid = @userID and ShoppingCart.cartid = @cartid; " &
                            "Update ShoppingCart SET totalprice += (CAST(@quantity AS Decimal(10,2)) * @price) WHERE cartid = @cartid; "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userID", SqlDbType.Int).Value = MyBase.userID
                    .Parameters.Add("@menuid", SqlDbType.Int).Value = Me.menuid
                    .Parameters.Add("@quantity", SqlDbType.Int).Value = Me.quantity
                    .Parameters.Add("@price", SqlDbType.Decimal).Value = Me.price
                    .Parameters.Add("@cartid", SqlDbType.Int).Value = Me.cartID
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

    Public Sub CancelOrderedMenuInShoppingCart()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        Query = "Update ShoppingCart set ShoppingCart.totalprice -= ShoppingCart_Menu.price " &
                            "FROM ShoppingCart Inner join ShoppingCart_Menu on ShoppingCart.cartid = ShoppingCart_Menu.cartid " &
                            "WHERE ShoppingCart_Menu.menuid = @menuid and ShoppingCart.userid = @userID and ShoppingCart.cartid = @cartid; " &
                            "Delete From ShoppingCart_Menu WHERE menuid = @menuid and cartid = @cartid; "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userID", SqlDbType.Int).Value = MyBase.userID
                    .Parameters.Add("@menuid", SqlDbType.Int).Value = Me.menuid
                    .Parameters.Add("@cartid", SqlDbType.Int).Value = Me.cartID
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

    Public Function GetAllCartByUserID()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtData = New DataTable()

        Dim Query As String = "SELECT b.branchid, (r.name + ' - ' + b.city) As restName, b.address, scm.menuid, (sc.type + ' ID: ' + CAST(sc.cartId AS NVARCHAR(20))) as type, sc.totalPrice, m.name as dishName, scm.price, m.cost as unitprice, scm.quantity, scm.cartId, b.email " &
                                "from branch as b " &
                                " inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                " inner join menu as m on m.branchId = b.branchId " &
                                " inner join shoppingcart_menu as scm on scm.menuid = m.menuid " &
                                " inner join shoppingcart as sc on sc.cartid = scm.cartid " &
                                "where sc.userid = @userID order by scm.cartId, r.name, b.address, scm.menuid, sc.type, m.name "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@userID", SqlDbType.Int).Value = Me.userID
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtData.Load(reader)
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return dtData
    End Function

    Public Sub ClearShoppingCart()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtData = New DataTable()

        Dim Query As String = "Update shoppingcart_menu set quantity = 0, price = 0  where cartid = @cartid; " &
                                "Update shoppingcart set totalprice = 0  where cartid = @cartid; "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@cartid", SqlDbType.Int).Value = Me.cartID
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

    Public Function GetAllCartByCartID()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Dim dtData = New DataTable()

        Dim Query As String = "SELECT (r.name + ' - ' + b.city) As restName, sc.userid, b.branchid, b.address, scm.menuid, sc.type, sc.totalPrice, m.name as menu, scm.price, scm.quantity, b.email, " &
                                "(m.description + 'CHAR(13)CHAR(13)Energy: ' + CONVERT(nvarchar(20),m.energy) + ' cal.' + " &
                            "'CHAR(13)Protein: ' + CONVERT(nvarchar(20),m.protein) + ' g' + " &
                            "'CHAR(13)Carbs: ' + CONVERT(nvarchar(20),m.carbonhydrate) + ' g' + " &
                            "'CHAR(13)Sugar: ' + CONVERT(nvarchar(20),m.glucose) + ' g' + " &
                            "'CHAR(13)Fats: ' + CONVERT(nvarchar(20),m.fats) + ' g' + " &
                            "'CHAR(13)Sodium: ' + CONVERT(nvarchar(20),m.sodium) + ' g' " &
                            ") As describe " &
                                "from branch as b " &
                                " inner join restaurant as r on r.restaurantId = b.restaurantId " &
                                " inner join menu as m on m.branchId = b.branchId " &
                                " inner join shoppingcart_menu as scm on scm.menuid = m.menuid " &
                                " inner join shoppingcart as sc on sc.cartid = scm.cartid " &
                                "where sc.cartid = @cartID "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@cartID", SqlDbType.Int).Value = Me.cartID
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    If (reader.HasRows) Then
                        dtData.Load(reader)

                        dtData.Columns(11).ReadOnly = False

                        For i As Integer = 0 To dtData.Rows.Count - 1
                            dtData.Rows(i)(11) = dtData.Rows(i)(11).ToString().Replace("CHAR(13)", "<br/>")
                        Next
                    End If

                    conn.Close()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
        Return dtData
    End Function
#End Region

End Class

