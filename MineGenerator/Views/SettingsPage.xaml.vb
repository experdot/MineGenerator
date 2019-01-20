Namespace Views
    Class SettingsPage
        Shared _Current As SettingsPage
        Public Shared ReadOnly Property Current As SettingsPage
            Get
                If _Current Is Nothing Then
                    _Current = New SettingsPage
                End If
                Return _Current
            End Get
        End Property
    End Class

End Namespace
