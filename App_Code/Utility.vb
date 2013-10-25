Imports System.IO
Imports System.Data
Imports GlobalVars

Public Class Utility
    '************************************************************************************************************************
    'Sub that will enable/show several controls at once.
    '************************************************************************************************************************
    Public Shared Sub enableShow(Optional ByVal label1 As Label = Nothing, Optional ByVal label2 As Label = Nothing,
                                      Optional ByVal label3 As Label = Nothing, Optional ByVal textbox1 As TextBox = Nothing,
                                      Optional ByVal textbox2 As TextBox = Nothing, Optional ByVal textbox3 As TextBox = Nothing,
                                      Optional ByVal ddl1 As DropDownList = Nothing, Optional ByVal ddl2 As DropDownList = Nothing,
                                      Optional ByVal ddl3 As DropDownList = Nothing, Optional ByVal pan1 As Panel = Nothing,
                                      Optional ByVal pan2 As Panel = Nothing, Optional ByVal pan3 As Panel = Nothing,
                                      Optional ByVal rbl1 As RadioButtonList = Nothing)
        If label1 IsNot Nothing Then
            label1.Enabled = True
            label1.Visible = True
        End If
        If label2 IsNot Nothing Then
            label2.Enabled = True
            label2.Visible = True
        End If
        If label3 IsNot Nothing Then
            label3.Enabled = True
            label3.Visible = True
        End If
        If textbox1 IsNot Nothing Then
            textbox1.Enabled = True
            textbox1.Visible = True
        End If
        If textbox2 IsNot Nothing Then
            textbox2.Enabled = True
            textbox2.Visible = True
        End If
        If textbox3 IsNot Nothing Then
            textbox3.Enabled = True
            textbox3.Visible = True
        End If
        If ddl1 IsNot Nothing Then
            ddl1.Enabled = True
            ddl1.Visible = True
        End If
        If ddl2 IsNot Nothing Then
            ddl2.Enabled = True
            ddl2.Visible = True
        End If
        If ddl3 IsNot Nothing Then
            ddl3.Enabled = True
            ddl3.Visible = True
        End If
        If pan1 IsNot Nothing Then
            pan1.Enabled = True
            pan1.Visible = True
        End If
        If pan2 IsNot Nothing Then
            pan2.Enabled = True
            pan2.Visible = True
        End If
        If pan3 IsNot Nothing Then
            pan3.Enabled = True
            pan3.Visible = True
        End If
        If rbl1 IsNot Nothing Then
            rbl1.Enabled = True
            rbl1.Visible = True
        End If
    End Sub
    '************************************************************************************************************************
    'Sub that will disable/hide several controls at once.
    '************************************************************************************************************************
    Public Shared Sub disableHide(Optional ByVal label1 As Label = Nothing, Optional ByVal label2 As Label = Nothing,
                                      Optional ByVal label3 As Label = Nothing, Optional ByVal textbox1 As TextBox = Nothing,
                                      Optional ByVal textbox2 As TextBox = Nothing, Optional ByVal textbox3 As TextBox = Nothing,
                                      Optional ByVal ddl1 As DropDownList = Nothing, Optional ByVal ddl2 As DropDownList = Nothing,
                                      Optional ByVal ddl3 As DropDownList = Nothing, Optional ByVal pan1 As Panel = Nothing,
                                      Optional ByVal pan2 As Panel = Nothing, Optional ByVal pan3 As Panel = Nothing,
                                      Optional ByVal rbl1 As RadioButtonList = Nothing)
        If label1 IsNot Nothing Then
            label1.Enabled = False
            label1.Visible = False
        End If
        If label2 IsNot Nothing Then
            label2.Enabled = False
            label2.Visible = False
        End If
        If label3 IsNot Nothing Then
            label3.Enabled = False
            label3.Visible = False
        End If
        If textbox1 IsNot Nothing Then
            textbox1.Enabled = False
            textbox1.Visible = False
        End If
        If textbox2 IsNot Nothing Then
            textbox2.Enabled = False
            textbox2.Visible = False
        End If
        If textbox3 IsNot Nothing Then
            textbox3.Enabled = False
            textbox3.Visible = False
        End If
        If ddl1 IsNot Nothing Then
            ddl1.Enabled = False
            ddl1.Visible = False
        End If
        If ddl2 IsNot Nothing Then
            ddl2.Enabled = False
            ddl2.Visible = False
        End If
        If ddl3 IsNot Nothing Then
            ddl3.Enabled = False
            ddl3.Visible = False
        End If
        If pan1 IsNot Nothing Then
            pan1.Enabled = False
            pan1.Visible = False
        End If
        If pan2 IsNot Nothing Then
            pan2.Enabled = False
            pan2.Visible = False
        End If
        If pan3 IsNot Nothing Then
            pan3.Enabled = False
            pan3.Visible = False
        End If
        If rbl1 IsNot Nothing Then
            rbl1.Enabled = False
            rbl1.Visible = False
        End If
    End Sub
    '************************************************************************************************************************
    'Adds the dynamics to the Image Buttons (calendar icons)
    '************************************************************************************************************************
    Public Shared Sub showCal(ByVal cal As Calendar, ByVal lbl As Label, ByVal ib As ImageButton)
        cal.Enabled = True
        cal.Visible = True
        lbl.Visible = False
        ib.Visible = False
    End Sub
    '************************************************************************************************************************
    'Hides the calendar when a date is selected
    'Enters the appropriate date into the corresponding label
    '************************************************************************************************************************
    Public Shared Sub hideCal(ByVal cal As Calendar, ByVal lbl As Label, ByVal ib As ImageButton)
        lbl.Text = cal.SelectedDate.ToShortDateString
        cal.Enabled = False
        cal.Visible = False
        lbl.Visible = True
        ib.Visible = True
    End Sub
    '************************************************************************************************************************
    'When a date range is selected, this will check each day to see if it is a holiday or weeknd
    'If it is a holiday or weekend it is not included toward the adsent days
    '************************************************************************************************************************
    Public Shared Function isWeekendHoliday(ByVal dateVar As Date, ByVal pDT As DataTable) As Boolean
        Dim weekendOrHoliday As Boolean = False
        If dateVar.DayOfWeek = DayOfWeek.Saturday Or dateVar.DayOfWeek = DayOfWeek.Sunday Then
            weekendOrHoliday = True
        Else
            Dim dt As New DataTable
            dt = pDT
            Dim count As Integer = 0
            For Each holiday As DataRow In dt.Rows
                If dateVar = holiday.Item("EventDate") Then
                    count += 1
                End If
            Next
            If count > 0 Then
                weekendOrHoliday = True
            End If
        End If
        Return weekendOrHoliday
    End Function
    '************************************************************************************************************************
    'Used to figure out the return date given a starting day and the total amount of days off
    '************************************************************************************************************************
    Public Shared Function calculateReturnDate(ByVal totalHours As Integer, ByVal selectedDate As Date, ByVal pDT As DataTable) As Date
        Dim returnDate As Date = selectedDate
        Dim days As Integer = totalHours / 8

        While days > 0

            If Not isWeekendHoliday(returnDate, pDT) Then
                days -= 1
            End If
            returnDate = returnDate.AddDays(1)
        End While
        While isWeekendHoliday(returnDate, pDT)
            returnDate = returnDate.AddDays(1)
        End While
        Return returnDate
    End Function
    '************************************************************************************************************************
    'Will change absence douration if the return date is changed after it has been calculated
    '************************************************************************************************************************
    Public Shared Function updateHours(ByVal fromDate As Date, ByVal toDate As Date, ByVal pDT As DataTable) As Integer
        Dim hours As Integer
        Dim count As Integer
        Dim dateVar As Date = fromDate

        While dateVar < toDate
            If Not isWeekendHoliday(dateVar, pDT) Then
                count += 1
            End If
            dateVar = dateVar.AddDays(1)
        End While
        hours = count * 8
        Return hours
    End Function
    '************************************************************************************************************************
    'Method that will write the details to a log.
    '************************************************************************************************************************
    'Public Shared Sub writeToLog(ByVal message As String)
    '    Dim timestamp As Date = Now.ToString
    '    Dim break As String = "*********************************************************************************************************************" & vbCrLf

    '    If Not Directory.Exists(getPath()) Then
    '        Directory.CreateDirectory(getPath())
    '    End If
    '    If Not File.Exists(getPath() & getFile()) Then
    '        File.Create(getPath() & getFile())
    '        FileClose()
    '    End If
    '    Using sw As New StreamWriter(getPath() & getFile(), True)
    '        sw.WriteLine(break)
    '        sw.WriteLine(timestamp)
    '        sw.WriteLine(vbCrLf & message)
    '        sw.Close()
    '    End Using
    'End Sub
    '************************************************************************************************************************
    'Takes the user / manager name and formats it into an email address
    '************************************************************************************************************************
    Public Shared Function formatEmail(ByVal name As String) As String
        Dim names As String() = Split(name, " ")
        For Each n As String In names
            n.Trim()
        Next
        Dim first As String
        Dim last As String
        If names.Length = 2 Then
            first = names(0) & "."
            last = names(1)
        ElseIf names.Length = 3 Then
            first = names(0) & "."
            last = names(1) & names(2)
        Else
            Throw New Exception("There is a problem while trying to format an email address.  Please contact the network administrator.")
        End If
        Dim email As String = first & last & getDomain()
        Return email
    End Function


    '************************************************************************************************************************
    'Remove non-numeric chars
    '************************************************************************************************************************
    Public Shared Function FormatPhone(ByVal p_phone As String) As String
        Dim phone As String = ""
        For i As Integer = 0 To p_phone.Length - 1 Step 1
            Dim currentChar As String = p_phone.Substring(i, 1)
            If IsNumeric(currentChar) Then
                phone &= currentChar
            End If
        Next
        Return phone
    End Function

    '************************************************************************************************************************
    'Get the number of days between two date ranges
    '************************************************************************************************************************
    Public Shared Function updateDouration(ByVal pStart As Date, ByVal pFinish As Date, ByVal pDT As DataTable) As Integer
        Dim start As Date = pStart
        Dim finish As Date = pFinish
        Dim count As Integer = (finish - start).Days
        While start <= finish
            If isWeekendHoliday(start, pDT) Then
                count -= 1
            End If
            start = start.AddDays(1)
        End While
        Return count
    End Function
    '************************************************************************************************************************
    'Check to see if the given item has already been entered and adds it if it has not.
    '************************************************************************************************************************
    Public Shared Sub ItemExists(ByVal lb As ListBox, ByVal str As String)
        Dim exist As Boolean = False
        For Each i In lb.Items
            If str.Equals(i.ToString) Then
                exist = True
            End If
        Next
        If Not exist Then
            lb.Items.Add(str)
        End If
    End Sub
    '************************************************************************************************************************
    'Writes errors to a log for debugging purposes
    '************************************************************************************************************************
    Public Shared Sub errorLogging(ByVal ex As Exception)
        Dim timestamp As Date = Now.ToString
        Dim break As String = "*****************************************************************************************" & vbCrLf

        If Not Directory.Exists(getPath()) Then
            Directory.CreateDirectory(getPath())
        End If
        If Not File.Exists(getPath() & getFile()) Then
            File.Create(getPath() & getFile())
            FileClose()
        End If
        Using sw As New StreamWriter(getPath() & getFile(), True)
            sw.WriteLine(break)
            sw.WriteLine(timestamp)
            sw.WriteLine(vbCrLf & ex.ToString & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf)
            sw.Close()
        End Using
    End Sub
End Class

