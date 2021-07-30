Public Class DResultPercents
    Public Property PercentBarSendData As UInteger = 0
    Public Property DealyBool As Boolean = True
    Public Property DealyTime As UInteger = 0
    Public Sub AutoCloseMe()
        DealyTime = 0
        CanClose = True
        Percents.Value = 100
        Close()
    End Sub
    Private Sub DResultPercents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AutoPercentStep.Interval = 1000 / (100 / DealyTime)
        AutoPercentStep.Enabled = True
        DisposeDealyTimer.Enabled = DealyBool
    End Sub
    Private CanClose As Boolean = False
    Private Sub DResultPercents_UnLoad(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        If CanClose = False Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub DisposeDealyTimer_Tick(sender As Object, e As EventArgs) Handles DisposeDealyTimer.Tick
        If DealyTime > 0 Then
            DealyTime -= 1
        Else
            Percents.Value = 100
            CanClose = True
            Close()
        End If
    End Sub

    Private Sub AutoPercentStep_Tick(sender As Object, e As EventArgs) Handles AutoPercentStep.Tick
        Percents.Value += 1
    End Sub
End Class