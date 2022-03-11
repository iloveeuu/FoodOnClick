Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Public Class Encryption

    Protected str_Data As String

    Public Property data() As String
        Get
            data = str_Data
        End Get
        Set(ByVal Value As String)
            str_Data = Value
        End Set
    End Property

    Public Sub New()
        str_Data = ""
    End Sub

    Public Sub New(ByVal data As String)
        str_Data = data
    End Sub

    Public Function Encrypt() As String
        Try
            Dim encrypted As String = ""
            Dim EncryptionKey As String = "OurSecretKey"
            Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(Me.data)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                        cs.Write(clearBytes, 0, clearBytes.Length)
                        cs.Close()
                    End Using
                    encrypted = Convert.ToBase64String(ms.ToArray())
                End Using
            End Using
            Return encrypted
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Decrypt() As String
        Try
            Dim decrypted As String = ""
            Dim EncryptionKey As String = "OurSecretKey"
            Dim cipherBytes As Byte() = Convert.FromBase64String(Me.data)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(cipherBytes, 0, cipherBytes.Length)
                        cs.Close()
                    End Using
                    decrypted = Encoding.Unicode.GetString(ms.ToArray())
                End Using
            End Using
            Return decrypted
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class
