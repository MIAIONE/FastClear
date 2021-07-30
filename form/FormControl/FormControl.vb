Public Class FormControl
    Public ReadOnly Property MainForm As DResultPercents
    Public Sub New()
        MainForm = New DResultPercents
    End Sub
    Public Shared Function GetControlCheckBoxChecked(controls As UICheckBox) As Boolean
        Dim value As Boolean
        If controls.InvokeRequired Then
            Dim actionDelegate As Action = Sub()
                                               value = controls.Checked
                                           End Sub
            controls.Invoke(actionDelegate)
        Else
            value = controls.Checked
        End If
        Return value
    End Function
    Public Sub Show()
        If MainForm.InvokeRequired Then
            Dim actionDelegate As Action = Sub()
                                               MainForm.ShowDialog()
                                           End Sub
            MainForm.Messages.Invoke(actionDelegate)
        Else
            MainForm.ShowDialog()
        End If
    End Sub
    Public Sub Close()
        If MainForm.InvokeRequired Then
            Dim actionDelegate As Action = Sub()
                                               MainForm.AutoCloseMe()
                                           End Sub
            MainForm.Messages.Invoke(actionDelegate)
        Else
            MainForm.AutoCloseMe()
        End If
    End Sub
    Public Sub AppendMsg(text As String)
        If MainForm.Messages.InvokeRequired Then
            Dim actionDelegate As Action(Of String) = Sub(x)
                                                          MainForm.Messages.AppendText(x + vbCrLf)
                                                      End Sub
            MainForm.Messages.Invoke(actionDelegate, text)
        Else
            MainForm.Messages.AppendText(text + vbCrLf)
        End If
    End Sub
    Public Sub SetMsg(text As String)
        If MainForm.Messages.InvokeRequired Then
            Dim actionDelegate As Action(Of String) = Sub(x)
                                                          MainForm.Messages.Text = x
                                                      End Sub
            MainForm.Messages.Invoke(actionDelegate, text)
        Else
            MainForm.Messages.Text = text
        End If
    End Sub
    Public Sub SetPercent(value As UInteger)
        If MainForm.Messages.InvokeRequired Then
            Dim actionDelegate As Action(Of UInteger) = Sub(x)
                                                            MainForm.Percents.Value = x
                                                        End Sub
            MainForm.Percents.Invoke(actionDelegate, value)
        Else
            MainForm.Percents.Value = value
        End If
    End Sub
End Class
