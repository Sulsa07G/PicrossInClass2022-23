Public Class Midcross
    Public board As New List(Of List(Of picrossButton))

    ''' <summary>
    ''' Creates a 2d list of picross buttons
    ''' </summary>
    Public Sub generateRandomBoard(numOfRows As Integer, numOfCols As Integer)
        board.Clear()
        Dim rand As New Random

        For row As Integer = 0 To numOfRows - 1
            board.Add(New List(Of picrossButton))
            For col As Integer = 0 To numOfCols - 1
                Dim good As Boolean = IIf(rand.Next(0, 2) = 1, True, False)
                Dim pbtn As picrossButton = New picrossButton With {
                    .good = good
                    }
                board(row).Add(pbtn)
            Next
        Next

    End Sub

    ''' <summary>
    ''' Uses the 2d board list to size and place buttons in the board panel
    ''' </summary>
    Public Sub FillBoardPanel()
        If board.Count < 1 Then
            MsgBox("board data structure invalid")
            Return
        End If
        Dim cols As Integer = board(0).Count
        Dim rows As Integer = board.Count
        pnlBoard.Controls.Clear()
        'determine size of buttons
        Dim btnWidth As Integer = pnlBoard.Size.Width / cols
        Dim btnHeight As Integer = pnlBoard.Size.Width / rows
        Try
            For row As Integer = 0 To rows - 1
                For col As Integer = 0 To cols - 1
                    board(row)(col).Width = btnWidth
                    board(row)(col).Height = btnHeight
                    board(row)(col).Location = New Point(col * btnWidth, row * btnHeight)
                    pnlBoard.Controls.Add(board(row)(col))
                    AddHandler board(row)(col).Click, AddressOf btnClicked
                Next
            Next
        Catch ex As ArgumentOutOfRangeException
            MsgBox("Index out of range.")
        End Try

    End Sub

    Private Sub btnClicked(btn As picrossButton, e As EventArgs)
        If btn.clicked Then
            Return
        Else
            btn.clicked = True
        End If
    End Sub

    Private Sub GenerateColumnLabels()
        'make sure we have a board
        If board.Count = 0 Then
            Return
        End If
        Dim cols As Integer = board(0).Count
        Dim lblwidth As Integer = pnlTopNums.Width / cols
        For col As Integer = 0 To cols - 1
            Dim count As Integer = 0
            Dim streaks As New List(Of Integer)
            For row As Integer = 0 To board.Count - 1
                If board(row)(col).good Then
                    count += 1
                Else
                    If count >= 1 Then
                        streaks.Add(count)
                    End If
                    count = 0
                End If
            Next
            If count >= 1 Then
                streaks.Add(count)
            End If
            Dim newLbl As Label = createTopLabel(streaks, lblwidth)
            newLbl.Location = New Point(col * lblwidth, 0)
            pnlTopNums.Controls.Add(newLbl)
        Next
    End Sub

    Function createTopLabel(nums As List(Of Integer), width As Integer) As Label
        Dim lbl As New Label
        lbl.Width = width
        lbl.Height = pnlTopNums.Height
        lbl.TextAlign = ContentAlignment.BottomCenter
        lbl.Text = Strings.Join(nums.Select(Function(x) x.ToString()).ToArray(), ControlChars.NewLine)
        Return lbl
    End Function

    Private Sub Midcross_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        generateRandomBoard(10, 10) 'this is responsible for building our data structure with picross buttons
        FillBoardPanel() 'this is responsible for placing the buttons in the panel
        GenerateColumnLabels()
        revealAnswers()
    End Sub

    Public Sub revealAnswers()
        For Each ctrl As picrossButton In pnlBoard.Controls
            If ctrl.good Then
                ctrl.Text = "X"
            Else
                ctrl.Text = "-"
            End If
        Next
    End Sub
End Class

Public Class picrossButton
    Inherits Button

    Private _clicked As Boolean = False
    Public Property good As Boolean = False
    Public Property clicked As Boolean
        Get
            Return _clicked
        End Get
        Set(value As Boolean)
            _clicked = value
            If _clicked Then
                Me.Enabled = False
                If good Then
                    Me.BackColor = Color.Green
                Else
                    Me.BackColor = Color.Red
                End If
            Else
                Me.BackColor = Control.DefaultBackColor
            End If
        End Set
    End Property
End Class