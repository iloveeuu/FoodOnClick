Imports System.Configuration
Imports System.Data.SqlClient

Public Class ShoppingCart

    Protected iCartID As Integer
    Protected dTotalprices As Decimal
    Protected iUserID As Integer
    Protected sType As String

#Region "Objects"
    Public Property cartID() As Integer
        Get
            cartID = iCartID
        End Get
        Set(ByVal Value As Integer)
            iCartID = Value
        End Set
    End Property

    Public Property totalprices() As Decimal
        Get
            totalprices = dTotalprices
        End Get
        Set(ByVal Value As Decimal)
            dTotalprices = Value
        End Set
    End Property

    Public Property userID() As Integer
        Get
            userID = iUserID
        End Get
        Set(ByVal Value As Integer)
            iUserID = Value
        End Set
    End Property

    Public Property type() As String
        Get
            type = sType
        End Get
        Set(ByVal Value As String)
            sType = Value
        End Set
    End Property
#End Region

    Public Sub New()
    End Sub

    Public Sub New(ByVal iCartID As Integer, ByVal dTotalprices As Decimal,
                   ByVal iUserID As Integer, ByVal sType As String)
        Me.cartID = iCartID
        Me.totalprices = dTotalprices
        Me.userID = iUserID
        Me.type = sType
    End Sub

#Region "Functions"
    Public Function InsertShoppinngCart()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""
        Query = "INSERT INTO ShoppingCart (totalprice, userID, type) " &
                            "VALUES (@totalprice, @userID, @type);SELECT SCOPE_IDENTITY();"

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@totalprice", SqlDbType.Decimal).Value = Me.totalprices
                    .Parameters.Add("@userID", SqlDbType.Int).Value = Me.userID
                    .Parameters.Add("@type", SqlDbType.NVarChar).Value = Me.type
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

    Public Sub CancelShoppingCart()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""


        Query = "Delete from ShoppingCart Where cartId=@cartId "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@cartId", SqlDbType.Decimal).Value = Me.cartID
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
#End Region

End Class