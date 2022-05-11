Imports System.Configuration
Imports System.Data.SqlClient

Public Class Review
    Protected iRestaurantReviewId As Integer
    Protected sDescription As String
    Protected sDescriptionDel As String
    Protected iUserid As Integer
    Protected iBatchid As Integer
    Protected iBranchID As Integer
    Protected iRiderID As Integer
    Protected iRatingRest As Integer
    Protected iRatingDel As Integer
    Protected iReservationId As Integer
    Protected iDate As String

    Public Property RestaurantReviewId() As Integer
        Get
            RestaurantReviewId = iRestaurantReviewId
        End Get
        Set(ByVal Value As Integer)
            iRestaurantReviewId = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Description = sDescription
        End Get
        Set(ByVal Value As String)
            sDescription = Value
        End Set
    End Property

    Public Property DescriptionDel() As String
        Get
            DescriptionDel = sDescriptionDel
        End Get
        Set(ByVal Value As String)
            sDescriptionDel = Value
        End Set
    End Property

    Public Property Userid() As Integer
        Get
            Userid = iUserid
        End Get
        Set(ByVal Value As Integer)
            iUserid = Value
        End Set
    End Property

    Public Property Batchid() As Integer
        Get
            Batchid = iBatchid
        End Get
        Set(ByVal Value As Integer)
            iBatchid = Value
        End Set
    End Property

    Public Property BranchID() As Integer
        Get
            BranchID = iBranchID
        End Get
        Set(ByVal Value As Integer)
            iBranchID = Value
        End Set
    End Property

    Public Property RatingRest() As Integer
        Get
            RatingRest = iRatingRest
        End Get
        Set(ByVal Value As Integer)
            iRatingRest = Value
        End Set
    End Property

    Public Property RatingDel() As Integer
        Get
            RatingDel = iRatingDel
        End Get
        Set(ByVal Value As Integer)
            iRatingDel = Value
        End Set
    End Property

    Public Property ReservationId() As Integer
        Get
            ReservationId = iReservationId
        End Get
        Set(ByVal Value As Integer)
            iReservationId = Value
        End Set
    End Property

    Public Property RiderID() As Integer
        Get
            RiderID = iRiderID
        End Get
        Set(ByVal Value As Integer)
            iRiderID = Value
        End Set
    End Property

    Public Property DateID() As String
        Get
            DateID = iDate
        End Get
        Set(ByVal Value As String)
            iDate = Value
        End Set
    End Property

    Public Sub New()
    End Sub
    Public Sub InsertReviewReservation()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "INSERT INTO restaurant_review (description, userid, batchid, branchID, rating, reviewDate) " &
                                "VALUES (@description, @userid, @batchid, @branchID, @rating, Getdate()); "

        If Me.Batchid <> 0 Then
            Query += "UPDATE orders SET orderStatusID = 10 WHERE batchid = @batchid; "
        End If

        If Me.ReservationId <> 0 Then
            Query += "UPDATE reservation SET status = 'Reviewed' WHERE reservationId = @reservationId; "
        End If

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@description", SqlDbType.NVarChar).Value = Me.Description
                    .Parameters.Add("@userid", SqlDbType.Int).Value = Me.Userid
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.Batchid
                    .Parameters.Add("@branchID", SqlDbType.Int).Value = Me.BranchID
                    .Parameters.Add("@rating", SqlDbType.Int).Value = Me.RatingRest
                    .Parameters.Add("@reservationId", SqlDbType.Int).Value = Me.ReservationId
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
    End Sub

    Public Sub InsertReviewDelivery()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "INSERT INTO restaurant_review (description, userid, batchid, branchID, rating, reviewDate) " &
                                "VALUES (@description, @userid, @batchid, @branchID, @rating, GetDate()); "
        Query += "UPDATE orders SET orderStatusID = 10 WHERE batchid = @batchid; "
        Query += "INSERT INTO rider_review (description, reviewerID, riderID, rating, reviewDate) " &
                                "VALUES (@descriptionDel, @reviewerID, @riderID, @ratingDel, GetDate()); "
        Query += "UPDATE orders set riderReviewId = (SELECT SCOPE_IDENTITY()) Where batchid = @batchid; "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@description", SqlDbType.NVarChar).Value = Me.Description
                    .Parameters.Add("@userid", SqlDbType.Int).Value = Me.Userid
                    .Parameters.Add("@batchid", SqlDbType.Int).Value = Me.Batchid
                    .Parameters.Add("@branchID", SqlDbType.Int).Value = Me.BranchID
                    .Parameters.Add("@rating", SqlDbType.Int).Value = Me.RatingRest
                    .Parameters.Add("@descriptionDel", SqlDbType.NVarChar).Value = Me.DescriptionDel
                    .Parameters.Add("@reviewerID", SqlDbType.Int).Value = Me.Userid
                    .Parameters.Add("@riderID", SqlDbType.Int).Value = Me.RiderID
                    .Parameters.Add("@ratingDel", SqlDbType.Int).Value = Me.RatingDel
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As SqlException
                    Dim a As String = ex.Message
                End Try
            End Using
        End Using
    End Sub

    Public Function RetrieveBranchReviews(ByVal branchid As Integer)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Review) = New List(Of Review)
        Dim Query As String = "SELECT concat(firstName, ' ' ,lastName) as name, description,batchid,rating,reviewdate from restaurant_review as rv join useraccount as uc on rv.userid = uc.userid where branchid = @branchid"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = branchid
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Dim tempobj As Review = New Review()
                        'tempobj.RestaurantReviewId = Convert.ToInt32(reader("restaurantReviewId").ToString())
                        tempobj.Description = reader("description").ToString()
                        tempobj.DescriptionDel = reader("name").ToString()
                        tempobj.Batchid = Convert.ToInt32(reader("batchid").ToString())
                        'tempobj.BranchID = Convert.ToInt32(reader("branchid").ToString())
                        tempobj.RatingRest = Convert.ToInt32(reader("rating").ToString())
                        tempobj.DateID = reader("reviewDate")
                        returnObject.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function

    Public Function RetrieveBranchReviewsByDate(ByVal branchid As Integer, ByVal dateFrom As String, ByVal dateTo As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim returnObject As List(Of Review) = New List(Of Review)
        Dim Query As String = "SELECT concat(firstName, ' ' ,lastName) as name, description,batchid,rating,reviewdate from restaurant_review as rv join useraccount as uc on rv.userid = uc.userid where branchid = @branchid and reviewDate between '" & dateFrom & "' and '" & dateTo & "'"
        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.Add("@branchid", SqlDbType.Int).Value = branchid
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        Dim tempobj As Review = New Review()
                        'tempobj.RestaurantReviewId = Convert.ToInt32(reader("restaurantReviewId").ToString())
                        tempobj.Description = reader("description").ToString()
                        tempobj.DescriptionDel = reader("name").ToString()
                        tempobj.Batchid = Convert.ToInt32(reader("batchid").ToString())
                        'tempobj.BranchID = Convert.ToInt32(reader("branchid").ToString())
                        tempobj.RatingRest = Convert.ToInt32(reader("rating").ToString())
                        tempobj.DateID = reader("reviewDate")
                        returnObject.Add(tempobj)
                    End While
                Catch ex As SqlException
                End Try
            End Using
        End Using
        Return returnObject
    End Function
End Class
