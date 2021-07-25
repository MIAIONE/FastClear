Public Class MainWindow

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub ClearRAMBtn_Click(sender As Object, e As EventArgs) Handles ClearRAMBtn.Click
        DelayControl(ClearRAMBtn, False)
        ClearHelper.ClearMemory()
        DelayControl(ClearRAMBtn, True)
    End Sub
    Private Sub DelayControl(controls As Control, state As Boolean)
        controls.Enabled = state
    End Sub
    Private RAM_VALUE As PerformanceCounter = ClearHelper.GetCurrentMemoryUsing
    Private Sub RAM_Refresh_Tick(sender As Object, e As EventArgs) Handles RAM_Refresh.Tick
        Dim usingT As Single = (8089 - RAM_VALUE.NextValue) / 8089 * 100
        If usingT >= 70.55 Then
            RAM_Size.ForeColor = Color.Crimson
        Else
            RAM_Size.ForeColor = Color.Green
        End If
        RAM_Size.Text = "内存占用:" + usingT.ToString.Substring(0, 5) + "%"
    End Sub
    Private CPU_VALUE As PerformanceCounter = ClearHelper.GetCPUAllCoreUsing
    Private Sub CPU_Refresh_Tick(sender As Object, e As EventArgs) Handles CPU_Refresh.Tick
        Dim usingT As Single = CPU_VALUE.NextValue
        If usingT >= 85.0 Then
            CPU_Size.ForeColor = Color.Crimson
        Else
            CPU_Size.ForeColor = Color.Green
        End If
        CPU_Size.Text = "CPU占用:" + usingT.ToString.Substring(0, 5) + "%"
    End Sub


End Class
