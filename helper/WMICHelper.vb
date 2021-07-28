Public Class WMICHelper
    Public Shared ReadOnly WMIC As String = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\wbem\WMIC.exe"
    Public Shared ReadOnly SetVirtualMemory As String = "PageFileSet Where Name=" + My.Resources.SChar + Path.GetPathRoot(WMIC) + "pagefile.sys" + My.Resources.SChar + " Set InitialSize={0},MaximumSize={1}"
    Public Shared ReadOnly CancelAutoSet As String = String.Format("ComputerSystem Where Name={0} Set AutomaticManagedPagefile=False", Environment.GetEnvironmentVariable("ComputerName", EnvironmentVariableTarget.Machine))
    Public Shared ReadOnly ResetAutoSet As String = String.Format("ComputerSystem Where Name={0} Set AutomaticManagedPagefile=True", Environment.GetEnvironmentVariable("ComputerName", EnvironmentVariableTarget.Machine))
    Public Shared Function RunWMIC(command As String) As Boolean
        Try
            FuncRun.Run(WMIC, command)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Sub SetVirtualRAM(min As UInteger, max As UInteger)
        RunWMIC(CancelAutoSet)
        RunWMIC(String.Format(SetVirtualMemory, min, max))
    End Sub
    Public Shared Sub ResetVirtualMemorys()
        RunWMIC(ResetAutoSet)
    End Sub
End Class
