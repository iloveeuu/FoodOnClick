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
    Public Sub InsertOrder()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = ""

        If MyBase.orderTypeID = 10 Then
            Query = "INSERT INTO Orders (totalcharges, orderStatusID, batchID) " &
                            "VALUES (@totalcharges, 6, " &
                            "(SELECT TOP 1 batchID FROM batchorders Where userID = @userID Order BY batchID DESC)) "
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
