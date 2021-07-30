Public Class DismHelper
    Public ReadOnly Property MainProcess As New Process
    Public Sub Run(dism_command As String)
        MainProcess.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\dism.exe"
        MainProcess.StartInfo.Arguments = dism_command
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
