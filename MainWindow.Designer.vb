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
        Me.ClearRAMBtn = New Sunny.UI.UIButton()
        Me.CPU_Size = New Sunny.UI.UILabel()
        Me.CPU_Refresh = New System.Windows.Forms.Timer(Me.components)
        Me.Performance_low = New Sunny.UI.UIRadioButton()
        Me.UiGroupBox1 = New Sunny.UI.UIGroupBox()
        Me.Performance_auto = New Sunny.UI.UIRadioButton()
        Me.Performance_high = New Sunny.UI.UIRadioButton()
        Me.Performance_highest = New Sunny.UI.UIRadioButton()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RAM_Size
        '
        resources.ApplyResources(Me.RAM_Size, "RAM_Size")
        Me.RAM_Size.ForeColor = System.Drawing.Color.Green
        Me.RAM_Size.Name = "RAM_Size"
        Me.RAM_Size.Style = Sunny.UI.UIStyle.Custom
        '
        'RAM_Refresh
        '
        Me.RAM_Refresh.Enabled = True
        Me.RAM_Refresh.Interval = 800
        '
        'ClearRAMBtn
        '
        Me.ClearRAMBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ClearRAMBtn.FillColor = System.Drawing.Color.DodgerBlue
        resources.ApplyResources(Me.ClearRAMBtn, "ClearRAMBtn")
        Me.ClearRAMBtn.Name = "ClearRAMBtn"
        Me.ClearRAMBtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.ClearRAMBtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.ClearRAMBtn.Style = Sunny.UI.UIStyle.Custom
        '
        'CPU_Size
        '
        resources.ApplyResources(Me.CPU_Size, "CPU_Size")
        Me.CPU_Size.ForeColor = System.Drawing.Color.Green
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
        Me.Performance_low.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.Performance_low, "Performance_low")
        Me.Performance_low.Name = "Performance_low"
        Me.Performance_low.RadioButtonColor = System.Drawing.Color.DodgerBlue
        Me.Performance_low.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Performance_low.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Performance_low.Style = Sunny.UI.UIStyle.Custom
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.Performance_highest)
        Me.UiGroupBox1.Controls.Add(Me.Performance_high)
        Me.UiGroupBox1.Controls.Add(Me.Performance_auto)
        Me.UiGroupBox1.Controls.Add(Me.Performance_low)
        Me.UiGroupBox1.FillColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.FillDisableColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.UiGroupBox1, "UiGroupBox1")
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.UiGroupBox1.RectColor = System.Drawing.Color.DodgerBlue
        Me.UiGroupBox1.Style = Sunny.UI.UIStyle.Custom
        Me.UiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Performance_auto
        '
        Me.Performance_auto.BackColor = System.Drawing.Color.Transparent
        Me.Performance_auto.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.Performance_auto, "Performance_auto")
        Me.Performance_auto.Name = "Performance_auto"
        Me.Performance_auto.RadioButtonColor = System.Drawing.Color.DodgerBlue
        Me.Performance_auto.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Performance_auto.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Performance_auto.Style = Sunny.UI.UIStyle.Custom
        '
        'Performance_high
        '
        Me.Performance_high.BackColor = System.Drawing.Color.Transparent
        Me.Performance_high.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.Performance_high, "Performance_high")
        Me.Performance_high.Name = "Performance_high"
        Me.Performance_high.RadioButtonColor = System.Drawing.Color.DodgerBlue
        Me.Performance_high.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Performance_high.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Performance_high.Style = Sunny.UI.UIStyle.Custom
        '
        'Performance_highest
        '
        Me.Performance_highest.BackColor = System.Drawing.Color.Transparent
        Me.Performance_highest.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.Performance_highest, "Performance_highest")
        Me.Performance_highest.Name = "Performance_highest"
        Me.Performance_highest.RadioButtonColor = System.Drawing.Color.DodgerBlue
        Me.Performance_highest.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Performance_highest.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Performance_highest.Style = Sunny.UI.UIStyle.Custom
        '
        'MainWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.CPU_Size)
        Me.Controls.Add(Me.ClearRAMBtn)
        Me.Controls.Add(Me.RAM_Size)
        Me.EscClose = True
        Me.IsForbidAltF4 = True
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.RectColor = System.Drawing.Color.DodgerBlue
        Me.ShowRadius = False
        Me.ShowRect = False
        Me.ShowShadow = True
        Me.Style = Sunny.UI.UIStyle.Custom
        Me.TitleColor = System.Drawing.Color.DodgerBlue
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RAM_Size As UILabel
    Friend WithEvents RAM_Refresh As Windows.Forms.Timer
    Friend WithEvents ClearRAMBtn As UIButton
    Friend WithEvents CPU_Size As UILabel
    Friend WithEvents CPU_Refresh As Windows.Forms.Timer
    Friend WithEvents Performance_low As UIRadioButton
    Friend WithEvents UiGroupBox1 As UIGroupBox
    Friend WithEvents Performance_highest As UIRadioButton
    Friend WithEvents Performance_high As UIRadioButton
    Friend WithEvents Performance_auto As UIRadioButton
End Class
