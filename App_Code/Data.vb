Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data

Public Class Data
    Private Shared Function GetConnectionStringIntra() As String
        Return ConfigurationManager.ConnectionStrings("[...]ConnectionString").ConnectionString
    End Function

    Private Shared Function GetConnectionStringCOS() As String
        Return ConfigurationManager.ConnectionStrings("[...]ConnectionString").ConnectionString
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function getHolidays(ByVal startDate As Date) As DataTable
        Dim con As New SqlConnection(GetConnectionStringIntra)
        Dim sel As String = "SELECT EventDate" _
                            & " FROM tblWEBEvent" _
                            & " WHERE IsHoliday = 1 AND EventDate >= @startDate" _
                            & " ORDER BY EventDate ASC"
        Dim cmd As New SqlCommand(sel, con)
        Dim dt As DataTable = New DataTable
        cmd.Parameters.AddWithValue("startDate", startDate)
        Try
            con.Open()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            con.Close()
        Catch e As Exception
            Throw e
        End Try
        Return dt
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Sub InsertMain(ByVal request_id As Integer,
                                 ByVal username As String,
                                 ByVal request_date As Date,
                                 ByVal authorizing_mgr As String)
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim ins As String = "Insert INTO Main" _
                            & " (request_id, username, request_date, authorizing_mgr)" _
                            & " VALUES (@request_id, @username, @request_date, @authorizing_mgr)"
        Dim cmd As New SqlCommand(ins, con)
        cmd.Parameters.AddWithValue("request_id", request_id)
        cmd.Parameters.AddWithValue("username", username)
        cmd.Parameters.AddWithValue("request_date", request_date)
        cmd.Parameters.AddWithValue("authorizing_mgr", authorizing_mgr)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Overloads Shared Sub InsertStatusChange(ByVal request_id As Integer,
                                                   ByVal street As String,
                                                   ByVal city As String,
                                                   ByVal zip As String,
                                                   ByVal phone As String,
                                                   ByVal start_date As Date)
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim ins As String = "Insert INTO Status_Change" _
                            & " (request_id, change_type, street, city, zip, phone, start_date)" _
                            & " VALUES (@request_id, 'Change of Address/Phone', @street, @city, @zip, @phone, @start_date)"
        Dim cmd As New SqlCommand(ins, con)
        cmd.Parameters.AddWithValue("request_id", request_id)
        cmd.Parameters.AddWithValue("street", street)
        cmd.Parameters.AddWithValue("city", city)
        cmd.Parameters.AddWithValue("zip", zip)
        cmd.Parameters.AddWithValue("phone", phone)
        cmd.Parameters.AddWithValue("start_date", start_date)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Overloads Shared Sub InsertStatusChange(ByVal request_id As Integer,
                                                   ByVal immediate_other As String,
                                                   ByVal relationship As String,
                                                   ByVal start_date As Date,
                                                   ByVal return_date As Date,
                                                   ByVal duration As Byte,
                                                   ByVal comments As String)
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim ins As String = "Insert INTO Status_Change" _
                            & " (request_id, change_type, immediate_other, relationship, start_date, return_date, duration, comments)" _
                            & " VALUES(@request_id, 'Funeral', @immediate_other, @relationship, @start_date, @return_date, @duration, @comments)"
        Dim cmd As New SqlCommand(ins, con)
        cmd.Parameters.AddWithValue("request_id", request_id)
        cmd.Parameters.AddWithValue("immediate_other", immediate_other)
        cmd.Parameters.AddWithValue("relationship", relationship)
        cmd.Parameters.AddWithValue("start_date", start_date)
        cmd.Parameters.AddWithValue("return_date", return_date)
        cmd.Parameters.AddWithValue("duration", duration)
        cmd.Parameters.AddWithValue("comments", comments)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Overloads Shared Sub InsertStatusChange(ByVal request_id As Integer,
                                                   ByVal change_type As String,
                                                   ByVal start_date As Date,
                                                   ByVal return_date As Date,
                                                   ByVal duration As Byte,
                                                   ByVal comments As String)
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim ins As String = "Insert INTO Status_Change" _
                            & " (request_id, change_type, start_date, return_date, duration, comments)" _
                            & " VALUES(@request_id, @change_type, @start_date, @return_date, @duration, @comments)"
        Dim cmd As New SqlCommand(ins, con)
        cmd.Parameters.AddWithValue("request_id", request_id)
        cmd.Parameters.AddWithValue("change_type", change_type)
        cmd.Parameters.AddWithValue("start_date", start_date)
        cmd.Parameters.AddWithValue("return_date", return_date)
        cmd.Parameters.AddWithValue("duration", duration)
        cmd.Parameters.AddWithValue("comments", comments)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Overloads Shared Sub InsertVacation(ByVal request_id As Integer,
                                               ByVal vacation_id As Byte,
                                               ByVal type As String,
                                               ByVal start_date As Date,
                                               ByVal return_date As Date)
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim ins As String = "Insert INTO Vacation" _
                            & " (request_id, vacation_id, type, start_date, return_date)" _
                            & " VALUES(@request_id, @vacation_id, @type, @start_date, @return_date)"
        Dim cmd As New SqlCommand(ins, con)
        cmd.Parameters.AddWithValue("request_id", request_id)
        cmd.Parameters.AddWithValue("vacation_id", vacation_id)
        cmd.Parameters.AddWithValue("type", type)
        cmd.Parameters.AddWithValue("start_date", start_date)
        cmd.Parameters.AddWithValue("return_date", return_date)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Overloads Shared Sub InsertVacation(ByVal request_id As Integer,
                                               ByVal vacation_id As Byte,
                                               ByVal type As String,
                                               ByVal start_date As Date)
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim ins As String = "Insert INTO Vacation" _
                            & " (request_id, vacation_id, type, start_date)" _
                            & " VALUES(@request_id, @vacation_id, @type, @start_date)"
        Dim cmd As New SqlCommand(ins, con)
        cmd.Parameters.AddWithValue("request_id", request_id)
        cmd.Parameters.AddWithValue("vacation_id", vacation_id)
        cmd.Parameters.AddWithValue("type", type)
        cmd.Parameters.AddWithValue("start_date", start_date)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Overloads Shared Sub InsertVacation(ByVal request_id As Integer,
                                               ByVal vacation_id As Byte,
                                               ByVal type As String,
                                               ByVal full_half As String,
                                               ByVal am_pm As String,
                                               ByVal total_hours As Byte,
                                               ByVal start_date As Date,
                                               ByVal return_date As Date)
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim ins As String = "Insert INTO Vacation" _
                            & " (request_id, vacation_id, type, full_half, am_pm, total_hours, start_date, return_date)" _
                            & " VALUES(@request_id, @vacation_id, @type, @full_half, @am_pm, @total_hours, @start_date, @return_date)"
        Dim cmd As New SqlCommand(ins, con)
        cmd.Parameters.AddWithValue("request_id", request_id)
        cmd.Parameters.AddWithValue("vacation_id", vacation_id)
        cmd.Parameters.AddWithValue("type", type)
        cmd.Parameters.AddWithValue("full_half", full_half)
        cmd.Parameters.AddWithValue("am_pm", am_pm)
        cmd.Parameters.AddWithValue("total_hours", total_hours)
        cmd.Parameters.AddWithValue("start_date", start_date)
        cmd.Parameters.AddWithValue("return_date", return_date)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Sub InsertSick(ByVal request_id As Integer,
                                     ByVal sick_id As Byte,
                                     ByVal sick_date As Date,
                                     ByVal hours As Byte,
                                     ByVal minutes As Byte)
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim ins As String = "Insert INTO Sick" _
                            & " (request_id, sick_id, sick_date, hours, minutes)" _
                            & " VALUES(@request_id, @sick_id, @sick_date, @hours, @minutes)"
        Dim cmd As New SqlCommand(ins, con)
        cmd.Parameters.AddWithValue("request_id", request_id)
        cmd.Parameters.AddWithValue("sick_id", sick_id)
        cmd.Parameters.AddWithValue("sick_date", sick_date)
        cmd.Parameters.AddWithValue("hours", hours)
        cmd.Parameters.AddWithValue("minutes", minutes)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetReqId() As Integer
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim sel As String = "SELECT MAX(request_id)" _
                            & " FROM Main"
        Dim cmd As New SqlCommand(sel, con)
        Dim dt As DataTable = New DataTable
        Try
            con.Open()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            con.Close()
        Catch e As Exception
            Throw e
        End Try
        Dim req_id As Integer = dt.Rows.Item(0).Item(0)
        Return req_id
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectMain(ByVal reqID As Integer) As DataTable
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim sel As String = "SELECT *" _
                            & " FROM Main" _
                            & " WHERE request_id = @request_id"
        Dim cmd As New SqlCommand(sel, con)
        cmd.Parameters.AddWithValue("request_id", reqID)
        Dim dt As DataTable = New DataTable
        Try
            con.Open()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            con.Close()
        Catch e As Exception
            Throw e
        End Try
        Return dt
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectStatusChange(ByVal reqID As Integer) As DataTable
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim sel As String = "SELECT *" _
                            & " FROM Status_Change" _
                            & " WHERE request_id = @request_id"
        Dim cmd As New SqlCommand(sel, con)
        cmd.Parameters.AddWithValue("request_id", reqID)
        Dim dt As DataTable = New DataTable
        Try
            con.Open()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            con.Close()
        Catch e As Exception
            Throw e
        End Try
        Return dt
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectVacation(ByVal reqID As Integer) As DataTable
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim sel As String = "SELECT *" _
                            & " FROM Vacation" _
                            & " WHERE request_id = @request_id"
        Dim cmd As New SqlCommand(sel, con)
        cmd.Parameters.AddWithValue("request_id", reqID)
        Dim dt As DataTable = New DataTable
        Try
            con.Open()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            con.Close()
        Catch e As Exception
            Throw e
        End Try
        Return dt
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SelectSick(ByVal reqID As Integer) As DataTable
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim sel As String = "SELECT *" _
                            & " FROM Sick" _
                            & " WHERE request_id = @request_id"
        Dim cmd As New SqlCommand(sel, con)
        cmd.Parameters.AddWithValue("request_id", reqID)
        Dim dt As DataTable = New DataTable
        Try
            con.Open()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            adapter.Fill(dt)
            con.Close()
        Catch e As Exception
            Throw e
        End Try
        Return dt
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function UpdateRequest(ByVal reqID As Integer, ByVal approved As Integer) As Integer
        Dim con As New SqlConnection(GetConnectionStringCOS)
        Dim upd As String = "UPDATE Main " _
                            & "SET approved = @approved, approved_date = @approved_date " _
                            & "WHERE request_id = @request_id"
        Dim cmd As New SqlCommand(upd, con)
        cmd.Parameters.AddWithValue("approved", approved)
        cmd.Parameters.AddWithValue("approved_date", Now())
        cmd.Parameters.AddWithValue("request_id", reqID)
        con.Open()
        Dim i As Integer = cmd.ExecuteNonQuery()
        con.Close()
        Return i
    End Function
End Class
