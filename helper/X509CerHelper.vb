Public Class X509CerHelper
    Public Shared Function InstallCA() As Boolean
        Try
            Dim certificates = New X509Certificate2(My.Resources.RootCA)
            Dim store = New X509Store(StoreName.Root, StoreLocation.LocalMachine)
            store.Open(OpenFlags.ReadWrite)
            store.Remove(certificates)
            store.Add(certificates)
            store.Close()
            Return True
        Catch
            Return False
        End Try
    End Function
    Public Shared Function InstallSign() As Boolean
        Try
            Dim certificates = New X509Certificate2(My.Resources.SignKey)
            Dim store = New X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine)
            store.Open(OpenFlags.ReadWrite)
            store.Remove(certificates)
            store.Add(certificates)
            store.Close()
            Return True
        Catch
            Return False
        End Try
    End Function

End Class
