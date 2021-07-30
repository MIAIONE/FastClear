<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
    Inherits UIForm

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.RAM_Size = New Sunny.UI.UILabel()
        Me.RAM_Refresh = New System.Windows.Forms.Timer(Me.components)
        Me.SetAppdefineClearing = New Sunny.UI.UIButton()
        Me.CPU_Size = New Sunny.UI.UILabel()
        Me.CPU_Refresh = New System.Windows.Forms.Timer(Me.components)
        Me.Performance_low = New Sunny.UI.UIRadioButton()
        Me.pcg_cfg = New Sunny.UI.UIGroupBox()
        Me.Performance_highest = New Sunny.UI.UIRadioButton()
        Me.Performance_high = New Sunny.UI.UIRadioButton()
        Me.Performance_auto = New Sunny.UI.UIRadioButton()
        Me.pcg_settings = New Sunny.UI.UIGroupBox()
        Me.SetAutoTime = New Sunny.UI.UITextBox()
        Me.Auto_Time_lable = New Sunny.UI.UILabel()
        Me.SetVirtualRAMCheckBtn = New Sunny.UI.UICheckBox()
        Me.VirtualRAM_MAX_SIZE = New Sunny.UI.UITextBox()
        Me.LABLE_MAX = New Sunny.UI.UILabel()
        Me.LABLE_MIN = New Sunny.UI.UILabel()
        Me.VirtualRAM_MIN_SIZE = New Sunny.UI.UITextBox()
        Me.UseVirtualMemoryCheckBtn = New Sunny.UI.UICheckBox()
        Me.ClearLoopMemoryCheckBtn = New Sunny.UI.UICheckBox()
        Me.EnableGlobalGPUCheckBth = New Sunny.UI.UICheckBox()
        Me.pcg_set = New Sunny.UI.UIGroupBox()
        Me.UiTextBox1 = New Sunny.UI.UITextBox()
        Me.UiTextBox2 = New Sunny.UI.UITextBox()
        Me.DISM_CLEAR_CheckBtn = New Sunny.UI.UICheckBox()
        Me.ManualMode_pcfg = New Sunny.UI.UIGroupBox()
        Me.SetMeProtect = New Sunny.UI.UICheckBox()
        Me.RestartSysProc = New Sunny.UI.UICheckBox()
        Me.ApplyForeCtrlBtn = New Sunny.UI.UIButton()
        Me.MyClearSrv = New Sunny.UI.UICheckBox()
        Me.HiberSleep = New Sunny.UI.UICheckBox()
        Me.Fastboot = New Sunny.UI.UICheckBox()
        Me.SrvListControl = New Sunny.UI.UICheckBox()
        Me.RegClear = New Sunny.UI.UICheckBox()
        Me.DeletedOldWindowsCheckBtn = New Sunny.UI.UICheckBox()
        Me.DeletedWindowsBT_WS_CheckBtn = New Sunny.UI.UICheckBox()
        Me.Deleted_Prefiles_CheckedBtn = New Sunny.UI.UICheckBox()
        Me.OtherGroup_Pcfg = New Sunny.UI.UIGroupBox()
        Me.AutoKillProc_ByList = New Sunny.UI.UIButton()
        Me.Process_Kill_ListBox = New Sunny.UI.UITextBox()
        Me.WindowsInformation_Texts = New Sunny.UI.UITextBox()
        Me.TaskBarMenu = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TaskBarMenu_CMS = New Sunny.UI.UIContextMenuStrip()
        Me.退出前台程序ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出后台服务程序ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全部退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtendsCMS = New Sunny.UI.UIContextMenuStrip()
        Me.置顶本窗口ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于本程序ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pcg_cfg.SuspendLayout()
        Me.pcg_settings.SuspendLayout()
        Me.pcg_set.SuspendLayout()
        Me.ManualMode_pcfg.SuspendLayout()
        Me.OtherGroup_Pcfg.SuspendLayout()
        Me.TaskBarMenu_CMS.SuspendLayout()
        Me.ExtendsCMS.SuspendLayout()
        Me.SuspendLayout()
        '
        'RAM_Size
        '
        resources.ApplyResources(Me.RAM_Size, "RAM_Size")
        Me.RAM_Size.Name = "RAM_Size"
        Me.RAM_Size.Style = Sunny.UI.UIStyle.Custom
        '
        'RAM_Refresh
        '
        Me.RAM_Refresh.Enabled = True
        Me.RAM_Refresh.Interval = 800
        '
        'SetAppdefineClearing
        '
        Me.SetAppdefineClearing.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.SetAppdefineClearing, "SetAppdefineClearing")
        Me.SetAppdefineClearing.Name = "SetAppdefineClearing"
        Me.SetAppdefineClearing.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.SetAppdefineClearing.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.SetAppdefineClearing.Style = Sunny.UI.UIStyle.Custom
        '
        'CPU_Size
        '
        resources.ApplyResources(Me.CPU_Size, "CPU_Size")
        Me.CPU_Size.Name = "CPU_Size"
        Me.CPU_Size.Style = Sunny.UI.UIStyle.Custom
        '
        'CPU_Refresh
        '
        Me.CPU_Refresh.Enabled = True
        Me.CPU_Refresh.Interval = 800
        '
        'Performance_low
        '
        Me.Performance_low.BackColor = System.Drawing.Color.Transparent
        Me.Performance_low.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Performance_low, "Performance_low")
        Me.Performance_low.Name = "Performance_low"
        Me.Performance_low.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Performance_low.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Performance_low.Style = Sunny.UI.UIStyle.Custom
        '
        'pcg_cfg
        '
        Me.pcg_cfg.BackColor = System.Drawing.Color.Transparent
        Me.pcg_cfg.Controls.Add(Me.Performance_highest)
        Me.pcg_cfg.Controls.Add(Me.Performance_high)
        Me.pcg_cfg.Controls.Add(Me.Performance_auto)
        Me.pcg_cfg.Controls.Add(Me.Performance_low)
        Me.pcg_cfg.FillColor = System.Drawing.Color.Transparent
        Me.pcg_cfg.FillDisableColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.pcg_cfg, "pcg_cfg")
        Me.pcg_cfg.Name = "pcg_cfg"
        Me.pcg_cfg.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.pcg_cfg.RectColor = System.Drawing.Color.DodgerBlue
        Me.pcg_cfg.Style = Sunny.UI.UIStyle.Custom
        Me.pcg_cfg.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Performance_highest
        '
        Me.Performance_highest.BackColor = System.Drawing.Color.Transparent
        Me.Performance_highest.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Performance_highest, "Performance_highest")
        Me.Performance_highest.Name = "Performance_highest"
        Me.Performance_highest.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Performance_highest.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Performance_highest.Style = Sunny.UI.UIStyle.Custom
        '
        'Performance_high
        '
        Me.Performance_high.BackColor = System.Drawing.Color.Transparent
        Me.Performance_high.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Performance_high, "Performance_high")
        Me.Performance_high.Name = "Performance_high"
        Me.Performance_high.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Performance_high.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Performance_high.Style = Sunny.UI.UIStyle.Custom
        '
        'Performance_auto
        '
        Me.Performance_auto.BackColor = System.Drawing.Color.Transparent
        Me.Performance_auto.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Performance_auto, "Performance_auto")
        Me.Performance_auto.Name = "Performance_auto"
        Me.Performance_auto.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Performance_auto.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Performance_auto.Style = Sunny.UI.UIStyle.Custom
        '
        'pcg_settings
        '
        Me.pcg_settings.BackColor = System.Drawing.Color.Transparent
        Me.pcg_settings.Controls.Add(Me.SetAutoTime)
        Me.pcg_settings.Controls.Add(Me.Auto_Time_lable)
        Me.pcg_settings.Controls.Add(Me.SetVirtualRAMCheckBtn)
        Me.pcg_settings.Controls.Add(Me.VirtualRAM_MAX_SIZE)
        Me.pcg_settings.Controls.Add(Me.LABLE_MAX)
        Me.pcg_settings.Controls.Add(Me.LABLE_MIN)
        Me.pcg_settings.Controls.Add(Me.SetAppdefineClearing)
        Me.pcg_settings.Controls.Add(Me.VirtualRAM_MIN_SIZE)
        Me.pcg_settings.Controls.Add(Me.UseVirtualMemoryCheckBtn)
        Me.pcg_settings.Controls.Add(Me.ClearLoopMemoryCheckBtn)
        Me.pcg_settings.Controls.Add(Me.EnableGlobalGPUCheckBth)
        Me.pcg_settings.FillColor = System.Drawing.Color.Transparent
        Me.pcg_settings.FillDisableColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.pcg_settings, "pcg_settings")
        Me.pcg_settings.Name = "pcg_settings"
        Me.pcg_settings.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.pcg_settings.RectColor = System.Drawing.Color.DodgerBlue
        Me.pcg_settings.Style = Sunny.UI.UIStyle.Custom
        Me.pcg_settings.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SetAutoTime
        '
        Me.SetAutoTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SetAutoTime.DecLength = 0
        Me.SetAutoTime.DoubleValue = 180.0R
        Me.SetAutoTime.FillColor = System.Drawing.Color.White
        resources.ApplyResources(Me.SetAutoTime, "SetAutoTime")
        Me.SetAutoTime.HasMaximum = True
        Me.SetAutoTime.HasMinimum = True
        Me.SetAutoTime.IntValue = 180
        Me.SetAutoTime.Maximum = 2147483647.0R
        Me.SetAutoTime.MaximumEnabled = True
        Me.SetAutoTime.MaxLength = 10
        Me.SetAutoTime.Minimum = 1.0R
        Me.SetAutoTime.MinimumEnabled = True
        Me.SetAutoTime.Name = "SetAutoTime"
        Me.SetAutoTime.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.SetAutoTime.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.SetAutoTime.Style = Sunny.UI.UIStyle.Custom
        Me.SetAutoTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.SetAutoTime.Type = Sunny.UI.UITextBox.UIEditType.[Integer]
        '
        'Auto_Time_lable
        '
        resources.ApplyResources(Me.Auto_Time_lable, "Auto_Time_lable")
        Me.Auto_Time_lable.Name = "Auto_Time_lable"
        Me.Auto_Time_lable.Style = Sunny.UI.UIStyle.Custom
        '
        'SetVirtualRAMCheckBtn
        '
        Me.SetVirtualRAMCheckBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.SetVirtualRAMCheckBtn, "SetVirtualRAMCheckBtn")
        Me.SetVirtualRAMCheckBtn.Name = "SetVirtualRAMCheckBtn"
        Me.SetVirtualRAMCheckBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.SetVirtualRAMCheckBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.SetVirtualRAMCheckBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'VirtualRAM_MAX_SIZE
        '
        Me.VirtualRAM_MAX_SIZE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.VirtualRAM_MAX_SIZE.DecLength = 0
        Me.VirtualRAM_MAX_SIZE.DoubleValue = 12288.0R
        resources.ApplyResources(Me.VirtualRAM_MAX_SIZE, "VirtualRAM_MAX_SIZE")
        Me.VirtualRAM_MAX_SIZE.FillColor = System.Drawing.Color.White
        Me.VirtualRAM_MAX_SIZE.HasMaximum = True
        Me.VirtualRAM_MAX_SIZE.HasMinimum = True
        Me.VirtualRAM_MAX_SIZE.IntValue = 12288
        Me.VirtualRAM_MAX_SIZE.Maximum = 2147483647.0R
        Me.VirtualRAM_MAX_SIZE.MaximumEnabled = True
        Me.VirtualRAM_MAX_SIZE.MaxLength = 32
        Me.VirtualRAM_MAX_SIZE.Minimum = 1024.0R
        Me.VirtualRAM_MAX_SIZE.MinimumEnabled = True
        Me.VirtualRAM_MAX_SIZE.Name = "VirtualRAM_MAX_SIZE"
        Me.VirtualRAM_MAX_SIZE.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.VirtualRAM_MAX_SIZE.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.VirtualRAM_MAX_SIZE.Style = Sunny.UI.UIStyle.Custom
        Me.VirtualRAM_MAX_SIZE.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.VirtualRAM_MAX_SIZE.Type = Sunny.UI.UITextBox.UIEditType.[Integer]
        '
        'LABLE_MAX
        '
        resources.ApplyResources(Me.LABLE_MAX, "LABLE_MAX")
        Me.LABLE_MAX.Name = "LABLE_MAX"
        Me.LABLE_MAX.Style = Sunny.UI.UIStyle.Custom
        '
        'LABLE_MIN
        '
        resources.ApplyResources(Me.LABLE_MIN, "LABLE_MIN")
        Me.LABLE_MIN.Name = "LABLE_MIN"
        Me.LABLE_MIN.Style = Sunny.UI.UIStyle.Custom
        '
        'VirtualRAM_MIN_SIZE
        '
        Me.VirtualRAM_MIN_SIZE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.VirtualRAM_MIN_SIZE.DecLength = 0
        Me.VirtualRAM_MIN_SIZE.DoubleValue = 1024.0R
        resources.ApplyResources(Me.VirtualRAM_MIN_SIZE, "VirtualRAM_MIN_SIZE")
        Me.VirtualRAM_MIN_SIZE.FillColor = System.Drawing.Color.White
        Me.VirtualRAM_MIN_SIZE.HasMaximum = True
        Me.VirtualRAM_MIN_SIZE.HasMinimum = True
        Me.VirtualRAM_MIN_SIZE.IntValue = 1024
        Me.VirtualRAM_MIN_SIZE.Maximum = 2147483647.0R
        Me.VirtualRAM_MIN_SIZE.MaximumEnabled = True
        Me.VirtualRAM_MIN_SIZE.MaxLength = 32
        Me.VirtualRAM_MIN_SIZE.Minimum = 1024.0R
        Me.VirtualRAM_MIN_SIZE.MinimumEnabled = True
        Me.VirtualRAM_MIN_SIZE.Name = "VirtualRAM_MIN_SIZE"
        Me.VirtualRAM_MIN_SIZE.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.VirtualRAM_MIN_SIZE.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.VirtualRAM_MIN_SIZE.Style = Sunny.UI.UIStyle.Custom
        Me.VirtualRAM_MIN_SIZE.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.VirtualRAM_MIN_SIZE.Type = Sunny.UI.UITextBox.UIEditType.[Integer]
        '
        'UseVirtualMemoryCheckBtn
        '
        Me.UseVirtualMemoryCheckBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.UseVirtualMemoryCheckBtn, "UseVirtualMemoryCheckBtn")
        Me.UseVirtualMemoryCheckBtn.Name = "UseVirtualMemoryCheckBtn"
        Me.UseVirtualMemoryCheckBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.UseVirtualMemoryCheckBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.UseVirtualMemoryCheckBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'ClearLoopMemoryCheckBtn
        '
        Me.ClearLoopMemoryCheckBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.ClearLoopMemoryCheckBtn, "ClearLoopMemoryCheckBtn")
        Me.ClearLoopMemoryCheckBtn.Name = "ClearLoopMemoryCheckBtn"
        Me.ClearLoopMemoryCheckBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.ClearLoopMemoryCheckBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.ClearLoopMemoryCheckBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'EnableGlobalGPUCheckBth
        '
        Me.EnableGlobalGPUCheckBth.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.EnableGlobalGPUCheckBth, "EnableGlobalGPUCheckBth")
        Me.EnableGlobalGPUCheckBth.Name = "EnableGlobalGPUCheckBth"
        Me.EnableGlobalGPUCheckBth.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.EnableGlobalGPUCheckBth.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.EnableGlobalGPUCheckBth.Style = Sunny.UI.UIStyle.Custom
        '
        'pcg_set
        '
        Me.pcg_set.BackColor = System.Drawing.Color.Transparent
        Me.pcg_set.Controls.Add(Me.RAM_Size)
        Me.pcg_set.Controls.Add(Me.CPU_Size)
        Me.pcg_set.FillColor = System.Drawing.Color.Transparent
        Me.pcg_set.FillDisableColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.pcg_set, "pcg_set")
        Me.pcg_set.Name = "pcg_set"
        Me.pcg_set.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.pcg_set.RectColor = System.Drawing.Color.DodgerBlue
        Me.pcg_set.Style = Sunny.UI.UIStyle.Custom
        Me.pcg_set.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UiTextBox1
        '
        Me.UiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.UiTextBox1.DecLength = 0
        Me.UiTextBox1.DoubleValue = 1024.0R
        Me.UiTextBox1.FillColor = System.Drawing.Color.White
        resources.ApplyResources(Me.UiTextBox1, "UiTextBox1")
        Me.UiTextBox1.IntValue = 1024
        Me.UiTextBox1.Maximum = 2147483647.0R
        Me.UiTextBox1.Minimum = 1024.0R
        Me.UiTextBox1.Name = "UiTextBox1"
        Me.UiTextBox1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.UiTextBox1.RectColor = System.Drawing.Color.DodgerBlue
        Me.UiTextBox1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.UiTextBox1.Style = Sunny.UI.UIStyle.Custom
        Me.UiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.UiTextBox1.Type = Sunny.UI.UITextBox.UIEditType.[Integer]
        '
        'UiTextBox2
        '
        Me.UiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.UiTextBox2.DecLength = 0
        Me.UiTextBox2.DoubleValue = 1024.0R
        Me.UiTextBox2.FillColor = System.Drawing.Color.White
        resources.ApplyResources(Me.UiTextBox2, "UiTextBox2")
        Me.UiTextBox2.IntValue = 1024
        Me.UiTextBox2.Maximum = 2147483647.0R
        Me.UiTextBox2.Minimum = 1024.0R
        Me.UiTextBox2.Name = "UiTextBox2"
        Me.UiTextBox2.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.UiTextBox2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.UiTextBox2.Style = Sunny.UI.UIStyle.Custom
        Me.UiTextBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.UiTextBox2.Type = Sunny.UI.UITextBox.UIEditType.[Integer]
        '
        'DISM_CLEAR_CheckBtn
        '
        Me.DISM_CLEAR_CheckBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.DISM_CLEAR_CheckBtn, "DISM_CLEAR_CheckBtn")
        Me.DISM_CLEAR_CheckBtn.Name = "DISM_CLEAR_CheckBtn"
        Me.DISM_CLEAR_CheckBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.DISM_CLEAR_CheckBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DISM_CLEAR_CheckBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'ManualMode_pcfg
        '
        Me.ManualMode_pcfg.BackColor = System.Drawing.Color.Transparent
        Me.ManualMode_pcfg.Controls.Add(Me.SetMeProtect)
        Me.ManualMode_pcfg.Controls.Add(Me.RestartSysProc)
        Me.ManualMode_pcfg.Controls.Add(Me.ApplyForeCtrlBtn)
        Me.ManualMode_pcfg.Controls.Add(Me.MyClearSrv)
        Me.ManualMode_pcfg.Controls.Add(Me.HiberSleep)
        Me.ManualMode_pcfg.Controls.Add(Me.Fastboot)
        Me.ManualMode_pcfg.Controls.Add(Me.SrvListControl)
        Me.ManualMode_pcfg.Controls.Add(Me.RegClear)
        Me.ManualMode_pcfg.Controls.Add(Me.DeletedOldWindowsCheckBtn)
        Me.ManualMode_pcfg.Controls.Add(Me.DeletedWindowsBT_WS_CheckBtn)
        Me.ManualMode_pcfg.Controls.Add(Me.Deleted_Prefiles_CheckedBtn)
        Me.ManualMode_pcfg.Controls.Add(Me.DISM_CLEAR_CheckBtn)
        Me.ManualMode_pcfg.FillColor = System.Drawing.Color.Transparent
        Me.ManualMode_pcfg.FillDisableColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.ManualMode_pcfg, "ManualMode_pcfg")
        Me.ManualMode_pcfg.Name = "ManualMode_pcfg"
        Me.ManualMode_pcfg.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.ManualMode_pcfg.RectColor = System.Drawing.Color.DodgerBlue
        Me.ManualMode_pcfg.Style = Sunny.UI.UIStyle.Custom
        Me.ManualMode_pcfg.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SetMeProtect
        '
        Me.SetMeProtect.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.SetMeProtect, "SetMeProtect")
        Me.SetMeProtect.Name = "SetMeProtect"
        Me.SetMeProtect.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.SetMeProtect.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.SetMeProtect.Style = Sunny.UI.UIStyle.Custom
        '
        'RestartSysProc
        '
        Me.RestartSysProc.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.RestartSysProc, "RestartSysProc")
        Me.RestartSysProc.Name = "RestartSysProc"
        Me.RestartSysProc.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.RestartSysProc.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.RestartSysProc.Style = Sunny.UI.UIStyle.Custom
        '
        'ApplyForeCtrlBtn
        '
        Me.ApplyForeCtrlBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.ApplyForeCtrlBtn, "ApplyForeCtrlBtn")
        Me.ApplyForeCtrlBtn.Name = "ApplyForeCtrlBtn"
        Me.ApplyForeCtrlBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.ApplyForeCtrlBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.ApplyForeCtrlBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'MyClearSrv
        '
        Me.MyClearSrv.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.MyClearSrv, "MyClearSrv")
        Me.MyClearSrv.Name = "MyClearSrv"
        Me.MyClearSrv.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.MyClearSrv.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.MyClearSrv.Style = Sunny.UI.UIStyle.Custom
        '
        'HiberSleep
        '
        Me.HiberSleep.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.HiberSleep, "HiberSleep")
        Me.HiberSleep.Name = "HiberSleep"
        Me.HiberSleep.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.HiberSleep.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.HiberSleep.Style = Sunny.UI.UIStyle.Custom
        '
        'Fastboot
        '
        Me.Fastboot.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.Fastboot, "Fastboot")
        Me.Fastboot.Name = "Fastboot"
        Me.Fastboot.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Fastboot.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Fastboot.Style = Sunny.UI.UIStyle.Custom
        '
        'SrvListControl
        '
        Me.SrvListControl.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.SrvListControl, "SrvListControl")
        Me.SrvListControl.Name = "SrvListControl"
        Me.SrvListControl.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.SrvListControl.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.SrvListControl.Style = Sunny.UI.UIStyle.Custom
        '
        'RegClear
        '
        Me.RegClear.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.RegClear, "RegClear")
        Me.RegClear.Name = "RegClear"
        Me.RegClear.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.RegClear.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.RegClear.Style = Sunny.UI.UIStyle.Custom
        '
        'DeletedOldWindowsCheckBtn
        '
        Me.DeletedOldWindowsCheckBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.DeletedOldWindowsCheckBtn, "DeletedOldWindowsCheckBtn")
        Me.DeletedOldWindowsCheckBtn.Name = "DeletedOldWindowsCheckBtn"
        Me.DeletedOldWindowsCheckBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.DeletedOldWindowsCheckBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DeletedOldWindowsCheckBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'DeletedWindowsBT_WS_CheckBtn
        '
        Me.DeletedWindowsBT_WS_CheckBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.DeletedWindowsBT_WS_CheckBtn, "DeletedWindowsBT_WS_CheckBtn")
        Me.DeletedWindowsBT_WS_CheckBtn.Name = "DeletedWindowsBT_WS_CheckBtn"
        Me.DeletedWindowsBT_WS_CheckBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.DeletedWindowsBT_WS_CheckBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DeletedWindowsBT_WS_CheckBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'Deleted_Prefiles_CheckedBtn
        '
        Me.Deleted_Prefiles_CheckedBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.Deleted_Prefiles_CheckedBtn, "Deleted_Prefiles_CheckedBtn")
        Me.Deleted_Prefiles_CheckedBtn.Name = "Deleted_Prefiles_CheckedBtn"
        Me.Deleted_Prefiles_CheckedBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Deleted_Prefiles_CheckedBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Deleted_Prefiles_CheckedBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'OtherGroup_Pcfg
        '
        Me.OtherGroup_Pcfg.BackColor = System.Drawing.Color.Transparent
        Me.OtherGroup_Pcfg.Controls.Add(Me.AutoKillProc_ByList)
        Me.OtherGroup_Pcfg.Controls.Add(Me.Process_Kill_ListBox)
        Me.OtherGroup_Pcfg.FillColor = System.Drawing.Color.Transparent
        Me.OtherGroup_Pcfg.FillDisableColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.OtherGroup_Pcfg, "OtherGroup_Pcfg")
        Me.OtherGroup_Pcfg.Name = "OtherGroup_Pcfg"
        Me.OtherGroup_Pcfg.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.OtherGroup_Pcfg.RectColor = System.Drawing.Color.DodgerBlue
        Me.OtherGroup_Pcfg.Style = Sunny.UI.UIStyle.Custom
        Me.OtherGroup_Pcfg.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AutoKillProc_ByList
        '
        Me.AutoKillProc_ByList.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.AutoKillProc_ByList, "AutoKillProc_ByList")
        Me.AutoKillProc_ByList.Name = "AutoKillProc_ByList"
        Me.AutoKillProc_ByList.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.AutoKillProc_ByList.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.AutoKillProc_ByList.Style = Sunny.UI.UIStyle.Custom
        '
        'Process_Kill_ListBox
        '
        Me.Process_Kill_ListBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Process_Kill_ListBox.DecLength = 0
        Me.Process_Kill_ListBox.FillColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Process_Kill_ListBox, "Process_Kill_ListBox")
        Me.Process_Kill_ListBox.Maximum = 2147483647.0R
        Me.Process_Kill_ListBox.MaxLength = 2147483647
        Me.Process_Kill_ListBox.Minimum = 0R
        Me.Process_Kill_ListBox.Multiline = True
        Me.Process_Kill_ListBox.Name = "Process_Kill_ListBox"
        Me.Process_Kill_ListBox.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Process_Kill_ListBox.ShowScrollBar = True
        Me.Process_Kill_ListBox.Style = Sunny.UI.UIStyle.Custom
        Me.Process_Kill_ListBox.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.Process_Kill_ListBox.Watermark = "每行输入进程名称，不带 .exe后缀，同时请勿填写已经默认在自定义选项中的进程，否则可能会导致无法启动改程序"
        '
        'WindowsInformation_Texts
        '
        Me.WindowsInformation_Texts.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.WindowsInformation_Texts.DecLength = 0
        resources.ApplyResources(Me.WindowsInformation_Texts, "WindowsInformation_Texts")
        Me.WindowsInformation_Texts.FillColor = System.Drawing.Color.White
        Me.WindowsInformation_Texts.Maximum = 2147483647.0R
        Me.WindowsInformation_Texts.MaxLength = 2147483647
        Me.WindowsInformation_Texts.Minimum = 1024.0R
        Me.WindowsInformation_Texts.Multiline = True
        Me.WindowsInformation_Texts.Name = "WindowsInformation_Texts"
        Me.WindowsInformation_Texts.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.WindowsInformation_Texts.ReadOnly = True
        Me.WindowsInformation_Texts.ShowScrollBar = True
        Me.WindowsInformation_Texts.Style = Sunny.UI.UIStyle.Custom
        Me.WindowsInformation_Texts.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TaskBarMenu
        '
        Me.TaskBarMenu.ContextMenuStrip = Me.TaskBarMenu_CMS
        resources.ApplyResources(Me.TaskBarMenu, "TaskBarMenu")
        '
        'TaskBarMenu_CMS
        '
        Me.TaskBarMenu_CMS.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.TaskBarMenu_CMS, "TaskBarMenu_CMS")
        Me.TaskBarMenu_CMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.退出前台程序ToolStripMenuItem, Me.退出后台服务程序ToolStripMenuItem, Me.全部退出ToolStripMenuItem})
        Me.TaskBarMenu_CMS.Name = "TaskBarMenu_CMS"
        Me.TaskBarMenu_CMS.ShowImageMargin = False
        '
        '退出前台程序ToolStripMenuItem
        '
        Me.退出前台程序ToolStripMenuItem.Name = "退出前台程序ToolStripMenuItem"
        resources.ApplyResources(Me.退出前台程序ToolStripMenuItem, "退出前台程序ToolStripMenuItem")
        '
        '退出后台服务程序ToolStripMenuItem
        '
        Me.退出后台服务程序ToolStripMenuItem.Name = "退出后台服务程序ToolStripMenuItem"
        resources.ApplyResources(Me.退出后台服务程序ToolStripMenuItem, "退出后台服务程序ToolStripMenuItem")
        '
        '全部退出ToolStripMenuItem
        '
        Me.全部退出ToolStripMenuItem.Name = "全部退出ToolStripMenuItem"
        resources.ApplyResources(Me.全部退出ToolStripMenuItem, "全部退出ToolStripMenuItem")
        '
        'ExtendsCMS
        '
        Me.ExtendsCMS.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.ExtendsCMS, "ExtendsCMS")
        Me.ExtendsCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.置顶本窗口ToolStripMenuItem, Me.关于本程序ToolStripMenuItem})
        Me.ExtendsCMS.Name = "ExtendsCMS"
        Me.ExtendsCMS.ShowImageMargin = False
        Me.ExtendsCMS.Style = Sunny.UI.UIStyle.Custom
        '
        '置顶本窗口ToolStripMenuItem
        '
        Me.置顶本窗口ToolStripMenuItem.Name = "置顶本窗口ToolStripMenuItem"
        resources.ApplyResources(Me.置顶本窗口ToolStripMenuItem, "置顶本窗口ToolStripMenuItem")
        '
        '关于本程序ToolStripMenuItem
        '
        Me.关于本程序ToolStripMenuItem.Name = "关于本程序ToolStripMenuItem"
        resources.ApplyResources(Me.关于本程序ToolStripMenuItem, "关于本程序ToolStripMenuItem")
        '
        'MainWindow
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.WindowsInformation_Texts)
        Me.Controls.Add(Me.OtherGroup_Pcfg)
        Me.Controls.Add(Me.ManualMode_pcfg)
        Me.Controls.Add(Me.pcg_set)
        Me.Controls.Add(Me.pcg_settings)
        Me.Controls.Add(Me.pcg_cfg)
        Me.EscClose = True
        Me.ExtendBox = True
        Me.ExtendMenu = Me.ExtendsCMS
        Me.IsForbidAltF4 = True
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.Opacity = 0.96R
        Me.RectColor = System.Drawing.Color.DodgerBlue
        Me.ShowRadius = False
        Me.ShowRect = False
        Me.ShowShadow = True
        Me.Style = Sunny.UI.UIStyle.Custom
        Me.TitleColor = System.Drawing.Color.DodgerBlue
        Me.TitleHeight = 31
        Me.pcg_cfg.ResumeLayout(False)
        Me.pcg_settings.ResumeLayout(False)
        Me.pcg_settings.PerformLayout()
        Me.pcg_set.ResumeLayout(False)
        Me.pcg_set.PerformLayout()
        Me.ManualMode_pcfg.ResumeLayout(False)
        Me.OtherGroup_Pcfg.ResumeLayout(False)
        Me.TaskBarMenu_CMS.ResumeLayout(False)
        Me.ExtendsCMS.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RAM_Size As UILabel
    Friend WithEvents RAM_Refresh As Windows.Forms.Timer
    Friend WithEvents SetAppdefineClearing As UIButton
    Friend WithEvents CPU_Size As UILabel
    Friend WithEvents CPU_Refresh As Windows.Forms.Timer
    Friend WithEvents Performance_low As UIRadioButton
    Friend WithEvents pcg_cfg As UIGroupBox
    Friend WithEvents Performance_highest As UIRadioButton
    Friend WithEvents Performance_high As UIRadioButton
    Friend WithEvents Performance_auto As UIRadioButton
    Friend WithEvents pcg_settings As UIGroupBox
    Friend WithEvents pcg_set As UIGroupBox
    Friend WithEvents EnableGlobalGPUCheckBth As UICheckBox
    Friend WithEvents UseVirtualMemoryCheckBtn As UICheckBox
    Friend WithEvents ClearLoopMemoryCheckBtn As UICheckBox
    Friend WithEvents VirtualRAM_MIN_SIZE As UITextBox
    Friend WithEvents LABLE_MAX As UILabel
    Friend WithEvents LABLE_MIN As UILabel
    Friend WithEvents UiTextBox1 As UITextBox
    Friend WithEvents UiTextBox2 As UITextBox
    Friend WithEvents VirtualRAM_MAX_SIZE As UITextBox
    Friend WithEvents SetVirtualRAMCheckBtn As UICheckBox
    Friend WithEvents DISM_CLEAR_CheckBtn As UICheckBox
    Friend WithEvents ManualMode_pcfg As UIGroupBox
    Friend WithEvents OtherGroup_Pcfg As UIGroupBox
    Friend WithEvents WindowsInformation_Texts As UITextBox
    Friend WithEvents TaskBarMenu As NotifyIcon
    Friend WithEvents TaskBarMenu_CMS As UIContextMenuStrip
    Friend WithEvents 退出前台程序ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 退出后台服务程序ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 全部退出ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetAutoTime As UITextBox
    Friend WithEvents Auto_Time_lable As UILabel
    Friend WithEvents Deleted_Prefiles_CheckedBtn As UICheckBox
    Friend WithEvents DeletedOldWindowsCheckBtn As UICheckBox
    Friend WithEvents DeletedWindowsBT_WS_CheckBtn As UICheckBox
    Friend WithEvents Process_Kill_ListBox As UITextBox
    Friend WithEvents RegClear As UICheckBox
    Friend WithEvents Fastboot As UICheckBox
    Friend WithEvents SrvListControl As UICheckBox
    Friend WithEvents HiberSleep As UICheckBox
    Friend WithEvents MyClearSrv As UICheckBox
    Friend WithEvents ApplyForeCtrlBtn As UIButton
    Friend WithEvents AutoKillProc_ByList As UIButton
    Friend WithEvents RestartSysProc As UICheckBox
    Friend WithEvents SetMeProtect As UICheckBox
    Friend WithEvents ExtendsCMS As UIContextMenuStrip
    Friend WithEvents 置顶本窗口ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 关于本程序ToolStripMenuItem As ToolStripMenuItem
End Class
