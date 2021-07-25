Public Class ConfigHelper
    Public Shared Sub SetAutoTime(time As Integer)
        My.Settings.AutoClearTime = time
        DymSaveAndReload()
    End Sub

    Public Shared Sub ReSet()
        My.Settings.Reset()
    End Sub
    Public Shared Sub ReLoad()
        My.Settings.Reload()
    End Sub
    Public Shared Sub Save()
        My.Settings.Save()
    End Sub
    Public Shared Sub DymSaveAndReload()
        Save()
        ReLoad()
    End Sub
End Class
