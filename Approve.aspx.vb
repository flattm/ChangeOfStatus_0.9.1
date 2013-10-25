Imports System.Data
Imports System.Net.Mail
Imports Data
Imports Utility
Imports GlobalVars

Partial Class Approve
    Inherits System.Web.UI.Page

    Dim req As Integer
    Dim username As String
    Dim requestDate As Date
    Dim authMgr As String
    Dim changeType As String
    Dim street As String
    Dim city As String
    Dim zip As String
    Dim phone As String
    Dim funeralType As String
    Dim relationship As String
    Dim changeStartDate As Date
    Dim changeReturnDate As Date
    Dim duration As Byte
    Dim comments As String
    Dim vacationType As String()
    Dim fullHalf As String()
    Dim amPM As String()
    Dim totalHours As Byte()
    Dim vacationStartDate As Date()
    Dim vacationReturnDate As Date()
    Dim sickDate As Date()
    Dim hours As Byte()
    Dim minutes As Byte()




    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Gets data from URL query string
            req = Request.QueryString("req")
            Session("reqID") = req
            Dim mgr As Integer = Request.QueryString("mgr")
            If mgr = 1 Then
                panApprove.Visible = True
            End If
            'Gets all the information for the appropriate request (as determined by the request id)
            Dim main As DataTable = SelectMain(req)
            Dim statusChange As DataTable = SelectStatusChange(req)
            Dim vacation As DataTable = SelectVacation(req)
            Dim sick As DataTable = SelectSick(req)

            username = main.Rows(0).Item(1).ToString
            lblName.Text = username
            Session("username") = username
            requestDate = main.Rows(0).Item(2).ToString
            lblReqDate.Text = requestDate
            authMgr = main.Rows(0).Item(3).ToString
            Session("manager") = authMgr

            If statusChange.Rows.Count > 0 Then
                panStatusChange.Visible = True
                changeType = statusChange.Rows(0).Item(1).ToString
                lblChange.Text = changeType
                If changeType.StartsWith("Change") Then
                    panAddressPhone.Visible = True
                    street = statusChange.Rows(0).Item(2).ToString
                    If street.Length > -1 Then
                        panAddress.Visible = True
                        lblStreet.Text = street
                        city = statusChange.Rows(0).Item(3).ToString
                        lblCity.Text = city
                        zip = statusChange.Rows(0).Item(4).ToString
                        lblZip.Text = zip
                    End If
                    phone = statusChange.Rows(0).Item(5).ToString
                    If phone.Length > -1 Then
                        panPhone.Visible = True
                        lblPhone.Text = phone
                    End If
                    changeStartDate = statusChange.Rows(0).Item(8).ToString
                    lblEffectiveDate.Text = changeStartDate
                Else
                    If changeType.StartsWith("Funeral") Then
                        panFuneral.Visible = True
                        panDatesDuration.Visible = True
                        funeralType = statusChange.Rows(0).Item(6).ToString
                        lblType.Text = funeralType
                        relationship = statusChange.Rows(0).Item(7).ToString
                        lblRelationship.Text = relationship
                    Else
                        panDatesDuration.Visible = True
                    End If
                    lblStartDate.Text = changeStartDate
                    changeReturnDate = statusChange.Rows(0).Item(9).ToString
                    lblReturnDate.Text = changeReturnDate
                    duration = statusChange.Rows(0).Item(10).ToString
                    lblDuration.Text = duration
                    comments = statusChange.Rows(0).Item(11).ToString
                    lblComments.Text = comments
                End If
            End If
            If vacation.Rows.Count > 0 Then
                panVacation.Visible = True
                Dim size As Integer = vacation.Rows.Count - 1
                vacationType = New String(size) {}
                fullHalf = New String(size) {}
                amPM = New String(size) {}
                totalHours = New Byte(size) {}
                vacationStartDate = New Date(size) {}
                vacationReturnDate = New Date(size) {}
                For x As Integer = 0 To size Step 1
                    vacationType(x) = vacation.Rows(x).Item(2).ToString
                    fullHalf(x) = vacation.Rows(x).Item(3).ToString
                    amPM(x) = vacation.Rows(x).Item(4).ToString
                    totalHours(x) = vacation.Rows(x).Item(5)
                    vacationStartDate(x) = vacation.Rows(x).Item(6).ToString
                    vacationReturnDate(x) = vacation.Rows(x).Item(7).ToString
                Next
                For c As Integer = 0 To size Step 1
                    Dim tbl As New Table
                    Dim gv As New GridView
                    tbl = GenerateVacationTable(c, vacationType(c), fullHalf(c), amPM(c), totalHours(c), vacationStartDate(c), vacationReturnDate(c))
                    phVacation.Controls.Add(tbl)
                    phVacation.Controls.Add(New LiteralControl("<br />"))
                Next
            End If
            If sick.Rows.Count > 0 Then
                panSick.Visible = True
                Dim size As Integer = sick.Rows.Count - 1
                sickDate = New Date(size) {}
                hours = New Byte(size) {}
                minutes = New Byte(size) {}
                For x As Integer = 0 To size Step 1
                    sickDate(x) = sick.Rows(x).Item(2).ToString
                    hours(x) = sick.Rows(x).Item(3).ToString
                    minutes(x) = sick.Rows(x).Item(4).ToString
                Next
                For c As Integer = 0 To size Step 1
                    Dim tbl As New Table
                    tbl = GenerateSickTable(c, sickDate(c), hours(c), minutes(c))
                    phSick.Controls.Add(tbl)
                    phSick.Controls.Add(New LiteralControl("<br />"))
                Next
            End If
        End If
    End Sub

    Protected Function GenerateVacationTable(ByVal count As Integer, ByVal type As String,
                                     ByVal fullHalf As String, ByVal amPM As String,
                                     ByVal totalHours As Byte, ByVal vacationStartDate As Date,
                                     ByVal vacationReturnDate As Date) As Table
        Dim tbl As New Table
        tbl.ID = "tblVacation" & count.ToString
        Dim r0 As New TableRow
        Dim r0c1, r0c2 As New TableCell
        Dim typeLabel, lblType As New Label
        SetHeaderLabel(typeLabel, "Type:", "typeLabel", count)
        SetLabel(lblType, type, "lblType", count)
        r0c1.Width = 100
        r0c1.Controls.Add(typeLabel)
        r0c2.Controls.Add(lblType)
        r0.Cells.Add(r0c1)
        r0.Cells.Add(r0c2)
        tbl.Rows.Add(r0)
        If type.StartsWith("New") Then
            Dim r1, r2, r3, r4, r5, r6 As New TableRow
            Dim r1c1, r1c2, r2c1, r2c2, r3c1, r3c2, r4c1, r4c2, r5c1, r5c2 As New TableCell
            Dim fullHalfLabel, amPMLabel, totalHoursLabel, startDateLabel, returnDateLabel As New Label
            Dim lblfullHalf, lblAmPM, lblTotalHours, lblStartDate, lblReturnDate As New Label
            SetHeaderLabel(fullHalfLabel, "Length:", "fullHalfLabel", count)
            SetHeaderLabel(amPMLabel, "Half:", "amPMLabel", count)
            SetHeaderLabel(totalHoursLabel, "Total Hours:", "totalHoursLabel", count)
            SetHeaderLabel(startDateLabel, "Start Date:", "vacationStartDateLabel", count)
            SetHeaderLabel(returnDateLabel, "Return Date:", "vacationReturnDateLabel", count)
            SetLabel(lblfullHalf, fullHalf, "lblFullHalf", count)
            If amPM.Equals("AM") Or amPM.Equals("PM") Then
                SetLabel(lblAmPM, amPM, "lblAmPm", count)
            Else
                SetLabel(lblAmPM, "N/A", "lblAmPM", count)
            End If
            SetLabel(lblTotalHours, totalHours, "lblTotalHours", count)
            SetLabel(lblStartDate, vacationStartDate, "lblVacationStartDate", count)
            SetLabel(lblReturnDate, vacationReturnDate, "lblVacationReturnDate", count)
            r1c1.Controls.Add(fullHalfLabel)
            r1c2.Controls.Add(lblfullHalf)
            r2c1.Controls.Add(amPMLabel)
            r2c2.Controls.Add(lblAmPM)
            r3c1.Controls.Add(totalHoursLabel)
            r3c2.Controls.Add(lblTotalHours)
            r4c1.Controls.Add(startDateLabel)
            r4c2.Controls.Add(lblStartDate)
            r5c1.Controls.Add(returnDateLabel)
            r5c2.Controls.Add(lblReturnDate)
            r1.Cells.Add(r1c1)
            r1.Cells.Add(r1c2)
            r2.Cells.Add(r2c1)
            r2.Cells.Add(r2c2)
            r3.Cells.Add(r3c1)
            r3.Cells.Add(r3c2)
            r4.Cells.Add(r4c1)
            r4.Cells.Add(r4c2)
            r5.Cells.Add(r5c1)
            r5.Cells.Add(r5c2)
            tbl.Rows.Add(r1)
            tbl.Rows.Add(r2)
            tbl.Rows.Add(r3)
            tbl.Rows.Add(r4)
            tbl.Rows.Add(r5)
        Else
            Dim r1, r2 As New TableRow
            Dim r1c1, r1c2, r2c1, r2c2 As New TableCell
            Dim startDateLabel As Label = New Label
            Dim returnDateLabel As Label = New Label
            Dim lblStartDate As Label = New Label
            Dim lblReturnDate As Label = New Label
            SetHeaderLabel(startDateLabel, "Start Date:", "vacationStartDateLabel", count)
            SetHeaderLabel(returnDateLabel, "Return Date:", "vacationReturnDateLabel", count)
            SetLabel(lblStartDate, vacationStartDate, "lblVacationStartDate", count)
            SetLabel(lblReturnDate, vacationReturnDate, "lblVacationReturnDate", count)
            r1c1.Controls.Add(startDateLabel)
            r1c2.Controls.Add(lblStartDate)
            r2c1.Controls.Add(returnDateLabel)
            r2c2.Controls.Add(lblReturnDate)
            r1.Cells.Add(r1c1)
            r1.Cells.Add(r1c2)
            r2.Cells.Add(r2c1)
            r2.Cells.Add(r2c2)
            tbl.Rows.Add(r1)
            tbl.Rows.Add(r2)
        End If
        Return tbl
    End Function

    Protected Function GenerateSickTable(ByVal count As Integer, ByVal sickDate As Date,
                                     ByVal hours As Byte, ByVal minutes As Byte) As Table
        Dim tbl As New Table
        tbl.ID = "tblSick" & count.ToString
        Dim r1, r2, r3 As New TableRow
        Dim r1c1, r1c2, r2c1, r2c2, r3c1, r3c2 As New TableCell
        Dim sickDateLabel, hoursLabel, minutesLabel As New Label
        Dim lblSickDate, lblHours, lblMinutes As New Label
        SetHeaderLabel(sickDateLabel, "Date:", "sickDateLabel", count)
        SetHeaderLabel(hoursLabel, "Hours:", "hoursLabel", count)
        SetHeaderLabel(minutesLabel, "Minutes:", "minutesLabel", count)
        SetLabel(lblSickDate, sickDate, "lblSickDate", count)
        SetLabel(lblHours, hours, "lblHours", count)
        SetLabel(lblMinutes, minutes, "lblMinutes", count)
        r1c1.Controls.Add(sickDateLabel)
        r1c2.Controls.Add(lblSickDate)
        r2c1.Controls.Add(hoursLabel)
        r2c2.Controls.Add(lblHours)
        r3c1.Controls.Add(minutesLabel)
        r3c2.Controls.Add(lblMinutes)
        r1.Cells.Add(r1c1)
        r1.Cells.Add(r1c2)
        r2.Cells.Add(r2c1)
        r2.Cells.Add(r2c2)
        r3.Cells.Add(r3c1)
        r3.Cells.Add(r3c2)
        tbl.Rows.Add(r1)
        tbl.Rows.Add(r2)
        tbl.Rows.Add(r3)
        Return tbl
    End Function

    Protected Sub SetLabel(ByVal label As Label, ByVal text As String, ByVal name As String, ByVal count As Integer)
        label.Text = text
        label.ID = name & count
    End Sub
    Protected Sub SetHeaderLabel(ByVal label As Label, ByVal text As String, ByVal name As String, ByVal count As Integer)
        label.Text = text
        label.Font.Bold = True
        label.ID = name & count
    End Sub

    Protected Sub btnAccept_Click(sender As Object, e As System.EventArgs) Handles btnAccept.Click
        Dim client As New SmtpClient(getSmtpHost())
        Try
            UpdateRequest(CType(Session.Item("reqID"), Integer), 1)
            client.Send(Email(True))
        Catch ex As Exception
            Session("exception") = ex
            Response.Redirect("CustomErrorPage.aspx")
        End Try
        Session("confirm") = "approved"
        Response.Redirect("Confirm.aspx")
    End Sub

    Protected Sub btnDecline_Click(sender As Object, e As System.EventArgs) Handles btnDecline.Click
        Dim client As New SmtpClient(getSmtpHost())
        Try
            UpdateRequest(CType(Session.Item("reqID"), Integer), 0)
            client.Send(Email(False))
        Catch ex As Exception
            Session("exception") = ex
            Response.Redirect("CustomErrorPage.aspx")
        End Try
        Session("confirm") = "decline"
        Response.Redirect("Confirm.aspx")
    End Sub

    Private Function generateBody(ByVal approved As Boolean) As String
        Dim body As String = ""

        If approved Then
            body &= CType(Session.Item("manager"), String) & " has approved a Change of Status Request for " & CType(Session.Item("username"), String) & ". To view the details of this request please follow the link below. <br><br><br>"
        Else
            body &= CType(Session.Item("manager"), String) & " has declined your Change of Status Request. To review the request details please follow the link below. <br><br><br>"
        End If
        If tbComments.Text.Length > 0 Then
            body &= "Additional comments: <br>" & tbComments.Text & "<br><br><br>"
        End If
        body &= "<a href=" & getURL() & CType(Session.Item("reqID"), Integer) & "&mgr=0"">View Details</a>"

        'writeToLog(body)

        Return body
    End Function

    Private Function Email(ByVal approved As Boolean) As MailMessage
        Dim msg As New MailMessage()
        msg.From = New MailAddress(getSenderEmail())
        msg.To.Add(New MailAddress(formatEmail(CType(Session.Item("username"), String))))
        msg.To.Add(New MailAddress(getHREmail()))
        msg.To.Add(New MailAddress(getHREmail1()))
        msg.CC.Add(New MailAddress(formatEmail(CType(Session.Item("manager"), String))))
        msg.Subject = "Change of Status Request"
        msg.IsBodyHtml = True
        msg.Body = generateBody(approved)
        Return msg
    End Function
End Class
