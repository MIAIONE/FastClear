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
        If My.Settings.SetProtectBool Then
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
                Dim service As ServiceController = New ServiceController(My.Resources.SrvServiceName)

                If service.Status <> ServiceControllerStatus.Running AndAlso service.Status <> ServiceControllerStatus.StartPending Then
                    service.Start()

                    For i As Integer = 0 To 60 - 1
                        service.Refresh()
                        Thread.Sleep(1000)

                        If service.Status = System.ServiceProcess.ServiceControllerStatus.Running Then
                            Exit For
                        End If

                        If i = 59 Then
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

        Public Shared Sub ConfigService(myserv As MyInstaller, install As Boolean)
            Dim ti As TransactedInstaller = New TransactedInstaller()
            ti.Installers.Add(myserv.ServiceInstallers)
            ti.Installers.Add(myserv.ServiceProcessInstallers)
            ti.Context = New InstallContext()
            ti.Context.Parameters("AssemblyPath") = My.Resources.SChar & Assembly.GetEntryAssembly().Location & My.Resources.SChar + " /StartService fastclear_run"
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
            CanPauseAndContinue = True
            AutoLog = True
            ExitCode = 0
            ServiceName = My.Resources.SrvServiceName
        End Sub
        Protected ReadOnly TaskTimer As New Windows.Forms.Timer With {.Enabled = False, .Interval = 60000}
        Protected Sub RunTask()
            On Error Resume Next
            If My.Settings.ClearMemory Then
                ClearHelper.ClearMemory(My.Settings.ClearVirtualMemory)
            End If
            If My.Settings.ClearTempFiles Then

            End If
        End Sub

        Protected Overrides Sub OnStart(args() As String)
            AddHandler TaskTimer.Tick, AddressOf RunTask
            TaskTimer.Interval = My.Settings.AutoClearTime
            SetProtect(True)
        End Sub
        Protected Overrides Sub OnPause()
            TaskTimer.Enabled = False
            SetProtect(False)
        End Sub
        Protected Overrides Sub OnContinue()
            TaskTimer.Enabled = True
            SetProtect(True)
        End Sub
        Protected Overrides Sub OnStop()
            TaskTimer.Enabled = False
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
