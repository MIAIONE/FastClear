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
End Class
