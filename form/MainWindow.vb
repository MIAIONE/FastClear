Public Class MainWindow

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Program.GetOSVersion.Major >= 10 Then
            Performance_highest.Enabled = True
        Else
            Performance_highest.Enabled = False
        End If
        Select Case My.Settings.PowerCfgChoice
            Case My.Settings.PowerCfg_low
                Performance_low.Checked = True
            Case My.Settings.PowerCfg_Auto
                Performance_auto.Checked = True
            Case My.Settings.PowerCfg_High
                Performance_high.Checked = True
            Case My.Settings.PowerCfg_Highest
                Performance_highest.Checked = True
        End Select
    End Sub
    Private Sub MainWindow_UnLoad(sender As Object, e As cancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Hide()
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
            My.Settings.PowerCfgChoice = My.Settings.PowerCfg_low
            ConfigHelper.DymSaveAndReload()
            FuncRun.Run(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\powercfg.exe", ClearConst.POWERCFG_ACTIVE + My.Settings.PowerCfgChoice.ToString)
        End If
    End Sub

    Private Sub Performance_auto_CheckedChanged(sender As Object, e As EventArgs) Handles Performance_auto.CheckedChanged
        If Performance_auto.Checked Then
            My.Settings.PowerCfgChoice = My.Settings.PowerCfg_Auto
            ConfigHelper.DymSaveAndReload()
            FuncRun.Run(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\powercfg.exe", ClearConst.POWERCFG_ACTIVE + My.Settings.PowerCfgChoice.ToString)
        End If
    End Sub

    Private Sub Performance_high_CheckedChanged(sender As Object, e As EventArgs) Handles Performance_high.CheckedChanged
        If Performance_high.Checked Then
            My.Settings.PowerCfgChoice = My.Settings.PowerCfg_High
            ConfigHelper.DymSaveAndReload()
            FuncRun.Run(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\powercfg.exe", ClearConst.POWERCFG_ACTIVE + My.Settings.PowerCfgChoice.ToString)
        End If
    End Sub

    Private Sub Performance_highest_CheckedChanged(sender As Object, e As EventArgs) Handles Performance_highest.CheckedChanged
        If Performance_highest.Checked Then
            My.Settings.PowerCfgChoice = My.Settings.PowerCfg_Highest
            ConfigHelper.DymSaveAndReload()
            FuncRun.Run(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\powercfg.exe", ClearConst.POWERCFG_ACTIVE + My.Settings.PowerCfgChoice.ToString)
        End If
    End Sub

    Private Sub TaskBarMenu_Click(sender As Object, e As MouseEventArgs) Handles TaskBarMenu.Click
        Show()
    End Sub

    Private Sub 退出前台程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出前台程序ToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub 退出后台服务程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出后台服务程序ToolStripMenuItem.Click
        ServicesRun.ServiceHelper.StopService()
    End Sub

    Private Sub 全部退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全部退出ToolStripMenuItem.Click
        ServicesRun.ServiceHelper.StopService()
        Application.Exit()
    End Sub

    Private Sub SetAppdefineClearing_Click(sender As Object, e As EventArgs) Handles SetAppdefineClearing.Click
        DelayControl(SetAppdefineClearing, False)
        If ServicesRun.ServiceHelper.IsServiceExisted Then
            ServicesRun.ServiceHelper.StopService()
        Else
            ShowErrorDialog("FastClear | 未找到服务", "尚未安装服务（正常情况下应该已经在初次启动时安装），请先在自定义选项选中【启动后台优化服务】（如果此选项尚未勾选），然后单击【应用优化并保存设置】以安装服务", UIStyle.Red, False)
            Exit Sub
        End If
        Dim FormCtrler As New FormControl
        Dim FunctionRunner As New FuncRun
        FormCtrler.MainForm.DealyBool = False
        AddHandler FunctionRunner.MainProcess.OutputDataReceived, New DataReceivedEventHandler(Sub(s, ev)
                                                                                                   FormCtrler.AppendMsg("[Execute] " + ev.Data)
                                                                                               End Sub)
        Task.Factory.StartNew(New Action(Sub()
                                             FormCtrler.AppendMsg("[FastClear] 服务已停止.")
                                             ConfigHelper.AutoClearTime = (SetAutoTime.IntValue * 1000)
                                             If FormControl.GetControlCheckBoxChecked(EnableGlobalGPUCheckBth) Then
                                                 FormCtrler.AppendMsg("[GPUEngine] GPU全局加速已开启，等待服务重启中...")
                                                 My.Settings.GlobalGPUSpeedUp = True
                                                 ClearHelper.EnableGPU(True)
                                             Else
                                                 FormCtrler.AppendMsg("[GPUEngine] GPU全局加速已关闭，等待服务重启中...")
                                                 My.Settings.GlobalGPUSpeedUp = False
                                                 ClearHelper.EnableGPU(False)
                                             End If
                                             If FormControl.GetControlCheckBoxChecked(ClearLoopMemoryCheckBtn) Then
                                                 ConfigHelper.ClearMemory = True
                                             Else
                                                 ConfigHelper.ClearMemory = False
                                             End If
                                             If FormControl.GetControlCheckBoxChecked(UseVirtualMemoryCheckBtn) Then
                                                 ConfigHelper.Priority_UseVirtualMemory = True
                                             Else
                                                 ConfigHelper.Priority_UseVirtualMemory = False
                                             End If
                                             If FormControl.GetControlCheckBoxChecked(SetVirtualRAMCheckBtn) Then
                                                 My.Settings.DefineVirtualMemory_Max = VirtualRAM_MAX_SIZE.IntValue
                                                 My.Settings.DefineVirtualMemory_Min = VirtualRAM_MIN_SIZE.IntValue
                                                 FormCtrler.AppendMsg("[WMIC] 正在设置虚拟内存...")
                                                 WMICHelper.SetVirtualRAM(VirtualRAM_MIN_SIZE.IntValue, VirtualRAM_MAX_SIZE.IntValue)
                                                 FormCtrler.AppendMsg("[WMIC] 虚拟内存设置成功.")
                                             End If
                                             ConfigHelper.DymSaveAndReload()

                                             ServicesRun.ServiceHelper.StartService()
                                             FormCtrler.AppendMsg("[FastClear] 服务已启动.")
                                             FormCtrler.Close()
                                         End Sub))
        FormCtrler.Show()
        DelayControl(SetAppdefineClearing, True)
    End Sub

    Private Sub ApplyForeCtrlBtn_Click(sender As Object, e As EventArgs) Handles ApplyForeCtrlBtn.Click
        DelayControl(ApplyForeCtrlBtn, False)
        Dim FormCtrler As New FormControl
        Dim DismDistance As New DismHelper
        Dim FunctionRunner As New FuncRun
        FormCtrler.MainForm.DealyBool = False
        AddHandler FunctionRunner.MainProcess.OutputDataReceived, New DataReceivedEventHandler(Sub(s, ev)
                                                                                                   FormCtrler.AppendMsg("[Execute] " + ev.Data)
                                                                                               End Sub)
        AddHandler DismDistance.MainProcess.OutputDataReceived, New DataReceivedEventHandler(Sub(s, ev)
                                                                                                 FormCtrler.AppendMsg("[Dism] " + ev.Data)
                                                                                             End Sub)
        Task.Factory.StartNew(New Action(Sub()
                                             If FormControl.GetControlCheckBoxChecked(DISM_CLEAR_CheckBtn) Then

                                                 DismDistance.Run(ClearConst.DISM_CLEAR_UPDATE_IMAGE)
                                             Else

                                             End If
                                             If FormControl.GetControlCheckBoxChecked(Deleted_Prefiles_CheckedBtn) Then
                                                 FormCtrler.AppendMsg("[Memory] 正在清理...")
                                                 'ClearHelper.ClearMemory(False)
                                                 ClearHelper.ClearMemory(ConfigHelper.Priority_UseVirtualMemory)
                                                 FormCtrler.AppendMsg("[Memory] 清理完成.")
                                             End If
                                             If FormControl.GetControlCheckBoxChecked(DeletedWindowsBT_WS_CheckBtn) Then

                                             End If
                                             If FormControl.GetControlCheckBoxChecked(DeletedOldWindowsCheckBtn) Then

                                             End If
                                             If FormControl.GetControlCheckBoxChecked(RegClear) Then
                                                 FormCtrler.AppendMsg("[Register] 正在优化注册表")
                                                 ClearHelper.ClearReg()
                                                 FormCtrler.AppendMsg("[Register] 优化完成.")
                                             End If
                                             If FormControl.GetControlCheckBoxChecked(SrvListControl) Then

                                             End If
                                             If FormControl.GetControlCheckBoxChecked(Fastboot) Then

                                             End If
                                             If FormControl.GetControlCheckBoxChecked(HiberSleep) Then

                                             End If
                                             If FormControl.GetControlCheckBoxChecked(RestartSysProc) Then

                                             End If
                                             ConfigHelper.DymSaveAndReload()
                                             FormCtrler.Close()
                                         End Sub))
        FormCtrler.Show()
        DelayControl(ApplyForeCtrlBtn, True)
    End Sub

    Private Sub SetVirtualRAMCheckBtn_CheckedChanged(sender As Object, e As EventArgs) Handles SetVirtualRAMCheckBtn.CheckedChanged
        If SetVirtualRAMCheckBtn.Checked Then
            VirtualRAM_MAX_SIZE.Enabled = True
            VirtualRAM_MIN_SIZE.Enabled = True
        Else
            VirtualRAM_MAX_SIZE.Enabled = False
            VirtualRAM_MIN_SIZE.Enabled = False
        End If
    End Sub

    Private Sub UseVirtualMemoryCheckBtn_CheckedChanged(sender As Object, e As EventArgs) Handles UseVirtualMemoryCheckBtn.CheckedChanged
        If UseVirtualMemoryCheckBtn.Checked Then
            SetVirtualRAMCheckBtn.Enabled = True
        Else
            SetVirtualRAMCheckBtn.Checked = False
            SetVirtualRAMCheckBtn.Enabled = False
        End If
    End Sub

    Private Sub ClearLoopMemoryCheckBtn_CheckedChanged(sender As Object, e As EventArgs) Handles ClearLoopMemoryCheckBtn.CheckedChanged
        If ClearLoopMemoryCheckBtn.Checked Then
            UseVirtualMemoryCheckBtn.Enabled = True
        Else
            UseVirtualMemoryCheckBtn.Checked = False
            UseVirtualMemoryCheckBtn.Enabled = False
        End If
    End Sub
End Class
