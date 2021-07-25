
Public Class ClearHelper
    Public Shared Sub ClearMemory()
        On Error Resume Next
        Task.Factory.StartNew(New Action(Sub()

                                             GC.Collect()
                                             GC.WaitForPendingFinalizers()
                                             Dim processes As Process() = Process.GetProcesses()
                                             For Each oprocess As Process In processes
                                                 Try
                                                     If oprocess IsNot Process.GetCurrentProcess Then
                                                         If oprocess.Handle <> IntPtr.Zero Then
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
    Public Shared Function GetCurrentMemoryUsing() As Single
        On Error Resume Next
        Dim cpu As PerformanceCounter = New PerformanceCounter("Memory", "Available MBytes", "")
        Dim CPUs As Single = cpu.NextValue()
        Dim Be_RAM As Single = (8089 - CPUs) / 8089 * 100
        Return Be_RAM
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
    Public Shared Sub ClearSystemUpdateTempFiles(dir As String)
        On Error Resume Next
        Task.Factory.StartNew(New Action(Sub()
                                             DeleteDir(dir)
                                         End Sub))
    End Sub

    Public Shared Sub DeleteDir(files As String)
        On Error Resume Next
        Dim fileInfo As DirectoryInfo = New DirectoryInfo(files) With {.Attributes = FileAttributes.Normal And FileAttributes.Directory}
        File.SetAttributes(files, FileAttributes.Normal)
        If Directory.Exists(files) Then
            Parallel.ForEach(Directory.GetFileSystemEntries(files), New Action(Of String)(Sub(f)
                                                                                              If File.Exists(f) Then
                                                                                                  File.Delete(f)
                                                                                              Else
                                                                                                  DeleteDir(f)
                                                                                              End If
                                                                                          End Sub))
            Directory.Delete(files)
        End If
    End Sub
End Class
