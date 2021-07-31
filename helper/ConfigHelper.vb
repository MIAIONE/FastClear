Public Class ConfigHelper


    Public Shared Sub ReSet()
        My.Settings.Reset()
    End Sub
    Public Shared Sub ReLoad()
        My.Settings.Reload()
    End Sub
    Public Shared Sub Save()
        My.Settings.Save()
        My.Settings.Upgrade()
    End Sub
    Public Shared Sub DymSaveAndReload()
        UpdateCfg()
        'ReloadCfg()
        Save()
        ReLoad()
        'Thread.Sleep(1000)
    End Sub

    '---------json-----------'
    Public Shared Property GlobalCfg As SrvSettings
    Public Shared Sub UpdateCfg()
        File.WriteAllText(AppPath + "appConfig.json", GlobalCfg.ToConfig, Encoding.UTF8)
    End Sub
    Public Shared Sub ReloadCfg()
        GlobalCfg = File.ReadAllText(AppPath + "appConfig.json", Encoding.UTF8).ToSetting
    End Sub
    Public Shared Property AutoClearTime As Integer
        Set(value As Integer)
            GlobalCfg.AutoClearTime = value
        End Set
        Get
            Return Integer.Parse(GlobalCfg.AutoClearTime)
        End Get
    End Property
    Public Shared Property ClearMemory As Boolean
        Set(value As Boolean)
            GlobalCfg.ClearMemory = If(value, 1, 0)
        End Set
        Get
            Return GlobalCfg.ClearMemory = 1
        End Get
    End Property
    Public Shared Property Priority_UseVirtualMemory As Boolean
        Set(value As Boolean)
            GlobalCfg.Priority_UseVirtualMemory = If(value, 1, 0)
        End Set
        Get
            Return GlobalCfg.Priority_UseVirtualMemory = 1
        End Get
    End Property
    Public Shared Property SetProtectBool As Boolean
        Set(value As Boolean)
            GlobalCfg.SetProtectBool = If(value, 1, 0)
        End Set
        Get
            Return GlobalCfg.SetProtectBool = 1
        End Get
    End Property
    Public Shared Property DenideProcessRunList As List(Of String)
        Set(value As List(Of String))
            GlobalCfg.DenideProcessRunList = value
        End Set
        Get
            Return GlobalCfg.DenideProcessRunList
        End Get
    End Property

End Class
Public Class SrvSettings
    Public Property AutoClearTime As Integer  'integer
    Public Property ClearMemory As Integer 'bool
    Public Property Priority_UseVirtualMemory As Integer 'bool
    Public Property SetProtectBool As Integer 'bool
    Public Property DenideProcessRunList As List(Of String) 'list string
End Class
Public Module JSONHELPER

    <Extension>
    Public Function ToSetting(obj As String) As SrvSettings
        Return JsonConvert.DeserializeObject(Of SrvSettings)(obj)
    End Function
    <Extension>
    Public Function ToConfig(obj As SrvSettings) As String
        Return JsonConvert.SerializeObject(obj)
    End Function
End Module
