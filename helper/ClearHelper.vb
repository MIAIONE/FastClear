
Imports Version = System.Version
<SetSuperRunningToken(Privilege.ProfileSingleProcess + Privilege.IncreaseQuota)>
Public Class ClearHelper

    <DllImport("ntdll.dll")>
    Public Shared Function NtSetSystemInformation(InfoClass As SYSTEM_INFORMATION_CLASS, Info As IntPtr, Length As Integer) As Integer
    End Function
    <DllImport("psapi.dll")>
    Public Shared Function EmptyWorkingSet(hwProc As IntPtr) As Integer
    End Function

    Const MemoryPurgeStandbyList As Integer = 4
    Const MemoryEmptyWorkingSets As Integer = 2
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure SYSTEM_MEMORY_LIST_INFORMATION
        Public ZeroPageCount As UInteger
        Public FreePageCount As UInteger
        Public ModifiedPageCount As UInteger
        Public ModifiedNoWritePageCount As UInteger
        Public BadPageCount As UInteger
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)>
        Public PageCountByPriority As UInteger()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)>
        Public RepurposedPagesByPriority As UInteger()
        Public ModifiedPageCountPageFile As UInteger
    End Structure
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Structure SYSTEM_CACHE_INFORMATION
        Public CurrentSize As UInteger
        Public PeakSize As UInteger
        Public PageFaultCount As UInteger
        Public MinimumWorkingSet As UInteger
        Public MaximumWorkingSet As UInteger
        Public Unused1 As UInteger
        Public Unused2 As UInteger
        Public Unused3 As UInteger
        Public Unused4 As UInteger
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Structure SYSTEM_CACHE_INFORMATION_64_BIT
        Public CurrentSize As Long
        Public PeakSize As Long
        Public PageFaultCount As Long
        Public MinimumWorkingSet As Long
        Public MaximumWorkingSet As Long
        Public Unused1 As Long
        Public Unused2 As Long
        Public Unused3 As Long
        Public Unused4 As Long
    End Structure
    Public Enum SYSTEM_INFORMATION_CLASS
        SystemBasicInformation = &H0
        SystemProcessorInformation = &H1
        SystemPerformanceInformation = &H2
        SystemTimeOfDayInformation = &H3
        SystemPathInformation = &H4
        SystemProcessInformation = &H5
        SystemCallCountInformation = &H6
        SystemDeviceInformation = &H7
        SystemProcessorPerformanceInformation = &H8
        SystemFlagsInformation = &H9
        SystemCallTimeInformation = &HA
        SystemModuleInformation = &HB
        SystemLocksInformation = &HC
        SystemStackTraceInformation = &HD
        SystemPagedPoolInformation = &HE
        SystemNonPagedPoolInformation = &HF
        SystemHandleInformation = &H10
        SystemObjectInformation = &H11
        SystemPageFileInformation = &H12
        SystemVdmInstemulInformation = &H13
        SystemVdmBopInformation = &H14
        SystemFileCacheInformation = &H15
        SystemPoolTagInformation = &H16
        SystemInterruptInformation = &H17
        SystemDpcBehaviorInformation = &H18
        SystemFullMemoryInformation = &H19
        SystemLoadGdiDriverInformation = &H1A
        SystemUnloadGdiDriverInformation = &H1B
        SystemTimeAdjustmentInformation = &H1C
        SystemSummaryMemoryInformation = &H1D
        SystemMirrorMemoryInformation = &H1E
        SystemPerformanceTraceInformation = &H1F
        SystemObsolete0 = &H20
        SystemExceptionInformation = &H21
        SystemCrashDumpStateInformation = &H22
        SystemKernelDebuggerInformation = &H23
        SystemContextSwitchInformation = &H24
        SystemRegistryQuotaInformation = &H25
        SystemExtendServiceTableInformation = &H26
        SystemPrioritySeperation = &H27
        SystemVerifierAddDriverInformation = &H28
        SystemVerifierRemoveDriverInformation = &H29
        SystemProcessorIdleInformation = &H2A
        SystemLegacyDriverInformation = &H2B
        SystemCurrentTimeZoneInformation = &H2C
        SystemLookasideInformation = &H2D
        SystemTimeSlipNotification = &H2E
        SystemSessionCreate = &H2F
        SystemSessionDetach = &H30
        SystemSessionInformation = &H31
        SystemRangeStartInformation = &H32
        SystemVerifierInformation = &H33
        SystemVerifierThunkExtend = &H34
        SystemSessionProcessInformation = &H35
        SystemLoadGdiDriverInSystemSpace = &H36
        SystemNumaProcessorMap = &H37
        SystemPrefetcherInformation = &H38
        SystemExtendedProcessInformation = &H39
        SystemRecommendedSharedDataAlignment = &H3A
        SystemComPlusPackage = &H3B
        SystemNumaAvailableMemory = &H3C
        SystemProcessorPowerInformation = &H3D
        SystemEmulationBasicInformation = &H3E
        SystemEmulationProcessorInformation = &H3F
        SystemExtendedHandleInformation = &H40
        SystemLostDelayedWriteInformation = &H41
        SystemBigPoolInformation = &H42
        SystemSessionPoolTagInformation = &H43
        SystemSessionMappedViewInformation = &H44
        SystemHotpatchInformation = &H45
        SystemObjectSecurityMode = &H46
        SystemWatchdogTimerHandler = &H47
        SystemWatchdogTimerInformation = &H48
        SystemLogicalProcessorInformation = &H49
        SystemWow64SharedInformationObsolete = &H4A
        SystemRegisterFirmwareTableInformationHandler = &H4B
        SystemFirmwareTableInformation = &H4C
        SystemModuleInformationEx = &H4D
        SystemVerifierTriageInformation = &H4E
        SystemSuperfetchInformation = &H4F
        SystemMemoryListInformation = &H50
        SystemFileCacheInformationEx = &H51
        SystemThreadPriorityClientIdInformation = &H52
        SystemProcessorIdleCycleTimeInformation = &H53
        SystemVerifierCancellationInformation = &H54
        SystemProcessorPowerInformationEx = &H55
        SystemRefTraceInformation = &H56
        SystemSpecialPoolInformation = &H57
        SystemProcessIdInformation = &H58
        SystemErrorPortInformation = &H59
        SystemBootEnvironmentInformation = &H5A
        SystemHypervisorInformation = &H5B
        SystemVerifierInformationEx = &H5C
        SystemTimeZoneInformation = &H5D
        SystemImageFileExecutionOptionsInformation = &H5E
        SystemCoverageInformation = &H5F
        SystemPrefetchPatchInformation = &H60
        SystemVerifierFaultsInformation = &H61
        SystemSystemPartitionInformation = &H62
        SystemSystemDiskInformation = &H63
        SystemProcessorPerformanceDistribution = &H64
        SystemNumaProximityNodeInformation = &H65
        SystemDynamicTimeZoneInformation = &H66
        SystemCodeIntegrityInformation = &H67
        SystemProcessorMicrocodeUpdateInformation = &H68
        SystemProcessorBrandString = &H69
        SystemVirtualAddressInformation = &H6A
        SystemLogicalProcessorAndGroupInformation = &H6B
        SystemProcessorCycleTimeInformation = &H6C
        SystemStoreInformation = &H6D
        SystemRegistryAppendString = &H6E
        SystemAitSamplingValue = &H6F
        SystemVhdBootInformation = &H70
        SystemCpuQuotaInformation = &H71
        SystemNativeBasicInformation = &H72
        SystemErrorPortTimeouts = &H73
        SystemLowPriorityIoInformation = &H74
        SystemBootEntropyInformation = &H75
        SystemVerifierCountersInformation = &H76
        SystemPagedPoolInformationEx = &H77
        SystemSystemPtesInformationEx = &H78
        SystemNodeDistanceInformation = &H79
        SystemAcpiAuditInformation = &H7A
        SystemBasicPerformanceInformation = &H7B
        SystemQueryPerformanceCounterInformation = &H7C
        SystemSessionBigPoolInformation = &H7D
        SystemBootGraphicsInformation = &H7E
        SystemScrubPhysicalMemoryInformation = &H7F
        SystemBadPageInformation = &H80
        SystemProcessorProfileControlArea = &H81
        SystemCombinePhysicalMemoryInformation = &H82
        SystemEntropyInterruptTimingInformation = &H83
        SystemConsoleInformation = &H84
        SystemPlatformBinaryInformation = &H85
        SystemPolicyInformation = &H86
        SystemHypervisorProcessorCountInformation = &H87
        SystemDeviceDataInformation = &H88
        SystemDeviceDataEnumerationInformation = &H89
        SystemMemoryTopologyInformation = &H8A
        SystemMemoryChannelInformation = &H8B
        SystemBootLogoInformation = &H8C
        SystemProcessorPerformanceInformationEx = &H8D
        SystemCriticalProcessErrorLogInformation = &H8E
        SystemSecureBootPolicyInformation = &H8F
        SystemPageFileInformationEx = &H90
        SystemSecureBootInformation = &H91
        SystemEntropyInterruptTimingRawInformation = &H92
        SystemPortableWorkspaceEfiLauncherInformation = &H93
        SystemFullProcessInformation = &H94
        SystemKernelDebuggerInformationEx = &H95
        SystemBootMetadataInformation = &H96
        SystemSoftRebootInformation = &H97
        SystemElamCertificateInformation = &H98
        SystemOfflineDumpConfigInformation = &H99
        SystemProcessorFeaturesInformation = &H9A
        SystemRegistryReconciliationInformation = &H9B
        SystemEdidInformation = &H9C
        SystemManufacturingInformation = &H9D
        SystemEnergyEstimationConfigInformation = &H9E
        SystemHypervisorDetailInformation = &H9F
        SystemProcessorCycleStatsInformation = &HA0
        SystemVmGenerationCountInformation = &HA1
        SystemTrustedPlatformModuleInformation = &HA2
        SystemKernelDebuggerFlags = &HA3
        SystemCodeIntegrityPolicyInformation = &HA4
        SystemIsolatedUserModeInformation = &HA5
        SystemHardwareSecurityTestInterfaceResultsInformation = &HA6
        SystemSingleModuleInformation = &HA7
        SystemAllowedCpuSetsInformation = &HA8
        SystemDmaProtectionInformation = &HA9
        SystemInterruptCpuSetsInformation = &HAA
        SystemSecureBootPolicyFullInformation = &HAB
        SystemCodeIntegrityPolicyFullInformation = &HAC
        SystemAffinitizedInterruptProcessorInformation = &HAD
        SystemRootSiloInformation = &HAE
        SystemCpuSetInformation = &HAF
        SystemCpuSetTagInformation = &HB0
        SystemWin32WerStartCallout = &HB1
        SystemSecureKernelProfileInformation = &HB2
        SystemCodeIntegrityPlatformManifestInformation = &HB3
        SystemInterruptSteeringInformation = &HB4
        SystemSuppportedProcessorArchitectures = &HB5
        SystemMemoryUsageInformation = &HB6
        SystemCodeIntegrityCertificateInformation = &HB7
        SystemPhysicalMemoryInformation = &HB8
        SystemControlFlowTransition = &HB9
        SystemKernelDebuggingAllowed = &HBA
        SystemActivityModerationExeState = &HBB
        SystemActivityModerationUserSettings = &HBC
        SystemCodeIntegrityPoliciesFullInformation = &HBD
        SystemCodeIntegrityUnlockInformation = &HBE
        SystemIntegrityQuotaInformation = &HBF
        SystemFlushInformation = &HC0
        SystemProcessorIdleMaskInformation = &HC1
        SystemSecureDumpEncryptionInformation = &HC2
        SystemWriteConstraintInformation = &HC3
        SystemKernelVaShadowInformation = &HC4
        SystemHypervisorSharedPageInformation = &HC5
        SystemFirmwareBootPerformanceInformation = &HC6
        SystemCodeIntegrityVerificationInformation = &HC7
        SystemFirmwarePartitionInformation = &HC8
        SystemSpeculationControlInformation = &HC9
        SystemDmaGuardPolicyInformation = &HCA
        SystemEnclaveLaunchControlInformation = &HCB
        SystemWorkloadAllowedCpuSetsInformation = &HCC
        SystemCodeIntegrityUnlockModeInformation = &HCD
        SystemLeapSecondInformation = &HCE
        SystemFlags2Information = &HCF
        SystemSecurityModelInformation = &HD0
        SystemCodeIntegritySyntheticCacheInformation = &HD1
        MaxSystemInfoClass = &HD2
    End Enum

    Public Shared Function Is64BitMode() As Boolean
        Return IntPtr.Size = 8
    End Function

    Public Shared Sub ClearFileSystemCache(ClearStandbyCache As Boolean)
        Try

            Dim num1 As UInteger
            Dim SystemInfoLength As Integer
            Dim gcHandle As GCHandle

            If Not Is64BitMode() Then
                Dim cacheInformation As SYSTEM_CACHE_INFORMATION = New SYSTEM_CACHE_INFORMATION With {
                    .MinimumWorkingSet = UInteger.MaxValue,
                    .MaximumWorkingSet = UInteger.MaxValue
                }
                SystemInfoLength = Marshal.SizeOf(cacheInformation)
                gcHandle = GCHandle.Alloc(cacheInformation, GCHandleType.Pinned)
                num1 = NtSetSystemInformation(SYSTEM_INFORMATION_CLASS.SystemFileCacheInformation, gcHandle.AddrOfPinnedObject(), SystemInfoLength)
                gcHandle.Free()
            Else
                Dim information64Bit As SYSTEM_CACHE_INFORMATION_64_BIT = New SYSTEM_CACHE_INFORMATION_64_BIT With {
                    .MinimumWorkingSet = -1L,
                    .MaximumWorkingSet = -1L
                }
                SystemInfoLength = Marshal.SizeOf(information64Bit)
                gcHandle = GCHandle.Alloc(information64Bit, GCHandleType.Pinned)
                num1 = NtSetSystemInformation(SYSTEM_INFORMATION_CLASS.SystemFileCacheInformation, gcHandle.AddrOfPinnedObject(), SystemInfoLength)
                gcHandle.Free()
            End If

            If num1 <> 0 Then
            End If


            If ClearStandbyCache Then
                Dim _SystemInfoLength As Integer = Marshal.SizeOf(MemoryPurgeStandbyList)
                Dim _gcHandle As GCHandle = GCHandle.Alloc(MemoryPurgeStandbyList, GCHandleType.Pinned)
                Dim _num2 As UInteger = NtSetSystemInformation(SYSTEM_INFORMATION_CLASS.SystemMemoryListInformation, _gcHandle.AddrOfPinnedObject(), _SystemInfoLength)
                _gcHandle.Free()
                If _num2 <> 0 Then
                End If
            End If

        Catch ex As Exception
            Console.Write(ex.ToString())
        End Try
    End Sub
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
                                                             Psapi.EmptyWorkingSet(New Kernel32.SafeObjectHandle(oprocess.Handle))
                                                         End If
                                                     End If
                                                 Catch ex As SEHException
                                                 Catch ex As NullReferenceException
                                                 Catch ex As Exception
                                                 End Try
                                             Next
                                             ClearFileSystemCache(virtualRAMbool)
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
    Public Shared Sub ClearReg()
        On Error Resume Next
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "VideoInitTime", 1024, RegistryValueKind.DWord) '显示时间
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "EnablePrefetcher", 1, RegistryValueKind.DWord) '启用预加载，只预读系统启动文件
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "AppLaunchMaxNumPages", 8192, RegistryValueKind.DWord) '应用最大的分页文件
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "AppLaunchMaxNumSections", 512, RegistryValueKind.DWord) '部分
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "BootMaxNumPages", 128000, RegistryValueKind.DWord) '启动最大分页文件
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "BootMaxNumSections", 8192, RegistryValueKind.DWord) '部分
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "MaxNumActiveTraces", 64, RegistryValueKind.DWord) '激活跟踪数量
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "MaxNumSavedTraces", 64, RegistryValueKind.DWord) '保存跟踪数量
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "RootDirPath", "Prefetch", RegistryValueKind.String) '预读根目录
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "HostingAppList", "DLLHOST.EXE,MMC.EXE,RUNDLL32.EXE", RegistryValueKind.String) '承载进程列表
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Dfrg\BootOptimizeFunction", "Enable", "yes", RegistryValueKind.String) '启用程序优化
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "Win31FileSYSTEM", 0, RegistryValueKind.DWord) '不再向后兼容
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "NtfsDisable8dot3NameCreation", 1, RegistryValueKind.DWord) '不再支持短文件名，可增加性能、减少因短文件名引起的bug
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "Win95TruncatedExtensions", 0, RegistryValueKind.DWord) '是否隐藏短文件名后缀为.xx~
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "NtfsAllowExtendedCharacterIn8dot3Name", 1, RegistryValueKind.DWord) '8.3命名格式（短文件名）
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Control\FileSYSTEM", "ConfigFileAllocSize", 4096, RegistryValueKind.DWord) '配置文件大小
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Services\lanmanserver\parameters", "AutoShareServer", 0, RegistryValueKind.DWord) '关闭共享
        SetReg(Registry.LocalMachine, "SYSTEM\CurrentControlSet\Services\lanmanserver\parameters", "AutoShareWks", 0, RegistryValueKind.DWord) '同上----^
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "AllOrNone", 3, RegistryValueKind.DWord) '停止报告错误-不启动werfault错误报告程序
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "IncludeKernelFaults", 0, RegistryValueKind.DWord) '不包括内核错误
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "IncludeMicrosoftApps", 0, RegistryValueKind.DWord) '不包括微软程序
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "IncludeWindowsApps", 0, RegistryValueKind.DWord) '不包括Win32程序
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\PCHealth\ErrorReporting", "DoReport", 0, RegistryValueKind.DWord) '是否执行报告
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Windows\CurrentVersion\policies\SYSTEM", "legalnoticecaption", "", RegistryValueKind.String) 'winlogon前显示的横幅标题
        SetReg(Registry.LocalMachine, "SOFTWARE\Microsoft\Windows\CurrentVersion\policies\SYSTEM", "legalnoticetext", "", RegistryValueKind.String) '内容
    End Sub
    Public Shared Sub SetReg(RootReg As RegistryKey, dirpath As String, keyname As String, keyvalue As Object, valuekind As RegistryValueKind)
        On Error Resume Next
        RootReg.OpenSubKey(dirpath, True).SetValue(keyname, keyvalue, valuekind)
    End Sub
    Public Shared Function GetGPUInfo() As Boolean
        Dim objvide As ManagementObjectSearcher = New ManagementObjectSearcher("select * from Win32_VideoController")

        For Each obj As ManagementObject In objvide.[Get]()
            If obj("Name").ToString().ToUpper.IndexOf("NVIDIA") <> -1 Then
                Return Version.Parse(obj("DriverVersion").ToString) >= New Version("451.8.0")
            ElseIf obj("Name").ToString().ToUpper.IndexOf("AMD") <> -1 Then
                Return Version.Parse(obj("DriverVersion").ToString) >= New Version("20.5.1")
            End If
        Next
        Return False
    End Function
    Public Shared Function EnableGPU(open As Boolean) As Boolean
        Try
            Dim x = Registry.Users
            Dim key As RegistryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\CurrentControlSet\Services\Vxd\BIOS", True)
            key.SetValue("CPUPriority", If(open, 1, 0), RegistryValueKind.DWord)
            key.SetValue("PCIConcur", If(open, 1, 0), RegistryValueKind.DWord)
            key.SetValue("FastDRAM", If(open, 1, 0), RegistryValueKind.DWord)
            key.SetValue("AGPConcur", If(open, 1, 0), RegistryValueKind.DWord)
            key = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Direct3D\Drivers", True)
            key.SetValue("SoftwareOnly", If(open, 0, 1), RegistryValueKind.DWord)
            key = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\DirectDraw", True)
            key.SetValue("EmulationOnly", If(open, 0, 1), RegistryValueKind.DWord)
            If Program.GetOSVersion.Major >= 10 AndAlso Program.GetOSVersion.Build >= 19041 AndAlso GetGPUInfo() Then
                key = Registry.LocalMachine.CreateSubKey("SYSTEM\CurrentControlSet\Control\GraphicsDrivers", True)
                key.SetValue("HwSchMode", If(open, 2, 1), RegistryValueKind.DWord)
            End If
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
