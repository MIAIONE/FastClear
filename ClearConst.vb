Public Class ClearConst
    '----command
    Public ReadOnly DISM_CLEAR_UPDATE_IMAGE As String = "/Online /Cleanup-Image /StartComponentCleanup /ResetBase"
    Public ReadOnly POWERCFG_ACTIVE As String = "/duplicatescheme "
    Public ReadOnly GUID_EnergySaving As String = "a1841308-3541-4fab-bc81-f71556f20b4a"
    ''' <summary>
    ''' If the OS version is lower than Windows 10 (1803), the excellent performance cannot be turned on.
    ''' </summary>
    Public ReadOnly GUID_ExcellentPerformance As String = "e9a42b02-d5df-448d-aa00-03f14749eb61"

    Public ReadOnly GUID_HighPerformance As String = "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c"
    Public ReadOnly GUID_Balanced As String = "381b4222-f694-41f0-9685-ff5bb260df2e"

    '----path
    Public ReadOnly WINDOWS_ROOT_PATH As String = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
    Public ReadOnly WINDOWS_BT_FILE As String = WINDOWS_ROOT_PATH + "\$WINDOWS.~BT\"
    Public ReadOnly WINDOWS_WS_FILE As String = WINDOWS_ROOT_PATH + "\$WINDOWS.~WS\"
    Public ReadOnly RECYCLE_BIN_FILE As String = Path.GetPathRoot(WINDOWS_ROOT_PATH) + "$RECYCLE.BIN\"
    Public ReadOnly PREFETCH_FILE As String = WINDOWS_ROOT_PATH + "\Prefetch\"
    Public ReadOnly INTERNET_CACHE_FILE As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\"
    Public ReadOnly APPDATA_ROAMING_TEMP As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Temp\"
    Public ReadOnly APPDATA_LOCAL_TEMP As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Temp\"
    Public ReadOnly SYSTEM_TMP As String = Environment.GetEnvironmentVariable("TMP", EnvironmentVariableTarget.Machine) + "\"
    Public ReadOnly SYSTEM_TEMP As String = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine) + "\"
    Public ReadOnly SYSTEM_TMPDIR As String = Environment.GetEnvironmentVariable("TMPDIR", EnvironmentVariableTarget.Machine) + "\"
    Public ReadOnly USER_TMP As String = Environment.GetEnvironmentVariable("TMP", EnvironmentVariableTarget.User) + "\"
    Public ReadOnly USER_TEMP As String = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.User) + "\"
    Public ReadOnly CURRENT_TEMP As String = Path.GetTempPath
End Class
