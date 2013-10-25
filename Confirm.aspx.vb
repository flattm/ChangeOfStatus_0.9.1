
Partial Class Confirm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim confirm As String = CType(Session.Item("confirm"), String)
        If confirm = "request" Then
            lblConfirm.Text = "Your Status Change has been submitted.  A confirmation email will be sent to you and " & CType(Session.Item("manager"), String) & " shortly.  Please keep this email for future reference."
        ElseIf confirm = "approve" Then
            lblConfirm.Text = "Your response has been submitted.  A confirmation email will be sent to you, " & CType(Session.Item("username"), String) & ", and the Human Resource Department.  Please keep this email for future reference."
        Else
            lblConfirm.Text = "Your response has been submitted.  A confirmation email will be sent to you and " & CType(Session.Item("username"), String) & " shortly.  Please keep this email for future reference."
        End If
    End Sub
End Class
