Public Class MainWindow

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim msg As New StringBuilder
        msg.AppendLine("使用本软件可能会使得电脑更流畅，但想要更可观的实际性能提升，你仍需要购买更强的硬件以升级来获得。")
        msg.AppendLine("本软件为开放源代码软件，开源许可为MIT，完全免费，严禁倒卖和商用！")
        msg.AppendLine("")
        msg.AppendLine("本软件会使用以下权限：")
        msg.AppendLine("1.如运行服务则会使用额外的权限：SYSTEM账户")
        msg.AppendLine("2.全部特权令牌")
        msg.AppendLine("3.操作系统文件")
        msg.AppendLine("4.操作注册表")
        msg.AppendLine("5.管理员身份权限")
        msg.AppendLine("6.相关设备信息")
        msg.AppendLine("")
        msg.AppendLine("本软件会修改如下设置：")
        msg.AppendLine("1.系统电源选项")
        msg.AppendLine("2.全局硬件加速注册表")
        msg.AppendLine("3.删除系统更新遗留的更新文件")
        msg.AppendLine("4.结束资源管理器、桌面窗口管理器、索引服务")
        msg.AppendLine("5.操作内存数据、写入虚拟内存")
        msg.AppendLine("6.删除系统预读文件、缓存文件、临时文件、回收站文件")
        msg.AppendLine("")
        msg.AppendLine("你已知晓修改相关设置可能会带来系统的不稳定和严重发热、耗电等问题，如出现任何问题，均由使用者自行承担！")
        msg.AppendLine("点击【确定】接受许可协议并进入，如不接受，请单击【取消】退出程序。")
        Dim ask_result = ShowAskDialog("FastClear | 警告！请仔细阅读本软件使用须知！", msg.ToString, UIStyle.Red, True)
        If ask_result = False Then
            Application.Exit()
        End If
        If Program.GetOSVersion.Major >= 10 Then
            Performance_highest.Enabled = True
        Else
            Performance_highest.Enabled = False
        End If

    End Sub

    Private Sub ClearRAMBtn_Click(sender As Object, e As EventArgs) Handles ClearRAMBtn.Click
        DelayControl(ClearRAMBtn, False)
        ClearHelper.ClearMemory()
        DelayControl(ClearRAMBtn, True)
    End Sub
    Private Sub DelayControl(controls As Control, state As Boolean)
        controls.Enabled = state
    End Sub
    Private ReadOnly RAM_VALUE As PerformanceCounter = ClearHelper.GetCurrentMemoryUsing
    Private Sub RAM_Refresh_Tick(sender As Object, e As EventArgs) Handles RAM_Refresh.Tick
        Dim usingT As Single = (8089 - RAM_VALUE.NextValue) / 8089 * 100
        If usingT >= 75.0 Then
            RAM_Size.ForeColor = Color.Crimson
        Else
            RAM_Size.ForeColor = Color.Green
        End If
        RAM_Size.Text = "内存占用:" + usingT.ToString.Substring(0, 5) + "%"
    End Sub
    Private ReadOnly CPU_VALUE As PerformanceCounter = ClearHelper.GetCPUAllCoreUsing
    Private Sub CPU_Refresh_Tick(sender As Object, e As EventArgs) Handles CPU_Refresh.Tick
        Dim usingT As Single = CPU_VALUE.NextValue
        If usingT >= 85.0 Then
            CPU_Size.ForeColor = Color.Crimson
        Else
            CPU_Size.ForeColor = Color.Green
        End If
        CPU_Size.Text = "CPU占用:" + usingT.ToString.Substring(0, 5) + "%"
    End Sub

    Private Sub Performance_low_CheckedChanged(sender As Object, e As EventArgs) Handles Performance_low.CheckedChanged
        If Performance_low.Checked Then
            FuncRun.Run(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\powercfg.exe", ClearConst.POWERCFG_ACTIVE + ClearConst.GUID_EnergySaving)
        End If
    End Sub

    Private Sub Performance_auto_CheckedChanged(sender As Object, e As EventArgs) Handles Performance_auto.CheckedChanged
        If Performance_auto.Checked Then
            FuncRun.Run(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\powercfg.exe", ClearConst.POWERCFG_ACTIVE + ClearConst.GUID_Balanced)
        End If
    End Sub

    Private Sub Performance_high_CheckedChanged(sender As Object, e As EventArgs) Handles Performance_high.CheckedChanged
        If Performance_high.Checked Then
            FuncRun.Run(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\powercfg.exe", ClearConst.POWERCFG_ACTIVE + ClearConst.GUID_HighPerformance)
        End If
    End Sub

    Private Sub Performance_highest_CheckedChanged(sender As Object, e As EventArgs) Handles Performance_highest.CheckedChanged
        If Performance_highest.Checked Then
            FuncRun.Run(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\powercfg.exe", ClearConst.POWERCFG_ACTIVE + ClearConst.GUID_ExcellentPerformance)
        End If
    End Sub
End Class
