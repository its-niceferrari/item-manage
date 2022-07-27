Imports System.IO

Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.AddRange(TextBox1.Text.Split(vbNewLine))
        TextBox1.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()

        'ListBox1.Item.ClearSelected()
        'Clear(ListBox1.SelectedItem)
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        MessageBox.Show("Item Manage - Version: 1.0.1.0 - Build Date: 2022-07-26", "About")
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
            My.Computer.FileSystem.WriteAllText _
            (SaveFileDialog1.FileName, lst, True)
        End If
    End Sub

    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        ' opens OpenFileDialog1
        OpenFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
         Then
            'clears all items before opening text file
            ListBox1.Items.Clear()

            For Each line As String In File.ReadLines(OpenFileDialog1.SafeFileName)
                ' adds each line as a seperate ListBox1 item
                ListBox1.Items.AddRange(line.Split(vbNewLine))
            Next
        End If
    End Sub
End Class
