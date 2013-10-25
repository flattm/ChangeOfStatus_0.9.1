Option Explicit On

Imports System.Net.Mail
Imports System.Security
Imports System.Security.Principal
Imports System.Security.Principal.WindowsIdentity
Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement
Imports System.DirectoryServices.AccountManagement.UserPrincipal
Imports System.Web
Imports System.Data
Imports Utility
Imports Data
Imports GlobalVars

Partial Class _Default
    Inherits System.Web.UI.Page
    '************************************************************************************************************************
    'Initial page load
    '************************************************************************************************************************
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("username") = getDisplayName()
            lblName.Text = CType(Session.Item("username"), String)
            lblDate.Text = Today.ToShortDateString
            Session("holiday") = getHolidays(Today.AddMonths(-12))
        End If
        disableHide(, , , , , , , , , panSelectOne, panVacaVal, panSickVal)
    End Sub
    '************************************************************************************************************************
    'Show/Hide pannels based of of which are checked.
    '************************************************************************************************************************
    Protected Sub cbStatusChange_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbStatusChange.CheckedChanged
        If cbStatusChange.Checked = True Then
            enableShow(, , , , , , , , , panStatus)
        Else
            disableHide(, , , , , , , , , panStatus)
        End If
    End Sub

    Protected Sub cbVacation_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbVacation.CheckedChanged
        If cbVacation.Checked = True Then
            enableShow(, , , , , , , , , panVacation)
        Else
            disableHide(, , , , , , , , , panVacation)
        End If
    End Sub

    Protected Sub cbSick_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbSick.CheckedChanged
        If cbSick.Checked = True Then
            enableShow(, , , , , , , , , panSick)
        Else
            disableHide(, , , , , , , , , panSick)
        End If
    End Sub
    '************************************************************************************************************************
    'Show/Hide controls based off of which status change is selected
    '************************************************************************************************************************
    Protected Sub ddlStatusChange_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlStatusChange.SelectedIndexChanged
        clearStatusPannels()
        tbDouration.Text = ""
        ibChangeFrom.Enabled = True
        enableShow(lblReturning, lblDurationOfAbsence, lblDays)
        tbDouration.Visible = True
        tbComments.Text = ""

        If ddlStatusChange.SelectedIndex = 1 Then
            disableHide(lblReturning, lblChangeReturn, lblDays, , , , , , , panComments)
            ibChangeReturn.Visible = False
            enableShow(, , , , , , , , , panAddress)
        ElseIf ddlStatusChange.SelectedIndex = 2 Then
            enableShow(, , , , , , , , , panJury)
        ElseIf ddlStatusChange.SelectedIndex = 3 Then
            enableShow(, , , , , , , , , panFuneral)
            ibChangeReturn.Visible = False
            tbDouration.Text = ""
            lblChangeFrom.Text = ""
            lblChangeReturn.Text = ""
            cdrChangeFrom.SelectedDates.Clear()
            cdrChangeReturn.SelectedDates.Clear()
            ibChangeFrom.Enabled = False
        End If
    End Sub
    '************************************************************************************************************************
    'Arrange controls off of which funeral type is selected.
    'Automatically sets the douration of absence.
    '************************************************************************************************************************
    Protected Sub ddlFuneral_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlFuneral.SelectedIndexChanged
        ibChangeFrom.Enabled = True
        If ddlFuneral.SelectedIndex = 1 Then
            enableShow(lblImmed, , , , , , ddlImmed)
            disableHide(lblOther, , , , , , ddlOther)
            tbDouration.Text = "5"
        ElseIf ddlFuneral.SelectedIndex = 2 Then
            enableShow(lblOther, , , , , , ddlOther)
            disableHide(lblImmed, , , , , , ddlImmed)
            tbDouration.Text = "3"
        End If
    End Sub
    '************************************************************************************************************************
    'Arrange controls off of which option is selected.
    '************************************************************************************************************************
    Protected Sub rblAddressPhone_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblAddressPhone.SelectedIndexChanged
        If rblAddressPhone.SelectedIndex = 0 Then
            rfvStreet.Enabled = True
            rfvCity.Enabled = True
            rfvZip.Enabled = True
            tbStreet.Enabled = True
            tbCity.Enabled = True
            tbZip.Enabled = True
            rfvPhone.Enabled = False
            tbPhone.Enabled = False
            tbPhone.Text = ""
        ElseIf rblAddressPhone.SelectedIndex = 1 Then
            rfvStreet.Enabled = False
            rfvCity.Enabled = False
            rfvZip.Enabled = False
            tbStreet.Enabled = False
            tbCity.Enabled = False
            tbZip.Enabled = False
            tbStreet.Text = ""
            tbCity.Text = ""
            tbZip.Text = ""
            rfvPhone.Enabled = True
            tbPhone.Enabled = True
        ElseIf rblAddressPhone.SelectedIndex = 2 Then
            rfvStreet.Enabled = True
            rfvCity.Enabled = True
            rfvZip.Enabled = True
            rfvPhone.Enabled = True
            tbStreet.Enabled = True
            tbCity.Enabled = True
            tbZip.Enabled = True
            tbPhone.Enabled = True
        End If
    End Sub
    '************************************************************************************************************************
    'Automatically populate total hours of vacation based off of what is selected
    '************************************************************************************************************************
    Protected Sub rblFullHalf_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblFullHalf.SelectedIndexChanged
        cdrFrom.SelectedDates.Clear()
        cdrReturn.SelectedDates.Clear()
        lblFrom.Text = ""
        lblReturn.Text = ""
        If rblFullHalf.SelectedIndex = 1 Then
            tbTime.Text = 4
            enableShow(, , , , , , , , , , , , rblAMPM)
        ElseIf rblFullHalf.SelectedIndex = 0 Then
            clearVaca(False)
            tbTime.Text = 8
            'ibReturn.Enabled = True
        End If
    End Sub
    '************************************************************************************************************************
    'Switches between Add Vacation or Cancel Vacation
    '************************************************************************************************************************
    Protected Sub rblVaca_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblVaca.SelectedIndexChanged
        clearVaca()
        If rblVaca.SelectedIndex = 0 Then
            enableShow(, , , , , , , , , panAddVaca)
            disableHide(, , , , , , , , , panCancelVaca)
        ElseIf rblVaca.SelectedIndex = 1 Then
            enableShow(, , , , , , , , , panCancelVaca)
            disableHide(, , , , , , , , , panAddVaca)
        End If
    End Sub
    '************************************************************************************************************************
    'Handles all of the calendar controls.
    '************************************************************************************************************************
    Protected Sub ibChangeFrom_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibChangeFrom.Click
        showCal(cdrChangeFrom, lblChangeFrom, ibChangeFrom)
    End Sub

    Protected Sub cdrChangeFrom_SelectionChanged(sender As Object, e As System.EventArgs) Handles cdrChangeFrom.SelectionChanged
        If isWeekendHoliday(cdrChangeFrom.SelectedDate, CType(Session.Item("holiday"), DataTable)) Then
            cdrChangeFrom.SelectedDates.Clear()
        Else
            hideCal(cdrChangeFrom, lblChangeFrom, ibChangeFrom)
            If ddlStatusChange.SelectedIndex = 3 Then
                If ddlFuneral.SelectedIndex = 1 Then
                    cdrChangeReturn.SelectedDate = calculateReturnDate(40, cdrChangeFrom.SelectedDate, CType(Session.Item("holiday"), DataTable))
                    'lblChangeReturn.Text = cdrChangeReturn.SelectedDate.ToShortDateString
                ElseIf ddlFuneral.SelectedIndex = 2 Then
                    cdrChangeReturn.SelectedDate = calculateReturnDate(24, cdrChangeFrom.SelectedDate, CType(Session.Item("holiday"), DataTable))
                End If
                lblChangeReturn.Text = cdrChangeReturn.SelectedDate.ToShortDateString
            End If
            If ddlStatusChange.SelectedIndex = 1 Or ddlStatusChange.SelectedIndex = 3 Then
                'DoNothing
            Else
                ibChangeReturn.Visible = True
            End If
            If lblChangeReturn.Text IsNot "" Then
                tbDouration.Text = updateDouration(cdrChangeFrom.SelectedDate, cdrChangeReturn.SelectedDate, CType(Session.Item("holiday"), DataTable))
            End If
        End If
    End Sub

    Protected Sub ibChangeReturn_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibChangeReturn.Click
        showCal(cdrChangeReturn, lblChangeReturn, ibChangeReturn)
    End Sub

    Protected Sub cdrChangeReturn_SelectionChanged(sender As Object, e As System.EventArgs) Handles cdrChangeReturn.SelectionChanged
        If cdrChangeReturn.SelectedDate <= cdrChangeFrom.SelectedDate Or isWeekendHoliday(cdrChangeReturn.SelectedDate, CType(Session.Item("holiday"), DataTable)) Then
            cdrChangeReturn.SelectedDates.Clear()
        Else
            hideCal(cdrChangeReturn, lblChangeReturn, ibChangeReturn)
            'If ddlStatusChange.SelectedIndex = 1 Or ddlStatusChange.SelectedIndex = 3 Then
            '    'Nothing
            'Else

            'End If
            tbDouration.Text = updateDouration(cdrChangeFrom.SelectedDate, cdrChangeReturn.SelectedDate, CType(Session.Item("holiday"), DataTable))
        End If
    End Sub

    Protected Sub ibCancelStart_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibCancelStart.Click
        showCal(cdrCancelStart, lblCancelStart, ibCancelStart)
    End Sub

    Protected Sub cdrCancelStart_SelectionChanged(sender As Object, e As System.EventArgs) Handles cdrCancelStart.SelectionChanged
        If isWeekendHoliday(cdrCancelStart.SelectedDate, CType(Session.Item("holiday"), DataTable)) Then
            cdrCancelStart.SelectedDates.Clear()
        Else
            hideCal(cdrCancelStart, lblCancelStart, ibCancelStart)
        End If
    End Sub

    Protected Sub ibCancelEnd_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibCancelEnd.Click
        showCal(cdrCancelEnd, lblCancelEnd, ibCancelEnd)
    End Sub

    Protected Sub cdrCancelEnd_SelectionChanged(sender As Object, e As System.EventArgs) Handles cdrCancelEnd.SelectionChanged
        If cdrCancelEnd.SelectedDate <= cdrCancelStart.SelectedDate Or isWeekendHoliday(cdrCancelEnd.SelectedDate, CType(Session.Item("holiday"), DataTable)) Then
            cdrCancelEnd.SelectedDates.Clear()
        Else
            hideCal(cdrCancelEnd, lblCancelEnd, ibCancelEnd)
        End If
    End Sub

    Protected Sub ibSickDate_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibSickDate.Click
        showCal(cdrSickDate, lblSickDate, ibSickDate)
    End Sub

    Protected Sub cdrSickDate_SelectionChanged(sender As Object, e As System.EventArgs) Handles cdrSickDate.SelectionChanged
        If isWeekendHoliday(cdrSickDate.SelectedDate, CType(Session.Item("holiday"), DataTable)) Then
            cdrSickDate.SelectedDates.Clear()
        Else
            hideCal(cdrSickDate, lblSickDate, ibSickDate)
        End If
    End Sub

    Protected Sub ibFrom_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibFrom.Click
        Dim pass As Boolean = True
        If rblFullHalf.SelectedIndex > -1 Then
            disableHide(, , , , , , , , , panEnterInfoError)
            rblFullHalf.BackColor = Drawing.Color.White
            rblFullHalf.ForeColor = Drawing.Color.DimGray
            If rblFullHalf.SelectedIndex = 1 Then
                If rblAMPM.SelectedIndex > -1 Then
                    disableHide(, , , , , , , , , panEnterInfoError)
                    rblAMPM.BackColor = Drawing.Color.White
                    rblAMPM.ForeColor = Drawing.Color.DimGray
                Else
                    enableShow(, , , , , , , , , panEnterInfoError)
                    pass = False
                    rblAMPM.BackColor = Drawing.Color.Red
                    rblAMPM.ForeColor = Drawing.Color.White
                End If
            Else

            End If
        Else
            enableShow(, , , , , , , , , panEnterInfoError)
            pass = False
            rblFullHalf.BackColor = Drawing.Color.Red
            rblFullHalf.ForeColor = Drawing.Color.White
        End If
        If pass Then
            Try
                Dim time As Integer = -1
                time = tbTime.Text
                If tbTime.Text = 4 Or (tbTime.Text Mod 8) = 0 Then
                    disableHide(, , , , , , , , , panTotalHrError)
                    tbTime.BackColor = Drawing.Color.White
                    tbTime.ForeColor = Drawing.Color.DimGray
                    showCal(cdrFrom, lblFrom, ibFrom)
                Else
                    enableShow(, , , , , , , , , panTotalHrError)
                    tbTime.BackColor = Drawing.Color.Red
                    tbTime.ForeColor = Drawing.Color.White
                End If
            Catch ex As Exception
                enableShow(, , , , , , , , , panTotalHrError)
                tbTime.BackColor = Drawing.Color.Red
                tbTime.ForeColor = Drawing.Color.White
            End Try
        End If
    End Sub

    Protected Sub cdrFrom_SelectionChanged(sender As Object, e As System.EventArgs) Handles cdrFrom.SelectionChanged
        If isWeekendHoliday(cdrFrom.SelectedDate, CType(Session.Item("holiday"), DataTable)) Then
            cdrFrom.SelectedDates.Clear()
        Else
            hideCal(cdrFrom, lblFrom, ibFrom)
            If lblReturn.Text IsNot "" Then
                tbTime.Text = updateHours(cdrFrom.SelectedDate, cdrReturn.SelectedDate, CType(Session.Item("holiday"), DataTable)).ToString
            Else
                If rblFullHalf.SelectedIndex = 1 Then
                    If rblAMPM.SelectedIndex = 1 Then
                        cdrReturn.SelectedDate = calculateReturnDate(8, cdrFrom.SelectedDate, CType(Session.Item("holiday"), DataTable))
                        lblReturn.Text = cdrReturn.SelectedDate.ToShortDateString
                    Else
                        cdrReturn.SelectedDate = cdrFrom.SelectedDate
                        lblReturn.Text = cdrFrom.SelectedDate.ToShortDateString
                    End If
                ElseIf rblFullHalf.SelectedIndex = 0 Then
                    cdrReturn.SelectedDate = calculateReturnDate(tbTime.Text, cdrFrom.SelectedDate, CType(Session.Item("holiday"), DataTable))
                    lblReturn.Text = cdrReturn.SelectedDate.ToShortDateString
                End If
            End If
            If rblFullHalf.SelectedIndex = 0 Then
                ibReturn.Enabled = True
                ibReturn.Visible = True
            End If
        End If
    End Sub

    Protected Sub ibReturn_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibReturn.Click
        showCal(cdrReturn, lblReturn, ibReturn)
    End Sub

    Protected Sub cdrReturn_SelectionChanged(sender As Object, e As System.EventArgs) Handles cdrReturn.SelectionChanged
        If cdrReturn.SelectedDate <= cdrFrom.SelectedDate Or isWeekendHoliday(cdrReturn.SelectedDate, CType(Session.Item("holiday"), DataTable)) Then
            cdrReturn.SelectedDates.Clear()
        Else
            hideCal(cdrReturn, lblReturn, ibReturn)
            tbTime.Text = updateHours(cdrFrom.SelectedDate, cdrReturn.SelectedDate, CType(Session.Item("holiday"), DataTable)).ToString
        End If
    End Sub
    '************************************************************************************************************************
    'Adds the information for a new vacation to a listbox collection
    '************************************************************************************************************************
    Protected Sub btnAddVaca_Click(sender As Object, e As System.EventArgs) Handles btnAddVaca.Click
        Dim vaca As String = ""
        If rblVaca.SelectedIndex > -1 Then
            If rblVaca.SelectedIndex = 0 Then
                If lblReturn.Text IsNot "" Then
                    vaca &= "New Vacation:  "
                    vaca &= rblFullHalf.SelectedValue & " "
                    If rblFullHalf.SelectedIndex = 0 Then
                        'Nothing
                    Else
                        vaca &= rblAMPM.SelectedValue & " - "
                    End If
                    vaca &= "For a total of " & tbTime.Text & " hours.  "
                    vaca &= "From " & lblFrom.Text & " until " & lblReturn.Text & "."
                    'Checks to see if vacation entry already exists.  If it does nothing will happen.
                    ItemExists(lbVaca, vaca)
                    clearVaca()
                Else
                    lblSelectDateFirst.Visible = True
                End If
            Else
                If lblCancelStart.Text IsNot "" Then
                    If lblCancelEnd.Text = "" Then
                        lblSelectEnd.Visible = True
                    Else
                        vaca &= "Cancel Vacation:  "
                        If lblCancelEnd.Text IsNot "" Then
                            vaca &= "From " & lblCancelStart.Text & " to " & lblCancelEnd.Text & "."
                        Else
                            vaca &= "For: " & lblCancelStart.Text & "."
                        End If
                        'Checks to see if vacation entry already exists.  If it does nothing will happen.
                        ItemExists(lbVaca, vaca)
                        clearVaca()
                    End If
                End If
            End If
        End If
    End Sub
    '************************************************************************************************************************
    'Removes the selected vacation entry
    '************************************************************************************************************************
    Protected Sub btnRemoveVaca_Click(sender As Object, e As System.EventArgs) Handles btnRemoveVaca.Click
        If lbVaca.SelectedIndex >= 0 Then
            lbVaca.Items.RemoveAt(lbVaca.SelectedIndex)
        End If
    End Sub
    '************************************************************************************************************************
    'Adds the information for sick time to a listbox control
    '************************************************************************************************************************
    Protected Sub btnSickAdd_Click(sender As Object, e As System.EventArgs) Handles btnSickAdd.Click

        If lblSickDate.Text = "" Or (ddlHours.SelectedIndex = 0 And ddlMins.SelectedIndex = 0) Then
            'Do nothing
        Else
            Dim sick As String = ""
            sick &= "Sick:  "
            sick &= "On: " & lblSickDate.Text & "  For "
            sick &= ddlHours.SelectedValue & " hours"
            sick &= " and " & ddlMins.SelectedValue & " minutes."
            ItemExists(lbSick, sick)
        End If
    End Sub
    '************************************************************************************************************************
    'Removes the selected sick time
    '************************************************************************************************************************
    Protected Sub btnSickRemove_Click(sender As Object, e As System.EventArgs) Handles btnSickRemove.Click
        If lbSick.SelectedIndex >= 0 Then
            lbSick.Items.RemoveAt(lbSick.SelectedIndex)
        End If
    End Sub

    '************************************************************************************************************************
    'Sets up and emails the information to the submitter and the authorizing manager
    'Writes the information to a master log to ensure there is an appropriate trail in case of discrepancies
    '************************************************************************************************************************
    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        ' If no status change (vacation, sick, ect...) was selected 
        ' OR if 'Vacation' or 'Sick' was selected but none where added this will raise a warning.
        If cbStatusChange.Checked = False And cbVacation.Checked = False And cbSick.Checked = False Then
            enableShow(, , , , , , , , , panSelectOne)
        ElseIf cbVacation.Checked = True And lbVaca.Items.Count = 0 Then
            enableShow(, , , , , , , , , panVacaVal)
        ElseIf cbSick.Checked = True And lbSick.Items.Count = 0 Then
            enableShow(, , , , , , , , , panSickVal)
        Else
            'If all data is entered submit the request
            Session("manager") = ddlManager.SelectedValue
            Dim client As New SmtpClient(getSmtpHost())
            Application.Lock()
            Session("reqID") = CInt(Application("request_id"))
            Try
                InsertInto()
                client.Send(EmailManager())
                client.Send(EmailUser())
            Catch ex As Exception
                Session("exception") = ex
                Response.Redirect("CustomErrorPage.aspx")
            Finally
                Application("request_id") = (CType(Session.Item("reqID"), Integer) + 1)
                Application.UnLock()
            End Try
            Session("confirm") = "request"
            Response.Redirect("Confirm.aspx")
        End If
    End Sub

    '************************************************************************************************************************
    'Email user - mgr=1 (so the manager can see the approve/decline buttons)
    '************************************************************************************************************************
    Protected Function EmailManager() As MailMessage
        Dim msg As New MailMessage
        Dim body As String = ""
        msg.From = New MailAddress(getSenderEmail())
        msg.To.Add(New MailAddress(formatEmail(ddlManager.SelectedValue)))
        msg.Subject = "Change of Status Request"
        msg.IsBodyHtml = True
        'Create body
        body &= CType(Session.Item("username"), String) & _
            " has submitted a new Change of Status request. To review the request please follow the link below. <br><br><br>" & _
            "<a href=" & getURL() & CType(Session.Item("reqID"), String) & "&mgr=1"">Review Request</a>"
        msg.Body = body
        Return msg
    End Function

    '************************************************************************************************************************
    'Email user - mgr=0 (so the user cannot approve their own request)
    '************************************************************************************************************************
    Protected Function EmailUser() As MailMessage
        Dim msg As New MailMessage
        Dim body As String = ""
        msg.From = New MailAddress(getSenderEmail())
        msg.To.Add(New MailAddress(formatEmail(lblName.Text)))
        msg.Subject = "Change of Status Request"
        msg.IsBodyHtml = True
        'Create body
        body &= CType(Session.Item("username"), String) & _
            " has submitted a new Change of Status request. To review the request please follow the link below. <br><br><br>" & _
            "<a href=" & getURL() & CType(Session.Item("reqID"), String) & "&mgr=0"">Review Request</a>"
        msg.Body = body
        Return msg
    End Function

    '************************************************************************************************************************
    'Enter Data Into Database
    '************************************************************************************************************************
    Private Sub InsertInto()
        'Variables going into table 'Main'
        Dim reqID As Integer = CType(Session.Item("reqID"), Integer)
        Dim username As String = CType(Session.Item("username"), String)
        Dim requestDate As Date = Today().ToShortDateString
        Dim authorizingMgr As String = ddlManager.SelectedValue
        'Insert data into table 'Main'
        InsertMain(reqID, username, requestDate, authorizingMgr)
        'Figure out what overloaded InsertStatusChange to use
        If cbStatusChange.Checked = True Then
            Dim startDate As Date = cdrChangeFrom.SelectedDate
            If ddlStatusChange.SelectedIndex = 1 Then
                Dim street As String = tbStreet.Text
                Dim city As String = tbCity.Text
                Dim zip As String = tbZip.Text
                Dim phone As String = FormatPhone(tbPhone.Text)
                'Enter data into table 'StatusChange'
                InsertStatusChange(reqID, street, city, zip, phone, startDate)
            ElseIf ddlStatusChange.SelectedIndex = 3 Then
                Dim immediate_other As String = ddlFuneral.SelectedValue
                Dim relationship As String
                If ddlFuneral.SelectedIndex = 1 Then
                    relationship = ddlImmed.SelectedValue
                Else
                    relationship = ddlOther.SelectedValue
                End If
                Dim returnDate As Date = cdrChangeReturn.SelectedDate
                Dim duration As Byte = tbDouration.Text
                Dim comments As String = tbComments.Text
                'Insert data into 'StatusChange"
                InsertStatusChange(reqID, immediate_other, relationship, startDate, returnDate, duration, comments)
            Else
                Dim change_type As String = ddlStatusChange.SelectedValue
                Dim returnDate As Date = cdrChangeReturn.SelectedDate
                Dim duration As Byte = tbDouration.Text
                Dim comments As String = tbComments.Text
                'Insert data into 'StatusCahnge
                InsertStatusChange(reqID, change_type, startDate, returnDate, duration, comments)
            End If
        End If
        If cbVacation.Checked = True Then
            Dim count As Integer = 1
            Dim type As String

            For Each i In lbVaca.Items
                Dim str = i.ToString()
                Dim parts() As String = str.Split()
                If str.ToString.StartsWith("New") Then
                    type = "New Vacation"
                    Dim full_half As String = parts(3) & " " & parts(4)
                    Dim am_pm As String
                    Dim hours As Byte
                    Dim startDate As Date
                    Dim returnDate As Date
                    If parts(3).Equals("Full") Then
                        am_pm = ""
                        hours = parts(9)
                        startDate = CDate(parts(13))
                        returnDate = CDate(parts(15))
                    Else
                        am_pm = parts(5)
                        hours = parts(11)
                        startDate = CDate(parts(15))
                        returnDate = CDate(parts(17))
                    End If

                    'Insert data into Vacation
                    InsertVacation(reqID, count, type, full_half, am_pm, hours, startDate, returnDate)
                Else
                    type = "Cancel Vacation"
                    Dim startDate As Date = CDate(parts(4))
                    Dim returnDate As Date
                    If parts(3).StartsWith("For") Then
                        InsertVacation(reqID, count, type, startDate)
                    Else
                        returnDate = parts(6)
                        InsertVacation(reqID, count, type, startDate, returnDate)
                    End If
                End If
                count += 1
            Next
        End If
        If cbSick.Checked = True Then
            Dim count As Integer = 1
            For Each i In lbSick.Items()
                Dim str = i.ToString()
                Dim parts() As String = str.Split()
                Dim sick_date As Date = parts(3)
                Dim hours As Byte = parts(6)
                Dim minutes As Byte = parts(9)
                InsertSick(reqID, count, sick_date, hours, minutes)
                count += 1
            Next
        End If
    End Sub

    '************************************************************************************************************************
    'Does an LDAP query to get the Display Name of the current user
    '************************************************************************************************************************
    Private Function getDisplayName() As String

        Dim name As String = User.Identity.Name.ToString
        Dim dispName As String = ""

        name = name.Substring(name.IndexOf("\") + 1)

        Dim LDAPsvcAccStr As String = System.Configuration.ConfigurationManager.AppSettings("LDAPsvcAcc")
        Dim LDAPsvcPassStr As String = System.Configuration.ConfigurationManager.AppSettings("LDAPsvcPassStr")

        Try
            Dim de As DirectoryEntry = New DirectoryEntry("[...]", LDAPsvcAccStr, LDAPsvcPassStr)
            Dim ds As DirectorySearcher = New DirectorySearcher(de)

            ds.Filter = "(&(objectClass=user)(SAMAccountName=" & name & "))"

            Dim sr As SearchResult
            For Each sr In ds.FindAll()
                dispName = sr.GetDirectoryEntry.Properties.Item("displayName").Value
            Next
        Catch ex As Exception
            Session("exception") = ex
            Response.Redirect("CustomErrorPage.aspx")
        End Try

        Return dispName

    End Function

    '************************************************************************************************************************
    'Used to clear pannels when a different status change is selected.
    '************************************************************************************************************************
    Private Sub clearStatusPannels()
        disableHide(, , , , , , , , , panJury, panFuneral, panAddress)
        enableShow(, , , , , , , , , panComments)
    End Sub

    '************************************************************************************************************************
    'Resets controls once a  vacation is added or canceled
    '************************************************************************************************************************
    Private Sub clearVaca(Optional ByVal isAdd As Boolean = True)
        If isAdd Then
            rblFullHalf.SelectedIndex = -1
            rblAMPM.SelectedIndex = -1
        End If
        tbTime.Text = ""
        lblFrom.Text = ""
        lblReturn.Text = ""
        lblCancelStart.Text = ""
        lblCancelEnd.Text = ""
        cdrFrom.SelectedDates.Clear()
        cdrReturn.SelectedDates.Clear()
        cdrCancelStart.SelectedDates.Clear()
        cdrCancelEnd.SelectedDates.Clear()
        disableHide(lblSelectDateFirst, lblSelectEnd, , , , , , , , panEnterInfoError, panTotalHrError, , rblAMPM)
        rblFullHalf.BackColor = Drawing.Color.White
        rblFullHalf.ForeColor = Drawing.Color.DimGray
        rblAMPM.BackColor = Drawing.Color.White
        rblAMPM.ForeColor = Drawing.Color.DimGray
        tbTime.BackColor = Drawing.Color.White
        tbTime.ForeColor = Drawing.Color.DimGray
    End Sub

    Private Function formatNewVaca(ByVal i As String) As String
        Dim str As String = ""
        Dim split() As String = i.Split(" ")
        str &= "<b>New Vacation: </b>" & split(3) & split(4) & ".<br>"
        str &= "<b>For: </b>" & split(10) & " hours.<br>"
        str &= "<b>From: </b>" & split(14) & " until " & split(16) & "<br><br>"
        Return str
    End Function

    Private Function formatCancelVaca(ByVal i As String) As String
        Dim str As String = ""
        Dim split() As String = i.Split()
        str &= "<b>Cancel Vacation: </b><br>"
        If split(3).StartsWith("For") Then
            str &= "<b>For: </b>" & split(4) & "<br>"
        Else
            str &= "<b>From: </b>" & split(4) & " to " & split(6) & "<br>"
        End If
        str &= "<br>"
        Return str
    End Function

    Protected Sub rblAMPM_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblAMPM.SelectedIndexChanged
        cdrFrom.SelectedDates.Clear()
        lblFrom.Text = ""
        cdrReturn.SelectedDates.Clear()
        lblReturn.Text = ""
    End Sub
End Class