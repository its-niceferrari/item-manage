<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Find_Dialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.findWhatLabel = New System.Windows.Forms.Label()
        Me.findTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(349, 13)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Find"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(349, 42)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'findWhatLabel
        '
        Me.findWhatLabel.AutoSize = True
        Me.findWhatLabel.Location = New System.Drawing.Point(12, 18)
        Me.findWhatLabel.Name = "findWhatLabel"
        Me.findWhatLabel.Size = New System.Drawing.Size(56, 13)
        Me.findWhatLabel.TabIndex = 1
        Me.findWhatLabel.Text = "Find what:"
        '
        'findTextBox
        '
        Me.findTextBox.Location = New System.Drawing.Point(74, 15)
        Me.findTextBox.Name = "findTextBox"
        Me.findTextBox.Size = New System.Drawing.Size(269, 20)
        Me.findTextBox.TabIndex = 2
        '
        'Find_Dialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 148)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.findTextBox)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.findWhatLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(451, 195)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(451, 195)
        Me.Name = "Find_Dialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Find"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents findWhatLabel As Label
    Friend WithEvents findTextBox As TextBox
End Class
