<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Midcross
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
        Me.pnlBoard = New System.Windows.Forms.Panel()
        Me.pnlTopNums = New System.Windows.Forms.Panel()
        Me.pnlLeftNums = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnlBoard
        '
        Me.pnlBoard.Location = New System.Drawing.Point(345, 276)
        Me.pnlBoard.Name = "pnlBoard"
        Me.pnlBoard.Size = New System.Drawing.Size(445, 445)
        Me.pnlBoard.TabIndex = 0
        '
        'pnlTopNums
        '
        Me.pnlTopNums.Location = New System.Drawing.Point(345, 107)
        Me.pnlTopNums.Name = "pnlTopNums"
        Me.pnlTopNums.Size = New System.Drawing.Size(445, 163)
        Me.pnlTopNums.TabIndex = 1
        '
        'pnlLeftNums
        '
        Me.pnlLeftNums.Location = New System.Drawing.Point(189, 276)
        Me.pnlLeftNums.Name = "pnlLeftNums"
        Me.pnlLeftNums.Size = New System.Drawing.Size(150, 445)
        Me.pnlLeftNums.TabIndex = 2
        '
        'Midcross
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 745)
        Me.Controls.Add(Me.pnlLeftNums)
        Me.Controls.Add(Me.pnlTopNums)
        Me.Controls.Add(Me.pnlBoard)
        Me.Name = "Midcross"
        Me.Text = "Midcross"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBoard As Panel
    Friend WithEvents pnlTopNums As Panel
    Friend WithEvents pnlLeftNums As Panel
End Class
