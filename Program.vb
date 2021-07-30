Imports Version = System.Version

Public Class Program
    Public Class App
        Inherits WindowsFormsApplicationBase

        Public Sub New()
            IsSingleInstance = True
            EnableVisualStyles = True
            ShutdownStyle = ShutdownMode.AfterMainFormCloses
        End Sub

        Protected Overrides Sub OnCreateMainForm()
            MainForm = New MainWindow
        End Sub
    End Class
    Public Shared Function GetOSVersion() As Version
        Return Environment.OSVersion.Version
    End Function
    Public Shared Sub GetToken() ' 提权操作
        On Error Resume Next
        Dim priv As New PrivilegeEnabler(Process.GetCurrentProcess)
        For privileges As Privilege = 0 To 34
            priv.EnablePrivilege(privileges)
        Next
    End Sub
    Public Shared Sub Main(args As String())
        On Error Resume Next

        AddHandler Application.ThreadException, AddressOf Application_ThreadException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
        GetToken()
        If File.Exists(Application.StartupPath + "\appConfig.json") = False Then
            MsgBox("配置文件丢失，请重新下载本程序全部文件！", MsgBoxStyle.MsgBoxSetForeground + MsgBoxStyle.Critical, "FastClear")
            Application.Exit()
        End If
        ConfigHelper.ReloadCfg()
        '要想保证启动单实例，又能游刃有余的启动第二个实例，可以看到App是在判断完是否为服务后创建的
        If Command().ToLower = "/startservice fastclear_run" Then
            ServiceBase.Run(New ServiceBase() {New ServicesRun.Service})

        Else
            Dim License As String = ""
            If File.Exists("License") Then
                License = File.ReadAllText("License", Encoding.UTF8)
            End If
            If License.ToUpper <> "MIT_LICENSE_USING_FOR_USER" Then
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
                msg.AppendLine("7.安装自签发CA证书")
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
                Dim ask_result = MainWindow.ShowAskDialog("FastClear | 警告！请仔细阅读本软件使用须知！", msg.ToString, UIStyle.Red, True)
                If ask_result = False Then
                    Application.Exit()
                Else
                    File.WriteAllText("License", "MIT_LICENSE_USING_FOR_USER", Encoding.UTF8)
                End If
                ask_result = MainWindow.ShowAskDialog("FastClear | 需要安装系统服务", "由于本程序依赖于内置的服务，需要安装才能稳定运行，此行为对于杀毒软件属于高危操作，请暂时退出并在安装后添加本程序白名单，如果你不希望将服务安装到当前运行目录，请选择取消，复制到 如C:\Program Files或指定目录，再运行安装", UIStyle.Orange, False)
                If ask_result = False Then
                    Application.Exit()
                Else
                    Dim Mysrv As New ServicesRun.MyInstaller
                    ServicesRun.ServiceHelper.ConfigService(Mysrv, True, " /StartService fastclear_run")
                End If
            End If
            Dim appHandle As New App '单实例所在，也就是说不创建之前都可以多开
            ' Control.CheckForIllegalCrossThreadCalls = False
            appHandle.Run(args)
        End If
    End Sub

    Private Shared Sub CurrentDomain_UnhandledException(sender As Object, e As System.UnhandledExceptionEventArgs)
        On Error Resume Next
        'Dim ex As Exception = TryCast(e.ExceptionObject, Exception)
        'MessageBox.Show(String.Format("捕获到未处理异常：{0}" & vbCrLf & "异常信息：{1}" & vbCrLf & "异常堆栈：{2}" & vbCrLf & "CLR即将退出：{3}", ex.[GetType](), ex.Message, ex.StackTrace, e.IsTerminating))
    End Sub

    Private Shared Sub Application_ThreadException(sender As Object, e As System.Threading.ThreadExceptionEventArgs)
        On Error Resume Next
        'Dim ex As Exception = e.Exception
        'MessageBox.Show(String.Format("捕获到未处理异常：{0}" & vbCrLf & "异常信息：{1}" & vbCrLf & "异常堆栈：{2}", ex.[GetType](), ex.Message, ex.StackTrace))
    End Sub
End Class
