Imports MineGenerator.ViewModels

Namespace Views
    Class MainPage
        Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            DataContext = MainViewModel.Instance
        End Sub
    End Class

End Namespace
