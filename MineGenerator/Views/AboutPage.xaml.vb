Namespace Views
    Class AboutPage
        Private Sub TblVer_Loaded(sender As Object, e As RoutedEventArgs) Handles TblVer.Loaded
            TblVer.Text = "Version:" & If(Me.GetType.Assembly.GetCustomAttributes(GetType(Reflection.AssemblyFileVersionAttribute), False).OfType(Of Reflection.AssemblyFileVersionAttribute).FirstOrDefault?.Version, "未知")
        End Sub

        Private Sub Hyperlink_RequestNavigate(sender As Object, e As RequestNavigateEventArgs)
            Process.Start(DirectCast(sender, Hyperlink).NavigateUri.ToString)
            e.Handled = True
        End Sub
    End Class
End Namespace
