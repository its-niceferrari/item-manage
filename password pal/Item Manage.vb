Imports System.IO

Public Class Form1

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ListBox1.Items.AddRange(newItemTextBox.Text.Split(vbNewLine))
        newItemTextBox.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        AboutBox.Refresh()
        AboutBox.Show()
    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        ' writes ListBox1 items to String
        Dim lst As String = ""
        For Each item As String In ListBox1.Items
            lst &= item & vbCrLf
        Next
        Debug.Print(lst)

        ' opens SaveFileDialog1 and writes lst variable to text file
        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
         Then
            'My.Computer.FileSystem.WriteAllText _
            '(SaveFileDialog1.FileName, lst, True)

            File.WriteAllText(SaveFileDialog1.FileName, lst)
        End If
    End Sub

    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        ' opens OpenFileDialog1
        OpenFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
         Then
            'clears all items before opening text file
            ListBox1.Items.Clear()

            For Each line As String In File.ReadLines(OpenFileDialog1.FileName)
                ' adds each line as a seperate ListBox1 item
                ListBox1.Items.AddRange(line.Split(vbNewLine))
            Next
        End If
    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        If ListBox1.SelectedIndex >= 0 Then
            Clipboard.SetText(ListBox1.SelectedItem)
        End If
    End Sub

    Private Sub mnuFind_Click(sender As Object, e As EventArgs) Handles mnuFind.Click
        Find_Dialog.Refresh()
        Find_Dialog.Show()
    End Sub

    Private Sub addItemButton_Click(sender As Object, e As EventArgs) Handles addItemButton.Click

    End Sub
End Class
