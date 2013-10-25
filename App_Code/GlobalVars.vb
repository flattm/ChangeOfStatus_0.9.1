Imports Microsoft.VisualBasic
Imports System.Data

Public Class GlobalVars
    Private Const SMTPHOST As String = "[...]"
    Private Const SENDEREMAIL As String = "[...]"
    Private Const PATH As String = "[...]"
    Private Const FILE As String = "[...]"
    Private Const DOMAIN As String = "[...]"
    Private Const HREMAIL As String = "[...]"
    Private Const HREMAIL1 As String = "[...]"
    Private Const URL As String = "[...]"

    Public Shared Function getSmtpHost() As String
        Return SMTPHOST
    End Function

    Public Shared Function getSenderEmail() As String
        Return SENDEREMAIL
    End Function

    Public Shared Function getPath() As String
        Return PATH
    End Function

    Public Shared Function getFile() As String
        Return FILE
    End Function

    Public Shared Function getDomain() As String
        Return DOMAIN
    End Function

    Public Shared Function getHREmail() As String
        Return HREMAIL
    End Function

    Public Shared Function getHREmail1() As String
        Return HREMAIL1
    End Function

    Public Shared Function getURL() As String
        Return URL
    End Function
End Class
