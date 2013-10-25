Imports Utility

Partial Class CustomErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim ex As Exception = CType(Session.Item("exception"), Exception)
        errorLogging(ex)
        lblError.Text = ex.ToString & vbCrLf & ex.Message & vbCrLf & ex.StackTrace
    End Sub
End Class