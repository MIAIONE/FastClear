
Public Class ClearHelper
    ''' <summary>
    ''' 设置程序的WorkingSet大小，如果都为-1则尽可能的使用虚拟内存
    ''' </summary>
    ''' <param name="process">进程句柄</param>
    ''' <param name="minSize">最小大小</param>
    ''' <param name="maxSize">最大大小</param>
    ''' <returns>数值</returns>
    <DllImport("kernel32.dll", EntryPoint:="SetProcessWorkingSetSize")>
    Public Shared Function SetProcessWorkingSetSize(process As IntPtr, minSize As Integer, maxSize As Integer) As Integer
    End Function

    Public Shared Sub ClearMemory(virtualRAMbool As Boolean)
        On Error Resume Next
        Task.Factory.StartNew(New Action(Sub()
                                             Try
                                                 GC.Collect()
                                                 GC.WaitForPendingFinalizers()
                                                 Dim processes As Process() = Process.GetProcesses()
                                                 For Each oprocess As Process In processes
                                                     If oprocess IsNot Process.GetCurrentProcess Then
                                                         If oprocess.Handle <> IntPtr.Zero Then
                                                             Try
                                                                 If virtualRAMbool Then
                                                                     SetProcessWorkingSetSize(oprocess.Handle, -1, -1)
                                                                 End If
                                                                 Psapi.EmptyWorkingSet(New Kernel32.SafeObjectHandle(oprocess.Handle))
                                                             Catch ex As SEHException
                                                                 Continue For
                                                             Catch ex1 As NullReferenceException
                                                                 Continue For
                                                             Catch ex2 As Exception
                                                                 Continue For
                                                             End Try
                                                         End If
                                                     End If
                                                 Next
                                             Catch ex2 As Exception
                                             End Try
                                         End Sub)).Wait()
    End Sub

    Public Shared Function GetCurrentMemoryUsing() As PerformanceCounter
        On Error Resume Next
        'GC.Collect()
        Dim RAM As PerformanceCounter = New PerformanceCounter("Memory", "Available MBytes", "")
        Return RAM
    End Function
    Public Shared Function GetCPUAllCoreUsing() As PerformanceCounter
        On Error Resume Next
        'GC.Collect()

        Dim counters As PerformanceCounter = New PerformanceCounter
        counters = New PerformanceCounter("Processor", "% Processor Time", "_Total")
        counters.NextValue()
        Return counters
    End Function
    Public Shared Sub ClearReg()
        On Error Resume Next
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "VideoInitTime", 1024, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "EnablePrefetcher", 1, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "AppLaunchMaxNumPages", 8192, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "AppLaunchMaxNumSections", 512, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "BootMaxNumPages", 128000, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "BootMaxNumSections", 8192, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "MaxNumActiveTraces", 64, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "MaxNumSavedTraces", 64, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "RootDirPath", "Prefetch", RegistryValueKind.String)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "HostingAppList", "DLLHOST.EXE,MMC.EXE,RUNDLL32.EXE", RegistryValueKind.String)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control", "WaitToKillServiceTimeout", "10000", RegistryValueKind.String)
        SetReg(Registry.CurrentUser, "Control Panel\Desktop", "AutoEndTasks", 1, RegistryValueKind.DWord)
        SetReg(Registry.CurrentUser, "Control Panel\Desktop", "HungAppTimeout", "100", RegistryValueKind.String)
        SetReg(Registry.CurrentUser, "Control Panel\Desktop", "WaitToKillAppTimeout", "500", RegistryValueKind.String)
        SetReg(Registry.CurrentUser, "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", "AlwaysUnloadDLL", 1, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Dfrg\BootOptimizeFunction", "Enable", "yes", RegistryValueKind.String)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Services\stisvc", "Start", 4, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRemoteRecursiveEvents", 1, RegistryValueKind.DWord)
        SetReg(Registry.CurrentUser, "SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoSaveSettings", 0, RegistryValueKind.DWord)
        SetReg(Registry.CurrentUser, "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "NoNetCrawling", 1, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM\CDFS", "CacheSize", 4096, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM\CDFS", "Prefetch", 0, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM\CDFS", "PrefetchTail", 256, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "Win31FileSYSTEM", 0, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "NtfsDisable8dot3NameCreation", 0, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "Win95TruncatedExtensions", 1, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "NtfsAllowExtendedCharacterIn8dot3Name", 1, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "ConfigFileAllocSize", 1024, RegistryValueKind.DWord)
        SetReg(Registry.CurrentUser, "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CabinetState", "Use Search Asst", "no", RegistryValueKind.String)
        SetReg(Registry.CurrentUser, "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DisableThumbnailCache", 1, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Policies\Microsoft\Windows\DriverSearching", "DontSearchWindowsUpdate", 1, RegistryValueKind.DWord)
        SetReg(Registry.CurrentUser, "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Desktop\CleanupWiz", "NoRun", 1, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\MediaPlayer", "PlayerUpgrade\AskMeAgain", "no", RegistryValueKind.String)
        SetReg(Registry.LocalMachine, "SOFTWARE\Policies\Microsoft\WindowsMediaPlayer", "DisableAutoUpdate", 1, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", "SFCDisable", 4294967197, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Services\lanmanserver\parameters", "AutoShareServer", 0, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Services\lanmanserver\parameters", "AutoShareWks", 0, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "AllOrNone", 3, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "IncludeKernelFaults", 0, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "IncludeMicrosoftApps", 0, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "IncludeWindowsApps", 0, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "DoReport", 0, RegistryValueKind.DWord)
        SetReg(Registry.CurrentUser, "SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoDriveTypeAutoRun", 255, RegistryValueKind.DWord)
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Windows", "NoPopUpsOnBoot", "1", RegistryValueKind.String)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Windows\CurrentVersion\policies\SYSTEM", "legalnoticecaption", "", RegistryValueKind.String)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Windows\CurrentVersion\policies\SYSTEM", "legalnoticetext", "", RegistryValueKind.String)
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", "AutoAdminLogon", "0", RegistryValueKind.String)
    End Sub
    Public Shared Sub SetReg(RootReg As RegistryKey, dirpath As String, keyname As String, keyvalue As Object, valuekind As RegistryValueKind)
        On Error Resume Next
        RootReg.OpenSubKey(dirpath, True).SetValue(keyname, keyvalue, valuekind)
    End Sub

    Public Shared Function EnableGPU(open As Boolean) As Boolean
        Try
            Dim x = Registry.Users
            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Vxd", True)
            key.CreateSubKey("BIOS", True)
            key.OpenSubKey("BIOS", True)
            key.SetValue("CPUPriority", If(open, 1, 0), RegistryValueKind.DWord)
            key.SetValue("PCIConcur", If(open, 1, 0), RegistryValueKind.DWord)
            key.SetValue("FastDRAM", If(open, 1, 0), RegistryValueKind.DWord)
            key.SetValue("AGPConcur", If(open, 1, 0), RegistryValueKind.DWord)
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Shared Sub ClearSystemProcess()
        RestartProcess("dwm", False)
        RestartProcess("explorer")
    End Sub
    Public Shared Sub RestartProcess(name As String, Optional autoRun As Boolean = True)
        On Error Resume Next
        Dim ProcessPath As String
        Dim process_all As Process() = Process.GetProcesses()
        For Each every_proc As Process In process_all
            If every_proc.ProcessName.ToLower = name Then
                ProcessPath = every_proc.MainModule.FileName
                every_proc.Kill()
                If autoRun Then
                    Process.Start(ProcessPath)
                End If
            End If
        Next
    End Sub
    Public Shared Function SetHibernateEnabled(bool As Boolean) As Boolean
        Try
            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Power", True)
            key.SetValue("HibernateEnabled", If(bool, 1, 0), RegistryValueKind.DWord)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function SetHiberbootEnabled(bool As Boolean) As Boolean
        Try
            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Session Manager\Power", True)
            key.SetValue("HiberbootEnabled", If(bool, 1, 0), RegistryValueKind.DWord)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Sub CLearSystemDir()
        On Error Resume Next
        ClearFiles(ClearConst.RECYCLE_BIN_FILE)
        ClearFiles(ClearConst.WINDOWS_BT_FILE)
        ClearFiles(ClearConst.WINDOWS_WS_FILE)
    End Sub
    Public Shared Sub CLearAllNormalDir()
        On Error Resume Next
        ClearFiles(ClearConst.APPDATA_LOCAL_TEMP)
        ClearFiles(ClearConst.APPDATA_ROAMING_TEMP)
        ClearFiles(ClearConst.CURRENT_TEMP)
        ClearFiles(ClearConst.SYSTEM_TEMP)
        ClearFiles(ClearConst.SYSTEM_TMP)
        ClearFiles(ClearConst.SYSTEM_TMPDIR)
        ClearFiles(ClearConst.USER_TEMP)
        ClearFiles(ClearConst.USER_TMP)
        ClearFiles(ClearConst.PREFETCH_FILE)
        ClearFiles(ClearConst.INTERNET_CACHE_FILE)
    End Sub
    Public Shared Sub ClearFiles(dir As String)
        On Error Resume Next
        Task.Factory.StartNew(New Action(Sub()
                                             If Directory.Exists(dir) Then
                                                 DeleteDir(dir)
                                             End If
                                         End Sub))
    End Sub

    Public Shared Sub DeleteDir(files As String)
        On Error Resume Next
        Dim fileInfo As DirectoryInfo = New DirectoryInfo(files) With {.Attributes = FileAttributes.Normal And FileAttributes.Directory}
        File.SetAttributes(files, FileAttributes.Normal)
        If Directory.Exists(files) Then
            Parallel.ForEach(Directory.GetFileSystemEntries(files), New Action(Of String)(Sub(f)
                                                                                              Try
                                                                                                  If File.Exists(f) Then
                                                                                                      File.Delete(f)
                                                                                                  Else
                                                                                                      DeleteDir(f)
                                                                                                  End If
                                                                                              Catch fileex As FileNotFoundException
                                                                                              Catch ex As Exception
                                                                                              End Try
                                                                                          End Sub))
            Directory.Delete(files)
        End If
    End Sub
End Class
