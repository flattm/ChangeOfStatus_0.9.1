Partial Class ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim location As String = CType(Session.Item("errorLocation"), String)
        If location.Equals("getReqID") Then
            Label1.Text = "There was an unexpected error while setting an application variable."
        End If
    End Sub

End Class