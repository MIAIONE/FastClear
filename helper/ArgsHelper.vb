Public Class ArgsHelper
    Public Shared Function GetCommandLine() As IConfigurationRoot
        On Error Resume Next
        Dim commands As New ConsoleApplicationBase
        Dim list_param As New List(Of String)
        For Each everyparam As String In commands.CommandLineArgs
            list_param.Add(everyparam)
        Next
        Dim builder As ConfigurationBuilder = New ConfigurationBuilder()
        builder.AddCommandLine(list_param.ToArray)
        GC.Collect()
        Return builder.Build()
    End Function
    Public Shared Function GetParam(params As String) As String
        On Error Resume Next
        Dim iconfig As IConfigurationRoot = GetCommandLine()
        Return iconfig.Item(params)
    End Function
End Class
