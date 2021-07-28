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
        '要想保证启动单实例，又能游刃有余的启动第二个实例，可以看到App是在判断完是否为服务后创建的
        If Command().ToLower = "/startservice fastclear_run" Then
            ServiceBase.Run(New ServiceBase() {New ServicesRun.Service})
        Else
            Dim appHandle As New App '单实例所在，也就是说不创建之前都可以多开
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
