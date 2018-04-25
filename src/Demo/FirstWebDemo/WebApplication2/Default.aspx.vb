Imports FirstWebDemo.Mode

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim dbh As New Keel.DBHelper(Of Table_1)
        Dim t As Table_1 = dbh.Distill(Me.ctl_Table_1_Keel1)
        dbh.Fill(Me.ctl_Table_1_Keel2, t)


    End Sub
End Class