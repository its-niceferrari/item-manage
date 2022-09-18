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

    Private Sub MnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub MnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        AboutBox.Refresh()
        AboutBox.Show()
    End Sub

    Private Sub MnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        'writes ListBox1 items to String
        Dim lst As String = ""
        For Each item As String In ListBox1.Items
            lst &= item & vbCrLf
        Next
        Debug.Print(lst)

        'opens SaveFileDialog1 and writes lst variable to text file
        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
         Then
            'My.Computer.FileSystem.WriteAllText _
            '(SaveFileDialog1.FileName, lst, True)

            File.WriteAllText(SaveFileDialog1.FileName, lst)
        End If
    End Sub

    Private Sub MnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        'opens OpenFileDialog1
        OpenFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
         Then
            'clears all items before opening text file
            ListBox1.Items.Clear()

            For Each line As String In File.ReadLines(OpenFileDialog1.FileName)
                'adds each line as a seperate ListBox1 item
                ListBox1.Items.AddRange(line.Split(vbNewLine))
            Next
        End If
    End Sub

    Private Sub MnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        If ListBox1.SelectedIndex >= 0 Then
            Clipboard.SetText(ListBox1.SelectedItem)
        End If
    End Sub

    Private Sub AddItemButton_Click(sender As Object, e As EventArgs) Handles addItemButton.Click
        ListBox1.Items.AddRange(newItemTextBox.Text.Split(vbNewLine))
        newItemTextBox.Clear()
    End Sub

    Private Sub DeleteItemButton_Click(sender As Object, e As EventArgs) Handles deleteItemButton.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub MoveUpButton_Click(sender As Object, e As EventArgs) Handles moveUpButton.Click
        MoveItem(-1)
    End Sub

    Private Sub MoveDownButton_Click(sender As Object, e As EventArgs) Handles moveDownButton.Click
        MoveItem(1)
    End Sub

    Public Function MoveItem(ByVal direction As Integer) As Integer
        'checks selected item
        If (ListBox1.SelectedItem = vbNullString Or ListBox1.SelectedIndex < 0) Then
            Return 0 'no selected item - nothing to do
        End If

        'calculates New index using move direction
        Dim newIndex = ListBox1.SelectedIndex + direction

        'checks bounds of the range
        If (newIndex < 0 Or newIndex >= ListBox1.Items.Count) Then
            Return 0 'index out of range - nothing to do
        End If

        Dim selected = ListBox1.SelectedItem

        'removes removable element
        ListBox1.Items.Remove(selected)

        'inserts it in New position
        ListBox1.Items.Insert(newIndex, selected)

        'restores selection
        ListBox1.SetSelected(newIndex, True)
        Return 0

    End Function
End Class
