Public Class Program
    Public Shared Sub Main(args As String())
        AddHandler Application.ThreadException, AddressOf Application_ThreadException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
        If Command().ToLower = "/startservice fastclear_run" Then
            ServiceBase.Run(New ServiceBase() {New ServicesRun.Service})
        Else
            Application.Run(New MainWindow)
        End If
    End Sub

    Private Shared Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As System.UnhandledExceptionEventArgs)
        On Error Resume Next
        'Dim ex As Exception = TryCast(e.ExceptionObject, Exception)
        'MessageBox.Show(String.Format("捕获到未处理异常：{0}" & vbCrLf & "异常信息：{1}" & vbCrLf & "异常堆栈：{2}" & vbCrLf & "CLR即将退出：{3}", ex.[GetType](), ex.Message, ex.StackTrace, e.IsTerminating))
    End Sub

    Private Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        On Error Resume Next
        'Dim ex As Exception = e.Exception
        'MessageBox.Show(String.Format("捕获到未处理异常：{0}" & vbCrLf & "异常信息：{1}" & vbCrLf & "异常堆栈：{2}", ex.[GetType](), ex.Message, ex.StackTrace))
    End Sub
End Class
