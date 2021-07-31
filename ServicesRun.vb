Public Class ServicesRun
    ''' <summary>
    ''' 设置当前进程为关键进程
    ''' </summary>
    ''' <param name="NewValue">是否开启</param>
    ''' <param name="OldValue">是否保留旧的值</param>
    ''' <param name="IsWinLogon">是否为WinLogon</param>
    ''' <returns>是否成功</returns>
    <DllImport("ntdll.dll", SetLastError:=True)>
    Public Shared Function RtlSetProcessIsCritical(NewValue As Boolean, OldValue As Boolean, IsWinLogon As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    Public Shared Function SetProtect(bool As Boolean) As Boolean
        If ConfigHelper.SetProtectBool Then
            Return RtlSetProcessIsCritical(bool, False, False)
        Else
            Return False
        End If
    End Function
    ''辅助类
    Public Class ServiceHelper
        Public Shared Function IsServiceExisted() As Boolean
            Dim services As ServiceController() = ServiceController.GetServices()

            For Each s As ServiceController In services

                If s.ServiceName = My.Resources.SrvServiceName Then
                    Return True
                End If
            Next

            Return False
        End Function
        Public Shared Function GetService() As ServiceController
            If IsServiceExisted() Then
                Return New ServiceController(My.Resources.SrvServiceName)
            Else
                Return Nothing
            End If
        End Function
        Public Shared Function StartService() As Boolean
            If IsServiceExisted() Then
                Dim service As ServiceController = GetService()

                If service.Status <> ServiceControllerStatus.Running AndAlso service.Status <> ServiceControllerStatus.StartPending Then
                    service.Start()

                    For i As Integer = 1 To 30
                        service.Refresh()
                        Thread.Sleep(1000)

                        If service.Status = ServiceControllerStatus.Running Then
                            Exit For
                        End If

                        If i = 30 Then
                            Return False
                        End If
                    Next
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Function
        Public Shared Function StopService() As Boolean
            If IsServiceExisted() Then
                Dim service As ServiceController = GetService()

                If service.Status <> ServiceControllerStatus.Stopped AndAlso service.Status <> ServiceControllerStatus.StopPending Then
                    service.Stop()

                    For i As Integer = 1 To 30
                        service.Refresh()
                        Thread.Sleep(1000)

                        If service.Status = ServiceControllerStatus.Stopped Then
                            Exit For
                        End If

                        If i = 30 Then
                            Return False
                        End If
                    Next
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Function
        Public Shared Function GetServiceStatus() As ServiceControllerStatus
            Dim service As ServiceController = New ServiceController(My.Resources.SrvServiceName)
            Return service.Status
        End Function

        Public Shared Sub ConfigService(myserv As MyInstaller, install As Boolean, cmdline As String)
            Dim ti As TransactedInstaller = New TransactedInstaller()
            ti.Installers.Add(myserv.ServiceInstallers)
            ti.Installers.Add(myserv.ServiceProcessInstallers)
            ti.Context = New InstallContext()
            ti.Context.Parameters("AssemblyPath") = My.Resources.SChar & Assembly.GetEntryAssembly().Location & My.Resources.SChar + cmdline
            'ti.Context.Parameters("LogToConsole") = "false"
            If install Then
                ti.Install(New Hashtable())
            Else
                ti.Uninstall(Nothing)
            End If
        End Sub
    End Class
    ''服务
    Public Class Service
        Inherits ServiceBase
        Public Sub New()
            CanHandlePowerEvent = True
            CanHandleSessionChangeEvent = True
            CanShutdown = True
            CanStop = True
            CanPauseAndContinue = False
            AutoLog = True
            ExitCode = 0
            ServiceName = My.Resources.SrvServiceName
        End Sub
        Protected Sub WriteEventLogs(log As String)
            If (New FileInfo(ClearConst.AppPath + "srv.log")).Length >= 134217728 Then
                File.Delete(ClearConst.AppPath + "srv.log")
            End If
            File.AppendAllText(ClearConst.AppPath + "srv.log", Date.Now.ToString + " -- " + log + vbCrLf)
        End Sub
        Private TaskTimer As Threading.Timer
        Private RunTask As TimerCallback
        Private IsClearMemory As Boolean
        Private IsUseVirtual As Boolean

        Protected Overrides Sub OnStart(args() As String)
            On Error Resume Next
            WriteEventLogs("srv_start")
            ConfigHelper.ReloadCfg()
            IsClearMemory = ConfigHelper.ClearMemory
            IsUseVirtual = ConfigHelper.Priority_UseVirtualMemory
            RunTask = Sub()
                          WriteEventLogs("clear memory")
                          If IsClearMemory Then
                              ClearHelper.ClearMemory(IsUseVirtual)
                          End If
                      End Sub
            TaskTimer = New Threading.Timer(RunTask, Nothing, 0, ConfigHelper.AutoClearTime) 'ConfigHelper.AutoClearTime)
            SetProtect(ConfigHelper.SetProtectBool)
        End Sub

        Protected Overrides Sub OnStop()
            On Error Resume Next
            WriteEventLogs("srv_stop")
            TaskTimer.Dispose()
            SetProtect(False)
        End Sub
        Protected Overrides Function OnPowerEvent(powerStatus As PowerBroadcastStatus) As Boolean
            Return True
        End Function
    End Class
    Public Class MyInstaller
        Public ReadOnly Property ServiceProcessInstallers As ServiceProcessInstaller
        Public ReadOnly Property ServiceInstallers As ServiceInstaller
        Public Sub New()
            ''初始化

            ServiceProcessInstallers = New ServiceProcessInstaller
            ServiceInstallers = New ServiceInstaller
            ''设置属性等
            ServiceProcessInstallers.Account = ServiceAccount.LocalSystem
            ServiceProcessInstallers.Username = Nothing
            ServiceProcessInstallers.Password = Nothing
            ''
            ServiceInstallers.StartType = ServiceStartMode.Automatic
            ServiceInstallers.DelayedAutoStart = False
            ServiceInstallers.ServiceName = My.Resources.SrvServiceName
            ServiceInstallers.DisplayName = My.Resources.SrvDisplayName
            ServiceInstallers.Description = My.Resources.SrvDescription
        End Sub
    End Class
End Class
