Imports System.Data.SqlClient
Imports System.Configuration
Public Class Support

    Protected int_supportid As Int32
    Protected str_subject As String
    Protected str_description As String
    Protected int_userID As Int32
    Protected date_datesubmitted As String
    Protected date_dateclose As String
    Protected str_status As String
    Protected str_conversation As String

    Protected str_type As String
    Protected str_email As String


    Public Property supportid() As Int32
        Get
            supportid = int_supportid
        End Get
        Set(ByVal Value As Int32)
            int_supportid = Value
        End Set
    End Property



    Public Property subject() As String
        Get
            subject = str_subject
        End Get
        Set(ByVal Value As String)
            str_subject = Value
        End Set
    End Property


    Public Property description() As String
        Get
            description = str_description
        End Get
        Set(ByVal Value As String)
            str_description = Value
        End Set
    End Property


    Public Property userID() As Int32
        Get
            userID = int_userID
        End Get
        Set(ByVal Value As Int32)
            int_userID = Value
        End Set
    End Property


    Public Property datesubmitted() As String
        Get
            datesubmitted = date_datesubmitted
        End Get
        Set(ByVal Value As String)
            date_datesubmitted = Value
        End Set
    End Property

    Public Property dateclose() As String
        Get
            dateclose = date_dateclose
        End Get
        Set(ByVal Value As String)
            date_dateclose = Value
        End Set
    End Property


    Public Property status() As String
        Get
            status = str_status
        End Get
        Set(ByVal Value As String)
            str_status = Value
        End Set
    End Property

    Public Property type() As String
        Get
            type = str_type
        End Get
        Set(ByVal Value As String)
            str_type = Value
        End Set
    End Property

    Public Property conversation() As String
        Get
            conversation = str_conversation
        End Get
        Set(ByVal Value As String)
            str_conversation = Value
        End Set
    End Property

    Public Property email() As String
        Get
            email = str_email
        End Get
        Set(ByVal Value As String)
            str_email = Value
        End Set
    End Property



    Public Function getSupport(rUserType As String, rSupportStatus As String)
        Dim returnMsg As String = "False"
        Dim returnObject As List(Of Support) = New List(Of Support)
        'Query is select All ,Query 1 is select with conditional usertype and status type , Query 2 is selected with user type , Query 3 is selected with support type 
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "select supportid,support.status,support.userid,useraccount.type,subject,description, support.datesubmitted ,COALESCE(convert(varchar,support.dateclose),'TBA') AS dateclose from support join useraccount on support.userid=useraccount.userid where useraccount.status='APPROVED' AND useraccount.type!='Administrator' "
        Dim Query1 As String = "select supportid,support.status,support.userid,useraccount.type,subject,description, support.datesubmitted ,COALESCE(convert(varchar,support.dateclose),'TBA') AS dateclose from support join useraccount on support.userid=useraccount.userid where useraccount.status='APPROVED' AND useraccount.type!='Administrator' and useraccount.type=@typename and support.status=@supportstatus  "
        Dim Query2 As String = "select supportid,support.status,support.userid,useraccount.type,subject,description, support.datesubmitted ,COALESCE(convert(varchar,support.dateclose),'TBA') AS dateclose from support join useraccount on support.userid=useraccount.userid where useraccount.status='APPROVED' AND useraccount.type!='Administrator' and useraccount.type=@typename   "
        Dim Query3 As String = "select supportid,support.status,support.userid,useraccount.type,subject,description, support.datesubmitted ,COALESCE(convert(varchar,support.dateclose),'TBA') AS dateclose from support join useraccount on support.userid=useraccount.userid where useraccount.status='APPROVED' AND useraccount.type!='Administrator' and support.status=@supportstatus  "

        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()
                If rUserType = "All" And rSupportStatus = "All" Then
                    With comm
                        Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = Query
                    End With
                ElseIf rUserType = "All" Then
                    With comm
                        Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = Query3
                        .Parameters.AddWithValue("@supportstatus", rSupportStatus)
                    End With
                ElseIf rSupportStatus = "All" Then
                    With comm
                        Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = Query2
                        .Parameters.AddWithValue("@typename", rUserType)
                    End With
                Else
                    With comm
                        Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = Query1
                        .Parameters.AddWithValue("@typename", rUserType)
                        .Parameters.AddWithValue("@supportstatus", rSupportStatus)
                    End With

                End If

                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    Dim counter As Integer = 1
                    Dim tempobj As Support = New Support()
                    While reader.Read()
                        tempobj.supportid = reader("supportid")
                        tempobj.status = reader("status")
                        tempobj.userID = reader("userid")
                        tempobj.type = reader("type")
                        tempobj.subject = reader("subject")
                        tempobj.description = reader("description")
                        tempobj.datesubmitted = reader("datesubmitted")
                        tempobj.dateclose = reader("dateclose")


                        returnObject.Add(tempobj)
                        tempobj = New Support()
                    End While

                Catch ex As SqlException

                End Try
            End Using
        End Using
        Return returnObject
    End Function

    Public Function getSpecificSupport(rSupportID As String)
        Dim returnMsg As String = "False"
        Dim tempobj As Support = New Support()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "select supportid,support.status,support.userid,useraccount.type,subject,description, support.datesubmitted , COALESCE(conversation,'No Conversation Yet')  AS conversation,email from support join useraccount on support.userid=useraccount.userid where useraccount.status='APPROVED' AND useraccount.type!='Administrator' and supportid=@sessionSupportID "


        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()

                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.AddWithValue("@sessionSupportID", CType(rSupportID, Int32))
                End With


                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader

                    While reader.Read()
                        tempobj.supportid = reader("supportid")
                        tempobj.status = reader("status")
                        tempobj.userID = reader("userid")
                        tempobj.type = reader("type")
                        tempobj.subject = reader("subject")
                        tempobj.description = reader("description")
                        tempobj.datesubmitted = reader("datesubmitted")
                        tempobj.conversation = reader("conversation")
                        tempobj.email = reader("email")

                    End While

                Catch ex As SqlException

                End Try
            End Using
        End Using
        Return tempobj
    End Function


    Public Sub updateSupportConversation(rConversation As String, rSupportID As String)
        Dim returnMsg As String = "False"

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE SUPPORT SET conversation =@ConversatonRecord  WHERE supportid=@sessionSupportID "


        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()

                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.AddWithValue("@sessionSupportID", CType(rSupportID, Int32))
                    .Parameters.AddWithValue("@ConversatonRecord", rConversation)

                End With

                conn.Open()
                comm.ExecuteNonQuery()


            End Using
        End Using

    End Sub


    Public Function getSupportFromUser(rUserID As Int32)
        Dim returnMsg As String = "False"
        Dim returnObject As List(Of Support) = New List(Of Support)

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "select supportid,status,userid,subject,description, COALESCE(conversation,'No Conversation Yet')  AS conversation, datesubmitted ,COALESCE(convert(varchar,support.dateclose),'TBA') AS dateclose from support  where userid=@rUserID "


        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()

                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.AddWithValue("@rUserID", rUserID)
                End With



                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    Dim counter As Integer = 1
                    Dim tempobj As Support = New Support()
                    While reader.Read()
                        tempobj.supportid = reader("supportid")
                        tempobj.status = reader("status")
                        tempobj.userID = reader("userid")
                        tempobj.subject = reader("subject")
                        tempobj.description = reader("description")
                        tempobj.conversation = reader("conversation")
                        tempobj.datesubmitted = reader("datesubmitted")
                        tempobj.dateclose = reader("dateclose")

                        returnObject.Add(tempobj)
                        tempobj = New Support()
                    End While

                Catch ex As SqlException

                End Try
            End Using
        End Using
        Return returnObject
    End Function


    Public Sub updateSupportStatusSolved(SupportID As Int32, CloseDate As Date)
        Dim returnMsg As String = "False"

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "UPDATE SUPPORT SET status ='Solved',dateclose=@refDateClose WHERE supportid=@refSupportID"


        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()

                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.AddWithValue("@refSupportID", SupportID)
                    .Parameters.AddWithValue("@refDateClose", CloseDate)
                End With

                conn.Open()
                comm.ExecuteNonQuery()


            End Using
        End Using

    End Sub


    Public Sub insertIntoNewRecord(subject As String, txtMsg As String, userID As Int32)

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        con.ConnectionString = connectionString
        cmd.Connection = con
        con.Open()
        Dim CurrentDateTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        cmd = New SqlCommand("INSERT INTO Support (subject, description, userid, datesubmitted, status)
                                 values ('" & subject & "','" & txtMsg & "',
                                 '" & userID & "', '" & CurrentDateTime & "','" & "Pending" & "')", con)

        cmd.ExecuteNonQuery()
        con.Close()


    End Sub

    Public Function getMaxSupport()

        Dim returnMsg As String = "False"
        Dim tempobj As Support = New Support()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim Query As String = "select MAX(Supportid) as supportid from support"


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
                        tempobj.supportid = reader("supportid")

                    End While

                Catch ex As SqlException

                End Try
            End Using
        End Using


        Query = "select supportid,support.userid,email,useraccount.type from support join useraccount on support.userid=useraccount.userid where supportid=@rsupportID"



        Using conn As New SqlConnection(connectionString)

            Using comm As New SqlCommand()

                With comm
                    Dim mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = Query
                    .Parameters.AddWithValue("@rsupportID", tempobj.supportid)
                End With


                Try
                    conn.Open()
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    While reader.Read()
                        tempobj.userID = reader("userid")
                        tempobj.email = reader("email")
                        tempobj.type = reader("type")
                    End While


                Catch ex As SqlException

                End Try
            End Using
        End Using





        Return tempobj
    End Function

End Class
