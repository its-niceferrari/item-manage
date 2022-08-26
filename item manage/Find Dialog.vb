Imports System.Windows.Forms
Public Class Find_Dialog
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If findTextBox.Text = "" Then
            findResults.Text = "Enter a search query to find in the list."
            'TODO
            'Else
            'Dim firstResult = ListBox1.Search
            'findResults.Text = 

        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Find_Dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles findWhatLabel.Click

    End Sub

    Private Sub findTextBox_TextChanged(sender As Object, e As EventArgs) Handles findTextBox.TextChanged

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles findResults.Click

    End Sub
End Class
