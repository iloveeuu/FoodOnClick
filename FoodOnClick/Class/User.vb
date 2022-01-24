Public Class User

    Protected str_username As String
    Protected str_password As String

    Public Property username() As String
        Get
            username = str_username
        End Get
        Set(ByVal Value As String)
            str_username = Value
        End Set
    End Property
    Public Property password() As String
        Get
            password = str_password
        End Get
        Set(ByVal Value As String)
            str_password = Value
        End Set
    End Property


    Public Sub New()
        str_username = ""
        str_password = ""
    End Sub

    Public Sub New(ByVal username As String, ByVal password As String)
        str_username = username
        str_password = password
    End Sub

End Class
