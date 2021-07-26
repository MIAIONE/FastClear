Public Class ClearConst
    '----command
    Public Shared ReadOnly DISM_CLEAR_UPDATE_IMAGE As String = "/Online /Cleanup-Image /StartComponentCleanup /ResetBase"
    Public Shared ReadOnly POWERCFG_ACTIVE As String = "/SetActive "
    Public Shared ReadOnly GUID_EnergySaving As String = "a1841308-3541-4fab-bc81-f71556f20b4a"
    ''' <summary>
    ''' If the OS version is lower than Windows 10 (1803), the excellent performance cannot be turned on.
    ''' </summary>
    Public Shared ReadOnly GUID_ExcellentPerformance As String = "e9a42b02-d5df-448d-aa00-03f14749eb61"

    Public Shared ReadOnly GUID_HighPerformance As String = "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c"
    Public Shared ReadOnly GUID_Balanced As String = "381b4222-f694-41f0-9685-ff5bb260df2e"

    '----path
    Public Shared ReadOnly WINDOWS_ROOT_PATH As String = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
    Public Shared ReadOnly WINDOWS_BT_FILE As String = WINDOWS_ROOT_PATH + "\$WINDOWS.~BT\"
    Public Shared ReadOnly WINDOWS_WS_FILE As String = WINDOWS_ROOT_PATH + "\$WINDOWS.~WS\"
    Public Shared ReadOnly RECYCLE_BIN_FILE As String = Path.GetPathRoot(WINDOWS_ROOT_PATH) + "$RECYCLE.BIN\"
    Public Shared ReadOnly PREFETCH_FILE As String = WINDOWS_ROOT_PATH + "\Prefetch\"
    Public Shared ReadOnly INTERNET_CACHE_FILE As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\"
    Public Shared ReadOnly APPDATA_ROAMING_TEMP As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Temp\"
    Public Shared ReadOnly APPDATA_LOCAL_TEMP As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Temp\"
    Public Shared ReadOnly SYSTEM_TMP As String = Environment.GetEnvironmentVariable("TMP", EnvironmentVariableTarget.Machine) + "\"
    Public Shared ReadOnly SYSTEM_TEMP As String = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine) + "\"
    Public Shared ReadOnly SYSTEM_TMPDIR As String = Environment.GetEnvironmentVariable("TMPDIR", EnvironmentVariableTarget.Machine) + "\"
    Public Shared ReadOnly USER_TMP As String = Environment.GetEnvironmentVariable("TMP", EnvironmentVariableTarget.User) + "\"
    Public Shared ReadOnly USER_TEMP As String = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.User) + "\"
    Public Shared ReadOnly CURRENT_TEMP As String = Path.GetTempPath
End Class
