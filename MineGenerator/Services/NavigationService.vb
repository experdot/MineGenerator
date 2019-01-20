Namespace Services
    Public Module NavigationService

        Public ReadOnly Property MainFrame As Frame

        Public Sub AttachNavigationService(frame As Frame)
            _MainFrame = frame
        End Sub
    End Module
End Namespace
