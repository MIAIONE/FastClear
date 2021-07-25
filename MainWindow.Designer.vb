<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits UIForm

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.RAM_Size = New Sunny.UI.UILabel()
        Me.RAM_Refresh = New System.Windows.Forms.Timer(Me.components)
        Me.ClearRAMBtn = New Sunny.UI.UIButton()
        Me.CPU_Size = New Sunny.UI.UILabel()
        Me.CPU_Refresh = New System.Windows.Forms.Timer(Me.components)
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
        'MainWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RAM_Size As UILabel
    Friend WithEvents RAM_Refresh As Windows.Forms.Timer
    Friend WithEvents ClearRAMBtn As UIButton
    Friend WithEvents CPU_Size As UILabel
    Friend WithEvents CPU_Refresh As Windows.Forms.Timer
End Class
