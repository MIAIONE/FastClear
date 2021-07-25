Public Class NetworkSetting

    Public Shared Sub SetDNS(dns As String())
        SetIPAddress(Nothing, Nothing, Nothing, dns)
    End Sub

    Public Shared Sub SetGetWay(getway As String)
        SetIPAddress(Nothing, Nothing, New String() {getway}, Nothing)
    End Sub

    Public Shared Sub SetGetWay(getway As String())
        SetIPAddress(Nothing, Nothing, getway, Nothing)
    End Sub

    Public Shared Sub SetIPAddress(ip As String, submask As String)
        SetIPAddress(New String() {ip}, New String() {submask}, Nothing, Nothing)
    End Sub

    Public Shared Sub SetIPAddress(ip As String, submask As String, getway As String)
        SetIPAddress(New String() {ip}, New String() {submask}, New String() {getway}, Nothing)
    End Sub

    Public Shared Sub SetIPAddress(ip As String(), submask As String(), getway As String(), dns As String())
        Dim wmi As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = wmi.GetInstances()
        Dim inPar As ManagementBaseObject
        Dim outPar As ManagementBaseObject

        For Each mo As ManagementObject In moc
            If Not CBool(mo("IPEnabled")) Then Continue For

            If ip IsNot Nothing AndAlso submask IsNot Nothing Then
                inPar = mo.GetMethodParameters("EnableStatic")
                inPar("IPAddress") = ip
                inPar("SubnetMask") = submask
                outPar = mo.InvokeMethod("EnableStatic", inPar, Nothing)
            End If

            If getway IsNot Nothing Then
                inPar = mo.GetMethodParameters("SetGateways")
                inPar("DefaultIPGateway") = getway
                outPar = mo.InvokeMethod("SetGateways", inPar, Nothing)
            End If

            If dns IsNot Nothing Then
                inPar = mo.GetMethodParameters("SetDNSServerSearchOrder")
                inPar("DNSServerSearchOrder") = dns
                outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, Nothing)
            End If
        Next
    End Sub

    Public Shared Sub EnableDHCP()
        Dim wmi As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = wmi.GetInstances()

        For Each mo As ManagementObject In moc
            If Not CBool(mo("IPEnabled")) Then Continue For
            mo.InvokeMethod("SetDNSServerSearchOrder", Nothing)
            mo.InvokeMethod("EnableDHCP", Nothing)
        Next
    End Sub

    Public Shared Function IsIPAddress(ip As String) As Boolean
        Dim arr As String() = ip.Split("."c)
        If arr.Length <> 4 Then Return False

        For i As Integer = 0 To arr.Length - 1
            Dim d As String = arr(i)
            If i = 0 AndAlso d = "0" Then Return False
            If Not Regex.IsMatch(d, "\d{1,3}") Then Return False

            If d <> "0" Then
                d = d.TrimStart("0"c)
                If d = "" Then Return False
                If Integer.Parse(d) > 255 Then Return False
            End If
        Next

        Return True
    End Function

End Class
