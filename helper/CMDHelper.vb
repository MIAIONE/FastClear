Public Class Dism
    Public Shared Property UpdatePercent As String
    Public Shared Function MidStrEx_New(sourse As String, startstr As String, endstr As String) As String
        Dim rg As Regex = New Regex("(?<=(" & startstr & "))[.\s\S]*?(?=(" & endstr & "))", RegexOptions.Multiline Or RegexOptions.Singleline)
        Return rg.Match(sourse).Value
    End Function
    Public Shared Sub Run(cmd As String)
        Dim procs As New Process
        procs.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\dism.exe"
        procs.StartInfo.Arguments = cmd
        procs.StartInfo.UseShellExecute = False
        procs.StartInfo.CreateNoWindow = True
        procs.StartInfo.RedirectStandardOutput = True
        procs.StartInfo.StandardOutputEncoding = Encoding.UTF8
        procs.StartInfo.RedirectStandardError = False
        AddHandler procs.OutputDataReceived, AddressOf Proc_OutputDataReceived
        procs.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        procs.Start()
        procs.BeginOutputReadLine()
    End Sub
    Private Shared Sub Proc_OutputDataReceived(sender As Object, e As DataReceivedEventArgs)
        Dim Oristr As String = MidStrEx_New(e.Data, "[", "]")
        Dim Percent As String = Regex.Replace(Oristr, "[^0-9]+", "")
        UpdatePercent = Percent
    End Sub
End Class
