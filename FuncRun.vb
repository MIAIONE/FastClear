Public Class FuncRun
    Public Shared Sub Run(files As String, cmd As String)
        On Error Resume Next
        Dim procs As New Process
        procs.StartInfo.FileName = files
        procs.StartInfo.Arguments = cmd
        procs.StartInfo.UseShellExecute = False
        procs.StartInfo.CreateNoWindow = True
        procs.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        procs.Start()
    End Sub
    Public Shared Function RunOutput(files As String, cmd As String) As String
        Return ConsoleApp.Run(files, cmd).Output
    End Function
    Public Shared Function GetTask(action As Action) As Task
        Return Task.Factory.StartNew(action)
    End Function
    Public ReadOnly Property MainProcess As New Process
    Public Sub RunWait(files As String, _command As String)
        On Error Resume Next
        MainProcess.StartInfo.FileName = files
        MainProcess.StartInfo.Arguments = _command
        MainProcess.StartInfo.UseShellExecute = False
        MainProcess.StartInfo.CreateNoWindow = True
        MainProcess.StartInfo.RedirectStandardOutput = True
        MainProcess.StartInfo.StandardOutputEncoding = Encoding.Default
        MainProcess.StartInfo.RedirectStandardError = False
        MainProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        MainProcess.Start()
        MainProcess.BeginOutputReadLine()
        MainProcess.WaitForExit()
    End Sub

End Class
