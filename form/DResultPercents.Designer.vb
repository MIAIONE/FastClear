<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DResultPercents
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DResultPercents))
        Me.Percents = New Sunny.UI.UIProcessBar()
        Me.DisposeDealyTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Messages = New Sunny.UI.UITextBox()
        Me.AutoPercentStep = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Percents
        '
        Me.Percents.BackColor = System.Drawing.Color.LightGray
        Me.Percents.DecimalCount = 1
        Me.Percents.FillColor = System.Drawing.Color.LightSkyBlue
        resources.ApplyResources(Me.Percents, "Percents")
        Me.Percents.ForeColor = System.Drawing.Color.Gray
        Me.Percents.Name = "Percents"
        Me.Percents.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Percents.RectColor = System.Drawing.Color.DodgerBlue
        Me.Percents.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.Percents.ShowValue = False
        Me.Percents.Style = Sunny.UI.UIStyle.Custom
        '
        'DisposeDealyTimer
        '
        Me.DisposeDealyTimer.Interval = 1000
        '
        'Messages
        '
        Me.Messages.Cursor = System.Windows.Forms.Cursors.Default
        Me.Messages.FillColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Messages, "Messages")
        Me.Messages.Maximum = 2147483647.0R
        Me.Messages.MaxLength = 2147483647
        Me.Messages.Minimum = -2147483648.0R
        Me.Messages.Multiline = True
        Me.Messages.Name = "Messages"
        Me.Messages.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        Me.Messages.ReadOnly = True
        Me.Messages.ShowScrollBar = True
        Me.Messages.Style = Sunny.UI.UIStyle.Custom
        Me.Messages.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'AutoPercentStep
        '
        Me.AutoPercentStep.Interval = 1
        '
        'DResultPercents
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me, "$this")
        Me.ControlBox = False
        Me.Controls.Add(Me.Messages)
        Me.Controls.Add(Me.Percents)
        Me.IsForbidAltF4 = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DResultPercents"
        Me.Opacity = 0.96R
        Me.RectColor = System.Drawing.Color.DodgerBlue
        Me.ShowInTaskbar = False
        Me.ShowRadius = False
        Me.ShowRect = False
        Me.ShowShadow = True
        Me.Style = Sunny.UI.UIStyle.Custom
        Me.TitleColor = System.Drawing.Color.DodgerBlue
        Me.TitleHeight = 31
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Percents As UIProcessBar
    Friend WithEvents DisposeDealyTimer As Windows.Forms.Timer
    Friend WithEvents Messages As UITextBox
    Friend WithEvents AutoPercentStep As Windows.Forms.Timer
End Class
