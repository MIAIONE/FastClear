
Public Class ClearHelper
    <DllImport("kernel32.dll", EntryPoint:="SetProcessWorkingSetSize")>
    Public Shared Function SetProcessWorkingSetSize(process As IntPtr, minSize As Integer, maxSize As Integer) As Integer
    End Function
    Public Shared Sub ClearMemory(virtualRAMbool As Boolean)
        On Error Resume Next
        Task.Factory.StartNew(New Action(Sub()

                                             GC.Collect()
                                             GC.WaitForPendingFinalizers()
                                             Dim processes As Process() = Process.GetProcesses()
                                             For Each oprocess As Process In processes
                                                 Try
                                                     If oprocess IsNot Process.GetCurrentProcess Then
                                                         If oprocess.Handle <> IntPtr.Zero Then
                                                             If virtualRAMbool Then
                                                                 SetProcessWorkingSetSize(oprocess.Handle, -1, -1)
                                                             End If
                                                             Psapi.EmptyWorkingSet(New Kernel32.SafeObjectHandle(oprocess.Handle))
                                                         End If
                                                     End If
                                                 Catch ex As SEHException
                                                 Catch ex As NullReferenceException
                                                 Catch ex As Exception
                                                 End Try
                                             Next
                                         End Sub))
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
    Public Shared Function GetAllSubKeyAddin(RootReg As RegistryKey, dirpath As String) As Dictionary(Of String, String)
        On Error Resume Next
        Dim new_dic As New Dictionary(Of String, String)
        For Each strs As String In RootReg.GetSubKeyNames
            new_dic.Add(dirpath, strs + "\" + dirpath)
        Next
        Return new_dic
    End Function
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
        If My.Settings.ClearTask_Dwm Then
            RestartProcess("dwm", False)
        End If
        If My.Settings.ClearTask_Explorer Then
            RestartProcess("explorer")
        End If
        If My.Settings.ClearTask_SearchIndexer Then
            RestartProcess("searchindexer", False)
        End If
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
