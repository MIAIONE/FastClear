Public Class ClearConst
    '----command
    Public ReadOnly DISM_CLEAR_UPDATE_IMAGE As String = "/Online /Cleanup-Image /StartComponentCleanup /ResetBase"


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
